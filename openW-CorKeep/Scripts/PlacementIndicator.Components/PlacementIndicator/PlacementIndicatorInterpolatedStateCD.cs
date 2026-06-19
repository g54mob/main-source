using System.Runtime.CompilerServices;
using FixedTickInterpolation;
using Unity.Entities;
using Unity.Mathematics;

namespace PlacementIndicator
{
	public struct PlacementIndicatorInterpolatedStateCD : IFixedInterpolatedStateData<PlacementIndicatorCurrentStateCD, PlacementIndicatorInterpolatedValueCD>, IComponentData, IQueryTypeParameter
	{
		public float2 PreviousCollision;

		public float2 CurrentCollision;

		public float2 PreviousAim;

		public float2 CurrentAim;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Swap(PlacementIndicatorCurrentStateCD newState)
		{
			PreviousCollision = CurrentCollision;
			CurrentCollision = newState.collisionPosition.xz;
			PreviousAim = CurrentAim;
			CurrentAim = newState.aimPosition.xz;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Interpolate(ref PlacementIndicatorInterpolatedValueCD interpolatedData, float normalizedTimeAhead)
		{
			interpolatedData.CollisionPosition = math.lerp(PreviousCollision, CurrentCollision, normalizedTimeAhead);
			interpolatedData.AimPosition = math.lerp(PreviousAim, CurrentAim, normalizedTimeAhead);
		}
	}
}
