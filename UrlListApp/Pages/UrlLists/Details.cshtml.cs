using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using System.Linq;

namespace UrlListApp.Pages.UrlLists
{
    public class DetailsModel : PageModel
    {
        public UrlList? UrlList { get; set; }
        public IActionResult OnGet(Guid id)
        {
            UrlList = IndexModel.UrlListsStore.FirstOrDefault(l => l.Id == id);
            if (UrlList == null)
                return RedirectToPage("Index");
            return Page();
        }
    }
}
