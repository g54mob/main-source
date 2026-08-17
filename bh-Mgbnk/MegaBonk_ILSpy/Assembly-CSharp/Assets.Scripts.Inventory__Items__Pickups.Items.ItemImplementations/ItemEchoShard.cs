using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;
using UnityEngine.Localization;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemEchoShard : ItemBase
{
	private static float chancePerAmount = 0.12f;

	public float chance;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * chancePerAmount;
		chance = num;
	}

	public int GetExtraShards()
	{
		//IL_0053: Expected I4, but got O
		bool flag = (nint)MyRandom.random < 0;
		bool flag2 = MyRandom.random == null;
		if (!flag2)
		{
			double num = MyRandom.random.NextDouble();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return (flag4 & flag3) ? 1 : 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public ItemEchoShard(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
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
		//IL_0050: Expected O, but got I4
		//IL_0074: Expected I, but got O
		//IL_008d: Expected O, but got I
		//IL_00ba: Expected O, but got I
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = chancePerAmount * 100f;
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text);
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				num2 = 0;
				obj2 = text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
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
