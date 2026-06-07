using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class CompleteRevocationRefs : Asn1Encodable
	{
		private readonly Asn1Sequence crlOcspRefs;

		public static CompleteRevocationRefs GetInstance(object obj)
		{
			return null;
		}

		private CompleteRevocationRefs(Asn1Sequence seq)
		{
		}

		public CompleteRevocationRefs(params CrlOcspRef[] crlOcspRefs)
		{
		}

		public CompleteRevocationRefs(IEnumerable crlOcspRefs)
		{
		}

		public CrlOcspRef[] GetCrlOcspRefs()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
