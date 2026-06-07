namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerApplicationSpecific : Asn1Object
	{
		private readonly bool isConstructed;

		private readonly int tag;

		private readonly byte[] octets;

		public int ApplicationTag => 0;

		internal DerApplicationSpecific(bool isConstructed, int tag, byte[] octets)
		{
		}

		public DerApplicationSpecific(int tag, byte[] octets)
		{
		}

		public DerApplicationSpecific(int tag, Asn1Encodable obj)
		{
		}

		public DerApplicationSpecific(bool isExplicit, int tag, Asn1Encodable obj)
		{
		}

		public DerApplicationSpecific(int tagNo, Asn1EncodableVector vec)
		{
		}

		private int GetLengthOfHeader(byte[] data)
		{
			return 0;
		}

		public bool IsConstructed()
		{
			return false;
		}

		public byte[] GetContents()
		{
			return null;
		}

		public Asn1Object GetObject()
		{
			return null;
		}

		public Asn1Object GetObject(int derTagNo)
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

		private byte[] ReplaceTagNumber(int newTag, byte[] input)
		{
			return null;
		}
	}
}
