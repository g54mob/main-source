using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Extensions.Logging;
using TwitchLib.Api.Core.Common;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;

namespace TwitchLib.Api.Core.HttpCallHandlers
{
	public class TwitchWebRequest : IHttpCallHandler
	{
		private readonly ILogger<TwitchWebRequest> _logger;

		public TwitchWebRequest(ILogger<TwitchWebRequest> logger = null)
		{
			_logger = logger;
		}

		public void PutBytes(string url, byte[] payload)
		{
			try
			{
				using WebClient webClient = new WebClient();
				webClient.UploadData(new Uri(url), "PUT", payload);
			}
			catch (WebException e)
			{
				HandleWebException(e);
			}
		}

		public KeyValuePair<int, string> GeneralRequest(string url, string method, string payload = null, ApiVersion api = ApiVersion.V5, string clientId = null, string accessToken = null)
		{
			HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
			if (string.IsNullOrEmpty(clientId) && string.IsNullOrEmpty(accessToken))
			{
				throw new InvalidCredentialException("A Client-Id or OAuth token is required to use the Twitch API. If you previously set them in InitializeAsync, please be sure to await the method.");
			}
			if (!string.IsNullOrEmpty(clientId))
			{
				httpWebRequest.Headers["Client-ID"] = clientId;
			}
			httpWebRequest.Method = method;
			httpWebRequest.ContentType = "application/json";
			string text = "OAuth";
			switch (api)
			{
			case ApiVersion.Helix:
				httpWebRequest.Accept = "application/json";
				text = "Bearer";
				break;
			default:
				httpWebRequest.Accept = $"application/vnd.twitchtv.v{(int)api}+json";
				break;
			case ApiVersion.Void:
				break;
			}
			if (!string.IsNullOrEmpty(accessToken))
			{
				httpWebRequest.Headers["Authorization"] = text + " " + Helpers.FormatOAuth(accessToken);
			}
			if (payload != null)
			{
				using StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStreamAsync().GetAwaiter().GetResult());
				streamWriter.Write(payload);
			}
			try
			{
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream() ?? throw new InvalidOperationException());
				string value = streamReader.ReadToEnd();
				return new KeyValuePair<int, string>((int)httpWebResponse.StatusCode, value);
			}
			catch (WebException e)
			{
				HandleWebException(e);
			}
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
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = method;
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			return (int)httpWebResponse.StatusCode;
		}

		private void HandleWebException(WebException e)
		{
			if (!(e.Response is HttpWebResponse { StatusCode: var statusCode } httpWebResponse))
			{
				throw e;
			}
			switch (statusCode)
			{
			case HttpStatusCode.BadRequest:
				throw new BadRequestException("Your request failed because either: \n 1. Your ClientID was invalid/not set. \n 2. Your refresh token was invalid. \n 3. You requested a username when the server was expecting a user ID.");
			case HttpStatusCode.Unauthorized:
			{
				string[] values = httpWebResponse.Headers.GetValues("WWW-Authenticate");
				if ((values != null && values.Length == 0) || string.IsNullOrEmpty((values != null) ? values[0] : null))
				{
					throw new BadScopeException("Your request was blocked due to bad credentials (do you have the right scope for your access token?).");
				}
				if (values[0].Contains("error='invalid_token'"))
				{
					throw new TokenExpiredException("Your request was blocked du to an expired Token. Please refresh your token and update your API instance settings.");
				}
				break;
			}
			case HttpStatusCode.NotFound:
				throw new BadResourceException("The resource you tried to access was not valid.");
			case (HttpStatusCode)429:
			{
				string resetTime = httpWebResponse.Headers.Get("Ratelimit-Reset");
				throw new TooManyRequestsException("You have reached your rate limit. Too many requests were made", resetTime);
			}
			case (HttpStatusCode)422:
				throw new NotPartneredException("The resource you requested is only available to channels that have been partnered by Twitch.");
			default:
				throw e;
			}
		}
	}
}
