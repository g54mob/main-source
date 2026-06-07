using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class KekRecipientInformation : RecipientInformation
	{
		private KekRecipientInfo info;

		internal KekRecipientInformation(KekRecipientInfo info, CmsSecureReadable secureReadable)
			: base(null, null)
		{
		}

		public override CmsTypedStream GetContentStream(ICipherParameters key)
		{
			return null;
		}
	}
}
