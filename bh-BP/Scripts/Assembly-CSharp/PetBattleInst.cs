using System;
using System.Collections.Generic;

[Serializable]
public class PetBattleInst
{
	public int Id;

	public PetType Type;

	public float StateChangeTime;

	public int MaxHealth;

	public int CurHealth;

	public List<PetUpgradeInst> Upgrades;

	[NonSerialized]
	public PetObj Obj;

	private PetInst _metaInst;

	public PetBattleInst(PetInst inst)
	{
	}

	public PetInst GetMetaInst()
	{
		return null;
	}

	public bool HasUpgrade(PetUpgradeType pt)
	{
		return false;
	}

	public int GetUpgradeLvl(PetUpgradeType pt)
	{
		return 0;
	}

	public PetUpgradeInst GetUpgrade(PetUpgradeType pt)
	{
		return null;
	}

	public void AddUpgrade(PetUpgradeType pt)
	{
	}
}
