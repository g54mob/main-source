using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class OcspIdentifier : Asn1Encodable
	{
		private readonly ResponderID ocspResponderID;

		private readonly DerGeneralizedTime producedAt;

		public ResponderID OcspResponderID => null;

		public DateTime ProducedAt => default(DateTime);

		public static OcspIdentifier GetInstance(object obj)
		{
			return null;
		}

		private OcspIdentifier(Asn1Sequence seq)
		{
		}

		public OcspIdentifier(ResponderID ocspResponderID, DateTime producedAt)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
