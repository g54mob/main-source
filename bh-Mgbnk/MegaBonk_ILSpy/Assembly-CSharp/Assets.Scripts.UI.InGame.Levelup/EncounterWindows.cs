using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;

namespace Assets.Scripts.UI.InGame.Levelup;

public class EncounterWindows : MonoBehaviour
{
	public BaseEncounterWindow levelupScreen;

	public BaseEncounterWindow genericEncounterWindow;

	public BaseEncounterWindow chestWindow;

	public BaseEncounterWindow itemPickWindow;

	public BaseEncounterWindow microwaveWindow;

	private BaseEncounterWindow activeEncounterWindow;

	private Queue<EEncounter> rewardQueue;

	private bool _003CencounterInProgress_003Ek__BackingField;

	private bool closedEncounterThisFrame;

	private static List<EEncounter> nextMapQueue;

	public static Action A_WindowOpened;

	public static Action A_WindowClosed;

	public int currentLevel;

	public bool encounterInProgress
	{
		get
		{
			return _003CencounterInProgress_003Ek__BackingField;
		}
		private set
		{
			_003CencounterInProgress_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_0358: Expected I, but got O
		//IL_0369: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_0102: Expected I, but got O
		//IL_0113: Expected O, but got I4
		//IL_0156: Expected I, but got O
		//IL_0167: Expected O, but got I4
		//IL_0183: Expected I, but got O
		//IL_03eb: Expected O, but got I4
		//IL_0401: Expected I, but got O
		//IL_0265: Expected I, but got O
		//IL_042f: Expected O, but got I4
		//IL_0445: Expected I, but got O
		//IL_0473: Expected O, but got I4
		//IL_0489: Expected I, but got O
		//IL_04b7: Expected O, but got I4
		//IL_04cd: Expected I, but got O
		Action<int> b = OnLevelUp;
		Delegate obj = Delegate.Combine(PlayerXp.A_LevelUp, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action = default(Action<int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_053b;
			}
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0378;
			}
		}
		Action<PlayerInventory> b2 = OnInventoryInitialized;
		Delegate obj6 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b2);
		if ((object)obj6 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action2 = default(Action<PlayerInventory>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_03ab;
			}
			MyPlayer.A_PlayerInventoryInitialized = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_03bb;
			}
		}
		num = (nint)SpawnPlayerPortal.A_PortalClosed;
		Action action3 = OnPortalClosed;
		Delegate obj8 = Delegate.Combine(SpawnPlayerPortal.A_PortalClosed, action3);
		if ((object)obj8 == null)
		{
			SpawnPlayerPortal.A_PortalClosed = null;
		}
		else
		{
			bool flag4 = (object)obj8.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag4)
			{
				obj9 = obj8;
			}
			bool flag5 = (object)obj9 == null;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0503;
			}
			SpawnPlayerPortal.A_PortalClosed = (Action)obj9;
			bool flag6 = (object)obj8.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag6)
			{
				obj10 = obj8;
			}
			bool flag7 = (object)obj10 == null;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_051b;
			}
		}
		num = (nint)GameManager.A_GameOver;
		Action action4 = OnGameOver;
		Delegate obj11 = Delegate.Combine(GameManager.A_GameOver, action4);
		if ((object)obj11 == null)
		{
			GameManager.A_GameOver = null;
			return;
		}
		bool flag8 = (object)obj11.GetType() != typeof(Action);
		Delegate obj12 = null;
		if (!flag8)
		{
			obj12 = obj11;
		}
		bool flag9 = (object)obj12 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num5 = (nint)typeof(Action);
		if (flag9)
		{
			goto IL_052b;
		}
		GameManager.A_GameOver = (Action)obj12;
		bool flag10 = (object)obj11.GetType() != typeof(Action);
		Delegate obj13 = null;
		if (!flag10)
		{
			obj13 = obj11;
		}
		bool flag11 = (object)obj13 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num6 = (nint)typeof(Action);
		if (!flag11)
		{
			return;
		}
		goto IL_053b;
		IL_03bb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ab;
		IL_0503:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03bb;
		IL_03ab:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0378;
		IL_052b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_051b;
		IL_053b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_052b;
		IL_0378:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_051b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0503;
	}

	private void OnDestroy()
	{
		//IL_0358: Expected I, but got O
		//IL_0369: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_0102: Expected I, but got O
		//IL_0113: Expected O, but got I4
		//IL_0156: Expected I, but got O
		//IL_0167: Expected O, but got I4
		//IL_0183: Expected I, but got O
		//IL_03eb: Expected O, but got I4
		//IL_0401: Expected I, but got O
		//IL_0265: Expected I, but got O
		//IL_042f: Expected O, but got I4
		//IL_0445: Expected I, but got O
		//IL_0473: Expected O, but got I4
		//IL_0489: Expected I, but got O
		//IL_04b7: Expected O, but got I4
		//IL_04cd: Expected I, but got O
		Action<int> value = OnLevelUp;
		Delegate obj = Delegate.Remove(PlayerXp.A_LevelUp, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action = default(Action<int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_053b;
			}
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0378;
			}
		}
		Action<PlayerInventory> value2 = OnInventoryInitialized;
		Delegate obj6 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value2);
		if ((object)obj6 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action2 = default(Action<PlayerInventory>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_03ab;
			}
			MyPlayer.A_PlayerInventoryInitialized = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_03bb;
			}
		}
		num = (nint)SpawnPlayerPortal.A_PortalClosed;
		Action action3 = OnPortalClosed;
		Delegate obj8 = Delegate.Remove(SpawnPlayerPortal.A_PortalClosed, action3);
		if ((object)obj8 == null)
		{
			SpawnPlayerPortal.A_PortalClosed = null;
		}
		else
		{
			bool flag4 = (object)obj8.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag4)
			{
				obj9 = obj8;
			}
			bool flag5 = (object)obj9 == null;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0503;
			}
			SpawnPlayerPortal.A_PortalClosed = (Action)obj9;
			bool flag6 = (object)obj8.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag6)
			{
				obj10 = obj8;
			}
			bool flag7 = (object)obj10 == null;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_051b;
			}
		}
		num = (nint)GameManager.A_GameOver;
		Action action4 = OnGameOver;
		Delegate obj11 = Delegate.Remove(GameManager.A_GameOver, action4);
		if ((object)obj11 == null)
		{
			GameManager.A_GameOver = null;
			return;
		}
		bool flag8 = (object)obj11.GetType() != typeof(Action);
		Delegate obj12 = null;
		if (!flag8)
		{
			obj12 = obj11;
		}
		bool flag9 = (object)obj12 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num5 = (nint)typeof(Action);
		if (flag9)
		{
			goto IL_052b;
		}
		GameManager.A_GameOver = (Action)obj12;
		bool flag10 = (object)obj11.GetType() != typeof(Action);
		Delegate obj13 = null;
		if (!flag10)
		{
			obj13 = obj11;
		}
		bool flag11 = (object)obj13 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num6 = (nint)typeof(Action);
		if (!flag11)
		{
			return;
		}
		goto IL_053b;
		IL_03bb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ab;
		IL_0503:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03bb;
		IL_03ab:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0378;
		IL_052b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_051b;
		IL_053b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_052b;
		IL_0378:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_051b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0503;
	}

	private void OnGameOver()
	{
		rewardQueue.Clear();
		List<EEncounter> list = nextMapQueue;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v5 (System.Collections.Generic.List`1<Assets.Scripts.UI.InGame.Rewards.EEncounter>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
	}

	private void OnPortalClosed()
	{
		if (!MapController.IsFirstStage())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
			List<EEncounter>.Enumerator enumerator = default(List<EEncounter>.Enumerator);
			EEncounter rewardWindowType = default(EEncounter);
			while (enumerator.MoveNext())
			{
				AddEncounter(rewardWindowType);
			}
			enumerator.Dispose();
		}
		List<EEncounter> list = new List<EEncounter>();
		nextMapQueue = list;
	}

	private bool QueueEncountersForNextMap()
	{
		//IL_0037: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			bool flag = !instance.isTeleporting;
			return !flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool HasEncounter()
	{
		bool flag = _003CencounterInProgress_003Ek__BackingField;
		bool result = true;
		if (!flag)
		{
			result = closedEncounterThisFrame;
		}
		return result;
	}

	public void AddEncounter(EEncounter rewardWindowType)
	{
		//IL_008f: Expected O, but got I
		//IL_00e4: Expected O, but got I
		MyPlayer instance = MyPlayer.Instance;
		if (!instance.isTeleporting)
		{
			rewardQueue.Enqueue(rewardWindowType);
			if (!_003CencounterInProgress_003Ek__BackingField)
			{
				PopReward();
			}
			return;
		}
		List<EEncounter> list = nextMapQueue;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v8 (System.Collections.Generic.List`1<Assets.Scripts.UI.InGame.Rewards.EEncounter>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v8 (System.Collections.Generic.List`1<Assets.Scripts.UI.InGame.Rewards.EEncounter>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v8 (System.Collections.Generic.List`1<Assets.Scripts.UI.InGame.Rewards.EEncounter>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize(rewardWindowType);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v8 (System.Collections.Generic.List`1<Assets.Scripts.UI.InGame.Rewards.EEncounter>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	public void RewardFinished()
	{
		activeEncounterWindow.OnClose();
		activeEncounterWindow = null;
		Queue<EEncounter> queue = rewardQueue;
		_003CencounterInProgress_003Ek__BackingField = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v8 (System.Collections.Generic.Queue`1<Assets.Scripts.UI.InGame.Rewards.EEncounter>)+20]");
		if ((nint)0 <= (nint)0)
		{
			MyTime.Unpause();
			Action a_WindowClosed = A_WindowClosed;
			if (A_WindowClosed != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v141.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			return;
		}
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v8 (System.Collections.Generic.Queue`1<Assets.Scripts.UI.InGame.Rewards.EEncounter>)+20]");
			if ((nint)0 <= (nint)1 || rewardQueue.Peek() != EEncounter.Levelup || !IsPlayerMaxed())
			{
				break;
			}
			EEncounter eEncounter = rewardQueue.Dequeue();
			queue = rewardQueue;
		}
		PopReward();
	}

	private void PopReward()
	{
		//IL_008c: Expected O, but got I8
		//IL_00a6: Expected O, but got I8
		if (MyPlayer.Instance != null && !MyPlayer.Instance.IsDead())
		{
			_003CencounterInProgress_003Ek__BackingField = true;
			EEncounter eEncounter = rewardQueue.Dequeue();
			if (eEncounter <= EEncounter.ChestGhost)
			{
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v40+3E092C+v221 @ rax_v14 (Assets.Scripts.UI.InGame.Rewards.EEncounter)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v166 @ rdx_v14 (should have been resolved before IL gen)");
			}
			else
			{
				activeEncounterWindow = genericEncounterWindow;
			}
			MyTime.paused = true;
			Physics.simulationMode = SimulationMode.Script;
			Action<bool> a_Pause = MyTime.A_Pause;
			if (MyTime.A_Pause != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v294 @ rax_v23 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
			if ((object)activeEncounterWindow != null)
			{
				activeEncounterWindow.Open(eEncounter);
			}
			Action a_WindowOpened = A_WindowOpened;
			if (A_WindowOpened != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v104.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private void OnInventoryInitialized(PlayerInventory inventory)
	{
		PlayerXp playerXp = inventory.playerXp;
		currentLevel = playerXp.level;
	}

	private void LateUpdate()
	{
		closedEncounterThisFrame = false;
	}

	private void Start()
	{
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			PlayerXp playerXp = inventory.playerXp;
			currentLevel = playerXp.level;
		}
	}

	private void OnLevelUp(int level)
	{
		//IL_01c4: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_00cf: Invalid comparison between I4 and F4
		//IL_0181: Expected I4, but got O
		if (!IsPlayerMaxed())
		{
			int num = currentLevel;
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFGameSettings cfGameSettings = config.cfGameSettings;
			bool flag;
			bool flag2;
			if (cfGameSettings.auto_select_upgrades != 1)
			{
				flag = false;
				flag2 = false;
			}
			else
			{
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				ConfigSaveFile config2 = saveManager2.config;
				CFGameSettings cfGameSettings2 = config2.cfGameSettings;
				bool flag3 = (float)currentLevel < cfGameSettings2.auto_select_after_level;
				flag = !flag3;
				flag2 = false;
			}
			object obj = level - num;
			if ((nint)obj > 0)
			{
				bool flag5;
				do
				{
					bool flag4 = !flag;
					UnityEngine.Object obj2 = (UnityEngine.Object)num;
					if (!flag4)
					{
						obj2 = activeEncounterWindow;
						if (activeEncounterWindow != levelupScreen)
						{
							if (IsPlayerMaxed())
							{
								break;
							}
							UpgradePicker.AutoSelectUpgrade();
							goto IL_015d;
						}
					}
					AddEncounter(EEncounter.Levelup);
					goto IL_015d;
					IL_015d:
					flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
					flag5 = (flag2 ? 1 : 0) < (nint)obj;
					num = (int)obj2;
				}
				while (flag5);
			}
			currentLevel = level;
		}
		else
		{
			currentLevel = level;
		}
	}

	private bool IsPlayerMaxed()
	{
		//IL_00f6: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null && inventory.weaponInventory != null)
			{
				bool flag = inventory.weaponInventory.IsMaxed();
				if (!flag)
				{
					return flag;
				}
				MyPlayer instance2 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInventory inventory2 = instance2.inventory;
					if (instance2.inventory != null && inventory2.tomeInventory != null)
					{
						return inventory2.tomeInventory.IsMaxed();
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public EncounterWindows()
	{
		Queue<EEncounter> queue = new Queue<EEncounter>();
		rewardQueue = queue;
		base._002Ector();
	}

	static EncounterWindows()
	{
		List<EEncounter> list = new List<EEncounter>();
		nextMapQueue = list;
	}
}
