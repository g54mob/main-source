namespace MoreMountains.Tools
{
	public struct MMAchievementChangedEvent
	{
		public MMAchievement Achievement;

		private static MMAchievementChangedEvent e;

		public MMAchievementChangedEvent(MMAchievement newAchievement)
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
