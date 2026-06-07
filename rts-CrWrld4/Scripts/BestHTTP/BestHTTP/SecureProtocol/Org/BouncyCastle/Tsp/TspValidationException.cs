using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Tsp
{
	[Serializable]
	public class TspValidationException : TspException
	{
		private int failureCode;

		public int FailureCode => 0;

		public TspValidationException(string message)
		{
		}

		public TspValidationException(string message, int failureCode)
		{
		}
	}
}
