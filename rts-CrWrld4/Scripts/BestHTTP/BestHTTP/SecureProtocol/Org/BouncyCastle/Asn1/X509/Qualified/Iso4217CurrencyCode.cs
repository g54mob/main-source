namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509.Qualified
{
	public class Iso4217CurrencyCode : Asn1Encodable, IAsn1Choice
	{
		internal const int AlphabeticMaxSize = 3;

		internal const int NumericMinSize = 1;

		internal const int NumericMaxSize = 999;

		internal Asn1Encodable obj;

		public bool IsAlphabetic => false;

		public string Alphabetic => null;

		public int Numeric => 0;

		public static Iso4217CurrencyCode GetInstance(object obj)
		{
			return null;
		}

		public Iso4217CurrencyCode(int numeric)
		{
		}

		public Iso4217CurrencyCode(string alphabetic)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
