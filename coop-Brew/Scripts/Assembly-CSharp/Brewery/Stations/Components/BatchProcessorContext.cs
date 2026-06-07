using Brewery.Stations.Components.Interfaces;

namespace Brewery.Stations.Components
{
	public readonly struct BatchProcessorContext
	{
		public IStationSlotProvider Slots { get; }

		public IStationStateProvider State { get; }

		public int TotalBatches { get; }

		public int BatchesRemaining { get; }

		public int BatchesCompleted { get; }

		public int ProducedThisTick { get; }

		public BatchProcessorContext(IStationSlotProvider slots, IStationStateProvider state, int totalBatches, int batchesRemaining, int batchesCompleted, int producedThisTick)
		{
			Slots = null;
			State = null;
			TotalBatches = 0;
			BatchesRemaining = 0;
			BatchesCompleted = 0;
			ProducedThisTick = 0;
		}
	}
}
