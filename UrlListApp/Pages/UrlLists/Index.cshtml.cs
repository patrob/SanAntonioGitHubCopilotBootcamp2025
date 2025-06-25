using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlListApp.Models;
using System.Collections.Generic;

namespace UrlListApp.Pages.UrlLists
{
    public class IndexModel : PageModel
    {
        // In-memory store for demo; replace with DB in production
        public static List<UrlList> UrlListsStore { get; set; } = new();
        public List<UrlList> UrlLists => UrlListsStore;
        public void OnGet() { }
    }
}
