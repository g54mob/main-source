using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Recentre Layout")]
	public class RecentreLayout : LayoutModule
	{
		public override void ActOn(LayoutBlueprint blueprint)
		{
			Vector2 min;
			Vector2 new_min;
			if (blueprint.Tiles.Count != 0)
			{
				Dictionary<LayoutPosition, Room> tiles = blueprint.Tiles;
				min = new Vector2(tiles.Select((KeyValuePair<LayoutPosition, Room> r) => r.Key.x).Min(), tiles.Select((KeyValuePair<LayoutPosition, Room> r) => r.Key.y).Min());
				Vector2 vector = new Vector2(tiles.Select((KeyValuePair<LayoutPosition, Room> r) => r.Key.x).Max(), tiles.Select((KeyValuePair<LayoutPosition, Room> r) => r.Key.y).Max());
				new_min = -(vector - min) / 2f;
				new_min = new Vector2(Mathf.FloorToInt(new_min.x), Mathf.FloorToInt(new_min.y));
				blueprint.Tiles = tiles.ToDictionary((KeyValuePair<LayoutPosition, Room> r) => translate(r.Key), (KeyValuePair<LayoutPosition, Room> r) => r.Value);
				blueprint.Features = blueprint.Features.Select((Feature f) => new Feature(translate(f.Tile1), translate(f.Tile2), f.Type)).ToList();
			}
			LayoutPosition translate(Vector2 input)
			{
				return input - min + new_min;
			}
		}
	}
}
