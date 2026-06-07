namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerBitString : DerBitString
	{
		public BerBitString(byte[] data, int padBits)
			: base(null, 0)
		{
		}

		public BerBitString(byte[] data)
			: base(null, 0)
		{
		}

		public BerBitString(int namedBits)
			: base(null, 0)
		{
		}

		public BerBitString(Asn1Encodable obj)
			: base(null, 0)
		{
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}
	}
}
