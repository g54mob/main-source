using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups;

public class PlayerHealth
{
	public static int maxMaxHp = 50000;

	public int hp;

	public int maxHp;

	public float overheal;

	public float maxOverheal;

	public float shield;

	public float maxShield;

	public static Action<PlayerHealth, DamageContainer, bool> A_TakeDamage;

	public static Action<PlayerHealth, float, bool> A_Heal;

	public static Action<PlayerHealth> A_MaxValuesChanged;

	public static Action<PlayerHealth> A_OverhealUpdate;

	public static Action A_CooldownOver;

	public static Action A_Died;

	public static Action<Enemy> A_Evaded;

	public static Action<DamageContainer, bool> A_CheckStopDamage;

	private float baseHp;

	private float baseShield;

	private string lvlHpMovingStatName;

	private float minFallDamageSpeed;

	private float maxFallDamageSpeed;

	public float fallDamageTakenAtTime;

	public const string fallDamageSource = "fallDamage";

	private const string externalDamageSource = "Enemy";

	public static Action A_StoppedDamage;

	public static Action A_DamagePlayerCalled;

	public static HashSet<string> selfDamageSources;

	public static string thornsDamageSource;

	private float shieldRechargeAtTime;

	private float shieldRegenCooldownTime;

	public const float damageCooldownTime = 0.15f;

	public static Action<Enemy, int> A_LifestealProc;

	private int lifestealHeal;

	public static Action<int> A_LifestealHealing;

	private float leftOverHeal;

	public const string healthRegenDamageSource = "HealthRegen";

	private float nextCheckDeadTime;

	private float checkDeadInterval;

	private float overhealRemovalFractionPerSecond;

	private float shieldHealingPerTick;

	private float shieldHealingValue;

	private float healingValue;

	private float healingTime;

	private float healInterval;

	private float healPerInterval;

	private float healingPerMinute;

	private int maxIntervalsPerMinute;

	private float damageCooldown;

