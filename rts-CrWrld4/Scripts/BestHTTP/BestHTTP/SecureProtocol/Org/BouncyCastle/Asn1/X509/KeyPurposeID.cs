namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public sealed class KeyPurposeID : DerObjectIdentifier
	{
		private const string IdKP = "1.3.6.1.5.5.7.3";

		public static readonly KeyPurposeID AnyExtendedKeyUsage;

		public static readonly KeyPurposeID IdKPServerAuth;

		public static readonly KeyPurposeID IdKPClientAuth;

		public static readonly KeyPurposeID IdKPCodeSigning;

		public static readonly KeyPurposeID IdKPEmailProtection;

		public static readonly KeyPurposeID IdKPIpsecEndSystem;

		public static readonly KeyPurposeID IdKPIpsecTunnel;

		public static readonly KeyPurposeID IdKPIpsecUser;

		public static readonly KeyPurposeID IdKPTimeStamping;

		public static readonly KeyPurposeID IdKPOcspSigning;

		public static readonly KeyPurposeID IdKPSmartCardLogon;

		public static readonly KeyPurposeID IdKPMacAddress;

		private KeyPurposeID(string id)
			: base((string)null)
		{
		}
	}
}
