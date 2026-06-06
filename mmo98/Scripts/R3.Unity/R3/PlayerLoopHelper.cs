using System;
using System.Linq;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace R3
{
	public static class PlayerLoopHelper
	{
		private static string applicationDataPath;

		private static UnityFrameProvider[] runners;

		internal static string ApplicationDataPath => applicationDataPath;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void Init()
		{
			try
			{
				applicationDataPath = Application.dataPath;
			}
			catch
			{
			}
			if (runners == null)
			{
				PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();
				Initialize(ref playerLoop);
			}
		}

		public static void Initialize(ref PlayerLoopSystem playerLoop)
		{
			runners = new UnityFrameProvider[9];
			PlayerLoopSystem[] array = playerLoop.subSystemList.ToArray();
			InsertLoop(array, typeof(Initialization), typeof(R3LoopRunners.R3Initialization), runners[0] = (UnityFrameProvider)UnityFrameProvider.Initialization);
			InsertLoop(array, typeof(EarlyUpdate), typeof(R3LoopRunners.R3EarlyUpdate), runners[1] = (UnityFrameProvider)UnityFrameProvider.EarlyUpdate);
			InsertLoop(array, typeof(FixedUpdate), typeof(R3LoopRunners.R3FixedUpdate), runners[2] = (UnityFrameProvider)UnityFrameProvider.FixedUpdate);
			InsertLoop(array, typeof(PreUpdate), typeof(R3LoopRunners.R3PreUpdate), runners[3] = (UnityFrameProvider)UnityFrameProvider.PreUpdate);
			InsertLoop(array, typeof(Update), typeof(R3LoopRunners.R3Update), runners[4] = (UnityFrameProvider)UnityFrameProvider.Update);
			InsertLoop(array, typeof(PreLateUpdate), typeof(R3LoopRunners.R3PreLateUpdate), runners[5] = (UnityFrameProvider)UnityFrameProvider.PreLateUpdate);
			InsertLoop(array, typeof(PostLateUpdate), typeof(R3LoopRunners.R3PostLateUpdate), runners[6] = (UnityFrameProvider)UnityFrameProvider.PostLateUpdate);
			InsertLoop(array, typeof(TimeUpdate), typeof(R3LoopRunners.R3TimeUpdate), runners[7] = (UnityFrameProvider)UnityFrameProvider.TimeUpdate);
			InsertLoop(array, typeof(FixedUpdate), typeof(R3LoopRunners.R3PostFixedUpdate), runners[8] = (UnityFrameProvider)UnityFrameProvider.PostFixedUpdate);
			playerLoop.subSystemList = array;
			PlayerLoop.SetPlayerLoop(playerLoop);
		}

		private static void InsertLoop(PlayerLoopSystem[] loopSystems, Type loopType, Type loopRunnerType, UnityFrameProvider frameProvider)
		{
			int num = FindLoopSystemIndex(loopSystems, loopType);
			ref PlayerLoopSystem reference = ref loopSystems[num];
			reference.subSystemList = InsertRunner(reference.subSystemList, loopRunnerType, frameProvider);
		}

		private static int FindLoopSystemIndex(PlayerLoopSystem[] playerLoopList, Type systemType)
		{
			for (int i = 0; i < playerLoopList.Length; i++)
			{
				if (playerLoopList[i].type == systemType)
				{
					return i;
				}
			}
			throw new Exception("Target PlayerLoopSystem does not found. Type:" + systemType.FullName);
		}

		private static PlayerLoopSystem[] InsertRunner(PlayerLoopSystem[] subSystemList, Type loopRunnerType, UnityFrameProvider runner)
		{
			PlayerLoopSystem[] array = subSystemList.Where((PlayerLoopSystem x) => x.type != loopRunnerType).ToArray();
			PlayerLoopSystem[] array2 = new PlayerLoopSystem[array.Length + 1];
			int num = ((runner.PlayerLoopTiming == PlayerLoopTiming.PostFixedUpdate) ? (array2.Length - 1) : 0);
			Array.Copy(array, 0, array2, (num == 0) ? 1 : 0, array.Length);
			array2[num] = new PlayerLoopSystem
			{
				type = loopRunnerType,
				updateDelegate = runner.Run
			};
			return array2;
		}
	}
}
