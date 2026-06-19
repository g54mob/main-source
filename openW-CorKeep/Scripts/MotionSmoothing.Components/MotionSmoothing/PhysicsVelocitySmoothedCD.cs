using Unity.Entities;
using Unity.Mathematics;

namespace MotionSmoothing
{
	public struct PhysicsVelocitySmoothedCD : IComponentData, IQueryTypeParameter
	{
		public float3 Value;
	}
}
