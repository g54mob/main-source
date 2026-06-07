using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/LevelConfigSO")]
public class LevelConfigSO : ScriptableObject
{
	[Header("Level XP Gereksinimleri")]
	[Tooltip("Index 0 kullanılmaz. Index 1 = Level 2 için gereken XP, Index 2 = Level 3 için gereken XP...")]
	public List<int> requiredXPList = new List<int>();

	public int MaxLevel => requiredXPList.Count;

	public int GetRequiredXPForLevel(int targetLevel)
	{
		int num = targetLevel - 1;
		if (num < 0 || num >= requiredXPList.Count)
		{
			return int.MaxValue;
		}
		return requiredXPList[num];
	}

	public bool IsMaxLevel(int level)
	{
		return level >= MaxLevel;
	}
}
