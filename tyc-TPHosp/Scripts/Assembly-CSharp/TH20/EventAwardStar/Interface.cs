namespace TH20.EventAwardStar
{
	public interface Interface : IGameEventCallback
	{
		void OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug);
	}
}
