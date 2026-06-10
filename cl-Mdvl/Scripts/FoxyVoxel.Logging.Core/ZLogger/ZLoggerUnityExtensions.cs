using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;
using ZLogger.Providers;

namespace ZLogger
{
	public static class ZLoggerUnityExtensions
	{
		public static ILoggingBuilder AddZLoggerUnityDebug(this ILoggingBuilder builder)
		{
			builder.AddConfiguration();
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, ZLoggerUnityLoggerProvider>((IServiceProvider x) => new ZLoggerUnityLoggerProvider(x.GetService<IOptions<ZLoggerOptions>>())));
			LoggerProviderOptions.RegisterProviderOptions<ZLoggerOptions, ZLoggerUnityLoggerProvider>(builder.Services);
			return builder;
		}

		public static ILoggingBuilder AddZLoggerUnityDebug(this ILoggingBuilder builder, Action<ZLoggerOptions> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException("configure");
			}
			builder.AddZLoggerUnityDebug();
			builder.Services.Configure(configure);
			return builder;
		}
	}
}
