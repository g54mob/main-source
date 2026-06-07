using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class RsaPrivateKeyStructure : Asn1Encodable
	{
		private readonly BigInteger modulus;

		private readonly BigInteger publicExponent;

		private readonly BigInteger privateExponent;

		private readonly BigInteger prime1;

		private readonly BigInteger prime2;

		private readonly BigInteger exponent1;

		private readonly BigInteger exponent2;

		private readonly BigInteger coefficient;

		public BigInteger Modulus => null;

		public BigInteger PublicExponent => null;

		public BigInteger PrivateExponent => null;

		public BigInteger Prime1 => null;

		public BigInteger Prime2 => null;

		public BigInteger Exponent1 => null;

		public BigInteger Exponent2 => null;

		public BigInteger Coefficient => null;

		public static RsaPrivateKeyStructure GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public static RsaPrivateKeyStructure GetInstance(object obj)
		{
			return null;
		}

		public RsaPrivateKeyStructure(BigInteger modulus, BigInteger publicExponent, BigInteger privateExponent, BigInteger prime1, BigInteger prime2, BigInteger exponent1, BigInteger exponent2, BigInteger coefficient)
		{
		}

		public RsaPrivateKeyStructure(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
