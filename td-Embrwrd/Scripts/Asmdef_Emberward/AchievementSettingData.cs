using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/成就資料", order = 1)]
public class AchievementSettingData : ScriptableObject
{
	[SerializeField]
	private Sprite sprite_QuestionMark;

	[SerializeField]
	private Sprite sprite_QuestionMark_Gray;

	[SerializeField]
	private List<AchievementSettingEntry> list_AchievementSettings;

	public Sprite Sprite_QuestionMark => null;

	public Sprite Sprite_QuestionMark_Gray => null;

	public List<AchievementSettingEntry> List_AchievementSettings => null;

	public AchievementSettingEntry GetAchievement(eAchievementType type)
	{
		return null;
	}

	public string GetAchievementUnlockKey(eAchievementType type)
	{
		return null;
	}

	public string GetAchievementName(eAchievementType type)
	{
		return null;
	}

	public string GetAchievementDescription(eAchievementType type)
	{
		return null;
	}
}
