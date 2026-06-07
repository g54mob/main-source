namespace MoreMountains.Tools
{
	public struct MMAchievementUnlockedEvent
	{
		public MMAchievement Achievement;

		private static MMAchievementUnlockedEvent e;

		public MMAchievementUnlockedEvent(MMAchievement newAchievement)
		{
			Achievement = newAchievement;
		}

		public static void Trigger(MMAchievement newAchievement)
		{
			e.Achievement = newAchievement;
			MMEventManager.TriggerEvent(e);
		}
	}
}
