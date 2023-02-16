You need to download ffmpeg.exe (e.g. https://ffmpeg.org/download.html#build-windows) and 
add it to the project. Make sure you have ffmpeg.exe properties 
in Visual Studio set correctly, so that it gets deployed to be 
available for the function code:

"Copy to Output Directory" -> "Copy always"