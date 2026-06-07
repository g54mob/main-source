namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerBitString : DerStringBase
	{
		private static readonly char[] table;

		protected readonly byte[] mData;

		protected readonly int mPadBits;

		public virtual int PadBits => 0;

		public virtual int IntValue => 0;

		public static DerBitString GetInstance(object obj)
		{
			return null;
		}

		public static DerBitString GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public DerBitString(byte[] data, int padBits)
		{
		}

		public DerBitString(byte[] data)
		{
		}

		public DerBitString(int namedBits)
		{
		}

		public DerBitString(Asn1Encodable obj)
		{
		}

		public virtual byte[] GetOctets()
		{
			return null;
		}

		public virtual byte[] GetBytes()
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

		public override string GetString()
		{
			return null;
		}

		internal static DerBitString FromAsn1Octets(byte[] octets)
		{
			return null;
		}
	}
}
