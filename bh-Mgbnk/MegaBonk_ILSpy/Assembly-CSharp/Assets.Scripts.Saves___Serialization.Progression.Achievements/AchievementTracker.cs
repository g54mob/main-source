using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts._Data;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning.New;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Chests;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Tools;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Saves___Serialization.Progression.Achievements;

public static class AchievementTracker
{
	private static float baseMovementSpeed;

	private static float noDamageTimer;

	private static bool hasTakenDamageThisRun;

	private static bool hasDealtDamageThisRun;

	private static int consecutiveIceCrystalCooks;

	private static int consecutiveMoldyCheeseCooks;

	private static int runChestsBought;

	private static bool hasSpawnedLuckTomeQuest;

	private static string a_tacticalGlasses;

	private static string a_bossBuster;

	private static string a_luckTome;

	private static string a_quinsMask;

	private static string a_roberto;

	private static string a_hatSheriff;

	private static string aegisDamageSource;

	private static int chargedShrines;

	private static int chargedShrinesNoInterruptions;

	private static int totalChargeShrines;

	private static string a_hatPot;

	private static string a_kevin;

	private static int numBoomboxes;

	private static string a_hatTophat;

	private static string a_hatTophatLong;

	public static void Init()
	{
		//IL_1afb: Expected I, but got O
		//IL_1b04: Expected O, but got I4
		//IL_1b77: Expected O, but got I4
		//IL_1b8d: Expected I, but got O
		//IL_1bb3: Expected O, but got I4
		//IL_1bc9: Expected I, but got O
		//IL_1bef: Expected O, but got I4
		//IL_1c05: Expected I, but got O
		//IL_1c53: Expected O, but got I4
		//IL_1c69: Expected I, but got O
		//IL_1c8f: Expected O, but got I4
		//IL_1ca5: Expected I, but got O
		//IL_0292: Expected I, but got O
		//IL_02a3: Expected O, but got I4
		//IL_02e6: Expected I, but got O
		//IL_02f7: Expected O, but got I4
		//IL_0389: Expected I, but got O
		//IL_039a: Expected O, but got I4
		//IL_03dd: Expected I, but got O
		//IL_03ee: Expected O, but got I4
		//IL_0480: Expected I, but got O
		//IL_0491: Expected O, but got I4
		//IL_04d4: Expected I, but got O
		//IL_04e5: Expected O, but got I4
		//IL_0577: Expected I, but got O
		//IL_0588: Expected O, but got I4
		//IL_05cb: Expected I, but got O
		//IL_05dc: Expected O, but got I4
		//IL_066e: Expected I, but got O
		//IL_067f: Expected O, but got I4
		//IL_06c2: Expected I, but got O
		//IL_06d3: Expected O, but got I4
		//IL_0765: Expected I, but got O
		//IL_0776: Expected O, but got I4
		//IL_257d: Expected I, but got O
		//IL_07b9: Expected I, but got O
		//IL_07ca: Expected O, but got I4
		//IL_1ddb: Expected I, but got O
		//IL_1dec: Expected O, but got I4
		//IL_1e02: Expected I, but got O
		//IL_1e28: Expected I, but got O
		//IL_1e39: Expected O, but got I4
		//IL_1e4f: Expected I, but got O
		//IL_08e5: Expected I, but got O
		//IL_08f6: Expected O, but got I4
		//IL_0939: Expected I, but got O
		//IL_094a: Expected O, but got I4
		//IL_1ebc: Expected I, but got O
		//IL_1ecd: Expected O, but got I4
		//IL_1ee3: Expected I, but got O
		//IL_1f11: Expected O, but got I4
		//IL_1f27: Expected I, but got O
		//IL_0aa7: Expected O, but got I4
		//IL_0afb: Expected O, but got I4
		//IL_1fce: Expected O, but got I4
		//IL_1fe4: Expected I, but got O
		//IL_2012: Expected O, but got I4
		//IL_2028: Expected I, but got O
		//IL_0c4f: Expected O, but got I4
		//IL_0ca3: Expected O, but got I4
		//IL_0d46: Expected O, but got I4
		//IL_0d9a: Expected O, but got I4
		//IL_0e3d: Expected O, but got I4
		//IL_0e91: Expected O, but got I4
		//IL_0f34: Expected O, but got I4
		//IL_0f88: Expected O, but got I4
		//IL_102b: Expected O, but got I4
		//IL_107f: Expected O, but got I4
		//IL_10fa: Expected O, but got I4
		//IL_114e: Expected O, but got I4
		//IL_11c9: Expected O, but got I4
		//IL_121d: Expected O, but got I4
		//IL_1298: Expected O, but got I4
		//IL_12ec: Expected O, but got I4
		//IL_1367: Expected O, but got I4
		//IL_13bb: Expected O, but got I4
		//IL_145e: Expected O, but got I4
		//IL_14b2: Expected O, but got I4
		//IL_2236: Expected O, but got I4
		//IL_224c: Expected I, but got O
		//IL_227a: Expected O, but got I4
		//IL_2290: Expected I, but got O
		//IL_22ef: Expected O, but got I4
		//IL_2305: Expected I, but got O
		//IL_2333: Expected O, but got I4
		//IL_2349: Expected I, but got O
		//IL_16e8: Expected O, but got I4
		//IL_173c: Expected O, but got I4
		//IL_17df: Expected O, but got I4
		//IL_1833: Expected O, but got I4
		//IL_18ae: Expected O, but got I4
		//IL_1902: Expected O, but got I4
		//IL_23ff: Expected O, but got I4
		//IL_2415: Expected I, but got O
		//IL_2443: Expected O, but got I4
		//IL_2459: Expected I, but got O
		//IL_2487: Expected O, but got I4
		//IL_249d: Expected I, but got O
		//IL_24d0: Expected I, but got O
		//IL_24d9: Expected O, but got I4
		Delegate obj = GameManager.A_RunStarted;
		Action action = OnRunStarted;
		Delegate obj2 = Delegate.Combine(GameManager.A_RunStarted, action);
		Action action2;
		nint num;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_RunStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				num = (nint)typeof(Action);
				obj4 = 0;
				obj5 = obj2;
				goto IL_261a;
			}
			GameManager.A_RunStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_24ef;
			}
		}
		Action b = OnStageStarted;
		Delegate obj7 = Delegate.Combine(GameManager.A_StageStarted, b);
		if ((object)obj7 == null)
		{
			GameManager.A_StageStarted = null;
		}
		else
		{
			bool flag4 = (object)obj7.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj7;
			}
			bool flag5 = (object)obj8 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_24fa;
			}
			GameManager.A_StageStarted = (Action)obj8;
			bool flag6 = (object)obj7.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag6)
			{
				obj9 = obj7;
			}
			bool flag7 = (object)obj9 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_250a;
			}
		}
		Action b2 = OnTick;
		Delegate obj10 = Delegate.Combine(MyTime.A_Tick, b2);
		if ((object)obj10 == null)
		{
			MyTime.A_Tick = null;
		}
		else
		{
			bool flag8 = (object)obj10.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag8)
			{
				obj11 = obj10;
			}
			bool flag9 = (object)obj11 == null;
			obj4 = 0;
			obj5 = obj10;
			nint num5 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_251a;
			}
			MyTime.A_Tick = (Action)obj11;
			bool flag10 = (object)obj10.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag10)
			{
				obj12 = obj10;
			}
			bool flag11 = (object)obj12 == null;
			obj4 = 0;
			obj5 = obj10;
			nint num6 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_252a;
			}
		}
		Action<Enemy, DamageContainer> b3 = OnEnemyDied;
		Delegate obj13 = Delegate.Combine(Enemy.A_EnemyDied, b3);
		nint num7;
		Delegate obj14;
		if ((object)obj13 == null)
		{
			Enemy.A_EnemyDied = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action3 = default(Action<Enemy, DamageContainer>);
			bool flag12 = action3 == null;
			num7 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj14 = obj13;
			obj4 = 0;
			obj5 = null;
			if (flag12)
			{
				goto IL_1cdb;
			}
			Enemy.A_EnemyDied = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj15 = default(object);
			bool flag13 = obj15 == null;
			num7 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj14 = obj13;
			obj4 = 0;
			obj5 = null;
			if (flag13)
			{
				goto IL_1ceb;
			}
		}
		Action<Enemy, DamageContainer> b4 = OnEnemyDamaged;
		Delegate obj16 = Delegate.Combine(Enemy.A_Damage, b4);
		if ((object)obj16 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action4 = default(Action<Enemy, DamageContainer>);
			bool flag14 = action4 == null;
			num7 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj14 = obj16;
			obj4 = 0;
			obj5 = null;
			if (flag14)
			{
				goto IL_1cfb;
			}
			Enemy.A_Damage = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj17 = default(object);
			bool flag15 = obj17 == null;
			num7 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj14 = obj16;
			obj4 = 0;
			obj5 = null;
			if (flag15)
			{
				goto IL_1d0b;
			}
		}
		Action<bool> b5 = OnStageBossDefeated;
		Delegate obj18 = Delegate.Combine(InteractableBossSpawner.A_BossDefeated, b5);
		if ((object)obj18 == null)
		{
			InteractableBossSpawner.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action5 = default(Action<bool>);
			bool flag16 = action5 == null;
			num7 = (nint)typeof(Action<bool>);
			obj14 = obj18;
			obj4 = 0;
			obj5 = null;
			if (flag16)
			{
				goto IL_1d1b;
			}
			InteractableBossSpawner.A_BossDefeated = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj19 = default(object);
			bool flag17 = obj19 == null;
			num7 = (nint)typeof(Action<bool>);
			obj14 = obj18;
			obj4 = 0;
			obj5 = null;
			if (flag17)
			{
				goto IL_1d2b;
			}
		}
		Action<int> b6 = OnStageBossDefeatedNum;
		Delegate obj20 = Delegate.Combine(InteractableBossSpawner.A_NumBossesDefeated, b6);
		if ((object)obj20 == null)
		{
			InteractableBossSpawner.A_NumBossesDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action6 = default(Action<int>);
			bool flag18 = action6 == null;
			num7 = (nint)typeof(Action<int>);
			obj14 = obj20;
			obj4 = 0;
			obj5 = null;
			if (flag18)
			{
				goto IL_1d3b;
			}
			InteractableBossSpawner.A_NumBossesDefeated = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj21 = default(object);
			bool flag19 = obj21 == null;
			num7 = (nint)typeof(Action<int>);
			obj14 = obj20;
			obj4 = 0;
			obj5 = null;
			if (flag19)
			{
				goto IL_1d4b;
			}
		}
		Action<bool> b7 = OnStageBossDefeated;
		Delegate obj22 = Delegate.Combine(FinalFightController.A_BossDefeated, b7);
		if ((object)obj22 == null)
		{
			FinalFightController.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action7 = default(Action<bool>);
			bool flag20 = action7 == null;
			num7 = (nint)typeof(Action<bool>);
			obj14 = obj22;
			obj4 = 0;
			obj5 = null;
			if (flag20)
			{
				goto IL_1d5b;
			}
			FinalFightController.A_BossDefeated = action7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj23 = default(object);
			bool flag21 = obj23 == null;
			num7 = (nint)typeof(Action<bool>);
			obj14 = obj22;
			obj4 = 0;
			obj5 = null;
			if (flag21)
			{
				goto IL_1d6b;
			}
		}
		Action<float> b8 = OnStageBossDefeatedInTime;
		Delegate obj24 = Delegate.Combine(FinalFightController.A_BossDefeatedTime, b8);
		if ((object)obj24 == null)
		{
			FinalFightController.A_BossDefeatedTime = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action8 = default(Action<float>);
			bool flag22 = action8 == null;
			num7 = (nint)typeof(Action<float>);
			obj14 = obj24;
			obj4 = 0;
			obj5 = null;
			if (flag22)
			{
				goto IL_1d7b;
			}
			FinalFightController.A_BossDefeatedTime = action8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj25 = default(object);
			bool flag23 = obj25 == null;
			num7 = (nint)typeof(Action<float>);
			obj14 = obj24;
			obj4 = 0;
			obj5 = null;
			if (flag23)
			{
				goto IL_1d8b;
			}
		}
		Action action9 = OnChestBought;
		Delegate obj26 = Delegate.Combine(InteractableChest.A_ChestBought, action9);
		if ((object)obj26 == null)
		{
			InteractableChest.A_ChestBought = null;
		}
		else
		{
			bool flag24 = (object)obj26.GetType() != typeof(Action);
			Delegate obj27 = null;
			if (!flag24)
			{
				obj27 = obj26;
			}
			bool flag25 = (object)obj27 == null;
			num7 = (nint)InteractableChest.A_ChestBought;
			obj14 = action9;
			obj4 = 0;
			obj5 = obj26;
			nint num8 = (nint)typeof(Action);
			if (flag25)
			{
				goto IL_253a;
			}
			InteractableChest.A_ChestBought = (Action)obj27;
			bool flag26 = (object)obj26.GetType() != typeof(Action);
			Delegate obj28 = null;
			if (!flag26)
			{
				obj28 = obj26;
			}
			bool flag27 = (object)obj28 == null;
			num7 = (nint)InteractableChest.A_ChestBought;
			obj14 = action9;
			obj4 = 0;
			obj5 = obj26;
			nint num9 = (nint)typeof(Action);
			if (flag27)
			{
				goto IL_254a;
			}
		}
		Action<bool> b9 = OnShrineCharged;
		Delegate obj29 = Delegate.Combine(ChargeShrine.A_Charged, b9);
		if ((object)obj29 == null)
		{
			ChargeShrine.A_Charged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action10 = default(Action<bool>);
			bool flag28 = action10 == null;
			num7 = (nint)typeof(Action<bool>);
			obj14 = obj29;
			obj4 = 0;
			obj5 = null;
			if (flag28)
			{
				goto IL_1e85;
			}
			ChargeShrine.A_Charged = action10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj30 = default(object);
			bool flag29 = obj30 == null;
			num7 = (nint)typeof(Action<bool>);
			obj14 = obj29;
			obj4 = 0;
			obj5 = null;
			if (flag29)
			{
				goto IL_1e95;
			}
		}
		obj = ChargeShrine.A_ChargeShrineSpawned;
		Action action11 = OnChargeShrineSpawned;
		Delegate obj31 = Delegate.Combine(ChargeShrine.A_ChargeShrineSpawned, action11);
		if ((object)obj31 == null)
		{
			ChargeShrine.A_ChargeShrineSpawned = null;
		}
		else
		{
			bool flag30 = (object)obj31.GetType() != typeof(Action);
			Delegate obj32 = null;
			if (!flag30)
			{
				obj32 = obj31;
			}
			bool flag31 = (object)obj32 == null;
			num7 = (nint)obj;
			obj14 = action11;
			obj4 = 0;
			obj5 = obj31;
			nint num10 = (nint)typeof(Action);
			if (flag31)
			{
				goto IL_255a;
			}
			ChargeShrine.A_ChargeShrineSpawned = (Action)obj32;
			bool flag32 = (object)obj31.GetType() != typeof(Action);
			Delegate obj33 = null;
			if (!flag32)
			{
				obj33 = obj31;
			}
			bool flag33 = (object)obj33 == null;
			action2 = action11;
			obj4 = 0;
			obj5 = obj31;
			nint num11 = (nint)typeof(Action);
			if (flag33)
			{
				goto IL_256a;
			}
		}
		Action<EItem> b10 = OnMicrowaveUsed;
		Delegate obj34 = Delegate.Combine(InteractableMicrowave.A_Used, b10);
		if ((object)obj34 == null)
		{
			InteractableMicrowave.A_Used = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action12 = default(Action<EItem>);
			bool flag34 = action12 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj34;
			obj4 = 0;
			obj5 = null;
			if (flag34)
			{
				goto IL_1f5d;
			}
			InteractableMicrowave.A_Used = action12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj35 = default(object);
			bool flag35 = obj35 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj34;
			obj4 = 0;
			obj5 = null;
			if (flag35)
			{
				goto IL_1f6d;
			}
		}
		obj = GraveyardBossRoom.A_BossDied;
		Action action13 = OnGhostBossDied;
		Delegate obj36 = Delegate.Combine(GraveyardBossRoom.A_BossDied, action13);
		if ((object)obj36 == null)
		{
			GraveyardBossRoom.A_BossDied = null;
		}
		else
		{
			bool flag36 = (object)obj36.GetType() != typeof(Action);
			Delegate obj37 = null;
			if (!flag36)
			{
				obj37 = obj36;
			}
			bool flag37 = (object)obj37 == null;
			action2 = action13;
			obj4 = 0;
			obj5 = obj36;
			nint num12 = (nint)typeof(Action);
			if (flag37)
			{
				goto IL_258a;
			}
			GraveyardBossRoom.A_BossDied = (Action)obj37;
			bool flag38 = (object)obj36.GetType() != typeof(Action);
			Delegate obj38 = null;
			if (!flag38)
			{
				obj38 = obj36;
			}
			bool flag39 = (object)obj38 == null;
			action2 = action13;
			obj4 = 0;
			obj5 = obj36;
			nint num13 = (nint)typeof(Action);
			if (flag39)
			{
				goto IL_259a;
			}
		}
		Action<EStat> b11 = OnStatUpdate;
		Delegate obj39 = Delegate.Combine(PlayerStatsNew.A_StatUpdate, b11);
		if ((object)obj39 == null)
		{
			PlayerStatsNew.A_StatUpdate = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action14 = default(Action<EStat>);
			bool flag40 = action14 == null;
			obj = (Delegate)(object)typeof(Action<EStat>);
			action2 = (Action)obj39;
			obj4 = 0;
			obj5 = null;
			if (flag40)
			{
				goto IL_2036;
			}
			PlayerStatsNew.A_StatUpdate = action14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj40 = default(object);
			bool flag41 = obj40 == null;
			obj = (Delegate)(object)typeof(Action<EStat>);
			action2 = (Action)obj39;
			obj4 = 0;
			obj5 = null;
			if (flag41)
			{
				goto IL_2046;
			}
		}
		Action<WeaponBase> b12 = OnWeaponAddedOrUpgraded;
		Delegate obj41 = Delegate.Combine(WeaponInventory.A_WeaponAdded, b12);
		if ((object)obj41 == null)
		{
			WeaponInventory.A_WeaponAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action15 = default(Action<WeaponBase>);
			bool flag42 = action15 == null;
			obj = (Delegate)(object)typeof(Action<WeaponBase>);
			action2 = (Action)obj41;
			obj4 = 0;
			obj5 = null;
			if (flag42)
			{
				goto IL_2056;
			}
			WeaponInventory.A_WeaponAdded = action15;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj42 = default(object);
			bool flag43 = obj42 == null;
			obj = (Delegate)(object)typeof(Action<WeaponBase>);
			action2 = (Action)obj41;
			obj4 = 0;
			obj5 = null;
			if (flag43)
			{
				goto IL_2066;
			}
		}
		Action<ETome, EStat> b13 = OnTomeAddedOrUpgraded;
		Delegate obj43 = Delegate.Combine(TomeInventory.A_TomeUpgrade, b13);
		if ((object)obj43 == null)
		{
			TomeInventory.A_TomeUpgrade = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ETome, EStat> action16 = default(Action<ETome, EStat>);
			bool flag44 = action16 == null;
			obj = (Delegate)(object)typeof(Action<ETome, EStat>);
			action2 = (Action)obj43;
			obj4 = 0;
			obj5 = null;
			if (flag44)
			{
				goto IL_2076;
			}
			TomeInventory.A_TomeUpgrade = action16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj44 = default(object);
			bool flag45 = obj44 == null;
			obj = (Delegate)(object)typeof(Action<ETome, EStat>);
			action2 = (Action)obj43;
			obj4 = 0;
			obj5 = null;
			if (flag45)
			{
				goto IL_2086;
			}
		}
		Action<Pickup> b14 = OnPickupTriggered;
		Delegate obj45 = Delegate.Combine(Pickup.A_PickupTriggered, b14);
		if ((object)obj45 == null)
		{
			Pickup.A_PickupTriggered = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action17 = default(Action<Pickup>);
			bool flag46 = action17 == null;
			obj = (Delegate)(object)typeof(Action<Pickup>);
			action2 = (Action)obj45;
			obj4 = 0;
			obj5 = null;
			if (flag46)
			{
				goto IL_2096;
			}
			Pickup.A_PickupTriggered = action17;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj46 = default(object);
			bool flag47 = obj46 == null;
			obj = (Delegate)(object)typeof(Action<Pickup>);
			action2 = (Action)obj45;
			obj4 = 0;
			obj5 = null;
			if (flag47)
			{
				goto IL_20a6;
			}
		}
		Action<EItem> b15 = OnItemAdded;
		Delegate obj47 = Delegate.Combine(ItemInventory.A_ItemAdded, b15);
		if ((object)obj47 == null)
		{
			ItemInventory.A_ItemAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action18 = default(Action<EItem>);
			bool flag48 = action18 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj47;
			obj4 = 0;
			obj5 = null;
			if (flag48)
			{
				goto IL_20b6;
			}
			ItemInventory.A_ItemAdded = action18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj48 = default(object);
			bool flag49 = obj48 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj47;
			obj4 = 0;
			obj5 = null;
			if (flag49)
			{
				goto IL_20c6;
			}
		}
		Action<int> b16 = OnLevelUp;
		Delegate obj49 = Delegate.Combine(PlayerXp.A_LevelUp, b16);
		if ((object)obj49 == null)
		{
			PlayerXp.A_LevelUp = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action19 = default(Action<int>);
			bool flag50 = action19 == null;
			obj = (Delegate)(object)typeof(Action<int>);
			action2 = (Action)obj49;
			obj4 = 0;
			obj5 = null;
			if (flag50)
			{
				goto IL_20fe;
			}
			PlayerXp.A_LevelUp = action19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj50 = default(object);
			bool flag51 = obj50 == null;
			obj = (Delegate)(object)typeof(Action<int>);
			action2 = (Action)obj49;
			obj4 = 0;
			obj5 = null;
			if (flag51)
			{
				goto IL_210e;
			}
		}
		Action<PlayerInventory> b17 = OnPLayerInventoryInited;
		Delegate obj51 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b17);
		if ((object)obj51 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action20 = default(Action<PlayerInventory>);
			bool flag52 = action20 == null;
			obj = (Delegate)(object)typeof(Action<PlayerInventory>);
			action2 = (Action)obj51;
			obj4 = 0;
			obj5 = null;
			if (flag52)
			{
				goto IL_2146;
			}
			MyPlayer.A_PlayerInventoryInitialized = action20;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj52 = default(object);
			bool flag53 = obj52 == null;
			obj = (Delegate)(object)typeof(Action<PlayerInventory>);
			action2 = (Action)obj51;
			obj4 = 0;
			obj5 = null;
			if (flag53)
			{
				goto IL_2156;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> b18 = new Action<object, object, bool>(OnDamageTaken);
		Delegate obj53 = Delegate.Combine(PlayerHealth.A_TakeDamage, b18);
		if ((object)obj53 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action21 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag54 = action21 == null;
			obj = (Delegate)(object)typeof(Action<PlayerHealth, DamageContainer, bool>);
			action2 = (Action)obj53;
			obj4 = 0;
			obj5 = null;
			if (flag54)
			{
				goto IL_218e;
			}
			PlayerHealth.A_TakeDamage = action21;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj54 = default(object);
			bool flag55 = obj54 == null;
			obj = (Delegate)(object)typeof(Action<PlayerHealth, DamageContainer, bool>);
			action2 = (Action)obj53;
			obj4 = 0;
			obj5 = null;
			if (flag55)
			{
				goto IL_219e;
			}
		}
		Action<MyAchievement> b19 = OnUnlock;
		Delegate obj55 = Delegate.Combine(MyAchievements.A_Unlocked, b19);
		if ((object)obj55 == null)
		{
			MyAchievements.A_Unlocked = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyAchievement> action22 = default(Action<MyAchievement>);
			bool flag56 = action22 == null;
			obj = (Delegate)(object)typeof(Action<MyAchievement>);
			action2 = (Action)obj55;
			obj4 = 0;
			obj5 = null;
			if (flag56)
			{
				goto IL_21d6;
			}
			MyAchievements.A_Unlocked = action22;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj56 = default(object);
			bool flag57 = obj56 == null;
			obj = (Delegate)(object)typeof(Action<MyAchievement>);
			action2 = (Action)obj55;
			obj4 = 0;
			obj5 = null;
			if (flag57)
			{
				goto IL_21e6;
			}
		}
		Action<UnlockableBase> b20 = OnPurchased;
		Delegate obj57 = Delegate.Combine(UnlocksFooter.A_Purchased, b20);
		if ((object)obj57 == null)
		{
			UnlocksFooter.A_Purchased = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<UnlockableBase> action23 = default(Action<UnlockableBase>);
			bool flag58 = action23 == null;
			obj = (Delegate)(object)typeof(Action<UnlockableBase>);
			action2 = (Action)obj57;
			obj4 = 0;
			obj5 = null;
			if (flag58)
			{
				goto IL_21f6;
			}
			UnlocksFooter.A_Purchased = action23;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj58 = default(object);
			bool flag59 = obj58 == null;
			obj = (Delegate)(object)typeof(Action<UnlockableBase>);
			action2 = (Action)obj57;
			obj4 = 0;
			obj5 = null;
			if (flag59)
			{
				goto IL_2206;
			}
		}
		obj = SummonerController.A_FinalSwarmStarted;
		Action action24 = OnFinalSwarmStart;
		Delegate obj59 = Delegate.Combine(SummonerController.A_FinalSwarmStarted, action24);
		if ((object)obj59 == null)
		{
			SummonerController.A_FinalSwarmStarted = null;
		}
		else
		{
			bool flag60 = (object)obj59.GetType() != typeof(Action);
			Delegate obj60 = null;
			if (!flag60)
			{
				obj60 = obj59;
			}
			bool flag61 = (object)obj60 == null;
			action2 = action24;
			obj4 = 0;
			obj5 = obj59;
			nint num14 = (nint)typeof(Action);
			if (flag61)
			{
				goto IL_25aa;
			}
			SummonerController.A_FinalSwarmStarted = (Action)obj60;
			bool flag62 = (object)obj59.GetType() != typeof(Action);
			Delegate obj61 = null;
			if (!flag62)
			{
				obj61 = obj59;
			}
			bool flag63 = (object)obj61 == null;
			action2 = action24;
			obj4 = 0;
			obj5 = obj59;
			nint num15 = (nint)typeof(Action);
			if (flag63)
			{
				goto IL_25ba;
			}
		}
		obj = TrackStats.A_PotBroken;
		Action action25 = OnPotBroken;
		Delegate obj62 = Delegate.Combine(TrackStats.A_PotBroken, action25);
		if ((object)obj62 == null)
		{
			TrackStats.A_PotBroken = null;
		}
		else
		{
			bool flag64 = (object)obj62.GetType() != typeof(Action);
			Delegate obj63 = null;
			if (!flag64)
			{
				obj63 = obj62;
			}
			bool flag65 = (object)obj63 == null;
			action2 = action25;
			obj4 = 0;
			obj5 = obj62;
			nint num16 = (nint)typeof(Action);
			if (flag65)
			{
				goto IL_25ca;
			}
			TrackStats.A_PotBroken = (Action)obj63;
			bool flag66 = (object)obj62.GetType() != typeof(Action);
			Delegate obj64 = null;
			if (!flag66)
			{
				obj64 = obj62;
			}
			bool flag67 = (object)obj64 == null;
			action2 = action25;
			obj4 = 0;
			obj5 = obj62;
			nint num17 = (nint)typeof(Action);
			if (flag67)
			{
				goto IL_25da;
			}
		}
		Action<BaseInteractable, bool> b21 = OnInteracted;
		Delegate obj65 = Delegate.Combine(DetectInteractables.A_Interacted, b21);
		if ((object)obj65 == null)
		{
			DetectInteractables.A_Interacted = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<BaseInteractable, bool> action26 = default(Action<BaseInteractable, bool>);
			bool flag68 = action26 == null;
			obj = (Delegate)(object)typeof(Action<BaseInteractable, bool>);
			action2 = (Action)obj65;
			obj4 = 0;
			obj5 = null;
			if (flag68)
			{
				goto IL_2357;
			}
			DetectInteractables.A_Interacted = action26;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj66 = default(object);
			bool flag69 = obj66 == null;
			obj = (Delegate)(object)typeof(Action<BaseInteractable, bool>);
			action2 = (Action)obj65;
			obj4 = 0;
			obj5 = null;
			if (flag69)
			{
				goto IL_2367;
			}
		}
		Action<float> b22 = OnCryptSpeedrun;
		Delegate obj67 = Delegate.Combine(InteractableCryptLeave.A_FirstDungeonCompleted, b22);
		if ((object)obj67 == null)
		{
			InteractableCryptLeave.A_FirstDungeonCompleted = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action27 = default(Action<float>);
			bool flag70 = action27 == null;
			obj = (Delegate)(object)typeof(Action<float>);
			action2 = (Action)obj67;
			obj4 = 0;
			obj5 = null;
			if (flag70)
			{
				goto IL_2377;
			}
			InteractableCryptLeave.A_FirstDungeonCompleted = action27;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj68 = default(object);
			bool flag71 = obj68 == null;
			obj = (Delegate)(object)typeof(Action<float>);
			action2 = (Action)obj67;
			obj4 = 0;
			obj5 = null;
			if (flag71)
			{
				goto IL_2387;
			}
		}
		Action<string> b23 = OnInteractableUsedDebug;
		Delegate obj69 = Delegate.Combine(InteractablesStatus.A_InteractableUsed, b23);
		if ((object)obj69 == null)
		{
			InteractablesStatus.A_InteractableUsed = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action28 = default(Action<string>);
			bool flag72 = action28 == null;
			obj = (Delegate)(object)typeof(Action<string>);
			action2 = (Action)obj69;
			obj4 = 0;
			obj5 = null;
			if (flag72)
			{
				goto IL_23bf;
			}
			InteractablesStatus.A_InteractableUsed = action28;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj70 = default(object);
			bool flag73 = obj70 == null;
			obj = (Delegate)(object)typeof(Action<string>);
			action2 = (Action)obj69;
			obj4 = 0;
			obj5 = null;
			if (flag73)
			{
				goto IL_23cf;
			}
		}
		obj = MainMenu.A_MenuOpened;
		Action action29 = OnMainMenuOpened;
		Delegate obj71 = Delegate.Combine(MainMenu.A_MenuOpened, action29);
		if ((object)obj71 == null)
		{
			MainMenu.A_MenuOpened = null;
		}
		else
		{
			bool flag74 = (object)obj71.GetType() != typeof(Action);
			Delegate obj72 = null;
			if (!flag74)
			{
				obj72 = obj71;
			}
			bool flag75 = (object)obj72 == null;
			action2 = action29;
			obj4 = 0;
			obj5 = obj71;
			nint num18 = (nint)typeof(Action);
			if (flag75)
			{
				goto IL_25ea;
			}
			MainMenu.A_MenuOpened = (Action)obj72;
			bool flag76 = (object)obj71.GetType() != typeof(Action);
			Delegate obj73 = null;
			if (!flag76)
			{
				obj73 = obj71;
			}
			bool flag77 = (object)obj73 == null;
			action2 = action29;
			obj4 = 0;
			obj5 = obj71;
			nint num19 = (nint)typeof(Action);
			if (flag77)
			{
				goto IL_25fa;
			}
		}
		obj = LateFixedUpdate.A_LateUpdate;
		Action action30 = OnLateFixedUpdate;
		Delegate obj74 = Delegate.Combine(LateFixedUpdate.A_LateUpdate, action30);
		if ((object)obj74 == null)
		{
			LateFixedUpdate.A_LateUpdate = null;
			return;
		}
		bool flag78 = (object)obj74.GetType() != typeof(Action);
		Delegate obj75 = null;
		if (!flag78)
		{
			obj75 = obj74;
		}
		bool flag79 = (object)obj75 == null;
		action2 = action30;
		obj4 = 0;
		obj5 = obj74;
		nint num20 = (nint)typeof(Action);
		if (flag79)
		{
			goto IL_260a;
		}
		LateFixedUpdate.A_LateUpdate = (Action)obj75;
		bool flag80 = (object)obj74.GetType() != typeof(Action);
		Delegate obj76 = null;
		if (!flag80)
		{
			obj76 = obj74;
		}
		bool flag81 = (object)obj76 == null;
		action2 = action30;
		num = (nint)typeof(Action);
		obj4 = 0;
		obj5 = obj74;
		if (!flag81)
		{
			return;
		}
		goto IL_261a;
		IL_20a6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2096;
		IL_2076:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2066;
		IL_2156:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2146;
		IL_210e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_20fe;
		IL_218e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2156;
		IL_2046:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2036;
		IL_20fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_20c6;
		IL_20b6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_20a6;
		IL_20c6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_20b6;
		IL_2056:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2046;
		IL_256a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num7 = (nint)obj;
		obj14 = action2;
		goto IL_255a;
		IL_2096:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2086;
		IL_1f5d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_256a;
		IL_1e85:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_254a;
		IL_1f6d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f5d;
		IL_2066:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2056;
		IL_259a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_258a;
		IL_2036:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_259a;
		IL_1d7b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d6b;
		IL_255a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1e95;
		IL_1e95:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1e85;
		IL_253a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d8b;
		IL_254a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_253a;
		IL_2086:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2076;
		IL_258a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f6d;
		IL_1d6b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d5b;
		IL_1d0b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1cfb;
		IL_1d8b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d7b;
		IL_1d3b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d2b;
		IL_1d1b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d0b;
		IL_1d5b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d4b;
		IL_1d2b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d1b;
		IL_1ceb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1cdb;
		IL_1cfb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1ceb;
		IL_24fa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_24ef;
		IL_1d4b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d3b;
		IL_252a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_251a;
		IL_250a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_24fa;
		IL_260a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_25fa;
		IL_251a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_250a;
		IL_1cdb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_252a;
		IL_24ef:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_23bf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2387;
		IL_261a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_260a;
		IL_25fa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_25ea;
		IL_25ea:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_23cf;
		IL_2357:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_25da;
		IL_23cf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_23bf;
		IL_2387:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2377;
		IL_2377:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2367;
		IL_2206:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_21f6;
		IL_25aa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2206;
		IL_25ba:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_25aa;
		IL_21d6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_219e;
		IL_25ca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_25ba;
		IL_2367:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2357;
		IL_25da:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_25ca;
		IL_21f6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_21e6;
		IL_2146:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_210e;
		IL_21e6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_21d6;
		IL_219e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_218e;
	}

	public static void Cleanup()
	{
		//IL_1a22: Expected I, but got O
		//IL_1a2b: Expected O, but got I4
		//IL_1a9e: Expected O, but got I4
		//IL_1ab4: Expected I, but got O
		//IL_1b02: Expected O, but got I4
		//IL_1b18: Expected I, but got O
		//IL_1b3e: Expected O, but got I4
		//IL_1b54: Expected I, but got O
		//IL_01b9: Expected I, but got O
		//IL_01ca: Expected O, but got I4
		//IL_020d: Expected I, but got O
		//IL_021e: Expected O, but got I4
		//IL_02b0: Expected I, but got O
		//IL_02c1: Expected O, but got I4
		//IL_0304: Expected I, but got O
		//IL_0315: Expected O, but got I4
		//IL_03a7: Expected I, but got O
		//IL_03b8: Expected O, but got I4
		//IL_03fb: Expected I, but got O
		//IL_040c: Expected O, but got I4
		//IL_049e: Expected I, but got O
		//IL_04af: Expected O, but got I4
		//IL_04f2: Expected I, but got O
		//IL_0503: Expected O, but got I4
		//IL_0595: Expected I, but got O
		//IL_05a6: Expected O, but got I4
		//IL_05e9: Expected I, but got O
		//IL_05fa: Expected O, but got I4
		//IL_068c: Expected I, but got O
		//IL_069d: Expected O, but got I4
		//IL_06e0: Expected I, but got O
		//IL_06f1: Expected O, but got I4
		//IL_240c: Expected I, but got O
		//IL_1c8a: Expected I, but got O
		//IL_1c9b: Expected O, but got I4
		//IL_1cb1: Expected I, but got O
		//IL_1cd7: Expected I, but got O
		//IL_1ce8: Expected O, but got I4
		//IL_1cfe: Expected I, but got O
		//IL_080c: Expected I, but got O
		//IL_081d: Expected O, but got I4
		//IL_0860: Expected I, but got O
		//IL_0871: Expected O, but got I4
		//IL_1d6b: Expected I, but got O
		//IL_1d7c: Expected O, but got I4
		//IL_1d92: Expected I, but got O
		//IL_1dc0: Expected O, but got I4
		//IL_1dd6: Expected I, but got O
		//IL_09ce: Expected O, but got I4
		//IL_0a22: Expected O, but got I4
		//IL_1e7d: Expected O, but got I4
		//IL_1e93: Expected I, but got O
		//IL_1ec1: Expected O, but got I4
		//IL_1ed7: Expected I, but got O
		//IL_0b76: Expected O, but got I4
		//IL_0bca: Expected O, but got I4
		//IL_0c6d: Expected O, but got I4
		//IL_0cc1: Expected O, but got I4
		//IL_0d64: Expected O, but got I4
		//IL_0db8: Expected O, but got I4
		//IL_0e5b: Expected O, but got I4
		//IL_0eaf: Expected O, but got I4
		//IL_0f52: Expected O, but got I4
		//IL_0fa6: Expected O, but got I4
		//IL_1021: Expected O, but got I4
		//IL_1075: Expected O, but got I4
		//IL_10f0: Expected O, but got I4
		//IL_1144: Expected O, but got I4
		//IL_11bf: Expected O, but got I4
		//IL_1213: Expected O, but got I4
		//IL_128e: Expected O, but got I4
		//IL_12e2: Expected O, but got I4
		//IL_1385: Expected O, but got I4
		//IL_13d9: Expected O, but got I4
		//IL_20e5: Expected O, but got I4
		//IL_20fb: Expected I, but got O
		//IL_2129: Expected O, but got I4
		//IL_213f: Expected I, but got O
		//IL_219e: Expected O, but got I4
		//IL_21b4: Expected I, but got O
		//IL_21e2: Expected O, but got I4
		//IL_21f8: Expected I, but got O
		//IL_160f: Expected O, but got I4
		//IL_1663: Expected O, but got I4
		//IL_1706: Expected O, but got I4
		//IL_175a: Expected O, but got I4
		//IL_17d5: Expected O, but got I4
		//IL_1829: Expected O, but got I4
		//IL_22ae: Expected O, but got I4
		//IL_22c4: Expected I, but got O
		//IL_22f2: Expected O, but got I4
		//IL_2308: Expected I, but got O
		//IL_2336: Expected O, but got I4
		//IL_234c: Expected I, but got O
		//IL_237f: Expected I, but got O
		//IL_2388: Expected O, but got I4
		Delegate obj = GameManager.A_RunStarted;
		Action action = OnRunStarted;
		Delegate obj2 = Delegate.Remove(GameManager.A_RunStarted, action);
		Action action2;
		nint num;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_RunStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				num = (nint)typeof(Action);
				obj4 = 0;
				obj5 = obj2;
				goto IL_24a9;
			}
			GameManager.A_RunStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_239e;
			}
		}
		Action value = OnTick;
		Delegate obj7 = Delegate.Remove(MyTime.A_Tick, value);
		if ((object)obj7 == null)
		{
			MyTime.A_Tick = null;
		}
		else
		{
			bool flag4 = (object)obj7.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj7;
			}
			bool flag5 = (object)obj8 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_23a9;
			}
			MyTime.A_Tick = (Action)obj8;
			bool flag6 = (object)obj7.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag6)
			{
				obj9 = obj7;
			}
			bool flag7 = (object)obj9 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_23b9;
			}
		}
		Action<Enemy, DamageContainer> value2 = OnEnemyDied;
		Delegate obj10 = Delegate.Remove(Enemy.A_EnemyDied, value2);
		nint num5;
		Delegate obj11;
		if ((object)obj10 == null)
		{
			Enemy.A_EnemyDied = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action3 = default(Action<Enemy, DamageContainer>);
			bool flag8 = action3 == null;
			num5 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag8)
			{
				goto IL_1b8a;
			}
			Enemy.A_EnemyDied = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj12 = default(object);
			bool flag9 = obj12 == null;
			num5 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag9)
			{
				goto IL_1b9a;
			}
		}
		Action<Enemy, DamageContainer> value3 = OnEnemyDamaged;
		Delegate obj13 = Delegate.Remove(Enemy.A_Damage, value3);
		if ((object)obj13 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action4 = default(Action<Enemy, DamageContainer>);
			bool flag10 = action4 == null;
			num5 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj13;
			obj4 = 0;
			obj5 = null;
			if (flag10)
			{
				goto IL_1baa;
			}
			Enemy.A_Damage = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj14 = default(object);
			bool flag11 = obj14 == null;
			num5 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj13;
			obj4 = 0;
			obj5 = null;
			if (flag11)
			{
				goto IL_1bba;
			}
		}
		Action<bool> value4 = OnStageBossDefeated;
		Delegate obj15 = Delegate.Remove(InteractableBossSpawner.A_BossDefeated, value4);
		if ((object)obj15 == null)
		{
			InteractableBossSpawner.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action5 = default(Action<bool>);
			bool flag12 = action5 == null;
			num5 = (nint)typeof(Action<bool>);
			obj11 = obj15;
			obj4 = 0;
			obj5 = null;
			if (flag12)
			{
				goto IL_1bca;
			}
			InteractableBossSpawner.A_BossDefeated = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj16 = default(object);
			bool flag13 = obj16 == null;
			num5 = (nint)typeof(Action<bool>);
			obj11 = obj15;
			obj4 = 0;
			obj5 = null;
			if (flag13)
			{
				goto IL_1bda;
			}
		}
		Action<int> value5 = OnStageBossDefeatedNum;
		Delegate obj17 = Delegate.Remove(InteractableBossSpawner.A_NumBossesDefeated, value5);
		if ((object)obj17 == null)
		{
			InteractableBossSpawner.A_NumBossesDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action6 = default(Action<int>);
			bool flag14 = action6 == null;
			num5 = (nint)typeof(Action<int>);
			obj11 = obj17;
			obj4 = 0;
			obj5 = null;
			if (flag14)
			{
				goto IL_1bea;
			}
			InteractableBossSpawner.A_NumBossesDefeated = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj18 = default(object);
			bool flag15 = obj18 == null;
			num5 = (nint)typeof(Action<int>);
			obj11 = obj17;
			obj4 = 0;
			obj5 = null;
			if (flag15)
			{
				goto IL_1bfa;
			}
		}
		Action<bool> value6 = OnStageBossDefeated;
		Delegate obj19 = Delegate.Remove(FinalFightController.A_BossDefeated, value6);
		if ((object)obj19 == null)
		{
			FinalFightController.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action7 = default(Action<bool>);
			bool flag16 = action7 == null;
			num5 = (nint)typeof(Action<bool>);
			obj11 = obj19;
			obj4 = 0;
			obj5 = null;
			if (flag16)
			{
				goto IL_1c0a;
			}
			FinalFightController.A_BossDefeated = action7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj20 = default(object);
			bool flag17 = obj20 == null;
			num5 = (nint)typeof(Action<bool>);
			obj11 = obj19;
			obj4 = 0;
			obj5 = null;
			if (flag17)
			{
				goto IL_1c1a;
			}
		}
		Action<float> value7 = OnStageBossDefeatedInTime;
		Delegate obj21 = Delegate.Remove(FinalFightController.A_BossDefeatedTime, value7);
		if ((object)obj21 == null)
		{
			FinalFightController.A_BossDefeatedTime = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action8 = default(Action<float>);
			bool flag18 = action8 == null;
			num5 = (nint)typeof(Action<float>);
			obj11 = obj21;
			obj4 = 0;
			obj5 = null;
			if (flag18)
			{
				goto IL_1c2a;
			}
			FinalFightController.A_BossDefeatedTime = action8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj22 = default(object);
			bool flag19 = obj22 == null;
			num5 = (nint)typeof(Action<float>);
			obj11 = obj21;
			obj4 = 0;
			obj5 = null;
			if (flag19)
			{
				goto IL_1c3a;
			}
		}
		Action action9 = OnChestBought;
		Delegate obj23 = Delegate.Remove(InteractableChest.A_ChestBought, action9);
		if ((object)obj23 == null)
		{
			InteractableChest.A_ChestBought = null;
		}
		else
		{
			bool flag20 = (object)obj23.GetType() != typeof(Action);
			Delegate obj24 = null;
			if (!flag20)
			{
				obj24 = obj23;
			}
			bool flag21 = (object)obj24 == null;
			num5 = (nint)InteractableChest.A_ChestBought;
			obj11 = action9;
			obj4 = 0;
			obj5 = obj23;
			nint num6 = (nint)typeof(Action);
			if (flag21)
			{
				goto IL_23c9;
			}
			InteractableChest.A_ChestBought = (Action)obj24;
			bool flag22 = (object)obj23.GetType() != typeof(Action);
			Delegate obj25 = null;
			if (!flag22)
			{
				obj25 = obj23;
			}
			bool flag23 = (object)obj25 == null;
			num5 = (nint)InteractableChest.A_ChestBought;
			obj11 = action9;
			obj4 = 0;
			obj5 = obj23;
			nint num7 = (nint)typeof(Action);
			if (flag23)
			{
				goto IL_23d9;
			}
		}
		Action<bool> value8 = OnShrineCharged;
		Delegate obj26 = Delegate.Remove(ChargeShrine.A_Charged, value8);
		if ((object)obj26 == null)
		{
			ChargeShrine.A_Charged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action10 = default(Action<bool>);
			bool flag24 = action10 == null;
			num5 = (nint)typeof(Action<bool>);
			obj11 = obj26;
			obj4 = 0;
			obj5 = null;
			if (flag24)
			{
				goto IL_1d34;
			}
			ChargeShrine.A_Charged = action10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj27 = default(object);
			bool flag25 = obj27 == null;
			num5 = (nint)typeof(Action<bool>);
			obj11 = obj26;
			obj4 = 0;
			obj5 = null;
			if (flag25)
			{
				goto IL_1d44;
			}
		}
		obj = ChargeShrine.A_ChargeShrineSpawned;
		Action action11 = OnChargeShrineSpawned;
		Delegate obj28 = Delegate.Remove(ChargeShrine.A_ChargeShrineSpawned, action11);
		if ((object)obj28 == null)
		{
			ChargeShrine.A_ChargeShrineSpawned = null;
		}
		else
		{
			bool flag26 = (object)obj28.GetType() != typeof(Action);
			Delegate obj29 = null;
			if (!flag26)
			{
				obj29 = obj28;
			}
			bool flag27 = (object)obj29 == null;
			num5 = (nint)obj;
			obj11 = action11;
			obj4 = 0;
			obj5 = obj28;
			nint num8 = (nint)typeof(Action);
			if (flag27)
			{
				goto IL_23e9;
			}
			ChargeShrine.A_ChargeShrineSpawned = (Action)obj29;
			bool flag28 = (object)obj28.GetType() != typeof(Action);
			Delegate obj30 = null;
			if (!flag28)
			{
				obj30 = obj28;
			}
			bool flag29 = (object)obj30 == null;
			action2 = action11;
			obj4 = 0;
			obj5 = obj28;
			nint num9 = (nint)typeof(Action);
			if (flag29)
			{
				goto IL_23f9;
			}
		}
		Action<EItem> value9 = OnMicrowaveUsed;
		Delegate obj31 = Delegate.Remove(InteractableMicrowave.A_Used, value9);
		if ((object)obj31 == null)
		{
			InteractableMicrowave.A_Used = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action12 = default(Action<EItem>);
			bool flag30 = action12 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj31;
			obj4 = 0;
			obj5 = null;
			if (flag30)
			{
				goto IL_1e0c;
			}
			InteractableMicrowave.A_Used = action12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj32 = default(object);
			bool flag31 = obj32 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj31;
			obj4 = 0;
			obj5 = null;
			if (flag31)
			{
				goto IL_1e1c;
			}
		}
		obj = GraveyardBossRoom.A_BossDied;
		Action action13 = OnGhostBossDied;
		Delegate obj33 = Delegate.Remove(GraveyardBossRoom.A_BossDied, action13);
		if ((object)obj33 == null)
		{
			GraveyardBossRoom.A_BossDied = null;
		}
		else
		{
			bool flag32 = (object)obj33.GetType() != typeof(Action);
			Delegate obj34 = null;
			if (!flag32)
			{
				obj34 = obj33;
			}
			bool flag33 = (object)obj34 == null;
			action2 = action13;
			obj4 = 0;
			obj5 = obj33;
			nint num10 = (nint)typeof(Action);
			if (flag33)
			{
				goto IL_2419;
			}
			GraveyardBossRoom.A_BossDied = (Action)obj34;
			bool flag34 = (object)obj33.GetType() != typeof(Action);
			Delegate obj35 = null;
			if (!flag34)
			{
				obj35 = obj33;
			}
			bool flag35 = (object)obj35 == null;
			action2 = action13;
			obj4 = 0;
			obj5 = obj33;
			nint num11 = (nint)typeof(Action);
			if (flag35)
			{
				goto IL_2429;
			}
		}
		Action<EStat> value10 = OnStatUpdate;
		Delegate obj36 = Delegate.Remove(PlayerStatsNew.A_StatUpdate, value10);
		if ((object)obj36 == null)
		{
			PlayerStatsNew.A_StatUpdate = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action14 = default(Action<EStat>);
			bool flag36 = action14 == null;
			obj = (Delegate)(object)typeof(Action<EStat>);
			action2 = (Action)obj36;
			obj4 = 0;
			obj5 = null;
			if (flag36)
			{
				goto IL_1ee5;
			}
			PlayerStatsNew.A_StatUpdate = action14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj37 = default(object);
			bool flag37 = obj37 == null;
			obj = (Delegate)(object)typeof(Action<EStat>);
			action2 = (Action)obj36;
			obj4 = 0;
			obj5 = null;
			if (flag37)
			{
				goto IL_1ef5;
			}
		}
		Action<WeaponBase> value11 = OnWeaponAddedOrUpgraded;
		Delegate obj38 = Delegate.Remove(WeaponInventory.A_WeaponAdded, value11);
		if ((object)obj38 == null)
		{
			WeaponInventory.A_WeaponAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action15 = default(Action<WeaponBase>);
			bool flag38 = action15 == null;
			obj = (Delegate)(object)typeof(Action<WeaponBase>);
			action2 = (Action)obj38;
			obj4 = 0;
			obj5 = null;
			if (flag38)
			{
				goto IL_1f05;
			}
			WeaponInventory.A_WeaponAdded = action15;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj39 = default(object);
			bool flag39 = obj39 == null;
			obj = (Delegate)(object)typeof(Action<WeaponBase>);
			action2 = (Action)obj38;
			obj4 = 0;
			obj5 = null;
			if (flag39)
			{
				goto IL_1f15;
			}
		}
		Action<ETome, EStat> value12 = OnTomeAddedOrUpgraded;
		Delegate obj40 = Delegate.Remove(TomeInventory.A_TomeUpgrade, value12);
		if ((object)obj40 == null)
		{
			TomeInventory.A_TomeUpgrade = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ETome, EStat> action16 = default(Action<ETome, EStat>);
			bool flag40 = action16 == null;
			obj = (Delegate)(object)typeof(Action<ETome, EStat>);
			action2 = (Action)obj40;
			obj4 = 0;
			obj5 = null;
			if (flag40)
			{
				goto IL_1f25;
			}
			TomeInventory.A_TomeUpgrade = action16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj41 = default(object);
			bool flag41 = obj41 == null;
			obj = (Delegate)(object)typeof(Action<ETome, EStat>);
			action2 = (Action)obj40;
			obj4 = 0;
			obj5 = null;
			if (flag41)
			{
				goto IL_1f35;
			}
		}
		Action<Pickup> value13 = OnPickupTriggered;
		Delegate obj42 = Delegate.Remove(Pickup.A_PickupTriggered, value13);
		if ((object)obj42 == null)
		{
			Pickup.A_PickupTriggered = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action17 = default(Action<Pickup>);
			bool flag42 = action17 == null;
			obj = (Delegate)(object)typeof(Action<Pickup>);
			action2 = (Action)obj42;
			obj4 = 0;
			obj5 = null;
			if (flag42)
			{
				goto IL_1f45;
			}
			Pickup.A_PickupTriggered = action17;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj43 = default(object);
			bool flag43 = obj43 == null;
			obj = (Delegate)(object)typeof(Action<Pickup>);
			action2 = (Action)obj42;
			obj4 = 0;
			obj5 = null;
			if (flag43)
			{
				goto IL_1f55;
			}
		}
		Action<EItem> value14 = OnItemAdded;
		Delegate obj44 = Delegate.Remove(ItemInventory.A_ItemAdded, value14);
		if ((object)obj44 == null)
		{
			ItemInventory.A_ItemAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action18 = default(Action<EItem>);
			bool flag44 = action18 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj44;
			obj4 = 0;
			obj5 = null;
			if (flag44)
			{
				goto IL_1f65;
			}
			ItemInventory.A_ItemAdded = action18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj45 = default(object);
			bool flag45 = obj45 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj44;
			obj4 = 0;
			obj5 = null;
			if (flag45)
			{
				goto IL_1f75;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> value15 = new Action<object, object, bool>(OnDamageTaken);
		Delegate obj46 = Delegate.Remove(PlayerHealth.A_TakeDamage, value15);
		if ((object)obj46 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action19 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag46 = action19 == null;
			obj = (Delegate)(object)typeof(Action<PlayerHealth, DamageContainer, bool>);
			action2 = (Action)obj46;
			obj4 = 0;
			obj5 = null;
			if (flag46)
			{
				goto IL_1fad;
			}
			PlayerHealth.A_TakeDamage = action19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj47 = default(object);
			bool flag47 = obj47 == null;
			obj = (Delegate)(object)typeof(Action<PlayerHealth, DamageContainer, bool>);
			action2 = (Action)obj46;
			obj4 = 0;
			obj5 = null;
			if (flag47)
			{
				goto IL_1fbd;
			}
		}
		Action<int> value16 = OnLevelUp;
		Delegate obj48 = Delegate.Remove(PlayerXp.A_LevelUp, value16);
		if ((object)obj48 == null)
		{
			PlayerXp.A_LevelUp = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action20 = default(Action<int>);
			bool flag48 = action20 == null;
			obj = (Delegate)(object)typeof(Action<int>);
			action2 = (Action)obj48;
			obj4 = 0;
			obj5 = null;
			if (flag48)
			{
				goto IL_1ff5;
			}
			PlayerXp.A_LevelUp = action20;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj49 = default(object);
			bool flag49 = obj49 == null;
			obj = (Delegate)(object)typeof(Action<int>);
			action2 = (Action)obj48;
			obj4 = 0;
			obj5 = null;
			if (flag49)
			{
				goto IL_2005;
			}
		}
		Action<PlayerInventory> value17 = OnPLayerInventoryInited;
		Delegate obj50 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value17);
		if ((object)obj50 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action21 = default(Action<PlayerInventory>);
			bool flag50 = action21 == null;
			obj = (Delegate)(object)typeof(Action<PlayerInventory>);
			action2 = (Action)obj50;
			obj4 = 0;
			obj5 = null;
			if (flag50)
			{
				goto IL_203d;
			}
			MyPlayer.A_PlayerInventoryInitialized = action21;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj51 = default(object);
			bool flag51 = obj51 == null;
			obj = (Delegate)(object)typeof(Action<PlayerInventory>);
			action2 = (Action)obj50;
			obj4 = 0;
			obj5 = null;
			if (flag51)
			{
				goto IL_204d;
			}
		}
		Action<MyAchievement> value18 = OnUnlock;
		Delegate obj52 = Delegate.Remove(MyAchievements.A_Unlocked, value18);
		if ((object)obj52 == null)
		{
			MyAchievements.A_Unlocked = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyAchievement> action22 = default(Action<MyAchievement>);
			bool flag52 = action22 == null;
			obj = (Delegate)(object)typeof(Action<MyAchievement>);
			action2 = (Action)obj52;
			obj4 = 0;
			obj5 = null;
			if (flag52)
			{
				goto IL_2085;
			}
			MyAchievements.A_Unlocked = action22;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj53 = default(object);
			bool flag53 = obj53 == null;
			obj = (Delegate)(object)typeof(Action<MyAchievement>);
			action2 = (Action)obj52;
			obj4 = 0;
			obj5 = null;
			if (flag53)
			{
				goto IL_2095;
			}
		}
		Action<UnlockableBase> value19 = OnPurchased;
		Delegate obj54 = Delegate.Remove(UnlocksFooter.A_Purchased, value19);
		if ((object)obj54 == null)
		{
			UnlocksFooter.A_Purchased = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<UnlockableBase> action23 = default(Action<UnlockableBase>);
			bool flag54 = action23 == null;
			obj = (Delegate)(object)typeof(Action<UnlockableBase>);
			action2 = (Action)obj54;
			obj4 = 0;
			obj5 = null;
			if (flag54)
			{
				goto IL_20a5;
			}
			UnlocksFooter.A_Purchased = action23;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj55 = default(object);
			bool flag55 = obj55 == null;
			obj = (Delegate)(object)typeof(Action<UnlockableBase>);
			action2 = (Action)obj54;
			obj4 = 0;
			obj5 = null;
			if (flag55)
			{
				goto IL_20b5;
			}
		}
		obj = SummonerController.A_FinalSwarmStarted;
		Action action24 = OnFinalSwarmStart;
		Delegate obj56 = Delegate.Remove(SummonerController.A_FinalSwarmStarted, action24);
		if ((object)obj56 == null)
		{
			SummonerController.A_FinalSwarmStarted = null;
		}
		else
		{
			bool flag56 = (object)obj56.GetType() != typeof(Action);
			Delegate obj57 = null;
			if (!flag56)
			{
				obj57 = obj56;
			}
			bool flag57 = (object)obj57 == null;
			action2 = action24;
			obj4 = 0;
			obj5 = obj56;
			nint num12 = (nint)typeof(Action);
			if (flag57)
			{
				goto IL_2439;
			}
			SummonerController.A_FinalSwarmStarted = (Action)obj57;
			bool flag58 = (object)obj56.GetType() != typeof(Action);
			Delegate obj58 = null;
			if (!flag58)
			{
				obj58 = obj56;
			}
			bool flag59 = (object)obj58 == null;
			action2 = action24;
			obj4 = 0;
			obj5 = obj56;
			nint num13 = (nint)typeof(Action);
			if (flag59)
			{
				goto IL_2449;
			}
		}
		obj = TrackStats.A_PotBroken;
		Action action25 = OnPotBroken;
		Delegate obj59 = Delegate.Remove(TrackStats.A_PotBroken, action25);
		if ((object)obj59 == null)
		{
			TrackStats.A_PotBroken = null;
		}
		else
		{
			bool flag60 = (object)obj59.GetType() != typeof(Action);
			Delegate obj60 = null;
			if (!flag60)
			{
				obj60 = obj59;
			}
			bool flag61 = (object)obj60 == null;
			action2 = action25;
			obj4 = 0;
			obj5 = obj59;
			nint num14 = (nint)typeof(Action);
			if (flag61)
			{
				goto IL_2459;
			}
			TrackStats.A_PotBroken = (Action)obj60;
			bool flag62 = (object)obj59.GetType() != typeof(Action);
			Delegate obj61 = null;
			if (!flag62)
			{
				obj61 = obj59;
			}
			bool flag63 = (object)obj61 == null;
			action2 = action25;
			obj4 = 0;
			obj5 = obj59;
			nint num15 = (nint)typeof(Action);
			if (flag63)
			{
				goto IL_2469;
			}
		}
		Action<BaseInteractable, bool> value20 = OnInteracted;
		Delegate obj62 = Delegate.Remove(DetectInteractables.A_Interacted, value20);
		if ((object)obj62 == null)
		{
			DetectInteractables.A_Interacted = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<BaseInteractable, bool> action26 = default(Action<BaseInteractable, bool>);
			bool flag64 = action26 == null;
			obj = (Delegate)(object)typeof(Action<BaseInteractable, bool>);
			action2 = (Action)obj62;
			obj4 = 0;
			obj5 = null;
			if (flag64)
			{
				goto IL_2206;
			}
			DetectInteractables.A_Interacted = action26;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj63 = default(object);
			bool flag65 = obj63 == null;
			obj = (Delegate)(object)typeof(Action<BaseInteractable, bool>);
			action2 = (Action)obj62;
			obj4 = 0;
			obj5 = null;
			if (flag65)
			{
				goto IL_2216;
			}
		}
		Action<float> value21 = OnCryptSpeedrun;
		Delegate obj64 = Delegate.Remove(InteractableCryptLeave.A_FirstDungeonCompleted, value21);
		if ((object)obj64 == null)
		{
			InteractableCryptLeave.A_FirstDungeonCompleted = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action27 = default(Action<float>);
			bool flag66 = action27 == null;
			obj = (Delegate)(object)typeof(Action<float>);
			action2 = (Action)obj64;
			obj4 = 0;
			obj5 = null;
			if (flag66)
			{
				goto IL_2226;
			}
			InteractableCryptLeave.A_FirstDungeonCompleted = action27;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj65 = default(object);
			bool flag67 = obj65 == null;
			obj = (Delegate)(object)typeof(Action<float>);
			action2 = (Action)obj64;
			obj4 = 0;
			obj5 = null;
			if (flag67)
			{
				goto IL_2236;
			}
		}
		Action<string> value22 = OnInteractableUsedDebug;
		Delegate obj66 = Delegate.Remove(InteractablesStatus.A_InteractableUsed, value22);
		if ((object)obj66 == null)
		{
			InteractablesStatus.A_InteractableUsed = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action28 = default(Action<string>);
			bool flag68 = action28 == null;
			obj = (Delegate)(object)typeof(Action<string>);
			action2 = (Action)obj66;
			obj4 = 0;
			obj5 = null;
			if (flag68)
			{
				goto IL_226e;
			}
			InteractablesStatus.A_InteractableUsed = action28;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj67 = default(object);
			bool flag69 = obj67 == null;
			obj = (Delegate)(object)typeof(Action<string>);
			action2 = (Action)obj66;
			obj4 = 0;
			obj5 = null;
			if (flag69)
			{
				goto IL_227e;
			}
		}
		obj = MainMenu.A_MenuOpened;
		Action action29 = OnMainMenuOpened;
		Delegate obj68 = Delegate.Remove(MainMenu.A_MenuOpened, action29);
		if ((object)obj68 == null)
		{
			MainMenu.A_MenuOpened = null;
		}
		else
		{
			bool flag70 = (object)obj68.GetType() != typeof(Action);
			Delegate obj69 = null;
			if (!flag70)
			{
				obj69 = obj68;
			}
			bool flag71 = (object)obj69 == null;
			action2 = action29;
			obj4 = 0;
			obj5 = obj68;
			nint num16 = (nint)typeof(Action);
			if (flag71)
			{
				goto IL_2479;
			}
			MainMenu.A_MenuOpened = (Action)obj69;
			bool flag72 = (object)obj68.GetType() != typeof(Action);
			Delegate obj70 = null;
			if (!flag72)
			{
				obj70 = obj68;
			}
			bool flag73 = (object)obj70 == null;
			action2 = action29;
			obj4 = 0;
			obj5 = obj68;
			nint num17 = (nint)typeof(Action);
			if (flag73)
			{
				goto IL_2489;
			}
		}
		obj = LateFixedUpdate.A_LateUpdate;
		Action action30 = OnLateFixedUpdate;
		Delegate obj71 = Delegate.Remove(LateFixedUpdate.A_LateUpdate, action30);
		if ((object)obj71 == null)
		{
			LateFixedUpdate.A_LateUpdate = null;
			return;
		}
		bool flag74 = (object)obj71.GetType() != typeof(Action);
		Delegate obj72 = null;
		if (!flag74)
		{
			obj72 = obj71;
		}
		bool flag75 = (object)obj72 == null;
		action2 = action30;
		obj4 = 0;
		obj5 = obj71;
		nint num18 = (nint)typeof(Action);
		if (flag75)
		{
			goto IL_2499;
		}
		LateFixedUpdate.A_LateUpdate = (Action)obj72;
		bool flag76 = (object)obj71.GetType() != typeof(Action);
		Delegate obj73 = null;
		if (!flag76)
		{
			obj73 = obj71;
		}
		bool flag77 = (object)obj73 == null;
		action2 = action30;
		num = (nint)typeof(Action);
		obj4 = 0;
		obj5 = obj71;
		if (!flag77)
		{
			return;
		}
		goto IL_24a9;
		IL_1f25:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f15;
		IL_1f45:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f35;
		IL_1f35:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f25;
		IL_1f05:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1ef5;
		IL_2085:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_204d;
		IL_1f55:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f45;
		IL_1f65:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f55;
		IL_2439:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_20b5;
		IL_203d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2005;
		IL_1e1c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1e0c;
		IL_1f15:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f05;
		IL_1ef5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1ee5;
		IL_1d44:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d34;
		IL_23e9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1d44;
		IL_23f9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num5 = (nint)obj;
		obj11 = action2;
		goto IL_23e9;
		IL_2429:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2419;
		IL_2419:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1e1c;
		IL_23d9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_23c9;
		IL_23c9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1c3a;
		IL_1c3a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1c2a;
		IL_1ee5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2429;
		IL_1bfa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1bea;
		IL_1c0a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1bfa;
		IL_1bea:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1bda;
		IL_1e0c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_23f9;
		IL_1c1a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1c0a;
		IL_1bba:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1baa;
		IL_1bca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1bba;
		IL_1d34:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_23d9;
		IL_1b8a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_23b9;
		IL_1b9a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b8a;
		IL_23b9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_23a9;
		IL_1bda:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1bca;
		IL_24a9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2499;
		IL_1baa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b9a;
		IL_239e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_1c2a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1c1a;
		IL_227e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_226e;
		IL_2489:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2479;
		IL_2479:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_227e;
		IL_23a9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_239e;
		IL_2216:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2206;
		IL_226e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2236;
		IL_2236:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2226;
		IL_2459:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2449;
		IL_2469:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2459;
		IL_2449:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2439;
		IL_2226:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2216;
		IL_2499:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2489;
		IL_2095:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2085;
		IL_20b5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_20a5;
		IL_20a5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2095;
		IL_2206:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_2469;
		IL_1ff5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1fbd;
		IL_1fbd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1fad;
		IL_2005:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1ff5;
		IL_1f75:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f65;
		IL_204d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_203d;
		IL_1fad:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1f75;
	}

	private static void OnFinalSwarmStart()
	{
	}

	private static void OnRunStarted()
	{
		runChestsBought = 0;
		hasTakenDamageThisRun = false;
		hasDealtDamageThisRun = false;
		hasSpawnedLuckTomeQuest = false;
		chargedShrines = 0;
		chargedShrinesNoInterruptions = 0;
		totalChargeShrines = 0;
	}

	private static void OnStageStarted()
	{
		numBoomboxes = 0;
		consecutiveIceCrystalCooks = 0;
		consecutiveMoldyCheeseCooks = 0;
		if (MyAchievements.IsAchievementDone("a_desert"))
		{
			return;
		}
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData.eMap == EMap.Forest && MapController.index == 1)
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.character == ECharacter.Cl4nk)
			{
				bool flag = MyAchievements.TryUnlock("a_desert");
			}
		}
	}

	private static void OnPLayerInventoryInited(PlayerInventory inv)
	{
		float stat = inv.playerStats.GetStat(EStat.MoveSpeedMultiplier);
		baseMovementSpeed = stat;
		noDamageTimer = 0f;
	}

	private static void OnStatUpdate(EStat stat)
	{
		//IL_0134: Invalid comparison between F4 and I4
		if (!PlayerStats.HasStats())
		{
			return;
		}
		if (!MyAchievements.IsAchievementDone("a_chonkplate") && stat == EStat.MaxHealth)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			PlayerHealth playerHealth = inventory.playerHealth;
			int achievementTargetValue = MyAchievements.GetAchievementTargetValue("a_chonkplate");
			if (playerHealth.maxHp >= achievementTargetValue)
			{
				bool flag = MyAchievements.TryUnlock("a_chonkplate");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_skuleg") && stat == EStat.Difficulty)
		{
			float stat2 = PlayerStats.GetStat(stat);
			float num = stat2 * 100f;
			int achievementTargetValue2 = MyAchievements.GetAchievementTargetValue("a_skuleg");
			if (!(num < (float)achievementTargetValue2))
			{
				bool flag2 = MyAchievements.TryUnlock("a_skuleg");
			}
		}
	}

	private static void OnTick()
	{
		//IL_00cd: Invalid comparison between F4 and I4
		//IL_013b: Expected O, but got I4
		//IL_0144: Invalid comparison between F4 and O
		//IL_01b2: Expected O, but got I4
		//IL_01bb: Invalid comparison between F4 and O
		if (!(GameManager.Instance != null))
		{
			return;
		}
		if (!MyAchievements.IsAchievementDone("a_aura"))
		{
			GameManager instance = GameManager.Instance;
			if (instance.isPlaying)
			{
				float num = noDamageTimer + MyTime.fixedDeltaTime;
				noDamageTimer = num;
				if (noDamageTimer > 120f)
				{
					bool flag = MyAchievements.TryUnlock("a_aura");
				}
			}
		}
		if (!MyAchievements.IsAchievementDone("a_ghost"))
		{
			int achievementTargetValue = MyAchievements.GetAchievementTargetValue("a_ghost");
			if (!(MyTime.finalSwarmTimer < (float)achievementTargetValue))
			{
				bool flag2 = MyAchievements.TryUnlock("a_ghost");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_bob"))
		{
			int achievementTargetValue2 = MyAchievements.GetAchievementTargetValue("a_bob");
			object obj = achievementTargetValue2 * 60;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)MyTime.finalSwarmTimer) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				bool flag3 = MyAchievements.TryUnlock("a_bob");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_soulHarvester"))
		{
			int achievementTargetValue3 = MyAchievements.GetAchievementTargetValue("a_soulHarvester");
			object obj2 = achievementTargetValue3 * 60;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)MyTime.finalSwarmTimer) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				bool flag4 = MyAchievements.TryUnlock("a_soulHarvester");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_kills5000"))
		{
			int stat = RunStats.GetStat(EMyStat.kills);
			if (stat > 5000)
			{
				bool flag5 = MyAchievements.TryUnlock("a_kills5000");
			}
		}
	}

	private unsafe static void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
		//IL_0092: Invalid comparison between I4 and F4
		//IL_0135: Invalid comparison between I4 and F4
		//IL_0205: Invalid comparison between F4 and I4
		//IL_023e: Expected O, but got Ref
		//IL_0255: Expected O, but got Ref
		//IL_0512: Expected Ref, but got F4
		//IL_03f8: Invalid comparison between I4 and F4
		if (!MyAchievements.IsAchievementDone(a_tacticalGlasses) && enemy.IsBoss() && !enemy.IsStageBoss())
		{
			float num = MyTime.time - enemy._003CspawnedAtTime_003Ek__BackingField;
			int achievementTargetValue = MyAchievements.GetAchievementTargetValue(a_tacticalGlasses);
			if (!((float)achievementTargetValue < num))
			{
				bool flag = MyAchievements.TryUnlock(a_tacticalGlasses);
			}
		}
		if (!MyAchievements.IsAchievementDone(a_bossBuster) && enemy.IsStageBoss())
		{
			float num2 = MyTime.time - enemy._003CspawnedAtTime_003Ek__BackingField;
			int achievementTargetValue2 = MyAchievements.GetAchievementTargetValue(a_bossBuster);
			if (!((float)achievementTargetValue2 < num2))
			{
				bool flag2 = MyAchievements.TryUnlock(a_bossBuster);
			}
		}
		if (!MyAchievements.IsAchievementDone(a_luckTome) && !hasSpawnedLuckTomeQuest)
		{
			double num3 = MyRandom.random.NextDouble();
			MyAchievement achievement = DataManager.Instance.GetAchievement(a_luckTome);
			float num4 = achievement.targetValueFloat * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm6\"");
			if (!(num4 < 0f))
			{
				hasSpawnedLuckTomeQuest = true;
				Vector3 centerPosition = enemy.GetCenterPosition();
				float num5 = default(float);
				Vector3 vector = RaycastUtility.RayToGround((Vector3)(&num5));
				EffectManager.Instance.TrySpawnLuckQuest((Vector3)(&num5));
			}
		}
		if (!MyAchievements.IsAchievementDone(a_quinsMask))
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.character == ECharacter.Athena && enemy.IsStageBoss() && deathSource.damageSource == aegisDamageSource)
			{
				bool flag3 = MyAchievements.TryUnlock(a_quinsMask);
			}
		}
		if (!MyAchievements.IsAchievementDone(a_roberto))
		{
			EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
			if (enemyData.enemyName == EEnemy.GhostInvincible)
			{
				bool flag4 = MyAchievements.TryUnlock(a_roberto);
			}
		}
		if (MyAchievements.IsAchievementDone(a_hatSheriff))
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		if (instance2.character == ECharacter.Cl4nk && enemy.IsBoss())
		{
			float num6 = enemy.teleportTime + enemy._003CspawnedAtTime_003Ek__BackingField;
			float num7 = MyTime.time - num6;
			float num8 = default(float);
			string text = num8.ToString();
			float num9 = (float)enemy + 256f;
			string text2 = ((float*)num9)->ToString();
			string text3 = "killed in time: " + text + "; teleportTime: " + text2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			int achievementTargetValue3 = MyAchievements.GetAchievementTargetValue(a_hatSheriff);
			if (!((float)achievementTargetValue3 < num7))
			{
				bool flag5 = MyAchievements.TryUnlock(a_hatSheriff);
			}
		}
	}

	private static void OnStageBossDefeated(bool isOpeningPortal)
	{
		//IL_0188: Expected O, but got I4
		//IL_01b9: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_05d8: Expected O, but got I4
		//IL_0602: Expected O, but got I4
		//IL_069f: Expected O, but got I4
		//IL_06c9: Expected O, but got I4
		//IL_093b: Expected O, but got I4
		//IL_0961: Expected O, but got I4
		//IL_098b: Expected O, but got I4
		MyPlayer instance = MyPlayer.Instance;
		if (!MyAchievements.IsAchievementDone("a_cursedTome"))
		{
			MyAchievement achievement = DataManager.Instance.GetAchievement("a_cursedTome");
			float num = (float)achievement.targetValue * 60f;
			bool flag = num < MyTime.runTimer;
			float num2 = num;
			if (!flag)
			{
				bool flag2 = MyAchievements.TryUnlock("a_cursedTome");
				num2 = num;
			}
		}
		string skinAchievementName = AchievementGenerator.GetSkinAchievementName(instance.character, ESkinType.Speedrun);
		if (!MyAchievements.IsAchievementDone(skinAchievementName))
		{
			int skinAchValue = AchievementGenerator.GetSkinAchValue(ESkinType.Speedrun);
			float num2 = (float)skinAchValue * 60f;
			if (!(num2 < MyTime.runTimer))
			{
				string skinAchievementName2 = AchievementGenerator.GetSkinAchievementName(instance.character, ESkinType.Speedrun);
				bool flag3 = MyAchievements.TryUnlock(skinAchievementName2);
			}
		}
		string skinAchievementName3 = AchievementGenerator.GetSkinAchievementName(instance.character, ESkinType.FinalBoss);
		bool flag4 = MyAchievements.IsAchievementDone(skinAchievementName3);
		object obj = 0;
		if (!flag4)
		{
			bool flag5 = !MapController.isFinalBossStage;
			obj = 0;
			if (!flag5)
			{
				string skinAchievementName4 = AchievementGenerator.GetSkinAchievementName(instance.character, ESkinType.FinalBoss);
				bool flag6 = MyAchievements.TryUnlock(skinAchievementName4);
				obj = 0;
			}
		}
		if (!MyAchievements.IsAchievementDone("a_clank"))
		{
			MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData.eMap == EMap.Forest && MapController.index == 0)
			{
				bool flag7 = MyAchievements.TryUnlock("a_clank");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_robinette"))
		{
			MapData mapData2 = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData2.eMap == EMap.Forest && MapController.index == 1)
			{
				bool flag8 = MyAchievements.TryUnlock("a_robinette");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_chadwell"))
		{
			MapData mapData3 = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData3.eMap == EMap.Forest && MapController.index == 2)
			{
				bool flag9 = MyAchievements.TryUnlock("a_chadwell");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_ninja"))
		{
			MapData mapData4 = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData4.eMap == EMap.Desert && MapController.index == 0)
			{
				bool flag10 = MyAchievements.TryUnlock("a_ninja");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_vlad"))
		{
			MapData mapData5 = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData5.eMap == EMap.Desert && MapController.index == 1)
			{
				bool flag11 = MyAchievements.TryUnlock("a_vlad");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_holyBook") && !hasTakenDamageThisRun)
		{
			bool flag12 = MyAchievements.TryUnlock("a_holyBook");
		}
		if (!MyAchievements.IsAchievementDone("a_speedBoi"))
		{
			GameManager instance2 = GameManager.Instance;
			MyAchievement achievement2 = DataManager.Instance.GetAchievement("a_speedBoi");
			bool flag13 = instance2.bossCurses < achievement2.targetValue;
			obj = 0;
			if (!flag13)
			{
				bool flag14 = MyAchievements.TryUnlock("a_speedBoi");
				obj = 0;
			}
		}
		if (!MyAchievements.IsAchievementDone("a_gamerGoggles"))
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory = instance3.inventory;
			float hpRatio = inventory.playerHealth.GetHpRatio();
			MyAchievement achievement3 = DataManager.Instance.GetAchievement("a_gamerGoggles");
			float num2 = (float)achievement3.targetValue / 100f;
			bool flag15 = num2 < hpRatio;
			obj = 0;
			if (!flag15)
			{
				bool flag16 = MyAchievements.TryUnlock("a_gamerGoggles");
				obj = 0;
			}
		}
		if (!MyAchievements.IsAchievementDone("a_spaceNoodle") && instance.character == ECharacter.TonyMcZoom)
		{
			MapData mapData6 = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData6.eMap == EMap.Desert)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A740");
				object obj2 = default(object);
				if ((nint)obj2 == 1)
				{
					bool flag17 = MyAchievements.TryUnlock("a_spaceNoodle");
				}
			}
		}
		if (!MyAchievements.IsAchievementDone("a_heroSword"))
		{
			int stat = RunStats.GetStat(EMyStat.powerupsUsed);
			if (stat <= 0)
			{
				MyPlayer instance4 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance4.inventory;
				ItemInventory itemInventory = inventory2.itemInventory;
				int count = itemInventory.items.Count;
				if (count <= 0 && chargedShrines <= 0)
				{
					bool flag18 = MyAchievements.TryUnlock("a_heroSword");
				}
			}
		}
		if (!MyAchievements.IsAchievementDone("a_hatCheese") && MapController.isFinalBossStage)
		{
			MyPlayer instance5 = MyPlayer.Instance;
			if (instance5.character == ECharacter.Amog)
			{
				MyPlayer instance6 = MyPlayer.Instance;
				PlayerInventory inventory3 = instance6.inventory;
				int amount = inventory3.itemInventory.GetAmount(EItem.MoldyCheese);
				MyPlayer instance7 = MyPlayer.Instance;
				PlayerInventory inventory4 = instance7.inventory;
				int amount2 = inventory4.itemInventory.GetAmount(EItem.Snek);
				bool flag19 = amount < 8;
				obj = 0;
				if (!flag19)
				{
					bool flag20 = amount2 < 1;
					obj = 0;
					if (!flag20)
					{
						bool flag21 = MyAchievements.TryUnlock("a_hatCheese");
						obj = 0;
					}
				}
			}
		}
		if (MyAchievements.IsAchievementDone("a_hatMedieval") || !MapController.isFinalBossStage)
		{
			return;
		}
		MyPlayer instance8 = MyPlayer.Instance;
		if (instance8.character != ECharacter.SirOofie)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A790");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v64+58]");
		if ((nint)0 != 1)
		{
			return;
		}
		MyPlayer instance9 = MyPlayer.Instance;
		PlayerInventory inventory5 = instance9.inventory;
		int weaponLevel = inventory5.weaponInventory.GetWeaponLevel(EWeapon.HeroSword);
		if (weaponLevel <= 0)
		{
			return;
		}
		MyPlayer instance10 = MyPlayer.Instance;
		PlayerInventory inventory6 = instance10.inventory;
		int weaponLevel2 = inventory6.weaponInventory.GetWeaponLevel(EWeapon.CorruptSword);
		if (weaponLevel2 > 0)
		{
			MyPlayer instance11 = MyPlayer.Instance;
			PlayerInventory inventory7 = instance11.inventory;
			int weaponLevel3 = inventory7.weaponInventory.GetWeaponLevel(EWeapon.Scythe);
			if (weaponLevel3 > 0)
			{
				bool flag22 = MyAchievements.TryUnlock("a_hatMedieval");
			}
		}
	}

	private static void OnStageBossDefeatedInTime(float time)
	{
		//IL_0147: Invalid comparison between I4 and F4
		if (MyAchievements.IsAchievementDone("a_skin_megachadKevin") || !MapController.isFinalBossStage)
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.character != ECharacter.Megachad)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A790");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v16+58]");
		if ((nint)0 != 1)
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerRenderer playerRenderer = instance2.playerRenderer;
		UnityEngine.Object currentHat = playerRenderer.currentHat;
		if (!(playerRenderer.currentHat != null))
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rbx_v7 (UnityEngine.Object)+50]");
		if ((nint)0 == 9)
		{
			int achievementTargetValue = MyAchievements.GetAchievementTargetValue("a_skin_megachadKevin");
			if (!((float)achievementTargetValue < time))
			{
				bool flag = MyAchievements.TryUnlock("a_skin_megachadKevin");
			}
		}
	}

	private static void OnStageBossDefeatedNum(int numBosses)
	{
		//IL_00c5: Expected O, but got I4
		if (MyAchievements.IsAchievementDone("a_hatHeadset"))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.character != ECharacter.Ninja)
		{
			return;
		}
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData.eMap != EMap.Desert)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A740");
		object obj = default(object);
		if (obj == null)
		{
			int achievementTargetValue = MyAchievements.GetAchievementTargetValue("a_hatHeadset");
			object obj2 = numBosses - 1;
			if ((nint)obj2 >= achievementTargetValue)
			{
				bool flag = MyAchievements.TryUnlock("a_hatHeadset");
			}
		}
	}

	private static void OnDamageTaken(PlayerHealth ph, DamageContainer dc, bool brokeShield)
	{
		noDamageTimer = 0f;
		hasTakenDamageThisRun = true;
	}

	private static void OnEnemyDamaged(Enemy arg1, DamageContainer arg2)
	{
		hasDealtDamageThisRun = true;
	}

	private static void OnLevelUp(int level)
	{
		if (!MyAchievements.IsAchievementDone("a_armorTome"))
		{
			MyAchievement achievement = DataManager.Instance.GetAchievement("a_armorTome");
			if (level >= achievement.targetValue)
			{
				MyPlayer instance = MyPlayer.Instance;
				if (instance.character == ECharacter.SirOofie)
				{
					bool flag = MyAchievements.TryUnlock("a_armorTome");
				}
			}
		}
		if (!MyAchievements.IsAchievementDone("a_bloodyCleaver"))
		{
			MyAchievement achievement2 = DataManager.Instance.GetAchievement("a_bloodyCleaver");
			if (level >= achievement2.targetValue)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				if (instance2.character == ECharacter.Vlad)
				{
					bool flag2 = MyAchievements.TryUnlock("a_bloodyCleaver");
				}
			}
		}
		if (MyAchievements.IsAchievementDone("a_demonicSoul"))
		{
			return;
		}
		MyAchievement achievement3 = DataManager.Instance.GetAchievement("a_demonicSoul");
		if (level >= achievement3.targetValue)
		{
			MyPlayer instance3 = MyPlayer.Instance;
			if (instance3.character == ECharacter.Calcium)
			{
				bool flag3 = MyAchievements.TryUnlock("a_demonicSoul");
			}
		}
	}

	private static void OnChestBought()
	{
	}

	private static void OnShrineCharged(bool noChargeInterruption)
	{
		int num = chargedShrines + 1;
		chargedShrines = num;
		if (noChargeInterruption)
		{
			int num2 = chargedShrinesNoInterruptions + 1;
			chargedShrinesNoInterruptions = num2;
		}
		if (chargedShrines >= totalChargeShrines && !MyAchievements.IsAchievementDone("a_suckyMagnet"))
		{
			bool flag = MyAchievements.TryUnlock("a_suckyMagnet");
		}
		if (!MyAchievements.IsAchievementDone("a_chaosTome") && MapController.index >= 2 && chargedShrinesNoInterruptions >= totalChargeShrines)
		{
			bool flag2 = MyAchievements.TryUnlock("a_chaosTome");
		}
	}

	private static void OnChargeShrineSpawned()
	{
		int num = totalChargeShrines + 1;
		totalChargeShrines = num;
	}

	private static void OnMicrowaveUsed(EItem eItem)
	{
		if (!MyAchievements.IsAchievementDone("a_noelle"))
		{
			if (eItem != EItem.IceCrystal)
			{
				consecutiveIceCrystalCooks = 0;
			}
			else
			{
				int num = consecutiveIceCrystalCooks + 1;
				consecutiveIceCrystalCooks = num;
				int achievementTargetValue = MyAchievements.GetAchievementTargetValue("a_noelle");
				if (consecutiveIceCrystalCooks >= achievementTargetValue)
				{
					bool flag = MyAchievements.TryUnlock("a_noelle");
				}
			}
		}
		if (MyAchievements.IsAchievementDone("a_poisonGloves"))
		{
			return;
		}
		if (eItem != EItem.MoldyCheese)
		{
			consecutiveMoldyCheeseCooks = 0;
			return;
		}
		int num2 = consecutiveMoldyCheeseCooks + 1;
		consecutiveMoldyCheeseCooks = num2;
		int achievementTargetValue2 = MyAchievements.GetAchievementTargetValue("a_poisonGloves");
		if (consecutiveMoldyCheeseCooks >= achievementTargetValue2)
		{
			bool flag2 = MyAchievements.TryUnlock("a_poisonGloves");
		}
	}

	private static void OnGhostBossDied()
	{
		//IL_00a0: Invalid comparison between I4 and F4
		if (!MyAchievements.IsAchievementDone("a_scythe"))
		{
			bool flag = MyAchievements.TryUnlock("a_scythe");
		}
		if (MyAchievements.IsAchievementDone("a_hatSunglasses"))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.character == ECharacter.Calcium)
		{
			int achievementTargetValue = MyAchievements.GetAchievementTargetValue("a_hatSunglasses");
			if (!((float)achievementTargetValue < MyTime.stageTimer))
			{
				bool flag2 = MyAchievements.TryUnlock("a_hatSunglasses");
			}
		}
	}

	private static void OnWeaponAddedOrUpgraded(WeaponBase weapon)
	{
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.inventory == null)
		{
			return;
		}
		if (!MyAchievements.IsAchievementDone("a_durationTome"))
		{
			WeaponData weaponData = weapon.weaponData;
			if (weaponData.eWeapon == EWeapon.Axe)
			{
				int achievementTargetValue = MyAchievements.GetAchievementTargetValue("a_durationTome");
				if (weapon.level >= achievementTargetValue)
				{
					bool flag = MyAchievements.TryUnlock("a_durationTome");
				}
			}
		}
		if (!MyAchievements.IsAchievementDone("a_wirelessDaggers"))
		{
			WeaponData weaponData2 = weapon.weaponData;
			if (weaponData2.eWeapon == EWeapon.LightningStaff)
			{
				int achievementTargetValue2 = MyAchievements.GetAchievementTargetValue("a_wirelessDaggers");
				if (weapon.level >= achievementTargetValue2)
				{
					bool flag2 = MyAchievements.TryUnlock("a_wirelessDaggers");
				}
			}
		}
		MyPlayer instance2 = MyPlayer.Instance;
		if (!MyAchievements.IsAchievementDone("a_wizardsHat") && instance2.character == ECharacter.Vlad && weapon.level > 40)
		{
			bool flag3 = MyAchievements.TryUnlock("a_wizardsHat");
		}
		if (MyAchievements.IsAchievementDone("a_hatMagic") || instance2.character != ECharacter.Fox)
		{
			return;
		}
		int achievementTargetValue3 = MyAchievements.GetAchievementTargetValue("a_hatMagic");
		MyPlayer instance3 = MyPlayer.Instance;
		PlayerInventory inventory = instance3.inventory;
		int weaponLevel = inventory.weaponInventory.GetWeaponLevel(EWeapon.FireStaff);
		if (weaponLevel < achievementTargetValue3)
		{
			return;
		}
		MyPlayer instance4 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance4.inventory;
		int weaponLevel2 = inventory2.weaponInventory.GetWeaponLevel(EWeapon.LightningStaff);
		if (weaponLevel2 >= achievementTargetValue3)
		{
			MyPlayer instance5 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance5.inventory;
			int weaponLevel3 = inventory3.weaponInventory.GetWeaponLevel(EWeapon.BloodMagic);
			if (weaponLevel3 >= achievementTargetValue3)
			{
				bool flag4 = MyAchievements.TryUnlock("a_hatMagic");
			}
		}
	}

	private static void OnTomeAddedOrUpgraded(ETome eTome, EStat stat)
	{
		if (!MyAchievements.IsAchievementDone("a_turboSocks") && eTome == ETome.Agility)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			int tomeLevel = inventory.tomeInventory.GetTomeLevel(ETome.Agility);
			if (MyAchievements.CheckAchievementValue("a_turboSocks", tomeLevel))
			{
				bool flag = MyAchievements.TryUnlock("a_turboSocks");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_battery") && eTome == ETome.Cooldown)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			int tomeLevel2 = inventory2.tomeInventory.GetTomeLevel(ETome.Cooldown);
			if (MyAchievements.CheckAchievementValue("a_battery", tomeLevel2))
			{
				bool flag2 = MyAchievements.TryUnlock("a_battery");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_leechingCrystal") && eTome == ETome.Regeneration)
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance3.inventory;
			int tomeLevel3 = inventory3.tomeInventory.GetTomeLevel(ETome.Regeneration);
			if (MyAchievements.CheckAchievementValue("a_leechingCrystal", tomeLevel3))
			{
				bool flag3 = MyAchievements.TryUnlock("a_leechingCrystal");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_echoShard") && eTome == ETome.Xp)
		{
			MyPlayer instance4 = MyPlayer.Instance;
			PlayerInventory inventory4 = instance4.inventory;
			int tomeLevel4 = inventory4.tomeInventory.GetTomeLevel(ETome.Xp);
			if (MyAchievements.CheckAchievementValue("a_echoShard", tomeLevel4))
			{
				bool flag4 = MyAchievements.TryUnlock("a_echoShard");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_turboSkates") && (eTome == ETome.Agility || eTome == ETome.Cooldown))
		{
			MyAchievement achievement = DataManager.Instance.GetAchievement("a_turboSkates");
			MyPlayer instance5 = MyPlayer.Instance;
			PlayerInventory inventory5 = instance5.inventory;
			int tomeLevel5 = inventory5.tomeInventory.GetTomeLevel(ETome.Agility);
			if (tomeLevel5 >= achievement.targetValue)
			{
				MyPlayer instance6 = MyPlayer.Instance;
				PlayerInventory inventory6 = instance6.inventory;
				int tomeLevel6 = inventory6.tomeInventory.GetTomeLevel(ETome.Cooldown);
				if (tomeLevel6 >= achievement.targetValue)
				{
					bool flag5 = MyAchievements.TryUnlock("a_turboSkates");
				}
			}
		}
		if (!MyAchievements.IsAchievementDone("a_shatteredKnowledge") && eTome == ETome.Attraction)
		{
			MyPlayer instance7 = MyPlayer.Instance;
			PlayerInventory inventory7 = instance7.inventory;
			int tomeLevel7 = inventory7.tomeInventory.GetTomeLevel(ETome.Attraction);
			if (MyAchievements.CheckAchievementValue("a_shatteredKnowledge", tomeLevel7))
			{
				bool flag6 = MyAchievements.TryUnlock("a_shatteredKnowledge");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_sniperRifle") && eTome == ETome.Precision)
		{
			MyPlayer instance8 = MyPlayer.Instance;
			PlayerInventory inventory8 = instance8.inventory;
			int tomeLevel8 = inventory8.tomeInventory.GetTomeLevel(ETome.Precision);
			if (MyAchievements.CheckAchievementValue("a_sniperRifle", tomeLevel8))
			{
				bool flag7 = MyAchievements.TryUnlock("a_sniperRifle");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_bloodMagic") && eTome == ETome.Blood)
		{
			MyPlayer instance9 = MyPlayer.Instance;
			PlayerInventory inventory9 = instance9.inventory;
			int tomeLevel9 = inventory9.tomeInventory.GetTomeLevel(ETome.Blood);
			if (MyAchievements.CheckAchievementValue("a_bloodMagic", tomeLevel9))
			{
				bool flag8 = MyAchievements.TryUnlock("a_bloodMagic");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_blackHole") && eTome == ETome.Knockback)
		{
			MyPlayer instance10 = MyPlayer.Instance;
			PlayerInventory inventory10 = instance10.inventory;
			int tomeLevel10 = inventory10.tomeInventory.GetTomeLevel(ETome.Knockback);
			if (MyAchievements.CheckAchievementValue("a_blackHole", tomeLevel10))
			{
				bool flag9 = MyAchievements.TryUnlock("a_blackHole");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_dice") && eTome == ETome.Luck)
		{
			MyPlayer instance11 = MyPlayer.Instance;
			PlayerInventory inventory11 = instance11.inventory;
			int tomeLevel11 = inventory11.tomeInventory.GetTomeLevel(ETome.Luck);
			if (MyAchievements.CheckAchievementValue("a_dice", tomeLevel11))
			{
				bool flag10 = MyAchievements.TryUnlock("a_dice");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_corruptedSword") && eTome == ETome.Cursed && !(600f < MyTime.runTimer))
		{
			MyPlayer instance12 = MyPlayer.Instance;
			PlayerInventory inventory12 = instance12.inventory;
			int tomeLevel12 = inventory12.tomeInventory.GetTomeLevel(ETome.Cursed);
			if (MyAchievements.CheckAchievementValue("a_corruptedSword", tomeLevel12))
			{
				bool flag11 = MyAchievements.TryUnlock("a_corruptedSword");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_megachad") && eTome == ETome.Damage)
		{
			MyPlayer instance13 = MyPlayer.Instance;
			PlayerInventory inventory13 = instance13.inventory;
			int tomeLevel13 = inventory13.tomeInventory.GetTomeLevel(ETome.Damage);
			if (MyAchievements.CheckAchievementValue("a_megachad", tomeLevel13))
			{
				bool flag12 = MyAchievements.TryUnlock("a_megachad");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_athena") && eTome == ETome.Thorns)
		{
			MyPlayer instance14 = MyPlayer.Instance;
			PlayerInventory inventory14 = instance14.inventory;
			int tomeLevel14 = inventory14.tomeInventory.GetTomeLevel(ETome.Thorns);
			if (MyAchievements.CheckAchievementValue("a_athena", tomeLevel14))
			{
				bool flag13 = MyAchievements.TryUnlock("a_athena");
			}
		}
		if (!MyAchievements.IsAchievementDone("a_cursedGloves") && eTome == ETome.Cursed)
		{
			MyPlayer instance15 = MyPlayer.Instance;
			PlayerInventory inventory15 = instance15.inventory;
			int tomeLevel15 = inventory15.tomeInventory.GetTomeLevel(ETome.Cursed);
			if (MyAchievements.CheckAchievementValue("a_cursedGloves", tomeLevel15))
			{
				bool flag14 = MyAchievements.TryUnlock("a_cursedGloves");
			}
		}
	}

	private static void OnItemAdded(EItem item)
	{
		//IL_00ef: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		if (!MyAchievements.IsAchievementDone(a_kevin) && item == EItem.LeechingCrystal)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			int amount = inventory.itemInventory.GetAmount(EItem.LeechingCrystal);
			int achievementTargetValue = MyAchievements.GetAchievementTargetValue(a_kevin);
			if (amount >= achievementTargetValue)
			{
				bool flag = MyAchievements.TryUnlock(a_kevin);
			}
		}
		if (MyAchievements.IsAchievementDone(a_hatPot))
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		object obj = instance2.character - 20;
		bool flag2 = obj == null;
		object obj2 = item - 84;
		bool flag3 = obj2 == null;
		object obj3 = flag3 & flag2;
		if (obj3 != null)
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance3.inventory;
			int amount2 = inventory2.itemInventory.GetAmount(EItem.Pot);
			int achievementTargetValue2 = MyAchievements.GetAchievementTargetValue(a_hatPot);
			if (amount2 >= achievementTargetValue2)
			{
				bool flag4 = MyAchievements.TryUnlock(a_hatPot);
			}
		}
	}

	private static void OnPickupTriggered(Pickup pickup)
	{
	}

	private static void OnPotBroken()
	{
		if (!MyAchievements.IsAchievementDone("a_xpTome"))
		{
			int stat = RunStats.GetStat("potsBroken");
			MyAchievement achievement = DataManager.Instance.GetAchievement("a_xpTome");
			if (stat >= achievement.targetValue)
			{
				bool flag = MyAchievements.TryUnlock("a_xpTome");
			}
		}
	}

	private unsafe static void OnInteracted(BaseInteractable interactable, bool success)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_029e: Expected I, but got O
		//IL_02a6: Expected I, but got O
		//IL_02b6: Expected O, but got I
		//IL_032e: Expected O, but got I4
		//IL_02f2: Expected O, but got I
		//IL_0317: Expected O, but got I4
		//IL_018d: Expected O, but got Ref
		//IL_0274: Expected O, but got Ref
		//IL_01a4: Expected O, but got Ref
		//IL_028b: Expected O, but got Ref
		if ((object)interactable == null)
		{
			return;
		}
		nint num = (nint)typeof(InteractableTumbleWeed);
		nint num2 = (nint)interactable;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<InteractableTumbleWeed>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v2 (Il2CppClass<BaseInteractable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<InteractableTumbleWeed>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v2 (Il2CppClass<BaseInteractable>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v86+FFFFFFF8+v49 @ rax_v3*8]");
			if (0 == (nint)typeof(InteractableTumbleWeed))
			{
				obj3 = 1;
				goto IL_03e7;
			}
		}
		obj3 = 0;
		goto IL_03e7;
		IL_047f:
		object obj4;
		bool flag = obj4 == null;
		BaseInteractable baseInteractable = null;
		if (!flag)
		{
			baseInteractable = interactable;
		}
		bool flag2 = (object)baseInteractable == null;
		bool flag3 = false;
		if (!flag2)
		{
			flag3 = success;
		}
		if (flag3 && !MyAchievements.IsAchievementDone("a_boombox"))
		{
			int num4 = numBoomboxes + 1;
			numBoomboxes = num4;
			MyAchievement achievement = DataManager.Instance.GetAchievement("a_boombox");
			if (numBoomboxes >= achievement.targetValue)
			{
				bool flag4 = MyAchievements.TryUnlock("a_boombox");
			}
		}
		return;
		IL_03e7:
		bool flag5 = obj3 == null;
		BaseInteractable baseInteractable2 = null;
		if (!flag5)
		{
			baseInteractable2 = interactable;
		}
		bool flag6 = (object)baseInteractable2 == null;
		bool flag7 = false;
		if (!flag6)
		{
			flag7 = success;
		}
		if (flag7)
		{
			float num7 = default(float);
			if (!MyAchievements.IsAchievementDone("a_katana") && MapController.index == 0)
			{
				float num5 = UnityEngine.Random.Range(0f, 1f);
				int achievementTargetValue = MyAchievements.GetAchievementTargetValue("a_katana");
				float num6 = (float)achievementTargetValue / 100f;
				if (!(num6 < num5))
				{
					Transform transform = interactable.transform;
					Vector3 position = transform.position;
					Vector3 vector = RaycastUtility.RayToGround((Vector3)(&num7));
					object obj5 = Vector3.upVector + Vector3.upVector;
					float num8 = (float)obj5 + vector.x;
					EffectManager.Instance.TrySpawnKatanaQuest((Vector3)(&num7));
					num7 = num8;
				}
			}
			if (!MyAchievements.IsAchievementDone("a_shotgun") && MapController.index == 1)
			{
				float num9 = UnityEngine.Random.Range(0f, 1f);
				int achievementTargetValue2 = MyAchievements.GetAchievementTargetValue("a_shotgun");
				float num10 = (float)achievementTargetValue2 / 100f;
				if (!(num10 < num9))
				{
					Transform transform2 = interactable.transform;
					Vector3 position2 = transform2.position;
					Vector3 vector2 = RaycastUtility.RayToGround((Vector3)(&num7));
					EffectManager.Instance.TrySpawnShotgunQuest((Vector3)(&num7));
				}
			}
		}
		nint num11 = (nint)typeof(InteractableBoombox);
		nint num12 = (nint)interactable;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rdx_v7 (Il2CppClass<InteractableBoombox>)+130]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r8_v5 (Il2CppClass<BaseInteractable>)+130]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rdx_v7 (Il2CppClass<InteractableBoombox>)+130]");
		if (num13 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r8_v5 (Il2CppClass<BaseInteractable>)+C8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rax_v28+FFFFFFF8+v418 @ rax_v8*8]");
			bool flag8 = 0 == (nint)typeof(InteractableBoombox);
			obj4 = 1;
			if (flag8)
			{
				goto IL_047f;
			}
		}
		obj4 = 0;
		goto IL_047f;
	}

	private static void OnCryptSpeedrun(float cryptTime)
	{
		//IL_006a: Invalid comparison between I4 and F4
		if (!RsgController.isCurrentMapRandomSeed)
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		string skinAchievementName = AchievementGenerator.GetSkinAchievementName(instance.character, ESkinType.Crypt);
		if (!MyAchievements.IsAchievementDone(skinAchievementName))
		{
			MyAchievement achievement = DataManager.Instance.GetAchievement(skinAchievementName);
			if (!((float)achievement.targetValue < cryptTime))
			{
				bool flag = MyAchievements.TryUnlock(skinAchievementName);
			}
		}
	}

	private static void OnInteractableUsedDebug(string debugName)
	{
		CheckPotUnlock(debugName);
		CheckPumpkinUnlock(debugName);
	}

	private static void OnMainMenuOpened()
	{
		CheckCrownAchievement();
	}

	private static void CheckPotUnlock(string debugName)
	{
		GameManager instance = GameManager.Instance;
		if (instance._003CisCrypt_003Ek__BackingField && instance._003CcryptIndex_003Ek__BackingField == 0 && RsgController.isCurrentMapRandomSeed && !((HashSet<object>)(object)ChallengesTracker.modifierNames).Contains((object)"no_items") && (!(debugName != InteractableChest.debugNameCrypt) || debugName == InteractablePot.debugNameCrypt) && ((Dictionary<object, object>)(object)InteractablesStatus.interactablesByName).TryGetValue((object)InteractableChest.debugNameCrypt, out object value) && ((Dictionary<object, object>)(object)InteractablesStatus.interactablesByName).TryGetValue((object)InteractablePot.debugNameCrypt, out object value2) && ((InteractablesStatus.InteractableStatusContainer)value).IsDone() && ((InteractablesStatus.InteractableStatusContainer)value2).IsDone())
		{
			bool flag = MyAchievements.TryUnlock("a_potSteel");
		}
	}

	private static void CheckPumpkinUnlock(string debugName)
	{
		MyPlayer instance = MyPlayer.Instance;
		if (instance.character == ECharacter.Roberto && debugName == InteractablePot.debugGraveyardName && ((Dictionary<object, object>)(object)InteractablesStatus.interactablesByName).TryGetValue((object)InteractablePot.debugGraveyardName, out object value) && ((Dictionary<object, object>)(object)InteractablesStatus.interactablesByName).TryGetValue((object)InteractablePot.debugGraveyardName, out object value2) && ((InteractablesStatus.InteractableStatusContainer)value).IsDone() && ((InteractablesStatus.InteractableStatusContainer)value2).IsDone())
		{
			bool flag = MyAchievements.TryUnlock("a_pumpkin");
		}
	}

	private unsafe static void OnUnlock(MyAchievement achUnlocked)
	{
		//IL_0058: Expected O, but got Ref
		//IL_007c: Expected O, but got I
		//IL_00a4: Expected O, but got I
		if (MyAchievements.IsAchievementDone("a_allQuests"))
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ stack_-30+30]");
				if (!MyAchievements.IsAchievementDone((string)0))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ stack_-30+30]");
					if (!((string)0 == "a_allQuests"))
					{
						((List<MyAchievement>.Enumerator*)(&enumerator))->Dispose();
						return;
					}
				}
				continue;
			}
			((List<MyAchievement>.Enumerator*)(&enumerator))->Dispose();
			bool flag2 = MyAchievements.TryUnlock("a_allQuests");
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe static void OnPurchased(UnlockableBase unlockable)
	{
		if (MyAchievements.IsAchievementDone("a_unlockEverything"))
		{
			return;
		}
		List<UnlockableBase> allPurchasable = DataManager.Instance.GetAllPurchasable();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		UnityEngine.Object obj = default(UnityEngine.Object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				if (!flag)
				{
					if ((object)obj == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ stack_-30 (UnityEngine.Object)+18]");
					if ((nint)0 != (flag ? 1 : 0) && !MyAchievements.IsPurchased((UnlockableBase)obj))
					{
						((List<UnlockableBase>.Enumerator*)(&enumerator))->Dispose();
						return;
					}
				}
				continue;
			}
			((List<UnlockableBase>.Enumerator*)(&enumerator))->Dispose();
			bool flag2 = MyAchievements.TryUnlock("a_unlockEverything");
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe static void CheckCrownAchievement()
	{
		//IL_0065: Expected O, but got Ref
		//IL_006d: Expected O, but got Ref
		//IL_00e5: Expected O, but got I4
		//IL_0101: Expected I, but got O
		//IL_0109: Expected I, but got O
		//IL_0138: Expected I, but got O
		//IL_0170: Expected I, but got O
		//IL_01a7: Expected I, but got O
		//IL_01af: Expected O, but got I
		//IL_01df: Expected I, but got O
		//IL_020c: Expected I4, but got O
		//IL_0224: Expected I, but got O
		//IL_0264: Expected O, but got I4
		//IL_0283: Expected O, but got I4
		if (MyAchievements.IsAchievementDone("a_hatCrown"))
		{
			return;
		}
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ECharacter));
		Array values = Enum.GetValues(typeFromHandle);
		IEnumerator enumerator = values.GetEnumerator();
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj4 = default(object);
		object obj3 = (object)(&obj4);
		Array array = values;
		object obj5 = default(object);
		Array array2 = default(Array);
		object obj6 = default(object);
		object obj8 = default(object);
		while (true)
		{
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				if (obj5 != null)
				{
					bool flag = obj2 == null;
					array = null;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						bool flag2 = array2 == null;
						array = (Array)1;
						if (!flag2)
						{
							nint num = (nint)typeof(ECharacter);
							nint num2 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v21 (Il2CppClass<System.Array>)+40]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ r8_v14 (Il2CppClass<ECharacter>)+40]");
							bool flag3 = num3 != 0;
							nint num4 = (nint)typeof(ECharacter);
							array = array2;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								nint num5 = (nint)typeof(SaveManager);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rax_v39 (Il2CppClass<SaveManager>)+B8]");
								nint num6 = 0;
								SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
								bool flag4 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
								num4 = (nint)typeof(ECharacter);
								array = (Array)num6;
								if (!flag4)
								{
									bool flag5 = saveManager.progression == null;
									num4 = (nint)typeof(ECharacter);
									array = (Array)(object)saveManager.progression;
									if (!flag5)
									{
										CharacterProgression characterProgression = saveManager.progression.GetCharacterProgression((ECharacter)obj6);
										bool flag6 = characterProgression == null;
										num4 = unchecked((nint)null);
										array = (Array)(object)saveManager.progression;
										if (flag6)
										{
											break;
										}
										int num7 = XpUtility.XpToLevel(characterProgression.xp);
										object obj7 = num7 + 1;
										bool flag7 = (nint)obj7 >= 100;
										array = (Array)characterProgression.xp;
										if (!flag7)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180363560");
											return;
										}
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				obj3 = obj8;
				if (obj8 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				bool flag8 = MyAchievements.TryUnlock("a_hatCrown");
				return;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private static void OnLateFixedUpdate()
	{
		if (!(GameManager.Instance != null) || !(MapController._003CcurrentMap_003Ek__BackingField != null))
		{
			return;
		}
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData.eMap != EMap.Forest)
		{
			return;
		}
		if (!MyAchievements.IsAchievementDone(a_hatTophat))
		{
			int stat = RunStats.GetStat(EMyStat.kills);
			int achievementTargetValue = MyAchievements.GetAchievementTargetValue(a_hatTophat);
			if (stat >= achievementTargetValue)
			{
				bool flag = MyAchievements.TryUnlock(a_hatTophat);
			}
		}
		if (!MyAchievements.IsAchievementDone(a_hatTophatLong))
		{
			int stat2 = RunStats.GetStat(EMyStat.kills);
			int achievementTargetValue2 = MyAchievements.GetAchievementTargetValue(a_hatTophatLong);
			if (stat2 >= achievementTargetValue2)
			{
				bool flag2 = MyAchievements.TryUnlock(a_hatTophatLong);
			}
		}
	}

	unsafe static AchievementTracker()
	{
		//IL_0031: Expected O, but got Ref
		hasSpawnedLuckTomeQuest = false;
		a_tacticalGlasses = "a_tacticalGlasses";
		a_bossBuster = "a_bossBuster";
		a_luckTome = "a_luckTome";
		a_quinsMask = "a_quinsMask";
		a_roberto = "a_roberto";
		a_hatSheriff = "a_hatSheriff";
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		aegisDamageSource = text;
		a_hatPot = "a_hatPot";
		a_kevin = "a_kevin";
		a_hatTophat = "a_hatTophat";
		a_hatTophatLong = "a_hatTophatLong";
	}
}
