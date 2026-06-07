namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerTaggedObject : Asn1TaggedObject
	{
		public DerTaggedObject(int tagNo, Asn1Encodable obj)
			: base(0, null)
		{
		}

		public DerTaggedObject(bool explicitly, int tagNo, Asn1Encodable obj)
			: base(0, null)
		{
		}

		public DerTaggedObject(int tagNo)
			: base(0, null)
		{
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}
	}
}
