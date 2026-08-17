using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.MapGeneration.MapEvents;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Chests;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public static class TrackStats
{
	public static Action A_PotBroken;

	private static string minesWeaponDamageSource;

	private static string tornadoDamageSource;

	private static HashSet<EPickup> nonPowerupPickups;

	private static Dictionary<EMyStat, string> statStrings;

	public static void Init()
	{
		//IL_13af: Expected I, but got O
		//IL_13c0: Expected O, but got I4
		//IL_0091: Expected I, but got O
		//IL_00a2: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_0188: Expected I, but got O
		//IL_0199: Expected O, but got I4
		//IL_0203: Expected I, but got O
		//IL_0214: Expected O, but got I4
		//IL_0257: Expected I, but got O
		//IL_0268: Expected O, but got I4
		//IL_02fa: Expected I, but got O
		//IL_030b: Expected O, but got I4
		//IL_034e: Expected I, but got O
		//IL_035f: Expected O, but got I4
		//IL_14a2: Expected I, but got O
		//IL_14b3: Expected O, but got I4
		//IL_14c9: Expected I, but got O
		//IL_14ef: Expected I, but got O
		//IL_1500: Expected O, but got I4
		//IL_1516: Expected I, but got O
		//IL_04ca: Expected I, but got O
		//IL_04db: Expected O, but got I4
		//IL_051e: Expected I, but got O
		//IL_052f: Expected O, but got I4
		//IL_0599: Expected I, but got O
		//IL_05aa: Expected O, but got I4
		//IL_05ed: Expected I, but got O
		//IL_05fe: Expected O, but got I4
		//IL_0690: Expected I, but got O
		//IL_06a1: Expected O, but got I4
		//IL_06e4: Expected I, but got O
		//IL_06f5: Expected O, but got I4
		//IL_075f: Expected I, but got O
		//IL_0770: Expected O, but got I4
		//IL_07b3: Expected I, but got O
		//IL_07c4: Expected O, but got I4
		//IL_0856: Expected I, but got O
		//IL_0867: Expected O, but got I4
		//IL_08aa: Expected I, but got O
		//IL_08bb: Expected O, but got I4
		//IL_0925: Expected I, but got O
		//IL_0936: Expected O, but got I4
		//IL_0979: Expected I, but got O
		//IL_098a: Expected O, but got I4
		//IL_166d: Expected I, but got O
		//IL_16b5: Expected O, but got I4
		//IL_16cb: Expected I, but got O
		//IL_1726: Expected I, but got O
		//IL_16f9: Expected O, but got I4
		//IL_170f: Expected I, but got O
		//IL_176e: Expected O, but got I4
		//IL_1784: Expected I, but got O
		//IL_17b2: Expected O, but got I4
		//IL_17c8: Expected I, but got O
		//IL_0b56: Expected I, but got O
		//IL_0b67: Expected O, but got I4
		//IL_0baa: Expected I, but got O
		//IL_0bbb: Expected O, but got I4
		//IL_0bd7: Expected I, but got O
		//IL_183e: Expected O, but got I4
		//IL_1854: Expected I, but got O
		//IL_1882: Expected O, but got I4
		//IL_1898: Expected I, but got O
		//IL_0d07: Expected I, but got O
		//IL_0d18: Expected O, but got I4
		//IL_0d5b: Expected I, but got O
		//IL_0d6c: Expected O, but got I4
		//IL_0dd6: Expected I, but got O
		//IL_0de7: Expected O, but got I4
		//IL_0e2a: Expected I, but got O
		//IL_0e3b: Expected O, but got I4
		//IL_0ecd: Expected I, but got O
		//IL_0ede: Expected O, but got I4
		//IL_0f21: Expected I, but got O
		//IL_0f32: Expected O, but got I4
		//IL_0fc4: Expected I, but got O
		//IL_0fd5: Expected O, but got I4
		//IL_1018: Expected I, but got O
		//IL_1029: Expected O, but got I4
		//IL_1045: Expected I, but got O
		//IL_1996: Expected O, but got I4
		//IL_19ac: Expected I, but got O
		//IL_19da: Expected O, but got I4
		//IL_19f0: Expected I, but got O
		//IL_119d: Expected I, but got O
		//IL_11ae: Expected O, but got I4
		//IL_11f1: Expected I, but got O
		//IL_1202: Expected O, but got I4
		//IL_1a27: Expected I, but got O
		//IL_1a6f: Expected O, but got I4
		//IL_1a85: Expected I, but got O
		//IL_1ab3: Expected O, but got I4
		//IL_1ac9: Expected I, but got O
		//IL_131d: Expected I, but got O
		//IL_132e: Expected O, but got I4
		//IL_1371: Expected I, but got O
		//IL_1382: Expected O, but got I4
		RunStats.Init();
		Action<Enemy, DamageContainer> b = OnEnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyDied, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = null;
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
				goto IL_1b0f;
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
				goto IL_13f7;
			}
		}
		Action<Enemy, DamageContainer> b2 = OnEnemyDamage;
		Delegate obj6 = Delegate.Combine(Enemy.A_Damage, b2);
		if ((object)obj6 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action2 = default(Action<Enemy, DamageContainer>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_1402;
			}
			Enemy.A_Damage = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_1412;
			}
		}
		Action<PlayerInventory, int> b3 = OnGoldChange;
		Delegate obj8 = Delegate.Combine(PlayerInventory.A_GoldChange, b3);
		if ((object)obj8 == null)
		{
			PlayerInventory.A_GoldChange = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory, int> action3 = default(Action<PlayerInventory, int>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<PlayerInventory, int>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_144a;
			}
			PlayerInventory.A_GoldChange = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<PlayerInventory, int>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_145a;
			}
		}
		Action<int> b4 = OnSilverChange;
		Delegate obj10 = Delegate.Combine(ProgressionSaveFile.A_SilverChanged, b4);
		if ((object)obj10 == null)
		{
			ProgressionSaveFile.A_SilverChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action4 = default(Action<int>);
			bool flag6 = action4 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_146a;
			}
			ProgressionSaveFile.A_SilverChanged = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_147a;
			}
		}
		Action action5 = OnChestOpened;
		Delegate obj12 = Delegate.Combine(ChestWindowUi.A_Close, action5);
		if ((object)obj12 == null)
		{
			ChestWindowUi.A_Close = null;
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
			num2 = (nint)ChestWindowUi.A_Close;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num3 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_1b1f;
			}
			ChestWindowUi.A_Close = (Action)obj13;
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj12;
			}
			bool flag11 = (object)obj14 == null;
			num2 = (nint)ChestWindowUi.A_Close;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num4 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_1b2f;
			}
		}
		Action<EItem> b5 = OnItemAdded;
		Delegate obj15 = Delegate.Combine(ItemInventory.A_ItemAdded, b5);
		if ((object)obj15 == null)
		{
			ItemInventory.A_ItemAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action6 = default(Action<EItem>);
			bool flag12 = action6 == null;
			num2 = (nint)typeof(Action<EItem>);
			obj2 = obj15;
			obj3 = 0;
			obj4 = null;
			if (flag12)
			{
				goto IL_1524;
			}
			ItemInventory.A_ItemAdded = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj16 = default(object);
			bool flag13 = obj16 == null;
			num2 = (nint)typeof(Action<EItem>);
			obj2 = obj15;
			obj3 = 0;
			obj4 = null;
			if (flag13)
			{
				goto IL_1534;
			}
		}
		Action<MyAchievement> b6 = OnAchievementUnlocked;
		Delegate obj17 = Delegate.Combine(MyAchievements.A_Unlocked, b6);
		if ((object)obj17 == null)
		{
			MyAchievements.A_Unlocked = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyAchievement> action7 = default(Action<MyAchievement>);
			bool flag14 = action7 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj2 = obj17;
			obj3 = 0;
			obj4 = null;
			if (flag14)
			{
				goto IL_156c;
			}
			MyAchievements.A_Unlocked = action7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj18 = default(object);
			bool flag15 = obj18 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj2 = obj17;
			obj3 = 0;
			obj4 = null;
			if (flag15)
			{
				goto IL_157c;
			}
		}
		Action<UnlockableBase> b7 = OnUnlockPurchased;
		Delegate obj19 = Delegate.Combine(ProgressionSaveFile.A_UnlockablePurchased, b7);
		if ((object)obj19 == null)
		{
			ProgressionSaveFile.A_UnlockablePurchased = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<UnlockableBase> action8 = default(Action<UnlockableBase>);
			bool flag16 = action8 == null;
			num2 = (nint)typeof(Action<UnlockableBase>);
			obj2 = obj19;
			obj3 = 0;
			obj4 = null;
			if (flag16)
			{
				goto IL_158c;
			}
			ProgressionSaveFile.A_UnlockablePurchased = action8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj20 = default(object);
			bool flag17 = obj20 == null;
			num2 = (nint)typeof(Action<UnlockableBase>);
			obj2 = obj19;
			obj3 = 0;
			obj4 = null;
			if (flag17)
			{
				goto IL_159c;
			}
		}
		Action<ProjectileBase> b8 = OnProjectileSpawned;
		Delegate obj21 = Delegate.Combine(WeaponAttack.A_SpawnedProjectileSuccessfully, b8);
		if ((object)obj21 == null)
		{
			WeaponAttack.A_SpawnedProjectileSuccessfully = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ProjectileBase> action9 = default(Action<ProjectileBase>);
			bool flag18 = action9 == null;
			num2 = (nint)typeof(Action<ProjectileBase>);
			obj2 = obj21;
			obj3 = 0;
			obj4 = null;
			if (flag18)
			{
				goto IL_15d4;
			}
			WeaponAttack.A_SpawnedProjectileSuccessfully = action9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj22 = default(object);
			bool flag19 = obj22 == null;
			num = (nint)typeof(Action<ProjectileBase>);
			obj2 = obj21;
			obj3 = 0;
			obj4 = null;
			if (flag19)
			{
				goto IL_15e4;
			}
		}
		Action<BaseInteractable, bool> b9 = OnInteracted;
		Delegate obj23 = Delegate.Combine(DetectInteractables.A_Interacted, b9);
		if ((object)obj23 == null)
		{
			DetectInteractables.A_Interacted = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<BaseInteractable, bool> action10 = default(Action<BaseInteractable, bool>);
			bool flag20 = action10 == null;
			num = (nint)typeof(Action<BaseInteractable, bool>);
			obj2 = obj23;
			obj3 = 0;
			obj4 = null;
			if (flag20)
			{
				goto IL_15fc;
			}
			DetectInteractables.A_Interacted = action10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj24 = default(object);
			bool flag21 = obj24 == null;
			num = (nint)typeof(Action<BaseInteractable, bool>);
			obj2 = obj23;
			obj3 = 0;
			obj4 = null;
			if (flag21)
			{
				goto IL_160c;
			}
		}
		Action<bool> b10 = OnShrineCharged;
		Delegate obj25 = Delegate.Combine(ChargeShrine.A_Charged, b10);
		if ((object)obj25 == null)
		{
			ChargeShrine.A_Charged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action11 = default(Action<bool>);
			bool flag22 = action11 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj25;
			obj3 = 0;
			obj4 = null;
			if (flag22)
			{
				goto IL_1644;
			}
			ChargeShrine.A_Charged = action11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj26 = default(object);
			bool flag23 = obj26 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj25;
			obj3 = 0;
			obj4 = null;
			if (flag23)
			{
				goto IL_1654;
			}
		}
		num = (nint)InteractableShrineChallenge.A_Completed;
		Action action12 = OnChallengeShrineCompleted;
		Delegate obj27 = Delegate.Combine(InteractableShrineChallenge.A_Completed, action12);
		if ((object)obj27 == null)
		{
			InteractableShrineChallenge.A_Completed = null;
		}
		else
		{
			bool flag24 = (object)obj27.GetType() != typeof(Action);
			Delegate obj28 = null;
			if (!flag24)
			{
				obj28 = obj27;
			}
			bool flag25 = (object)obj28 == null;
			obj2 = action12;
			obj3 = 0;
			obj4 = obj27;
			nint num5 = (nint)typeof(Action);
			if (flag25)
			{
				goto IL_1b3f;
			}
			InteractableShrineChallenge.A_Completed = (Action)obj28;
			bool flag26 = (object)obj27.GetType() != typeof(Action);
			Delegate obj29 = null;
			if (!flag26)
			{
				obj29 = obj27;
			}
			bool flag27 = (object)obj29 == null;
			obj2 = action12;
			obj3 = 0;
			obj4 = obj27;
			nint num6 = (nint)typeof(Action);
			if (flag27)
			{
				goto IL_1b4f;
			}
		}
		num = (nint)InteractableChest.A_ChestBought;
		Action action13 = OnChestBought;
		Delegate obj30 = Delegate.Combine(InteractableChest.A_ChestBought, action13);
		if ((object)obj30 == null)
		{
			InteractableChest.A_ChestBought = null;
		}
		else
		{
			bool flag28 = (object)obj30.GetType() != typeof(Action);
			Delegate obj31 = null;
			if (!flag28)
			{
				obj31 = obj30;
			}
			bool flag29 = (object)obj31 == null;
			obj2 = action13;
			obj3 = 0;
			obj4 = obj30;
			nint num7 = (nint)typeof(Action);
			if (flag29)
			{
				goto IL_1b5f;
			}
			InteractableChest.A_ChestBought = (Action)obj31;
			bool flag30 = (object)obj30.GetType() != typeof(Action);
			Delegate obj32 = null;
			if (!flag30)
			{
				obj32 = obj30;
			}
			bool flag31 = (object)obj32 == null;
			obj2 = action13;
			obj3 = 0;
			obj4 = obj30;
			nint num8 = (nint)typeof(Action);
			if (flag31)
			{
				goto IL_1b6f;
			}
		}
		Action<InteractableShadyGuy> b11 = OnShadyGuyUsed;
		Delegate obj33 = Delegate.Combine(InteractableShadyGuy.A_ShadyGuyDone, b11);
		if ((object)obj33 == null)
		{
			InteractableShadyGuy.A_ShadyGuyDone = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<InteractableShadyGuy> action14 = default(Action<InteractableShadyGuy>);
			bool flag32 = action14 == null;
			num = (nint)typeof(Action<InteractableShadyGuy>);
			obj2 = obj33;
			obj3 = 0;
			obj4 = null;
			if (flag32)
			{
				goto IL_17fe;
			}
			InteractableShadyGuy.A_ShadyGuyDone = action14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj34 = default(object);
			bool flag33 = obj34 == null;
			num = (nint)typeof(Action<InteractableShadyGuy>);
			obj2 = obj33;
			obj3 = 0;
			obj4 = null;
			if (flag33)
			{
				goto IL_180e;
			}
		}
		num = (nint)ItemIceCube.A_FreezeEnemy;
		Action action15 = OnIcecubeFreezeEnemy;
		Delegate obj35 = Delegate.Combine(ItemIceCube.A_FreezeEnemy, action15);
		if ((object)obj35 == null)
		{
			ItemIceCube.A_FreezeEnemy = null;
		}
		else
		{
			bool flag34 = (object)obj35.GetType() != typeof(Action);
			Delegate obj36 = null;
			if (!flag34)
			{
				obj36 = obj35;
			}
			bool flag35 = (object)obj36 == null;
			obj2 = action15;
			obj3 = 0;
			obj4 = obj35;
			nint num9 = (nint)typeof(Action);
			if (flag35)
			{
				goto IL_1b7f;
			}
			ItemIceCube.A_FreezeEnemy = (Action)obj36;
			bool flag36 = (object)obj35.GetType() != typeof(Action);
			Delegate obj37 = null;
			if (!flag36)
			{
				obj37 = obj35;
			}
			bool flag37 = (object)obj37 == null;
			obj2 = action15;
			obj3 = 0;
			obj4 = obj35;
			nint num10 = (nint)typeof(Action);
			if (flag37)
			{
				goto IL_1b8f;
			}
		}
		Action<PlayerXp, int> b12 = OnXpAdded;
		Delegate obj38 = Delegate.Combine(PlayerXp.A_XpAdded, b12);
		if ((object)obj38 == null)
		{
			PlayerXp.A_XpAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerXp, int> action16 = default(Action<PlayerXp, int>);
			bool flag38 = action16 == null;
			num = (nint)typeof(Action<PlayerXp, int>);
			obj2 = obj38;
			obj3 = 0;
			obj4 = null;
			if (flag38)
			{
				goto IL_18ce;
			}
			PlayerXp.A_XpAdded = action16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj39 = default(object);
			bool flag39 = obj39 == null;
			num = (nint)typeof(Action<PlayerXp, int>);
			obj2 = obj38;
			obj3 = 0;
			obj4 = null;
			if (flag39)
			{
				goto IL_18de;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> b13 = new Action<object, object, bool>(OnPlayerTakeDamage);
		Delegate obj40 = Delegate.Combine(PlayerHealth.A_TakeDamage, b13);
		if ((object)obj40 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action17 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag40 = action17 == null;
			num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj40;
			obj3 = 0;
			obj4 = null;
			if (flag40)
			{
				goto IL_1916;
			}
			PlayerHealth.A_TakeDamage = action17;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj41 = default(object);
			bool flag41 = obj41 == null;
			num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj40;
			obj3 = 0;
			obj4 = null;
			if (flag41)
			{
				goto IL_1926;
			}
		}
		Action<Enemy> b14 = OnEvade;
		Delegate obj42 = Delegate.Combine(PlayerHealth.A_Evaded, b14);
		if ((object)obj42 == null)
		{
			PlayerHealth.A_Evaded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action18 = default(Action<Enemy>);
			bool flag42 = action18 == null;
			num = (nint)typeof(Action<Enemy>);
			obj2 = obj42;
			obj3 = 0;
			obj4 = null;
			if (flag42)
			{
				goto IL_1936;
			}
			PlayerHealth.A_Evaded = action18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj43 = default(object);
			bool flag43 = obj43 == null;
			num = (nint)typeof(Action<Enemy>);
			obj2 = obj42;
			obj3 = 0;
			obj4 = null;
			if (flag43)
			{
				goto IL_1946;
			}
		}
		Action<int> b15 = OnLifestealHealing;
		Delegate obj44 = Delegate.Combine(PlayerHealth.A_LifestealHealing, b15);
		if ((object)obj44 == null)
		{
			PlayerHealth.A_LifestealHealing = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action19 = default(Action<int>);
			bool flag44 = action19 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj44;
			obj3 = 0;
			obj4 = null;
			if (flag44)
			{
				goto IL_1956;
			}
			PlayerHealth.A_LifestealHealing = action19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj45 = default(object);
			bool flag45 = obj45 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj44;
			obj3 = 0;
			obj4 = null;
			if (flag45)
			{
				goto IL_1966;
			}
		}
		num = (nint)PlayerHealth.A_Died;
		Action action20 = OnDead;
		Delegate obj46 = Delegate.Combine(PlayerHealth.A_Died, action20);
		if ((object)obj46 == null)
		{
			PlayerHealth.A_Died = null;
		}
		else
		{
			bool flag46 = (object)obj46.GetType() != typeof(Action);
			Delegate obj47 = null;
			if (!flag46)
			{
				obj47 = obj46;
			}
			bool flag47 = (object)obj47 == null;
			obj2 = action20;
			obj3 = 0;
			obj4 = obj46;
			nint num11 = (nint)typeof(Action);
			if (flag47)
			{
				goto IL_1b9f;
			}
			PlayerHealth.A_Died = (Action)obj47;
			bool flag48 = (object)obj46.GetType() != typeof(Action);
			Delegate obj48 = null;
			if (!flag48)
			{
				obj48 = obj46;
			}
			bool flag49 = (object)obj48 == null;
			obj2 = action20;
			obj3 = 0;
			obj4 = obj46;
			nint num12 = (nint)typeof(Action);
			if (flag49)
			{
				goto IL_1baf;
			}
		}
		Action<Pickup> b16 = OnPickup;
		Delegate obj49 = Delegate.Combine(Pickup.A_PickupTriggered, b16);
		if ((object)obj49 == null)
		{
			Pickup.A_PickupTriggered = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action21 = default(Action<Pickup>);
			bool flag50 = action21 == null;
			num = (nint)typeof(Action<Pickup>);
			obj2 = obj49;
			obj3 = 0;
			obj4 = null;
			if (flag50)
			{
				goto IL_19fe;
			}
			Pickup.A_PickupTriggered = action21;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj50 = default(object);
			bool flag51 = obj50 == null;
			num = (nint)typeof(Action<Pickup>);
			obj2 = obj49;
			obj3 = 0;
			obj4 = null;
			if (flag51)
			{
				goto IL_1a0e;
			}
		}
		num = (nint)InteractableMicrowave.A_Exploded;
		Action action22 = OnMicrowaveExploded;
		Delegate obj51 = Delegate.Combine(InteractableMicrowave.A_Exploded, action22);
		if ((object)obj51 == null)
		{
			InteractableMicrowave.A_Exploded = null;
		}
		else
		{
			bool flag52 = (object)obj51.GetType() != typeof(Action);
			Delegate obj52 = null;
			if (!flag52)
			{
				obj52 = obj51;
			}
			bool flag53 = (object)obj52 == null;
			obj2 = action22;
			obj3 = 0;
			obj4 = obj51;
			nint num13 = (nint)typeof(Action);
			if (flag53)
			{
				goto IL_1bbf;
			}
			InteractableMicrowave.A_Exploded = (Action)obj52;
			bool flag54 = (object)obj51.GetType() != typeof(Action);
			Delegate obj53 = null;
			if (!flag54)
			{
				obj53 = obj51;
			}
			bool flag55 = (object)obj53 == null;
			obj2 = action22;
			obj3 = 0;
			obj4 = obj51;
			nint num14 = (nint)typeof(Action);
			if (flag55)
			{
				goto IL_1bcf;
			}
		}
		Action<int> b17 = OnPunchedByKevin;
		Delegate obj54 = Delegate.Combine(ItemKevin.A_PunchedByKevin, b17);
		if ((object)obj54 == null)
		{
			ItemKevin.A_PunchedByKevin = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action23 = default(Action<int>);
		bool flag56 = action23 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj54;
		obj3 = 0;
		obj4 = null;
		if (flag56)
		{
			goto IL_1aff;
		}
		ItemKevin.A_PunchedByKevin = action23;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj55 = default(object);
		bool flag57 = obj55 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj54;
		obj3 = 0;
		obj4 = null;
		if (!flag57)
		{
			return;
		}
		goto IL_1b0f;
		IL_1b6f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b5f;
		IL_15e4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_15d4;
		IL_1b4f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b3f;
		IL_1644:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_160c;
		IL_17fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b6f;
		IL_1654:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1644;
		IL_156c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1534;
		IL_159c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_158c;
		IL_15d4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_159c;
		IL_15fc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_15e4;
		IL_158c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_157c;
		IL_160c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_15fc;
		IL_1b3f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1654;
		IL_147a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_146a;
		IL_1412:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1402;
		IL_1b1f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_147a;
		IL_146a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_145a;
		IL_1534:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1524;
		IL_13f7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_1524:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b2f;
		IL_1b2f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b1f;
		IL_1aff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1bcf;
		IL_144a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1412;
		IL_157c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_156c;
		IL_145a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_144a;
		IL_1a0e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_19fe;
		IL_1baf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b9f;
		IL_1bcf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1bbf;
		IL_1bbf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1a0e;
		IL_1402:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_13f7;
		IL_1956:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1946;
		IL_1b0f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1aff;
		IL_19fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1baf;
		IL_1b9f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1966;
		IL_1916:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_18de;
		IL_1966:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1956;
		IL_1946:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1936;
		IL_1936:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1926;
		IL_1b7f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_180e;
		IL_1926:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1916;
		IL_18de:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_18ce;
		IL_18ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b8f;
		IL_1b5f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b4f;
		IL_1b8f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b7f;
		IL_180e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_17fe;
	}

	public static void Cleanup()
	{
		//IL_13af: Expected I, but got O
		//IL_13c0: Expected O, but got I4
		//IL_0091: Expected I, but got O
		//IL_00a2: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_0188: Expected I, but got O
		//IL_0199: Expected O, but got I4
		//IL_0203: Expected I, but got O
		//IL_0214: Expected O, but got I4
		//IL_0257: Expected I, but got O
		//IL_0268: Expected O, but got I4
		//IL_02fa: Expected I, but got O
		//IL_030b: Expected O, but got I4
		//IL_034e: Expected I, but got O
		//IL_035f: Expected O, but got I4
		//IL_14a2: Expected I, but got O
		//IL_14b3: Expected O, but got I4
		//IL_14c9: Expected I, but got O
		//IL_14ef: Expected I, but got O
		//IL_1500: Expected O, but got I4
		//IL_1516: Expected I, but got O
		//IL_04ca: Expected I, but got O
		//IL_04db: Expected O, but got I4
		//IL_051e: Expected I, but got O
		//IL_052f: Expected O, but got I4
		//IL_0599: Expected I, but got O
		//IL_05aa: Expected O, but got I4
		//IL_05ed: Expected I, but got O
		//IL_05fe: Expected O, but got I4
		//IL_0690: Expected I, but got O
		//IL_06a1: Expected O, but got I4
		//IL_06e4: Expected I, but got O
		//IL_06f5: Expected O, but got I4
		//IL_075f: Expected I, but got O
		//IL_0770: Expected O, but got I4
		//IL_07b3: Expected I, but got O
		//IL_07c4: Expected O, but got I4
		//IL_0856: Expected I, but got O
		//IL_0867: Expected O, but got I4
		//IL_08aa: Expected I, but got O
		//IL_08bb: Expected O, but got I4
		//IL_0925: Expected I, but got O
		//IL_0936: Expected O, but got I4
		//IL_0979: Expected I, but got O
		//IL_098a: Expected O, but got I4
		//IL_166d: Expected I, but got O
		//IL_16b5: Expected O, but got I4
		//IL_16cb: Expected I, but got O
		//IL_1726: Expected I, but got O
		//IL_16f9: Expected O, but got I4
		//IL_170f: Expected I, but got O
		//IL_176e: Expected O, but got I4
		//IL_1784: Expected I, but got O
		//IL_17b2: Expected O, but got I4
		//IL_17c8: Expected I, but got O
		//IL_0b56: Expected I, but got O
		//IL_0b67: Expected O, but got I4
		//IL_0baa: Expected I, but got O
		//IL_0bbb: Expected O, but got I4
		//IL_0bd7: Expected I, but got O
		//IL_183e: Expected O, but got I4
		//IL_1854: Expected I, but got O
		//IL_1882: Expected O, but got I4
		//IL_1898: Expected I, but got O
		//IL_0d07: Expected I, but got O
		//IL_0d18: Expected O, but got I4
		//IL_0d5b: Expected I, but got O
		//IL_0d6c: Expected O, but got I4
		//IL_0dd6: Expected I, but got O
		//IL_0de7: Expected O, but got I4
		//IL_0e2a: Expected I, but got O
		//IL_0e3b: Expected O, but got I4
		//IL_0ecd: Expected I, but got O
		//IL_0ede: Expected O, but got I4
		//IL_0f21: Expected I, but got O
		//IL_0f32: Expected O, but got I4
		//IL_0fc4: Expected I, but got O
		//IL_0fd5: Expected O, but got I4
		//IL_1018: Expected I, but got O
		//IL_1029: Expected O, but got I4
		//IL_1045: Expected I, but got O
		//IL_1996: Expected O, but got I4
		//IL_19ac: Expected I, but got O
		//IL_19da: Expected O, but got I4
		//IL_19f0: Expected I, but got O
		//IL_119d: Expected I, but got O
		//IL_11ae: Expected O, but got I4
		//IL_11f1: Expected I, but got O
		//IL_1202: Expected O, but got I4
		//IL_1a27: Expected I, but got O
		//IL_1a6f: Expected O, but got I4
		//IL_1a85: Expected I, but got O
		//IL_1ab3: Expected O, but got I4
		//IL_1ac9: Expected I, but got O
		//IL_131d: Expected I, but got O
		//IL_132e: Expected O, but got I4
		//IL_1371: Expected I, but got O
		//IL_1382: Expected O, but got I4
		RunStats.Cleanup();
		Action<Enemy, DamageContainer> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyDied, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = null;
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
				goto IL_1b0f;
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
				goto IL_13f7;
			}
		}
		Action<Enemy, DamageContainer> value2 = OnEnemyDamage;
		Delegate obj6 = Delegate.Remove(Enemy.A_Damage, value2);
		if ((object)obj6 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action2 = default(Action<Enemy, DamageContainer>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_1402;
			}
			Enemy.A_Damage = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_1412;
			}
		}
		Action<PlayerInventory, int> value3 = OnGoldChange;
		Delegate obj8 = Delegate.Remove(PlayerInventory.A_GoldChange, value3);
		if ((object)obj8 == null)
		{
			PlayerInventory.A_GoldChange = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory, int> action3 = default(Action<PlayerInventory, int>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<PlayerInventory, int>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_144a;
			}
			PlayerInventory.A_GoldChange = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<PlayerInventory, int>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_145a;
			}
		}
		Action<int> value4 = OnSilverChange;
		Delegate obj10 = Delegate.Remove(ProgressionSaveFile.A_SilverChanged, value4);
		if ((object)obj10 == null)
		{
			ProgressionSaveFile.A_SilverChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action4 = default(Action<int>);
			bool flag6 = action4 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_146a;
			}
			ProgressionSaveFile.A_SilverChanged = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_147a;
			}
		}
		Action action5 = OnChestOpened;
		Delegate obj12 = Delegate.Remove(ChestWindowUi.A_Close, action5);
		if ((object)obj12 == null)
		{
			ChestWindowUi.A_Close = null;
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
			num2 = (nint)ChestWindowUi.A_Close;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num3 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_1b1f;
			}
			ChestWindowUi.A_Close = (Action)obj13;
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj12;
			}
			bool flag11 = (object)obj14 == null;
			num2 = (nint)ChestWindowUi.A_Close;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num4 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_1b2f;
			}
		}
		Action<EItem> value5 = OnItemAdded;
		Delegate obj15 = Delegate.Remove(ItemInventory.A_ItemAdded, value5);
		if ((object)obj15 == null)
		{
			ItemInventory.A_ItemAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action6 = default(Action<EItem>);
			bool flag12 = action6 == null;
			num2 = (nint)typeof(Action<EItem>);
			obj2 = obj15;
			obj3 = 0;
			obj4 = null;
			if (flag12)
			{
				goto IL_1524;
			}
			ItemInventory.A_ItemAdded = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj16 = default(object);
			bool flag13 = obj16 == null;
			num2 = (nint)typeof(Action<EItem>);
			obj2 = obj15;
			obj3 = 0;
			obj4 = null;
			if (flag13)
			{
				goto IL_1534;
			}
		}
		Action<MyAchievement> value6 = OnAchievementUnlocked;
		Delegate obj17 = Delegate.Remove(MyAchievements.A_Unlocked, value6);
		if ((object)obj17 == null)
		{
			MyAchievements.A_Unlocked = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyAchievement> action7 = default(Action<MyAchievement>);
			bool flag14 = action7 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj2 = obj17;
			obj3 = 0;
			obj4 = null;
			if (flag14)
			{
				goto IL_156c;
			}
			MyAchievements.A_Unlocked = action7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj18 = default(object);
			bool flag15 = obj18 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj2 = obj17;
			obj3 = 0;
			obj4 = null;
			if (flag15)
			{
				goto IL_157c;
			}
		}
		Action<UnlockableBase> value7 = OnUnlockPurchased;
		Delegate obj19 = Delegate.Remove(ProgressionSaveFile.A_UnlockablePurchased, value7);
		if ((object)obj19 == null)
		{
			ProgressionSaveFile.A_UnlockablePurchased = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<UnlockableBase> action8 = default(Action<UnlockableBase>);
			bool flag16 = action8 == null;
			num2 = (nint)typeof(Action<UnlockableBase>);
			obj2 = obj19;
			obj3 = 0;
			obj4 = null;
			if (flag16)
			{
				goto IL_158c;
			}
			ProgressionSaveFile.A_UnlockablePurchased = action8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj20 = default(object);
			bool flag17 = obj20 == null;
			num2 = (nint)typeof(Action<UnlockableBase>);
			obj2 = obj19;
			obj3 = 0;
			obj4 = null;
			if (flag17)
			{
				goto IL_159c;
			}
		}
		Action<ProjectileBase> value8 = OnProjectileSpawned;
		Delegate obj21 = Delegate.Remove(WeaponAttack.A_SpawnedProjectileSuccessfully, value8);
		if ((object)obj21 == null)
		{
			WeaponAttack.A_SpawnedProjectileSuccessfully = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ProjectileBase> action9 = default(Action<ProjectileBase>);
			bool flag18 = action9 == null;
			num2 = (nint)typeof(Action<ProjectileBase>);
			obj2 = obj21;
			obj3 = 0;
			obj4 = null;
			if (flag18)
			{
				goto IL_15d4;
			}
			WeaponAttack.A_SpawnedProjectileSuccessfully = action9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj22 = default(object);
			bool flag19 = obj22 == null;
			num = (nint)typeof(Action<ProjectileBase>);
			obj2 = obj21;
			obj3 = 0;
			obj4 = null;
			if (flag19)
			{
				goto IL_15e4;
			}
		}
		Action<BaseInteractable, bool> value9 = OnInteracted;
		Delegate obj23 = Delegate.Remove(DetectInteractables.A_Interacted, value9);
		if ((object)obj23 == null)
		{
			DetectInteractables.A_Interacted = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<BaseInteractable, bool> action10 = default(Action<BaseInteractable, bool>);
			bool flag20 = action10 == null;
			num = (nint)typeof(Action<BaseInteractable, bool>);
			obj2 = obj23;
			obj3 = 0;
			obj4 = null;
			if (flag20)
			{
				goto IL_15fc;
			}
			DetectInteractables.A_Interacted = action10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj24 = default(object);
			bool flag21 = obj24 == null;
			num = (nint)typeof(Action<BaseInteractable, bool>);
			obj2 = obj23;
			obj3 = 0;
			obj4 = null;
			if (flag21)
			{
				goto IL_160c;
			}
		}
		Action<bool> value10 = OnShrineCharged;
		Delegate obj25 = Delegate.Remove(ChargeShrine.A_Charged, value10);
		if ((object)obj25 == null)
		{
			ChargeShrine.A_Charged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action11 = default(Action<bool>);
			bool flag22 = action11 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj25;
			obj3 = 0;
			obj4 = null;
			if (flag22)
			{
				goto IL_1644;
			}
			ChargeShrine.A_Charged = action11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj26 = default(object);
			bool flag23 = obj26 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj25;
			obj3 = 0;
			obj4 = null;
			if (flag23)
			{
				goto IL_1654;
			}
		}
		num = (nint)InteractableShrineChallenge.A_Completed;
		Action action12 = OnChallengeShrineCompleted;
		Delegate obj27 = Delegate.Remove(InteractableShrineChallenge.A_Completed, action12);
		if ((object)obj27 == null)
		{
			InteractableShrineChallenge.A_Completed = null;
		}
		else
		{
			bool flag24 = (object)obj27.GetType() != typeof(Action);
			Delegate obj28 = null;
			if (!flag24)
			{
				obj28 = obj27;
			}
			bool flag25 = (object)obj28 == null;
			obj2 = action12;
			obj3 = 0;
			obj4 = obj27;
			nint num5 = (nint)typeof(Action);
			if (flag25)
			{
				goto IL_1b3f;
			}
			InteractableShrineChallenge.A_Completed = (Action)obj28;
			bool flag26 = (object)obj27.GetType() != typeof(Action);
			Delegate obj29 = null;
			if (!flag26)
			{
				obj29 = obj27;
			}
			bool flag27 = (object)obj29 == null;
			obj2 = action12;
			obj3 = 0;
			obj4 = obj27;
			nint num6 = (nint)typeof(Action);
			if (flag27)
			{
				goto IL_1b4f;
			}
		}
		num = (nint)InteractableChest.A_ChestBought;
		Action action13 = OnChestBought;
		Delegate obj30 = Delegate.Remove(InteractableChest.A_ChestBought, action13);
		if ((object)obj30 == null)
		{
			InteractableChest.A_ChestBought = null;
		}
		else
		{
			bool flag28 = (object)obj30.GetType() != typeof(Action);
			Delegate obj31 = null;
			if (!flag28)
			{
				obj31 = obj30;
			}
			bool flag29 = (object)obj31 == null;
			obj2 = action13;
			obj3 = 0;
			obj4 = obj30;
			nint num7 = (nint)typeof(Action);
			if (flag29)
			{
				goto IL_1b5f;
			}
			InteractableChest.A_ChestBought = (Action)obj31;
			bool flag30 = (object)obj30.GetType() != typeof(Action);
			Delegate obj32 = null;
			if (!flag30)
			{
				obj32 = obj30;
			}
			bool flag31 = (object)obj32 == null;
			obj2 = action13;
			obj3 = 0;
			obj4 = obj30;
			nint num8 = (nint)typeof(Action);
			if (flag31)
			{
				goto IL_1b6f;
			}
		}
		Action<InteractableShadyGuy> value11 = OnShadyGuyUsed;
		Delegate obj33 = Delegate.Remove(InteractableShadyGuy.A_ShadyGuyDone, value11);
		if ((object)obj33 == null)
		{
			InteractableShadyGuy.A_ShadyGuyDone = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<InteractableShadyGuy> action14 = default(Action<InteractableShadyGuy>);
			bool flag32 = action14 == null;
			num = (nint)typeof(Action<InteractableShadyGuy>);
			obj2 = obj33;
			obj3 = 0;
			obj4 = null;
			if (flag32)
			{
				goto IL_17fe;
			}
			InteractableShadyGuy.A_ShadyGuyDone = action14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj34 = default(object);
			bool flag33 = obj34 == null;
			num = (nint)typeof(Action<InteractableShadyGuy>);
			obj2 = obj33;
			obj3 = 0;
			obj4 = null;
			if (flag33)
			{
				goto IL_180e;
			}
		}
		num = (nint)ItemIceCube.A_FreezeEnemy;
		Action action15 = OnIcecubeFreezeEnemy;
		Delegate obj35 = Delegate.Combine(ItemIceCube.A_FreezeEnemy, action15);
		if ((object)obj35 == null)
		{
			ItemIceCube.A_FreezeEnemy = null;
		}
		else
		{
			bool flag34 = (object)obj35.GetType() != typeof(Action);
			Delegate obj36 = null;
			if (!flag34)
			{
				obj36 = obj35;
			}
			bool flag35 = (object)obj36 == null;
			obj2 = action15;
			obj3 = 0;
			obj4 = obj35;
			nint num9 = (nint)typeof(Action);
			if (flag35)
			{
				goto IL_1b7f;
			}
			ItemIceCube.A_FreezeEnemy = (Action)obj36;
			bool flag36 = (object)obj35.GetType() != typeof(Action);
			Delegate obj37 = null;
			if (!flag36)
			{
				obj37 = obj35;
			}
			bool flag37 = (object)obj37 == null;
			obj2 = action15;
			obj3 = 0;
			obj4 = obj35;
			nint num10 = (nint)typeof(Action);
			if (flag37)
			{
				goto IL_1b8f;
			}
		}
		Action<PlayerXp, int> value12 = OnXpAdded;
		Delegate obj38 = Delegate.Remove(PlayerXp.A_XpAdded, value12);
		if ((object)obj38 == null)
		{
			PlayerXp.A_XpAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerXp, int> action16 = default(Action<PlayerXp, int>);
			bool flag38 = action16 == null;
			num = (nint)typeof(Action<PlayerXp, int>);
			obj2 = obj38;
			obj3 = 0;
			obj4 = null;
			if (flag38)
			{
				goto IL_18ce;
			}
			PlayerXp.A_XpAdded = action16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj39 = default(object);
			bool flag39 = obj39 == null;
			num = (nint)typeof(Action<PlayerXp, int>);
			obj2 = obj38;
			obj3 = 0;
			obj4 = null;
			if (flag39)
			{
				goto IL_18de;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> value13 = new Action<object, object, bool>(OnPlayerTakeDamage);
		Delegate obj40 = Delegate.Remove(PlayerHealth.A_TakeDamage, value13);
		if ((object)obj40 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action17 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag40 = action17 == null;
			num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj40;
			obj3 = 0;
			obj4 = null;
			if (flag40)
			{
				goto IL_1916;
			}
			PlayerHealth.A_TakeDamage = action17;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj41 = default(object);
			bool flag41 = obj41 == null;
			num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj40;
			obj3 = 0;
			obj4 = null;
			if (flag41)
			{
				goto IL_1926;
			}
		}
		Action<Enemy> value14 = OnEvade;
		Delegate obj42 = Delegate.Remove(PlayerHealth.A_Evaded, value14);
		if ((object)obj42 == null)
		{
			PlayerHealth.A_Evaded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action18 = default(Action<Enemy>);
			bool flag42 = action18 == null;
			num = (nint)typeof(Action<Enemy>);
			obj2 = obj42;
			obj3 = 0;
			obj4 = null;
			if (flag42)
			{
				goto IL_1936;
			}
			PlayerHealth.A_Evaded = action18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj43 = default(object);
			bool flag43 = obj43 == null;
			num = (nint)typeof(Action<Enemy>);
			obj2 = obj42;
			obj3 = 0;
			obj4 = null;
			if (flag43)
			{
				goto IL_1946;
			}
		}
		Action<int> value15 = OnLifestealHealing;
		Delegate obj44 = Delegate.Remove(PlayerHealth.A_LifestealHealing, value15);
		if ((object)obj44 == null)
		{
			PlayerHealth.A_LifestealHealing = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action19 = default(Action<int>);
			bool flag44 = action19 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj44;
			obj3 = 0;
			obj4 = null;
			if (flag44)
			{
				goto IL_1956;
			}
			PlayerHealth.A_LifestealHealing = action19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj45 = default(object);
			bool flag45 = obj45 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj44;
			obj3 = 0;
			obj4 = null;
			if (flag45)
			{
				goto IL_1966;
			}
		}
		num = (nint)PlayerHealth.A_Died;
		Action action20 = OnDead;
		Delegate obj46 = Delegate.Remove(PlayerHealth.A_Died, action20);
		if ((object)obj46 == null)
		{
			PlayerHealth.A_Died = null;
		}
		else
		{
			bool flag46 = (object)obj46.GetType() != typeof(Action);
			Delegate obj47 = null;
			if (!flag46)
			{
				obj47 = obj46;
			}
			bool flag47 = (object)obj47 == null;
			obj2 = action20;
			obj3 = 0;
			obj4 = obj46;
			nint num11 = (nint)typeof(Action);
			if (flag47)
			{
				goto IL_1b9f;
			}
			PlayerHealth.A_Died = (Action)obj47;
			bool flag48 = (object)obj46.GetType() != typeof(Action);
			Delegate obj48 = null;
			if (!flag48)
			{
				obj48 = obj46;
			}
			bool flag49 = (object)obj48 == null;
			obj2 = action20;
			obj3 = 0;
			obj4 = obj46;
			nint num12 = (nint)typeof(Action);
			if (flag49)
			{
				goto IL_1baf;
			}
		}
		Action<Pickup> value16 = OnPickup;
		Delegate obj49 = Delegate.Remove(Pickup.A_PickupTriggered, value16);
		if ((object)obj49 == null)
		{
			Pickup.A_PickupTriggered = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action21 = default(Action<Pickup>);
			bool flag50 = action21 == null;
			num = (nint)typeof(Action<Pickup>);
			obj2 = obj49;
			obj3 = 0;
			obj4 = null;
			if (flag50)
			{
				goto IL_19fe;
			}
			Pickup.A_PickupTriggered = action21;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj50 = default(object);
			bool flag51 = obj50 == null;
			num = (nint)typeof(Action<Pickup>);
			obj2 = obj49;
			obj3 = 0;
			obj4 = null;
			if (flag51)
			{
				goto IL_1a0e;
			}
		}
		num = (nint)InteractableMicrowave.A_Exploded;
		Action action22 = OnMicrowaveExploded;
		Delegate obj51 = Delegate.Remove(InteractableMicrowave.A_Exploded, action22);
		if ((object)obj51 == null)
		{
			InteractableMicrowave.A_Exploded = null;
		}
		else
		{
			bool flag52 = (object)obj51.GetType() != typeof(Action);
			Delegate obj52 = null;
			if (!flag52)
			{
				obj52 = obj51;
			}
			bool flag53 = (object)obj52 == null;
			obj2 = action22;
			obj3 = 0;
			obj4 = obj51;
			nint num13 = (nint)typeof(Action);
			if (flag53)
			{
				goto IL_1bbf;
			}
			InteractableMicrowave.A_Exploded = (Action)obj52;
			bool flag54 = (object)obj51.GetType() != typeof(Action);
			Delegate obj53 = null;
			if (!flag54)
			{
				obj53 = obj51;
			}
			bool flag55 = (object)obj53 == null;
			obj2 = action22;
			obj3 = 0;
			obj4 = obj51;
			nint num14 = (nint)typeof(Action);
			if (flag55)
			{
				goto IL_1bcf;
			}
		}
		Action<int> value17 = OnPunchedByKevin;
		Delegate obj54 = Delegate.Remove(ItemKevin.A_PunchedByKevin, value17);
		if ((object)obj54 == null)
		{
			ItemKevin.A_PunchedByKevin = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action23 = default(Action<int>);
		bool flag56 = action23 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj54;
		obj3 = 0;
		obj4 = null;
		if (flag56)
		{
			goto IL_1aff;
		}
		ItemKevin.A_PunchedByKevin = action23;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj55 = default(object);
		bool flag57 = obj55 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj54;
		obj3 = 0;
		obj4 = null;
		if (!flag57)
		{
			return;
		}
		goto IL_1b0f;
		IL_1b6f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b5f;
		IL_15e4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_15d4;
		IL_1b4f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b3f;
		IL_1644:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_160c;
		IL_17fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b6f;
		IL_1654:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1644;
		IL_156c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1534;
		IL_159c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_158c;
		IL_15d4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_159c;
		IL_15fc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_15e4;
		IL_158c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_157c;
		IL_160c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_15fc;
		IL_1b3f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1654;
		IL_147a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_146a;
		IL_1412:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1402;
		IL_1b1f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_147a;
		IL_146a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_145a;
		IL_1534:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1524;
		IL_13f7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_1524:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b2f;
		IL_1b2f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b1f;
		IL_1aff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1bcf;
		IL_144a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1412;
		IL_157c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_156c;
		IL_145a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_144a;
		IL_1a0e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_19fe;
		IL_1baf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b9f;
		IL_1bcf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1bbf;
		IL_1bbf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1a0e;
		IL_1402:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_13f7;
		IL_1956:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1946;
		IL_1b0f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1aff;
		IL_19fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1baf;
		IL_1b9f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1966;
		IL_1916:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_18de;
		IL_1966:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1956;
		IL_1946:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1936;
		IL_1936:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1926;
		IL_1b7f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_180e;
		IL_1926:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1916;
		IL_18de:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_18ce;
		IL_18ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b8f;
		IL_1b5f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b4f;
		IL_1b8f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_1b7f;
		IL_180e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_17fe;
	}

	private static void AddValue(EMyStat stat, int value)
	{
		//IL_0029: Expected F4, but got I4
		string statString = GetStatString(stat);
		MyStats.AddValue(statString, value);
		string statString2 = GetStatString(stat);
		RunStats.AddValue(statString2, value);
	}

	private static void AddValue(string statKey, int value)
	{
		//IL_0012: Expected F4, but got I4
		MyStats.AddValue(statKey, value);
		RunStats.AddValue(statKey, value);
	}

	private static void OnGoldChange(PlayerInventory inv, int amount)
	{
		if (amount <= 0)
		{
			int value = -amount;
			AddValue(EMyStat.goldSpent, value);
		}
		else
		{
			AddValue(EMyStat.goldEarned, amount);
		}
	}

	private static void OnSilverChange(int change)
	{
		if (change > 0)
		{
			AddValue(EMyStat.silverEarned, change);
		}
	}

	private unsafe static void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
		//IL_0561: Expected O, but got Ref
		AddValue(EMyStat.kills, 1);
		if (enemy.IsElite())
		{
			AddValue(EMyStat.eliteKills, 1);
		}
		if (enemy.IsBoss() && !enemy.IsStageBoss())
		{
			AddValue(EMyStat.minibossKills, 1);
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			CharacterData characterData = inventory.characterData;
			if (characterData.eCharacter == ECharacter.Calcium)
			{
				AddValue(EMyStat.minibossKillsCalcium, 1);
			}
		}
		if (enemy.IsStageBoss())
		{
			AddValue(EMyStat.bossKills, 1);
			if (MapController.isFinalBossStage)
			{
				AddValue(EMyStat.finalBossKills, 1);
			}
		}
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		if (StatTrackingUtility.skeletonEnemies.Contains(enemyData.enemyName))
		{
			AddValue(EMyStat.skeletonKills, 1);
		}
		EnemyData enemyData2 = enemy._003CenemyData_003Ek__BackingField;
		if (StatTrackingUtility.goblinEnemies.Contains(enemyData2.enemyName))
		{
			AddValue(EMyStat.goblinKills, 1);
		}
		string keyKillsEnemy = StatTrackingUtility.GetKeyKillsEnemy(enemy);
		AddValue(keyKillsEnemy, 1);
		if (deathSource != null && !string.IsNullOrEmpty(deathSource.damageSource))
		{
			if (!StatTrackingUtility.keysKillsSources.ContainsKey(deathSource.damageSource))
			{
				char c = deathSource.damageSource.get_Chars(0);
				char c2 = char.ToLower(c);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814478A0");
				string text = deathSource.damageSource.Substring(1);
				string text2 = default(string);
				string value = text2 + text + "Kills";
				((Dictionary<object, object>)(object)StatTrackingUtility.keysKillsSources).Add((object)deathSource.damageSource, (object)value);
			}
			string statKey = StatTrackingUtility.keysKillsSources.get_Item(deathSource.damageSource);
			AddValue(statKey, 1);
			EMyStat stat;
			if (deathSource.element == EElement.Lightning)
			{
				stat = EMyStat.lightningKills;
			}
			else
			{
				if (deathSource.element != EElement.Fire)
				{
					goto IL_07b0;
				}
				stat = EMyStat.fireKills;
			}
			AddValue(stat, 1);
			goto IL_07b0;
		}
		goto IL_05b9;
		IL_05b9:
		EnemyData enemyData3 = enemy._003CenemyData_003Ek__BackingField;
		if (StatTrackingUtility.wispEnemies.Contains(enemyData3.enemyName))
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			CharacterData characterData2 = inventory2.characterData;
			if (characterData2.eCharacter == ECharacter.Fox)
			{
				AddValue(EMyStat.foxWispsKills, 1);
			}
		}
		MyPlayer instance3 = MyPlayer.Instance;
		PlayerMovement playerMovement = instance3.playerMovement;
		if (0.1f > playerMovement.avgVelocity)
		{
			AddValue(EMyStat.standingStillKills, 1);
		}
		MyPlayer instance4 = MyPlayer.Instance;
		PlayerMovement playerMovement2 = instance4.playerMovement;
		if (playerMovement2._003CisTouchingTornado_003Ek__BackingField && deathSource.damageSource == tornadoDamageSource)
		{
			AddValue(EMyStat.killsInTornadoWithTornado, 1);
		}
		MyPlayer instance5 = MyPlayer.Instance;
		string keyKillsCharacter = StatTrackingUtility.GetKeyKillsCharacter(instance5.character);
		AddValue(keyKillsCharacter, 1);
		return;
		IL_07b0:
		if (deathSource.damageSource == PlayerHealth.thornsDamageSource)
		{
			EnemyData enemyData4 = enemy._003CenemyData_003Ek__BackingField;
			if (enemyData4.enemyName == EEnemy.CactusShooter)
			{
				AddValue(EMyStat.cactusKillsWithThorns, 1);
			}
		}
		MyPlayer instance6 = MyPlayer.Instance;
		PlayerInventory inventory3 = instance6.inventory;
		CharacterData characterData3 = inventory3.characterData;
		if (characterData3.eCharacter == ECharacter.Athena && deathSource.damageSource == ItemQuinsMask.damageSource)
		{
			AddValue(EMyStat.quinsMaskKillsAsAthena, 1);
		}
		MyPlayer instance7 = MyPlayer.Instance;
		PlayerInventory inventory4 = instance7.inventory;
		CharacterData characterData4 = inventory4.characterData;
		if (characterData4.eCharacter == ECharacter.Birdo && deathSource.damageSource == minesWeaponDamageSource)
		{
			AddValue(EMyStat.birdoFlyingMinesKills, 1);
			object obj = default(object);
			string statName = ((Enum)(&obj)).ToString();
			float stat2 = MyStats.GetStat(statName);
			float num = default(float);
			string text3 = num.ToString();
			string text4 = "Flying birdo mines kills: " + text3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
		goto IL_05b9;
	}

	private static void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
		if (dc.crit)
		{
			AddValue(EMyStat.crits, 1);
		}
	}

	private static void OnChestOpened()
	{
		AddValue(EMyStat.chestsOpened, 1);
	}

	private static void OnItemAdded(EItem eItem)
	{
		AddValue(EMyStat.itemsPickedUp, 1);
	}

	private static void OnXpAdded(PlayerXp playerXp, int amount)
	{
		AddValue(EMyStat.xpGained, amount);
	}

	private unsafe static void OnAchievementUnlocked(MyAchievement ach)
	{
		//IL_00c3: Expected O, but got Ref
		//IL_011a: Expected F4, but got I4
		//IL_0145: Expected I, but got O
		//IL_014d: Expected I, but got O
		//IL_015d: Expected O, but got I
		//IL_0199: Expected O, but got I
		//IL_01ea: Expected O, but got Ref
		//IL_0205: Expected F4, but got I4
		List<object> achievements = (List<object>)(object)RunStats.achievements;
		int version = achievements._version + 1;
		achievements._version = version;
		object[] items = achievements._items;
		if (achievements._size >= items.Length)
		{
			achievements.AddWithResize((object)ach);
		}
		else
		{
			int size = achievements._size + 1;
			achievements._size = size;
			int num = default(int);
			items[num] = ach;
		}
		IntPtr intPtr = default(IntPtr);
		string statName = ((Enum)(&intPtr)).ToString();
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		HashSet<string> achievements2 = progression.achievements;
		MyStats.SetValueForce(statName, achievements2._count);
		if ((object)ach == null)
		{
			return;
		}
		nint num2 = (nint)typeof(ChallengeData);
		nint num3 = (nint)ach;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rdx_v7 (Il2CppClass<ChallengeData>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rdx_v7 (Il2CppClass<ChallengeData>)+130]");
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v23+FFFFFFF8+v385 @ rax_v22*8]");
			if (0 == (nint)typeof(ChallengeData))
			{
				MyAchievements.GetAchievementTypeProgress(EAchievementType.Challenges, out var completed, out var _, out var _);
				string statName2 = ((Enum)(&intPtr)).ToString();
				MyStats.SetValueForce(statName2, completed);
			}
		}
	}

	private unsafe static void OnUnlockPurchased(UnlockableBase unlock)
	{
		//IL_005d: Expected O, but got Ref
		//IL_0053: Expected F4, but got I4
		object obj = default(object);
		string statName = ((Enum)(&obj)).ToString();
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		HashSet<string> purchases = progression.purchases;
		MyStats.SetValueForce(statName, purchases._count);
	}

	private static void OnProjectileSpawned(ProjectileBase projectileBase)
	{
		AddValue(EMyStat.projectilesFired, 1);
	}

	private static void OnInteracted(BaseInteractable interactable, bool success)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_0207: Expected I, but got O
		//IL_020f: Expected I, but got O
		//IL_021f: Expected O, but got I
		//IL_0168: Expected O, but got I4
		//IL_0124: Expected O, but got I
		//IL_015a: Expected O, but got I4
		if ((object)interactable == null)
		{
			return;
		}
		nint num = (nint)typeof(InteractablePot);
		nint num2 = (nint)interactable;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Interactables.InteractablePot>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v2 (Il2CppClass<BaseInteractable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Interactables.InteractablePot>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v2 (Il2CppClass<BaseInteractable>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v23+FFFFFFF8+v46 @ rax_v3*8]");
			if (0 == (nint)typeof(InteractablePot))
			{
				obj3 = 1;
				goto IL_01be;
			}
		}
		obj3 = 0;
		goto IL_01be;
		IL_024b:
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
		if (flag3)
		{
			AddValue(EMyStat.shrineSucc, 1);
		}
		return;
		IL_01be:
		bool flag4 = obj3 == null;
		BaseInteractable baseInteractable2 = null;
		if (!flag4)
		{
			baseInteractable2 = interactable;
		}
		bool flag5 = (object)baseInteractable2 == null;
		bool flag6 = false;
		if (!flag5)
		{
			flag6 = success;
		}
		if (flag6)
		{
			AddValue(EMyStat.potsBroken, 1);
			Action a_PotBroken = A_PotBroken;
			if (A_PotBroken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v202.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		nint num4 = (nint)typeof(InteractableShrineMagnet);
		nint num5 = (nint)interactable;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v6 (Il2CppClass<InteractableShrineMagnet>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ r8_v4 (Il2CppClass<BaseInteractable>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v6 (Il2CppClass<InteractableShrineMagnet>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ r8_v4 (Il2CppClass<BaseInteractable>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v13+FFFFFFF8+v228 @ rax_v6*8]");
			if (0 == (nint)typeof(InteractableShrineMagnet))
			{
				obj4 = 1;
				goto IL_024b;
			}
		}
		obj4 = 0;
		goto IL_024b;
	}

	private static void OnShrineCharged(bool notInterrupted)
	{
		AddValue(EMyStat.shrineCharge, 1);
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData.eMap == EMap.Desert && MapEventsDesert.isActiveStorm)
		{
			float num = MapEventsDesert.currentStormStartedAtTime + 2f;
			if (!(MyTime.stageTimer < num))
			{
				AddValue(EMyStat.shrineChargeSandstorm, 1);
			}
		}
	}

	private static void OnChallengeShrineCompleted()
	{
		AddValue(EMyStat.shrineChallenge, 1);
	}

	private static void OnChestBought()
	{
		AddValue(EMyStat.chestsBought, 1);
	}

	private static void OnShadyGuyUsed(InteractableShadyGuy shadyGuy)
	{
		//IL_003a: Expected O, but got I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		bool flag = shadyGuy.rarity == EItemRarity.Common;
		if (!flag)
		{
			object obj = shadyGuy.rarity - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						AddValue(EMyStat.shadyGuysGold, 1);
					}
				}
				else
				{
					AddValue(EMyStat.shadyGuysPink, 1);
				}
			}
			else
			{
				AddValue(EMyStat.shadyGuysBlue, 1);
			}
		}
		else
		{
			AddValue(EMyStat.shadyGuysBlack, 1);
		}
	}

	private static void OnPlayerTakeDamage(PlayerHealth ph, DamageContainer dc, bool brokeShield)
	{
		if (dc.damageBlockedByArmor > 0)
		{
			AddValue(EMyStat.damageReductionArmor, dc.damageBlockedByArmor);
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.character == ECharacter.SirOofie && dc.damageBlockedByArmor > 0)
		{
			AddValue(EMyStat.damageReductionArmorAsKnight, dc.damageBlockedByArmor);
		}
	}

	private static void OnEvade(Enemy attacker)
	{
		AddValue(EMyStat.evades, 1);
	}

	private static void OnLifestealHealing(int amount)
	{
		AddValue(EMyStat.lifestealHealing, amount);
	}

	private static void OnDead()
	{
		AddValue(EMyStat.runs, 1);
	}

	private static void OnIcecubeFreezeEnemy()
	{
		AddValue(EMyStat.icecubeFreezes, 1);
	}

	private static void OnPickup(Pickup pickup)
	{
		if (!nonPowerupPickups.Contains(pickup.ePickup))
		{
			AddValue(EMyStat.powerupsUsed, 1);
		}
	}

	private static void OnMicrowaveExploded()
	{
		AddValue(EMyStat.microwavesExploded, 1);
	}

	private static void OnPunchedByKevin(int times)
	{
		AddValue(EMyStat.kevinPunches, times);
	}

	public unsafe static string GetStatString(EMyStat stat)
	{
		//IL_003a: Expected O, but got Ref
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)statStrings).TryGetValue((System.Int32Enum)stat, out object value);
		string result = (string)value;
		if (!flag)
		{
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			if (statStrings == null)
			{
				return (string)(object)new NullReferenceException();
			}
			((Dictionary<System.Int32Enum, object>)(object)statStrings).Add((System.Int32Enum)stat, (object)text);
			result = text;
		}
		return result;
	}

	public unsafe static string GetCharacterRunsString(ECharacter character)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "runsAs" + text;
	}

	unsafe static TrackStats()
	{
		//IL_008d: Expected O, but got Ref
		//IL_00a3: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		minesWeaponDamageSource = text;
		object obj2 = default(object);
		string text2 = ((Enum)(&obj2)).ToString();
		tornadoDamageSource = text2;
		HashSet<EPickup> hashSet = (HashSet<EPickup>)(object)new HashSet<System.Int32Enum>();
		bool flag = hashSet.Add(EPickup.Gold);
		bool flag2 = hashSet.Add(EPickup.Silver);
		bool flag3 = hashSet.Add(EPickup.Xp);
		nonPowerupPickups = hashSet;
		Dictionary<EMyStat, string> dictionary = new Dictionary<EMyStat, string>();
		statStrings = dictionary;
	}
}
