using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebApplication.Extensions;

namespace WebApplication.Middleware
{
	public class RequestLoggingMiddleware
	{
		private readonly RequestDelegate next;
		private readonly ILogger logger;

		public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
		{
			this.next = next;
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task Invoke(HttpContext context)
		{
			var sw = Stopwatch.StartNew();

			try
			{
				await next(context);
			}
			finally
			{
				sw.Stop();

				// TODO: Find a better way for getting request status.
				var statusCode = context.Response.StatusCode;
				var succeeded = statusCode >= 200 && statusCode < 299;
				var dataSize = context.GetRequestLogProperty("data_size");

				logger.LogInformation($"requestInfo success={succeeded} duration={sw.ElapsedMilliseconds} statusCode={statusCode} data_size={dataSize}");
			}
		}
	}
}
