using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.X509
{
	public class MonetaryLimit : Asn1Encodable
	{
		private readonly DerPrintableString currency;

		private readonly DerInteger amount;

		private readonly DerInteger exponent;

		public virtual string Currency => null;

		public virtual BigInteger Amount => null;

		public virtual BigInteger Exponent => null;

		public static MonetaryLimit GetInstance(object obj)
		{
			return null;
		}

		private MonetaryLimit(Asn1Sequence seq)
		{
		}

		public MonetaryLimit(string currency, int amount, int exponent)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
