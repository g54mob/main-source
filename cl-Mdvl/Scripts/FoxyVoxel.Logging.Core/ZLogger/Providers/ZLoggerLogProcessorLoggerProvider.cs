using System;
using Microsoft.Extensions.Logging;

namespace ZLogger.Providers
{
	[ProviderAlias("ZLoggerLogProcessor")]
	public class ZLoggerLogProcessorLoggerProvider : ILoggerProvider, IDisposable
	{
		private IAsyncLogProcessor processor;

		public ZLoggerLogProcessorLoggerProvider(IAsyncLogProcessor processor)
		{
			this.processor = processor;
		}

		public ILogger CreateLogger(string categoryName)
		{
			return new AsyncProcessZLogger(categoryName, processor);
		}

		public void Dispose()
		{
			processor.DisposeAsync().AsTask().Wait();
		}
	}
}
