namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class DigestInfo : Asn1Encodable
	{
		private readonly byte[] digest;

		private readonly AlgorithmIdentifier algID;

		public AlgorithmIdentifier AlgorithmID => null;

		public static DigestInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static DigestInfo GetInstance(object obj)
		{
			return null;
		}

		public DigestInfo(AlgorithmIdentifier algID, byte[] digest)
		{
		}

		private DigestInfo(Asn1Sequence seq)
		{
		}

		public byte[] GetDigest()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
