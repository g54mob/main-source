using System;

namespace Brewery.UI
{
	[Serializable]
	public struct AchievementData
	{
		public string Id;

		public string Icon;

		public string Name;

		public string Description;

		public bool IsUnlocked;

		public AchievementData(string id, string icon, string name, string description, bool unlocked)
		{
			Id = null;
			Icon = null;
			Name = null;
			Description = null;
			IsUnlocked = false;
		}
	}
}
