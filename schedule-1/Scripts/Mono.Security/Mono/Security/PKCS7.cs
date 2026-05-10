using System.Collections;
using Mono.Security.X509;

namespace Mono.Security
{
	public sealed class PKCS7
	{
		public class ContentInfo
		{
			private string contentType;

			private ASN1 content;

			public ASN1 ASN1 => null;

			public ASN1 Content
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string ContentType
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public ContentInfo()
			{
			}

			public ContentInfo(string oid)
			{
			}

			public ContentInfo(byte[] data)
			{
			}

			public ContentInfo(ASN1 asn1)
			{
			}

			internal ASN1 GetASN1()
			{
				return null;
			}
		}

		public class EncryptedData
		{
			private byte _version;

			private ContentInfo _content;

			private ContentInfo _encryptionAlgorithm;

			private byte[] _encrypted;

			public ContentInfo EncryptionAlgorithm => null;

			public byte[] EncryptedContent => null;

			public EncryptedData()
			{
			}

			public EncryptedData(ASN1 asn1)
			{
			}
		}

		public class SignedData
		{
			private byte version;

			private string hashAlgorithm;

			private ContentInfo contentInfo;

			private X509CertificateCollection certs;

			private ArrayList crls;

			private SignerInfo signerInfo;

			private bool mda;

			public X509CertificateCollection Certificates => null;

			public ContentInfo ContentInfo => null;

			public string HashName
			{
				set
				{
				}
			}

			public SignerInfo SignerInfo => null;

			public SignedData(ASN1 asn1)
			{
			}

			internal string OidToName(string oid)
			{
				return null;
			}
		}

		public class SignerInfo
		{
			private byte version;

			private string hashAlgorithm;

			private ArrayList authenticatedAttributes;

			private ArrayList unauthenticatedAttributes;

			private byte[] signature;

			private string issuer;

			private byte[] serial;

			private byte[] ski;

			public string IssuerName => null;

			public byte[] SerialNumber => null;

			public ArrayList AuthenticatedAttributes => null;

			public string HashName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public byte[] Signature => null;

			public ArrayList UnauthenticatedAttributes => null;

			public byte Version => 0;

			public SignerInfo()
			{
			}

			public SignerInfo(ASN1 asn1)
			{
			}
		}
	}
}
