using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct RefillWaterStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public Entity waterSourceEntity;

		[GhostField]
		public int tileset;

		[GhostField]
		public float3 pickupWorldPosition;

		[GhostField]
		public TickTimer refillWaterDuration;

		[GhostField]
		public TickTimer particleDelay;
	}
}
