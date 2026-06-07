namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class ObjectDigestInfo : Asn1Encodable
	{
		public const int PublicKey = 0;

		public const int PublicKeyCert = 1;

		public const int OtherObjectDigest = 2;

		internal readonly DerEnumerated digestedObjectType;

		internal readonly DerObjectIdentifier otherObjectTypeID;

		internal readonly AlgorithmIdentifier digestAlgorithm;

		internal readonly DerBitString objectDigest;

		public DerEnumerated DigestedObjectType => null;

		public DerObjectIdentifier OtherObjectTypeID => null;

		public AlgorithmIdentifier DigestAlgorithm => null;

		public DerBitString ObjectDigest => null;

		public static ObjectDigestInfo GetInstance(object obj)
		{
			return null;
		}

		public static ObjectDigestInfo GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public ObjectDigestInfo(int digestedObjectType, string otherObjectTypeID, AlgorithmIdentifier digestAlgorithm, byte[] objectDigest)
		{
		}

		private ObjectDigestInfo(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
