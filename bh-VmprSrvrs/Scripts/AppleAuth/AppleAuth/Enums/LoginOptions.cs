using System;

namespace AppleAuth.Enums
{
	[Flags]
	public enum LoginOptions
	{
		None = 0,
		IncludeFullName = 1,
		IncludeEmail = 2
	}
}
