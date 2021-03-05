using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Models
{
    public class TranslateResponse
    {
        [JsonProperty("detectedLanguage")]
        public DetectedLanguage DetectedLanguage { get; set; }
        [JsonProperty("translations")]
        public List<Translation> Translations { get; set; }
    }

    public class DetectedLanguage
    {
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("score")]
        public decimal Score { get; set; }
    }

    public class Translation
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
    }

    public class TranslateViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
    }
}
