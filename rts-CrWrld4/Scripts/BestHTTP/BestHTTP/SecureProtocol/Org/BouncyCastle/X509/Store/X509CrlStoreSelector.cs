using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Date;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store
{
	public class X509CrlStoreSelector : IX509Selector, ICloneable
	{
		private X509Certificate certificateChecking;

		private DateTimeObject dateAndTime;

		private ICollection issuers;

		private BigInteger maxCrlNumber;

		private BigInteger minCrlNumber;

		private IX509AttributeCertificate attrCertChecking;

		private bool completeCrlEnabled;

		private bool deltaCrlIndicatorEnabled;

		private byte[] issuingDistributionPoint;

		private bool issuingDistributionPointEnabled;

		private BigInteger maxBaseCrlNumber;

		public X509Certificate CertificateChecking
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DateTimeObject DateAndTime
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ICollection Issuers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BigInteger MaxCrlNumber
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BigInteger MinCrlNumber
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IX509AttributeCertificate AttrCertChecking
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool CompleteCrlEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DeltaCrlIndicatorEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public byte[] IssuingDistributionPoint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IssuingDistributionPointEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public BigInteger MaxBaseCrlNumber
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public X509CrlStoreSelector()
		{
		}

		public X509CrlStoreSelector(X509CrlStoreSelector o)
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
	}
}
