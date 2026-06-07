using System;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Mirror
{
	internal static class NetworkLoop
	{
		internal enum AddMode
		{
			Beginning = 0,
			End = 1
		}

		internal static int FindPlayerLoopEntryIndex(PlayerLoopSystem.UpdateFunction function, PlayerLoopSystem playerLoop, Type playerLoopSystemType)
		{
			return 0;
		}

		internal static bool AddToPlayerLoop(PlayerLoopSystem.UpdateFunction function, Type ownerType, ref PlayerLoopSystem playerLoop, Type playerLoopSystemType, AddMode addMode)
		{
			return false;
		}

		[RuntimeInitializeOnLoadMethod]
		private static void RuntimeInitializeOnLoad()
		{
		}

		private static void NetworkEarlyUpdate()
		{
		}

		private static void NetworkLateUpdate()
		{
		}
	}
}
