using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemFlappyFeathers : ItemBase
{
	private float speedBoostPerAmount = 2.2f;

	private float jumpHeightAdditionPerAmount = 0.15f;

	private float speedBoost;

	private int extraJumpsPerAmount = 1;

	protected override void OnInitOrAmountChanged()
	{
		StatModifier statModifier = new StatModifier();
		statModifier.stat = EStat.JumpHeight;
		float modification = (float)amount * jumpHeightAdditionPerAmount;
		statModifier.modification = modification;
		SetStat(statModifier);
		StatModifier statModifier2 = new StatModifier();
		statModifier2.modifyType = EStatModifyType.Flat;
		statModifier2.stat = EStat.ExtraJumps;
		float modification2 = (float)extraJumpsPerAmount * (float)amount;
		statModifier2.modification = modification2;
		SetStat(statModifier2);
		float num = (float)amount * speedBoostPerAmount;
		speedBoost = num;
	}

	private unsafe void OnJumped(PlayerMovement pm)
	{
		//IL_0017: Expected O, but got Ref
		//IL_0053: Expected O, but got Ref
		Vector3 wishDir = pm.GetWishDir();
		float num = default(float);
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Vector3 velocity = pm.rb.velocity;
		pm.rb.velocity = (Vector3)(&num);
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerMovement> b = OnJumped;
		Delegate obj = Delegate.Combine(PlayerMovement.A_Jumped, b);
		if ((object)obj == null)
		{
			PlayerMovement.A_Jumped = (Action<PlayerMovement>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerMovement> action = default(Action<PlayerMovement>);
		if (action != null)
		{
			PlayerMovement.A_Jumped = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerMovement>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerMovement>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerMovement> value = OnJumped;
		Delegate obj = Delegate.Remove(PlayerMovement.A_Jumped, value);
		if ((object)obj == null)
		{
			PlayerMovement.A_Jumped = (Action<PlayerMovement>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerMovement> action = default(Action<PlayerMovement>);
		if (action != null)
		{
			PlayerMovement.A_Jumped = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerMovement>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerMovement>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public ItemFlappyFeathers(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
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
		//IL_01ba: Expected O, but got I
		//IL_0079: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_009d: Expected I, but got O
		//IL_00b6: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_00e6: Expected I, but got O
		//IL_01eb: Expected O, but got I
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected I, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.ExtraJumps);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 46;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			object[] array = new object[1];
			bool flag2 = array == null;
			obj = text;
			obj2 = 1;
			num = (nint)typeof(object[]);
			if (!flag2)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v9 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text);
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				obj = text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v9 (Il2CppClass<System.Object[]>)+40]");
				obj2 = 0;
				num = (nint)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)num).Add((string)obj2, obj);
					object obj4 = default(object);
					throw obj4;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				num = (nint)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				obj = text;
				obj2 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}
}
