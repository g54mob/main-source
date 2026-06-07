using System;
using System.Collections.Generic;

[Serializable]
public class PassiveInst : UpgradeInst<PassiveInfo>
{
	public PassiveType Type;

	public int NextActiveTurn;

	public List<PassiveStatData> StatData;

	public PassiveInst(PassiveType type)
	{
	}

	public PassiveInst(PassiveInst toCopy)
	{
	}

	public override PassiveInfo GetInfo()
	{
		return null;
	}

	public PassiveStatData GetStatData()
	{
		return null;
	}

	public string DumpStats()
	{
		return null;
	}
}
