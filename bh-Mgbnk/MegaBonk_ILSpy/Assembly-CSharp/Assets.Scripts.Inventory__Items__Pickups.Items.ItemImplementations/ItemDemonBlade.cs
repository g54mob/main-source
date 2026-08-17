using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine.Localization;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemDemonBlade : ItemBase
{
	private float critChance = 0.01f;

	private float healChancePerStack = 0.25f;

	private float totalHealChance;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * healChancePerStack;
		totalHealChance = num;
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.CritChance;
		statModifier.modification = critChance;
		SetStat(statModifier);
	}

	private void OnEnemyDamaged(Enemy e, DamageContainer dc)
	{
		//IL_013d: Invalid comparison between I4 and F8
		if (!dc.crit)
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (inventory.playerHealth.CanLifesteal())
		{
			double d = (double)totalHealChance * (double)dc.procCoefficient;
			double num = Math.Floor(d);
			double num2 = MyRandom.random.NextDouble();
			double num3 = num + 1.0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
			if ((nint)MyRandom.random <= 0)
			{
				num3 = num;
			}
			if (0.0 < num3)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance2.inventory;
				int num4 = inventory2.playerHealth.Heal((float)num3);
			}
		}
	}

	public ItemDemonBlade(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
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

	public override void Tick()
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
		float num = healChancePerStack * 100f;
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
}
