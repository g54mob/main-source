using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	internal class EnvelopedDataHelper
	{
		private static readonly IDictionary BaseCipherNames;

		private static readonly IDictionary MacAlgNames;

		static EnvelopedDataHelper()
		{
		}

		public static object CreateContentCipher(bool forEncryption, ICipherParameters encKey, AlgorithmIdentifier encryptionAlgID)
		{
			return null;
		}

		public AlgorithmIdentifier GenerateEncryptionAlgID(DerObjectIdentifier encryptionOID, KeyParameter encKey, SecureRandom random)
		{
			return null;
		}

		public CipherKeyGenerator CreateKeyGenerator(DerObjectIdentifier algorithm, SecureRandom random)
		{
			return null;
		}
	}
}
