using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	[Serializable]
	public class Achievement
	{
		public string id;

		public string statKey;

		public int threshhold;

		public string title;

		public string description;

		public string narration;

		public string tier;

		public float delayOverride;

		public bool isSecret;

		public bool isAvailableInEA;

		public bool isSteam;

		[NonSerialized]
		private List<Achievement> _achievementGroup;

		private List<Achievement> AchievementGroup => null;

		public bool IsVisible()
		{
			return false;
		}

		public string GetGroupKey()
		{
			return null;
		}

		public bool IsAchieved()
		{
			return false;
		}

		public bool IsRequirementMet()
		{
			return false;
		}

		public bool HasProgression()
		{
			return false;
		}

		public int GetProgressionValue()
		{
			return 0;
		}

		public DateTime GetAchievedTimestamp()
		{
			return default(DateTime);
		}

		public TooltipData GetTooltip()
		{
			return null;
		}
	}
}
