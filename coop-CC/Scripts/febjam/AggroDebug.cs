using System.Diagnostics;
using UnityEngine;

public static class AggroDebug
{
	[Conditional("ENABLE_QUOTA_LOGGING")]
	public static void LogQuota(string msg, Object context = null)
	{
		UnityEngine.Debug.Log("[QUOTA] " + msg, context);
	}

	[Conditional("ENABLE_QUOTA_LOGGING")]
	public static void LogQuotaWarning(string msg, Object context = null)
	{
		UnityEngine.Debug.LogWarning("[QUOTA] " + msg, context);
	}
}
