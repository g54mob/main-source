using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Filters/Opposite Pair")]
	public class FilterOppositePair : LayoutModule
	{
		public override void ActOn(LayoutBlueprint blueprint)
		{
			foreach (Feature item in blueprint.Features.OrderBy((Feature f) => Random.value).ToList())
			{
				foreach (Feature feature in blueprint.Features)
				{
					int iD = blueprint[item.Tile1.x, item.Tile1.y].ID;
					int iD2 = blueprint[item.Tile2.x, item.Tile2.y].ID;
					int iD3 = blueprint[feature.Tile1.x, feature.Tile1.y].ID;
					int iD4 = blueprint[feature.Tile2.x, feature.Tile2.y].ID;
					if (iD != Room.Null.ID && iD2 != Room.Null.ID && iD3 != Room.Null.ID && iD4 != Room.Null.ID && (iD != iD3 || iD2 != iD4) && (iD == iD3 || iD == iD4 || iD2 == iD3 || iD2 == iD4) && item.Tile2.x - item.Tile1.x == feature.Tile2.x - feature.Tile1.x && item.Tile2.y - item.Tile1.y == feature.Tile2.y - feature.Tile1.y && (item.Tile1.x == feature.Tile1.x || item.Tile1.y == feature.Tile1.y))
					{
						blueprint.Features = new List<Feature> { item, feature };
						return;
					}
				}
			}
		}
	}
}
