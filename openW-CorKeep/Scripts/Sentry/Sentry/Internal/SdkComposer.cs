using System;
using Sentry.Extensibility;
using Sentry.Http;
using Sentry.Infrastructure;
using Sentry.Internal.Http;

namespace Sentry.Internal
{
	internal class SdkComposer
	{
		private readonly SentryOptions _options;

		public SdkComposer(SentryOptions options)
		{
			_options = options ?? throw new ArgumentNullException("options");
			if (options.Dsn == null)
			{
				throw new ArgumentException("No DSN defined in the SentryOptions");
			}
		}

		private ITransport CreateTransport()
		{
			_options.LogDebug("Creating transport.");
			ITransport transport = _options.Transport ?? CreateHttpTransport();
			if (!string.IsNullOrWhiteSpace(_options.CacheDirectoryPath))
			{
				_options.LogDebug("Cache directory path is specified.");
				if (_options.DisableFileWrite)
				{
					_options.LogInfo("File write has been disabled via the options. Skipping caching transport creation.");
				}
				else
				{
					_options.LogDebug("File writing is enabled, wrapping transport in caching transport.");
					transport = CachingTransport.Create(transport, _options);
				}
			}
			else
			{
				_options.LogDebug("No cache directory path specified. Skipping caching transport creation.");
			}
			if (_options.EnableSpotlight)
			{
				if (string.Equals(_options.SettingLocator.GetEnvironment(useDefaultIfNotFound: true), "production", StringComparison.OrdinalIgnoreCase))
				{
					_options.LogWarning("[Spotlight] It seems you're not in dev mode because environment is set to 'production'.\nDo you really want to have Spotlight enabled?\nYou can set a different environment via SENTRY_ENVIRONMENT env var or programatically during Init.\nDocs on Environment: https://docs.sentry.io/platforms/dotnet/configuration/environments/");
				}
				else
				{
					_options.LogInfo("Connecting to Spotlight at {0}", _options.SpotlightUrl);
				}
				if (!Uri.TryCreate(_options.SpotlightUrl, UriKind.Absolute, out var result))
				{
					throw new InvalidOperationException("Invalid option for SpotlightUrl: " + _options.SpotlightUrl);
				}
				transport = new SpotlightHttpTransport(transport, _options, _options.GetHttpClient(), result, SystemClock.Clock);
			}
			_options.Transport = transport;
			return transport;
		}

		private LazyHttpTransport CreateHttpTransport()
		{
			if (_options.SentryHttpClientFactory != null)
			{
				_options.LogDebug("Using ISentryHttpClientFactory set through options: {0}.", _options.SentryHttpClientFactory.GetType().Name);
			}
			return new LazyHttpTransport(_options);
		}

		public IBackgroundWorker CreateBackgroundWorker()
		{
			IBackgroundWorker backgroundWorker = _options.BackgroundWorker;
			if (backgroundWorker != null)
			{
				_options.LogDebug("Using IBackgroundWorker set through options: {0}.", backgroundWorker.GetType().Name);
				return backgroundWorker;
			}
			return new BackgroundWorker(CreateTransport(), _options);
		}
	}
}
