namespace Alekrus.UnivarsalPlatform.Stats
{
	public class StatsStorededArgs : ResultArgs
	{
		public ILocalUserId UserId { get; }

		public StatsStorededArgs(ILocalUserId parUserId, IResult parResult)
			: base(parResult)
		{
			UserId = parUserId;
		}
	}
}
