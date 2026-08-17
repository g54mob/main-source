using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive;

public abstract class PassiveAbility
{
	public Dictionary<EStat, StatModifiersContainer> statModifiers;

	public static Action<EStat> A_StatModified;

	protected void SetStat(StatModifier statModifier)
	{
		if (!((Dictionary<System.Int32Enum, object>)(object)statModifiers).ContainsKey((System.Int32Enum)statModifier.stat))
		{
			StatModifiersContainer value = new StatModifiersContainer();
			((Dictionary<System.Int32Enum, object>)(object)statModifiers).Add((System.Int32Enum)statModifier.stat, (object)value);
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)statModifiers).get_Item((System.Int32Enum)statModifier.stat);
		((StatModifiersContainer)obj).SetModifier(statModifier);
		Action<EStat> a_StatModified = A_StatModified;
		if (A_StatModified != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v209 @ rax_v9 (System.Action`1<Assets.Scripts.Menu.Shop.EStat>)+18] (should have been resolved before IL gen)");
		}
	}

	public abstract void Init();

	public abstract void Cleanup();

	public abstract void Tick();

	public abstract EPassive GetPassiveType();

	public virtual string GetDescription(LocalizedString localizedString)
	{
		if (localizedString != null)
		{
			return localizedString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	protected PassiveAbility()
	{
		Dictionary<EStat, StatModifiersContainer> dictionary = new Dictionary<EStat, StatModifiersContainer>();
		statModifiers = dictionary;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
