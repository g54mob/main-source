using System.Collections;

namespace VoxelBusters.EssentialKit
{
	public class ServerCredentials
	{
		public class AndroidPlatformProperties
		{
			public string ServerAuthCode { get; private set; }

			public AndroidPlatformProperties(string serverAuthCode)
			{
			}
		}

		public class IosPlatformProperties
		{
			private const string kCredentialsPublicKeyUrl = "public-key-url";

			private const string kCredentialsSignature = "signature";

			private const string kCredentialsSalt = "salt";

			private const string kCredentialsTimestamp = "timestamp";

			public string PublicKeyUrl { get; private set; }

			public byte[] Signature { get; private set; }

			public byte[] Salt { get; private set; }

			public long Timestamp { get; private set; }

			public IosPlatformProperties(string publicKeyUrl, byte[] signature, byte[] salt, long timestamp)
			{
			}

			private void Load(IDictionary json)
			{
			}
		}

		private IosPlatformProperties m_iosProperties;

		private AndroidPlatformProperties m_androidProperties;

		public IosPlatformProperties IosProperties => null;

		public AndroidPlatformProperties AndroidProperties => null;

		public ServerCredentials(IosPlatformProperties iosProperties = null, AndroidPlatformProperties androidProperties = null)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
