using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class KillsAndGoldCounter : MonoBehaviour
{
	public TextMeshProUGUI t_gold;

	public TextMeshProUGUI t_kills;

	public TextMeshProUGUI t_silver;

	public TextMeshProUGUI t_chestPrice;

	private string killsString;

	private bool queuedKillsUpdate;

	private bool queuedGoldUpdate;

	private void Start()
	{
		if (MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.inventory != null)
			{
				OnSilverChange(0);
				UpdateGoldCounter();
				UpdateKillCounter();
				OnChestPriceIncreased();
			}
		}
	}

	private void Awake()
	{
		//IL_05e4: Expected I, but got O
		//IL_05f5: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_01f9: Expected I, but got O
		//IL_020a: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_02c8: Expected I, but got O
		//IL_02d9: Expected O, but got I4
		//IL_031c: Expected I, but got O
		//IL_032d: Expected O, but got I4
		//IL_0714: Expected I, but got O
		//IL_075c: Expected O, but got I4
		//IL_0772: Expected I, but got O
		//IL_03fa: Expected I, but got O
		//IL_07a0: Expected O, but got I4
		//IL_07b6: Expected I, but got O
		//IL_07e4: Expected O, but got I4
		//IL_07fa: Expected I, but got O
		//IL_0828: Expected O, but got I4
		//IL_083e: Expected I, but got O
		//IL_0552: Expected I, but got O
		//IL_0563: Expected O, but got I4
		//IL_05a6: Expected I, but got O
		//IL_05b7: Expected O, but got I4
		UpdateKillCounter();
		queuedGoldUpdate = true;
		OnSilverChange(0);
		Action<PlayerInventory, int> b = OnGoldIncrease;
		Delegate obj = Delegate.Combine(PlayerInventory.A_GoldChange, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerInventory.A_GoldChange = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory, int> action = default(Action<PlayerInventory, int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerInventory, int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_085c;
			}
			PlayerInventory.A_GoldChange = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerInventory, int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0648;
			}
		}
		Action<int> b2 = OnSilverChange;
		Delegate obj6 = Delegate.Combine(ProgressionSaveFile.A_SilverChanged, b2);
		if ((object)obj6 == null)
		{
			ProgressionSaveFile.A_SilverChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_0653;
			}
			ProgressionSaveFile.A_SilverChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_0663;
			}
		}
		Action<PlayerInventory> b3 = OnInventoryInitialized;
		Delegate obj8 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b3);
		if ((object)obj8 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action3 = default(Action<PlayerInventory>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_069b;
			}
			MyPlayer.A_PlayerInventoryInitialized = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_06ab;
			}
		}
		Action<string, float> b4 = new Action<object, float>(OnRunStatChanged);
		Delegate obj10 = Delegate.Combine(RunStats.A_StatChange, b4);
		if ((object)obj10 == null)
		{
			RunStats.A_StatChange = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, float> action4 = default(Action<string, float>);
			bool flag6 = action4 == null;
			num = (nint)typeof(Action<string, float>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_06e3;
			}
			RunStats.A_StatChange = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<string, float>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_06fb;
			}
		}
		num = (nint)MoneyUtility.A_ChestPriceIncreased;
		Action action5 = OnChestPriceIncreased;
		Delegate obj12 = Delegate.Combine(MoneyUtility.A_ChestPriceIncreased, action5);
		if ((object)obj12 == null)
		{
			MoneyUtility.A_ChestPriceIncreased = null;
		}
		else
		{
			bool flag8 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag8)
			{
				obj13 = obj12;
			}
			bool flag9 = (object)obj13 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num3 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_086c;
			}
			MoneyUtility.A_ChestPriceIncreased = (Action)obj13;
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj12;
			}
			bool flag11 = (object)obj14 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num4 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_087c;
			}
		}
		num = (nint)SpawnPlayerPortal.A_PortalClosed;
		Action action6 = OnSpawnFinished;
		Delegate obj15 = Delegate.Combine(SpawnPlayerPortal.A_PortalClosed, action6);
		if ((object)obj15 == null)
		{
			SpawnPlayerPortal.A_PortalClosed = null;
		}
		else
		{
			bool flag12 = (object)obj15.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag12)
			{
				obj16 = obj15;
			}
			bool flag13 = (object)obj16 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num5 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_088c;
			}
			SpawnPlayerPortal.A_PortalClosed = (Action)obj16;
			bool flag14 = (object)obj15.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag14)
			{
				obj17 = obj15;
			}
			bool flag15 = (object)obj17 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num6 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_089c;
			}
		}
		Action<EStat> b5 = OnStatsUpdated;
		Delegate obj18 = Delegate.Combine(PlayerStatsNew.A_StatUpdate, b5);
		if ((object)obj18 == null)
		{
			PlayerStatsNew.A_StatUpdate = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStat> action7 = default(Action<EStat>);
		bool flag16 = action7 == null;
		num = (nint)typeof(Action<EStat>);
		obj2 = obj18;
		obj3 = 0;
		obj4 = null;
		if (flag16)
		{
			goto IL_084c;
		}
		PlayerStatsNew.A_StatUpdate = action7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj19 = default(object);
		bool flag17 = obj19 == null;
		num = (nint)typeof(Action<EStat>);
		obj2 = obj18;
		obj3 = 0;
		obj4 = null;
		if (!flag17)
		{
			return;
		}
		goto IL_085c;
		IL_06fb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06e3;
		IL_088c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_087c;
		IL_06e3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_06ab;
		IL_0663:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0653;
		IL_06ab:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_069b;
		IL_085c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_084c;
		IL_089c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_088c;
		IL_0648:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0653:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0648;
		IL_069b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0663;
		IL_086c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06fb;
		IL_087c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_086c;
		IL_084c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_089c;
	}

	private void OnDestroy()
	{
		//IL_05e4: Expected I, but got O
		//IL_05f5: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_01f9: Expected I, but got O
		//IL_020a: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_02c8: Expected I, but got O
		//IL_02d9: Expected O, but got I4
		//IL_031c: Expected I, but got O
		//IL_032d: Expected O, but got I4
		//IL_06d0: Expected I, but got O
		//IL_0718: Expected O, but got I4
		//IL_072e: Expected I, but got O
		//IL_03fa: Expected I, but got O
		//IL_075c: Expected O, but got I4
		//IL_0772: Expected I, but got O
		//IL_07a0: Expected O, but got I4
		//IL_07b6: Expected I, but got O
		//IL_07e4: Expected O, but got I4
		//IL_07fa: Expected I, but got O
		//IL_0552: Expected I, but got O
		//IL_0563: Expected O, but got I4
		//IL_05a6: Expected I, but got O
		//IL_05b7: Expected O, but got I4
		Action<PlayerInventory, int> value = OnGoldIncrease;
		Delegate obj = Delegate.Remove(PlayerInventory.A_GoldChange, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerInventory.A_GoldChange = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory, int> action = default(Action<PlayerInventory, int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerInventory, int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0818;
			}
			PlayerInventory.A_GoldChange = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerInventory, int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0604;
			}
		}
		Action<int> value2 = OnSilverChange;
		Delegate obj6 = Delegate.Remove(ProgressionSaveFile.A_SilverChanged, value2);
		if ((object)obj6 == null)
		{
			ProgressionSaveFile.A_SilverChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_060f;
			}
			ProgressionSaveFile.A_SilverChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_061f;
			}
		}
		Action<PlayerInventory> value3 = OnInventoryInitialized;
		Delegate obj8 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value3);
		if ((object)obj8 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action3 = default(Action<PlayerInventory>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_0657;
			}
			MyPlayer.A_PlayerInventoryInitialized = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_0667;
			}
		}
		Action<string, float> value4 = new Action<object, float>(OnRunStatChanged);
		Delegate obj10 = Delegate.Remove(RunStats.A_StatChange, value4);
		if ((object)obj10 == null)
		{
			RunStats.A_StatChange = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, float> action4 = default(Action<string, float>);
			bool flag6 = action4 == null;
			num = (nint)typeof(Action<string, float>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_069f;
			}
			RunStats.A_StatChange = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<string, float>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_06b7;
			}
		}
		num = (nint)MoneyUtility.A_ChestPriceIncreased;
		Action action5 = OnChestPriceIncreased;
		Delegate obj12 = Delegate.Remove(MoneyUtility.A_ChestPriceIncreased, action5);
		if ((object)obj12 == null)
		{
			MoneyUtility.A_ChestPriceIncreased = null;
		}
		else
		{
			bool flag8 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag8)
			{
				obj13 = obj12;
			}
			bool flag9 = (object)obj13 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num3 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_0850;
			}
			MoneyUtility.A_ChestPriceIncreased = (Action)obj13;
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj12;
			}
			bool flag11 = (object)obj14 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num4 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_0860;
			}
		}
		num = (nint)SpawnPlayerPortal.A_PortalClosed;
		Action action6 = OnSpawnFinished;
		Delegate obj15 = Delegate.Remove(SpawnPlayerPortal.A_PortalClosed, action6);
		if ((object)obj15 == null)
		{
			SpawnPlayerPortal.A_PortalClosed = null;
		}
		else
		{
			bool flag12 = (object)obj15.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag12)
			{
				obj16 = obj15;
			}
			bool flag13 = (object)obj16 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num5 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_0870;
			}
			SpawnPlayerPortal.A_PortalClosed = (Action)obj16;
			bool flag14 = (object)obj15.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag14)
			{
				obj17 = obj15;
			}
			bool flag15 = (object)obj17 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num6 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_0880;
			}
		}
		Action<EStat> value5 = OnStatsUpdated;
		Delegate obj18 = Delegate.Remove(PlayerStatsNew.A_StatUpdate, value5);
		if ((object)obj18 == null)
		{
			PlayerStatsNew.A_StatUpdate = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStat> action7 = default(Action<EStat>);
		bool flag16 = action7 == null;
		num = (nint)typeof(Action<EStat>);
		obj2 = obj18;
		obj3 = 0;
		obj4 = null;
		if (flag16)
		{
			goto IL_0808;
		}
		PlayerStatsNew.A_StatUpdate = action7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj19 = default(object);
		bool flag17 = obj19 == null;
		num = (nint)typeof(Action<EStat>);
		obj2 = obj18;
		obj3 = 0;
		obj4 = null;
		if (!flag17)
		{
			return;
		}
		goto IL_0818;
		IL_06b7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_069f;
		IL_0870:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0860;
		IL_069f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0667;
		IL_061f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_060f;
		IL_0667:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0657;
		IL_0818:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0808;
		IL_0880:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0870;
		IL_0604:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_060f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0604;
		IL_0657:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_061f;
		IL_0850:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06b7;
		IL_0860:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0850;
		IL_0808:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0880;
	}

	private void OnInventoryInitialized(PlayerInventory inv)
	{
		OnSilverChange(0);
		UpdateGoldCounter();
		UpdateKillCounter();
		OnChestPriceIncreased();
	}

	private void Update()
	{
		if (queuedKillsUpdate)
		{
			UpdateKillCounter();
		}
		if (queuedGoldUpdate)
		{
			UpdateGoldCounter();
		}
	}

	private void OnRunStatChanged(string stat, float value)
	{
		if (stat == killsString)
		{
			queuedKillsUpdate = true;
		}
	}

	private void OnGoldIncrease(PlayerInventory inv, int amount)
	{
		queuedGoldUpdate = true;
	}

	private void UpdateKillCounter()
	{
		queuedKillsUpdate = false;
		int stat = RunStats.GetStat(EMyStat.kills);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"<size=120%><sprite name=skull></size> {arg:N0}";
		t_kills.text = text;
	}

	private void UpdateGoldCounter()
	{
		queuedGoldUpdate = false;
		MyPlayer instance = MyPlayer.Instance;
		string text;
		if (instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			double num = Math.Floor(inventory._003Cgold_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			text = $"<size=110%><sprite name=gold></size> {arg:N0}";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			text = $"<size=110%><sprite name=gold></size> {arg2:N0}";
		}
		t_gold.text = text;
	}

	private void OnSilverChange(int delta)
	{
		//IL_0069: Expected F8, but got I4
		string text;
		if (SaveManager._003CInstance_003Ek__BackingField != null)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression = saveManager.progression;
			double num = Math.Floor((double)progression.silver);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			text = $"<size=110%><sprite name=silver></size> {arg:N0}";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			text = $"<size=110%><sprite name=silver></size> {arg2:N0}";
		}
		t_silver.text = text;
	}

	private void OnChestPriceIncreased()
	{
		int chestPrice = MoneyUtility.GetChestPrice();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"<size=115%><sprite name=chest></size><sprite name=gold>{arg}";
		t_chestPrice.text = text;
	}

	private void OnSpawnFinished()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F52]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		OnChestPriceIncreased();
		Invoke("OnChestPriceIncreased", 0.1f);
	}

	private void OnStatsUpdated(EStat stat)
	{
		if (stat == EStat.ChestPriceMultiplier && PlayerStats.HasStats())
		{
			OnChestPriceIncreased();
		}
	}

	public unsafe KillsAndGoldCounter()
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		killsString = ((Enum)(&obj)).ToString();
		base._002Ector();
	}
}
