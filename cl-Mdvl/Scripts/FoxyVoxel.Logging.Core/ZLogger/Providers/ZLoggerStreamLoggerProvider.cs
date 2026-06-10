using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ZLogger.Providers
{
	[ProviderAlias("ZLoggerStream")]
	public class ZLoggerStreamLoggerProvider : ILoggerProvider, IDisposable
	{
		internal const string DefaultOptionName = "ZLoggerStream.Default";

		private AsyncStreamLineMessageWriter streamWriter;

		public ZLoggerStreamLoggerProvider(Stream stream, IOptionsMonitor<ZLoggerOptions> options)
			: this(stream, "ZLoggerStream.Default", options)
		{
		}

		public ZLoggerStreamLoggerProvider(Stream stream, string? optionName, IOptionsMonitor<ZLoggerOptions> options)
		{
			streamWriter = new AsyncStreamLineMessageWriter(stream, options.Get(optionName ?? "ZLoggerStream.Default"));
		}

		public ILogger CreateLogger(string categoryName)
		{
			return new AsyncProcessZLogger(categoryName, streamWriter);
		}

		public void Dispose()
		{
			streamWriter.DisposeAsync().AsTask().Wait();
		}
	}
}
