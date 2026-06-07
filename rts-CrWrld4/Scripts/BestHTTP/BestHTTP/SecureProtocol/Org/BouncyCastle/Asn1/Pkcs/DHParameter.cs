using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class DHParameter : Asn1Encodable
	{
		internal DerInteger p;

		internal DerInteger g;

		internal DerInteger l;

		public BigInteger P => null;

		public BigInteger G => null;

		public BigInteger L => null;

		public DHParameter(BigInteger p, BigInteger g, int l)
		{
		}

		public DHParameter(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
