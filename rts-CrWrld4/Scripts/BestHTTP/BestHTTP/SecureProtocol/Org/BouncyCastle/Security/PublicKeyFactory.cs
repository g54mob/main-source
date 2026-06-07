using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class PublicKeyFactory
	{
		private PublicKeyFactory()
		{
		}

		public static AsymmetricKeyParameter CreateKey(byte[] keyInfoData)
		{
			return null;
		}

		public static AsymmetricKeyParameter CreateKey(Stream inStr)
		{
			return null;
		}

		public static AsymmetricKeyParameter CreateKey(SubjectPublicKeyInfo keyInfo)
		{
			return null;
		}

		private static byte[] GetRawKey(SubjectPublicKeyInfo keyInfo, int expectedSize)
		{
			return null;
		}

		private static bool IsPkcsDHParam(Asn1Sequence seq)
		{
			return false;
		}

		private static DHPublicKeyParameters ReadPkcsDHParam(DerObjectIdentifier algOid, BigInteger y, Asn1Sequence seq)
		{
			return null;
		}
	}
}
