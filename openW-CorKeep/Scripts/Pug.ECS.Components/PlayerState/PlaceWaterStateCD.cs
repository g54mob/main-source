using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct PlaceWaterStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public int tileset;

		[GhostField]
		public TickTimer placeWaterDuration;

		[GhostField]
		public TickTimer particleDelay;

		[GhostField]
		public int3 bestPositionToPlaceAt;
	}
}
