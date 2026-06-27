namespace Alekrus.UnivarsalPlatform.Achievements
{
	public class AchievementsUnlockedArgs : ResultArgs
	{
		public ILocalUserId UserId { get; }

		public AchievementId AchievementId { get; }

		public AchievementsUnlockedArgs(ILocalUserId parUserId, AchievementId parAchievementId, IResult parResult)
			: base(parResult)
		{
			UserId = parUserId;
			AchievementId = parAchievementId;
		}
	}
}
