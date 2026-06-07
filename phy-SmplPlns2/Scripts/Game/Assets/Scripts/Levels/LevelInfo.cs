using System.Collections.Generic;
using Jundroo.SocialPlatforms.Achievements;

namespace Assets.Scripts.Levels
{
	public class LevelInfo
	{
		public AchievementKey? AchievementKey { get; set; }

		public bool CarRace { get; set; }

		public string Category { get; set; }

		public string Description { get; set; }

		public bool DisplayInMenu { get; set; }

		public string Id { get; set; }

		public bool IsSandbox => Id.StartsWith("LevelSandbox");

		public bool IsTraining => Id.StartsWith("Training");

		public bool Locked { get; set; }

		public string MapName { get; set; }

		public string ModName { get; set; }

		public string Name { get; set; }

		public string Prefab { get; set; }

		public List<string> RestrictedCategories { get; set; }

		public List<string> RestrictedDesignerParts { get; set; }

		public List<string> RestrictedModifiers { get; set; }

		public List<string> RestrictedPartIds { get; set; }

		public bool SkipDesigner { get; set; }

		public LevelInfo()
		{
			RestrictedPartIds = new List<string>();
			RestrictedModifiers = new List<string>();
			RestrictedDesignerParts = new List<string>();
			RestrictedCategories = new List<string>();
		}
	}
}
