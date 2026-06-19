namespace TH20.EventUnlockHospital
{
	public interface Interface : IGameEventCallback
	{
		void OnHospitalUnlockedEvent(LevelConfig level);
	}
}
