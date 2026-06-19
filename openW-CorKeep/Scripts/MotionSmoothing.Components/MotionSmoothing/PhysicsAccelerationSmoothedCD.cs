using Unity.Entities;
using Unity.Mathematics;

namespace MotionSmoothing
{
	public struct PhysicsAccelerationSmoothedCD : IComponentData, IQueryTypeParameter
	{
		public float3 Value;
	}
}
