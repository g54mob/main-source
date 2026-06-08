using System;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime
{
	public class AssumeRoleImmutableCredentials : ImmutableCredentials
	{
		public DateTime Expiration { get; private set; }

		public AssumeRoleImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, DateTime expiration)
			: this(awsAccessKeyId, awsSecretAccessKey, token, expiration, null)
		{
		}

		public AssumeRoleImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, DateTime expiration, string accountId)
			: base(awsAccessKeyId, awsSecretAccessKey, token, accountId)
		{
			if (string.IsNullOrEmpty(token))
			{
				throw new ArgumentNullException("token");
			}
			Expiration = expiration;
		}

		public new AssumeRoleImmutableCredentials Copy()
		{
			return new AssumeRoleImmutableCredentials(base.AccessKey, base.SecretKey, base.Token, Expiration, base.AccountId);
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(base.AccessKey, base.SecretKey, base.Token, Expiration);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is AssumeRoleImmutableCredentials assumeRoleImmutableCredentials))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[4] { base.AccessKey, base.SecretKey, base.Token, Expiration }, new object[4] { assumeRoleImmutableCredentials.AccessKey, assumeRoleImmutableCredentials.SecretKey, assumeRoleImmutableCredentials.Token, Expiration });
		}
	}
}
