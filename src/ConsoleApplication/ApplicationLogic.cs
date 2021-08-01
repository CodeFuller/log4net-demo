using System;
using System.Threading;
using System.Threading.Tasks;
using CodeFuller.Library.Bootstrap;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
	internal class ApplicationLogic : IApplicationLogic
	{
		private readonly ILogger<ApplicationLogic> logger;

		public ApplicationLogic(ILogger<ApplicationLogic> logger)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public Task<int> Run(string[] args, CancellationToken cancellationToken)
		{
			logger.LogInformation("Starting application ...");

			using (logger.AddScopeProperty("property1", "VALUE_1"))
			{
				logger.LogInformation("Message from first scope");
				using (logger.AddScopeProperty("property2", "VALUE_2"))
				{
					logger.LogInformation("Message from second scope");
				}
			}

			logger.LogInformation("Exiting application ...");

			return Task.FromResult(0);
		}
	}
}
