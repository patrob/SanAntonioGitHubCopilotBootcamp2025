using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UrlListApp.Models
{
    public class UrlList
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? Title { get; set; }
        public string? CustomUrl { get; set; }
        public List<UrlItem> Items { get; set; } = new();
        public bool Published { get; set; } = false;
    }

    public class UrlItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Url]
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
