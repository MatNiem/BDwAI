using BDwAI.Models;

namespace BDwAI.Services
{
    public interface IPlacowkiService
    {
        List<Placowka> GetPlacowkas();
        Placowka GetPlacowka(int id);
        string GetPlacowkaImage(int placowkaId);
    }
}
