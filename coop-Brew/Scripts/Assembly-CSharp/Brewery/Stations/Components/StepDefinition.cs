using System;

namespace Brewery.Stations.Components
{
	public readonly struct StepDefinition<TStep> where TStep : struct, Enum
	{
		public TStep Step { get; }

		public float DurationSeconds { get; }

		public OptionalMaterialDefinition[] OptionalMaterials { get; }

		public StepDefinition(TStep step, float durationSeconds, OptionalMaterialDefinition[] optionalMaterials)
		{
			Step = default(TStep);
			DurationSeconds = 0f;
			OptionalMaterials = null;
		}
	}
}
