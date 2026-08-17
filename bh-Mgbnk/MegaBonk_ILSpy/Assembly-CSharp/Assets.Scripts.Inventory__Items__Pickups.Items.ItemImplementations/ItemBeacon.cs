using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBeacon : ItemBase
{
	private int extraShrinesPerAmount = 2;

	private float healingRadiusPerAmount = 2f;

	private float healingFractionPerInterval = 0.025f;

	public float GetHealingPerInterval()
	{
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		PlayerHealth playerHealth = inventory.playerHealth;
		float num = (float)amount * healingFractionPerInterval;
		return num * (float)playerHealth.maxHp;
	}

	public float GetRadius()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		object obj = amount * healingRadiusPerAmount;
		return (float)obj + 8f;
	}

	public int GetExtraShrines()
	{
		return extraShrinesPerAmount * amount;
	}

	public ItemBeacon(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	protected override void OnInitOrAmountChanged()
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
		//IL_00b2: Expected O, but got I4
		//IL_00d6: Expected I, but got O
		//IL_00e6: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string localizedString2 = LocalizationUtility.GetLocalizedString("Game_Interactables", "CHARGE_SHRINE_NAME");
		bool flag = dictionary == null;
		object obj = null;
		string text = "CHARGE_SHRINE_NAME";
		string text2 = "Game_Interactables";
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"charge_shrine", (object)localizedString2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text3 = $"+{arg}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value", (object)text3);
			object[] array = new object[1];
			bool flag2 = array == null;
			obj = text3;
			text = (string)1;
			text2 = (string)(object)typeof(object[]);
			if (!flag2)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
				text = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text3);
				object obj2 = default(object);
				bool flag3 = obj2 == null;
				obj = text3;
				text2 = (string)(object)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)(object)text2).Add(text, obj);
					object obj3 = default(object);
					throw obj3;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				text2 = (string)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				obj = text3;
				text = (string)(object)dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}
}
