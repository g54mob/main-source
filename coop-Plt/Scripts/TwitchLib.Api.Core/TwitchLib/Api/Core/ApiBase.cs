using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Core.Models;
using TwitchLib.Api.Core.Models.Root;

namespace TwitchLib.Api.Core
{
	public class ApiBase
	{
		private class TwitchLibJsonSerializer
		{
			private class LowercaseContractResolver : DefaultContractResolver
			{
				protected override string ResolvePropertyName(string propertyName)
				{
					return propertyName.ToLower();
				}
			}

			private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
			{
				ContractResolver = new LowercaseContractResolver(),
				NullValueHandling = NullValueHandling.Ignore
			};

			public string SerializeObject(object o)
			{
				return JsonConvert.SerializeObject(o, Formatting.Indented, _settings);
			}
		}

		private readonly TwitchLibJsonSerializer _jsonSerializer;

		protected readonly IApiSettings Settings;

		private readonly IRateLimiter _rateLimiter;

		private readonly IHttpCallHandler _http;

		internal const string BaseV5 = "https://api.twitch.tv/kraken";

		internal const string BaseHelix = "https://api.twitch.tv/helix";

		internal const string BaseOauthToken = "https://id.twitch.tv/oauth2/token";

		private DateTime? _serverBasedAccessTokenExpiry;

		private string _serverBasedAccessToken;

		private readonly JsonSerializerSettings _twitchLibJsonDeserializer = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			MissingMemberHandling = MissingMemberHandling.Ignore
		};

