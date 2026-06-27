namespace Alekrus.UnivarsalPlatform.Stats
{
	public interface IStats : IInitializable, ISubInterface<IMain>
	{
		event StatsReceivedEventHandler StatsReceived;

		event StatsStorededEventHandler StatsStoreded;

		float GetStatValue(ILocalUserId parUserId, StatId parStatId);

		bool RequestStats(ILocalUserId parUserId);

		bool AddStatValue(ILocalUserId parUserId, StatId parStatId, float parDelta);

		bool SetStatValue(ILocalUserId parUserId, StatId parStatId, float parValue);
	}
}
