using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class SingleResponse : Asn1Encodable
	{
		private readonly CertID certID;

		private readonly CertStatus certStatus;

		private readonly DerGeneralizedTime thisUpdate;

		private readonly DerGeneralizedTime nextUpdate;

		private readonly X509Extensions singleExtensions;

		public CertID CertId => null;

		public CertStatus CertStatus => null;

		public DerGeneralizedTime ThisUpdate => null;

		public DerGeneralizedTime NextUpdate => null;

		public X509Extensions SingleExtensions => null;

		public SingleResponse(CertID certID, CertStatus certStatus, DerGeneralizedTime thisUpdate, DerGeneralizedTime nextUpdate, X509Extensions singleExtensions)
		{
		}

		public SingleResponse(Asn1Sequence seq)
		{
		}

		public static SingleResponse GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static SingleResponse GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
