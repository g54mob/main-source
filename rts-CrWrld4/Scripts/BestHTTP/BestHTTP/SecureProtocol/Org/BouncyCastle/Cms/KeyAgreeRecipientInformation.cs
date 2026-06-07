using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class KeyAgreeRecipientInformation : RecipientInformation
	{
		private KeyAgreeRecipientInfo info;

		private Asn1OctetString encryptedKey;

		internal static void ReadRecipientInfo(IList infos, KeyAgreeRecipientInfo info, CmsSecureReadable secureReadable)
		{
		}

		internal KeyAgreeRecipientInformation(KeyAgreeRecipientInfo info, RecipientID rid, Asn1OctetString encryptedKey, CmsSecureReadable secureReadable)
			: base(null, null)
		{
		}

		private AsymmetricKeyParameter GetSenderPublicKey(AsymmetricKeyParameter receiverPrivateKey, OriginatorIdentifierOrKey originator)
		{
			return null;
		}

		private AsymmetricKeyParameter GetPublicKeyFromOriginatorPublicKey(AsymmetricKeyParameter receiverPrivateKey, OriginatorPublicKey originatorPublicKey)
		{
			return null;
		}

		private AsymmetricKeyParameter GetPublicKeyFromOriginatorID(OriginatorID origID)
		{
			return null;
		}

		private KeyParameter CalculateAgreedWrapKey(string wrapAlg, AsymmetricKeyParameter senderPublicKey, AsymmetricKeyParameter receiverPrivateKey)
		{
			return null;
		}

		private KeyParameter UnwrapSessionKey(string wrapAlg, KeyParameter agreedKey)
		{
			return null;
		}

		internal KeyParameter GetSessionKey(AsymmetricKeyParameter receiverPrivateKey)
		{
			return null;
		}

		public override CmsTypedStream GetContentStream(ICipherParameters key)
		{
			return null;
		}
	}
}
