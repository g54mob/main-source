using System;

namespace FuryStudios.FurySDK
{
	[Flags]
	public enum SignInOptions
	{
		None = 0,
		TrySilent = 1,
		AllowGuests = 2
	}
}
