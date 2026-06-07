namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerIA5String : DerStringBase
	{
		private readonly string str;

		public static DerIA5String GetInstance(object obj)
		{
			return null;
		}

		public static DerIA5String GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public DerIA5String(byte[] str)
		{
		}

		public DerIA5String(string str)
		{
		}

		public DerIA5String(string str, bool validate)
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

		protected override int Asn1GetHashCode()
		{
			return 0;
		}

		protected override bool Asn1Equals(Asn1Object asn1Object)
		{
			return false;
		}

		public static bool IsIA5String(string str)
		{
			return false;
		}
	}
}
