using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsSignedGenerator
	{
		public static readonly string Data;

		public static readonly string DigestSha1;

		public static readonly string DigestSha224;

		public static readonly string DigestSha256;

		public static readonly string DigestSha384;

		public static readonly string DigestSha512;

		public static readonly string DigestMD5;

		public static readonly string DigestGost3411;

		public static readonly string DigestRipeMD128;

		public static readonly string DigestRipeMD160;

		public static readonly string DigestRipeMD256;

		public static readonly string EncryptionRsa;

		public static readonly string EncryptionDsa;

		public static readonly string EncryptionECDsa;

		public static readonly string EncryptionRsaPss;

		public static readonly string EncryptionGost3410;

		public static readonly string EncryptionECGost3410;

		internal IList _certs;

		internal IList _crls;

		internal IList _signers;

		internal IDictionary _digests;

		internal bool _useDerForCerts;

		internal bool _useDerForCrls;

		protected readonly SecureRandom rand;

		public bool UseDerForCerts
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseDerForCrls
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected CmsSignedGenerator()
		{
		}

		protected CmsSignedGenerator(SecureRandom rand)
		{
		}

		protected internal virtual IDictionary GetBaseParameters(DerObjectIdentifier contentType, AlgorithmIdentifier digAlgId, byte[] hash)
		{
			return null;
		}

		protected internal virtual Asn1Set GetAttributeSet(BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable attr)
		{
			return null;
		}

		public void AddCertificates(IX509Store certStore)
		{
		}

		public void AddCrls(IX509Store crlStore)
		{
		}

		public void AddAttributeCertificates(IX509Store store)
		{
		}

		public void AddSigners(SignerInformationStore signerStore)
		{
		}

		public IDictionary GetGeneratedDigests()
		{
			return null;
		}

		internal virtual void AddSignerCallback(SignerInformation si)
		{
		}

		internal static SignerIdentifier GetSignerIdentifier(X509Certificate cert)
		{
			return null;
		}

		internal static SignerIdentifier GetSignerIdentifier(byte[] subjectKeyIdentifier)
		{
			return null;
		}
	}
}
