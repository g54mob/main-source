using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class PkixCertPathBuilder
	{
		private Exception certPathException;

		public virtual PkixCertPathBuilderResult Build(PkixBuilderParameters pkixParams)
		{
			return null;
		}

		protected virtual PkixCertPathBuilderResult Build(X509Certificate tbvCert, PkixBuilderParameters pkixParams, IList tbvPath)
		{
			return null;
		}
	}
}
