using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Date;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store
{
	public class X509AttrCertStoreSelector : IX509Selector, ICloneable
	{
		private IX509AttributeCertificate attributeCert;

		private DateTimeObject attributeCertificateValid;

		private AttributeCertificateHolder holder;

		private AttributeCertificateIssuer issuer;

		private BigInteger serialNumber;

		private ISet targetNames;

		private ISet targetGroups;

		public IX509AttributeCertificate AttributeCert
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DateTimeObject AttribueCertificateValid
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DateTimeObject AttributeCertificateValid
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AttributeCertificateHolder Holder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AttributeCertificateIssuer Issuer
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

		public X509AttrCertStoreSelector()
		{
		}

		private X509AttrCertStoreSelector(X509AttrCertStoreSelector o)
		{
		}

		public bool Match(object obj)
		{
			return false;
		}

		public object Clone()
		{
			return null;
		}

		public void AddTargetName(GeneralName name)
		{
		}

		public void AddTargetName(byte[] name)
		{
		}

		public void SetTargetNames(IEnumerable names)
		{
		}

		public IEnumerable GetTargetNames()
		{
			return null;
		}

		public void AddTargetGroup(GeneralName group)
		{
		}

		public void AddTargetGroup(byte[] name)
		{
		}

		public void SetTargetGroups(IEnumerable names)
		{
		}

		public IEnumerable GetTargetGroups()
		{
			return null;
		}

		private ISet ExtractGeneralNames(IEnumerable names)
		{
			return null;
		}
	}
}
