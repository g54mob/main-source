using System.Collections.Generic;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Split Line")]
	public class SplitLine : LayoutModule
	{
		public int Position;

		public int Count;

		public bool IsRow;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			for (int i = 0; i <= Count; i++)
			{
				PerformSplit(blueprint, IsRow, Position);
			}
		}

		private void PerformSplit(LayoutBlueprint blueprint, bool is_row, int index)
		{
			Dictionary<LayoutPosition, Room> dictionary = new Dictionary<LayoutPosition, Room>();
			foreach (KeyValuePair<LayoutPosition, Room> tile in blueprint.Tiles)
			{
				LayoutPosition key = remap(tile.Key);
				dictionary[key] = tile.Value;
				if (is_row && tile.Key.y == index)
				{
					dictionary[tile.Key] = tile.Value;
				}
				if (!is_row && tile.Key.x == index)
				{
					dictionary[tile.Key] = tile.Value;
				}
			}
			blueprint.Tiles = dictionary;
			LayoutPosition remap(LayoutPosition prev)
			{
				if (is_row && prev.y >= index)
				{
					return new LayoutPosition(prev.x, prev.y + 1);
				}
				if (!is_row && prev.x >= index)
				{
					return new LayoutPosition(prev.x + 1, prev.y);
				}
				return prev;
			}
		}
	}
}
