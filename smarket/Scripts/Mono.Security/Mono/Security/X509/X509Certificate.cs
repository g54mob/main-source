using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace Mono.Security.X509
{
	public class X509Certificate : ISerializable
	{
		private ASN1 decoder;

		private byte[] m_encodedcert;

		private DateTime m_from;

		private DateTime m_until;

		private ASN1 issuer;

		private string m_issuername;

		private string m_keyalgo;

		private byte[] m_keyalgoparams;

		private ASN1 subject;

		private string m_subject;

		private byte[] m_publickey;

		private byte[] signature;

		private string m_signaturealgo;

		private byte[] m_signaturealgoparams;

		private byte[] certhash;

		private RSA _rsa;

		private DSA _dsa;

		private int version;

		private byte[] serialnumber;

		private byte[] issuerUniqueID;

		private byte[] subjectUniqueID;

		private X509ExtensionCollection extensions;

		private static string encoding_error;

		public DSA DSA
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public X509ExtensionCollection Extensions => null;

		public byte[] Hash => null;

		public virtual string IssuerName => null;

		public virtual string KeyAlgorithm => null;

		public virtual byte[] KeyAlgorithmParameters
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual byte[] PublicKey => null;

		public virtual RSA RSA
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual byte[] RawData => null;

		public virtual byte[] SerialNumber => null;

		public virtual byte[] Signature => null;

		public virtual string SubjectName => null;

		public virtual DateTime ValidFrom => default(DateTime);

		public virtual DateTime ValidUntil => default(DateTime);

		public int Version => 0;

		public bool IsCurrent => false;

		public bool IsSelfSigned => false;

		private void Parse(byte[] data)
		{
		}

		public X509Certificate(byte[] data)
		{
		}

		private byte[] GetUnsignedBigInteger(byte[] integer)
		{
			return null;
		}

		public bool WasCurrent(DateTime instant)
		{
			return false;
		}

		internal bool VerifySignature(DSA dsa)
		{
			return false;
		}

		internal bool VerifySignature(RSA rsa)
		{
			return false;
		}

		public bool VerifySignature(AsymmetricAlgorithm aa)
		{
			return false;
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		private static byte[] PEM(string type, byte[] data)
		{
			return null;
		}
	}
}