	public unsafe PlayerHealth(PlayerStatsNew playerStats)
	{
		//IL_079d: Expected I, but got O
		//IL_01cd: Expected I4, but got F8
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0244: Expected F4, but got I4
		//IL_02bd: Expected O, but got I4
		//IL_02cb: Expected I, but got O
		//IL_02d0: Expected I, but got O
		//IL_0319: Expected O, but got I4
		//IL_0327: Expected I, but got O
		//IL_032c: Expected I, but got O
		//IL_03c4: Expected O, but got I4
		//IL_03d2: Expected I, but got O
		//IL_03d7: Expected I, but got O
		//IL_0420: Expected O, but got I4
		//IL_042e: Expected I, but got O
		//IL_0433: Expected I, but got O
		//IL_04cb: Expected O, but got I4
		//IL_04d9: Expected I, but got O
		//IL_04de: Expected I, but got O
		//IL_0527: Expected O, but got I4
		//IL_0535: Expected I, but got O
		//IL_053a: Expected I, but got O
		//IL_05aa: Expected O, but got I4
		//IL_05b8: Expected I, but got O
		//IL_05bd: Expected I, but got O
		//IL_0606: Expected O, but got I4
		//IL_0614: Expected I, but got O
		//IL_0619: Expected I, but got O
		//IL_0689: Expected O, but got I4
		//IL_0697: Expected I, but got O
		//IL_069c: Expected I, but got O
		baseHp = 100f;
		baseShield = 25f;
		lvlHpMovingStatName = "LevelHp";
		minFallDamageSpeed = 30f;
		maxFallDamageSpeed = 140f;
		shieldRegenCooldownTime = 6f;
		checkDeadInterval = 1f;
		overhealRemovalFractionPerSecond = 0.03f;
		shieldHealingPerTick = 10f;
		healingPerMinute = 10f;
		float fixedDeltaTime = Time.fixedDeltaTime;
		float num = 1f / fixedDeltaTime;
		nint num2 = (nint)typeof(Math);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v5 (Il2CppClass<System.Math>)+E4]");
		double num3 = default(double);
		double num4 = default(double);
		double num5;
		if ((nint)0 >= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018042AE75h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v5 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 == 0)
			{
				bool flag = (object)(num3 & 1) == null;
				num4 = 0.5;
				num5 = num3;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [18262EC98h]\"");
					num4 = 0.5;
					num5 = num3;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm1\"");
				num5 = Math.Floor(num);
				num4 = 0.5;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [18262ED10h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018042AEADh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v5 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 == 0)
			{
				bool flag2 = (object)(num3 & 1) == null;
				num5 = num3;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [18262EC98h]\"");
					num5 = num3;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC90h]\"");
				num5 = Math.Ceiling(num);
			}
		}
		maxIntervalsPerMinute = (int)(num5 * 60.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		float stat = playerStats.GetStat(EStat.MaxHealth);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		int num6 = default(int);
		maxHp = num6;
		float stat2 = playerStats.GetStat(EStat.Shield);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		shield = 0f;
		hp = maxHp;
		maxShield = num6;
		float num7 = MyTime.time + shieldRegenCooldownTime;
		shieldRechargeAtTime = num7;
		float stat3 = playerStats.GetStat(EStat.HealthRegen);
		UpdateRegenValues(stat3);
		Action<EStat> action = OnStatUpdate;
		action._002Ector((object)this, (IntPtr)(nint)__ldftn(PlayerHealth.OnStatUpdate));
		Delegate obj = Delegate.Combine(PlayerStatsNew.A_StatUpdate, action);
		float num10;
		Delegate obj3;
		object obj2;
		nint num8;
		nint num9;
		if ((object)obj == null)
		{
			PlayerStatsNew.A_StatUpdate = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action2 = default(Action<EStat>);
			bool flag3 = action2 == null;
			obj2 = 0;
			num8 = (nint)typeof(Action<EStat>);
			num9 = unchecked((nint)null);
			num10 = stat3;
			obj3 = obj;
			if (flag3)
			{
				goto IL_07ef;
			}
			PlayerStatsNew.A_StatUpdate = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj4 = default(object);
			bool flag4 = obj4 == null;
			obj2 = 0;
			num8 = (nint)typeof(Action<EStat>);
			num9 = unchecked((nint)null);
			num10 = stat3;
			obj3 = obj;
			if (flag4)
			{
				goto IL_07fa;
			}
		}
		Action<float> b = OnPlayerLanded;
		Delegate obj5 = Delegate.Combine(PlayerMovement.A_Landed, b);
		if ((object)obj5 == null)
		{
			PlayerMovement.A_Landed = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action3 = default(Action<float>);
			bool flag5 = action3 == null;
			obj2 = 0;
			num8 = (nint)typeof(Action<float>);
			num9 = unchecked((nint)null);
			num10 = stat3;
			obj3 = obj5;
			if (flag5)
			{
				goto IL_080a;
			}
			PlayerMovement.A_Landed = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj6 = default(object);
			bool flag6 = obj6 == null;
			obj2 = 0;
			num8 = (nint)typeof(Action<float>);
			num9 = unchecked((nint)null);
			num10 = stat3;
			obj3 = obj5;
			if (flag6)
			{
				goto IL_081a;
			}
		}
		Action<Pickup> b2 = OnPickup;
		Delegate obj7 = Delegate.Combine(Pickup.A_PickupTriggered, b2);
		if ((object)obj7 == null)
		{
			Pickup.A_PickupTriggered = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action4 = default(Action<Pickup>);
			bool flag7 = action4 == null;
			obj2 = 0;
			num8 = (nint)typeof(Action<Pickup>);
			num9 = unchecked((nint)null);
			num10 = stat3;
			obj3 = obj7;
			if (flag7)
			{
				goto IL_082a;
			}
			Pickup.A_PickupTriggered = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj8 = default(object);
			bool flag8 = obj8 == null;
			obj2 = 0;
			num8 = (nint)typeof(Action<Pickup>);
			num9 = unchecked((nint)null);
			num10 = stat3;
			obj3 = obj7;
			if (flag8)
			{
				goto IL_083a;
			}
		}
		Action<Enemy, DamageContainer> b3 = OnEnemyDamaged;
		Delegate obj9 = Delegate.Combine(Enemy.A_Damage, b3);
		if ((object)obj9 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action5 = default(Action<Enemy, DamageContainer>);
			bool flag9 = action5 == null;
			obj2 = 0;
			num8 = (nint)typeof(Action<Enemy, DamageContainer>);
			num9 = unchecked((nint)null);
			num10 = stat3;
			obj3 = obj9;
			if (flag9)
			{
				goto IL_0872;
			}
			Enemy.A_Damage = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag10 = obj10 == null;
			obj2 = 0;
			num8 = (nint)typeof(Action<Enemy, DamageContainer>);
			num9 = unchecked((nint)null);
			num10 = stat3;
			obj3 = obj9;
			if (flag10)
			{
				goto IL_0882;
			}
		}
		Action<int> b4 = OnLevelUp;
		Delegate obj11 = Delegate.Combine(PlayerXp.A_LevelUp, b4);
		if ((object)obj11 == null)
		{
			PlayerXp.A_LevelUp = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action6 = default(Action<int>);
		bool flag11 = action6 == null;
		obj2 = 0;
		num8 = (nint)typeof(Action<int>);
		num9 = unchecked((nint)null);
		num10 = stat3;
		obj3 = obj11;
		if (!flag11)
		{
			PlayerXp.A_LevelUp = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj12 = default(object);
			bool flag12 = obj12 == null;
			num10 = (float)num4;
			stat3 = (float)num5;
			obj3 = (Delegate)(object)playerStats;
			if (!flag12)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			object obj13 = default(object);
			obj2 = obj13;
			IntPtr intPtr = default(IntPtr);
			num8 = intPtr;
			IntPtr intPtr2 = default(IntPtr);
			num9 = intPtr2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0882;
		IL_080a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07fa;
		IL_082a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_081a;
		IL_0882:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0872;
		IL_083a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_082a;
		IL_07ef:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_081a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_080a;
		IL_07fa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07ef;
		IL_0872:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_083a;
	}

	public void OnDestroy()
	{
		//IL_0475: Expected I, but got O
		//IL_0486: Expected O, but got I4
		//IL_048f: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_012e: Expected I, but got O
		//IL_013f: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_0186: Expected I, but got O
		//IL_0197: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_023e: Expected O, but got I4
		//IL_0247: Expected O, but got I4
		//IL_0285: Expected I, but got O
		//IL_0296: Expected O, but got I4
		//IL_029f: Expected O, but got I4
		//IL_0304: Expected I, but got O
		//IL_0315: Expected O, but got I4
		//IL_031e: Expected O, but got I4
		//IL_035c: Expected I, but got O
		//IL_036d: Expected O, but got I4
		//IL_0376: Expected O, but got I4
		//IL_03db: Expected I, but got O
		//IL_03ec: Expected O, but got I4
		//IL_03f5: Expected O, but got I4
		//IL_0433: Expected I, but got O
		//IL_0444: Expected O, but got I4
		//IL_044d: Expected O, but got I4
		Action<EStat> value = OnStatUpdate;
		Delegate obj = Delegate.Remove(PlayerStatsNew.A_StatUpdate, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatsNew.A_StatUpdate = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action = default(Action<EStat>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStat>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_058f;
			}
			PlayerStatsNew.A_StatUpdate = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EStat>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_04bc;
			}
		}
		Action<float> value2 = OnPlayerLanded;
		Delegate obj6 = Delegate.Remove(PlayerMovement.A_Landed, value2);
		if ((object)obj6 == null)
		{
			PlayerMovement.A_Landed = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action2 = default(Action<float>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_04c7;
			}
			PlayerMovement.A_Landed = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_04d7;
			}
		}
		Action<Pickup> value3 = OnPickup;
		Delegate obj8 = Delegate.Remove(Pickup.A_PickupTriggered, value3);
		if ((object)obj8 == null)
		{
			Pickup.A_PickupTriggered = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action3 = default(Action<Pickup>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<Pickup>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag4)
			{
				goto IL_04e7;
			}
			Pickup.A_PickupTriggered = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<Pickup>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag5)
			{
				goto IL_04f7;
			}
		}
		Action<Enemy, DamageContainer> value4 = OnEnemyDamaged;
		Delegate obj10 = Delegate.Remove(Enemy.A_Damage, value4);
		if ((object)obj10 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action4 = default(Action<Enemy, DamageContainer>);
			bool flag6 = action4 == null;
			num = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = 0;
			if (flag6)
			{
				goto IL_0537;
			}
			Enemy.A_Damage = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = 0;
			if (flag7)
			{
				goto IL_0547;
			}
		}
		Action<int> value5 = OnLevelUp;
		Delegate obj12 = Delegate.Remove(PlayerXp.A_LevelUp, value5);
		if ((object)obj12 == null)
		{
			PlayerXp.A_LevelUp = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action5 = default(Action<int>);
		bool flag8 = action5 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj12;
		obj3 = 0;
		obj4 = 0;
		if (flag8)
		{
			goto IL_057f;
		}
		PlayerXp.A_LevelUp = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj13 = default(object);
		bool flag9 = obj13 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj12;
		obj3 = 0;
		obj4 = 0;
		if (!flag9)
		{
			return;
		}
		goto IL_058f;
		IL_058f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_057f;
		IL_04e7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04d7;
		IL_04c7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04bc;
		IL_0547:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0537;
		IL_057f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0547;
		IL_0537:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04f7;
		IL_04bc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04f7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_04e7;
		IL_04d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04c7;
	}

	private void OnPickup(Pickup pickup)
	{
		if (pickup.ePickup == EPickup.Health)
		{
			float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			float amount = default(float);
			int num = Heal(amount, allowOverheal: false);
		}
	}

	private void OnStatUpdate(EStat stat)
	{
		//IL_0034: Expected O, but got I8
		if (!(GameManager.Instance != null))
		{
			return;
		}
		object obj = (long)stat & 0xFFFFFFFDL;
		if (obj != null)
		{
			switch (stat)
			{
			case EStat.HealthRegen:
				UpdateRegenValues();
				return;
			case EStat.Overheal:
				break;
			default:
				return;
			}
		}
		UpdateMaxValues();
	}

	private void OnLevelUp(int lvl)
	{
		//IL_004f: Expected F4, but got I4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.MaxHealth;
		statModifier.modification = lvl;
		inventory.statInventory.ChangeMovingStat(lvlHpMovingStatName, statModifier);
		UpdateMaxValues();
	}

	private void UpdateRegenValues(float forceValue = 0f)
	{
		//IL_0013: Invalid comparison between F4 and I4
		//IL_006f: Invalid comparison between F4 and I
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected F4, but got Unknown
		//IL_018b: Invalid comparison between F4 and I4
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0096: Expected F4, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018042A757h\"");
		bool flag = forceValue != 0f;
		float num = forceValue;
		if (!flag)
		{
			num = PlayerStats.GetStat(EStat.HealthRegen);
		}
		healingPerMinute = num;
		float num2 = num * 2.5f;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ECCC]");
		if (num3 < 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ECCC]");
			num2 = 0f;
		}
		float num4 = healingPerMinute;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num4 & 0;
		shieldHealingPerTick = num2;
		object obj2 = default(object);
		float num7 = default(float);
		if ((nint)obj <= maxIntervalsPerMinute)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm3\"");
			float num5 = 60f / (float)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			float num6 = num5 & 0;
			healInterval = num6;
			num7 = ((healingPerMinute < 0f) ? (-1f) : 1f);
		}
		float num8 = healingPerMinute;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj3 = num8 & 0;
		healingTime = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm3\"");
		object obj4 = obj3 / obj2;
		float num9 = (float)obj4 * num7;
		healPerInterval = num9;
	}

	private unsafe void OnPlayerLanded(float speed)
	{
		//IL_00b9: Expected I, but got O
		//IL_014c: Expected O, but got I
		//IL_018d: Invalid comparison between F4 and I4
		//IL_0081: Expected I, but got O
		//IL_0256: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		nint num2;
		if (instance.character != ECharacter.Calcium)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			if (instance2.character != ECharacter.TonyMcZoom)
			{
				MyPlayer instance3 = MyPlayer.Instance;
				if (!instance3.playerMovement.IsCrouching())
				{
					nint num = (nint)typeof(MyPlayer);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ rax_v42 (Il2CppClass<Assets.Scripts.Actors.Player.MyPlayer>)+B8]");
					num2 = 0;
					MyPlayer instance4 = MyPlayer.Instance;
					if (instance4.character == ECharacter.Spaceman)
					{
						return;
					}
					goto IL_00e6;
				}
			}
		}
		MyPlayer instance5 = MyPlayer.Instance;
		num2 = (nint)instance5.playerMovement;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v12 (Il2CppStaticFields<Assets.Scripts.Actors.Player.MyPlayer>)+DC]");
		if ((nint)0 != 0)
		{
			return;
		}
		goto IL_00e6;
		IL_00e6:
		float stat = PlayerStats.GetStat(EStat.JumpHeight);
		float num3 = stat + minFallDamageSpeed;
		float stat2 = PlayerStats.GetStat(EStat.JumpHeight);
		if (!(num3 > speed))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm8\"");
			object obj = 10 - num2;
			float stat3 = PlayerStats.GetStat(EStat.FallDamageReduction);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			float num4 = (float)obj - (float)num2;
			float num5 = (float)hp - num4;
			if (!(num5 > 1f))
			{
				num4 = (float)hp - 1f;
			}
			if (!(num4 < 1f))
			{
				object obj2 = default(object);
				bool ignoreShield = default(bool);
				string damageSource = default(string);
				DcFlags flags = default(DcFlags);
				EDamageEffect damageEffect = default(EDamageEffect);
				DamagePlayerExternal(num4, 0f, (Vector3)(&obj2), ignoreShield, damageSource, flags, damageEffect);
			}
			EffectManager.Instance.PlayerLandHard();
			fallDamageTakenAtTime = MyTime.time;
		}
	}

	private void UpdateMaxValues()
	{
		//IL_006b: Expected F4, but got I4
		//IL_01ce: Invalid comparison between F4 and I4
		//IL_016f: Expected F4, but got I4
		//IL_0111: Expected F4, but got I4
		bool flag = GameManager.Instance == null;
		if (!flag)
		{
			float stat = PlayerStats.GetStat(EStat.MaxHealth);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			maxHp = (flag ? 1 : 0);
			float stat2 = PlayerStats.GetStat(EStat.Shield);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			maxShield = (flag ? 1 : 0);
			if (maxHp > maxMaxHp)
			{
				maxHp = maxMaxHp;
			}
			if (maxShield > (float)maxMaxHp)
			{
				maxShield = maxMaxHp;
			}
			if (hp > maxHp)
			{
				hp = maxHp;
			}
			if (shield > maxShield)
			{
				shield = maxShield;
			}
			float amount = (float)maxHp - (float)maxHp;
			int num = Heal(amount);
			float stat3 = PlayerStats.GetStat(EStat.Overheal);
			float num2 = (float)maxHp * stat3;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			maxOverheal = num;
			Action<PlayerHealth> a_MaxValuesChanged = A_MaxValuesChanged;
			if (A_MaxValuesChanged != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v76 @ r9_v3 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.PlayerHealth>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public unsafe void DamagePlayer(Enemy enemy, Vector3 direction, DcFlags flags = DcFlags.None)
	{
		//IL_001b: Expected O, but got Ref
		if (CanTakeDamage())
		{
			object obj = default(object);
			DamageContainer playerDamage = DamageUtility.GetPlayerDamage(enemy, (Vector3)(&obj), flags);
			Damage(playerDamage, ignoreShield: false);
		}
	}

	public unsafe void DamagePlayerExternal(float damage, float knockback, Vector3 direction, bool ignoreShield = false, string damageSource = "Enemy", DcFlags flags = DcFlags.None, EDamageEffect damageEffect = EDamageEffect.None, Enemy enemy = null)
	{
		//IL_0060: Expected O, but got Ref
		if (!CanTakeDamage())
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (!inventory.statusEffects.HasStatusEffect(EStatusEffect.Invulnerability))
		{
			object obj = default(object);
			string damageSource2 = default(string);
			DcFlags flags2 = default(DcFlags);
			DamageContainer playerDamage = DamageUtility.GetPlayerDamage(damage, knockback, (Vector3)(&obj), null, damageSource2, flags2);
			Enemy enemy2 = default(Enemy);
			playerDamage.enemy = enemy2;
			playerDamage.damageEffect = EDamageEffect.None;
			string text = default(string);
			if (text == "Poison")
			{
				playerDamage.damageEffect = EDamageEffect.Poison;
			}
			IntPtr intPtr = default(IntPtr);
			Damage(playerDamage, (byte)(nint)intPtr != 0);
		}
	}

	private void Damage(DamageContainer dc, bool ignoreShield)
	{
		//IL_00c1: Invalid comparison between I4 and F4
		//IL_00e3: Invalid comparison between F4 and I4
		//IL_015b: Invalid comparison between F4 and I4
		//IL_043d: Invalid comparison between F4 and I4
		//IL_055f: Expected O, but got I4
		//IL_0191: Invalid comparison between I4 and F4
		//IL_01fd: Invalid comparison between F4 and I4
		//IL_01de: Expected F4, but got I4
		//IL_0127: Invalid comparison between F4 and I4
		//IL_041e: Expected F4, but got I4
		//IL_0427: Expected O, but got I4
		//IL_042f: Expected F4, but got I4
		//IL_021d: Expected F4, but got I4
		//IL_0276: Expected O, but got I4
		//IL_030d: Expected O, but got I4
		Action a_DamagePlayerCalled = A_DamagePlayerCalled;
		if (A_DamagePlayerCalled != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (hp > 0 && !(damageCooldown > 0.1f))
		{
			MyPlayer instance = MyPlayer.Instance;
			bool flag = default(bool);
			if (!instance.isTeleporting && !CheckStopDamage(dc, flag))
			{
				Retaliate(dc);
				if (!(0f < dc.damage))
				{
					return;
				}
				int num2 = default(int);
				float num3;
				object obj;
				if (shield > 0f && !flag)
				{
					float num = shield - dc.damage;
					if (!(num < 0f))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
						shield = num2;
						obj = 1;
						num3 = num2;
						goto IL_04a1;
					}
				}
				num3 = overheal;
				float num4 = dc.damage;
				if (overheal > 0f)
				{
					float num5 = overheal - dc.damage;
					if (!(0f > num5))
					{
						if (num5 > maxOverheal)
						{
							num5 = maxOverheal;
						}
					}
					else
					{
						num5 = 0f;
					}
					overheal = num5;
					num4 -= num3;
					num3 = num5;
				}
				if (num4 > 0f)
				{
					num3 = (float)hp - num4;
					if (num3 < 0f)
					{
						num3 = 0f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					hp = num2;
				}
				bool flag2 = hp > 0;
				obj = 0;
				if (flag2)
				{
					goto IL_031d;
				}
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory = instance2.inventory;
				ItemInventory itemInventory = inventory.itemInventory;
				bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)itemInventory.items).ContainsKey((System.Int32Enum)25);
				bool flag4 = !flag3;
				obj = 0;
				if (!flag4)
				{
					MyPlayer instance3 = MyPlayer.Instance;
					PlayerInventory inventory2 = instance3.inventory;
					StatModifier[] modifiers = new StatModifier[0];
					float expirationTime = default(float);
					StatusEffect statusEffect = new StatusEffect(EStatusEffect.TimeFreeze, expirationTime, modifiers);
					expirationTime = ItemZaWarudo.freezeTime + MyTime.time;
					num4 = ItemZaWarudo.freezeTime;
					inventory2.statusEffects.AddNewEffect(statusEffect, ItemZaWarudo.freezeTime);
					MyPlayer instance4 = MyPlayer.Instance;
					PlayerInventory inventory3 = instance4.inventory;
					inventory3.itemInventory.RemoveItem(EItem.ZaWarudo);
					hp = maxHp;
					obj = 0;
				}
				goto IL_04a1;
			}
		}
		Action a_StoppedDamage = A_StoppedDamage;
		if (A_StoppedDamage != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v200.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		return;
		IL_031d:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317273C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (dc.damageSource == "Enemy")
		{
			float stat = PlayerStats.GetStat(EStat.DamageCooldownMultiplier);
			float num3 = stat * 0.15f;
			damageCooldown = num3;
		}
		if (!((HashSet<object>)(object)selfDamageSources).Contains((object)dc.damageSource))
		{
			float num3 = MyTime.time + shieldRegenCooldownTime;
			shieldRechargeAtTime = num3;
		}
		Action<PlayerHealth, DamageContainer, bool> a_TakeDamage = A_TakeDamage;
		if (A_TakeDamage != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v231 @ r10_v2 (System.Action`3<Assets.Scripts.Inventory__Items__Pickups.PlayerHealth, Assets.Scripts.Actors.DamageContainer, System.Boolean>)+18] (should have been resolved before IL gen)");
		}
		return;
		IL_04a1:
		if (hp <= 0)
		{
			PlayerDied();
		}
		goto IL_031d;
	}

	private void CheckDamageCooldown(DamageContainer dc)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317273C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (dc.damageSource == "Enemy")
		{
			float stat = PlayerStats.GetStat(EStat.DamageCooldownMultiplier);
			float num = stat * 0.15f;
			damageCooldown = num;
		}
	}

	private void CheckShieldRecharge(DamageContainer dc)
	{
		if (!((HashSet<object>)(object)selfDamageSources).Contains((object)dc.damageSource))
		{
			float num = MyTime.time + shieldRegenCooldownTime;
			shieldRechargeAtTime = num;
		}
	}

	public void KillPlayer()
	{
		if (hp > 0)
		{
			hp = 0;
			PlayerDied();
		}
	}

	public unsafe bool CheckStopDamage(DamageContainer dc, bool ignoreShield)
	{
		//IL_0389: Expected I4, but got O
		//IL_0018: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_03b9: Expected O, but got I4
		//IL_03d3: Expected O, but got I4
		//IL_0506: Invalid comparison between I4 and F4
		//IL_0164: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		//IL_047f: Expected O, but got Ref
		//IL_0492: Expected O, but got I4
		//IL_04ac: Expected O, but got I4
		//IL_041b: Expected O, but got Ref
		//IL_01de: Invalid comparison between F4 and I4
		//IL_0205: Invalid comparison between F4 and I
		//IL_022c: Expected F4, but got I
		if (dc != null)
		{
			object obj = dc.flags & DcFlags.BypassAegis;
			bool flag = obj == null;
			object obj2 = !flag;
			if (obj2 != null)
			{
				goto IL_03a6;
			}
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				AuraAttacks playerConstantAttacks = instance.playerConstantAttacks;
				if ((object)instance.playerConstantAttacks != null)
				{
					if (!(playerConstantAttacks.aegisAttack != null))
					{
						goto IL_03a6;
					}
					MyPlayer instance2 = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						AuraAttacks playerConstantAttacks2 = instance2.playerConstantAttacks;
						if ((object)instance2.playerConstantAttacks != null)
						{
							AegisAttack aegisAttack = playerConstantAttacks2.aegisAttack;
							if ((object)playerConstantAttacks2.aegisAttack != null)
							{
								if (aegisAttack.isActive)
								{
									object obj3 = dc.flags & DcFlags.BossDamage;
									bool flag2 = obj3 == null;
									object obj4 = !flag2;
									object obj5 = default(object);
									if (obj4 == null)
									{
										UseAegis(dc, (Color)(&obj5));
										MyPlayer instance3 = MyPlayer.Instance;
										if ((object)MyPlayer.Instance == null)
										{
											goto IL_037b;
										}
										if (instance3.character == ECharacter.Athena)
										{
											goto IL_02a9;
										}
										float num = (dc.damage *= 0.05f);
										if (num > 0f)
										{
											float num2 = num;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC7C]");
											if (num2 < 0f)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC7C]");
												num = 0f;
											}
											dc.damage = num;
										}
										dc.knockback = 0f;
									}
									else
									{
										UseAegis(dc, (Color)(&obj5), "Weak Block");
										object obj6 = dc.flags & DcFlags.FinalBossDamage;
										bool flag3 = obj6 == null;
										object obj7 = !flag3;
										float num = ((obj7 != null) ? (dc.damage * 0.75f) : (dc.damage * 0.33f));
										dc.damage = num;
									}
								}
								goto IL_03a6;
							}
						}
					}
				}
			}
		}
		goto IL_037b;
		IL_03a6:
		object obj8 = dc.flags & DcFlags.BypassEvade;
		bool flag4 = obj8 == null;
		object obj9 = !flag4;
		if (obj9 == null && DamageUtility.CheckEvade(dc.enemy))
		{
			Evade(dc);
			goto IL_02a9;
		}
		MyPlayer instance4 = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance4.inventory;
			if (instance4.inventory != null && inventory.statusEffects != null)
			{
				if (!inventory.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze))
				{
					Action<DamageContainer, bool> a_CheckStopDamage = A_CheckStopDamage;
					if (A_CheckStopDamage != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v435 @ r10_v2 (System.Action`2<Assets.Scripts.Actors.DamageContainer, System.Boolean>)+18] (should have been resolved before IL gen)");
					}
					if (0f < dc.damage)
					{
						return false;
					}
				}
				goto IL_02a9;
			}
		}
		goto IL_037b;
		IL_037b:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_02a9:
		return true;
	}

	private unsafe void UseAegis(DamageContainer dc, Color color, string text = "Block")
	{
		//IL_0044: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		//IL_00dc: Expected O, but got Ref
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		float num = default(float);
		int textSize = default(int);
		EffectManager.Instance.PopupText(text, (Color)(&obj), (Vector3)(&num), textSize);
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position2 = transform2.position;
		if (dc.enemy != null)
		{
			Vector3 feetPosition = dc.enemy.GetFeetPosition();
		}
		MyPlayer instance = MyPlayer.Instance;
		AuraAttacks playerConstantAttacks = instance.playerConstantAttacks;
		playerConstantAttacks.aegisAttack.UseShield((Vector3)(&num));
		ControllerShaker.Shake(0, 0.3f, 0.1f);
		MyStats.AddValue(EMyStat.aegisBlocks, 1f);
	}

	public bool WillDamageKill(DamageContainer dc, bool ignoreShield)
	{
		//IL_00a3: Expected I4, but got O
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0036: Invalid comparison between F4 and I4
		if (dc != null)
		{
			if (!ignoreShield && shield > 0f)
			{
				return false;
			}
			object obj = hp + overheal;
			object obj2 = obj - dc.damage;
			bool flag = 0 < (nint)obj2;
			return !flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool WillDamageKill(float damage, bool ignoreShield)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_005f: Invalid comparison between I4 and F4
		//IL_0019: Invalid comparison between F4 and I4
		if (!ignoreShield && shield > 0f)
		{
			return false;
		}
		object obj = hp + overheal;
		float num = (float)obj - damage;
		bool flag = 0f < num;
		return !flag;
	}

	private unsafe void Evade(DamageContainer dc)
	{
		//IL_00a3: Expected O, but got Ref
		//IL_00a3: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		ItemInventory itemInventory = inventory.itemInventory;
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)itemInventory.items).ContainsKey((System.Int32Enum)8);
		if (flag)
		{
		}
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		object obj2 = default(object);
		int textSize = default(int);
		EffectManager.Instance.PopupText("EVADE", (Color)(&obj), (Vector3)(&obj2), textSize);
		Retaliate(dc);
		MyPlayer instance2 = MyPlayer.Instance;
		instance2.playerSfxs.Evade(flag);
		Action<Enemy> a_Evaded = A_Evaded;
		if (A_Evaded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v103 @ r9_v3 (System.Action`1<Assets.Scripts.Actors.Enemies.Enemy>)+18] (should have been resolved before IL gen)");
		}
	}

	public unsafe void Retaliate(DamageContainer dc)
	{
		//IL_008e: Expected F4, but got O
		//IL_00e8: Expected O, but got Ref
		//IL_00e8: Expected O, but got Ref
		if (dc.enemy != null)
		{
			float stat = PlayerStats.GetStat(EStat.Thorns);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
			if ((nint)dc.enemy > 0)
			{
				Vector3 vector = default(Vector3);
				Enemy enemy = default(Enemy);
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(null, (float)dc.enemy, 1f, thornsDamageSource, vector, enemy);
				dc.enemy.DamageFromPlayerOther(damageContainer);
				Vector3 centerPosition = dc.enemy.GetCenterPosition();
				object obj = default(object);
				object obj2 = default(object);
				bool useSfx = default(bool);
				EffectManager.Instance.EnemyHitEffect((Vector3)(&obj), (Vector3)(&obj2), hitEnemy: true, (string)vector, (GameObject)(object)enemy, useSfx);
			}
		}
	}

	private float GetDamageCooldown()
	{
		float stat = PlayerStats.GetStat(EStat.DamageCooldownMultiplier);
		return stat * 0.15f;
	}

	private void OnEnemyDamaged(Enemy enemy, DamageContainer dc)
	{
		//IL_0114: Invalid comparison between I4 and F4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected I4, but got Unknown
		if ((hp >= maxHp && !(maxOverheal > overheal)) || dc.damageEffect == EDamageEffect.Bloodmark)
		{
			return;
		}
		float stat = PlayerStats.GetStat(EStat.Lifesteal);
		if (0f < stat)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
			double num = Math.Floor(0.0);
			double num2 = MyRandom.random.NextDouble();
			double num3 = num + 1.0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
			if ((nint)MyRandom.random <= 0)
			{
				num3 = num;
			}
			int num4 = (int)(lifestealHeal + num3);
			lifestealHeal = num4;
			Action<Enemy, int> a_LifestealProc = A_LifestealProc;
			if (A_LifestealProc != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v217 @ r10_v3 (System.Action`2<Assets.Scripts.Actors.Enemies.Enemy, System.Int32>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void TryLifestealHit(Enemy enemy, DamageContainer dc)
	{
		//IL_00ae: Invalid comparison between I4 and F4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected I4, but got Unknown
		float stat = PlayerStats.GetStat(EStat.Lifesteal);
		if (0f < stat)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
			double num = Math.Floor(0.0);
			double num2 = MyRandom.random.NextDouble();
			double num3 = num + 1.0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
			if ((nint)MyRandom.random <= 0)
			{
				num3 = num;
			}
			int num4 = (int)(lifestealHeal + num3);
			lifestealHeal = num4;
			Action<Enemy, int> a_LifestealProc = A_LifestealProc;
			if (A_LifestealProc != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v66 @ r10_v2 (System.Action`2<Assets.Scripts.Actors.Enemies.Enemy, System.Int32>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void ApplyLifesteal()
	{
		//IL_002a: Expected F4, but got I4
		int num = Heal(lifestealHeal);
		lifestealHeal = 0;
		if (num > 0)
		{
			Action<int> a_LifestealHealing = A_LifestealHealing;
			if (A_LifestealHealing != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ r9_v3 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public int Heal(float amount, bool allowOverheal = true)
	{
		//IL_033c: Expected I4, but got O
		//IL_028f: Invalid comparison between I4 and F8
		//IL_02c0: Invalid comparison between I4 and F8
		//IL_030d: Expected F8, but got I4
		//IL_02de: Invalid comparison between F8 and I4
		//IL_01b4: Invalid comparison between I4 and F8
		//IL_0215: Expected F8, but got I4
		//IL_021e: Expected F8, but got I4
		//IL_02ff: Expected F8, but got I4
		//IL_0323: Expected O, but got I4
		//IL_022b: Expected F8, but got I4
		//IL_0234: Expected O, but got I4
		MyPlayer instance = MyPlayer.Instance;
		int result;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null && inventory.statusEffects != null)
			{
				if (inventory.statusEffects.HasStatusEffect(EStatusEffect.Bleed))
				{
					goto IL_0328;
				}
				float stat = PlayerStats.GetStat(EStat.HealingMultiplier);
				float num2 = default(float);
				float num = stat * num2;
				float num3 = num + leftOverHeal;
				leftOverHeal = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
				double num4 = Math.Floor(0.0);
				float num5 = num3 - (float)num4;
				float num6 = num5 + leftOverHeal;
				leftOverHeal = num6;
				if (allowOverheal && hp >= maxHp && maxOverheal > overheal)
				{
					double num7 = (double)maxOverheal - (double)overheal;
					if (num7 > num4)
					{
						num7 = num4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331010");
					int num8 = default(int);
					if (num8 <= 0)
					{
						goto IL_0328;
					}
					double num9 = num4 + (double)overheal;
					if (!(0.0 > num9))
					{
						bool flag = !(num9 > (double)maxOverheal);
						double num10 = maxOverheal;
						if (!flag)
						{
							num10 = maxOverheal;
							num9 = maxOverheal;
						}
					}
					else
					{
						double num10 = 0.0;
						num9 = 0.0;
					}
					overheal = (float)num9;
					Action<PlayerHealth, float, bool> a_Heal = A_Heal;
					bool flag2 = A_Heal == null;
					result = num8;
					if (flag2)
					{
						goto IL_037f;
					}
					double num11 = num8;
					object obj = 0;
					result = num8;
				}
				else
				{
					if (hp >= maxHp || hp <= 0 || !(0.0 < num4))
					{
						goto IL_0328;
					}
					double num10 = (double)hp + num4;
					if (!(0.0 > num10))
					{
						if (num10 > (double)maxHp)
						{
							num10 = maxHp;
						}
					}
					else
					{
						num10 = 0.0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
					hp = (allowOverheal ? 1 : 0);
					result = (allowOverheal ? 1 : 0) - hp;
					Action<PlayerHealth, float, bool> a_Heal = A_Heal;
					if (A_Heal == null)
					{
						goto IL_037f;
					}
					double num11 = num4;
					object obj = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v503 @ r8_v2 (System.Action`3<Assets.Scripts.Inventory__Items__Pickups.PlayerHealth, System.Single, System.Boolean>)+18] (should have been resolved before IL gen)");
				goto IL_037f;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_037f:
		return result;
		IL_0328:
		return 0;
	}

	public unsafe void Tick()
	{
		//IL_0455: Invalid comparison between F4 and I4
		//IL_04d6: Expected F4, but got I4
		//IL_04e7: Expected F4, but got I4
		//IL_0491: Invalid comparison between I4 and F4
		//IL_05ee: Invalid comparison between F4 and I4
		//IL_0058: Expected O, but got I
		//IL_0341: Invalid comparison between I4 and F4
		//IL_0125: Invalid comparison between I4 and F4
		//IL_0398: Expected F4, but got I4
		//IL_028a: Invalid comparison between I4 and F4
		//IL_02e1: Expected F4, but got I4
		//IL_0675: Expected I, but got O
		//IL_019f: Invalid comparison between F4 and I4
		//IL_05be: Expected O, but got I4
		//IL_05be: Expected O, but got Ref
		//IL_05c7: Expected F4, but got I4
		if (damageCooldown > 0f && !(0f < (damageCooldown -= MyTime.fixedDeltaTime)))
		{
			Action a_CooldownOver = A_CooldownOver;
			if (A_CooldownOver != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v65.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		float num = lifestealHeal;
		int num2 = Heal(lifestealHeal);
		lifestealHeal = 0;
		bool flag = num2 <= 0;
		Action<int> action = null;
		bool flag2 = true;
		PlayerHealth playerHealth = this;
		if (!flag)
		{
			action = A_LifestealHealing;
			bool flag3 = A_LifestealHealing == null;
			flag2 = true;
			playerHealth = this;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r9_v2 (System.Action`1<System.Int32>)+28]");
				flag2 = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r9_v2 (System.Action`1<System.Int32>)+40]");
				playerHealth = (PlayerHealth)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ r9_v2 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
			}
		}
		float num3 = (healingTime += MyTime.fixedDeltaTime);
		if (!(num3 < healInterval))
		{
			float num4 = num3 - healInterval;
			healingTime = num4;
			double num5 = (double)healPerInterval + (double)healingValue;
			healingValue = (float)num5;
			if (num5 < 1.0)
			{
				bool flag4 = -1.0 < num5;
				num = -1f;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331010");
					float num7 = default(float);
					float num6 = (float)hp + num7;
					num = healingValue - num7;
					healingValue = num;
					bool flag5 = 0f < num6;
					float num8 = num7;
					if (!flag5)
					{
						num8 = 1f - (float)hp;
					}
					nint num9 = (nint)typeof(Math);
					float num10 = 0f - num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v38 (Il2CppClass<System.Math>)+E4]");
					if ((nint)0 < (nint)0)
					{
						num10 = num8;
					}
					float num11 = (float)hp - num10;
					if (!(num11 < 1f) && num10 > 0f)
					{
						object obj = default(object);
						bool ignoreShield = default(bool);
						string damageSource = default(string);
						DcFlags flags = default(DcFlags);
						EDamageEffect damageEffect = default(EDamageEffect);
						DamagePlayerExternal(num10, 0f, (Vector3)(&obj), ignoreShield, damageSource, flags, damageEffect, (Enemy)1);
						float num12 = 0f;
						num = num10;
					}
				}
			}
			else
			{
				double num13 = Math.Floor(num5);
				float num12 = healingValue - (float)num13;
				healingValue = num12;
				int num14 = Heal((float)num13, allowOverheal: false);
				num = (float)num13;
			}
		}
		if (!(MyTime.time < shieldRechargeAtTime))
		{
			float num15 = maxShield;
			if (maxShield > shield)
			{
				float num16 = shieldHealingPerTick * MyTime.fixedDeltaTime;
				float num17 = num16 + shield;
				if (!(0f > num17))
				{
					num15 = maxShield;
					if (num17 > maxShield)
					{
						num17 = maxShield;
					}
				}
				else
				{
					num17 = 0f;
				}
				shield = num17;
				Action<PlayerHealth, float, bool> a_Heal = A_Heal;
				if (A_Heal != null)
				{
					float num12 = shieldHealingPerTick;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v469 @ r8_v8 (System.Action`3<Assets.Scripts.Inventory__Items__Pickups.PlayerHealth, System.Single, System.Boolean>)+18] (should have been resolved before IL gen)");
				}
			}
		}
		float num18 = overheal;
		if (overheal > 0f)
		{
			float num19 = maxOverheal * overhealRemovalFractionPerSecond;
			float num20 = num19 * MyTime.fixedDeltaTime;
			float num21 = overheal - num20;
			if (!(0f > num21))
			{
				num18 = maxOverheal;
				if (num21 > maxOverheal)
				{
					num21 = maxOverheal;
				}
			}
			else
			{
				num21 = 0f;
			}
			overheal = num21;
			Action<PlayerHealth> a_OverhealUpdate = A_OverhealUpdate;
			if (A_OverhealUpdate != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v573 @ r9_v6 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.PlayerHealth>)+18] (should have been resolved before IL gen)");
			}
		}
		if (nextCheckDeadTime > MyTime.time)
		{
			return;
		}
		float num22 = MyTime.time + checkDeadInterval;
		nextCheckDeadTime = num22;
		if (hp <= 0)
		{
			GameManager instance = GameManager.Instance;
			if (!instance._003CisGameOver_003Ek__BackingField)
			{
				PlayerDied();
			}
		}
	}

	private void CheckDead()
	{
		if (nextCheckDeadTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + checkDeadInterval;
		nextCheckDeadTime = num;
		if (hp <= 0)
		{
			GameManager instance = GameManager.Instance;
			if (!instance._003CisGameOver_003Ek__BackingField)
			{
				PlayerDied();
			}
		}
	}

	private void UpdateHealthRegen()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected F4, but got Unknown
		//IL_0093: Invalid comparison between F4 and I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		float num = healingPerMinute;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num & 0;
		object obj2 = default(object);
		float num4;
		if ((nint)obj <= maxIntervalsPerMinute)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm3\"");
			float num2 = 60f / (float)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			float num3 = num2 & 0;
			healInterval = num3;
			if (healingPerMinute < 0f)
			{
				num4 = -1f;
				goto IL_00a7;
			}
		}
		num4 = 1f;
		goto IL_00a7;
		IL_00a7:
		float num5 = healingPerMinute;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj3 = num5 & 0;
		healingTime = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm3\"");
		object obj4 = obj3 / obj2;
		float num6 = (float)obj4 * num4;
		healPerInterval = num6;
	}

	public void PlayerDied()
	{
		hp = 0;
		shield = 0f;
		overheal = 0f;
		Action a_Died = A_Died;
		if (A_Died != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v46.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public bool IsDead()
	{
		int num = hp ^ hp;
		int num2 = hp & num;
		bool flag = num2 < 0;
		bool flag2 = hp < 0;
		bool flag3 = hp == 0;
		bool flag4 = flag2 != flag;
		return flag4 | flag3;
	}

	public bool CanTakeDamage()
	{
		//IL_0056: Expected I4, but got O
		if (hp > 0 && !(damageCooldown > 0.1f))
		{
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				return !instance.isTeleporting;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public int GetCombinedHp()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		int result = default(int);
		return result;
	}

	public int GetCombinedMaxHp()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		int result = default(int);
		return result;
	}

	public float GetHpRatio()
	{
		return (float)hp / (float)maxHp;
	}

	public bool DamageCooldown()
	{
		//IL_002c: Invalid comparison between F4 and I4
		bool flag = damageCooldown < 0.1f;
		float num = damageCooldown - 0.1f;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public bool CanHeal()
	{
		if (hp >= maxHp)
		{
			return false;
		}
		int num = hp ^ hp;
		int num2 = hp & num;
		bool flag = num2 < 0;
		bool flag2 = hp < 0;
		bool flag3 = hp == 0;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		return flag5 & flag4;
	}

	public bool CanLifesteal()
	{
		//IL_0057: Invalid comparison between F4 and I4
		if (hp < maxHp)
		{
			return true;
		}
		bool flag = maxOverheal < overheal;
		float num = maxOverheal - overheal;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	static PlayerHealth()
	{
		HashSet<string> hashSet = (HashSet<string>)(object)new HashSet<object>();
		bool flag = hashSet.Add(ItemKevin.damageSource);
		bool flag2 = hashSet.Add("HealthRegen");
		selfDamageSources = hashSet;
		thornsDamageSource = "Thorns";
	}
}
