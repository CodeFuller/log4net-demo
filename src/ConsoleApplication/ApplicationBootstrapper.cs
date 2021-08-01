using CodeFuller.Library.Bootstrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Log4NetDemo
{
	internal class ApplicationBootstrapper : BasicApplicationBootstrapper<IApplicationLogic>
	{
		protected override void RegisterServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IApplicationLogic, ApplicationLogic>();
		}

		protected override void BootstrapConfiguration(IConfigurationBuilder configurationBuilder, string[] commandLineArgs)
		{
			// This application does not use configuration.
		}

		protected override void BootstrapLogging(ILoggerFactory loggerFactory, IConfiguration configuration)
		{
			loggerFactory.AddLog4Net();
		}
	}
}
