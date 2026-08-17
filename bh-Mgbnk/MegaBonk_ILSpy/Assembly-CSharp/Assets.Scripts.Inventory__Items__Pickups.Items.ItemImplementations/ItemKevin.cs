using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemKevin : ItemBase
{
	private float damageChancePerAmount = 0.25f;

	private float damageChance;

	private int numHits;

	public static string damageSource;

	public static Action<int> A_PunchedByKevin;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * damageChancePerAmount;
		damageChance = num;
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> b = OnEnemyDamaged;
		Delegate obj = Delegate.Combine(Enemy.A_Damage, b);
		if ((object)obj == null)
		{
			Enemy.A_Damage = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_Damage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> value = OnEnemyDamaged;
		Delegate obj = Delegate.Remove(Enemy.A_Damage, value);
		if ((object)obj == null)
		{
			Enemy.A_Damage = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_Damage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnEnemyDamaged(Enemy enemy, DamageContainer dc)
	{
		//IL_0037: Invalid comparison between F4 and I4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		PlayerHealth playerHealth = inventory.playerHealth;
		if (1f < (float)playerHealth.hp)
		{
			int num = numHits + 1;
			numHits = num;
		}
	}

	private unsafe void CheckSelfDamage()
	{
		//IL_0037: Invalid comparison between F4 and I4
		//IL_00c5: Expected O, but got I4
		//IL_00eb: Expected F8, but got I4
		//IL_00fc: Expected F8, but got I4
		//IL_01d7: Invalid comparison between F8 and I4
		//IL_027a: Expected O, but got I4
		//IL_027a: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		PlayerHealth playerHealth = inventory.playerHealth;
		if (!(1f < (float)playerHealth.hp))
		{
			return;
		}
		int num = numHits ^ numHits;
		int num2 = numHits & num;
		bool flag = num2 < 0;
		bool flag2 = numHits < 0;
		bool flag3 = numHits == 0;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		object obj = flag5 & flag4;
		bool flag6 = numHits <= 0;
		int num3 = 0;
		double num4 = 0.0;
		double num6 = default(double);
		float num5 = (float)num6;
		double num7 = 0.0;
		if (!flag6)
		{
			bool flag7;
			do
			{
				double num8 = Math.Floor(damageChance);
				System.Random random = MyRandom.random;
				double num9 = random.NextDouble();
				double num10 = (double)damageChance - num8;
				double num11 = num8 + 1.0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
				if ((nint)random <= 0)
				{
					num11 = num8;
				}
				num3++;
				num4 += num11;
				flag7 = num3 < numHits;
				num5 = (float)num10;
				num7 = num4;
			}
			while (flag7);
		}
		numHits = 0;
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		PlayerHealth playerHealth2 = inventory2.playerHealth;
		double num12 = (double)playerHealth2.hp - num7;
		if (!(num12 > 1.0))
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance3.inventory;
			PlayerHealth playerHealth3 = inventory3.playerHealth;
			num7 = (double)playerHealth3.hp - 1.0;
		}
		if (!(num7 < 1.0))
		{
			MyPlayer instance4 = MyPlayer.Instance;
			PlayerInventory inventory4 = instance4.inventory;
			object obj2 = default(object);
			bool ignoreShield = default(bool);
			string text = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory4.playerHealth.DamagePlayerExternal((float)num7, 0f, (Vector3)(&obj2), ignoreShield, text, flags, damageEffect, (Enemy)1);
			num5 = (float)num7;
		}
		Action<int> a_PunchedByKevin = A_PunchedByKevin;
		if (A_PunchedByKevin != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v391 @ r9_v3 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void Tick()
	{
		CheckSelfDamage();
	}

	public ItemKevin(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
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

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_0095: Expected O, but got I4
		//IL_00b9: Expected I, but got O
		//IL_00d2: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = damageChancePerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string text = $"+{obj}%";
		bool flag = dictionary == null;
		object obj2 = null;
		object obj3 = obj;
		string text2 = "+{0}%";
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)text);
			object[] array = new object[1];
			bool flag2 = array == null;
			nint num2 = 0;
			obj2 = text;
			obj3 = 1;
			text2 = (string)(object)typeof(object[]);
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text);
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				num2 = 0;
				obj2 = text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
				obj3 = 0;
				text2 = (string)(object)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)(object)text2).Add((string)obj3, obj2);
					object obj5 = default(object);
					throw obj5;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				text2 = (string)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				num2 = 0;
				obj2 = text;
				obj3 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}

	unsafe static ItemKevin()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
