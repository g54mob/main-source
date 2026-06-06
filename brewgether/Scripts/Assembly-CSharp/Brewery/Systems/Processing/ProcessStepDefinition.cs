using System;

namespace Brewery.Systems.Processing
{
	public readonly struct ProcessStepDefinition<TStep> where TStep : struct, Enum
	{
		public TStep Step { get; }

		public float DurationSeconds { get; }

		public ProcessStepDefinition(TStep step, float durationSeconds)
		{
			Step = default(TStep);
			DurationSeconds = 0f;
		}
	}
}
