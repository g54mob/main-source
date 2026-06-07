using System;
using Brewery.Stations.Components.Interfaces;
using Brewery.Systems.Processing;

namespace Brewery.Stations.Components
{
	public sealed class MultiStepProcessor<TStep> where TStep : struct, Enum
	{
		private readonly MultiStepProcessDefinition<TStep> definition;

		private readonly MultiStepProcessorOptions<TStep> options;

		private readonly IStationStateProvider stateProvider;

		private readonly IStationSlotProvider slotProvider;

		private readonly IMetadataProvider metadataProvider;

		private ProcessMetadata<TStep> metadata;

		private bool metadataLoaded;

		public ProcessMetadata<TStep> Metadata => default(ProcessMetadata<TStep>);

		public MultiStepProcessor(MultiStepProcessDefinition<TStep> definition, MultiStepProcessorOptions<TStep> options, IStationStateProvider stateProvider, IStationSlotProvider slotProvider, IMetadataProvider metadataProvider)
		{
		}

		public void Tick()
		{
		}

		public void ApplyOptionalMaterial(string key)
		{
		}

		public bool IsStepComplete(TStep step)
		{
			return false;
		}

		private void CompleteCurrentStep(StepDefinition<TStep> stepDefinition)
		{
		}

		private bool IsComplete(TStep step)
		{
			return false;
		}

		private void EnsureMetadata()
		{
		}

		private void SaveMetadata()
		{
		}
	}
}
