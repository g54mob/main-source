using System.Diagnostics;
using Rewired;

internal static class PkKUKnPMAUEagAjKWPegHbKIFKbHA
{
	[Conditional("STEAM_DEBUG")]
	public static void rHzoylUolHnLyncTmcxraiMbOQrYA(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.Log("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void mEECVtbeokyrcrIrWyQXrVQtsIsn(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogWarning("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void xuMCDdYXCAwhholonVCRVYKMGhcd(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogError("[STEAMDEBUG] " + P_0);
	}
}
