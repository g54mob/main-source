using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class OcspStatusRequest
	{
		protected readonly IList mResponderIDList;

		protected readonly X509Extensions mRequestExtensions;

		public virtual IList ResponderIDList => null;

		public virtual X509Extensions RequestExtensions => null;

		public OcspStatusRequest(IList responderIDList, X509Extensions requestExtensions)
		{
		}

		public virtual void Encode(Stream output)
		{
		}

		public static OcspStatusRequest Parse(Stream input)
		{
			return null;
		}
	}
}
