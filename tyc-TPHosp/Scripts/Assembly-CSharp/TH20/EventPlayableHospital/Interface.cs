namespace TH20.EventPlayableHospital
{
	public interface Interface : IGameEventCallback
	{
		void OnHospitalBecamePlayableEvent(LevelConfig level);
	}
}
