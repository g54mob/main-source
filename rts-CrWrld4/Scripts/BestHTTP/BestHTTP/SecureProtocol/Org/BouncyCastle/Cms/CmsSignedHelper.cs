using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	internal class CmsSignedHelper
	{
		internal static readonly CmsSignedHelper Instance;

		private static readonly string EncryptionECDsaWithSha1;

		private static readonly string EncryptionECDsaWithSha224;

		private static readonly string EncryptionECDsaWithSha256;

		private static readonly string EncryptionECDsaWithSha384;

		private static readonly string EncryptionECDsaWithSha512;

		private static readonly IDictionary encryptionAlgs;

		private static readonly IDictionary digestAlgs;

		private static readonly IDictionary digestAliases;

		private static readonly ISet noParams;

		private static readonly IDictionary ecAlgorithms;

		private static void AddEntries(DerObjectIdentifier oid, string digest, string encryption)
		{
		}

		static CmsSignedHelper()
		{
		}

		internal string GetDigestAlgName(string digestAlgOid)
		{
			return null;
		}

		internal AlgorithmIdentifier GetEncAlgorithmIdentifier(DerObjectIdentifier encOid, Asn1Encodable sigX509Parameters)
		{
			return null;
		}

		internal string[] GetDigestAliases(string algName)
		{
			return null;
		}

		internal string GetEncryptionAlgName(string encryptionAlgOid)
		{
			return null;
		}

		internal IDigest GetDigestInstance(string algorithm)
		{
			return null;
		}

		internal ISigner GetSignatureInstance(string algorithm)
		{
			return null;
		}

		internal IX509Store CreateAttributeStore(string type, Asn1Set certSet)
		{
			return null;
		}

		internal IX509Store CreateCertificateStore(string type, Asn1Set certSet)
		{
			return null;
		}

		internal IX509Store CreateCrlStore(string type, Asn1Set crlSet)
		{
			return null;
		}

		private void AddCertsFromSet(IList certs, Asn1Set certSet)
		{
		}

		private void AddCrlsFromSet(IList crls, Asn1Set crlSet)
		{
		}

		internal AlgorithmIdentifier FixAlgID(AlgorithmIdentifier algId)
		{
			return null;
		}

		internal string GetEncOid(AsymmetricKeyParameter key, string digestOID)
		{
			return null;
		}
	}
}
