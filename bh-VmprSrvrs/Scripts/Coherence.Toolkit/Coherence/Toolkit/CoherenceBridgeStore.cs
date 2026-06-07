using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Cloud;
using Coherence.Log;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	public static class CoherenceBridgeStore
	{
		internal static readonly Dictionary<int, CoherenceBridge> bridges;

		internal static ICoherenceBridge instantiatingBridge;

		private static CoherenceBridge masterBridge;

		private static readonly Coherence.Log.Logger logger;

		public static CoherenceBridge MasterBridge => null;

		public static event CoherenceBridgeResolver<MonoBehaviour> BridgeResolve
		{
			add
			{
			}
			remove
			{
			}
		}

		private static event CoherenceBridgeResolver<MonoBehaviour> bridgeResolve
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetBridgeStore()
		{
		}

		internal static void RegisterBridge(CoherenceBridge bridge, int id, bool isMaster)
		{
		}

		internal static void RegisterBridge(CoherenceBridge bridge, Scene scene, bool isMaster)
		{
		}

		internal static void DeregisterBridge(int id)
		{
		}

		internal static void DeregisterBridge(CoherenceBridge bridge)
		{
		}

		public static bool TryGetBridge(int sceneHandle, out CoherenceBridge bridge)
		{
			bridge = null;
			return false;
		}

		public static bool TryGetBridge(PlayerAccount playerAccount, out CoherenceBridge bridge)
		{
			bridge = null;
			return false;
		}

		public static bool TryGetBridge(Scene scene, out CoherenceBridge bridge)
		{
			bridge = null;
			return false;
		}

		public static bool TryGetBridge<T>(Scene scene, CoherenceBridgeResolver<T> resolver, T component, out CoherenceBridge bridge) where T : MonoBehaviour
		{
			bridge = null;
			return false;
		}
	}
}
