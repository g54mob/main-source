using System;
using System.Collections.Generic;

[Serializable]
public class EternalTrialsRun
{
	public int currentStageSeed;

	public string currentMap = "Nordfels";

	public int stage;

	public int score;

	public bool runComplete;

	public bool inGame;

	public bool inNight;

	public List<EquippablePerk> acquiredPerks = new List<EquippablePerk>();

	public List<EquippablePerk> disabledPerks = new List<EquippablePerk>();

	public EquippableWeapon currentWeapon;

	public List<string> acquiredPerkNamesForSaving = new List<string>();

	public List<string> disabledPerkNamesForSaving = new List<string>();

	public string currentWeaponNameForSaving = "";

	public int StageBonusScore => stage * stage * 1000;

	public int OverallScore => score + StageBonusScore;

	public EternalTrialsRun(string currentMap, int currentStageSeed, int stage = 0, bool runComplete = false)
	{
		this.currentStageSeed = currentStageSeed;
		this.currentMap = currentMap;
		this.stage = stage;
		this.runComplete = runComplete;
	}

	public void LoadoutToStringsForSaving()
	{
		acquiredPerkNamesForSaving = new List<string>();
		disabledPerkNamesForSaving = new List<string>();
		currentWeaponNameForSaving = "";
		if (currentWeapon != null)
		{
			currentWeaponNameForSaving = currentWeapon.displayName;
		}
		foreach (EquippablePerk acquiredPerk in acquiredPerks)
		{
			acquiredPerkNamesForSaving.Add(acquiredPerk.displayName);
		}
		foreach (EquippablePerk disabledPerk in disabledPerks)
		{
			disabledPerkNamesForSaving.Add(disabledPerk.displayName);
		}
	}

	public void SavedStringsToLoadout()
	{
		currentWeapon = null;
		acquiredPerks = new List<EquippablePerk>();
		disabledPerks = new List<EquippablePerk>();
		List<EquippableWeapon> list = new List<EquippableWeapon>();
		List<EquippablePerk> list2 = new List<EquippablePerk>();
		foreach (Equippable allEquippable in PerkManager.instance.allEquippables)
		{
			if (allEquippable is EquippableWeapon)
			{
				list.Add(allEquippable as EquippableWeapon);
			}
			if (allEquippable is EquippablePerk)
			{
				list2.Add(allEquippable as EquippablePerk);
			}
		}
		foreach (EquippableWeapon item in list)
		{
			if (item.displayName == currentWeaponNameForSaving)
			{
				currentWeapon = item;
				break;
			}
		}
		foreach (string item2 in acquiredPerkNamesForSaving)
		{
			foreach (EquippablePerk item3 in list2)
			{
				if (item3.displayName == item2)
				{
					acquiredPerks.Add(item3);
					break;
				}
			}
		}
		foreach (string item4 in disabledPerkNamesForSaving)
		{
			foreach (EquippablePerk item5 in list2)
			{
				if (item5.displayName == item4)
				{
					disabledPerks.Add(item5);
					break;
				}
			}
		}
	}
}
