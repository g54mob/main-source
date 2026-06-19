using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct BoatRidingStateCD : IComponentData, IQueryTypeParameter
	{
		public const float InertiaFactor = 0.87f;

		[GhostField]
		public float3 previousVelocity;
	}
}
