using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public abstract class ItemBase
{
	private string damageSource;

	public int amount;

	private ItemInventory itemInventoryRef;

	public Dictionary<EStat, StatModifiersContainer> statModifiers;

	public static Action<ItemBase> A_ItemAdded;

	public static Action<ItemBase> A_ItemRemoved;

	protected ItemBase(ItemInventory itemInventoryRef)
	{
		Dictionary<EStat, StatModifiersContainer> dictionary = new Dictionary<EStat, StatModifiersContainer>();
		statModifiers = dictionary;
		LateFixedUpdate();
		this.itemInventoryRef = itemInventoryRef;
	}

	protected void SetStat(StatModifier statModifier)
	{
		//IL_009c: Expected O, but got I
		if (itemInventoryRef != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)statModifiers).ContainsKey((System.Int32Enum)statModifier.stat))
			{
				StatModifiersContainer statModifiersContainer = new StatModifiersContainer();
				Dictionary<EStatModifyType, StatModifier> statContainers = new Dictionary<EStatModifyType, StatModifier>();
				statModifiersContainer.statContainers = statContainers;
				((Dictionary<System.Int32Enum, object>)(object)statModifiers).Add((System.Int32Enum)statModifier.stat, (object)statModifiersContainer);
			}
			object obj = ((Dictionary<System.Int32Enum, object>)(object)statModifiers).get_Item((System.Int32Enum)statModifier.stat);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v7 (System.Object)+10]");
			((Dictionary<System.Int32Enum, object>)0).set_Item((System.Int32Enum)statModifier.modifyType, (object)statModifier);
			Action<EStat> a_StatsChanged = ItemInventory.A_StatsChanged;
			if (ItemInventory.A_StatsChanged != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v335 @ rax_v12 (System.Action`1<Assets.Scripts.Menu.Shop.EStat>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public void AddAmount()
	{
		int num = amount + 1;
		amount = num;
		OnInitOrAmountChanged();
		Action<ItemBase> a_ItemAdded = A_ItemAdded;
		if (A_ItemAdded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v33 @ rax_v5 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+18] (should have been resolved before IL gen)");
		}
	}

	public void RemoveAmount()
	{
		int num = amount - 1;
		amount = num;
		OnInitOrAmountChanged();
		Action<ItemBase> a_ItemRemoved = A_ItemRemoved;
		if (A_ItemRemoved != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v33 @ rax_v5 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+18] (should have been resolved before IL gen)");
		}
	}

	public abstract void Init();

	public abstract void Cleanup();

	protected abstract void OnInitOrAmountChanged();

	public abstract void Tick();

	public abstract void PreAttack(DamageContainer dc, StatComponents itemAttackModifier);

	public abstract void ProcOnHitEffects(DamageContainer dc);

	public abstract bool HasOnHitEffectProc();

	public abstract bool HasPreAttackProc();

	public virtual void LateFixedUpdate()
	{
	}

	protected virtual Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}

	public virtual string GetDescription(LocalizedString localizedString)
	{
		//IL_018b: Expected I, but got O
		//IL_015a: Expected I, but got O
		//IL_0071: Expected I, but got O
		//IL_0087: Expected I, but got O
		//IL_00b8: Expected I, but got O
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected I, but got Unknown
		//IL_011f: Expected I, but got O
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+210]");
		nint num2 = 0;
		Dictionary<string, object> localizationKeys = GetLocalizationKeys();
		bool flag = localizationKeys == null;
		Dictionary<string, object> dictionary = (Dictionary<string, object>)(object)this;
		nint num3;
		if (!flag)
		{
			int count = localizationKeys.Count;
			bool flag2 = count == 0;
			num2 = 0;
			dictionary = localizationKeys;
			if (!flag2)
			{
				object[] array = new object[1];
				bool flag3 = array == null;
				num2 = 1;
				num3 = (nint)typeof(object[]);
				if (!flag3)
				{
					nint num4 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj = default(object);
					bool flag4 = obj == null;
					num3 = (nint)localizationKeys;
					if (flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						object obj2 = default(object);
						throw obj2;
					}
					if (array.Length <= 0)
					{
						return (string)(object)new IndexOutOfRangeException();
					}
					num3 = (nint)(array + 32);
					array[0] = localizationKeys;
					bool flag5 = localizedString == null;
					num2 = (nint)localizationKeys;
					if (!flag5)
					{
						return localizedString.GetLocalizedString(array);
					}
				}
				goto IL_017a;
			}
		}
		bool flag6 = localizedString == null;
		num3 = (nint)dictionary;
		if (!flag6)
		{
			return localizedString.GetLocalizedString();
		}
		goto IL_017a;
		IL_017a:
		throw new NullReferenceException();
	}
}
