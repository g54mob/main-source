using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class RsaesOaepParameters : Asn1Encodable
	{
		private AlgorithmIdentifier hashAlgorithm;

		private AlgorithmIdentifier maskGenAlgorithm;

		private AlgorithmIdentifier pSourceAlgorithm;

		public static readonly AlgorithmIdentifier DefaultHashAlgorithm;

		public static readonly AlgorithmIdentifier DefaultMaskGenFunction;

		public static readonly AlgorithmIdentifier DefaultPSourceAlgorithm;

		public AlgorithmIdentifier HashAlgorithm => null;

		public AlgorithmIdentifier MaskGenAlgorithm => null;

		public AlgorithmIdentifier PSourceAlgorithm => null;

		public static RsaesOaepParameters GetInstance(object obj)
		{
			return null;
		}

		public RsaesOaepParameters()
		{
		}

		public RsaesOaepParameters(AlgorithmIdentifier hashAlgorithm, AlgorithmIdentifier maskGenAlgorithm, AlgorithmIdentifier pSourceAlgorithm)
		{
		}

		public RsaesOaepParameters(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
