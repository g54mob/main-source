using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemHolyBook : ItemBase
{
	public static Action<float> A_OnUse;

	private float maxHpPerAmount;

	private float hpRegenPerAmount;

	private float overhealPerAmount;

	private float radius;

	private float radiusPerAmount;

	private float healsThisTick;

	private float nextDamageTime;

	private float cooldown;

	private string damageSource;

	private DamageContainer dc;

	protected override void OnInitOrAmountChanged()
	{
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.MaxHealth;
		float modification = (float)amount * maxHpPerAmount;
		statModifier.modification = modification;
		SetStat(statModifier);
		StatModifier statModifier2 = new StatModifier();
		statModifier2.modifyType = EStatModifyType.Flat;
		statModifier2.stat = EStat.HealthRegen;
		float modification2 = (float)amount * hpRegenPerAmount;
		statModifier2.modification = modification2;
		SetStat(statModifier2);
		StatModifier statModifier3 = new StatModifier();
		statModifier3.modifyType = EStatModifyType.Flat;
		statModifier3.stat = EStat.Overheal;
		float modification3 = (float)amount * overhealPerAmount;
		statModifier3.modification = modification3;
		SetStat(statModifier3);
		object obj = amount * radiusPerAmount;
		float num = (float)obj + 5f;
		radius = num;
	}

	public unsafe ItemHolyBook(ItemInventory itemInventoryRef)
	{
		//IL_0077: Expected O, but got Ref
		//IL_008e: Expected O, but got Ref
		maxHpPerAmount = 100f;
		hpRegenPerAmount = 50f;
		overhealPerAmount = 0.25f;
		radiusPerAmount = 1f;
		cooldown = 1.5f;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		object obj2 = default(object);
		string text2 = ((Enum)(&obj2)).ToString();
		dc = new DamageContainer(0.5f, text2);
		base._002Ector(itemInventoryRef);
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, float, bool> b = new Action<object, float, bool>(OnHeal);
		Delegate obj = Delegate.Combine(PlayerHealth.A_Heal, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_Heal = (Action<PlayerHealth, float, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, float, bool> action = default(Action<PlayerHealth, float, bool>);
		if (action != null)
		{
			PlayerHealth.A_Heal = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, float, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, float, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, float, bool> value = new Action<object, float, bool>(OnHeal);
		Delegate obj = Delegate.Remove(PlayerHealth.A_Heal, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_Heal = (Action<PlayerHealth, float, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, float, bool> action = default(Action<PlayerHealth, float, bool>);
		if (action != null)
		{
			PlayerHealth.A_Heal = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, float, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, float, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnHeal(PlayerHealth ph, float hpHealed, bool isShield)
	{
		if (!isShield)
		{
			float num = hpHealed + healsThisTick;
			healsThisTick = num;
		}
	}

	public unsafe override void Tick()
	{
		//IL_0008: Expected O, but got Ref
		//IL_034b: Invalid comparison between I4 and F4
		//IL_00b3: Expected O, but got Ref
		//IL_00d9: Expected O, but got Ref
		//IL_00f9: Expected F4, but got I4
		//IL_03b2: Expected O, but got I
		//IL_0137: Expected O, but got I
		//IL_015b: Expected O, but got I
		//IL_02da: Invalid comparison between F4 and I4
		//IL_01ba: Expected O, but got I
		//IL_01c3: Invalid comparison between F4 and I4
		//IL_03d0: Expected O, but got I
		//IL_0242: Expected O, but got Ref
		//IL_0242: Expected O, but got I
		//IL_0257: Expected F4, but got O
		//IL_027c: Expected O, but got Ref
		//IL_027c: Expected O, but got Ref
		//IL_02ac: Expected F4, but got O
		//IL_02bd: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (!(0f < healsThisTick) || nextDamageTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + cooldown;
		nextDamageTime = num;
		MyPlayer instance = MyPlayer.Instance;
		float num2 = instance.baseDamage * 0.5f;
		float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
		healsThisTick = 0f;
		Transform transform = MyPlayer.Instance.transform;
		float baseDamage = num2 * healsThisTick;
		float num3 = stat * radius;
		Vector3 position = transform.position;
		float num4 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num4), num3, out System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64)));
		bool flag = enemiesInRadiusSafe <= 0;
		float num5 = num3;
		Vector3 vector = (Vector3)(&num4);
		float num6 = num3;
		num4 = position.x;
		float num7 = 0f;
		float num8 = stat;
		if (!flag)
		{
			Vector3 vector2 = default(Vector3);
			Enemy enemy3 = default(Enemy);
			float x = default(float);
			float x2 = default(float);
			float num9 = default(float);
			bool useSfx = default(bool);
			bool flag4;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
				object obj3 = 0;
				ref Enemy enemy = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
				EnemyManager instance2 = EnemyManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ r10_v5+20+v444 @ rbx_v6 (System.Single)*8]");
				bool enemy2 = instance2.GetEnemy((Collider)0, out enemy);
				bool flag2 = !enemy2;
				ref Collider[] reference = ref *(Collider[]*)null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ r10_v5+20+v444 @ rbx_v6 (System.Single)*8]");
				vector = (Vector3)0;
				if (!flag2)
				{
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(dc, baseDamage, 0.5f, damageSource, vector2, enemy3);
					dc = damageContainer;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
					((Enemy)0).DamageFromPlayerOther(dc);
					bool flag3 = !(num7 < 10f);
					num6 = 0.5f;
					reference = ref *(Collider[]*)damageSource;
					vector = (Vector3)dc;
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
						object obj4 = 0;
						Transform transform2 = MyPlayer.Instance.transform;
						Vector3 position2 = transform2.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rcx_v27+50]");
						Vector3 vector3 = ((Collider)0).ClosestPoint((Vector3)(&x));
						num8 = (float)Vector3.zeroVector;
						EffectManager.Instance.EnemyHitEffect((Vector3)(&x2), (Vector3)(&num9), hitEnemy: true, (string)vector2, (GameObject)(object)enemy3, useSfx);
						x2 = vector3.x;
						x = position2.x;
						num6 = 0.5f;
						num4 = (float)Vector3.zeroVector;
						reference = ref *(Collider[]*)1;
						vector = (Vector3)(&x2);
					}
				}
				num7++;
				flag4 = num7 < (float)enemiesInRadiusSafe;
				num5 = num6;
				stat = num8;
			}
			while (flag4);
		}
		Action<float> a_OnUse = A_OnUse;
		if (A_OnUse != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v724 @ rax_v59 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.MaxHealth);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			string text2 = EnumUtility.EnumToReadable(EStat.HealthRegen);
			if (text2 == null)
			{
				text2 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
