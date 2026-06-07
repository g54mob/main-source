using System;
using System.Collections.Generic;

[Serializable]
public class TowerIngameData
{
	public eItemType ItemType;

	public int Level;

	public bool DoOverrideBuildLimit;

	public int OverrideBuildLimit;

	public List<TowerStats> List_AdditionalBuff;

	public TowerIngameData(eItemType type, int level)
	{
	}
}
