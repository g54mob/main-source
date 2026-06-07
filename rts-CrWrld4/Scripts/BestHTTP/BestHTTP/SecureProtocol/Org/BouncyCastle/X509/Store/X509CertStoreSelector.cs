using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Date;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store
{
	public class X509CertStoreSelector : IX509Selector, ICloneable
	{
		private byte[] authorityKeyIdentifier;

		private int basicConstraints;

		private X509Certificate certificate;

		private DateTimeObject certificateValid;

		private ISet extendedKeyUsage;

		private bool ignoreX509NameOrdering;

		private X509Name issuer;

		private bool[] keyUsage;

		private ISet policy;

		private DateTimeObject privateKeyValid;

		private BigInteger serialNumber;

		private X509Name subject;

		private byte[] subjectKeyIdentifier;

		private SubjectPublicKeyInfo subjectPublicKey;

		private DerObjectIdentifier subjectPublicKeyAlgID;

		public byte[] AuthorityKeyIdentifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int BasicConstraints
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public X509Certificate Certificate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DateTimeObject CertificateValid
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ISet ExtendedKeyUsage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IgnoreX509NameOrdering
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public X509Name Issuer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string IssuerAsString => null;

		public bool[] KeyUsage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ISet Policy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DateTimeObject PrivateKeyValid
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BigInteger SerialNumber
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public X509Name Subject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SubjectAsString => null;

		public byte[] SubjectKeyIdentifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SubjectPublicKeyInfo SubjectPublicKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DerObjectIdentifier SubjectPublicKeyAlgID
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public X509CertStoreSelector()
		{
		}

		public X509CertStoreSelector(X509CertStoreSelector o)
		{
		}

		public virtual object Clone()
		{
			return null;
		}

		public virtual bool Match(object obj)
		{
			return false;
		}

		internal static bool IssuersMatch(X509Name a, X509Name b)
		{
			return false;
		}

		private static bool[] CopyBoolArray(bool[] b)
		{
			return null;
		}

		private static ISet CopySet(ISet s)
		{
			return null;
		}

		private static SubjectPublicKeyInfo GetSubjectPublicKey(X509Certificate c)
		{
			return null;
		}

		private static bool MatchExtension(byte[] b, X509Certificate c, DerObjectIdentifier oid)
		{
			return false;
		}
	}
}
