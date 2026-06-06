using System;
using System.Linq;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace LitMotion
{
	internal static class PlayerLoopHelper
	{
		private static bool initialized;

		public static event Action OnInitialization;

		public static event Action OnEarlyUpdate;

		public static event Action OnFixedUpdate;

		public static event Action OnPreUpdate;

		public static event Action OnUpdate;

		public static event Action OnPreLateUpdate;

		public static event Action OnPostLateUpdate;

		public static event Action OnTimeUpdate;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void Init()
		{
			if (initialized)
			{
				return;
			}
			if (!initialized)
			{
				OnInitialization += delegate
				{
					MotionDispatcher.Update(PlayerLoopTiming.Initialization);
				};
				OnEarlyUpdate += delegate
				{
					MotionDispatcher.Update(PlayerLoopTiming.EarlyUpdate);
				};
				OnFixedUpdate += delegate
				{
					MotionDispatcher.Update(PlayerLoopTiming.FixedUpdate);
				};
				OnPreUpdate += delegate
				{
					MotionDispatcher.Update(PlayerLoopTiming.PreUpdate);
				};
				OnUpdate += delegate
				{
					MotionDispatcher.Update(PlayerLoopTiming.Update);
				};
				OnPreLateUpdate += delegate
				{
					MotionDispatcher.Update(PlayerLoopTiming.PreLateUpdate);
				};
				OnPostLateUpdate += delegate
				{
					MotionDispatcher.Update(PlayerLoopTiming.PostLateUpdate);
				};
				OnTimeUpdate += delegate
				{
					MotionDispatcher.Update(PlayerLoopTiming.TimeUpdate);
				};
			}
			PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();
			Initialize(ref playerLoop);
		}

		public static void Initialize(ref PlayerLoopSystem playerLoop)
		{
			initialized = true;
			PlayerLoopSystem[] array = playerLoop.subSystemList.ToArray();
			InsertLoop(array, typeof(Initialization), typeof(LitMotionLoopRunners.LitMotionInitialization), delegate
			{
				PlayerLoopHelper.OnInitialization?.Invoke();
			});
			InsertLoop(array, typeof(EarlyUpdate), typeof(LitMotionLoopRunners.LitMotionEarlyUpdate), delegate
			{
				PlayerLoopHelper.OnEarlyUpdate?.Invoke();
			});
			InsertLoop(array, typeof(FixedUpdate), typeof(LitMotionLoopRunners.LitMotionFixedUpdate), delegate
			{
				PlayerLoopHelper.OnFixedUpdate?.Invoke();
			});
			InsertLoop(array, typeof(PreUpdate), typeof(LitMotionLoopRunners.LitMotionPreUpdate), delegate
			{
				PlayerLoopHelper.OnPreUpdate?.Invoke();
			});
			InsertLoop(array, typeof(Update), typeof(LitMotionLoopRunners.LitMotionUpdate), delegate
			{
				PlayerLoopHelper.OnUpdate?.Invoke();
			});
			InsertLoop(array, typeof(PreLateUpdate), typeof(LitMotionLoopRunners.LitMotionPreLateUpdate), delegate
			{
				PlayerLoopHelper.OnPreLateUpdate?.Invoke();
			});
			InsertLoop(array, typeof(PostLateUpdate), typeof(LitMotionLoopRunners.LitMotionPostLateUpdate), delegate
			{
				PlayerLoopHelper.OnPostLateUpdate?.Invoke();
			});
			InsertLoop(array, typeof(TimeUpdate), typeof(LitMotionLoopRunners.LitMotionTimeUpdate), delegate
			{
				PlayerLoopHelper.OnTimeUpdate?.Invoke();
			});
			playerLoop.subSystemList = array;
			PlayerLoop.SetPlayerLoop(playerLoop);
		}

		private static void InsertLoop(PlayerLoopSystem[] loopSystems, Type loopType, Type loopRunnerType, PlayerLoopSystem.UpdateFunction updateDelegate)
		{
			int num = FindLoopSystemIndex(loopSystems, loopType);
			ref PlayerLoopSystem reference = ref loopSystems[num];
			reference.subSystemList = InsertRunner(reference.subSystemList, loopRunnerType, updateDelegate);
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

		private static PlayerLoopSystem[] InsertRunner(PlayerLoopSystem[] subSystemList, Type loopRunnerType, PlayerLoopSystem.UpdateFunction updateDelegate)
		{
			PlayerLoopSystem[] array = subSystemList.Where((PlayerLoopSystem x) => x.type != loopRunnerType).ToArray();
			PlayerLoopSystem[] array2 = new PlayerLoopSystem[array.Length + 1];
			Array.Copy(array, 0, array2, 1, array.Length);
			array2[0] = new PlayerLoopSystem
			{
				type = loopRunnerType,
				updateDelegate = updateDelegate
			};
			return array2;
		}
	}
}
