using System;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime
{
	public class ImmutableCredentials
	{
		public string AccessKey { get; private set; }

		public string SecretKey { get; private set; }

		public string Token { get; private set; }

		public bool UseToken => !string.IsNullOrEmpty(Token);

		public string AccountId { get; private set; }

		public ImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token)
		{
			if (string.IsNullOrEmpty(awsAccessKeyId))
			{
				throw new ArgumentNullException("awsAccessKeyId");
			}
			if (string.IsNullOrEmpty(awsSecretAccessKey))
			{
				throw new ArgumentNullException("awsSecretAccessKey");
			}
			AccessKey = awsAccessKeyId;
			SecretKey = awsSecretAccessKey;
			Token = token ?? string.Empty;
		}

		public ImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, string accountId)
			: this(awsAccessKeyId, awsSecretAccessKey, token)
		{
			AccountId = accountId;
		}

		private ImmutableCredentials()
		{
		}

		public virtual ImmutableCredentials Copy()
		{
			return new ImmutableCredentials
			{
				AccessKey = AccessKey,
				SecretKey = SecretKey,
				Token = Token,
				AccountId = AccountId
			};
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(AccessKey, SecretKey, Token);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is ImmutableCredentials immutableCredentials))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[3] { AccessKey, SecretKey, Token }, new object[3] { immutableCredentials.AccessKey, immutableCredentials.SecretKey, immutableCredentials.Token });
		}
	}
}
