using System;
using System.Diagnostics;
using System.Reflection;
using Sentry.Internal.Extensions;

namespace Sentry.Internal
{
	internal class SettingLocator
	{
		private readonly SentryOptions _options;

		public Assembly? AssemblyForAttributes { get; protected set; } = Assembly.GetEntryAssembly();

		public SettingLocator(SentryOptions options)
		{
			_options = options;
		}

		public virtual string? GetEnvironmentVariable(string variable)
		{
			return Environment.GetEnvironmentVariable(variable);
		}

		public string GetDsn()
		{
			if (!string.IsNullOrEmpty(_options.Dsn))
			{
				return _options.Dsn;
			}
			string text = GetEnvironmentVariable("SENTRY_DSN") ?? AssemblyForAttributes?.GetCustomAttribute<DsnAttribute>()?.Dsn;
			if (_options.Dsn == null && text == null)
			{
				throw new ArgumentNullException("You must supply a DSN to use Sentry.To disable Sentry, pass an empty string: \"\".See https://docs.sentry.io/platforms/dotnet/configuration/options/#dsn");
			}
			if (text != null)
			{
				_options.Dsn = text;
			}
			return _options.Dsn;
		}

		public string GetEnvironment()
		{
			return GetEnvironment(useDefaultIfNotFound: true);
		}

		public string? GetEnvironment(bool useDefaultIfNotFound)
		{
			string environment = _options.Environment;
			if (!string.IsNullOrWhiteSpace(environment))
			{
				return environment;
			}
			environment = GetEnvironmentVariable("SENTRY_ENVIRONMENT").NullIfWhitespace();
			if (useDefaultIfNotFound)
			{
				if (environment == null)
				{
					environment = (Debugger.IsAttached ? "debug" : "production");
				}
			}
			else if (environment == null)
			{
				return null;
			}
			_options.Environment = environment;
			return environment;
		}

		public string? GetRelease()
		{
			string release = _options.Release;
			if (!string.IsNullOrWhiteSpace(release))
			{
				return release;
			}
			release = GetEnvironmentVariable("SENTRY_RELEASE").NullIfWhitespace() ?? ApplicationVersionLocator.GetCurrent(AssemblyForAttributes);
			_options.Release = release;
			return release;
		}
	}
}
