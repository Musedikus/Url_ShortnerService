using Application.Common.Models;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Helpers;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Application.Services
{
    public class UrlService : IUrlService
    {
        private readonly UrlDbContext _context;
        private readonly IConfiguration _config;
        public UrlService(UrlDbContext context,IConfiguration config)
        {
            _context = context;
            _config = config;   

        }

        public async Task<ResultModel<ShortenUrlResponse>> ShortenUrlAsync(string longUrl)
        {
            if (!Uri.IsWellFormedUriString(longUrl, UriKind.Absolute))
                return ResultModel<ShortenUrlResponse>.Failure($"Invalid URL");   //Handle edge cases such as invalid URLs

            var shortnerDomain = _config["ShortenerDomain"];

            var existing = await _context.UrlMappings.FirstOrDefaultAsync(x => x.LongUrl == longUrl);
            if (existing != null)
                return ResultModel<ShortenUrlResponse>.SuccessResponse(new ShortenUrlResponse { ShortUrl = $"{shortnerDomain}/{existing.ShortCode}" }, "Url Was Successfully Shortened.");
            

            var shortCode = await GenerateUniqueShortCodeAsync();
            var entity = new UrlMapping { ShortCode = shortCode, LongUrl = longUrl };
            _context.UrlMappings.Add(entity);
            await _context.SaveChangesAsync();

            return ResultModel<ShortenUrlResponse>.SuccessResponse(new ShortenUrlResponse { ShortUrl = $"{shortnerDomain}/{shortCode}" }, "Url Was Successfully Shortened."); ;
        }

        public async Task<string> GetLongUrlAsync(string shortUrl)
        {
            // Extract the short code from the URL
            var decodedUrl = Uri.UnescapeDataString(shortUrl);
            if (!Uri.TryCreate(decodedUrl, UriKind.Absolute, out var uri))
                return null;

            string shortCode = uri.Segments.LastOrDefault()?.Trim('/');
            if (string.IsNullOrWhiteSpace(shortCode))
                return null;

            // Query the database
            var mapping = await _context.UrlMappings.FirstOrDefaultAsync(x => x.ShortCode == shortCode);
            if (mapping == null || (mapping.ExpiryDate.HasValue && mapping.ExpiryDate < DateTime.UtcNow))
                return null;

            // Update stats
            mapping.AccessCount++;
            await _context.SaveChangesAsync();

            return mapping.LongUrl;
        }

        public async Task<int> GetStatsAsync(string shortUrl)
        {
            var shortCode = UrlHelper.ExtractShortCode(shortUrl);
            if (!string.IsNullOrWhiteSpace(shortCode))
                return 0;
            var mapping = await _context.UrlMappings.FirstOrDefaultAsync(x => x.ShortCode == shortCode);
            return mapping?.AccessCount ?? 0;
        }

        private async Task<string> GenerateUniqueShortCodeAsync()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            string shortCode;


            //Checks db untill short code is unique
            do
            {
                shortCode = new string(Enumerable.Range(1, 7).Select(_ => chars[random.Next(chars.Length)]).ToArray());
            }
            while (await _context.UrlMappings.AnyAsync(x => x.ShortCode == shortCode));

            return shortCode;
        }
    }
}
