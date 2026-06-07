using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class TlsSrpUtilities
	{
		public static void AddSrpExtension(IDictionary extensions, byte[] identity)
		{
		}

		public static byte[] GetSrpExtension(IDictionary extensions)
		{
			return null;
		}

		public static byte[] CreateSrpExtension(byte[] identity)
		{
			return null;
		}

		public static byte[] ReadSrpExtension(byte[] extensionData)
		{
			return null;
		}

		public static BigInteger ReadSrpParameter(Stream input)
		{
			return null;
		}

		public static void WriteSrpParameter(BigInteger x, Stream output)
		{
		}

		public static bool IsSrpCipherSuite(int cipherSuite)
		{
			return false;
		}
	}
}
