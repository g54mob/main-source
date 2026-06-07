using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts
{
	public static class GamePlayerLoop
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CustomSystems
		{
			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct GamePlayerLoop_PostFixedUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct GamePlayerLoop_PostLateUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct GamePlayerLoop_PostUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct GamePlayerLoop_PreAudioSystemFixedUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct GamePlayerLoop_PreFixedUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct GamePlayerLoop_PreLateUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct GamePlayerLoop_PreUpdate
			{
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker ScheduleBatchedJobs = new ProfilerMarker("GamePlayerLoop.ScheduleBatchedJobs");
		}

		private static Action _actionPostFixedUpdate;

		private static Action _actionPostLateUpdate;

		private static Action _actionPostUpdate;

		private static Action _actionPreAudioFixedUpdate;

		private static Action _actionPreFixedUpdate;

		private static Action _actionPreLateUpdate;

		private static Action _actionPreUpdate;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		public static void AppStart()
		{
			PlayerLoopSystem loop = PlayerLoop.GetCurrentPlayerLoop();
			AddPreAndPostSystems<FixedUpdate.ScriptRunBehaviourFixedUpdate, CustomSystems.GamePlayerLoop_PreFixedUpdate, CustomSystems.GamePlayerLoop_PostFixedUpdate>(ref loop, RunPreFixedUpdate, RunPostFixedUpdate);
			AddPreAndPostSystems<Update.ScriptRunBehaviourUpdate, CustomSystems.GamePlayerLoop_PreUpdate, CustomSystems.GamePlayerLoop_PostUpdate>(ref loop, RunPreUpdate, RunPostUpdate);
			AddPreAndPostSystems<PreLateUpdate.ScriptRunBehaviourLateUpdate, CustomSystems.GamePlayerLoop_PreLateUpdate, CustomSystems.GamePlayerLoop_PostLateUpdate>(ref loop, RunPreLateUpdate, RunPostLateUpdate);
			AddPreSystem<FixedUpdate.AudioFixedUpdate, CustomSystems.GamePlayerLoop_PostLateUpdate>(ref loop, RunPreAudioSystemFixedUpdate);
			PlayerLoop.SetPlayerLoop(loop);
		}

		public static void RegisterPostFixedUpdate(Action action)
		{
			_actionPostFixedUpdate = (Action)Delegate.Combine(_actionPostFixedUpdate, action);
		}

		public static void RegisterPostLateUpdate(Action action)
		{
			_actionPostLateUpdate = (Action)Delegate.Combine(_actionPostLateUpdate, action);
		}

		public static void RegisterPostUpdate(Action action)
		{
			_actionPostUpdate = (Action)Delegate.Combine(_actionPostUpdate, action);
		}

		public static void RegisterPreAudioSystemFixedUpdate(Action action)
		{
			_actionPreAudioFixedUpdate = (Action)Delegate.Combine(_actionPreAudioFixedUpdate, action);
		}

		public static void RegisterPreFixedUpdate(Action action)
		{
			_actionPreFixedUpdate = (Action)Delegate.Combine(_actionPreFixedUpdate, action);
		}

		public static void RegisterPreLateUpdate(Action action)
		{
			_actionPreLateUpdate = (Action)Delegate.Combine(_actionPreLateUpdate, action);
		}

		public static void RegisterPreUpdate(Action action)
		{
			_actionPreUpdate = (Action)Delegate.Combine(_actionPreUpdate, action);
		}

		public static void UnregisterPostFixedUpdate(Action action)
		{
			_actionPostFixedUpdate = (Action)Delegate.Remove(_actionPostFixedUpdate, action);
		}

		public static void UnregisterPostLateUpdate(Action action)
		{
			_actionPostLateUpdate = (Action)Delegate.Remove(_actionPostLateUpdate, action);
		}

		public static void UnregisterPostUpdate(Action action)
		{
			_actionPostUpdate = (Action)Delegate.Remove(_actionPostUpdate, action);
		}

		public static void UnregisterPreAudioSystemFixedUpdate(Action action)
		{
			_actionPreAudioFixedUpdate = (Action)Delegate.Remove(_actionPreAudioFixedUpdate, action);
		}

		public static void UnregisterPreFixedUpdate(Action action)
		{
			_actionPreFixedUpdate = (Action)Delegate.Remove(_actionPreFixedUpdate, action);
		}

		public static void UnregisterPreLateUpdate(Action action)
		{
			_actionPreLateUpdate = (Action)Delegate.Remove(_actionPreLateUpdate, action);
		}

		public static void UnregisterPreUpdate(Action action)
		{
			_actionPreUpdate = (Action)Delegate.Remove(_actionPreUpdate, action);
		}

		private static void AddPreAndPostSystems<TSystem, TPreSystem, TPostSystem>(ref PlayerLoopSystem loop, PlayerLoopSystem.UpdateFunction preAction, PlayerLoopSystem.UpdateFunction postAction)
		{
			PlayerLoopSystem item = new PlayerLoopSystem
			{
				type = typeof(TPreSystem),
				updateDelegate = preAction
			};
			PlayerLoopSystem item2 = new PlayerLoopSystem
			{
				type = typeof(TPostSystem),
				updateDelegate = postAction
			};
			bool flag = false;
			PlayerLoopSystem[] subSystemList = loop.subSystemList;
			for (int i = 0; i < subSystemList.Length; i++)
			{
				if (!(subSystemList[i].type == typeof(TSystem).DeclaringType))
				{
					continue;
				}
				PlayerLoopSystem[] subSystemList2 = subSystemList[i].subSystemList;
				for (int j = 0; j < subSystemList2.Length; j++)
				{
					if (subSystemList2[j].type == typeof(TSystem))
					{
						List<PlayerLoopSystem> list = subSystemList[i].subSystemList.ToList();
						list.Insert(j + 1, item2);
						list.Insert(j, item);
						subSystemList[i].subSystemList = list.ToArray();
						flag = true;
						break;
					}
				}
				break;
			}
			if (!flag)
			{
				Debug.LogError($"Unable to update the player loop with {typeof(TPreSystem).FullName} and {typeof(TPostSystem)}.");
			}
		}

		private static void AddPreSystem<TSystem, TPreSystem>(ref PlayerLoopSystem loop, PlayerLoopSystem.UpdateFunction preAction)
		{
			PlayerLoopSystem item = new PlayerLoopSystem
			{
				type = typeof(TPreSystem),
				updateDelegate = preAction
			};
			bool flag = false;
			PlayerLoopSystem[] subSystemList = loop.subSystemList;
			for (int i = 0; i < subSystemList.Length; i++)
			{
				if (!(subSystemList[i].type == typeof(TSystem).DeclaringType))
				{
					continue;
				}
				PlayerLoopSystem[] subSystemList2 = subSystemList[i].subSystemList;
				for (int j = 0; j < subSystemList2.Length; j++)
				{
					if (subSystemList2[j].type == typeof(TSystem))
					{
						List<PlayerLoopSystem> list = subSystemList[i].subSystemList.ToList();
						list.Insert(j, item);
						subSystemList[i].subSystemList = list.ToArray();
						flag = true;
						break;
					}
				}
				break;
			}
			if (!flag)
			{
				Debug.LogError("Unable to update the player loop with " + typeof(TPreSystem).FullName + ".");
			}
		}

		private static void PrintPlayerLoopSystem(in PlayerLoopSystem system)
		{
			StringBuilder stringBuilder = new StringBuilder();
			PrintPlayerLoopSystem(in system, stringBuilder, 0);
			Debug.Log(stringBuilder.ToString());
		}

		private static void PrintPlayerLoopSystem(in PlayerLoopSystem system, StringBuilder stringBuilder, int depth)
		{
			if (depth == 0)
			{
				stringBuilder.AppendLine("Root");
			}
			else if (system.type != null)
			{
				for (int i = 0; i < depth; i++)
				{
					stringBuilder.Append('\t');
				}
				stringBuilder.AppendLine(system.type.Name);
			}
			if (system.subSystemList != null)
			{
				depth++;
				PlayerLoopSystem[] subSystemList = system.subSystemList;
				for (int j = 0; j < subSystemList.Length; j++)
				{
					PlayerLoopSystem system2 = subSystemList[j];
					PrintPlayerLoopSystem(in system2, stringBuilder, depth);
				}
				depth--;
			}
		}

		private static void RunPostFixedUpdate()
		{
			_actionPostFixedUpdate?.Invoke();
		}

		private static void RunPostLateUpdate()
		{
			_actionPostLateUpdate?.Invoke();
		}

		private static void RunPostUpdate()
		{
			_actionPostUpdate?.Invoke();
		}

		private static void RunPreAudioSystemFixedUpdate()
		{
			_actionPreAudioFixedUpdate?.Invoke();
		}

		private static void RunPreFixedUpdate()
		{
			_actionPreFixedUpdate?.Invoke();
			ScheduleBatchedJobs();
		}

		private static void RunPreLateUpdate()
		{
			_actionPreLateUpdate?.Invoke();
			ScheduleBatchedJobs();
		}

		private static void RunPreUpdate()
		{
			_actionPreUpdate?.Invoke();
			ScheduleBatchedJobs();
		}

		private static void ScheduleBatchedJobs()
		{
			using (Profile.ScheduleBatchedJobs.Auto())
			{
				JobHandle.ScheduleBatchedJobs();
			}
		}
	}
}
