using System;

namespace Amazon.Runtime.Identity
{
	public abstract class BaseIdentity
	{
		public virtual DateTime? Expiration { get; set; }
	}
}
