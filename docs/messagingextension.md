# Develop a messaging extension

* Run `ngrok.exe http 5000`, because our web api project will listen on port 5000.
* Copy the ngrok url.
![ngrok](assets/messagingextension_en_us/ngrok.png)

* Create a bot using Teams App Stdio or the BotFramework web [https://dev.botframework.com/bots/new](https://dev.botframework.com/bots/new). Greater detail can be found [here](https://docs.microsoft.com/en-us/microsoftteams/platform/concepts/bots/bots-create). Regards to the `Messaging endpoint`, input the ngrok url with the postfix `/api/extension`

![bot-reg](assets/messagingextension_en_us/bot-reg.png)

* When a bot is created, remember the `Microsoft App ID` which will be used in the next step.

![get-app-id](assets/messagingextension_en_us/get-app-id.png)

* Run `dotnet new teamsmsgext --name SampleApp` to generate the project.

* Open `SampleApp/manifest/manifest.json` file, paste `Microsoft App ID` you got in previous step.

![manifest-json](assets/messagingextension_en_us/manifest-json.png)

* Zip `SampleApp/manifest` folder into manifest.zip file.

![zip-manifest](assets/messagingextension_en_us/zip-manifest.png)

* Upload manifest.zip file into your Teams. `Manage Team -> Apps`, click the bottom-right link `Upload a custom app`

![upload-custom-app](assets/messagingextension_en_us/upload-custom-app.png)

* Start the project by running `dotnet run`.

* All done, you can switch to Microsoft Teams, go to a team's channel into which you have uploaded the custom app(the zip file), click the `...` button, you can find your messaging extension.

![msg-ext](assets/messagingextension_en_us/msg-ext.png)

![msg-ext-select-city](assets/messagingextension_en_us/msg-ext-select-city.png)

![msg-ext-seattle](assets/messagingextension_en_us/msg-ext-seattle.png)