		public ApiBase(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
		{
			Settings = settings;
			_rateLimiter = rateLimiter;
			_http = http;
			_jsonSerializer = new TwitchLibJsonSerializer();
		}

		public Task<CredentialCheckResponseModel> CheckCredentialsAsync()
		{
			string text = "Check successful";
			string text2 = "";
			bool flag = true;
			if (!string.IsNullOrWhiteSpace(Settings.ClientId) && !ValidClientId(Settings.ClientId))
			{
				flag = false;
				text2 = "The passed Client Id was not valid. To get a valid Client Id, register an application here: https://www.twitch.tv/kraken/oauth2/clients/new";
			}
			if (!string.IsNullOrWhiteSpace(Settings.AccessToken) && ValidAccessToken(Settings.AccessToken) == null)
			{
				flag = false;
				text2 += "The passed Access Token was not valid. To get an access token, go here:  https://twitchtokengenerator.com/";
			}
			return Task.FromResult(new CredentialCheckResponseModel
			{
				Result = flag,
				ResultMessage = (flag ? text : text2)
			});
		}

		public void DynamicScopeValidation(AuthScopes requiredScope, string accessToken = null)
		{
			if (!Settings.SkipDynamicScopeValidation && !string.IsNullOrWhiteSpace(accessToken))
			{
				Settings.Scopes = ValidAccessToken(accessToken);
				if (Settings.Scopes == null)
				{
					throw new InvalidCredentialException("The current access token does not support this call. Missing required scope: " + requiredScope.ToString().ToLower() + ". You can skip this check by using: IApiSettings.SkipDynamicScopeValidation = true . You can also generate a new token with this scope here: https://twitchtokengenerator.com");
				}
				if ((!Settings.Scopes.Contains(requiredScope) && requiredScope != AuthScopes.Any) || (requiredScope == AuthScopes.Any && Settings.Scopes.Any((AuthScopes x) => x == AuthScopes.None)))
				{
					throw new InvalidCredentialException("The current access token (" + string.Join(",", Settings.Scopes) + ") does not support this call. Missing required scope: " + requiredScope.ToString().ToLower() + ". You can skip this check by using: IApiSettings.SkipDynamicScopeValidation = true . You can also generate a new token with this scope here: https://twitchtokengenerator.com");
				}
			}
		}

		internal virtual Task<Root> GetRootAsync(string authToken = null, string clientId = null)
		{
			return TwitchGetGenericAsync<Root>("", ApiVersion.V5, null, authToken, clientId);
		}

		public string GetAccessToken(string accessToken = null)
		{
			if (!string.IsNullOrEmpty(accessToken))
			{
				return accessToken;
			}
			if (!string.IsNullOrEmpty(Settings.AccessToken))
			{
				return Settings.AccessToken;
			}
			if (!string.IsNullOrEmpty(Settings.Secret) && !string.IsNullOrEmpty(Settings.ClientId) && !Settings.SkipAutoServerTokenGeneration)
			{
				if (!_serverBasedAccessTokenExpiry.HasValue || _serverBasedAccessTokenExpiry - TimeSpan.FromMinutes(1.0) < DateTime.Now)
				{
					return GenerateServerBasedAccessToken();
				}
				return _serverBasedAccessToken;
			}
			return null;
		}

		internal string GenerateServerBasedAccessToken()
		{
			KeyValuePair<int, string> keyValuePair = _http.GeneralRequest("https://id.twitch.tv/oauth2/token?client_id=" + Settings.ClientId + "&client_secret=" + Settings.Secret + "&grant_type=client_credentials", "POST", null, ApiVersion.Helix, Settings.ClientId);
			if (keyValuePair.Key == 200)
			{
				dynamic val = JsonConvert.DeserializeObject<object>(keyValuePair.Value);
				int num = (int)val.expires_in;
				_serverBasedAccessTokenExpiry = DateTime.Now + TimeSpan.FromSeconds(num);
				_serverBasedAccessToken = (string)val.access_token;
				return _serverBasedAccessToken;
			}
			return null;
		}

		internal void ForceAccessTokenAndClientIdForHelix(string clientId, string accessToken, ApiVersion api)
		{
			if (api != ApiVersion.Helix || (!string.IsNullOrWhiteSpace(clientId) && !string.IsNullOrWhiteSpace(accessToken)))
			{
				return;
			}
			throw new ClientIdAndOAuthTokenRequired("As of May 1, all calls to Twitch's Helix API require Client-ID and OAuth access token be set. Example: api.Settings.AccessToken = \"twitch-oauth-access-token-here\"; api.Settings.ClientId = \"twitch-client-id-here\";");
		}

		protected Task<T> TwitchGetGenericAsync<T>(string resource, ApiVersion api, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, getParams, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => JsonConvert.DeserializeObject<T>(_http.GeneralRequest(url, "GET", null, api, clientId, accessToken).Value, _twitchLibJsonDeserializer)).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected Task<T> TwitchPatchGenericAsync<T>(string resource, ApiVersion api, string payload, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, getParams, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => JsonConvert.DeserializeObject<T>(_http.GeneralRequest(url, "PATCH", payload, api, clientId, accessToken).Value, _twitchLibJsonDeserializer)).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected Task<string> TwitchPatchAsync(string resource, ApiVersion api, string payload, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, getParams, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => _http.GeneralRequest(url, "PATCH", payload, api, clientId, accessToken).Value).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected Task<string> TwitchDeleteAsync(string resource, ApiVersion api, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, getParams, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => _http.GeneralRequest(url, "DELETE", null, api, clientId, accessToken).Value).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected Task<T> TwitchPostGenericAsync<T>(string resource, ApiVersion api, string payload, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, getParams, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => JsonConvert.DeserializeObject<T>(_http.GeneralRequest(url, "POST", payload, api, clientId, accessToken).Value, _twitchLibJsonDeserializer)).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected Task<T> TwitchPostGenericModelAsync<T>(string resource, ApiVersion api, RequestModel model, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, null, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => JsonConvert.DeserializeObject<T>(_http.GeneralRequest(url, "POST", (model != null) ? _jsonSerializer.SerializeObject(model) : "", api, clientId, accessToken).Value, _twitchLibJsonDeserializer)).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected Task<T> TwitchDeleteGenericAsync<T>(string resource, ApiVersion api, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, getParams, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => JsonConvert.DeserializeObject<T>(_http.GeneralRequest(url, "DELETE", null, api, clientId, accessToken).Value, _twitchLibJsonDeserializer)).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected Task<T> TwitchPutGenericAsync<T>(string resource, ApiVersion api, string payload = null, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, getParams, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => JsonConvert.DeserializeObject<T>(_http.GeneralRequest(url, "PUT", payload, api, clientId, accessToken).Value, _twitchLibJsonDeserializer)).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected Task<string> TwitchPutAsync(string resource, ApiVersion api, string payload, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, getParams, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => _http.GeneralRequest(url, "PUT", payload, api, clientId, accessToken).Value).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected Task<KeyValuePair<int, string>> TwitchPostAsync(string resource, ApiVersion api, string payload, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, string clientId = null, string customBase = null)
		{
			string url = ConstructResourceUrl(resource, getParams, api, customBase);
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => _http.GeneralRequest(url, "POST", payload, api, clientId, accessToken)).ConfigureAwait(continueOnCapturedContext: false));
		}

		protected void PutBytes(string url, byte[] payload)
		{
			_http.PutBytes(url, payload);
		}

		internal int RequestReturnResponseCode(string url, string method, List<KeyValuePair<string, string>> getParams = null)
		{
			return _http.RequestReturnResponseCode(url, method, getParams);
		}

		protected Task<T> GetGenericAsync<T>(string url, List<KeyValuePair<string, string>> getParams = null, string accessToken = null, ApiVersion api = ApiVersion.V5, string clientId = null)
		{
			if (getParams != null)
			{
				for (int i = 0; i < getParams.Count; i++)
				{
					if (i == 0)
					{
						url = url + "?" + getParams[i].Key + "=" + Uri.EscapeDataString(getParams[i].Value);
					}
					else
					{
						url = url + "&" + getParams[i].Key + "=" + Uri.EscapeDataString(getParams[i].Value);
					}
				}
			}
			if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
			{
				clientId = Settings.ClientId;
			}
			accessToken = GetAccessToken(accessToken);
			ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);
			return _rateLimiter.Perform(async () => await Task.Run(() => JsonConvert.DeserializeObject<T>(_http.GeneralRequest(url, "GET", null, api, clientId, accessToken).Value, _twitchLibJsonDeserializer)).ConfigureAwait(continueOnCapturedContext: false));
		}

		internal Task<T> GetSimpleGenericAsync<T>(string url, List<KeyValuePair<string, string>> getParams = null)
		{
			if (getParams != null)
			{
				for (int i = 0; i < getParams.Count; i++)
				{
					if (i == 0)
					{
						url = url + "?" + getParams[i].Key + "=" + Uri.EscapeDataString(getParams[i].Value);
					}
					else
					{
						url = url + "&" + getParams[i].Key + "=" + Uri.EscapeDataString(getParams[i].Value);
					}
				}
			}
			return _rateLimiter.Perform(async () => JsonConvert.DeserializeObject<T>(await SimpleRequestAsync(url), _twitchLibJsonDeserializer));
		}

		private Task<string> SimpleRequestAsync(string url)
		{
			TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
			WebClient client = new WebClient();
			client.DownloadStringCompleted += DownloadStringCompletedEventHandler;
			client.DownloadString(new Uri(url));
			return tcs.Task;
			void DownloadStringCompletedEventHandler(object sender, DownloadStringCompletedEventArgs args)
			{
				if (args.Cancelled)
				{
					tcs.SetCanceled();
				}
				else if (args.Error != null)
				{
					tcs.SetException(args.Error);
				}
				else
				{
					tcs.SetResult(args.Result);
				}
				client.DownloadStringCompleted -= DownloadStringCompletedEventHandler;
			}
		}

		private bool ValidClientId(string clientId)
		{
			try
			{
				Root result = GetRootAsync(null, clientId).GetAwaiter().GetResult();
				return result.Token != null;
			}
			catch (BadRequestException)
			{
				return false;
			}
		}

		private List<AuthScopes> ValidAccessToken(string accessToken)
		{
			try
			{
				Root result = GetRootAsync(accessToken).GetAwaiter().GetResult();
				if (result.Token == null)
				{
					return null;
				}
				return BuildScopesList(result.Token);
			}
			catch
			{
				return null;
			}
		}

		private static List<AuthScopes> BuildScopesList(RootToken token)
		{
			List<AuthScopes> list = new List<AuthScopes>();
			string[] scopes = token.Auth.Scopes;
			for (int i = 0; i < scopes.Length; i++)
			{
				switch (scopes[i])
				{
				case "channel_check_subscription":
					list.Add(AuthScopes.Channel_Check_Subscription);
					break;
				case "channel_commercial":
					list.Add(AuthScopes.Channel_Commercial);
					break;
				case "channel_editor":
					list.Add(AuthScopes.Channel_Editor);
					break;
				case "channel_feed_edit":
					list.Add(AuthScopes.Channel_Feed_Edit);
					break;
				case "channel_feed_read":
					list.Add(AuthScopes.Channel_Feed_Read);
					break;
				case "channel_read":
					list.Add(AuthScopes.Channel_Read);
					break;
				case "channel_stream":
					list.Add(AuthScopes.Channel_Stream);
					break;
				case "channel_subscriptions":
					list.Add(AuthScopes.Channel_Subscriptions);
					break;
				case "chat_login":
					list.Add(AuthScopes.Chat_Login);
					break;
				case "collections_edit":
					list.Add(AuthScopes.Collections_Edit);
					break;
				case "communities_edit":
					list.Add(AuthScopes.Communities_Edit);
					break;
				case "communities_moderate":
					list.Add(AuthScopes.Communities_Moderate);
					break;
				case "user_blocks_edit":
					list.Add(AuthScopes.User_Blocks_Edit);
					break;
				case "user_blocks_read":
					list.Add(AuthScopes.User_Blocks_Read);
					break;
				case "user_follows_edit":
					list.Add(AuthScopes.User_Follows_Edit);
					break;
				case "user_read":
					list.Add(AuthScopes.User_Read);
					break;
				case "user_subscriptions":
					list.Add(AuthScopes.User_Subscriptions);
					break;
				case "openid":
					list.Add(AuthScopes.OpenId);
					break;
				case "viewing_activity_read":
					list.Add(AuthScopes.Viewing_Activity_Read);
					break;
				case "user:edit:broadcast":
					list.Add(AuthScopes.Helix_User_Edit_Broadcast);
					break;
				case "analytics:read:extensions":
					list.Add(AuthScopes.Helix_Analytics_Read_Extensions);
					break;
				case "analytics:read:games":
					list.Add(AuthScopes.Helix_Analytics_Read_Games);
					break;
				case "bits:read":
					list.Add(AuthScopes.Helix_Bits_Read);
					break;
				case "channel:edit:commercial":
					list.Add(AuthScopes.Helix_Channel_Edit_Commercial);
					break;
				case "channel:manage:broadcast":
					list.Add(AuthScopes.Helix_Channel_Manage_Broadcast);
					break;
				case "channel:manage:extensions":
					list.Add(AuthScopes.Helix_Channel_Manage_Extensions);
					break;
				case "channel:manage:redemptions":
					list.Add(AuthScopes.Helix_Channel_Manage_Redemptions);
					break;
				case "channel:read:hype_train":
					list.Add(AuthScopes.Helix_Channel_Read_Hype_Train);
					break;
				case "channel:read:redemptions":
					list.Add(AuthScopes.Helix_Channel_Read_Redemptions);
					break;
				case "channel:read:stream_key":
					list.Add(AuthScopes.Helix_Channel_Read_Stream_Key);
					break;
				case "channel:read:subscriptions":
					list.Add(AuthScopes.Helix_Channel_Read_Subscriptions);
					break;
				case "clips:edit":
					list.Add(AuthScopes.Helix_Clips_Edit);
					break;
				case "moderation:read":
					list.Add(AuthScopes.Helix_Moderation_Read);
					break;
				case "user:edit":
					list.Add(AuthScopes.Helix_User_Edit);
					break;
				case "user:edit:follows":
					list.Add(AuthScopes.Helix_User_Edit_Follows);
					break;
				case "user:read:broadcast":
					list.Add(AuthScopes.Helix_User_Read_Broadcast);
					break;
				case "user:read:email":
					list.Add(AuthScopes.Helix_User_Read_Email);
					break;
				case "channel:read:editors":
					list.Add(AuthScopes.Helix_Channel_Read_Editors);
					break;
				case "channel:manage:videos":
					list.Add(AuthScopes.Helix_Channel_Manage_Videos);
					break;
				case "user:read:blocked_users":
					list.Add(AuthScopes.Helix_User_Read_BlockedUsers);
					break;
				case "user:manage:blocked_users":
					list.Add(AuthScopes.Helix_User_Manage_BlockedUsers);
					break;
				case "user:read:subscriptions":
					list.Add(AuthScopes.Helix_User_Read_Subscriptions);
					break;
				case "channel:manage:polls":
					list.Add(AuthScopes.Helix_Channel_Manage_Polls);
					break;
				case "channel:manage:predictions":
					list.Add(AuthScopes.Helix_Channel_Manage_Predictions);
					break;
				case "channel:read:polls":
					list.Add(AuthScopes.Helix_Channel_Read_Polls);
					break;
				case "channel:read:predictions":
					list.Add(AuthScopes.Helix_Channel_Read_Predictions);
					break;
				case "moderator:manage:automod":
					list.Add(AuthScopes.Helix_Channel_Moderator_Manage_Automod);
					break;
				}
			}
			if (list.Count == 0)
			{
				list.Add(AuthScopes.None);
			}
			return list;
		}

		private string ConstructResourceUrl(string resource = null, List<KeyValuePair<string, string>> getParams = null, ApiVersion api = ApiVersion.V5, string overrideUrl = null)
		{
			string text = "";
			if (overrideUrl == null)
			{
				if (resource == null)
				{
					throw new Exception("Cannot pass null resource with null override url");
				}
				switch (api)
				{
				case ApiVersion.V5:
					text = "https://api.twitch.tv/kraken" + resource;
					break;
				case ApiVersion.Helix:
					text = "https://api.twitch.tv/helix" + resource;
					break;
				}
			}
			else
			{
				text = ((resource == null) ? overrideUrl : (overrideUrl + resource));
			}
			if (getParams != null)
			{
				for (int i = 0; i < getParams.Count; i++)
				{
					text = ((i != 0) ? (text + "&" + getParams[i].Key + "=" + Uri.EscapeDataString(getParams[i].Value)) : (text + "?" + getParams[i].Key + "=" + Uri.EscapeDataString(getParams[i].Value)));
				}
			}
			return text;
		}
	}
}
