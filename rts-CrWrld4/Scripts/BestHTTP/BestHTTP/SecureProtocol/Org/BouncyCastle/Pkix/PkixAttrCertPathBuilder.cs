using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class PkixAttrCertPathBuilder
	{
		private Exception certPathException;

		public virtual PkixCertPathBuilderResult Build(PkixBuilderParameters pkixParams)
		{
			return null;
		}

		private PkixCertPathBuilderResult Build(IX509AttributeCertificate attrCert, X509Certificate tbvCert, PkixBuilderParameters pkixParams, IList tbvPath)
		{
			return null;
		}
	}
}
