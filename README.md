# HAL-GPT-3

## Welcome to my HAL-GPT-3 repository! 

This repository contains two assets that you need to get this application working in your environment:

- Power Platform solution: HALGPT3_1_0_0_X_managed.zip
- Azure Function App Visual Studio project: PowerApps.TalkWithChatGPT

You can use this link to see the app in action: https://youtube.com/shorts/H5hfnjMHs7U?feature=share

![image](https://user-images.githubusercontent.com/10154416/219325525-4fb6f0c0-b8ec-4910-bcc1-ddafd5f04300.png)

## Instructions
You need the following services available and the listed secrets and other values before importing the solution package:

1. Azure Blob Storage - https://azure.microsoft.com/en-us/products/storage/blobs/
2. Azure Cognitive Services - https://azure.microsoft.com/en-us/products/cognitive-services/
3. Azure Function App - https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview
4. OpenAI API access - https://platform.openai.com/account/api-keys


|Environment variable |Example  |Notes |
--- | --- | ---|
|Blob Storage Public Folder|public|You need to create a public folder under your storage account where response from Azure Cognitive Service Text to Speech audio file is stored|
|Cognitive Services Subscription Key|232126c...|Key to access your Cognitive Services API|
|Convert to WAV enpoint|https://...v.azurewebsites.net/api/ConvertToWAV?code=X1x...|The function endpoint of your published PowerApps.TalkWithChatGPT Azure Function App|
|OpenAI Bearer Token|sk-Oy...|Your OpenAI API access key|
|Storage Account Name|chatgptstorage|Storage account name of your Blob Storage|

### Step 1: Create Azure resources and deploy Function App

Create the above listed Azure resources and take note of all the needed values and secrets described in the above table. A Visual Studio solution for the Azure Function App can be found under [PowerApps.TalkWithChatGPT](https://github.com/TerhoAntila/HAL-GPT-3/tree/master/PowerApps.TalkWithChatGPT) folder.

Create also a publicly available folder in Azure Blob Storage where the response audio will be stored.

### Step 2: Install Power Platform solution into your target environment

Download the latest solution package. The latest package is [1.0.0.6](https://github.com/TerhoAntila/HAL-GPT-3/blob/master/HALGPT3_1_0_0_6_managed.zip), but you should double check that above, if I forget to update this link :)

Import the solution into your environment. While importing, you are requested to provide Environment Variable values listed in the table presented earlier.

Once you are done with all of the above, you are good to go (hopefully)!
