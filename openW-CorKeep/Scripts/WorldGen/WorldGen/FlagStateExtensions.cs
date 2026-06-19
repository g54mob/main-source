using System;
using System.Runtime.CompilerServices;

namespace WorldGen
{
	public static class FlagStateExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool MatchesFlagState(this TileTypeMapping.FlagState state, bool flag)
		{
			return state switch
			{
				TileTypeMapping.FlagState.Any => true, 
				TileTypeMapping.FlagState.True => flag, 
				TileTypeMapping.FlagState.False => !flag, 
				_ => throw new ArgumentException(), 
			};
		}
	}
}
