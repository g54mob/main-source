using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsSignedDataParser : CmsContentInfoParser
	{
		private static readonly CmsSignedHelper Helper;

		private SignedDataParser _signedData;

		private DerObjectIdentifier _signedContentType;

		private CmsTypedStream _signedContent;

		private IDictionary _digests;

		private ISet _digestOids;

		private SignerInformationStore _signerInfoStore;

		private Asn1Set _certSet;

		private Asn1Set _crlSet;

		private bool _isCertCrlParsed;

		private IX509Store _attributeStore;

		private IX509Store _certificateStore;

		private IX509Store _crlStore;

		public int Version => 0;

		public ISet DigestOids => null;

		public DerObjectIdentifier SignedContentType => null;

		public CmsSignedDataParser(byte[] sigBlock)
			: base(null)
		{
		}

		public CmsSignedDataParser(CmsTypedStream signedContent, byte[] sigBlock)
			: base(null)
		{
		}

		public CmsSignedDataParser(Stream sigData)
			: base(null)
		{
		}

		public CmsSignedDataParser(CmsTypedStream signedContent, Stream sigData)
			: base(null)
		{
		}

		public SignerInformationStore GetSignerInfos()
		{
			return null;
		}

		public IX509Store GetAttributeCertificates(string type)
		{
			return null;
		}

		public IX509Store GetCertificates(string type)
		{
			return null;
		}

		public IX509Store GetCrls(string type)
		{
			return null;
		}

		private void PopulateCertCrlSets()
		{
		}

		public CmsTypedStream GetSignedContent()
		{
			return null;
		}

		public static Stream ReplaceSigners(Stream original, SignerInformationStore signerInformationStore, Stream outStr)
		{
			return null;
		}

		public static Stream ReplaceCertificatesAndCrls(Stream original, IX509Store x509Certs, IX509Store x509Crls, IX509Store x509AttrCerts, Stream outStr)
		{
			return null;
		}

		private static Asn1Set GetAsn1Set(Asn1SetParser asn1SetParser)
		{
			return null;
		}
	}
}
