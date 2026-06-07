using System.Diagnostics;
using Rewired;

internal static class RRQryEaeDcDWpGqfHwVWlLMMjoyg
{
	[Conditional("STEAM_DEBUG")]
	public static void oSrzFJGZfUCPHuNPLENPheEyWsoK(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.Log("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void YMqtZBVekxoghscazbzQepLolYjUA(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogWarning("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void lLdgPYZrAEOlmLFYtxnVnzXbjavJ(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogError("[STEAMDEBUG] " + P_0);
	}
}
