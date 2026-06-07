using System;

[Serializable]
public class PetUpgradeInst : UpgradeInst<PetUpgradeInfo>
{
	public PetUpgradeType Type;

	public PetUpgradeInst(PetUpgradeType pt)
	{
	}

	public override PetUpgradeInfo GetInfo()
	{
		return null;
	}
}
