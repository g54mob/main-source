using System.Runtime.CompilerServices;
using Unity.Mathematics;

internal static class ObjectLookupUtility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int2 ToSubAreaCellIndex(int2 tilePosition)
	{
		return (tilePosition & ~(ObjectLookupConstants.SubAreaCellSize - 1)) >> ObjectLookupConstants.SubAreaCellSizeLog2;
	}
}
