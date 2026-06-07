namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerBmpString : DerStringBase
	{
		private readonly string str;

		public static DerBmpString GetInstance(object obj)
		{
			return null;
		}

		public static DerBmpString GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public DerBmpString(byte[] str)
		{
		}

		internal DerBmpString(char[] str)
		{
		}

		public DerBmpString(string str)
		{
		}

		public override string GetString()
		{
			return null;
		}

		protected override bool Asn1Equals(Asn1Object asn1Object)
		{
			return false;
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}
	}
}
