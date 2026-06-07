namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerGeneralString : DerStringBase
	{
		private readonly string str;

		public static DerGeneralString GetInstance(object obj)
		{
			return null;
		}

		public static DerGeneralString GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public DerGeneralString(byte[] str)
		{
		}

		public DerGeneralString(string str)
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
