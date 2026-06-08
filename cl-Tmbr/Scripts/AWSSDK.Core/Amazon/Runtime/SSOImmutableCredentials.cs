using System;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime
{
	public class SSOImmutableCredentials : ImmutableCredentials
	{
		public DateTime Expiration { get; private set; }

		public SSOImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, DateTime expiration)
			: this(awsAccessKeyId, awsSecretAccessKey, token, expiration, null)
		{
		}

		public SSOImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, DateTime expiration, string accountId)
			: base(awsAccessKeyId, awsSecretAccessKey, token, accountId)
		{
			if (string.IsNullOrEmpty(token))
			{
				throw new ArgumentNullException("token");
			}
			Expiration = expiration;
		}

		public new SSOImmutableCredentials Copy()
		{
			return new SSOImmutableCredentials(base.AccessKey, base.SecretKey, base.Token, Expiration, base.AccountId);
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(base.AccessKey, base.SecretKey, base.Token, Expiration, base.AccountId);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is SSOImmutableCredentials sSOImmutableCredentials))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[5] { base.AccessKey, base.SecretKey, base.Token, Expiration, base.AccountId }, new object[5] { sSOImmutableCredentials.AccessKey, sSOImmutableCredentials.SecretKey, sSOImmutableCredentials.Token, Expiration, base.AccountId });
		}
	}
}
