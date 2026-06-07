using System;
using UnityEngine;

[Serializable]
public class AchievementSettingEntry
{
	[SerializeField]
	private eAchievementType achievementType;

	[SerializeField]
	private bool isAchievementLocked;

	[SerializeField]
	private Sprite icon_Completed;

	[SerializeField]
	private Sprite icon_NotCompleted;

	[SerializeField]
	private bool hasProgress;

	[SerializeField]
	private int targetValue;

	[SerializeField]
	private eCharacterType requireCharacter;

	[SerializeField]
	private eWorldType requireUnlockWorld;

	public eAchievementType AchievementType => default(eAchievementType);

	public bool IsAchievementLocked => false;

	public Sprite Icon_Completed => null;

	public Sprite Icon_NotCompleted => null;

	public bool HasProgress => false;

	public int TargetValue => 0;

	public eCharacterType RequireCharacter => default(eCharacterType);

	public eWorldType RequireUnlockWorld => default(eWorldType);

	public void SetNotCompletedIcon(Sprite sprite)
	{
	}

	public bool IsHaveRequireCharacter()
	{
		return false;
	}

	public bool IsHaveRequireUnlockWorld()
	{
		return false;
	}
}
