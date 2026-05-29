using System;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	internal class AchievementInfo
	{
		public string key;

		public string steamAPI;

		public SteamAchievementInfo steamExtras;

		public string gogAPI;

		public string epicAPI;

		public int playstation4;

		public string gamecoreAPI;

		public string iosAPI;

		public string androidAPI;
	}
}
