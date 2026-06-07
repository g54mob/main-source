using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public class X9ECParameters : Asn1Encodable
	{
		private X9FieldID fieldID;

		private ECCurve curve;

		private X9ECPoint g;

		private BigInteger n;

		private BigInteger h;

		private byte[] seed;

		public ECCurve Curve => null;

		public ECPoint G => null;

		public BigInteger N => null;

		public BigInteger H => null;

		public X9Curve CurveEntry => null;

		public X9FieldID FieldIDEntry => null;

		public X9ECPoint BaseEntry => null;

		public static X9ECParameters GetInstance(object obj)
		{
			return null;
		}

		public X9ECParameters(Asn1Sequence seq)
		{
		}

		public X9ECParameters(ECCurve curve, ECPoint g, BigInteger n)
		{
		}

		public X9ECParameters(ECCurve curve, X9ECPoint g, BigInteger n, BigInteger h)
		{
		}

		public X9ECParameters(ECCurve curve, ECPoint g, BigInteger n, BigInteger h)
		{
		}

		public X9ECParameters(ECCurve curve, ECPoint g, BigInteger n, BigInteger h, byte[] seed)
		{
		}

		public X9ECParameters(ECCurve curve, X9ECPoint g, BigInteger n, BigInteger h, byte[] seed)
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
