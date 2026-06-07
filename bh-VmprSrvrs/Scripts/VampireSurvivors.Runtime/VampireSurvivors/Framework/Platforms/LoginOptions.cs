using System;

namespace VampireSurvivors.Framework.Platforms
{
	[Flags]
	public enum LoginOptions
	{
		PlatformDefault = 0,
		TrySilent = 1,
		AllowGuest = 2,
		ForceAccountPicker = 4,
		RequireOnlineAccount = 8
	}
}
