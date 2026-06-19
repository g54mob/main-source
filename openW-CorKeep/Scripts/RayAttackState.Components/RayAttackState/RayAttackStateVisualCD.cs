using Unity.Entities;
using Unity.Mathematics;

namespace RayAttackState
{
	public struct RayAttackStateVisualCD : IComponentData, IQueryTypeParameter
	{
		public bool isEnabled;

		public bool isBeamHittingSomething;

		public float3 fromPos;

		public float3 toPos;
	}
}
