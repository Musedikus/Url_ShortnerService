using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public static class UrlHelper
    {
        public static string ExtractShortCode(string shortUrl)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
                return null;

            var decodedUrl = Uri.UnescapeDataString(shortUrl);

            if (!Uri.TryCreate(decodedUrl, UriKind.Absolute, out var uri))
                return null;

            var shortCode = uri.Segments.LastOrDefault()?.Trim('/');
            return string.IsNullOrWhiteSpace(shortCode) ? null : shortCode;
        }
    }
}
