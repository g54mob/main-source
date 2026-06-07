namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class SubjectPublicKeyInfo : Asn1Encodable
	{
		private readonly AlgorithmIdentifier algID;

		private readonly DerBitString keyData;

		public AlgorithmIdentifier AlgorithmID => null;

		public DerBitString PublicKeyData => null;

		public static SubjectPublicKeyInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static SubjectPublicKeyInfo GetInstance(object obj)
		{
			return null;
		}

		public SubjectPublicKeyInfo(AlgorithmIdentifier algID, Asn1Encodable publicKey)
		{
		}

		public SubjectPublicKeyInfo(AlgorithmIdentifier algID, byte[] publicKey)
		{
		}

		private SubjectPublicKeyInfo(Asn1Sequence seq)
		{
		}

		public Asn1Object ParsePublicKey()
		{
			return null;
		}

		public Asn1Object GetPublicKey()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
