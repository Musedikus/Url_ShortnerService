using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ResultModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }

        public static ResultModel<T> SuccessResponse(T data, string message = "Success", int statusCode = 200) =>
            new()
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = statusCode
            };

        public static ResultModel<T> Failure(string message = "An error occurred", List<string>? errors = null, int statusCode = 400) =>
            new()
            {
                Success = false,
                Message = message,
                Errors = errors,
                StatusCode = statusCode
            };
    }
}
