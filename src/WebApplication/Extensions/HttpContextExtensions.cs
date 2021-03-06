using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Extensions
{
	public static class HttpContextExtensions
	{
		private const string RequestLogScopeKey = "RequestLogPropertiesKey";

		public static void AddRequestLogProperty<TValue>(this HttpContext httpContext, string property, TValue value)
		{
			var logProperties = httpContext.GetContextValue<Dictionary<string, object>>(RequestLogScopeKey);
			if (logProperties == null)
			{
				logProperties = new Dictionary<string, object>();
				httpContext.Items.Add(RequestLogScopeKey, logProperties);
			}

			logProperties[property] = value?.ToString();
		}

		public static object GetRequestLogProperty(this HttpContext httpContext, string property)
		{
			var logProperties = httpContext.GetContextValue<Dictionary<string, object>>(RequestLogScopeKey);
			if (logProperties == null)
			{
				return null;
			}

			return logProperties.TryGetValue(property, out var value) ? value : null;
		}

		public static IReadOnlyDictionary<string, object> GetRequestLogProperties(this HttpContext httpContext)
		{
			return httpContext.GetContextValue<Dictionary<string, object>>(RequestLogScopeKey) ?? new Dictionary<string, object>();
		}

		private static T GetContextValue<T>(this HttpContext httpContext, string key)
		{
			return httpContext.Items.TryGetValue(key, out var value) && (value is T typedValue) ? typedValue : default;
		}
	}
}
