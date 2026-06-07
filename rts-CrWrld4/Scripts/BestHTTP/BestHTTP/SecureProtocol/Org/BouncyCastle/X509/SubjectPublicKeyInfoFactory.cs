using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public sealed class SubjectPublicKeyInfoFactory
	{
		private SubjectPublicKeyInfoFactory()
		{
		}

		public static SubjectPublicKeyInfo CreateSubjectPublicKeyInfo(AsymmetricKeyParameter publicKey)
		{
			return null;
		}

		private static void ExtractBytes(byte[] encKey, int offset, BigInteger bI)
		{
		}

		private static void ExtractBytes(byte[] encKey, int size, int offSet, BigInteger bI)
		{
		}
	}
}
