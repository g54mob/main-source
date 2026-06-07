using Brewery.Stations.Components.Interfaces;

namespace Brewery.Stations.Components
{
	public sealed class BatchProcessor<TConfig> where TConfig : IBatchProcessorConfig
	{
		private readonly TConfig config;

		private readonly IStationStateProvider stateProvider;

		private readonly IStationSlotProvider slotProvider;

		private readonly BatchProcessorOptions options;

		private float timer;

		private float syncTimer;

		private int pendingBatches;

		private int totalBatches;

		private bool isProcessing;

		public bool IsProcessing => false;

		public int PendingBatches => 0;

		public int TotalBatches => 0;

		public BatchProcessor(TConfig config, IStationStateProvider stateProvider, IStationSlotProvider slotProvider, BatchProcessorOptions options = null)
		{
		}

		public bool TryStart()
		{
			return false;
		}

		public void Tick()
		{
		}

		public void Cancel()
		{
		}

		private void CompleteSingleBatch()
		{
		}

		private int CalculateAvailableBatches()
		{
			return 0;
		}

		private bool HasOutputCapacity(int batchesToProduce)
		{
			return false;
		}

		private void ConsumeInputs()
		{
		}

		private void ApplyOutput()
		{
		}
	}
}
