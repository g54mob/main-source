namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerNull : Asn1Null
	{
		public static readonly DerNull Instance;

		private byte[] zeroBytes;

		public DerNull()
		{
		}

		protected internal DerNull(int dummy)
		{
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
