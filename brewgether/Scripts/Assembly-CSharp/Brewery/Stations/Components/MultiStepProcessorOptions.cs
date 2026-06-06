using System;

namespace Brewery.Stations.Components
{
	public sealed class MultiStepProcessorOptions<TStep> where TStep : struct, Enum
	{
		public string MetadataKey { get; set; }

		public Action<ProcessStepEventContext<TStep>> OnStepStarted { get; set; }

		public Action<ProcessStepEventContext<TStep>> OnStepCompleted { get; set; }

		public Action<ProcessStepEventContext<TStep>> OnAllStepsCompleted { get; set; }

		public Action<float> OnProgressUpdated { get; set; }
	}
}
