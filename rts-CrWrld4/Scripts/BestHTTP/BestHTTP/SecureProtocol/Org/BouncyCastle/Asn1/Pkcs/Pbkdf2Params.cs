using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class Pbkdf2Params : Asn1Encodable
	{
		private static AlgorithmIdentifier algid_hmacWithSHA1;

		private readonly Asn1OctetString octStr;

		private readonly DerInteger iterationCount;

		private readonly DerInteger keyLength;

		private readonly AlgorithmIdentifier prf;

		public BigInteger IterationCount => null;

		public BigInteger KeyLength => null;

		public bool IsDefaultPrf => false;

		public AlgorithmIdentifier Prf => null;

		public static Pbkdf2Params GetInstance(object obj)
		{
			return null;
		}

		public Pbkdf2Params(Asn1Sequence seq)
		{
		}

		public Pbkdf2Params(byte[] salt, int iterationCount)
		{
		}

		public Pbkdf2Params(byte[] salt, int iterationCount, int keyLength)
		{
		}

		public Pbkdf2Params(byte[] salt, int iterationCount, int keyLength, AlgorithmIdentifier prf)
		{
		}

		public Pbkdf2Params(byte[] salt, int iterationCount, AlgorithmIdentifier prf)
		{
		}

		public byte[] GetSalt()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
