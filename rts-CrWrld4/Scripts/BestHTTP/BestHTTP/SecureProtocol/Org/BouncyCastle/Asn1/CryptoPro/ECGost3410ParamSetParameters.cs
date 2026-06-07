using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.CryptoPro
{
	public class ECGost3410ParamSetParameters : Asn1Encodable
	{
		internal readonly DerInteger p;

		internal readonly DerInteger q;

		internal readonly DerInteger a;

		internal readonly DerInteger b;

		internal readonly DerInteger x;

		internal readonly DerInteger y;

		public BigInteger P => null;

		public BigInteger Q => null;

		public BigInteger A => null;

		public static ECGost3410ParamSetParameters GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static ECGost3410ParamSetParameters GetInstance(object obj)
		{
			return null;
		}

		public ECGost3410ParamSetParameters(BigInteger a, BigInteger b, BigInteger p, BigInteger q, int x, BigInteger y)
		{
		}

		public ECGost3410ParamSetParameters(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
