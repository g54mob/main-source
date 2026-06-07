using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO.Pem;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.OpenSsl
{
	public class MiscPemGenerator : PemObjectGenerator
	{
		private object obj;

		private string algorithm;

		private char[] password;

		private SecureRandom random;

		public MiscPemGenerator(object obj)
		{
		}

		public MiscPemGenerator(object obj, string algorithm, char[] password, SecureRandom random)
		{
		}

		private static PemObject CreatePemObject(object obj)
		{
			return null;
		}

		private static PemObject CreatePemObject(object obj, string algorithm, char[] password, SecureRandom random)
		{
			return null;
		}

		private static byte[] EncodePrivateKey(AsymmetricKeyParameter akp, out string keyType)
		{
			keyType = null;
			return null;
		}

		public PemObject Generate()
		{
			return null;
		}
	}
}
