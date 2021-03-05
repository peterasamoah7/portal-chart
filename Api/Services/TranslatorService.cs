using Api.Interfaces;
using Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class TranslatorService : ITranslatorService
    {
        private readonly HttpClient _httpClient; 

        public TranslatorService(HttpClient httpClient)
        {
            httpClient.BaseAddress = 
                new Uri(Environment.GetEnvironmentVariable("AzureTranslator"));
            httpClient.DefaultRequestHeaders
                .Add("Ocp-Apim-Subscription-Key", Environment.GetEnvironmentVariable("TranslatorSubKey"));
            httpClient.DefaultRequestHeaders
               .Add("Ocp-Apim-Subscription-Region", Environment.GetEnvironmentVariable("ResourceLocation"));

            _httpClient = httpClient; 
        }

        /// <summary>
        /// Auto detect and translate
        /// </summary>
        /// <param name="text"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<TranslateViewModel> Translate(string text, string to)
        {
            string route = $"translate?api-version=3.0&to={to}";

            object[] body = new object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            var request = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(route, request);

            result.EnsureSuccessStatusCode();
            var resultstr = await result.Content.ReadAsStringAsync();

            var trResponse = JsonConvert.DeserializeObject<List<TranslateResponse>>(resultstr)?[0];

            return new TranslateViewModel
            {
                From = trResponse.DetectedLanguage.Language,
                To = trResponse.Translations[0].To,
                Text = trResponse.Translations[0].Text
            };
        }

        /// <summary>
        /// Get Supported Languages
        /// </summary>
        /// <param name="text"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<List<LanguageViewModel>> GetSupportedLanguages()
        {
            string route = $"languages?api-version=3.0&scope=translation";

            var result = await _httpClient.GetAsync(route);

            result.EnsureSuccessStatusCode();
            var resultstr = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<SupportedLanguage>(resultstr);

            var model = new List<LanguageViewModel>(); 

            foreach(var item in response.Translations.Keys)
            {
                model.Add(new LanguageViewModel
                {
                    Prefix = item,
                    Name = response.Translations[item].Name
                });
            }

            return model; 
        }
    }
}
