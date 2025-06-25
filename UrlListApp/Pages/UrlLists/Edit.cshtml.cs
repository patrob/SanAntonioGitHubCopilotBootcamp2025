using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using System.Linq;

namespace UrlListApp.Pages.UrlLists
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public UrlList? UrlList { get; set; }

        public IActionResult OnGet(Guid id)
        {
            UrlList = IndexModel.UrlListsStore.FirstOrDefault(l => l.Id == id);
            if (UrlList == null)
                return RedirectToPage("Index");
            return Page();
        }

        public IActionResult OnPost(Guid id)
        {
            var existing = IndexModel.UrlListsStore.FirstOrDefault(l => l.Id == id);
            if (existing == null || UrlList == null)
                return RedirectToPage("Index");
            if (!ModelState.IsValid)
                return Page();
            existing.Title = UrlList.Title;
            existing.CustomUrl = UrlList.CustomUrl;
            return RedirectToPage("Index");
        }
    }
}
