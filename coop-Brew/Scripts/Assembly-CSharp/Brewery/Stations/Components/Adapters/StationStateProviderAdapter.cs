using System;
using Brewery.Stations.Components.Interfaces;

namespace Brewery.Stations.Components.Adapters
{
	public sealed class StationStateProviderAdapter : IStationStateProvider
	{
		private readonly BaseBreweryStation station;

		private readonly Func<float> deltaTimeProvider;

		public StationState CurrentState => default(StationState);

		public ulong StationId => 0uL;

		public float CurrentProgress => 0f;

		public float DeltaTime => 0f;

		public bool IsServer => false;

		public StationStateProviderAdapter(BaseBreweryStation station, Func<float> deltaTimeProvider = null)
		{
		}

		public void SetState(StationState state)
		{
		}

		public void SetProgress(float normalizedProgress)
		{
		}
	}
}
