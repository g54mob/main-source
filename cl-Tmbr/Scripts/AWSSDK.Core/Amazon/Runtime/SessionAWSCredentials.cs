using System;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime
{
	public class SessionAWSCredentials : AWSCredentials
	{
		private ImmutableCredentials _lastCredentials;

		public SessionAWSCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token)
			: this(awsAccessKeyId, awsSecretAccessKey, token, null)
		{
		}

		public SessionAWSCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, string accountId)
		{
			if (string.IsNullOrEmpty(awsAccessKeyId))
			{
				throw new ArgumentNullException("awsAccessKeyId");
			}
			if (string.IsNullOrEmpty(awsSecretAccessKey))
			{
				throw new ArgumentNullException("awsSecretAccessKey");
			}
			if (string.IsNullOrEmpty(token))
			{
				throw new ArgumentNullException("token");
			}
			_lastCredentials = new ImmutableCredentials(awsAccessKeyId, awsSecretAccessKey, token, accountId);
			base.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_STS_SESSION_TOKEN);
		}

		public override ImmutableCredentials GetCredentials()
		{
			return _lastCredentials.Copy();
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is SessionAWSCredentials sessionAWSCredentials))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[1] { _lastCredentials }, new object[1] { sessionAWSCredentials._lastCredentials });
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(_lastCredentials);
		}
	}
}
