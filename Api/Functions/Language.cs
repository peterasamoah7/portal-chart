using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Api.Interfaces;
using Api.Models;

namespace Api.Functions
{
    public class Language
    {
        private readonly ITranslatorService _translatorService; 

        public Language(ITranslatorService translatorService)
        {
            _translatorService = translatorService; 
        }

        [FunctionName("Translate")]
        public async Task<IActionResult> Translate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "translate")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<TranslateRequest>(requestBody);

            var response = await _translatorService.Translate(data.Text, data.To); 

            return new OkObjectResult(response);
        }

        [FunctionName("GetSupportLangs")]
        public async Task<IActionResult> GetSupportLangs(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "languages")] HttpRequest req)
        {
            var response = await _translatorService.GetSupportedLanguages();

            return new OkObjectResult(response);
        }
    }
}
