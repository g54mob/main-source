using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementData : ScriptableObject
{
	public enum AchievementPlatform
	{
		None = 0,
		GameCenter = 1,
		Steamworks = 2
	}

	public enum AchievementDataType
	{
		None = 0,
		PlatformId = 1
	}

	[Serializable]
	public class AchievementPlatformSpecificData
	{
		public AchievementPlatform forPlatform;

		public AchievementDataType dataKey;

		public int intData;

		public string stringData;

		public virtual AchievementPlatformSpecificData Clone(AchievementPlatformSpecificData intoData = null)
		{
			AchievementPlatformSpecificData achievementPlatformSpecificData = intoData;
			if (achievementPlatformSpecificData == null)
			{
				achievementPlatformSpecificData = new AchievementPlatformSpecificData();
			}
			achievementPlatformSpecificData.forPlatform = forPlatform;
			achievementPlatformSpecificData.dataKey = dataKey;
			achievementPlatformSpecificData.intData = intData;
			achievementPlatformSpecificData.stringData = stringData;
			return achievementPlatformSpecificData;
		}
	}

	public Sprite achievementIcon;

	[SerializeField]
	public List<AchievementPlatformSpecificData> platformSpecificData = new List<AchievementPlatformSpecificData>();

	public virtual string GetId()
	{
		return base.name;
	}
}
