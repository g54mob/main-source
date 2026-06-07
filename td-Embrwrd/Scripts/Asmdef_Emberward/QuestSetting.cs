using System;
using UnityEngine;

[Serializable]
public class QuestSetting
{
	public eQuestType type;

	public eQuestDifficulty difficulty;

	public bool difficultyEasyAvailable;

	public bool difficultyNormalAvailable;

	public bool difficultyHardAvailable;

	public bool isInGame;

	public bool isInDemo;

	public bool editorTest;

	public int RequireValueCount;

	public int Requirement_value_1;

	public int Requirement_value_2;

	public int Requirement_value_3;

	[Header("玩家最少砲塔數量")]
	public int PlayerMinTowerCount;

	[Header("玩家擁有某種塔")]
	public eItemType PlayerHasTower;

	[Header("玩家擁有某種屬性的塔")]
	public eDamageType PlayerHasTowerType;

	[Header("玩家擁有某種尺寸的塔")]
	public eTowerSizeType PlayerHasTowerSize;

	private Color GetQuestDifficultyColor()
	{
		return default(Color);
	}

	private Color GetEditorTestColor()
	{
		return default(Color);
	}

	private Color GetRequireValueCountColor()
	{
		return default(Color);
	}

	private Color GetRequirementValue1Color()
	{
		return default(Color);
	}

	private Color GetRequirementValue2Color()
	{
		return default(Color);
	}

	private Color GetRequirementValue3Color()
	{
		return default(Color);
	}

	public bool CanAppearInDifficulty(eQuestDifficulty difficulty)
	{
		return false;
	}
}
