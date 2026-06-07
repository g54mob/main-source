using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store
{
	public class X509CertPairStoreSelector : IX509Selector, ICloneable
	{
		private X509CertificatePair certPair;

		private X509CertStoreSelector forwardSelector;

		private X509CertStoreSelector reverseSelector;

		public X509CertificatePair CertPair
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public X509CertStoreSelector ForwardSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public X509CertStoreSelector ReverseSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private static X509CertStoreSelector CloneSelector(X509CertStoreSelector s)
		{
			return null;
		}

		public X509CertPairStoreSelector()
		{
		}

		private X509CertPairStoreSelector(X509CertPairStoreSelector o)
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
	}
}
