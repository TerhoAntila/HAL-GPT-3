using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace PowerApps.TalkWithChatGPT
{
    public static class ConvertToWAV
    {
        // https://kamdaryash.wordpress.com/2020/02/05/create-a-pdf-file-of-text-converted-from-speech-recorded-in-powerapps-using-azure-cognitive-services-part-2/

        [FunctionName("ConvertToWAV")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var temp = Path.GetTempFileName() + ".source.audio";
            var tempOut = Path.GetTempFileName() + ".wav";
            var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempPath);
            using (var ms = new MemoryStream())
            {
                req.Body.CopyTo(ms);
                File.WriteAllBytes(temp, ms.ToArray());
            }
            var bs = File.ReadAllBytes(temp);
            log.LogInformation($"Renc Length: { bs.Length}");
            try
            {
                var psi = new ProcessStartInfo();
                psi.FileName = @"D:\home\site\wwwroot\ffmpeg.exe";
                psi.Arguments = $"-i \"{ temp}\" \"{ tempOut}\"";
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                log.LogInformation($"Args: { psi.Arguments}");
                var process = Process.Start(psi);
                process.WaitForExit((int)TimeSpan.FromSeconds(60).TotalMilliseconds);
            }
            catch (Exception ex)
            {
                log.LogInformation(ex.Message);
            }
            var bytes = File.ReadAllBytes(tempOut);
            log.LogInformation($"Renc Length: { bytes.Length}");
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(new MemoryStream(bytes));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");
                File.Delete(tempOut);
                File.Delete(temp);
                Directory.Delete(tempPath, true);
                return response;
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                throw;
            }
        }
    }
}
