using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public class X9Curve : Asn1Encodable
	{
		private readonly ECCurve curve;

		private readonly byte[] seed;

		private readonly DerObjectIdentifier fieldIdentifier;

		public ECCurve Curve => null;

		public X9Curve(ECCurve curve)
		{
		}

		public X9Curve(ECCurve curve, byte[] seed)
		{
		}

		public X9Curve(X9FieldID fieldID, Asn1Sequence seq)
		{
		}

		public X9Curve(X9FieldID fieldID, BigInteger order, BigInteger cofactor, Asn1Sequence seq)
		{
		}

		public byte[] GetSeed()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
