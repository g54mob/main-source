using System.Diagnostics;
using UnityEngine;

namespace Aggro.Core
{
	public static class PoolDebug
	{
		[Conditional("ENABLE_POOL_LOGGING")]
		internal static void Log(string msg)
		{
			UnityEngine.Debug.Log("[PREFAB POOL] " + msg);
		}

		[Conditional("ENABLE_POOL_LOGGING")]
		internal static void Log(string msg, Object obj)
		{
			UnityEngine.Debug.Log("[PREFAB POOL] " + msg, obj);
		}
	}
}
