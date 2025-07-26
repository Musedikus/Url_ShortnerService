using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;
        private readonly IConfiguration _config;

        public UrlController(IUrlService urlService, IConfiguration config)
        {
            _urlService = urlService;
            _config = config;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> Shorten([FromBody] ShortenUrlRequest request)
        {
            
                var result = await _urlService.ShortenUrlAsync(request.LongUrl);
                return Ok(result);
           
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> RedirectToLongUrl(string shortUrl)
        {
            var longUrl = await _urlService.GetLongUrlAsync(shortUrl);
            return longUrl == null ? NotFound() : Redirect(longUrl);
        }

        [HttpGet("stats/{shortUrl}")]
        public async Task<IActionResult> GetStats(string shortUrl)
        {
            var result = await _urlService.GetStatsAsync(shortUrl);
            return Ok(result);
        }
    }
}
