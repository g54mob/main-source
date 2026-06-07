using System;
using System.Collections.Generic;

namespace JWT.Exceptions
{
	public class TokenNotYetValidException : SignatureVerificationException
	{
		private const string PayloadDataKey = "PayloadData";

		private const string NotBeforeKey = "NotBefore";

		public IReadOnlyDictionary<string, object> PayloadData
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public DateTime? NotBefore
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public TokenNotYetValidException(string message)
			: base(null)
		{
		}
	}
}
