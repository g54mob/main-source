using System;

[Serializable]
public struct UpgradeChange
{
	public int Value;

	public UpgradeChangeType Type;

	public UpgradeChange(int val, UpgradeChangeType t = UpgradeChangeType.kAdditive)
	{
		Value = 0;
		Type = default(UpgradeChangeType);
	}
}
