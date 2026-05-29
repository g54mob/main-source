using System.Diagnostics;
using Rewired;

internal static class aqmVnJdMRaREoESfdfdcFHMNAOG
{
	[Conditional("XBOXONE_DEBUG")]
	public static void zsGBKYkpPoIfFUZODmNcqvxUrZf(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
			goto IL_000a;
		}
		goto IL_0028;
		IL_0028:
		Logger.Log("[XBOXONE_DEBUG] " + P_0);
		int num = 873105154;
		goto IL_000f;
		IL_000a:
		num = 873105153;
		goto IL_000f;
		IL_000f:
		switch (num ^ 0x340A8703)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			goto IL_0028;
		case 1:
			return;
		}
		goto IL_000a;
	}

	[Conditional("XBOXONE_DEBUG")]
	public static void RCZibCynKPLrxFCdbwNthFcOGVg(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogWarning("[XBOXONE_DEBUG] " + P_0);
	}

	[Conditional("XBOXONE_DEBUG")]
	public static void ulMVJFuaskRxmuaThruwjmsPwkk(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogError("[XBOXONE_DEBUG] " + P_0);
	}
}
