using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Random Expand")]
	public class RandomExpand : LayoutModule
	{
		public int MinX;

		public int MinY;

		public int MaxX;

		public int MaxY;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			Bounds bounds = blueprint.GetBounds();
			bounds = blueprint.GetBounds();
			int num = Random.Range(MinX, MaxX + 1);
			int num2 = Random.Range(MinY, MaxY + 1);
			for (int i = 0; i < num; i++)
			{
				PerformSplit(blueprint, is_row: true, Random.Range((int)bounds.min.y, (int)bounds.max.y + i + 1));
			}
			for (int j = 0; j < num2; j++)
			{
				PerformSplit(blueprint, is_row: false, Random.Range((int)bounds.min.x, (int)bounds.max.x + j + 1));
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
