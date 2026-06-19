using Unity.Entities;

namespace FixedTickInterpolation
{
	public struct LastRecordedPhysicsStepCD : IComponentData, IQueryTypeParameter
	{
		public int physicsTicks;
	}
}
