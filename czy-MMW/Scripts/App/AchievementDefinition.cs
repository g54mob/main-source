using System.Collections.Generic;
using Factory;
using UnityEngine;

public abstract class AchievementDefinition
{
	protected List<AchievementData.AchievementPlatformSpecificData> platformSpecificData = new List<AchievementData.AchievementPlatformSpecificData>();

	[Dependency]
	protected IScope _scope;

	public string Id { get; protected set; }

	public Sprite Icon { get; protected set; }

	public bool HasLoggedFailure { get; set; }

	public virtual bool CanBeAwardedRetroactively => true;

	public virtual int GetIntDataForPlatformAndKey(AchievementData.AchievementPlatform platform, AchievementData.AchievementDataType dataKey)
	{
		int result = -1;
		for (int i = 0; i < platformSpecificData.Count; i++)
		{
			AchievementData.AchievementPlatformSpecificData achievementPlatformSpecificData = platformSpecificData[i];
			if (achievementPlatformSpecificData.forPlatform == platform && achievementPlatformSpecificData.dataKey == dataKey)
			{
				result = achievementPlatformSpecificData.intData;
				break;
			}
		}
		return result;
	}

	public bool TryGetStringDataForPlatformAndKey(AchievementData.AchievementPlatform platform, AchievementData.AchievementDataType dataKey, out string result)
	{
		result = null;
		for (int i = 0; i < platformSpecificData.Count; i++)
		{
			AchievementData.AchievementPlatformSpecificData achievementPlatformSpecificData = platformSpecificData[i];
			if (achievementPlatformSpecificData.forPlatform == platform && achievementPlatformSpecificData.dataKey == dataKey)
			{
				result = achievementPlatformSpecificData.stringData;
				break;
			}
		}
		return result != null;
	}

	public static AchievementDefinition FromAchievementData(AchievementData achievementData, IScope scope)
	{
		AchievementDefinition achievementDefinition = scope.Get<AchievementDefinition>();
		if (achievementDefinition.InitFromAchievementData(achievementData, scope))
		{
			return achievementDefinition;
		}
		return null;
	}

	public virtual bool InitFromAchievementData(AchievementData achievementData, IScope scope)
	{
		Id = achievementData.GetId();
		Icon = achievementData.achievementIcon;
		platformSpecificData = new List<AchievementData.AchievementPlatformSpecificData>(achievementData.platformSpecificData.Count);
		for (int i = 0; i < achievementData.platformSpecificData.Count; i++)
		{
			AchievementData.AchievementPlatformSpecificData achievementPlatformSpecificData = achievementData.platformSpecificData[i];
			platformSpecificData.Add(achievementPlatformSpecificData.Clone());
		}
		return true;
	}
}
