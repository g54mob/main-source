using System.ComponentModel;
using Microsoft.Extensions.Logging;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.HttpCallHandlers;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Core.RateLimiter;
using TwitchLib.Api.Core.Undocumented;
using TwitchLib.Api.Helix;
using TwitchLib.Api.Interfaces;
using TwitchLib.Api.ThirdParty;
using TwitchLib.Api.V5;

namespace TwitchLib.Api
{
	public class TwitchAPI : ITwitchAPI
	{
		private readonly ILogger<TwitchAPI> _logger;

		public IApiSettings Settings { get; }

		public TwitchLib.Api.V5.V5 V5 { get; }

		public TwitchLib.Api.Helix.Helix Helix { get; }

		public TwitchLib.Api.ThirdParty.ThirdParty ThirdParty { get; }

		public Undocumented Undocumented { get; }

		public TwitchAPI(ILoggerFactory loggerFactory = null, IRateLimiter rateLimiter = null, IApiSettings settings = null, IHttpCallHandler http = null)
		{
			_logger = loggerFactory?.CreateLogger<TwitchAPI>();
			rateLimiter = rateLimiter ?? BypassLimiter.CreateLimiterBypassInstance();
			http = http ?? new TwitchHttpClient(loggerFactory?.CreateLogger<TwitchHttpClient>());
			Settings = settings ?? new ApiSettings();
			Helix = new TwitchLib.Api.Helix.Helix(loggerFactory, rateLimiter, Settings, http);
			V5 = new TwitchLib.Api.V5.V5(loggerFactory, rateLimiter, Settings, http);
			ThirdParty = new TwitchLib.Api.ThirdParty.ThirdParty(Settings, rateLimiter, http);
			Undocumented = new Undocumented(Settings, rateLimiter, http);
			Settings.PropertyChanged += SettingsPropertyChanged;
		}

		private void SettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
			case "AccessToken":
				V5.Settings.AccessToken = Settings.AccessToken;
				Helix.Settings.AccessToken = Settings.AccessToken;
				break;
			case "Secret":
				V5.Settings.Secret = Settings.Secret;
				Helix.Settings.Secret = Settings.Secret;
				break;
			case "ClientId":
				V5.Settings.ClientId = Settings.ClientId;
				Helix.Settings.ClientId = Settings.ClientId;
				break;
			case "SkipDynamicScopeValidation":
				V5.Settings.SkipDynamicScopeValidation = Settings.SkipDynamicScopeValidation;
				Helix.Settings.SkipDynamicScopeValidation = Settings.SkipDynamicScopeValidation;
				break;
			case "SkipAutoServerTokenGeneration":
				V5.Settings.SkipAutoServerTokenGeneration = Settings.SkipAutoServerTokenGeneration;
				Helix.Settings.SkipAutoServerTokenGeneration = Settings.SkipAutoServerTokenGeneration;
				break;
			case "Scopes":
				V5.Settings.Scopes = Settings.Scopes;
				Helix.Settings.Scopes = Settings.Scopes;
				break;
			}
		}
	}
}
