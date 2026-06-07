using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	[Serializable]
	public class PkixCertPathValidatorException : GeneralSecurityException
	{
		private Exception cause;

		private PkixCertPath certPath;

		private int index;

		public override string Message => null;

		public PkixCertPath CertPath => null;

		public int Index => 0;

		public PkixCertPathValidatorException()
		{
		}

		public PkixCertPathValidatorException(string message)
		{
		}

		public PkixCertPathValidatorException(string message, Exception cause)
		{
		}

		public PkixCertPathValidatorException(string message, Exception cause, PkixCertPath certPath, int index)
		{
		}
	}
}
