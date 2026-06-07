using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class RsaPublicKeyStructure : Asn1Encodable
	{
		private BigInteger modulus;

		private BigInteger publicExponent;

		public BigInteger Modulus => null;

		public BigInteger PublicExponent => null;

		public static RsaPublicKeyStructure GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static RsaPublicKeyStructure GetInstance(object obj)
		{
			return null;
		}

		public RsaPublicKeyStructure(BigInteger modulus, BigInteger publicExponent)
		{
		}

		private RsaPublicKeyStructure(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
