using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Operators
{
	public class CmsKeyTransRecipientInfoGenerator : KeyTransRecipientInfoGenerator
	{
		private readonly IKeyWrapper keyWrapper;

		protected override AlgorithmIdentifier AlgorithmDetails => null;

		public CmsKeyTransRecipientInfoGenerator(X509Certificate recipCert, IKeyWrapper keyWrapper)
		{
		}

		public CmsKeyTransRecipientInfoGenerator(byte[] subjectKeyID, IKeyWrapper keyWrapper)
		{
		}

		protected override byte[] GenerateWrappedKey(KeyParameter contentKey)
		{
			return null;
		}
	}
}
