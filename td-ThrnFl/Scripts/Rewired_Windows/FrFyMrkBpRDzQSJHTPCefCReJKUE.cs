using System.Diagnostics;
using Rewired;

internal static class FrFyMrkBpRDzQSJHTPCefCReJKUE
{
	[Conditional("STEAM_DEBUG")]
	public static void fxoCBbdlcIyMEfJSnWmrSAQVRBOj(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.Log("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void kXFhbxYMznAOKdYmXpHXDTIFZbBH(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogWarning("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void biXfcTAvYNmFTbacuYaRHxAakRBZ(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogError("[STEAMDEBUG] " + P_0);
	}
}
