using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class OcspListID : Asn1Encodable
	{
		private readonly Asn1Sequence ocspResponses;

		public static OcspListID GetInstance(object obj)
		{
			return null;
		}

		private OcspListID(Asn1Sequence seq)
		{
		}

		public OcspListID(params OcspResponsesID[] ocspResponses)
		{
		}

		public OcspListID(IEnumerable ocspResponses)
		{
		}

		public OcspResponsesID[] GetOcspResponses()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
