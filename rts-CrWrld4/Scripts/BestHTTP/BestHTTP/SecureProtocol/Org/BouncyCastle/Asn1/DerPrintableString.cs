namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerPrintableString : DerStringBase
	{
		private readonly string str;

		public static DerPrintableString GetInstance(object obj)
		{
			return null;
		}

		public static DerPrintableString GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public DerPrintableString(byte[] str)
		{
		}

		public DerPrintableString(string str)
		{
		}

		public DerPrintableString(string str, bool validate)
		{
		}

		public override string GetString()
		{
			return null;
		}

		public byte[] GetOctets()
		{
			return null;
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}

		protected override bool Asn1Equals(Asn1Object asn1Object)
		{
			return false;
		}

		public static bool IsPrintableString(string str)
		{
			return false;
		}
	}
}
