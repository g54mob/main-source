using System;
using System.Collections.Immutable;
using Timberborn.BlockSystem;

namespace Timberborn.ModelHiding
{
	internal static class BlockObjectExtensions
	{
		public static bool IsFloor(this BlockObject blockObject)
		{
			ImmutableArray<Block>.Enumerator enumerator = blockObject.Blocks.GetAllBlocks().GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Occupation != BlockOccupations.Floor)
				{
					return false;
				}
			}
			return true;
		}

		public static int GetBaseLevel(this BlockObject blockObject)
		{
			return Math.Max(0, blockObject.CoordinatesAtBaseZ.z - (blockObject.IsFloor() ? 1 : 0));
		}

		public static int GetTopLevel(this BlockObject blockObject)
		{
			return blockObject.Coordinates.z + blockObject.Blocks.Size.z;
		}
	}
}
