using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;
using ZLogger.Providers;

namespace ZLogger
{
	public static class UnityLoggerFactory
	{
		private class LoggingConfiguration
		{
			public IConfiguration Configuration { get; }

			public LoggingConfiguration(IConfiguration configuration)
			{
				Configuration = configuration;
			}
		}

		private class LoggerProviderConfiguration<T> : ILoggerProviderConfiguration<T>
		{
			public IConfiguration Configuration { get; }

			public LoggerProviderConfiguration(ILoggerProviderConfigurationFactory providerConfigurationFactory)
			{
				Configuration = providerConfigurationFactory.GetConfiguration(typeof(T));
			}
		}

		private class LoggerProviderConfigurationFactory : ILoggerProviderConfigurationFactory
		{
			private readonly IEnumerable<LoggingConfiguration> _configurations;

			public LoggerProviderConfigurationFactory(IEnumerable<LoggingConfiguration> configurations)
			{
				_configurations = configurations;
			}

			public IConfiguration GetConfiguration(Type providerType)
			{
				if (providerType == null)
				{
					throw new ArgumentNullException("providerType");
				}
				string fullName = providerType.FullName;
				string alias = ProviderAliasUtilities.GetAlias(providerType);
				ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
				foreach (LoggingConfiguration configuration in _configurations)
				{
					IConfigurationSection section = configuration.Configuration.GetSection(fullName);
					configurationBuilder.AddConfiguration(section);
					if (!string.IsNullOrWhiteSpace(alias))
					{
						IConfigurationSection section2 = configuration.Configuration.GetSection(alias);
						configurationBuilder.AddConfiguration(section2);
					}
				}
				return configurationBuilder.Build();
			}
		}

		private class LoggerProviderConfigureOptions<TOptions, TProvider> : ConfigureFromConfigurationOptions<TOptions> where TOptions : class
		{
			public LoggerProviderConfigureOptions(ILoggerProviderConfiguration<TProvider> providerConfiguration)
				: base(providerConfiguration.Configuration)
			{
			}
		}

		private static class ProviderAliasUtilities
		{
			private const string AliasAttibuteTypeFullName = "Microsoft.Extensions.Logging.ProviderAliasAttribute";

			private const string AliasAttibuteAliasProperty = "Alias";

			internal static string GetAlias(Type providerType)
			{
				object[] customAttributes = providerType.GetTypeInfo().GetCustomAttributes(inherit: false);
				foreach (object obj in customAttributes)
				{
					if (obj.GetType().FullName == "Microsoft.Extensions.Logging.ProviderAliasAttribute")
					{
						PropertyInfo property = obj.GetType().GetProperty("Alias", BindingFlags.Instance | BindingFlags.Public);
						if (property != null)
						{
							return property.GetValue(obj) as string;
						}
					}
				}
				return null;
			}
		}

		private class DisposingLoggerFactory : ILoggerFactory, IDisposable
		{
			private readonly ILoggerFactory loggerFactory;

			private readonly IServiceProvider serviceProvider;

			public DisposingLoggerFactory(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
			{
				if (loggerFactory == null)
				{
					throw new ArgumentNullException("loggerFactory");
				}
				if (serviceProvider == null)
				{
					throw new ArgumentNullException("serviceProvider");
				}
				this.loggerFactory = loggerFactory;
				this.serviceProvider = serviceProvider;
			}

			public void Dispose()
			{
				(serviceProvider as IDisposable)?.Dispose();
			}

			public ILogger CreateLogger(string categoryName)
			{
				return loggerFactory.CreateLogger(categoryName);
			}

			public void AddProvider(ILoggerProvider provider)
			{
				loggerFactory.AddProvider(provider);
			}
		}

		public static ILoggerFactory Create(Action<ILoggingBuilder> configure)
		{
			ServiceCollection services = new ServiceCollection();
			services.AddLogging(delegate(ILoggingBuilder x)
			{
				AddBeforeConfiguration(x);
				configure(x);
				AddAfterConfiguration(x);
			});
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			return new DisposingLoggerFactory(serviceProvider.GetService<ILoggerFactory>(), serviceProvider);
		}

		private static void AddBeforeConfiguration(ILoggingBuilder builder)
		{
			builder.Services.TryAddSingleton<ILoggerProviderConfigurationFactory, LoggerProviderConfigurationFactory>();
			builder.Services.TryAddSingleton(typeof(ILoggerProviderConfiguration<>), typeof(LoggerProviderConfiguration<>));
		}

