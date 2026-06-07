using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Tsp
{
	public class TimeStampResp : Asn1Encodable
	{
		private readonly PkiStatusInfo pkiStatusInfo;

		private readonly ContentInfo timeStampToken;

		public PkiStatusInfo Status => null;

		public ContentInfo TimeStampToken => null;

		public static TimeStampResp GetInstance(object obj)
		{
			return null;
		}

		private TimeStampResp(Asn1Sequence seq)
		{
		}

		public TimeStampResp(PkiStatusInfo pkiStatusInfo, ContentInfo timeStampToken)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
