namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class UserNotice : Asn1Encodable
	{
		private readonly NoticeReference noticeRef;

		private readonly DisplayText explicitText;

		public virtual NoticeReference NoticeRef => null;

		public virtual DisplayText ExplicitText => null;

		public UserNotice(NoticeReference noticeRef, DisplayText explicitText)
		{
		}

		public UserNotice(NoticeReference noticeRef, string str)
		{
		}

		public UserNotice(Asn1Sequence seq)
		{
		}

		public static UserNotice GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
