using Unity.Entities;
using Unity.Mathematics;

namespace PlacementIndicator
{
	public struct PlacementIndicatorCurrentStateCD : IComponentData, IQueryTypeParameter
	{
		public float3 collisionPosition;

		public float3 aimPosition;
	}
}
