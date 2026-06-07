using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public class X9ECPoint : Asn1Encodable
	{
		private readonly Asn1OctetString encoding;

		private ECCurve c;

		private ECPoint p;

		public ECPoint Point => null;

		public bool IsPointCompressed => false;

		public X9ECPoint(ECPoint p)
		{
		}

		public X9ECPoint(ECPoint p, bool compressed)
		{
		}

		public X9ECPoint(ECCurve c, byte[] encoding)
		{
		}

		public X9ECPoint(ECCurve c, Asn1OctetString s)
		{
		}

		public byte[] GetPointEncoding()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
