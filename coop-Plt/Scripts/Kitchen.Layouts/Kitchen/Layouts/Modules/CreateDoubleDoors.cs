using System.Collections.Generic;
using Kitchen.Layouts.Features;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Create Double Doors")]
	public class CreateDoubleDoors : LayoutModule
	{
		public int OffsetY;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			if (blueprint.Tiles.Count == 0)
			{
				return;
			}
			foreach (Feature feature in blueprint.Features)
			{
				if (feature.Type != FeatureType.Door || feature.Tile1.y != OffsetY)
				{
					continue;
				}
				foreach (Feature feature2 in blueprint.Features)
				{
					if (((feature.Tile1.x == feature2.Tile1.x && feature.Tile2.x == feature2.Tile2.x) || (feature.Tile2.x == feature2.Tile1.x && feature.Tile1.x == feature2.Tile2.x)) && Mathf.Abs(feature.Tile1.y - feature2.Tile2.y) <= 1)
					{
						blueprint.Features = new List<Feature>
						{
							new Feature(feature.Tile1, feature.Tile2, FeatureType.Door),
							new Feature(feature2.Tile1, feature2.Tile2, FeatureType.DoorReversed)
						};
						return;
					}
				}
			}
		}
	}
}
