using Unity.Entities;

namespace PredictionSmoothing
{
	public struct LastRecordedPhysicsStepsForPredictionSmoothingCD : IComponentData, IQueryTypeParameter
	{
		public int physicsTicks;
	}
}
