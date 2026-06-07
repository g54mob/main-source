using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class PolicyMappings : Asn1Encodable
	{
		private readonly Asn1Sequence seq;

		public PolicyMappings(Asn1Sequence seq)
		{
		}

		public PolicyMappings(Hashtable mappings)
		{
		}

		public PolicyMappings(IDictionary mappings)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
