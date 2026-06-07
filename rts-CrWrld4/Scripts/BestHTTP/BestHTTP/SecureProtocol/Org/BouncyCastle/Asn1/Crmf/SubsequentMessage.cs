namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class SubsequentMessage : DerInteger
	{
		public static readonly SubsequentMessage encrCert;

		public static readonly SubsequentMessage challengeResp;

		private SubsequentMessage(int value)
			: base(0)
		{
		}

		public static SubsequentMessage ValueOf(int value)
		{
			return null;
		}
	}
}
