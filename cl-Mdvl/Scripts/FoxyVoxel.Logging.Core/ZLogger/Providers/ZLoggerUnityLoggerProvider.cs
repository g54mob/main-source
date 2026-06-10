using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ZLogger.Providers
{
	[ProviderAlias("ZLoggerUnity")]
	public class ZLoggerUnityLoggerProvider : ILoggerProvider, IDisposable
	{
		private UnityDebugLogProcessor debugLogProcessor;

		public ZLoggerUnityLoggerProvider(IOptions<ZLoggerOptions> options)
		{
			debugLogProcessor = new UnityDebugLogProcessor(options.Value);
		}

		public ILogger CreateLogger(string categoryName)
		{
			return new AsyncProcessZLogger(categoryName, debugLogProcessor);
		}

		public void Dispose()
		{
		}
	}
}
