using FixedTickInterpolation;
using Unity.Entities;
using Unity.Mathematics;

namespace PlacementIndicator
{
	public struct PlacementIndicatorInterpolatedValueCD : IFixedInterpolatedSmoothedData, IComponentData, IQueryTypeParameter
	{
		public float2 CollisionPosition;

		public float2 AimPosition;
	}
}
