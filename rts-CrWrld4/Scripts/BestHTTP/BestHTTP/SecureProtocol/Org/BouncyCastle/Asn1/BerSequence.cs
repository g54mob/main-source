namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerSequence : DerSequence
	{
		public new static readonly BerSequence Empty;

		public new static BerSequence FromVector(Asn1EncodableVector elementVector)
		{
			return null;
		}

		public BerSequence()
		{
		}

		public BerSequence(Asn1Encodable element)
		{
		}

		public BerSequence(params Asn1Encodable[] elements)
		{
		}

		public BerSequence(Asn1EncodableVector elementVector)
		{
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}
	}
}
