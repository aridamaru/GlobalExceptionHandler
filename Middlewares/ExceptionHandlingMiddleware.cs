using System.Net;
using System.Text.Json;
using GEH.Dto;

namespace GEH.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogError(ex.Message);
            await HandleExceptionAsync(httpContext, ex.Message,
                HttpStatusCode.NotFound,
                ex.GetType().ToString());
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            await HandleExceptionAsync(httpContext, e.Message,
                HttpStatusCode.NotFound,
                e.GetType().ToString());
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext,
        string exMsg,
        HttpStatusCode statusCode,
        string message)
    {
        _logger.LogError(exMsg);
        HttpResponse response = httpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)statusCode;
        ErrorDto errorDto = new()
        {
            Message = message,
            StatusCode = (int)statusCode
        };
        string result = errorDto.ToString();
        await response.WriteAsJsonAsync(result);
    }
}