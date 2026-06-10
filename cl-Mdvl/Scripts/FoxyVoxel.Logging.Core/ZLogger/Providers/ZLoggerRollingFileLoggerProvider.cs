using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ZLogger.Providers
{
	[ProviderAlias("ZLoggerRollingFile")]
	public class ZLoggerRollingFileLoggerProvider : ILoggerProvider, IDisposable
	{
		internal const string DefaultOptionName = "ZLoggerRollingFile.Default";

		private AsyncStreamLineMessageWriter streamWriter;

		public ZLoggerRollingFileLoggerProvider(Func<DateTimeOffset, int, string> fileNameSelector, Func<DateTimeOffset, DateTimeOffset> timestampPattern, int rollSizeKB, IOptionsMonitor<ZLoggerOptions> options)
			: this(fileNameSelector, timestampPattern, rollSizeKB, "ZLoggerRollingFile.Default", options)
		{
		}

		public ZLoggerRollingFileLoggerProvider(Func<DateTimeOffset, int, string> fileNameSelector, Func<DateTimeOffset, DateTimeOffset> timestampPattern, int rollSizeKB, string? optionName, IOptionsMonitor<ZLoggerOptions> options)
		{
			ZLoggerOptions options2 = options.Get(optionName ?? "ZLoggerRollingFile.Default");
			RollingFileStream stream = new RollingFileStream(fileNameSelector, timestampPattern, rollSizeKB, options2);
			streamWriter = new AsyncStreamLineMessageWriter(stream, options2);
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
