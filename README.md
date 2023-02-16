# HAL-GPT-3

## Welcome to my HAL-GPT-3 repository! 

This repository contains two assets that you need to get this application working in your environment:

- Power Platform solution (unmanaged): HALGPT3_1_0_0_X.zip
- Azure Function App Visual Studio project: PowerApps.TalkWithChatGPT

![image](https://user-images.githubusercontent.com/10154416/219325525-4fb6f0c0-b8ec-4910-bcc1-ddafd5f04300.png)

## Instructions
You need the following services available and the listed secrets and other values before importing the solution package:

1. Azure Blob Storage - https://azure.microsoft.com/en-us/products/storage/blobs/
2. Azure Cognitive Services - https://azure.microsoft.com/en-us/products/cognitive-services/
3. Azure Function App - https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview
4. OpenAI API access - https://platform.openai.com/account/api-keys

|Environment variable|Value|
|env|lk|


|Environment variable |Example  |Notes |
--- | --- | ---|
|Blob Storage Public Folder|public|You need to create a public folder under your storage account where response from Azure Cognitive Service Text to Speech audio file is stored|
|Cognitive Services Subscription Key|232126c...|Key to access your Cognitive Services API|
|Convert to WAV enpoint|https://...v.azurewebsites.net/api/ConvertToWAV?code=X1x...|The function endpoint of your published PowerApps.TalkWithChatGPT Azure Function App|
|OpenAI Bearer Token|sk-Oy...|Your OpenAI API access key|
|Storage Account Name|chatgptstorage|Storage account name of your Blob Storage|


