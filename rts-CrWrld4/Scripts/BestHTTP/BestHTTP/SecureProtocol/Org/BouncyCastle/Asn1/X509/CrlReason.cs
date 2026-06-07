namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class CrlReason : DerEnumerated
	{
		public const int Unspecified = 0;

		public const int KeyCompromise = 1;

		public const int CACompromise = 2;

		public const int AffiliationChanged = 3;

		public const int Superseded = 4;

		public const int CessationOfOperation = 5;

		public const int CertificateHold = 6;

		public const int RemoveFromCrl = 8;

		public const int PrivilegeWithdrawn = 9;

		public const int AACompromise = 10;

		private static readonly string[] ReasonString;

		public CrlReason(int reason)
			: base(0)
		{
		}

		public CrlReason(DerEnumerated reason)
			: base(0)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
