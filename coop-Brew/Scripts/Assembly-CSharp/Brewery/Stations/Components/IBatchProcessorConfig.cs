using System.Collections.Generic;

namespace Brewery.Stations.Components
{
	public interface IBatchProcessorConfig
	{
		float BatchDurationSeconds { get; }

		int OutputPerBatch { get; }

		int OutputCapacity { get; }

		string OutputItemId { get; }

		IReadOnlyList<BatchInputRequirement> Inputs { get; }
	}
}
