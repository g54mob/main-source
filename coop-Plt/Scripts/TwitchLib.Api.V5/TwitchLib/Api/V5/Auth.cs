using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Common;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.V5.Models.Auth;

namespace TwitchLib.Api.V5
{
	public class Auth : ApiBase
	{
		public Auth(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<RefreshResponse> RefreshAuthTokenAsync(string refreshToken, string clientSecret, string clientId = null)
		{
			string value = clientId ?? Settings.ClientId;
			if (string.IsNullOrWhiteSpace(refreshToken))
			{
				throw new BadParameterException("The refresh token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			if (string.IsNullOrWhiteSpace(clientSecret))
			{
				throw new BadParameterException("The client secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new BadParameterException("The clientId is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("grant_type", "refresh_token"),
				new KeyValuePair<string, string>("refresh_token", refreshToken),
				new KeyValuePair<string, string>("client_id", value),
				new KeyValuePair<string, string>("client_secret", clientSecret)
			};
			return TwitchPostGenericAsync<RefreshResponse>("/oauth2/token", ApiVersion.V5, null, getParams, null, null, "https://id.twitch.tv");
		}

		public string GetAuthorizationCodeUrl(string redirectUri, IEnumerable<AuthScopes> scopes, bool forceVerify = false, string state = null, string clientId = null)
		{
			string text = clientId ?? Settings.ClientId;
			string text2 = null;
			foreach (AuthScopes scope in scopes)
			{
				text2 = ((text2 != null) ? (text2 + "+" + Helpers.AuthScopesToString(scope)) : Helpers.AuthScopesToString(scope));
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				throw new BadParameterException("The clientId is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			return "https://id.twitch.tv/oauth2/authorize?client_id=" + text + "&redirect_uri=" + HttpUtility.UrlEncode(redirectUri) + "&response_type=code&scope=" + text2 + "&state=" + state + "&" + $"force_verify={forceVerify}";
		}

		public Task<AuthCodeResponse> GetAccessTokenFromCodeAsync(string code, string clientSecret, string redirectUri, string clientId = null)
		{
			string value = clientId ?? Settings.ClientId;
			if (string.IsNullOrWhiteSpace(code))
			{
				throw new BadParameterException("The code is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			if (string.IsNullOrWhiteSpace(clientSecret))
			{
				throw new BadParameterException("The client secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			if (string.IsNullOrWhiteSpace(redirectUri))
			{
				throw new BadParameterException("The redirectUri is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new BadParameterException("The clientId is not valid. It is not allowed to be null, empty or filled with whitespaces.");
			}
			List<KeyValuePair<string, string>> getParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("grant_type", "authorization_code"),
				new KeyValuePair<string, string>("code", code),
				new KeyValuePair<string, string>("client_id", value),
				new KeyValuePair<string, string>("client_secret", clientSecret),
				new KeyValuePair<string, string>("redirect_uri", HttpUtility.UrlEncode(redirectUri))
			};
			return TwitchPostGenericAsync<AuthCodeResponse>("/oauth2/token", ApiVersion.V5, null, getParams, null, null, "https://id.twitch.tv");
		}
	}
}
