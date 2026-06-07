using System;
using System.Collections.Generic;

namespace JWT.Exceptions
{
	public class TokenExpiredException : SignatureVerificationException
	{
		private const string PayloadDataKey = "PayloadData";

		private const string ExpirationKey = "Expiration";

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

		public DateTime? Expiration
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public TokenExpiredException(string message)
			: base(null)
		{
		}
	}
}
