using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class RevocationValues : Asn1Encodable
	{
		private readonly Asn1Sequence crlVals;

		private readonly Asn1Sequence ocspVals;

		private readonly OtherRevVals otherRevVals;

		public OtherRevVals OtherRevVals => null;

		public static RevocationValues GetInstance(object obj)
		{
			return null;
		}

		private RevocationValues(Asn1Sequence seq)
		{
		}

		public RevocationValues(CertificateList[] crlVals, BasicOcspResponse[] ocspVals, OtherRevVals otherRevVals)
		{
		}

		public RevocationValues(IEnumerable crlVals, IEnumerable ocspVals, OtherRevVals otherRevVals)
		{
		}

		public CertificateList[] GetCrlVals()
		{
			return null;
		}

		public BasicOcspResponse[] GetOcspVals()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
