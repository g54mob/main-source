namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class ErrorMsgContent : Asn1Encodable
	{
		private readonly PkiStatusInfo pkiStatusInfo;

		private readonly DerInteger errorCode;

		private readonly PkiFreeText errorDetails;

		public virtual PkiStatusInfo PkiStatusInfo => null;

		public virtual DerInteger ErrorCode => null;

		public virtual PkiFreeText ErrorDetails => null;

		private ErrorMsgContent(Asn1Sequence seq)
		{
		}

		public static ErrorMsgContent GetInstance(object obj)
		{
			return null;
		}

		public ErrorMsgContent(PkiStatusInfo pkiStatusInfo)
		{
		}

		public ErrorMsgContent(PkiStatusInfo pkiStatusInfo, DerInteger errorCode, PkiFreeText errorDetails)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
