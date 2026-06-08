using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime
{
	public class BasicAWSCredentials : AWSCredentials
	{
		private ImmutableCredentials _credentials;

		public BasicAWSCredentials(string accessKey, string secretKey)
			: this(accessKey, secretKey, null)
		{
		}

		public BasicAWSCredentials(string accessKey, string secretKey, string accountId)
		{
			if (!string.IsNullOrEmpty(accessKey))
			{
				_credentials = new ImmutableCredentials(accessKey, secretKey, null, accountId);
				base.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_CODE);
			}
		}

		public override ImmutableCredentials GetCredentials()
		{
			if (_credentials == null)
			{
				return null;
			}
			return _credentials.Copy();
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is BasicAWSCredentials basicAWSCredentials))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[1] { _credentials }, new object[1] { basicAWSCredentials._credentials });
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(_credentials);
		}
	}
}
