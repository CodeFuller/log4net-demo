using System.Threading.Tasks;

namespace ConsoleApplication
{
	public static class Program
	{
		public static async Task<int> Main(string[] args)
		{
			using var bootstrapper = new ApplicationBootstrapper();
			var application = new CodeFuller.Library.Bootstrap.ConsoleApplication(bootstrapper);

			return await application.Run(args);
		}
	}
}
