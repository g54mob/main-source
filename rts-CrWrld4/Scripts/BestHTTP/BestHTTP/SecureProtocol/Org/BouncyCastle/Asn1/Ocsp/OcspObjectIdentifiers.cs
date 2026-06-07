namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public abstract class OcspObjectIdentifiers
	{
		internal const string PkixOcspId = "1.3.6.1.5.5.7.48.1";

		public static readonly DerObjectIdentifier PkixOcsp;

		public static readonly DerObjectIdentifier PkixOcspBasic;

		public static readonly DerObjectIdentifier PkixOcspNonce;

		public static readonly DerObjectIdentifier PkixOcspCrl;

		public static readonly DerObjectIdentifier PkixOcspResponse;

		public static readonly DerObjectIdentifier PkixOcspNocheck;

		public static readonly DerObjectIdentifier PkixOcspArchiveCutoff;

		public static readonly DerObjectIdentifier PkixOcspServiceLocator;
	}
}
