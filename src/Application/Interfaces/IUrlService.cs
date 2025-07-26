using Application.Common.Models;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUrlService
    {
        Task<ResultModel<ShortenUrlResponse>> ShortenUrlAsync(string longUrl);
        Task<string> GetLongUrlAsync(string shortUrl);
        Task<ResultModel<StatsResponse>> GetStatsAsync(string shortUrl);
    }
}
