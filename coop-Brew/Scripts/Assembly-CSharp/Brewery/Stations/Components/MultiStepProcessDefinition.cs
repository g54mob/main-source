using System;
using System.Collections.Generic;

namespace Brewery.Stations.Components
{
	public sealed class MultiStepProcessDefinition<TStep> where TStep : struct, Enum
	{
		private readonly List<StepDefinition<TStep>> steps;

		public IReadOnlyList<StepDefinition<TStep>> Steps => null;

		public MultiStepProcessDefinition<TStep> AddStep(TStep step, float durationSeconds, params OptionalMaterialDefinition[] optionalMaterials)
		{
			return null;
		}

		public bool TryGetStep(TStep step, out StepDefinition<TStep> definition)
		{
			definition = default(StepDefinition<TStep>);
			return false;
		}

		public bool TryGetNextStep(TStep current, out StepDefinition<TStep> definition)
		{
			definition = default(StepDefinition<TStep>);
			return false;
		}
	}
}
