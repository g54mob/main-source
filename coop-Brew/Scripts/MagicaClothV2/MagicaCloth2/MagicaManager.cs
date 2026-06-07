using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

namespace MagicaCloth2
{
	public static class MagicaManager
	{
		public delegate void UpdateMethod();

		public enum InitializationLocation
		{
			Start = 0,
			Awake = 1
		}

		private static List<IManager> managers;

		public static UpdateMethod afterEarlyUpdateDelegate;

		public static UpdateMethod afterFixedUpdateDelegate;

		public static UpdateMethod firstPreUpdateDelegate;

		public static UpdateMethod afterUpdateDelegate;

		public static UpdateMethod beforeLateUpdateDelegate;

		public static UpdateMethod afterLateUpdateDelegate;

		public static UpdateMethod afterDelayedDelegate;

		public static UpdateMethod afterRenderingDelegate;

		public static UpdateMethod defaultUpdateDelegate;

		private static bool isPlaying;

		public static Action OnPreSimulation;

		public static Action OnPostSimulation;

		internal static InitializationLocation initializationLocation;

		public static TimeManager Time => null;

		public static TeamManager Team => null;

		public static ClothManager Cloth => null;

		public static RenderManager Render => null;

		public static TransformManager Bone => null;

		public static VirtualMeshManager VMesh => null;

		public static SimulationManager Simulation => null;

		public static ColliderManager Collider => null;

		public static WindManager Wind => null;

		public static PreBuildManager PreBuild => null;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Initialize()
		{
		}

		private static void OnAppQuitting()
		{
		}

		private static void Dispose()
		{
		}

		public static bool IsPlaying()
		{
			return false;
		}

		public static void InitCustomGameLoop()
		{
		}

		private static void SetCustomGameLoop(ref PlayerLoopSystem playerLoop)
		{
		}

		private static void AddPlayerLoop(PlayerLoopSystem method, ref PlayerLoopSystem playerLoop, string categoryName, string systemName, int firstLast = 0, bool before = false)
		{
		}

		private static bool CheckRegist(ref PlayerLoopSystem playerLoop)
		{
			return false;
		}

		public static void SetGlobalTimeScale(float timeScale)
		{
		}

		public static float GetGlobalTimeScale()
		{
			return 0f;
		}

		public static void SetSimulationFrequency(int freq)
		{
		}

		public static int GetSimulationFrequency()
		{
			return 0;
		}

		public static void SetMaxSimulationCountPerFrame(int count)
		{
		}

		public static int GetMaxSimulationCountPerFrame()
		{
			return 0;
		}

		public static void SetUpdateLocation(TimeManager.UpdateLocation updateLocation)
		{
		}

		public static TimeManager.UpdateLocation GetUpdateLocation()
		{
			return default(TimeManager.UpdateLocation);
		}

		public static void UnloadUnusedData()
		{
		}

		public static void SetInitializationLocation(InitializationLocation initLocation)
		{
		}

		public static void SetSplitProxyMeshVertexCount(int vertexCount)
		{
		}

		public static int GetSplitProxyMeshVertexCount()
		{
			return 0;
		}
	}
}
