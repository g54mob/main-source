using System;
using UnityEngine;

[Serializable]
public class AchievementDisplayData
{
	public int index;

	public bool showIfNotUnlocked;

	public Sprite icon;

	public AchievementDisplayData(int index, bool showIfNotUnlocked, Sprite icon)
	{
		this.index = index;
		this.showIfNotUnlocked = showIfNotUnlocked;
		this.icon = icon;
	}
}
