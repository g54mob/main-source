using System;
using System.Runtime.CompilerServices;

namespace WorldGen
{
	public static class ResourceIndexExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool MatchesResourceIndex(this TileTypeMapping.ResourceIndex index, int resourceIndex)
		{
			return index switch
			{
				TileTypeMapping.ResourceIndex.Any => true, 
				TileTypeMapping.ResourceIndex.None => resourceIndex == 0, 
				TileTypeMapping.ResourceIndex.Resource1 => resourceIndex == 1, 
				TileTypeMapping.ResourceIndex.Resource2 => resourceIndex == 2, 
				TileTypeMapping.ResourceIndex.Resource3 => resourceIndex == 3, 
				TileTypeMapping.ResourceIndex.Resource4 => resourceIndex == 4, 
				TileTypeMapping.ResourceIndex.Resource5 => resourceIndex == 5, 
				_ => throw new ArgumentException(), 
			};
		}
	}
}
