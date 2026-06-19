using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;

public struct PartialRespawnArea : IComponentData, IQueryTypeParameter
{
	public SubMapLayer LowResShouldRespawnFlags;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int2 GetSampleIndex(int2 cellLocalPosition)
	{
		return math.clamp(cellLocalPosition >> 2, 0, 64);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void GetSampleRange(int2 cellLocalBasePosition, int2 size, out int2 startIndex, out int2 endIndex)
	{
		startIndex = GetSampleIndex(cellLocalBasePosition);
		endIndex = GetSampleIndex(cellLocalBasePosition + size);
	}
}
