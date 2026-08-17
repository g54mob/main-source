using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;

public class MoneyUtility
{
	public static int[] moneyTiers = new int[3] { 20, 5, 1 };

	private const float spawnInterval = 60f;

	private static float nextSilverSpawnTime = 60f;

	private static List<int> coins;

	private static Dictionary<GameObject, MoneyFlying> flyingMoneyDict;

	private static MoneyFlying lastSpawnedMoney;

	private static int chestBasePrice;

	private static int priceIncreasePerChest;

	private static int priceIncreasePerChestOver10;

	private static int priceIncreasePerChestOver20;

	private static int priceIncreasePerChestOver30;

	private static int priceIncreasePerChestOver40;

	private static int priceIncreasePerChestOver50;

	private static float chestPriceIncrease;

	private static int chestsPurchased;

	private static float bigPotMultiplier;

	private static float potMoneyFractionOfChest;

	public static Action A_ChestPriceIncreased;

	public static void Init()
	{
		//IL_0283: Expected I, but got O
		//IL_0294: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_02c6: Expected I, but got O
		//IL_02d7: Expected O, but got I4
		//IL_02ed: Expected I, but got O
		//IL_0190: Expected I, but got O
		//IL_0313: Expected I, but got O
		//IL_0324: Expected O, but got I4
		//IL_033a: Expected I, but got O
		//IL_0368: Expected O, but got I4
		//IL_037e: Expected I, but got O
		//IL_03ac: Expected O, but got I4
		//IL_03c2: Expected I, but got O
		Action<Enemy, DamageContainer> b = OnEnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyDied, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Enemy, DamageContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0430;
			}
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_02a3;
			}
		}
		Action action2 = OnNewRun;
		Delegate obj6 = Delegate.Combine(GameManager.A_RunStarted, action2);
		if ((object)obj6 == null)
		{
			GameManager.A_RunStarted = null;
		}
		else
		{
			bool flag2 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 == null;
			num2 = (nint)GameManager.A_RunStarted;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03f8;
			}
			GameManager.A_RunStarted = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num = (nint)GameManager.A_RunStarted;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0408;
			}
		}
		num = (nint)GameManager.A_StageStarted;
		Action action3 = OnNewStage;
		Delegate obj9 = Delegate.Combine(GameManager.A_StageStarted, action3);
		if ((object)obj9 == null)
		{
			GameManager.A_StageStarted = null;
			return;
		}
		bool flag6 = (object)obj9.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj9;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num5 = (nint)typeof(Action);
		if (flag7)
		{
			goto IL_0420;
		}
		GameManager.A_StageStarted = (Action)obj10;
		bool flag8 = (object)obj9.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag8)
		{
			obj11 = obj9;
		}
		bool flag9 = (object)obj11 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num6 = (nint)typeof(Action);
		if (!flag9)
		{
			return;
		}
		goto IL_0430;
		IL_0430:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0420;
		IL_02a3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0420:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0408;
		IL_0408:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03f8;
		IL_03f8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02a3;
	}

	public static void Cleanup()
	{
		//IL_0283: Expected I, but got O
		//IL_0294: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_02c6: Expected I, but got O
		//IL_02d7: Expected O, but got I4
		//IL_02ed: Expected I, but got O
		//IL_0190: Expected I, but got O
		//IL_0313: Expected I, but got O
		//IL_0324: Expected O, but got I4
		//IL_033a: Expected I, but got O
		//IL_0368: Expected O, but got I4
		//IL_037e: Expected I, but got O
		//IL_03ac: Expected O, but got I4
		//IL_03c2: Expected I, but got O
		Action<Enemy, DamageContainer> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyDied, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Enemy, DamageContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0430;
			}
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_02a3;
			}
		}
		Action action2 = OnNewRun;
		Delegate obj6 = Delegate.Remove(GameManager.A_RunStarted, action2);
		if ((object)obj6 == null)
		{
			GameManager.A_RunStarted = null;
		}
		else
		{
			bool flag2 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 == null;
			num2 = (nint)GameManager.A_RunStarted;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03f8;
			}
			GameManager.A_RunStarted = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num = (nint)GameManager.A_RunStarted;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0408;
			}
		}
		num = (nint)GameManager.A_StageStarted;
		Action action3 = OnNewStage;
		Delegate obj9 = Delegate.Remove(GameManager.A_StageStarted, action3);
		if ((object)obj9 == null)
		{
			GameManager.A_StageStarted = null;
			return;
		}
		bool flag6 = (object)obj9.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj9;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num5 = (nint)typeof(Action);
		if (flag7)
		{
			goto IL_0420;
		}
		GameManager.A_StageStarted = (Action)obj10;
		bool flag8 = (object)obj9.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag8)
		{
			obj11 = obj9;
		}
		bool flag9 = (object)obj11 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num6 = (nint)typeof(Action);
		if (!flag9)
		{
			return;
		}
		goto IL_0430;
		IL_0430:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0420;
		IL_02a3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0420:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0408;
		IL_0408:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03f8;
		IL_03f8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02a3;
	}

	private unsafe static void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
		//IL_0118: Expected O, but got I4
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected I4, but got Unknown
		//IL_0428: Expected O, but got Ref
		//IL_0213: Expected I, but got O
		//IL_021b: Expected I, but got O
		//IL_022b: Expected O, but got I
		//IL_025f: Expected I, but got O
		//IL_027d: Expected O, but got I
		//IL_02b2: Expected I, but got O
		//IL_04ff: Expected I, but got O
		//IL_02e3: Expected O, but got I
		//IL_02f9: Expected O, but got I
		//IL_032c: Expected I, but got O
		//IL_0358: Expected I, but got O
		if (MyTime.time > nextSilverSpawnTime)
		{
			SpawnSilver(enemy);
		}
		int money;
		object obj;
		if ((object)enemy != null)
		{
			money = enemy.GetMoney();
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance.inventory;
				if (instance.inventory != null)
				{
					ItemInventory itemInventory = inventory.itemInventory;
					if (inventory.itemInventory != null && itemInventory.items != null)
					{
						bool flag = ((Dictionary<System.Int32Enum, object>)(object)itemInventory.items).ContainsKey((System.Int32Enum)23);
						bool flag2 = !flag;
						obj = 0;
						nint num = 0;
						if (flag2)
						{
							goto IL_0466;
						}
						MyPlayer instance2 = MyPlayer.Instance;
						bool flag3 = (object)MyPlayer.Instance == null;
						num = 0;
						if (!flag3)
						{
							PlayerInventory inventory2 = instance2.inventory;
							bool flag4 = instance2.inventory == null;
							num = 0;
							if (!flag4)
							{
								ItemInventory itemInventory2 = inventory2.itemInventory;
								bool flag5 = inventory2.itemInventory == null;
								num = 0;
								if (!flag5)
								{
									bool flag6 = itemInventory2.items == null;
									num = 0;
									if (!flag6)
									{
										object obj2 = ((Dictionary<System.Int32Enum, object>)(object)itemInventory2.items).get_Item((System.Int32Enum)23);
										bool flag7 = obj2 == null;
										object obj3 = obj2;
										num = 0;
										if (!flag7)
										{
											nint num2 = (nint)typeof(ItemGoldenGlove);
											nint num3 = (nint)obj2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r8_v9 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemGoldenGlove>)+130]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v35 (Il2CppClass<System.Object>)+130]");
											nint num4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r8_v9 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemGoldenGlove>)+130]");
											bool flag8 = num4 < 0;
											obj3 = obj2;
											num = (nint)typeof(ItemGoldenGlove);
											if (!flag8)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v35 (Il2CppClass<System.Object>)+C8]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rcx_v30+FFFFFFF8+v377 @ rcx_v29*8]");
												bool flag9 = 0 != (nint)typeof(ItemGoldenGlove);
												obj3 = obj2;
												num = (nint)typeof(ItemGoldenGlove);
												if (!flag9)
												{
													bool flag10 = MyRandom.random == null;
													obj3 = obj2;
													num = (nint)typeof(ItemGoldenGlove);
													if (flag10)
													{
														goto IL_0429;
													}
													double num5 = MyRandom.random.NextDouble();
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v34 (System.Object)+38]");
													obj = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v34 (System.Object)+38]");
													object obj6 = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
													bool flag11 = (nint)MyRandom.random <= 0;
													obj3 = obj2;
													num = (nint)typeof(ItemGoldenGlove);
													if (!flag11)
													{
														obj3 = obj2;
														obj = obj6;
														num = (nint)typeof(ItemGoldenGlove);
													}
													goto IL_0466;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0429;
		IL_0466:
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			if (playerInventory != null && playerInventory.statusEffects != null)
			{
				int num6 = money + obj;
				if (playerInventory.statusEffects.HasStatusEffect(EStatusEffect.Stonks))
				{
					float rageCooldownMultiplier = PowerupConstants.GetRageCooldownMultiplier();
					float num7 = rageCooldownMultiplier * (float)num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
					int num8 = default(int);
					num6 = num8;
				}
				Vector3 centerPosition = enemy.GetCenterPosition();
				float num9 = default(float);
				SpawnMoney(num6, (Vector3)(&num9));
				return;
			}
		}
		goto IL_0429;
		IL_0429:
		throw new NullReferenceException();
	}

	private static void CheckSilver(Enemy enemy)
	{
		if (MyTime.time > nextSilverSpawnTime)
		{
			SpawnSilver(enemy);
		}
	}

	private unsafe static void SpawnSilver(Enemy enemy)
	{
		//IL_007a: Expected O, but got Ref
		//IL_00b9: Expected O, but got Ref
		Vector3 centerPosition = enemy.GetCenterPosition();
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.silverPool.Get();
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			float num = default(float);
			transform.position = (Vector3)(&num);
			GameObject gameObject2 = gameObject.gameObject;
			gameObject2.SetActive(value: true);
			SilverFlying component = gameObject.GetComponent<SilverFlying>();
			component.Set((Vector3)(&num));
		}
		float stat = PlayerStats.GetStat(EStat.SilverIncreaseMultiplier);
		float num2 = 60f / stat;
		float num3 = MyTime.time + num2;
		nextSilverSpawnTime = num3;
	}

	public unsafe static void SpawnSilver(Vector3 pos)
	{
		//IL_0063: Expected O, but got Ref
		//IL_00a2: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.silverPool.Get();
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			float num = default(float);
			transform.position = (Vector3)(&num);
			GameObject gameObject2 = gameObject.gameObject;
			gameObject2.SetActive(value: true);
			SilverFlying component = gameObject.GetComponent<SilverFlying>();
			component.Set((Vector3)(&num));
		}
		float stat = PlayerStats.GetStat(EStat.SilverIncreaseMultiplier);
		float num2 = 60f / stat;
		float num3 = MyTime.time + num2;
		nextSilverSpawnTime = num3;
	}

	public unsafe static void SpawnSilverNoTimerImpact(int amount, Vector3 pos)
	{
		//IL_000e: Expected O, but got I4
		//IL_016e: Expected I, but got O
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_019c: Expected O, but got Ref
		//IL_01d9: Expected O, but got Ref
		//IL_01eb: Expected I, but got O
		if (amount <= 0)
		{
			return;
		}
		object obj = 0;
		UnityEngine.Object obj3 = default(UnityEngine.Object);
		float x = default(float);
		GameObject gameObject2 = default(GameObject);
		float num3 = default(float);
		do
		{
			PoolManager instance = PoolManager.Instance;
			ObjectPool<GameObject> silverPool = instance.silverPool;
			UnityEngine.Object obj2;
			if ((nint)silverPool.m_FreshlyReleased <= 0)
			{
				List<GameObject> list = silverPool.m_List;
				if (list._size != 0)
				{
					int index = list._size - 1;
					GameObject gameObject = silverPool.m_List.get_Item(index);
					int index2 = list._size - 1;
					((List<object>)(object)silverPool.m_List).RemoveAt(index2);
					obj2 = gameObject;
				}
				else
				{
					Func<GameObject> createFunc = silverPool.m_CreateFunc;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v264 @ rax_v25 (System.Func`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
					int num = silverPool._003CCountAll_003Ek__BackingField + 1;
					silverPool._003CCountAll_003Ek__BackingField = num;
					obj2 = obj3;
				}
			}
			else
			{
				obj2 = silverPool.m_FreshlyReleased;
				silverPool.m_FreshlyReleased = null;
			}
			Action<GameObject> actionOnGet = silverPool.m_ActionOnGet;
			if (silverPool.m_ActionOnGet != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v391 @ rax_v10 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			bool flag = obj2 != null;
			bool flag2 = !flag;
			nint num2 = unchecked((nint)null);
			if (!flag2)
			{
				Transform transform = ((GameObject)obj2).transform;
				transform.position = (Vector3)(&x);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1815336B0");
				gameObject2.SetActive(value: true);
				SilverFlying component = ((GameObject)obj2).GetComponent<SilverFlying>();
				component.Set((Vector3)(&num3));
				x = pos.x;
				num2 = unchecked((nint)null);
			}
			obj++;
		}
		while ((nint)obj < amount);
	}

	private static void OnNewRun()
	{
		chestsPurchased = 0;
		flyingMoneyDict.Clear();
		lastSpawnedMoney = null;
	}

	private static void OnNewStage()
	{
		flyingMoneyDict.Clear();
		lastSpawnedMoney = null;
	}

	public static List<int> Exchange(int amount)
	{
		//IL_0027: Expected O, but got I4
		//IL_0035: Expected I, but got O
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0142: Expected I, but got O
		List<int> list = coins;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v3 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		object obj = 0;
		nint num = (nint)typeof(MoneyUtility);
		int num2 = amount;
		while (true)
		{
			int[] array = moneyTiers;
			bool flag = (nint)obj >= array.Length;
			nint num3 = num;
			if (flag)
			{
				break;
			}
			while (true)
			{
				num = num3;
				int[] array2 = moneyTiers;
				if ((nint)obj < array2.Length)
				{
					if (num2 < array2[obj])
					{
						break;
					}
					int[] array3 = moneyTiers;
					if ((nint)obj < array3.Length)
					{
						coins.Add(array3[obj]);
						int[] array4 = moneyTiers;
						if ((nint)obj < array4.Length)
						{
							num2 -= array4[obj];
							num3 = (nint)typeof(MoneyUtility);
							continue;
						}
					}
				}
				return (List<int>)(object)new IndexOutOfRangeException();
			}
			obj++;
		}
		return coins;
	}

	public unsafe static void SpawnMoney(int amount, Vector3 pos)
	{
		//IL_003a: Expected O, but got I4
		//IL_017c: Expected O, but got Ref
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_03a9: Expected O, but got I
		//IL_046e: Expected I, but got O
		//IL_03ee: Expected I, but got O
		//IL_04e2: Expected O, but got F4
		//IL_04f3: Expected O, but got Ref
		//IL_03cc: Expected O, but got I
		//IL_03d1: Expected I, but got O
		List<int> list = coins;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v1 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		object obj = 0;
		int num = amount;
		while (true)
		{
			int[] array = moneyTiers;
			if ((nint)obj >= array.Length)
			{
				break;
			}
			while (true)
			{
				int[] array2 = moneyTiers;
				if ((nint)obj < array2.Length)
				{
					if (num < array2[obj])
					{
						break;
					}
					int[] array3 = moneyTiers;
					if ((nint)obj < array3.Length)
					{
						coins.Add(array3[obj]);
						int[] array4 = moneyTiers;
						if ((nint)obj < array4.Length)
						{
							num -= array4[obj];
							continue;
						}
					}
				}
				throw new IndexOutOfRangeException();
			}
			obj++;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
		List<int>.Enumerator enumerator2 = default(List<int>.Enumerator);
		List<int>.Enumerator enumerator = enumerator2;
		nint num2 = 0;
		List<int>.Enumerator enumerator3 = default(List<int>.Enumerator);
		UnityEngine.Object obj3 = default(UnityEngine.Object);
		int num4 = default(int);
		List<int>.Enumerator enumerator4 = default(List<int>.Enumerator);
		while (true)
		{
			if (enumerator3.MoveNext())
			{
				List<object> list2 = (List<object>)(&enumerator3);
				PoolManager instance = PoolManager.Instance;
				if ((object)PoolManager.Instance != null)
				{
					ObjectPool<GameObject> goldPool = instance.goldPool;
					if (instance.goldPool != null)
					{
						UnityEngine.Object obj2;
						if ((nint)goldPool.m_FreshlyReleased <= 0)
						{
							List<GameObject> list3 = goldPool.m_List;
							if (goldPool.m_List == null)
							{
								throw new NullReferenceException();
							}
							if (list3._size != 0)
							{
								int index = list3._size - 1;
								GameObject gameObject = goldPool.m_List.get_Item(index);
								list2 = (List<object>)(object)goldPool.m_List;
								if (goldPool.m_List == null)
								{
									throw new NullReferenceException();
								}
								int index2 = list3._size - 1;
								((List<object>)(object)goldPool.m_List).RemoveAt(index2);
								obj2 = gameObject;
							}
							else
							{
								Func<GameObject> createFunc = goldPool.m_CreateFunc;
								if (goldPool.m_CreateFunc == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v590 @ rax_v106 (System.Func`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
								int num3 = goldPool._003CCountAll_003Ek__BackingField + 1;
								goldPool._003CCountAll_003Ek__BackingField = num3;
								obj2 = obj3;
							}
						}
						else
						{
							obj2 = goldPool.m_FreshlyReleased;
							goldPool.m_FreshlyReleased = null;
						}
						Action<GameObject> actionOnGet = goldPool.m_ActionOnGet;
						if (goldPool.m_ActionOnGet != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1128 @ rax_v52 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
						}
						if (!(obj2 != null))
						{
							if (!(lastSpawnedMoney == null))
							{
								bool flag = (object)lastSpawnedMoney == null;
								list2 = (List<object>)(object)lastSpawnedMoney;
								if (!flag)
								{
									lastSpawnedMoney.AddValue(num4);
									num2 = unchecked((nint)null);
									continue;
								}
								throw new NullReferenceException();
							}
							list2 = (List<object>)(object)MyPlayer.Instance;
							if ((object)MyPlayer.Instance != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rcx_v14 (System.Collections.Generic.List`1<System.Object>)+90]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rcx_v14 (System.Collections.Generic.List`1<System.Object>)+90]");
								list2 = (List<object>)0;
								if (!flag2)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rcx_v14 (System.Collections.Generic.List`1<System.Object>)+90]");
									((PlayerInventory)0).ChangeGold(num4);
									num2 = unchecked((nint)null);
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						bool flag3 = flyingMoneyDict == null;
						list2 = (List<object>)(object)flyingMoneyDict;
						if (!flag3)
						{
							if (!flyingMoneyDict.ContainsKey((GameObject)obj2))
							{
								bool flag4 = (object)obj2 == null;
								list2 = (List<object>)(object)flyingMoneyDict;
								if (flag4)
								{
									throw new NullReferenceException();
								}
								MoneyFlying component = ((GameObject)obj2).GetComponent<MoneyFlying>();
								bool flag5 = component != null;
								bool flag6 = !flag5;
								num2 = unchecked((nint)null);
								if (flag6)
								{
									continue;
								}
								bool flag7 = flyingMoneyDict == null;
								list2 = (List<object>)(object)flyingMoneyDict;
								if (flag7)
								{
									throw new NullReferenceException();
								}
								((Dictionary<object, object>)(object)flyingMoneyDict).Add((object)obj2, (object)component);
							}
							bool flag8 = flyingMoneyDict == null;
							list2 = (List<object>)(object)flyingMoneyDict;
							if (!flag8)
							{
								MoneyFlying moneyFlying = flyingMoneyDict.get_Item((GameObject)obj2);
								bool flag9 = (object)moneyFlying == null;
								list2 = (List<object>)(object)flyingMoneyDict;
								if (!flag9)
								{
									enumerator = (List<int>.Enumerator)pos.x;
									moneyFlying.Set(num4, (Vector3)(&enumerator4));
									bool flag10 = flyingMoneyDict == null;
									list2 = (List<object>)(object)flyingMoneyDict;
									if (!flag10)
									{
										MoneyFlying moneyFlying2 = flyingMoneyDict.get_Item((GameObject)obj2);
										lastSpawnedMoney = moneyFlying2;
										int[] array3 = null;
										num2 = 0;
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			enumerator3.Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public static int GetChestPrice()
	{
		//IL_0039: Expected I, but got O
		//IL_0173: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_009d: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00d1: Expected O, but got I4
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_0105: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0139: Expected O, but got I4
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		nint num = (nint)typeof(MoneyUtility);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		object obj = chestsPurchased * priceIncreasePerChest;
		object obj2;
		if (chestsPurchased <= 10)
		{
			obj2 = obj;
		}
		else
		{
			object obj3 = chestsPurchased - 10;
			object obj4 = obj3 * priceIncreasePerChestOver10;
			obj2 = obj4 + obj;
		}
		if (chestsPurchased > 20)
		{
			object obj5 = chestsPurchased - 20;
			object obj6 = obj5 * priceIncreasePerChestOver20;
			obj2 += obj6;
		}
		if (chestsPurchased > 30)
		{
			object obj7 = chestsPurchased - 30;
			object obj8 = obj7 * priceIncreasePerChestOver30;
			obj2 += obj8;
		}
		if (chestsPurchased > 40)
		{
			object obj9 = chestsPurchased - 30;
			object obj10 = obj9 * priceIncreasePerChestOver40;
			obj2 += obj10;
		}
		if (chestsPurchased > 50)
		{
			object obj11 = chestsPurchased - 30;
			object obj12 = obj11 * priceIncreasePerChestOver50;
			obj2 += obj12;
		}
		float stat = PlayerStats.GetStat(EStat.ChestPriceMultiplier);
		float num2 = (float)chestBasePrice * chestPriceIncrease;
		float num3 = num2 + (float)obj2;
		float num4 = stat * num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int result = default(int);
		return result;
	}

	public static int GetShadyguyPrice()
	{
		//IL_0027: Expected O, but got I4
		float num = (float)chestsPurchased * 0.65f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		float stat = PlayerStats.GetStat(EStat.ChestPriceMultiplier);
		object obj = MapController.index + 1;
		float num2 = (float)chestBasePrice * chestPriceIncrease;
		float num3 = num2 * (float)obj;
		float num4 = stat * num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int result = default(int);
		return result;
	}

	public static int GetItemPriceShadyGuy(EItemRarity rarity)
	{
		//IL_0027: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		float num = (float)chestsPurchased * 0.65f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		float stat = PlayerStats.GetStat(EStat.ChestPriceMultiplier);
		object obj = MapController.index + 1;
		float num2 = (float)chestBasePrice * chestPriceIncrease;
		float num3 = num2 * (float)obj;
		float num4 = stat * num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		object obj2 = rarity - 1;
		bool flag = rarity == EItemRarity.Rare;
		float num5;
		if (!flag)
		{
			object obj3 = obj2 - 1;
			num5 = (flag ? 4f : (((nint)obj3 == 1) ? 8f : 1f));
		}
		else
		{
			num5 = 2f;
		}
		object obj4 = default(object);
		float num6 = (float)obj4 * num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int result = default(int);
		return result;
	}

	public static int GetPotMoney(bool isBig)
	{
		//IL_003a: Invalid comparison between I4 and F4
		//IL_0085: Expected F4, but got I4
		//IL_0243: Expected I4, but got O
		//IL_0113: Expected I, but got O
		//IL_012f: Expected I, but got O
		//IL_0137: Expected I, but got O
		//IL_0147: Expected O, but got I
		//IL_0173: Expected I, but got O
		//IL_0191: Expected O, but got I
		//IL_01be: Expected I, but got O
		//IL_01ee: Expected O, but got I
		//IL_021b: Expected I, but got O
		float num = (isBig ? bigPotMultiplier : 1f);
		int chestPrice = GetChestPrice();
		float num2 = (float)chestPrice * potMoneyFractionOfChest;
		if (!(0f > num2))
		{
			if (num2 > 1000f)
			{
				num2 = 1000f;
			}
		}
		else
		{
			num2 = 0f;
		}
		MyPlayer instance = MyPlayer.Instance;
		float num8;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				ItemInventory itemInventory = inventory.itemInventory;
				if (inventory.itemInventory != null)
				{
					ItemBase item = inventory.itemInventory.GetItem(EItem.Pumpkin);
					bool flag = item == null;
					nint num3 = unchecked((nint)null);
					if (!flag)
					{
						nint num4 = (nint)typeof(ItemPumpkin);
						nint num5 = (nint)item;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ r8_v4 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
						itemInventory = (ItemInventory)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ r9_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ r8_v4 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
						bool flag2 = num6 < 0;
						num3 = (nint)typeof(ItemPumpkin);
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ r9_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
							ItemInventory itemInventory2 = (ItemInventory)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v12 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemInventory)+FFFFFFF8+v224 @ rcx_v9 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemInventory)*8]");
							bool flag3 = 0 != (nint)typeof(ItemPumpkin);
							num3 = (nint)typeof(ItemPumpkin);
							itemInventory = itemInventory2;
							if (!flag3)
							{
								int amount = item.amount;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v12 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase)+34]");
								object obj = (nint)amount * (nint)0;
								float num7 = (float)obj + 1f;
								num8 = num7 * num;
								num3 = (nint)typeof(ItemPumpkin);
								itemInventory = itemInventory2;
								goto IL_026f;
							}
						}
					}
					num8 = num;
					goto IL_026f;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_026f:
		float num9 = num2 * num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int result = default(int);
		return result;
	}

	public static void IncreaseChestPrice()
	{
		int num = chestsPurchased + 1;
		chestsPurchased = num;
		Action a_ChestPriceIncreased = A_ChestPriceIncreased;
		if (A_ChestPriceIncreased != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	static MoneyUtility()
	{
		List<int> list = new List<int>();
		coins = list;
		Dictionary<GameObject, MoneyFlying> dictionary = new Dictionary<GameObject, MoneyFlying>();
		flyingMoneyDict = dictionary;
		chestBasePrice = 30;
		priceIncreasePerChest = 35;
		priceIncreasePerChestOver10 = 300;
		priceIncreasePerChestOver20 = 550;
		priceIncreasePerChestOver30 = 1200;
		priceIncreasePerChestOver40 = 2400;
		priceIncreasePerChestOver50 = 4500;
		chestPriceIncrease = 1.22f;
		bigPotMultiplier = 2f;
		potMoneyFractionOfChest = 0.3f;
	}
}
