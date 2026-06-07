using System;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public struct SteamAchievementInfo
	{
		public string statName;

		public StatType statType;

		public float minValue;

		public float maxValue;
	}
}
