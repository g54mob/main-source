using Unity.Entities;
using Unity.Mathematics;

namespace MotionSmoothing
{
	public struct PhysicsVelocityInterpolatedValuesCD : IComponentData, IQueryTypeParameter
	{
		public float3 Previous;

		public float3 Current;
	}
}
