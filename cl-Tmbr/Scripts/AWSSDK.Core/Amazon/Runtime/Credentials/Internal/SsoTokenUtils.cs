using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Credentials.Internal
{
	public static class SsoTokenUtils
	{
		private static class JsonPropertyNames
		{
			public const string AccessToken = "accessToken";

			public const string Region = "region";

			public const string RefreshToken = "refreshToken";

			public const string ClientId = "clientId";

			public const string ClientSecret = "clientSecret";

			public const string RegistrationExpiresAt = "registrationExpiresAt";

			public const string ExpiresAt = "expiresAt";

			public const string StartUrl = "startUrl";
		}

		public static bool IsExpired(this SsoToken token)
		{
			if (token == null)
			{
				throw new ArgumentNullException("token");
			}
			DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
			return token.ExpiresAt < correctedUtcNow;
		}

		public static bool NeedsRefresh(this SsoToken token)
		{
			DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
			return token.ExpiresAt <= correctedUtcNow.AddMinutes(6.0);
		}

		public static bool CanRefresh(this SsoToken token)
		{
			if (!string.IsNullOrEmpty(token.RefreshToken) && !string.IsNullOrEmpty(token.ClientId))
			{
				return !string.IsNullOrEmpty(token.ClientSecret);
			}
			return false;
		}

		public static string AsJson(this SsoToken token)
		{
			return ToJson(token);
		}

		public static bool RegisteredClientExpired(this SsoToken token)
		{
			if (token == null)
			{
				throw new ArgumentNullException("token");
			}
			DateTime dateTime = ConvertRFC3339StringToDateTime(token.RegistrationExpiresAt);
			return AWSSDKUtils.CorrectedUtcNow >= dateTime.AddMinutes(-5.0);
		}

		public static string ToJson(SsoToken token)
		{
			return JsonSerializerHelper.Serialize<Dictionary<string, string>>(new Dictionary<string, string>
			{
				["accessToken"] = token.AccessToken,
				["expiresAt"] = XmlConvert.ToString(token.ExpiresAt, XmlDateTimeSerializationMode.Utc),
				["refreshToken"] = token.RefreshToken,
				["clientId"] = token.ClientId,
				["clientSecret"] = token.ClientSecret,
				["registrationExpiresAt"] = token.RegistrationExpiresAt,
				["region"] = token.Region,
				["startUrl"] = token.StartUrl
			}, new DictionaryStringStringJsonSerializerContexts(new Amazon.Util.Internal.JsonSerializerOptions
			{
				WriteIndented = true
			}));
		}

		public static SsoToken FromJson(string json, bool throwIfTokenInvalid)
		{
			using JsonDocument jsonDocument = JsonDocument.Parse(json);
			JsonElement rootElement = jsonDocument.RootElement;
			SsoToken ssoToken = new SsoToken();
			if (rootElement.TryGetProperty("accessToken", out var value))
			{
				ssoToken.AccessToken = value.GetString();
				if (rootElement.TryGetProperty("expiresAt", out var value2))
				{
					ssoToken.ExpiresAt = XmlConvert.ToDateTime(value2.GetString(), XmlDateTimeSerializationMode.Utc);
					if (rootElement.TryGetProperty("refreshToken", out var value3))
					{
						ssoToken.RefreshToken = value3.GetString();
					}
					if (rootElement.TryGetProperty("clientId", out var value4))
					{
						ssoToken.ClientId = value4.GetString();
					}
					if (rootElement.TryGetProperty("clientSecret", out var value5))
					{
						ssoToken.ClientSecret = value5.GetString();
					}
					if (rootElement.TryGetProperty("registrationExpiresAt", out var value6))
					{
						ssoToken.RegistrationExpiresAt = value6.GetString();
					}
					if (rootElement.TryGetProperty("region", out var value7))
					{
						ssoToken.Region = value7.GetString();
					}
					if (rootElement.TryGetProperty("startUrl", out var value8))
					{
						ssoToken.StartUrl = value8.GetString();
					}
					return ssoToken;
				}
				if (throwIfTokenInvalid)
				{
					throw new AmazonClientException("Token is invalid: missing required field [expiresAt]");
				}
				return null;
			}
			if (throwIfTokenInvalid)
			{
				throw new AmazonClientException("Token is invalid: missing required field [accessToken]");
			}
			return null;
		}

		public static SsoToken FromJson(string json)
		{
			return FromJson(json, throwIfTokenInvalid: true);
		}

		private static DateTime ConvertRFC3339StringToDateTime(string stringFormattedDate)
		{
			if (string.IsNullOrEmpty(stringFormattedDate))
			{
				throw new ArgumentNullException("stringFormattedDate");
			}
			return XmlConvert.ToDateTime(stringFormattedDate, XmlDateTimeSerializationMode.Utc);
		}
	}
}
