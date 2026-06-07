using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class RsassaPssParameters : Asn1Encodable
	{
		private AlgorithmIdentifier hashAlgorithm;

		private AlgorithmIdentifier maskGenAlgorithm;

		private DerInteger saltLength;

		private DerInteger trailerField;

		public static readonly AlgorithmIdentifier DefaultHashAlgorithm;

		public static readonly AlgorithmIdentifier DefaultMaskGenFunction;

		public static readonly DerInteger DefaultSaltLength;

		public static readonly DerInteger DefaultTrailerField;

		public AlgorithmIdentifier HashAlgorithm => null;

		public AlgorithmIdentifier MaskGenAlgorithm => null;

		public DerInteger SaltLength => null;

		public DerInteger TrailerField => null;

		public static RsassaPssParameters GetInstance(object obj)
		{
			return null;
		}

		public RsassaPssParameters()
		{
		}

		public RsassaPssParameters(AlgorithmIdentifier hashAlgorithm, AlgorithmIdentifier maskGenAlgorithm, DerInteger saltLength, DerInteger trailerField)
		{
		}

		public RsassaPssParameters(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
