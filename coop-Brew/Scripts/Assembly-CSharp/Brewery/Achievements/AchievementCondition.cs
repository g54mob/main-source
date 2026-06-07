using System;
using UnityEngine;

namespace Brewery.Achievements
{
	[Serializable]
	public class AchievementCondition
	{
		[Tooltip("What this condition checks")]
		public AchievementTriggerType triggerType;

		[Tooltip("Optional context filter")]
		public string context;

		[Tooltip("Required count (1 for one-time, higher for cumulative)")]
		public int requiredCount;

		[Tooltip("Description of this condition for debugging")]
		public string debugDescription;
	}
}
