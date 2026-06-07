namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerNull : DerNull
	{
		public new static readonly BerNull Instance;

		public BerNull()
		{
		}

		private BerNull(int dummy)
		{
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}
	}
}
