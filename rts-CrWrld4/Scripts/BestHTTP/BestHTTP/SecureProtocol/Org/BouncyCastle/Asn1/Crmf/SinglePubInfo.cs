using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class SinglePubInfo : Asn1Encodable
	{
		private readonly DerInteger pubMethod;

		private readonly GeneralName pubLocation;

		public virtual GeneralName PubLocation => null;

		private SinglePubInfo(Asn1Sequence seq)
		{
		}

		public static SinglePubInfo GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
