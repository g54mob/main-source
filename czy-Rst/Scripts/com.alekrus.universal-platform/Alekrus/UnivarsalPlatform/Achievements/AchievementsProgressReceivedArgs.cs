namespace Alekrus.UnivarsalPlatform.Achievements
{
	public class AchievementsProgressReceivedArgs : ResultArgs
	{
		public ILocalUserId UserId { get; }

		public AchievementsProgressReceivedArgs(ILocalUserId parUserId, IResult parResult)
			: base(parResult)
		{
			UserId = parUserId;
		}
	}
}
