using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	internal class CmsEnvelopedHelper
	{
		internal class CmsAuthenticatedSecureReadable : CmsSecureReadable
		{
			private AlgorithmIdentifier algorithm;

			private IMac mac;

			private CmsReadable readable;

			public AlgorithmIdentifier Algorithm => null;

			public object CryptoObject => null;

			internal CmsAuthenticatedSecureReadable(AlgorithmIdentifier algorithm, CmsReadable readable)
			{
			}

			public CmsReadable GetReadable(KeyParameter sKey)
			{
				return null;
			}
		}

		internal class CmsEnvelopedSecureReadable : CmsSecureReadable
		{
			private AlgorithmIdentifier algorithm;

			private IBufferedCipher cipher;

			private CmsReadable readable;

			public AlgorithmIdentifier Algorithm => null;

			public object CryptoObject => null;

			internal CmsEnvelopedSecureReadable(AlgorithmIdentifier algorithm, CmsReadable readable)
			{
			}

			public CmsReadable GetReadable(KeyParameter sKey)
			{
				return null;
			}
		}

		internal static readonly CmsEnvelopedHelper Instance;

		private static readonly IDictionary KeySizes;

		private static readonly IDictionary BaseCipherNames;

		static CmsEnvelopedHelper()
		{
		}

		private string GetAsymmetricEncryptionAlgName(string encryptionAlgOid)
		{
			return null;
		}

		internal IBufferedCipher CreateAsymmetricCipher(string encryptionOid)
		{
			return null;
		}

		internal IWrapper CreateWrapper(string encryptionOid)
		{
			return null;
		}

		internal string GetRfc3211WrapperName(string oid)
		{
			return null;
		}

		internal int GetKeySize(string oid)
		{
			return 0;
		}

		internal static RecipientInformationStore BuildRecipientInformationStore(Asn1Set recipientInfos, CmsSecureReadable secureReadable)
		{
			return null;
		}

		private static void ReadRecipientInfo(IList infos, RecipientInfo info, CmsSecureReadable secureReadable)
		{
		}
	}
}
