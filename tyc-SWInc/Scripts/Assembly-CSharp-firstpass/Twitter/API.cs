using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Twitter
{
	public class API
	{
		private static readonly string RequestTokenURL = "https://api.twitter.com/oauth/request_token";

		private static readonly string AuthorizationURL = "https://api.twitter.com/oauth/authenticate?oauth_token={0}";

		private static readonly string AccessTokenURL = "https://api.twitter.com/oauth/access_token";

		private const string PostTweetURL = "https://api.twitter.com/1.1/statuses/update.json";

		private const string PostMediaURL = "https://upload.twitter.com/1.1/media/upload.json";

		private static readonly string[] OAuthParametersToIncludeInHeader = new string[7] { "oauth_version", "oauth_nonce", "oauth_timestamp", "oauth_signature_method", "oauth_consumer_key", "oauth_token", "oauth_verifier" };

		private static readonly string[] SecretParameters = new string[3] { "oauth_consumer_secret", "oauth_token_secret", "oauth_signature" };

		public static IEnumerator GetRequestToken(string consumerKey, string consumerSecret, RequestTokenCallback callback)
		{
			WWW web = WWWRequestToken(consumerKey, consumerSecret);
			yield return web;
			if (!string.IsNullOrEmpty(web.error))
			{
				Debug.Log(string.Format("GetRequestToken - failed. error : {0}", web.error));
				callback(false, null);
				yield break;
			}
			RequestTokenResponse requestTokenResponse = new RequestTokenResponse
			{
				Token = Regex.Match(web.text, "oauth_token=([^&]+)").Groups[1].Value,
				TokenSecret = Regex.Match(web.text, "oauth_token_secret=([^&]+)").Groups[1].Value
			};
			if (!string.IsNullOrEmpty(requestTokenResponse.Token) && !string.IsNullOrEmpty(requestTokenResponse.TokenSecret))
			{
				callback(true, requestTokenResponse);
				yield break;
			}
			Debug.Log(string.Format("GetRequestToken - failed. response : {0}", web.text));
			callback(false, null);
		}

		public static void OpenAuthorizationPage(string requestToken)
		{
			Application.OpenURL(string.Format(AuthorizationURL, requestToken));
		}

		public static IEnumerator GetAccessToken(string consumerKey, string consumerSecret, string requestToken, string pin, AccessTokenCallback callback)
		{
			WWW web = WWWAccessToken(consumerKey, consumerSecret, requestToken, pin);
			yield return web;
			if (!string.IsNullOrEmpty(web.error))
			{
				Debug.Log(string.Format("GetAccessToken - failed. error : {0}", web.error));
				callback(false, null);
				yield break;
			}
			AccessTokenResponse accessTokenResponse = new AccessTokenResponse
			{
				Token = Regex.Match(web.text, "oauth_token=([^&]+)").Groups[1].Value,
				TokenSecret = Regex.Match(web.text, "oauth_token_secret=([^&]+)").Groups[1].Value,
				UserId = Regex.Match(web.text, "user_id=([^&]+)").Groups[1].Value,
				ScreenName = Regex.Match(web.text, "screen_name=([^&]+)").Groups[1].Value
			};
			if (!string.IsNullOrEmpty(accessTokenResponse.Token) && !string.IsNullOrEmpty(accessTokenResponse.TokenSecret) && !string.IsNullOrEmpty(accessTokenResponse.UserId) && !string.IsNullOrEmpty(accessTokenResponse.ScreenName))
			{
				callback(true, accessTokenResponse);
				yield break;
			}
			Debug.Log(string.Format("GetAccessToken - failed. response : {0}", web.text));
			callback(false, null);
		}

		private static WWW WWWRequestToken(string consumerKey, string consumerSecret)
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("oauth_callback", "oob");
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			AddDefaultOAuthParams(dictionary, consumerKey, consumerSecret);
			dictionary.Add("oauth_callback", "oob");
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			dictionary2["Authorization"] = GetFinalOAuthHeader("POST", RequestTokenURL, dictionary);
			return new WWW(RequestTokenURL, wWWForm.data, dictionary2);
		}

		private static WWW WWWAccessToken(string consumerKey, string consumerSecret, string requestToken, string pin)
		{
			byte[] postData = new byte[1] { 0 };
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			AddDefaultOAuthParams(dictionary2, consumerKey, consumerSecret);
			dictionary2.Add("oauth_token", requestToken);
			dictionary2.Add("oauth_verifier", pin);
			dictionary["Authorization"] = GetFinalOAuthHeader("POST", AccessTokenURL, dictionary2);
			return new WWW(AccessTokenURL, postData, dictionary);
		}

		private static string GetHeaderWithAccessToken(string httpRequestType, string apiURL, string consumerKey, string consumerSecret, AccessTokenResponse response, Dictionary<string, string> parameters)
		{
			AddDefaultOAuthParams(parameters, consumerKey, consumerSecret);
			parameters.Add("oauth_token", response.Token);
			parameters.Add("oauth_token_secret", response.TokenSecret);
			return GetFinalOAuthHeader(httpRequestType, apiURL, parameters);
		}

		public static IEnumerator PostMedia(Texture2D pic, string consumerKey, string consumerSecret, AccessTokenResponse response, PostMediaCallback callback)
		{
			string value = Convert.ToBase64String(pic.EncodeToPNG());
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("media_data", value);
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("media_data", value);
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			dictionary2["Authorization"] = GetHeaderWithAccessToken("POST", "https://upload.twitter.com/1.1/media/upload.json", consumerKey, consumerSecret, response, dictionary);
			WWW web = new WWW("https://upload.twitter.com/1.1/media/upload.json", wWWForm.data, dictionary2);
			yield return web;
			if (!string.IsNullOrEmpty(web.error))
			{
				Debug.Log(string.Format("PostMedia - failed. {0}\n{1}", web.error, web.text));
				callback(false, null);
				yield break;
			}
			string value2 = Regex.Match(web.text, "<error>([^&]+)</error>").Groups[1].Value;
			if (!string.IsNullOrEmpty(value2))
			{
				Debug.Log(string.Format("PostMedia - failed. {0}", value2));
				callback(false, null);
			}
			else
			{
				string value3 = Regex.Match(web.text, "\\\"media_id\\\"\\: ?(\\d+),").Groups[1].Value;
				callback(true, value3);
			}
		}

		public static IEnumerator PostTweet(string text, string mediaId, string consumerKey, string consumerSecret, AccessTokenResponse response, PostTweetCallback callback)
		{
			if (string.IsNullOrEmpty(text) || text.Length > 140)
			{
				Debug.Log(string.Format("PostTweet - text[{0}] is empty or too long.", text));
				callback(false);
				yield break;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("status", text);
			if (mediaId != null)
			{
				dictionary.Add("media_ids", mediaId);
			}
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("status", text);
			if (mediaId != null)
			{
				wWWForm.AddField("media_ids", mediaId);
			}
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			dictionary2["Authorization"] = GetHeaderWithAccessToken("POST", "https://api.twitter.com/1.1/statuses/update.json", consumerKey, consumerSecret, response, dictionary);
			WWW web = new WWW("https://api.twitter.com/1.1/statuses/update.json", wWWForm.data, dictionary2);
			yield return web;
			if (!string.IsNullOrEmpty(web.error))
			{
				Debug.Log(string.Format("PostTweet - failed. {0}\n{1}", web.error, web.text));
				callback(false);
				yield break;
			}
			string value = Regex.Match(web.text, "<error>([^&]+)</error>").Groups[1].Value;
			if (!string.IsNullOrEmpty(value))
			{
				Debug.Log(string.Format("PostTweet - failed. {0}", value));
				callback(false);
			}
			else
			{
				callback(true);
			}
		}

		private static void AddDefaultOAuthParams(Dictionary<string, string> parameters, string consumerKey, string consumerSecret)
		{
			parameters.Add("oauth_version", "1.0");
			parameters.Add("oauth_nonce", GenerateNonce());
			parameters.Add("oauth_timestamp", GenerateTimeStamp());
			parameters.Add("oauth_signature_method", "HMAC-SHA1");
			parameters.Add("oauth_consumer_key", consumerKey);
			parameters.Add("oauth_consumer_secret", consumerSecret);
		}

		private static string GetFinalOAuthHeader(string HTTPRequestType, string URL, Dictionary<string, string> parameters)
		{
			string value = GenerateSignature(HTTPRequestType, URL, parameters);
			parameters.Add("oauth_signature", value);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("OAuth realm=\"{0}\"", "Twitter API");
			foreach (KeyValuePair<string, string> item in parameters.Where(delegate(KeyValuePair<string, string> p)
			{
				string[] oAuthParametersToIncludeInHeader = OAuthParametersToIncludeInHeader;
				KeyValuePair<string, string> keyValuePair = p;
				return oAuthParametersToIncludeInHeader.Contains(keyValuePair.Key);
			}).OrderBy(delegate(KeyValuePair<string, string> p)
			{
				KeyValuePair<string, string> keyValuePair = p;
				return keyValuePair.Key;
			}).ThenBy(delegate(KeyValuePair<string, string> p)
			{
				KeyValuePair<string, string> keyValuePair = p;
				return UrlEncode(keyValuePair.Value);
			}))
			{
				stringBuilder.AppendFormat(",{0}=\"{1}\"", UrlEncode(item.Key), UrlEncode(item.Value));
			}
			stringBuilder.AppendFormat(",oauth_signature=\"{0}\"", UrlEncode(parameters["oauth_signature"]));
			return stringBuilder.ToString();
		}

		private static string GenerateSignature(string httpMethod, string url, Dictionary<string, string> parameters)
		{
			IEnumerable<KeyValuePair<string, string>> parameters2 = parameters.Where(delegate(KeyValuePair<string, string> p)
			{
				string[] secretParameters = SecretParameters;
				KeyValuePair<string, string> keyValuePair = p;
				return !secretParameters.Contains(keyValuePair.Key);
			});
			string s = string.Format(CultureInfo.InvariantCulture, "{0}&{1}&{2}", httpMethod, UrlEncode(NormalizeUrl(new Uri(url))), UrlEncode(parameters2));
			string s2 = string.Format(CultureInfo.InvariantCulture, "{0}&{1}", UrlEncode(parameters["oauth_consumer_secret"]), parameters.ContainsKey("oauth_token_secret") ? UrlEncode(parameters["oauth_token_secret"]) : string.Empty);
			return Convert.ToBase64String(new HMACSHA1(Encoding.ASCII.GetBytes(s2)).ComputeHash(Encoding.ASCII.GetBytes(s)));
		}

		private static string GenerateTimeStamp()
		{
			return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds, CultureInfo.CurrentCulture).ToString(CultureInfo.CurrentCulture);
		}

		private static string GenerateNonce()
		{
			return new System.Random().Next(123400, int.MaxValue).ToString("X", CultureInfo.InvariantCulture);
		}

		private static string NormalizeUrl(Uri url)
		{
			string text = string.Format(CultureInfo.InvariantCulture, "{0}://{1}", url.Scheme, url.Host);
			if ((!(url.Scheme == "http") || url.Port != 80) && (!(url.Scheme == "https") || url.Port != 443))
			{
				text = text + ":" + url.Port;
			}
			return text + url.AbsolutePath;
		}

		private static string EscapeString(string originalString)
		{
			int num = 2000;
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = originalString.Length / num;
			for (int i = 0; i <= num2; i++)
			{
				if (i < num2)
				{
					stringBuilder.Append(Uri.EscapeDataString(originalString.Substring(num * i, num)));
				}
				else
				{
					stringBuilder.Append(Uri.EscapeDataString(originalString.Substring(num * i)));
				}
			}
			return stringBuilder.ToString();
		}

		private static string UrlEncode(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}
			value = EscapeString(value);
			value = Regex.Replace(value, "(%[0-9a-f][0-9a-f])", (Match c) => c.Value.ToUpper());
			value = value.Replace("(", "%28").Replace(")", "%29").Replace("$", "%24")
				.Replace("!", "%21")
				.Replace("*", "%2A")
				.Replace("'", "%27");
			value = value.Replace("%7E", "~");
			return value;
		}

		private static string UrlEncode(IEnumerable<KeyValuePair<string, string>> parameters)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in parameters.OrderBy(delegate(KeyValuePair<string, string> p)
			{
				KeyValuePair<string, string> keyValuePair = p;
				return keyValuePair.Key;
			}).ThenBy(delegate(KeyValuePair<string, string> p)
			{
				KeyValuePair<string, string> keyValuePair = p;
				return keyValuePair.Value;
			}))
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append("&");
				}
				stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0}={1}", UrlEncode(item.Key), UrlEncode(item.Value)));
			}
			return UrlEncode(stringBuilder.ToString());
		}
	}
}
