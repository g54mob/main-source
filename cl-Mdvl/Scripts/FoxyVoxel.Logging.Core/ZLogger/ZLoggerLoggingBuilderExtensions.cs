using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;
using ZLogger.Providers;

namespace ZLogger
{
	public static class ZLoggerLoggingBuilderExtensions
	{
		public static ILoggingBuilder AddZLoggerConsole(this ILoggingBuilder builder, bool consoleOutputEncodingToUtf8 = true, bool configureEnableAnsiEscapeCode = false, bool outputToErrorStream = false)
		{
			if (configureEnableAnsiEscapeCode)
			{
				EnableAnsiEscapeCode();
			}
			builder.AddConfiguration();
			builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerConsoleLoggerProvider>((IServiceProvider x) => new ZLoggerConsoleLoggerProvider(consoleOutputEncodingToUtf8, outputToErrorStream, null, x.GetRequiredService<IOptionsMonitor<ZLoggerOptions>>())));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerConsoleLoggerProvider>(builder.Services);
			return builder;
		}

		public static ILoggingBuilder AddZLoggerConsole(this ILoggingBuilder builder, Action<ZLoggerOptions> configure, bool consoleOutputEncodingToUtf8 = true, bool configureEnableAnsiEscapeCode = false, bool outputToErrorStream = false)
		{
			return builder.AddZLoggerConsole("ZLoggerConsole.Default", configure, consoleOutputEncodingToUtf8, configureEnableAnsiEscapeCode, outputToErrorStream);
		}

		public static ILoggingBuilder AddZLoggerConsole(this ILoggingBuilder builder, string optionName, Action<ZLoggerOptions> configure, bool consoleOutputEncodingToUtf8 = true, bool configureEnableAnsiEscapeCode = false, bool outputToErrorStream = false)
		{
			if (configureEnableAnsiEscapeCode)
			{
				EnableAnsiEscapeCode();
			}
			if (configure == null)
			{
				throw new ArgumentNullException("configure");
			}
			builder.AddConfiguration();
			builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerConsoleLoggerProvider>((IServiceProvider x) => new ZLoggerConsoleLoggerProvider(consoleOutputEncodingToUtf8, outputToErrorStream, optionName, x.GetRequiredService<IOptionsMonitor<ZLoggerOptions>>())));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerConsoleLoggerProvider>(builder.Services);
			builder.Services.AddOptions<ZLoggerOptions>(optionName).Configure(configure);
			return builder;
		}

		private static void EnableAnsiEscapeCode()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				WindowsConsoleMode.TryEnableVirtualTerminalProcessing();
			}
		}

		public static ILoggingBuilder AddZLoggerStream(this ILoggingBuilder builder, Stream stream)
		{
			builder.AddConfiguration();
			builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerStreamLoggerProvider>((IServiceProvider x) => new ZLoggerStreamLoggerProvider(stream, x.GetRequiredService<IOptionsMonitor<ZLoggerOptions>>())));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerStreamLoggerProvider>(builder.Services);
			return builder;
		}

		public static ILoggingBuilder AddZLoggerStream(this ILoggingBuilder builder, Stream stream, Action<ZLoggerOptions> configure)
		{
			return builder.AddZLoggerStream(stream, "ZLoggerStream.Default", configure);
		}

		public static ILoggingBuilder AddZLoggerStream(this ILoggingBuilder builder, Stream stream, string optionName, Action<ZLoggerOptions> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException("configure");
			}
			builder.AddConfiguration();
			builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerStreamLoggerProvider>((IServiceProvider x) => new ZLoggerStreamLoggerProvider(stream, optionName, x.GetRequiredService<IOptionsMonitor<ZLoggerOptions>>())));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerStreamLoggerProvider>(builder.Services);
			builder.Services.AddOptions<ZLoggerOptions>(optionName).Configure(configure);
			return builder;
		}

		public static ILoggingBuilder AddZLoggerLogProcessor(this ILoggingBuilder builder, IAsyncLogProcessor logProcessor)
		{
			builder.AddConfiguration();
			builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerLogProcessorLoggerProvider>((IServiceProvider x) => new ZLoggerLogProcessorLoggerProvider(logProcessor)));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerLogProcessorLoggerProvider>(builder.Services);
			return builder;
		}

		public static ILoggingBuilder AddZLoggerFile(this ILoggingBuilder builder, string fileName)
		{
			builder.AddConfiguration();
			builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerFileLoggerProvider>((IServiceProvider x) => new ZLoggerFileLoggerProvider(fileName, x.GetRequiredService<IOptionsMonitor<ZLoggerOptions>>())));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerFileLoggerProvider>(builder.Services);
			return builder;
		}

		public static ILoggingBuilder AddZLoggerFile(this ILoggingBuilder builder, string fileName, Action<ZLoggerOptions> configure)
		{
			return builder.AddZLoggerFile(fileName, "ZLoggerFile.Default", configure);
		}

		public static ILoggingBuilder AddZLoggerFile(this ILoggingBuilder builder, string fileName, string optionName, Action<ZLoggerOptions> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException("configure");
			}
			builder.AddConfiguration();
			builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerFileLoggerProvider>((IServiceProvider x) => new ZLoggerFileLoggerProvider(fileName, optionName, x.GetRequiredService<IOptionsMonitor<ZLoggerOptions>>())));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerFileLoggerProvider>(builder.Services);
			builder.Services.AddOptions<ZLoggerOptions>(optionName).Configure(configure);
			return builder;
		}

		public static ILoggingBuilder AddZLoggerRollingFile(this ILoggingBuilder builder, Func<DateTimeOffset, int, string> fileNameSelector, Func<DateTimeOffset, DateTimeOffset> timestampPattern, int rollSizeKB)
		{
			builder.AddConfiguration();
			builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerRollingFileLoggerProvider>((IServiceProvider x) => new ZLoggerRollingFileLoggerProvider(fileNameSelector, timestampPattern, rollSizeKB, x.GetRequiredService<IOptionsMonitor<ZLoggerOptions>>())));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerRollingFileLoggerProvider>(builder.Services);
			return builder;
		}

		public static ILoggingBuilder AddZLoggerRollingFile(this ILoggingBuilder builder, Func<DateTimeOffset, int, string> fileNameSelector, Func<DateTimeOffset, DateTimeOffset> timestampPattern, int rollSizeKB, Action<ZLoggerOptions> configure)
		{
			return builder.AddZLoggerRollingFile(fileNameSelector, timestampPattern, rollSizeKB, "ZLoggerRollingFile.Default", configure);
		}

		public static ILoggingBuilder AddZLoggerRollingFile(this ILoggingBuilder builder, Func<DateTimeOffset, int, string> fileNameSelector, Func<DateTimeOffset, DateTimeOffset> timestampPattern, int rollSizeKB, string optionName, Action<ZLoggerOptions> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException("configure");
			}
			builder.AddConfiguration();
			builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerRollingFileLoggerProvider>((IServiceProvider x) => new ZLoggerRollingFileLoggerProvider(fileNameSelector, timestampPattern, rollSizeKB, optionName, x.GetRequiredService<IOptionsMonitor<ZLoggerOptions>>())));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerRollingFileLoggerProvider>(builder.Services);
			builder.Services.AddOptions<ZLoggerOptions>(optionName).Configure(configure);
			return builder;
		}
	}
}
