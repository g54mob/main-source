using System;
using System.Collections.Generic;
using Factory;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement Database", menuName = "Motorways/Achievements/Achievement Collection", order = 2)]
public class AchievementDatabase : ScriptableObject, IReleasedFromScopeHandler
{
	public const string MenuItemFolder = "Motorways/Achievements/";

	public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("AchievementDatabase");

	private List<AchievementDefinition> achievements = new List<AchievementDefinition>();

	public List<AchievementData> allAchievementData = new List<AchievementData>();

	[Dependency]
	protected IScope _scope;

	public AchievementDefinition this[int key] => achievements[key];

	public AchievementDefinition this[string key]
	{
		get
		{
			for (int i = 0; i < achievements.Count; i++)
			{
				if (achievements[i].Id == key)
				{
					return achievements[i];
				}
			}
			return null;
		}
	}

	public AchievementDefinition this[Enum key]
	{
		get
		{
			string key2 = key.ToString();
			return this[key2];
		}
	}

	public int Count => achievements.Count;

	public bool Load()
	{
		for (int i = 0; i < allAchievementData.Count; i++)
		{
			AchievementDefinition achievementDefinition = AchievementDefinition.FromAchievementData(allAchievementData[i], _scope);
			if (achievementDefinition == null)
			{
				Log.Warn("Failed to load achievement {0}.", i);
			}
			else
			{
				achievements.Add(achievementDefinition);
			}
		}
		return true;
	}

	public bool ContainsAchievement(string achievementName)
	{
		for (int i = 0; i < achievements.Count; i++)
		{
			if (achievements[i].Id == achievementName)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsAchievement(Enum achievementNameEnum)
	{
		string achievementName = achievementNameEnum.ToString();
		return ContainsAchievement(achievementName);
	}

	public void OnReleasedFromScope(IScope scope)
	{
		for (int i = 0; i < achievements.Count; i++)
		{
			scope.Release(achievements[i]);
		}
	}
}
