using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct FlattenStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public float3 positionToPlaceAt;

		[GhostField]
		public TickTimer placeDuration;
	}
}
