using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class NoticeReference : Asn1Encodable
	{
		private readonly DisplayText organization;

		private readonly Asn1Sequence noticeNumbers;

		public virtual DisplayText Organization => null;

		private static Asn1EncodableVector ConvertVector(IList numbers)
		{
			return null;
		}

		public NoticeReference(string organization, IList numbers)
		{
		}

		public NoticeReference(string organization, Asn1EncodableVector noticeNumbers)
		{
		}

		public NoticeReference(DisplayText organization, Asn1EncodableVector noticeNumbers)
		{
		}

		private NoticeReference(Asn1Sequence seq)
		{
		}

		public static NoticeReference GetInstance(object obj)
		{
			return null;
		}

		public virtual DerInteger[] GetNoticeNumbers()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
