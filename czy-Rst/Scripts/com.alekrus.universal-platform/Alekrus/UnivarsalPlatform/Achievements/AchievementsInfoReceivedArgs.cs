namespace Alekrus.UnivarsalPlatform.Achievements
{
	public class AchievementsInfoReceivedArgs : ResultArgs
	{
		public ILocalUserId UserId { get; }

		public AchievementsInfoReceivedArgs(ILocalUserId parUserId, IResult parResult)
			: base(parResult)
		{
			UserId = parUserId;
		}
	}
}
