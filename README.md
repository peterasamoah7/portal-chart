<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

<!-- PROJECT LOGO -->
<br />
<p align="center">
<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
      </ul>
      <ul>
        <li><a href="#setup">Setup & Running</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project
Portal Chat is a chat application that improves the overall chat experience by removing language constraints. Portal Chat provides real-time language translation so users can send and receive messages in their language of choice. 


You can view the demo [here]()

You can try the live application here [Live site](https://ashy-bay-0f647ba03.azurestaticapps.net)
### Built With
* [Azure Functions](https://azure.microsoft.com/services/functions/)
* [Azure SignalR Service](https://azure.microsoft.com/services/signalr-service/)
* [Azure Cognitive Services Translator](https://azure.microsoft.com/services/cognitive-services/translator/)

<!-- GETTING STARTED -->
## Getting Started

To run the application locally, please follow the steps below.

### Prerequisites

* [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)
* [Azure Account](https://azure.microsoft.com/)

### Setup

1. Clone the repo.
2. Create a free Azure Account [here](https://azure.microsoft.com/) or use an existing one. 
3. Create a free Azure Cognitive Service Translator service. Follow the steps [here](https://docs.microsoft.com/en-gb/azure/cognitive-services/translator/translator-how-to-signup).
4. Create an Azure SignalR Service. Follow the steps [here](https://docs.microsoft.com/en-us/azure/azure-signalr/signalr-quickstart-azure-functions-csharp).
5. Download and install Visual Studio Code from [Visual Studio Code](https://code.visualstudio.com/) or Visual Studio 2019 from [Visual Studio](https://visualstudio.microsoft.com/).
6. Open project using your Visual Studio 2019 or Visual Studio Code.
7. Update local.setting.json with the following, if local.setting.json is missing create one and add the json content below and update wih your credentials.
  ```sh
  {
    "IsEncrypted": false,
    "Values": {
      "AzureWebJobsStorage": "UseDevelopmentStorage=true",
      "FUNCTIONS_WORKER_RUNTIME": "dotnet",
      "AzureSignalRConnectionString": "<add your azure signalr service connection string here>",
      "AzureTranslator": "<add your translator endpoint here>",
      "TranslatorSubKey": "<add your translator subscription key here>",
      "ResourceLocation": "<add your translator service resource location in azure here>"
    },
    "Host": {
      "LocalHttpPort": 7071,
      "CORS": "<add base url of client app>",
      "CORSCredentials": true
    }`
  }
  ```

### Running from Visual Studio Code

1. Install Azure Function core tools. Follow the steps here to install the right tools for your device [Azure Function Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local).

2. Run Azure Function locally.
```sh
func start
```

### Running from Visual Studio Code

1. From Visual Studio, press `F5`


## Usage

Please refer to the [demo]()

## License

Distributed under the MIT License. See `LICENSE` for more information.

