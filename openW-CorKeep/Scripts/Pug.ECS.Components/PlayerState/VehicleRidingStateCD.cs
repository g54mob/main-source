using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct VehicleRidingStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public float3 previousVelocity;

		[GhostField]
		public TickTimer reorientationDelay;

		[GhostField]
		public Direction previousDirection;

		[GhostField]
		public float3 prevPosition;

		[GhostField]
		public float3 drivingDirection;

		[GhostField]
		public float speed;

		[GhostField]
		public TickTimer attackDestructiblesTimer;

		public BlobAssetReference<BlobCurve> vehicleDriftingAmountCurve;

		public Entity vehicleEntityLocal;
	}
}
