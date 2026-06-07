namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerTaggedObject : DerTaggedObject
	{
		public BerTaggedObject(int tagNo, Asn1Encodable obj)
			: base(0, null)
		{
		}

		public BerTaggedObject(bool explicitly, int tagNo, Asn1Encodable obj)
			: base(0, null)
		{
		}

		public BerTaggedObject(int tagNo)
			: base(0, null)
		{
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}
	}
}
