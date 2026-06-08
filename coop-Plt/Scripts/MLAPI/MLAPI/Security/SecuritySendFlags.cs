using System;

namespace MLAPI.Security
{
	[Flags]
	public enum SecuritySendFlags
	{
		None = 0,
		Encrypted = 1,
		Authenticated = 2
	}
}
