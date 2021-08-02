using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApplication.Extensions
{
	public static class LoggerExtensions
	{
		public static IDisposable AddScopeProperty<TValue>(this ILogger logger, string property, TValue value)
		{
			return logger.BeginScope(new Dictionary<string, object> { { property, value } });
		}

		public static IDisposable CreateRequestLoggingScope(this ILogger logger, HttpContext httpContext)
		{
			return logger.BeginScope(httpContext.GetRequestLogProperties());
		}

		public static IDisposable CreateRequestLoggingScope<TValue>(this ILogger logger, HttpContext httpContext, string property, TValue value)
		{
			httpContext.AddRequestLogProperty(property, value);

			return logger.AddScopeProperty(property, value);
		}
	}
}
