using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Split Rooms")]
	public class SplitRooms : LayoutModule
	{
		public int UniformX;

		public int UniformY;

		public int RandomX;

		public int RandomY;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			Bounds bounds = blueprint.GetBounds();
			int num = (int)bounds.max.x;
			while ((float)num >= bounds.min.x)
			{
				for (int i = 0; i < UniformX; i++)
				{
					PerformSplit(blueprint, is_row: false, num);
				}
				num--;
			}
			int num2 = (int)bounds.max.y;
			while ((float)num2 >= bounds.min.y)
			{
				for (int j = 0; j < UniformY; j++)
				{
					PerformSplit(blueprint, is_row: true, num2);
				}
				num2--;
			}
			bounds = blueprint.GetBounds();
			for (int k = 0; k < RandomX; k++)
			{
				PerformSplit(blueprint, is_row: true, Random.Range((int)bounds.min.y, (int)bounds.max.y + k + 1));
			}
			for (int l = 0; l < RandomY; l++)
			{
				PerformSplit(blueprint, is_row: false, Random.Range((int)bounds.min.x, (int)bounds.max.x + l + 1));
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
