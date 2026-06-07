using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class TlsSRTPUtils
	{
		public static void AddUseSrtpExtension(IDictionary extensions, UseSrtpData useSRTPData)
		{
		}

		public static UseSrtpData GetUseSrtpExtension(IDictionary extensions)
		{
			return null;
		}

		public static byte[] CreateUseSrtpExtension(UseSrtpData useSrtpData)
		{
			return null;
		}

		public static UseSrtpData ReadUseSrtpExtension(byte[] extensionData)
		{
			return null;
		}
	}
}
