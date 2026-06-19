namespace TH20.EventAwardStar
{
	public class Action : GameEvent_Base<Interface>
	{
		public void InvokeSafe(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			IterateCallbacks(delegate(Interface callback)
			{
				callback.OnStarAwardedEvent(starIndex, levelConfig, debug);
			});
		}
	}
}
