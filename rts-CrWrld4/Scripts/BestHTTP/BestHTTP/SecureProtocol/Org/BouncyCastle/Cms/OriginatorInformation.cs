using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class OriginatorInformation
	{
		private readonly OriginatorInfo originatorInfo;

		internal OriginatorInformation(OriginatorInfo originatorInfo)
		{
		}

		public virtual IX509Store GetCertificates()
		{
			return null;
		}

		public virtual IX509Store GetCrls()
		{
			return null;
		}

		public virtual OriginatorInfo ToAsn1Structure()
		{
			return null;
		}
	}
}
