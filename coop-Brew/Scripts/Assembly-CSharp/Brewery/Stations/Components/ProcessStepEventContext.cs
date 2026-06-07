using System;
using Brewery.Stations.Components.Interfaces;
using Brewery.Systems.Processing;

namespace Brewery.Stations.Components
{
	public readonly struct ProcessStepEventContext<TStep> where TStep : struct, Enum
	{
		public TStep Step { get; }

		public IStationSlotProvider Slots { get; }

		public ProcessMetadata<TStep> Metadata { get; }

		public ProcessStepEventContext(TStep step, IStationSlotProvider slots, ProcessMetadata<TStep> metadata)
		{
			Step = default(TStep);
			Slots = null;
			Metadata = default(ProcessMetadata<TStep>);
		}
	}
}
