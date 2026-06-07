using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts.GameLoop
{
	internal static class CustomPlayerLoop
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CustomSystems
		{
			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct PostFixedUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct PostLateUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct PostUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct PreFixedUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct PreLateUpdate
			{
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct PreUpdate
			{
			}
		}

		private static Action _actionPostFixedUpdate;

		private static Action _actionPostLateUpdate;

		private static Action _actionPostUpdate;

		private static Action _actionPreFixedUpdate;

		private static Action _actionPreLateUpdate;

		private static Action _actionPreUpdate;

		public static void ClearUpdateActions()
		{
			_actionPreFixedUpdate = null;
			_actionPostFixedUpdate = null;
			_actionPreUpdate = null;
			_actionPostUpdate = null;
			_actionPreLateUpdate = null;
			_actionPostLateUpdate = null;
		}

		public static void SetUpdateActions(Action preFixedUpdate, Action postFixedUpdate, Action preUpdate, Action postUpdate, Action preLateUpdate, Action postLateUpdate)
		{
			_actionPreFixedUpdate = preFixedUpdate;
			_actionPostFixedUpdate = postFixedUpdate;
			_actionPreUpdate = preUpdate;
			_actionPostUpdate = postUpdate;
			_actionPreLateUpdate = preLateUpdate;
			_actionPostLateUpdate = postLateUpdate;
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

		[RuntimeInitializeOnLoadMethod]
		private static void AppStart()
		{
			PlayerLoopSystem loop = PlayerLoop.GetCurrentPlayerLoop();
			AddPreAndPostSystems<FixedUpdate.ScriptRunBehaviourFixedUpdate, CustomSystems.PreFixedUpdate, CustomSystems.PostFixedUpdate>(ref loop, RunPreFixedUpdate, RunPostFixedUpdate);
			AddPreAndPostSystems<Update.ScriptRunBehaviourUpdate, CustomSystems.PreUpdate, CustomSystems.PostUpdate>(ref loop, RunPreUpdate, RunPostUpdate);
			AddPreAndPostSystems<PreLateUpdate.ScriptRunBehaviourLateUpdate, CustomSystems.PreLateUpdate, CustomSystems.PostLateUpdate>(ref loop, RunPreLateUpdate, RunPostLateUpdate);
			PlayerLoop.SetPlayerLoop(loop);
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
					stringBuilder.Append("\t");
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

		private static void RunPreFixedUpdate()
		{
			_actionPreFixedUpdate?.Invoke();
		}

		private static void RunPreLateUpdate()
		{
			_actionPreLateUpdate?.Invoke();
		}

		private static void RunPreUpdate()
		{
			_actionPreUpdate?.Invoke();
		}
	}
}
