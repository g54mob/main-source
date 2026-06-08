using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Logging;
using TwitchLib.Api.Core.Common;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Core.Internal;

namespace TwitchLib.Api.Core.HttpCallHandlers
{
	public class TwitchHttpClient : IHttpCallHandler
	{
		private readonly ILogger<TwitchHttpClient> _logger;

		private readonly HttpClient _http;

		public TwitchHttpClient(ILogger<TwitchHttpClient> logger = null)
		{
			_logger = logger;
			_http = new HttpClient(new TwitchHttpClientHandler(_logger));
		}

		public void PutBytes(string url, byte[] payload)
		{
			HttpResponseMessage result = _http.PutAsync(new Uri(url), new ByteArrayContent(payload)).GetAwaiter().GetResult();
			if (!result.IsSuccessStatusCode)
			{
				HandleWebException(result);
			}
		}

		public KeyValuePair<int, string> GeneralRequest(string url, string method, string payload = null, ApiVersion api = ApiVersion.V5, string clientId = null, string accessToken = null)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage
			{
				RequestUri = new Uri(url),
				Method = new HttpMethod(method)
			};
			if (string.IsNullOrEmpty(clientId) && string.IsNullOrEmpty(accessToken))
			{
				throw new InvalidCredentialException("A Client-Id or OAuth token is required to use the Twitch API. If you previously set them in InitializeAsync, please be sure to await the method.");
			}
			if (!string.IsNullOrEmpty(clientId))
			{
				httpRequestMessage.Headers.Add("Client-ID", clientId);
			}
			string text = "OAuth";
			switch (api)
			{
			case ApiVersion.Helix:
				httpRequestMessage.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");
				text = "Bearer";
				break;
			default:
				httpRequestMessage.Headers.Add(HttpRequestHeader.Accept.ToString(), $"application/vnd.twitchtv.v{(int)api}+json");
				break;
			case ApiVersion.Void:
				break;
			}
			if (!string.IsNullOrEmpty(accessToken))
			{
				httpRequestMessage.Headers.Add(HttpRequestHeader.Authorization.ToString(), text + " " + Helpers.FormatOAuth(accessToken));
			}
			if (payload != null)
			{
				httpRequestMessage.Content = new StringContent(payload, Encoding.UTF8, "application/json");
			}
			HttpResponseMessage result = _http.SendAsync(httpRequestMessage).GetAwaiter().GetResult();
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
				return new KeyValuePair<int, string>((int)result.StatusCode, result2);
			}
			HandleWebException(result);
			return new KeyValuePair<int, string>(0, null);
		}

		public int RequestReturnResponseCode(string url, string method, List<KeyValuePair<string, string>> getParams = null)
		{
			if (getParams != null)
			{
				for (int i = 0; i < getParams.Count; i++)
				{
					url = ((i != 0) ? (url + "&" + getParams[i].Key + "=" + Uri.EscapeDataString(getParams[i].Value)) : (url + "?" + getParams[i].Key + "=" + Uri.EscapeDataString(getParams[i].Value)));
				}
			}
			HttpRequestMessage request = new HttpRequestMessage
			{
				RequestUri = new Uri(url),
				Method = new HttpMethod(method)
			};
			HttpResponseMessage result = _http.SendAsync(request).GetAwaiter().GetResult();
			return (int)result.StatusCode;
		}

		private void HandleWebException(HttpResponseMessage errorResp)
		{
			switch (errorResp.StatusCode)
			{
			case HttpStatusCode.BadRequest:
				throw new BadRequestException("Your request failed because either: \n 1. Your ClientID was invalid/not set. \n 2. Your refresh token was invalid. \n 3. You requested a username when the server was expecting a user ID.");
			case HttpStatusCode.Unauthorized:
			{
				HttpHeaderValueCollection<AuthenticationHeaderValue> wwwAuthenticate = errorResp.Headers.WwwAuthenticate;
				if (wwwAuthenticate == null || wwwAuthenticate.Count <= 0)
				{
					throw new BadScopeException("Your request was blocked due to bad credentials (Do you have the right scope for your access token?).");
				}
				throw new TokenExpiredException("Your request was blocked due to an expired Token. Please refresh your token and update your API instance settings.");
			}
			case HttpStatusCode.NotFound:
				throw new BadResourceException("The resource you tried to access was not valid.");
			case (HttpStatusCode)422:
				throw new NotPartneredException("The resource you requested is only available to channels that have been partnered by Twitch.");
			case (HttpStatusCode)429:
			{
				errorResp.Headers.TryGetValues("Ratelimit-Reset", out var values);
				throw new TooManyRequestsException("You have reached your rate limit. Too many requests were made", values.FirstOrDefault());
			}
			case HttpStatusCode.BadGateway:
				throw new BadGatewayException("The API answered with a 502 Bad Gateway. Please retry your request");
			case HttpStatusCode.GatewayTimeout:
				throw new GatewayTimeoutException("The API answered with a 504 Gateway Timeout. Please retry your request");
			case HttpStatusCode.InternalServerError:
				throw new InternalServerErrorException("The API answered with a 500 Internal Server Error. Please retry your request");
			case HttpStatusCode.Forbidden:
				throw new BadTokenException("The token provided in the request did not match the associated user. Make sure the token you're using is from the resource owner (streamer? viewer?)");
			default:
				throw new HttpRequestException("Something went wrong during the request! Please try again later");
			}
		}
	}
}
