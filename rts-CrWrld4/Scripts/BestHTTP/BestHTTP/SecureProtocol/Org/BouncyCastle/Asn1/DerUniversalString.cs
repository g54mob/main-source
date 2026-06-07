namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerUniversalString : DerStringBase
	{
		private static readonly char[] table;

		private readonly byte[] str;

		public static DerUniversalString GetInstance(object obj)
		{
			return null;
		}

		public static DerUniversalString GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public DerUniversalString(byte[] str)
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
	}
}
