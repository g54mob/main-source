using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemScarf : ItemBase
{
	private float damageAddPerAmount = 0.5f;

	private float damageAdd;

	private float lastValueSet;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * damageAddPerAmount;
		damageAdd = num;
		if (MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerMovement playerMovement = instance.playerMovement;
			UpdateDamage(playerMovement.grounded);
		}
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	private void OnGroundedChange(bool grounded)
	{
		UpdateDamage(grounded);
	}

	private void UpdateDamage(bool grounded)
	{
		//IL_001d: Expected F4, but got I4
		float num = (grounded ? 0f : damageAdd);
		bool flag = num == lastValueSet;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180463F57h\"");
		if (!flag)
		{
			lastValueSet = num;
			StatModifier statModifier = new StatModifier();
			statModifier.modification = num;
			statModifier.stat = EStat.DamageMultiplier;
			SetStat(statModifier);
		}
	}

	public ItemScarf(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> b = OnGroundedChange;
		Delegate obj = Delegate.Combine(PlayerMovement.A_Grounded, b);
		if ((object)obj == null)
		{
			PlayerMovement.A_Grounded = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			PlayerMovement.A_Grounded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> value = OnGroundedChange;
		Delegate obj = Delegate.Remove(PlayerMovement.A_Grounded, value);
		if ((object)obj == null)
		{
			PlayerMovement.A_Grounded = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			PlayerMovement.A_Grounded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Tick()
	{
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
		string text = EnumUtility.EnumToReadable(EStat.DamageMultiplier);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num = damageAddPerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
