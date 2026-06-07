using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Oiw
{
	public class ElGamalParameter : Asn1Encodable
	{
		internal DerInteger p;

		internal DerInteger g;

		public BigInteger P => null;

		public BigInteger G => null;

		public ElGamalParameter(BigInteger p, BigInteger g)
		{
		}

		public ElGamalParameter(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
