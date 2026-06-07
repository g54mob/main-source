using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class OriginatorPublicKey : Asn1Encodable
	{
		private readonly AlgorithmIdentifier mAlgorithm;

		private readonly DerBitString mPublicKey;

		public AlgorithmIdentifier Algorithm => null;

		public DerBitString PublicKey => null;

		public OriginatorPublicKey(AlgorithmIdentifier algorithm, byte[] publicKey)
		{
		}

		public OriginatorPublicKey(Asn1Sequence seq)
		{
		}

		public static OriginatorPublicKey GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static OriginatorPublicKey GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
