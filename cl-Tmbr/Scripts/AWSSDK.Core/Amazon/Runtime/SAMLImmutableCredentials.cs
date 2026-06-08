using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime
{
	public class SAMLImmutableCredentials : ImmutableCredentials
	{
		private const string AccessKeyProperty = "AccessKey";

		private const string SecretKeyProperty = "SecretKey";

		private const string TokenProperty = "Token";

		private const string ExpiresProperty = "Expires";

		private const string SubjectProperty = "Subject";

		public DateTime Expires { get; private set; }

		public string Subject { get; private set; }

		public SAMLImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, DateTime expires, string subject)
			: this(awsAccessKeyId, awsSecretAccessKey, token, expires, subject, null)
		{
		}

		public SAMLImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, DateTime expires, string subject, string accountId)
			: base(awsAccessKeyId, awsSecretAccessKey, token, accountId)
		{
			Expires = expires;
			Subject = subject;
		}

		public SAMLImmutableCredentials(ImmutableCredentials credentials, DateTime expires, string subject, string accountId)
			: base(credentials.AccessKey, credentials.SecretKey, credentials.Token, accountId)
		{
			Expires = expires;
			Subject = subject;
		}

		public SAMLImmutableCredentials(ImmutableCredentials credentials, DateTime expires, string subject)
			: this(credentials, expires, subject, null)
		{
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(base.AccessKey, base.SecretKey, base.Token, Subject, Expires);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is SAMLImmutableCredentials sAMLImmutableCredentials))
			{
				return false;
			}
			if (base.Equals(obj))
			{
				if (string.Equals(Subject, sAMLImmutableCredentials.Subject, StringComparison.Ordinal))
				{
					return DateTime.Equals(Expires, sAMLImmutableCredentials.Expires);
				}
				return false;
			}
			return false;
		}

		public override ImmutableCredentials Copy()
		{
			return new SAMLImmutableCredentials(base.AccessKey, base.SecretKey, base.Token, Expires, Subject, base.AccountId);
		}

		internal string ToJson()
		{
			return JsonSerializerHelper.Serialize<Dictionary<string, string>>(new Dictionary<string, string>
			{
				{ "AccessKey", base.AccessKey },
				{ "SecretKey", base.SecretKey },
				{ "Token", base.Token },
				{
					"Expires",
					Expires.ToString("u", CultureInfo.InvariantCulture)
				},
				{ "Subject", Subject }
			}, JsonSerializerContext.Default);
		}

		internal static SAMLImmutableCredentials FromJson(string json)
		{
			try
			{
				using JsonDocument jsonDocument = JsonDocument.Parse(json);
				DateTime dateTime = DateTime.Parse(jsonDocument.RootElement.GetProperty("Expires").GetString(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
				if (dateTime <= AWSSDKUtils.CorrectedUtcNow)
				{
					Logger.GetLogger(typeof(SAMLImmutableCredentials)).DebugFormat("Skipping serialized credentials due to expiry.");
					return null;
				}
				string? awsAccessKeyId = jsonDocument.RootElement.GetProperty("AccessKey").GetString();
				string awsSecretAccessKey = jsonDocument.RootElement.GetProperty("SecretKey").GetString();
				string token = jsonDocument.RootElement.GetProperty("Token").GetString();
				string subject = jsonDocument.RootElement.GetProperty("Subject").GetString();
				return new SAMLImmutableCredentials(awsAccessKeyId, awsSecretAccessKey, token, dateTime, subject);
			}
			catch (Exception exception)
			{
				Logger.GetLogger(typeof(SAMLImmutableCredentials)).Error(exception, "Error during deserialization");
			}
			return null;
		}
	}
}
