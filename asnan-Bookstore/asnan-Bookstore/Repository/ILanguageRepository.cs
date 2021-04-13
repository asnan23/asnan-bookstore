using asnan_Bookstore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace asnan_Bookstore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}