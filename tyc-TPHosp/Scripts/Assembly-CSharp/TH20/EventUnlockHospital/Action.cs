namespace TH20.EventUnlockHospital
{
	public class Action : GameEvent_Base<Interface>
	{
		public void InvokeSafe(LevelConfig level)
		{
			IterateCallbacks(delegate(Interface callback)
			{
				callback.OnHospitalUnlockedEvent(level);
			});
		}
	}
}
