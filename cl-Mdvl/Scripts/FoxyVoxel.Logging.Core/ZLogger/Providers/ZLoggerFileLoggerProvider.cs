using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ZLogger.Providers
{
	[ProviderAlias("ZLoggerFile")]
	public class ZLoggerFileLoggerProvider : ILoggerProvider, IDisposable
	{
		internal const string DefaultOptionName = "ZLoggerFile.Default";

		private AsyncStreamLineMessageWriter streamWriter;

		public ZLoggerFileLoggerProvider(string filePath, IOptionsMonitor<ZLoggerOptions> options)
			: this(filePath, "ZLoggerFile.Default", options)
		{
		}

		public ZLoggerFileLoggerProvider(string filePath, string? optionName, IOptionsMonitor<ZLoggerOptions> options)
		{
			DirectoryInfo directory = new FileInfo(filePath).Directory;
			if (!directory.Exists)
			{
				directory.Create();
			}
			ZLoggerOptions options2 = options.Get(optionName ?? "ZLoggerFile.Default");
			FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 1, useAsync: false);
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
