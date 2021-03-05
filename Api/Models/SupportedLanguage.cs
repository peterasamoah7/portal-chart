using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class SupportedLanguage
    {
        [JsonProperty("translation")]
        public Dictionary<string, Language> Translations { get; set; }
    }

    public class Language
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("nativeName")]
        public string NativeName { get; set; }
    }

    public class LanguageViewModel
    {
        public string Prefix { get; set; }
        public string Name { get; set; }
    }
}
