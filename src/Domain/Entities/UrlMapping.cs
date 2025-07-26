using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UrlMapping
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? ShortCode { get; set; }
        public string? LongUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; set; }
        public int AccessCount { get; set; } = 0;
    }
}
