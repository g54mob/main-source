namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerVisibleString : DerStringBase
	{
		private readonly string str;

		public static DerVisibleString GetInstance(object obj)
		{
			return null;
		}

		public static DerVisibleString GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public DerVisibleString(byte[] str)
		{
		}

		public DerVisibleString(string str)
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

		protected override int Asn1GetHashCode()
		{
			return 0;
		}
	}
}
