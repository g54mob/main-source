using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Dhs5.Utility.PlayerLoops
{
	public static class PlayerLoopManager
	{
		private static bool _modifiersRegistrationOpen = true;

		private static List<IPlayerLoopModifier> _modifiers = new List<IPlayerLoopModifier>();

		private static Dictionary<Type, PlayerLoopSystem> _disabledSystems = new Dictionary<Type, PlayerLoopSystem>();

		public static event Action PlayerLoopInitialized;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void AfterSceneLoad()
		{
			Application.quitting += OnApplicationQuitting;
			_modifiersRegistrationOpen = false;
			CreatePlayerLoop();
			ClearModifiers();
		}

		private static void OnApplicationQuitting()
		{
			ResetPlayerLoop();
		}

		private static void CreatePlayerLoop()
		{
			if (_modifiers != null && _modifiers.Count > 0)
			{
				PlayerLoopSystem playerLoopSystem = PlayerLoop.GetDefaultPlayerLoop();
				SortModifiers();
				foreach (IPlayerLoopModifier modifier in _modifiers)
				{
					playerLoopSystem = modifier.ModifyPlayerLoop(playerLoopSystem);
				}
				PlayerLoop.SetPlayerLoop(playerLoopSystem);
			}
			PlayerLoopManager.PlayerLoopInitialized?.Invoke();
			PlayerLoopManager.PlayerLoopInitialized = null;
		}

		public static void ResetPlayerLoop()
		{
			PlayerLoop.SetPlayerLoop(PlayerLoop.GetDefaultPlayerLoop());
		}

		public static bool RegisterModifier(IPlayerLoopModifier modifier)
		{
			if (_modifiersRegistrationOpen)
			{
				_modifiers.Add(modifier);
				return true;
			}
			return false;
		}

		private static void SortModifiers()
		{
			_modifiers.Sort((IPlayerLoopModifier m1, IPlayerLoopModifier m2) => m1.Priority.CompareTo(m2.Priority));
		}

		private static void ClearModifiers()
		{
			_modifiers.Clear();
		}

		public static void DisableSystem(Type type)
		{
			if (_disabledSystems.ContainsKey(type))
			{
				return;
			}
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			for (int i = 0; i < currentPlayerLoop.subSystemList.Length; i++)
			{
				PlayerLoopSystem playerLoopSystem = currentPlayerLoop.subSystemList[i];
				if (playerLoopSystem.type == type)
				{
					_disabledSystems[type] = playerLoopSystem;
					currentPlayerLoop.subSystemList[i] = new PlayerLoopSystem
					{
						type = type
					};
					PlayerLoop.SetPlayerLoop(currentPlayerLoop);
					break;
				}
				if (playerLoopSystem.subSystemList == null)
				{
					continue;
				}
				for (int j = 0; j < playerLoopSystem.subSystemList.Length; j++)
				{
					PlayerLoopSystem value = playerLoopSystem.subSystemList[j];
					if (value.type == type)
					{
						_disabledSystems[type] = value;
						playerLoopSystem.subSystemList[j] = new PlayerLoopSystem
						{
							type = type
						};
						currentPlayerLoop.subSystemList[i] = playerLoopSystem;
						PlayerLoop.SetPlayerLoop(currentPlayerLoop);
						break;
					}
				}
			}
		}

		public static void ReenableSystem(Type type)
		{
			if (!_disabledSystems.ContainsKey(type))
			{
				return;
			}
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			for (int i = 0; i < currentPlayerLoop.subSystemList.Length; i++)
			{
				PlayerLoopSystem playerLoopSystem = currentPlayerLoop.subSystemList[i];
				if (playerLoopSystem.type == type)
				{
					currentPlayerLoop.subSystemList[i] = _disabledSystems[type];
					PlayerLoop.SetPlayerLoop(currentPlayerLoop);
					_disabledSystems.Remove(type);
					break;
				}
				if (playerLoopSystem.subSystemList == null)
				{
					continue;
				}
				for (int j = 0; j < playerLoopSystem.subSystemList.Length; j++)
				{
					if (playerLoopSystem.subSystemList[j].type == type)
					{
						playerLoopSystem.subSystemList[j] = _disabledSystems[type];
						currentPlayerLoop.subSystemList[i] = playerLoopSystem;
						PlayerLoop.SetPlayerLoop(currentPlayerLoop);
						_disabledSystems.Remove(type);
						break;
					}
				}
			}
		}

		public static bool IsSystemEnabled(Type type)
		{
			return !_disabledSystems.ContainsKey(type);
		}

		public static void AddCustomMainSystemAtIndex(PlayerLoopSystem system, int index)
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			List<PlayerLoopSystem> list = currentPlayerLoop.subSystemList.ToList();
			list.Insert(index, system);
			currentPlayerLoop.subSystemList = list.ToArray();
			PlayerLoop.SetPlayerLoop(currentPlayerLoop);
		}

		public static void AddCustomMainSystemBefore(PlayerLoopSystem system, Type mainSystemToInsertBeforeType)
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			List<PlayerLoopSystem> list = currentPlayerLoop.subSystemList.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].type == mainSystemToInsertBeforeType)
				{
					list.Insert(i, system);
				}
			}
			currentPlayerLoop.subSystemList = list.ToArray();
			PlayerLoop.SetPlayerLoop(currentPlayerLoop);
		}

		public static void AddCustomMainSystemAfter(PlayerLoopSystem system, Type mainSystemToInsertAfterType)
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			List<PlayerLoopSystem> list = currentPlayerLoop.subSystemList.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].type == mainSystemToInsertAfterType)
				{
					list.Insert(i + 1, system);
				}
			}
			currentPlayerLoop.subSystemList = list.ToArray();
			PlayerLoop.SetPlayerLoop(currentPlayerLoop);
		}

		public static void AddCustomSubSystemAtIndex(PlayerLoopSystem system, Type mainSystemType, int index)
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			for (int i = 0; i < currentPlayerLoop.subSystemList.Length; i++)
			{
				if (currentPlayerLoop.subSystemList[i].type == mainSystemType)
				{
					List<PlayerLoopSystem> list;
					if (currentPlayerLoop.subSystemList[i].subSystemList != null)
					{
						list = currentPlayerLoop.subSystemList[i].subSystemList.ToList();
						list.Insert(index, system);
					}
					else
					{
						list = new List<PlayerLoopSystem> { system };
					}
					currentPlayerLoop.subSystemList[i].subSystemList = list.ToArray();
				}
			}
			PlayerLoop.SetPlayerLoop(currentPlayerLoop);
		}

		public static void AddCustomSubSystemAtLast(PlayerLoopSystem system, Type mainSystemType)
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			for (int i = 0; i < currentPlayerLoop.subSystemList.Length; i++)
			{
				if (currentPlayerLoop.subSystemList[i].type == mainSystemType)
				{
					List<PlayerLoopSystem> list = ((currentPlayerLoop.subSystemList[i].subSystemList == null) ? new List<PlayerLoopSystem>() : currentPlayerLoop.subSystemList[i].subSystemList.ToList());
					list.Add(system);
					currentPlayerLoop.subSystemList[i].subSystemList = list.ToArray();
				}
			}
			PlayerLoop.SetPlayerLoop(currentPlayerLoop);
		}
	}
}
