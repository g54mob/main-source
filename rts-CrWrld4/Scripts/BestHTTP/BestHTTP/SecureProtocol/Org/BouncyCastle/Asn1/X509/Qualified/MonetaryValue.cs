using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509.Qualified
{
	public class MonetaryValue : Asn1Encodable
	{
		internal Iso4217CurrencyCode currency;

		internal DerInteger amount;

		internal DerInteger exponent;

		public Iso4217CurrencyCode Currency => null;

		public BigInteger Amount => null;

		public BigInteger Exponent => null;

		public static MonetaryValue GetInstance(object obj)
		{
			return null;
		}

		private MonetaryValue(Asn1Sequence seq)
		{
		}

		public MonetaryValue(Iso4217CurrencyCode currency, int amount, int exponent)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
