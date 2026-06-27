namespace Alekrus.UnivarsalPlatform.Stats
{
	public class StatsReceivedArgs : ResultArgs
	{
		public ILocalUserId UserId { get; }

		public StatsReceivedArgs(ILocalUserId parUserId, IResult parResult)
			: base(parResult)
		{
			UserId = parUserId;
		}
	}
}
