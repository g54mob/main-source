using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class KeyTransRecipientInformation : RecipientInformation
	{
		private KeyTransRecipientInfo info;

		internal KeyTransRecipientInformation(KeyTransRecipientInfo info, CmsSecureReadable secureReadable)
			: base(null, null)
		{
		}

		private string GetExchangeEncryptionAlgorithmName(AlgorithmIdentifier algo)
		{
			return null;
		}

		internal KeyParameter UnwrapKey(ICipherParameters key)
		{
			return null;
		}

		public override CmsTypedStream GetContentStream(ICipherParameters key)
		{
			return null;
		}
	}
}
