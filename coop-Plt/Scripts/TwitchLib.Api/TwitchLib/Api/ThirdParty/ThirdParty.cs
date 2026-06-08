using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Common;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Events;
using TwitchLib.Api.ThirdParty.AuthorizationFlow;
using TwitchLib.Api.ThirdParty.ModLookup;
using TwitchLib.Api.ThirdParty.UsernameChange;

namespace TwitchLib.Api.ThirdParty
{
	public class ThirdParty
	{
		public class UsernameChangeApi : ApiBase
		{
			public UsernameChangeApi(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
				: base(settings, rateLimiter, http)
			{
			}

			public Task<List<UsernameChangeListing>> GetUsernameChangesAsync(string username)
			{
				List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
				{
					new KeyValuePair<string, string>("q", username),
					new KeyValuePair<string, string>("format", "json")
				};
				return GetGenericAsync<List<UsernameChangeListing>>("https://twitch-tools.rootonline.de/username_changelogs_search.php", getParams, null, ApiVersion.Void);
			}
		}

		public class ModLookupApi : ApiBase
		{
			public ModLookupApi(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
				: base(settings, rateLimiter, http)
			{
			}

			public Task<ModLookupResponse> GetChannelsModdedForByNameAsync(string username, int offset = 0, int limit = 100, bool useTls12 = true)
			{
				if (useTls12)
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				}
				List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
				{
					new KeyValuePair<string, string>("offset", offset.ToString()),
					new KeyValuePair<string, string>("limit", limit.ToString())
				};
				return GetGenericAsync<ModLookupResponse>("https://twitchstuff.3v.fi/modlookup/api/user/" + username, getParams, null, ApiVersion.Void);
			}

			public Task<TopResponse> GetChannelsModdedForByTopAsync(bool useTls12 = true)
			{
				if (useTls12)
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				}
				return GetGenericAsync<TopResponse>("https://twitchstuff.3v.fi/modlookup/api/top");
			}

			public Task<StatsResponse> GetChannelsModdedForStatsAsync(bool useTls12 = true)
			{
				if (useTls12)
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				}
				return GetGenericAsync<StatsResponse>("https://twitchstuff.3v.fi/modlookup/api/stats");
			}
		}

		public class AuthorizationFlowApi : ApiBase
		{
			private const string BaseUrl = "https://twitchtokengenerator.com/api";

			private string _apiId;

			private Timer _pingTimer;

			public event EventHandler<OnUserAuthorizationDetectedArgs> OnUserAuthorizationDetected;

			public event EventHandler<OnAuthorizationFlowErrorArgs> OnError;

			public AuthorizationFlowApi(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
				: base(settings, rateLimiter, http)
			{
			}

			public CreatedFlow CreateFlow(string applicationTitle, IEnumerable<AuthScopes> scopes)
			{
				string text = null;
				foreach (AuthScopes scope in scopes)
				{
					text = ((text != null) ? (text + "+" + TwitchLib.Api.Core.Common.Helpers.AuthScopesToString(scope)) : TwitchLib.Api.Core.Common.Helpers.AuthScopesToString(scope));
				}
				string address = "https://twitchtokengenerator.com/api/create/" + TwitchLib.Api.Core.Common.Helpers.Base64Encode(applicationTitle) + "/" + text;
				string value = new WebClient().DownloadString(address);
				return JsonConvert.DeserializeObject<CreatedFlow>(value);
			}

			public RefreshTokenResponse RefreshToken(string refreshToken)
			{
				string address = "https://twitchtokengenerator.com/api/refresh/" + refreshToken;
				string value = new WebClient().DownloadString(address);
				return JsonConvert.DeserializeObject<RefreshTokenResponse>(value);
			}

			public void BeginPingingStatus(string id, int intervalMs = 5000)
			{
				_apiId = id;
				_pingTimer = new Timer(intervalMs);
				_pingTimer.Elapsed += OnPingTimerElapsed;
				_pingTimer.Start();
			}

			public PingResponse PingStatus(string id = null)
			{
				if (id != null)
				{
					_apiId = id;
				}
				string jsonStr = new WebClient().DownloadString("https://twitchtokengenerator.com/api/status/" + _apiId);
				return new PingResponse(jsonStr);
			}

			private void OnPingTimerElapsed(object sender, ElapsedEventArgs e)
			{
				PingResponse pingResponse = PingStatus();
				if (pingResponse.Success)
				{
					_pingTimer.Stop();
					this.OnUserAuthorizationDetected?.Invoke(null, new OnUserAuthorizationDetectedArgs
					{
						Id = pingResponse.Id,
						Scopes = pingResponse.Scopes,
						Token = pingResponse.Token,
						Username = pingResponse.Username,
						Refresh = pingResponse.Refresh,
						ClientId = pingResponse.ClientId
					});
				}
				else if (pingResponse.Error != 3)
				{
					_pingTimer.Stop();
					this.OnError?.Invoke(null, new OnAuthorizationFlowErrorArgs
					{
						Error = pingResponse.Error,
						Message = pingResponse.Message
					});
				}
			}
		}

		public UsernameChangeApi UsernameChange { get; }

		public ModLookupApi ModLookup { get; }

		public AuthorizationFlowApi AuthorizationFlow { get; }

		public ThirdParty(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
		{
			UsernameChange = new UsernameChangeApi(settings, rateLimiter, http);
			ModLookup = new ModLookupApi(settings, rateLimiter, http);
			AuthorizationFlow = new AuthorizationFlowApi(settings, rateLimiter, http);
		}
	}
}
