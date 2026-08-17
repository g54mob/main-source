using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityFlex : PassiveAbility
{
	public static Action<bool> A_FlexReady;

	private static float cooldown = 12f;

	private static float minCooldown = 4f;

	private static float maxCooldown = 12f;

	private float cooldownReductionPerLevel = 0.2f;

	private float radius = 10f;

	private static float flexReadyAtTime;

	public float damagePerFlex = 0.025f;

	private int stacks;

	private bool canFlex;

	private DamageContainer reuseDc;

	private string damageSource;

	public override void Init()
	{
		//IL_01aa: Expected I, but got O
		//IL_01bb: Expected O, but got I4
		//IL_01c4: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0164: Expected I, but got O
		//IL_0175: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		Action<DamageContainer, bool> b = OnCheckStopDamage;
		Delegate obj = Delegate.Combine(PlayerHealth.A_CheckStopDamage, b);
		nint num;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_CheckStopDamage = (Action<DamageContainer, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<DamageContainer, bool> action = default(Action<DamageContainer, bool>);
			Delegate obj2;
			object obj3;
			object obj4;
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0211;
			}
			PlayerHealth.A_CheckStopDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01ce;
			}
		}
		Action<int> b2 = OnLevelup;
		Delegate obj6 = Delegate.Combine(PlayerXp.A_LevelUp, b2);
		if ((object)obj6 == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			Delegate obj2 = obj6;
			object obj3 = 0;
			object obj4 = 0;
			if (flag2)
			{
				goto IL_0201;
			}
			PlayerXp.A_LevelUp = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0211;
			}
		}
		cooldown = maxCooldown;
		stacks = 0;
		float num3 = MyTime.time + 4f;
		flexReadyAtTime = num3;
		return;
		IL_01ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0211:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0201;
		IL_0201:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01ce;
	}

	public override void Cleanup()
	{
		//IL_01b9: Expected I, but got O
		//IL_01ca: Expected O, but got I4
		//IL_01d3: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0164: Expected I, but got O
		//IL_0175: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		Action<DamageContainer, bool> value = OnCheckStopDamage;
		Delegate obj = Delegate.Remove(PlayerHealth.A_CheckStopDamage, value);
		nint num;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_CheckStopDamage = (Action<DamageContainer, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<DamageContainer, bool> action = default(Action<DamageContainer, bool>);
			Delegate obj2;
			object obj3;
			object obj4;
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0220;
			}
			PlayerHealth.A_CheckStopDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01dd;
			}
		}
		Action<int> value2 = OnLevelup;
		Delegate obj6 = Delegate.Remove(PlayerXp.A_LevelUp, value2);
		if ((object)obj6 == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			Delegate obj2 = obj6;
			object obj3 = 0;
			object obj4 = 0;
			if (flag2)
			{
				goto IL_0210;
			}
			PlayerXp.A_LevelUp = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0220;
			}
		}
		Action<bool> a_FlexReady = A_FlexReady;
		if (A_FlexReady != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v262 @ r9_v6 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
		return;
		IL_01dd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0210;
		IL_0210:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01dd;
	}

	private void OnLevelup(int level)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		object obj = level * cooldownReductionPerLevel;
		float num = maxCooldown - (float)obj;
		if (!(minCooldown > num))
		{
			if (num > maxCooldown)
			{
				cooldown = maxCooldown;
			}
			else
			{
				cooldown = num;
			}
		}
		else
		{
			cooldown = minCooldown;
		}
	}

	public override void Tick()
	{
		//IL_008c: Invalid comparison between I4 and F4
		GameManager instance = GameManager.Instance;
		if ((!instance._003CisCrypt_003Ek__BackingField || (0f < MyTime.cryptTimer && MyTime.cryptTimer < 600f)) && !canFlex && MyTime.time > flexReadyAtTime)
		{
			canFlex = true;
			Action<bool> a_FlexReady = A_FlexReady;
			if (A_FlexReady != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v137 @ r9_v2 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void OnCheckStopDamage(DamageContainer dc, bool shieldDamage)
	{
		//IL_0097: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_00c8: Expected F4, but got I4
		//IL_0067: Expected O, but got I4
		if (!(MyTime.time > flexReadyAtTime))
		{
			return;
		}
		if (!dc.damageSource.Equals(ItemKevin.damageSource) && !dc.damageSource.Equals("HealthRegen"))
		{
			object obj = dc.flags & DcFlags.BypassAll;
			if ((nint)obj == 5)
			{
				return;
			}
		}
		object obj2 = dc.flags & DcFlags.BossDamage;
		bool flag = obj2 == null;
		object obj3 = !flag;
		float damage = ((obj3 != null) ? (dc.damage * 0.25f) : 0f);
		dc.damage = damage;
		UseFlex();
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		return instance.baseDamage;
	}

	private float GetKnockback()
	{
		float stat = PlayerStats.GetStat(EStat.KnockbackMultiplier);
		return stat + stat;
	}

	private unsafe void UseFlex()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00a1: Expected O, but got Ref
		//IL_0101: Expected O, but got I4
		//IL_03f6: Expected O, but got I
		//IL_012e: Expected O, but got I
		//IL_0336: Expected O, but got Ref
		//IL_0357: Expected O, but got Ref
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_016b: Expected O, but got I
		//IL_01cf: Expected O, but got Ref
		//IL_0207: Expected O, but got I4
		//IL_026f: Expected O, but got I
		//IL_0299: Expected O, but got I
		//IL_02b4: Expected F4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		float num = MyTime.time + cooldown;
		flexReadyAtTime = num;
		int num2 = stacks + 1;
		stacks = num2;
		StatModifier statModifier = new StatModifier();
		statModifier.stat = EStat.DamageMultiplier;
		statModifier.modifyType = EStatModifyType.Flat;
		float modification = (float)stacks * damagePerFlex;
		statModifier.modification = modification;
		SetStat(statModifier);
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		float num3 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num3), radius, out System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64)));
		bool flag = enemiesInRadiusSafe <= 0;
		float num4 = radius;
		int num11 = default(int);
		float num12 = default(float);
		if (!flag)
		{
			float num6 = default(float);
			float num5 = num6;
			float num8 = default(float);
			float num7 = num8;
			float num9 = radius;
			num3 = position.x;
			object obj3 = 0;
			Enemy enemy2 = default(Enemy);
			object obj6 = default(object);
			bool flag2;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
				object obj4 = 0;
				ref Enemy enemy = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
				EnemyManager instance = EnemyManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r10_v5+20+v252 @ rdi_v9*8]");
				if (instance.GetEnemy((Collider)0, out enemy))
				{
					float damage = GetDamage();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
					Transform transform2 = ((Component)0).transform;
					Vector3 position2 = transform2.position;
					Transform transform3 = MyPlayer.Instance.transform;
					Vector3 position3 = transform3.position;
					float num10 = position2.x - position3.x;
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, damage, 1f, damageSource, (Vector3)num11, enemy2);
					reuseDc = damageContainer;
					DamageContainer damageContainer2 = reuseDc;
					float stat = PlayerStats.GetStat(EStat.KnockbackMultiplier);
					modification = stat + stat;
					damageContainer2.knockback = modification;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
					((Enemy)0).DamageFromPlayerOther(reuseDc);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
					((Enemy)0).AddDebuff(EDebuff.Stun, reuseDc, 3f, num11);
					num5 = 3f;
					num7 = damage;
					num12 = (float)obj6;
					num9 = 1f;
					num3 = num10;
				}
				obj3++;
				flag2 = (nint)obj3 < enemiesInRadiusSafe;
				num4 = num9;
			}
			while (flag2);
		}
		Transform transform4 = MyPlayer.Instance.transform;
		Vector3 position4 = transform4.position;
		Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		_ = MyColorUtility.aegisColor;
		EffectManager.Instance.PopupText("FLEX", color, (Vector3)(&num12), num11);
		MyPlayer instance2 = MyPlayer.Instance;
		instance2.playerSfxs.Flex();
		canFlex = false;
		Action<bool> a_FlexReady = A_FlexReady;
		if (A_FlexReady != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v579 @ r9_v6 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private bool HasFlex()
	{
		//IL_0034: Invalid comparison between F4 and I4
		bool flag = MyTime.time < flexReadyAtTime;
		float num = MyTime.time - flexReadyAtTime;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Flex;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_00b9: Expected I, but got O
		//IL_00d2: Expected O, but got I
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string value = $"{obj}";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
		string text = EnumUtility.EnumToReadable(EStat.DamageMultiplier);
		if (text == null)
		{
			text = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"statDamage", (object)text);
		float num = damagePerFlex * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value2 = $"{arg}%";
		((Dictionary<object, object>)(object)dictionary).Add((object)"valueDamage", (object)value2);
		object[] array = new object[1];
		if (array != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
			dictionary.Add((string)0, value2);
			object obj2 = default(object);
			if (obj2 == null)
			{
				((Dictionary<string, object>)(object)"{0}").Add((string)obj, (object)null);
				object obj3 = default(object);
				throw obj3;
			}
			array[0] = dictionary;
			if (localizedString != null)
			{
				return localizedString.GetLocalizedString(array);
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public PassiveAbilityFlex()
	{
		DamageContainer damageContainer = new DamageContainer(1f, "Flex");
		reuseDc = damageContainer;
		damageSource = "Flex";
		base._002Ector();
	}
}
