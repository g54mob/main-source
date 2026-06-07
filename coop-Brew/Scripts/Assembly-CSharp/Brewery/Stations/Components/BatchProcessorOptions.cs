using System;
using Brewery.Stations.Components.Interfaces;

namespace Brewery.Stations.Components
{
	public sealed class BatchProcessorOptions
	{
		public float SyncIntervalSeconds { get; set; }

		public Action<BatchProcessorContext> OnBatchStarted { get; set; }

		public Action<BatchProcessorContext> OnBatchCompleted { get; set; }

		public Action<BatchProcessorContext> OnAllBatchesCompleted { get; set; }

		public Action<float> OnProgressSynced { get; set; }

		public Func<IStationSlotProvider, int, bool> CanAcceptOutput { get; set; }
	}
}
