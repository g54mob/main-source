namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerNumericString : DerStringBase
	{
		private readonly string str;

		public static DerNumericString GetInstance(object obj)
		{
			return null;
		}

		public static DerNumericString GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public DerNumericString(byte[] str)
		{
		}

		public DerNumericString(string str)
		{
		}

		public DerNumericString(string str, bool validate)
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

		public static bool IsNumericString(string str)
		{
			return false;
		}
	}
}
