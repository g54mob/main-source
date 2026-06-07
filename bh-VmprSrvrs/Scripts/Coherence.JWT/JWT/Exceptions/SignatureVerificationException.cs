using System;

namespace JWT.Exceptions
{
	public class SignatureVerificationException : Exception
	{
		private const string ExpectedKey = "Expected";

		private const string ReceivedKey = "Received";

		public string Expected
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string Received
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public SignatureVerificationException(string message)
		{
		}

		public SignatureVerificationException(string decodedCrypto, params string[] decodedSignatures)
		{
		}

		protected T GetOrDefault<T>(string key)
		{
			return default(T);
		}
	}
}
