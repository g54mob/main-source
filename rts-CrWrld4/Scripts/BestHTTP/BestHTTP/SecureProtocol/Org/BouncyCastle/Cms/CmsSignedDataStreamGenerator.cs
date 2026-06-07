using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsSignedDataStreamGenerator : CmsSignedGenerator
	{
		private class DigestAndSignerInfoGeneratorHolder
		{
			internal readonly ISignerInfoGenerator signerInf;

			internal readonly string digestOID;

			internal AlgorithmIdentifier DigestAlgorithm => null;

			internal DigestAndSignerInfoGeneratorHolder(ISignerInfoGenerator signerInf, string digestOID)
			{
			}
		}

		private class SignerInfoGeneratorImpl : ISignerInfoGenerator
		{
			private readonly CmsSignedDataStreamGenerator outer;

			private readonly SignerIdentifier _signerIdentifier;

			private readonly string _digestOID;

			private readonly string _encOID;

			private readonly CmsAttributeTableGenerator _sAttr;

			private readonly CmsAttributeTableGenerator _unsAttr;

			private readonly string _encName;

			private readonly ISigner _sig;

			internal SignerInfoGeneratorImpl(CmsSignedDataStreamGenerator outer, AsymmetricKeyParameter key, SignerIdentifier signerIdentifier, string digestOID, string encOID, CmsAttributeTableGenerator sAttr, CmsAttributeTableGenerator unsAttr)
			{
			}

			public SignerInfo Generate(DerObjectIdentifier contentType, AlgorithmIdentifier digestAlgorithm, byte[] calculatedDigest)
			{
				return null;
			}
		}

		private class CmsSignedDataOutputStream : BaseOutputStream
		{
			private readonly CmsSignedDataStreamGenerator outer;

			private Stream _out;

			private DerObjectIdentifier _contentOID;

			private BerSequenceGenerator _sGen;

			private BerSequenceGenerator _sigGen;

			private BerSequenceGenerator _eiGen;

			public CmsSignedDataOutputStream(CmsSignedDataStreamGenerator outer, Stream outStream, string contentOID, BerSequenceGenerator sGen, BerSequenceGenerator sigGen, BerSequenceGenerator eiGen)
			{
			}

			public override void WriteByte(byte b)
			{
			}

			public override void Write(byte[] bytes, int off, int len)
			{
			}

			public override void Close()
			{
			}

			private void DoClose()
			{
			}

			private static void WriteToGenerator(Asn1Generator ag, Asn1Encodable ae)
			{
			}
		}

		private static readonly CmsSignedHelper Helper;

		private readonly IList _signerInfs;

		private readonly ISet _messageDigestOids;

		private readonly IDictionary _messageDigests;

		private readonly IDictionary _messageHashes;

		private bool _messageDigestsLocked;

		private int _bufferSize;

		public CmsSignedDataStreamGenerator()
		{
		}

		public CmsSignedDataStreamGenerator(SecureRandom rand)
		{
		}

		public void SetBufferSize(int bufferSize)
		{
		}

		public void AddDigests(params string[] digestOids)
		{
		}

		public void AddDigests(IEnumerable digestOids)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string digestOid)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string encryptionOid, string digestOid)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string digestOid, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string encryptionOid, string digestOid, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string digestOid, CmsAttributeTableGenerator signedAttrGenerator, CmsAttributeTableGenerator unsignedAttrGenerator)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string encryptionOid, string digestOid, CmsAttributeTableGenerator signedAttrGenerator, CmsAttributeTableGenerator unsignedAttrGenerator)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string digestOid)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string encryptionOid, string digestOid)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string digestOid, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string digestOid, CmsAttributeTableGenerator signedAttrGenerator, CmsAttributeTableGenerator unsignedAttrGenerator)
		{
		}

		public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string encryptionOid, string digestOid, CmsAttributeTableGenerator signedAttrGenerator, CmsAttributeTableGenerator unsignedAttrGenerator)
		{
		}

		private void DoAddSigner(AsymmetricKeyParameter privateKey, SignerIdentifier signerIdentifier, string encryptionOid, string digestOid, CmsAttributeTableGenerator signedAttrGenerator, CmsAttributeTableGenerator unsignedAttrGenerator)
		{
		}

		internal override void AddSignerCallback(SignerInformation si)
		{
		}

		public Stream Open(Stream outStream)
		{
			return null;
		}

		public Stream Open(Stream outStream, bool encapsulate)
		{
			return null;
		}

		public Stream Open(Stream outStream, bool encapsulate, Stream dataOutputStream)
		{
			return null;
		}

		public Stream Open(Stream outStream, string signedContentType, bool encapsulate)
		{
			return null;
		}

		public Stream Open(Stream outStream, string signedContentType, bool encapsulate, Stream dataOutputStream)
		{
			return null;
		}

		private void RegisterDigestOid(string digestOid)
		{
		}

		private void ConfigureDigest(string digestOid)
		{
		}

		internal void Generate(Stream outStream, string eContentType, bool encapsulate, Stream dataOutputStream, CmsProcessable content)
		{
		}

		private DerInteger CalculateVersion(DerObjectIdentifier contentOid)
		{
			return null;
		}

		private bool CheckForVersion3(IList signerInfos)
		{
			return false;
		}

		private static Stream AttachDigestsToOutputStream(ICollection digests, Stream s)
		{
			return null;
		}

		private static Stream GetSafeOutputStream(Stream s)
		{
			return null;
		}

		private static Stream GetSafeTeeOutputStream(Stream s1, Stream s2)
		{
			return null;
		}
	}
}
