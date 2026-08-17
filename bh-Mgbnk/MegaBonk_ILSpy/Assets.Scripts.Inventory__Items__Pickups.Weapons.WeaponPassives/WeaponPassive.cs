using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponPassives;

public abstract class WeaponPassive
{
	public Dictionary<EStat, StatModifiersContainer> statModifiers;

	protected WeaponBase weaponBase;

	public WeaponPassive(WeaponBase weaponBase)
	{
		Dictionary<EStat, StatModifiersContainer> dictionary = new Dictionary<EStat, StatModifiersContainer>();
		statModifiers = dictionary;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		this.weaponBase = weaponBase;
	}

	protected void SetStat(StatModifier statModifier)
	{
		if (!((Dictionary<System.Int32Enum, object>)(object)statModifiers).ContainsKey((System.Int32Enum)statModifier.stat))
		{
			StatModifiersContainer value = new StatModifiersContainer();
			((Dictionary<System.Int32Enum, object>)(object)statModifiers).Add((System.Int32Enum)statModifier.stat, (object)value);
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)statModifiers).get_Item((System.Int32Enum)statModifier.stat);
		((StatModifiersContainer)obj).SetModifier(statModifier);
		weaponBase.UpdateStat(statModifier.stat);
	}

	public abstract void Init();

	public abstract void Cleanup();
}
