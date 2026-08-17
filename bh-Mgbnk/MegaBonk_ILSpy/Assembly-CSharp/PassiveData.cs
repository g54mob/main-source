using System;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive;
using UnityEngine;
using UnityEngine.Localization;

public class PassiveData : ScriptableObject
{
	public LocalizedString localizedName;

	public LocalizedString localizedDescription;

	public EPassive ePassive;

	public Texture icon;

	private PassiveAbility dummyPassive;

	public string GetName()
	{
		if (localizedName != null)
		{
			return localizedName.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetDescription()
	{
		if (dummyPassive != null)
		{
			return dummyPassive.GetDescription(localizedDescription);
		}
		return (string)(object)new NullReferenceException();
	}

	public void Init()
	{
		if (dummyPassive == null)
		{
			PassiveAbility passiveAbility = PassiveAbilityFactory.CreatePassiveAbility(this);
			dummyPassive = passiveAbility;
		}
	}
}
