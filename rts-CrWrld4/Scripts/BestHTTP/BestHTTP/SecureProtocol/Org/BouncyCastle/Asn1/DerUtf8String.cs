namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerUtf8String : DerStringBase
	{
		private readonly string str;

		public static DerUtf8String GetInstance(object obj)
		{
			return null;
		}

		public static DerUtf8String GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public DerUtf8String(byte[] str)
		{
		}

		public DerUtf8String(string str)
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
