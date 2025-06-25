using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;

namespace UrlListApp.Pages.UrlLists
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public UrlList UrlList { get; set; } = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // Generate a unique custom URL if not provided
            if (string.IsNullOrWhiteSpace(UrlList.CustomUrl))
            {
                UrlList.CustomUrl = $"list-{Guid.NewGuid().ToString().Substring(0, 8)}";
            }
            // Add to in-memory store
            IndexModel.UrlListsStore.Add(UrlList);
            return RedirectToPage("Index");
        }
    }
}
