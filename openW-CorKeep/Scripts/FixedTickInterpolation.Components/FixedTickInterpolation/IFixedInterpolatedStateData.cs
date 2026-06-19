using System.Runtime.CompilerServices;
using Unity.Entities;

namespace FixedTickInterpolation
{
	public interface IFixedInterpolatedStateData<T, D> : IComponentData, IQueryTypeParameter where T : struct, IComponentData where D : struct, IFixedInterpolatedSmoothedData
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		void Swap(T newState);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		void Interpolate(ref D interpolatedData, float normalizedTimeAhead);
	}
}