		private static void AddAfterConfiguration(ILoggingBuilder builder)
		{
			ServiceDescriptor[] array = builder.Services.Where((ServiceDescriptor serviceDescriptor) => serviceDescriptor.ServiceType == typeof(IConfigureOptions<ZLoggerOptions>) && serviceDescriptor?.ImplementationType?.FullName?.StartsWith("Microsoft.Extensions.Logging.Configuration.LoggerProviderConfigureOptions") == true).ToArray();
			foreach (ServiceDescriptor item in array)
			{
				builder.Services.Remove(item);
			}
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<ZLoggerOptions>, LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerUnityLoggerProvider>>());
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<ZLoggerOptions>, LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerConsoleLoggerProvider>>());
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<ZLoggerOptions>, LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerFileLoggerProvider>>());
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<ZLoggerOptions>, LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerRollingFileLoggerProvider>>());
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<ZLoggerOptions>, LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerStreamLoggerProvider>>());
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<ZLoggerOptions>, LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerLogProcessorLoggerProvider>>());
		}

		private static void TypeHint()
		{
			new LoggerFactory((IEnumerable<ILoggerProvider>)null, (LoggerFilterOptions)null);
			IEnumerable<IConfigureOptions<ZLoggerOptions>> setups = new IConfigureOptions<ZLoggerOptions>[1]
			{
				new ConfigureOptions<ZLoggerOptions>(null)
			}.AsEnumerable();
			IEnumerable<IPostConfigureOptions<ZLoggerOptions>> postConfigures = new IPostConfigureOptions<ZLoggerOptions>[1]
			{
				new PostConfigureOptions<ZLoggerOptions>(null, null)
			}.AsEnumerable();
			OptionsFactory<ZLoggerOptions> factory = new OptionsFactory<ZLoggerOptions>(setups, postConfigures);
			new OptionsManager<ZLoggerOptions>(factory);
			IEnumerable<ConfigurationChangeTokenSource<ZLoggerOptions>> sources = new ConfigurationChangeTokenSource<ZLoggerOptions>[1]
			{
				new ConfigurationChangeTokenSource<ZLoggerOptions>(null)
			}.AsEnumerable();
			OptionsCache<ZLoggerOptions> cache = new OptionsCache<ZLoggerOptions>();
			new OptionsMonitor<ZLoggerOptions>(factory, sources, cache);
			IEnumerable<IConfigureOptions<LoggerFilterOptions>> setups2 = new IConfigureOptions<LoggerFilterOptions>[1]
			{
				new ConfigureOptions<LoggerFilterOptions>(null)
			}.AsEnumerable();
			IEnumerable<IPostConfigureOptions<LoggerFilterOptions>> postConfigures2 = new IPostConfigureOptions<LoggerFilterOptions>[1]
			{
				new PostConfigureOptions<LoggerFilterOptions>(null, null)
			}.AsEnumerable();
			OptionsFactory<LoggerFilterOptions> factory2 = new OptionsFactory<LoggerFilterOptions>(setups2, postConfigures2);
			new OptionsManager<LoggerFilterOptions>(factory2);
			IEnumerable<ConfigurationChangeTokenSource<LoggerFilterOptions>> sources2 = new ConfigurationChangeTokenSource<LoggerFilterOptions>[1]
			{
				new ConfigurationChangeTokenSource<LoggerFilterOptions>(null)
			}.AsEnumerable();
			OptionsCache<LoggerFilterOptions> cache2 = new OptionsCache<LoggerFilterOptions>();
			new OptionsMonitor<LoggerFilterOptions>(factory2, sources2, cache2);
			Options.Create(new LoggerFilterOptions());
			Options.Create(new ZLoggerOptions());
			new ConfigureNamedOptions<LoggerFilterOptions>(null, null);
			new ConfigureNamedOptions<ZLoggerOptions>(null, null);
			LoggerProviderConfigurationFactory providerConfigurationFactory = new LoggerProviderConfigurationFactory(new LoggingConfiguration[1]
			{
				new LoggingConfiguration(null)
			}.AsEnumerable());
			LoggerProviderConfiguration<ZLoggerUnityLoggerProvider> providerConfiguration = new LoggerProviderConfiguration<ZLoggerUnityLoggerProvider>(providerConfigurationFactory);
			new LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerUnityLoggerProvider>(providerConfiguration);
			new LoggerProviderOptionsChangeTokenSource<ZLoggerOptions, ZLoggerUnityLoggerProvider>(providerConfiguration);
			LoggerProviderConfiguration<ZLoggerConsoleLoggerProvider> providerConfiguration2 = new LoggerProviderConfiguration<ZLoggerConsoleLoggerProvider>(providerConfigurationFactory);
			new LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerConsoleLoggerProvider>(providerConfiguration2);
			new LoggerProviderOptionsChangeTokenSource<ZLoggerOptions, ZLoggerConsoleLoggerProvider>(providerConfiguration2);
			LoggerProviderConfiguration<ZLoggerFileLoggerProvider> providerConfiguration3 = new LoggerProviderConfiguration<ZLoggerFileLoggerProvider>(providerConfigurationFactory);
			new LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerFileLoggerProvider>(providerConfiguration3);
			new LoggerProviderOptionsChangeTokenSource<ZLoggerOptions, ZLoggerFileLoggerProvider>(providerConfiguration3);
			LoggerProviderConfiguration<ZLoggerRollingFileLoggerProvider> providerConfiguration4 = new LoggerProviderConfiguration<ZLoggerRollingFileLoggerProvider>(providerConfigurationFactory);
			new LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerRollingFileLoggerProvider>(providerConfiguration4);
			new LoggerProviderOptionsChangeTokenSource<ZLoggerOptions, ZLoggerRollingFileLoggerProvider>(providerConfiguration4);
			LoggerProviderConfiguration<ZLoggerStreamLoggerProvider> providerConfiguration5 = new LoggerProviderConfiguration<ZLoggerStreamLoggerProvider>(providerConfigurationFactory);
			new LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerStreamLoggerProvider>(providerConfiguration5);
			new LoggerProviderOptionsChangeTokenSource<ZLoggerOptions, ZLoggerStreamLoggerProvider>(providerConfiguration5);
			LoggerProviderConfiguration<ZLoggerLogProcessorLoggerProvider> providerConfiguration6 = new LoggerProviderConfiguration<ZLoggerLogProcessorLoggerProvider>(providerConfigurationFactory);
			new LoggerProviderConfigureOptions<ZLoggerOptions, ZLoggerLogProcessorLoggerProvider>(providerConfiguration6);
			new LoggerProviderOptionsChangeTokenSource<ZLoggerOptions, ZLoggerLogProcessorLoggerProvider>(providerConfiguration6);
		}
	}
}
