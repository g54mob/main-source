using System;
using System.Diagnostics;
using Amazon.Runtime.Identity;

namespace Amazon.Runtime
{
	[DebuggerDisplay("{Token}")]
	public class AWSToken : BaseIdentity
	{
		public string Token { get; set; }

		[Obsolete("This property is deprecated in favor of Expiration.")]
		public DateTime? ExpiresAt
		{
			get
			{
				return Expiration;
			}
			set
			{
				Expiration = value;
			}
		}

		public override DateTime? Expiration { get; set; }

		public override string ToString()
		{
			return Token;
		}
	}
}
