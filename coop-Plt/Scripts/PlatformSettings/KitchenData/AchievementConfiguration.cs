using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(menuName = "Kitchen/Achievement", fileName = "Achievement", order = 0)]
	public class AchievementConfiguration : ScriptableObject
	{
		[Serializable]
		public struct AchievementData
		{
			public string GameIdentifier;

			public int PlaystationIdentifier;

			public int MicrosoftIdentifier;
		}

		public List<AchievementData> Achievements = new List<AchievementData>();

		public Dictionary<string, string> DefaultMapping => Achievements.ToDictionary((AchievementData e) => e.GameIdentifier, (AchievementData e) => e.GameIdentifier);

		public Dictionary<string, string> PlaystationMapping => Achievements.ToDictionary((AchievementData e) => e.GameIdentifier, (AchievementData e) => e.PlaystationIdentifier.ToString());

		public Dictionary<string, string> MicrosoftMapping => Achievements.ToDictionary((AchievementData e) => e.GameIdentifier, (AchievementData e) => e.MicrosoftIdentifier.ToString());
	}
}
