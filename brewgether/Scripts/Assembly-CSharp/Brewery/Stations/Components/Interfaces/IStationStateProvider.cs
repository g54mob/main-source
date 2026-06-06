namespace Brewery.Stations.Components.Interfaces
{
	public interface IStationStateProvider
	{
		StationState CurrentState { get; }

		ulong StationId { get; }

		float CurrentProgress { get; }

		float DeltaTime { get; }

		bool IsServer { get; }

		void SetState(StationState state);

		void SetProgress(float normalizedProgress);
	}
}
