namespace TH20.EventPlayableHospital
{
	public class Action : GameEvent_Base<Interface>
	{
		public void InvokeSafe(LevelConfig level)
		{
			IterateCallbacks(delegate(Interface callback)
			{
				callback.OnHospitalBecamePlayableEvent(level);
			});
		}
	}
}
