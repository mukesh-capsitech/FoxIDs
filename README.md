# FoxIDs

FoxIDs is an open source security service (identity service) supporting login, OAuth 2.0, OpenID Connect 1.0, SAML 2.0 and convention between the standards.

FoxIDs is a cloud service ready to be deployed in you Azure tenant. In the future, it will also be possible to use FoxIDs on [https://FoxIDs.com](https://foxids.com) for at small transaction fee.

> For [Getting started](https://github.com/ITfoxtec/FoxIDs/wiki/Getting-started) guide and more documentation please see the [Wiki](https://github.com/ITfoxtec/FoxIDs/wiki).

> FoxIDs is .NET Core 3.1 and the Control Client is Blazor .NET Standard 2.1.

## Deployment

Deploy FoxIDs in your Azure tenant. 

> After sucessfully deployment open FoxIDs Control Client https<i>:</i>//foxidscontrolxxxxxxxxxx.azurewebsites.net (the app service starting with foxidscontrol). 
> The default admin user is: admin<i>@</i>foxids.com with password: FirstAccess!

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FITfoxtec%2FFoxIDs%2Frelease-current%2Fazuredeploy.json)

- Two App Services one for FoxIDs and one for the FoxIDs Control (Client and API). Both App Services is hosted in the same App Service plan. 
- FoxIDs is deployed to the two App Services from the `release-current` branch with Kudu. Thereafter, it is possible to manually initiate the Kudu update.
- Key vault. Secrets are placed in Key vault.
- Document DB.
- Redis cache.
- SendGrid.
- Application Insights.

**Troubleshooting deployent errors:**

> **Sendgrid terms.** If you have not already accepted the Sendgrid legal terms for the selected plan in the subscription you will get the error 
> *"User failed validation to purchase resources. Error message: 'Legal terms have not been accepted for this item on this subscription: 'XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX'. To accept legal terms using PowerShell, please use Get-AzureRmMarketplaceTerms and Set-AzureRmMarketplaceTerms API(https://go.microsoft.com/fwlink/?linkid=862451) or deploy via the Azure portal to accept the terms'"* 
>
> You need to accept the terms either by deploying a Sendgrid instance in [Azure portal](https://portal.azure.com) or with PowerShell. 
> The following PowerShell commands accept the Sendgrid terms for the free plan:
>
>     Connect-AzureRmAccount
>     $terms = Get-AzureRmMarketplaceTerms -Publisher 'SendGrid' -Product 'sendgrid_azure' -Name 'free'
>     Set-AzureRmMarketplaceTerms -Publisher 'SendGrid' -Product 'sendgrid_azure' -Name 'free' -Terms $terms -Accept
>
> Then delete the falling resource groups and redeploy.

### 2. Seed



#### 2.3 Create risk passwords

The seed tool can add risk passwords of insecure passwords to use in Cosmos DB documents as SHA-1 hashes. The insecure passwords (pwned passwords) is from [haveibeenpwned.com](https://haveibeenpwned.com)

Download the `SHA-1` pwned passwords `ordered by hash` from [haveibeenpwned.com/passwords](https://haveibeenpwned.com/Passwords).

Add the local pwned passwords file path to the seed tool configured.

```json
"SeedSettings": {
  "PwnedPasswordsPath": "c:\\... xxx ...\\pwned-passwords-sha1-ordered-by-count-v4.txt"
}
```

> Be aware that it takes some time to upload all risk passwords. This step can be omitted and postponed to later.

> The risk passwords are uploaded as bulk which has a higher consumption. Please make sure to adjust the Cosmos DB provisioned throughput (RU/s) temporarily.

Run the seed tool executable `SeedTool.exe`, select `P` for `Create risk passwords`.

#### 2.4 Add sample configuration to at track

It is possible to run the sample applications after they are configured in a FoxIDs track. The sample configuration can be added with the [sample seed tool](https://github.com/ITfoxtec/FoxIDs/wiki/Samples#Configure-samples-in-FoxIDs-track).

## Support

Please ask your question on <a href="https://stackoverflow.com/">Stack Overflow</a> and email a link to <a href="mailto:support@itfoxtec.com?subject=FoxIDs">support@itfoxtec.com</a> for me to answer.<br />

## Development

FoxIDs
https://localhost:44330

FoxIDs Control (Blazor WebAssembly client and API)
https://localhost:44331

*FoxIDs web
https://localhost:44333 - not created yet*
