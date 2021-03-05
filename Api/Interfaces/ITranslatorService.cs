using Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface ITranslatorService
    {
        Task<List<LanguageViewModel>> GetSupportedLanguages();
        Task<TranslateViewModel> Translate(string text, string to);
    }
}
