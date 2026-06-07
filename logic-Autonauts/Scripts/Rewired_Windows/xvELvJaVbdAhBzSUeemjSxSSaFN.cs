using System.Diagnostics;
using Rewired;

internal static class xvELvJaVbdAhBzSUeemjSxSSaFN
{
	[Conditional("STEAM_DEBUG")]
	public static void WVvBHUYMFZhLlcBqqnAkrSEoSLLL(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.Log("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void iNiXrGFJSeHvZLpBMxhbCoJaeHI(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogWarning("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void ZbfYERPziVDcQivnSxtmYXVpcjW(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogError("[STEAMDEBUG] " + P_0);
	}
}
