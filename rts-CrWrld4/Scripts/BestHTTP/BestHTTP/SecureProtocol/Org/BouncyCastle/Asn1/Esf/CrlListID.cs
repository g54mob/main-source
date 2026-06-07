using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class CrlListID : Asn1Encodable
	{
		private readonly Asn1Sequence crls;

		public static CrlListID GetInstance(object obj)
		{
			return null;
		}

		private CrlListID(Asn1Sequence seq)
		{
		}

		public CrlListID(params CrlValidatedID[] crls)
		{
		}

		public CrlListID(IEnumerable crls)
		{
		}

		public CrlValidatedID[] GetCrls()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
