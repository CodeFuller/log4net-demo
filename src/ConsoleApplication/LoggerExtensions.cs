using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
	public static class LoggerExtensions
	{
		public static IDisposable AddScopeProperty(this ILogger logger, string property, string value)
		{
			return logger.BeginScope(new Dictionary<string, string> { { property, value } });
		}
	}
}
