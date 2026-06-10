using System;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ZLogger.Providers
{
	[ProviderAlias("ZLoggerConsole")]
	public class ZLoggerConsoleLoggerProvider : ILoggerProvider, IDisposable
	{
		internal const string DefaultOptionName = "ZLoggerConsole.Default";

		private AsyncStreamLineMessageWriter streamWriter;

		public ZLoggerConsoleLoggerProvider(IOptionsMonitor<ZLoggerOptions> options)
			: this(consoleOutputEncodingToUtf8: true, null, options)
		{
		}

		public ZLoggerConsoleLoggerProvider(bool consoleOutputEncodingToUtf8, string? optionName, IOptionsMonitor<ZLoggerOptions> options)
			: this(consoleOutputEncodingToUtf8, outputToErrorStream: false, optionName, options)
		{
		}

		public ZLoggerConsoleLoggerProvider(bool consoleOutputEncodingToUtf8, bool outputToErrorStream, string? optionName, IOptionsMonitor<ZLoggerOptions> options)
		{
			if (consoleOutputEncodingToUtf8)
			{
				Console.OutputEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
			}
			ZLoggerOptions options2 = options.Get(optionName ?? "ZLoggerConsole.Default");
			streamWriter = new AsyncStreamLineMessageWriter(outputToErrorStream ? Console.OpenStandardError() : Console.OpenStandardOutput(), options2);
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
