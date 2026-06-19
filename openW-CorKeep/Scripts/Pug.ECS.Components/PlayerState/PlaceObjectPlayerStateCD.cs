using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct PlaceObjectPlayerStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public TickTimer placeDuration;

		[GhostField]
		public float3 positionToPlaceAt;
	}
}
