using System;

[Serializable]
public struct UpgradeChoice
{
	public UpgradeType Type;

	public int EquipmentIdx;

	public int EvoIdx;

	public UpgradeInfo Info;

	public bool IsNew;

	public UpgradeChoice(UpgradeType t, int eqIdx, UpgradeInfo inf, bool isNew, int evoIdx = 0)
	{
		Type = default(UpgradeType);
		EquipmentIdx = 0;
		EvoIdx = 0;
		Info = null;
		IsNew = false;
	}

	public UpgradeChoice(UpgradeInfo inf, bool isNew)
	{
		Type = default(UpgradeType);
		EquipmentIdx = 0;
		EvoIdx = 0;
		Info = null;
		IsNew = false;
	}
}
