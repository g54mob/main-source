using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public class X9FieldElement : Asn1Encodable
	{
		private ECFieldElement f;

		public ECFieldElement Value => null;

		public X9FieldElement(ECFieldElement f)
		{
		}

		public X9FieldElement(BigInteger p, Asn1OctetString s)
		{
		}

		public X9FieldElement(int m, int k1, int k2, int k3, Asn1OctetString s)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
