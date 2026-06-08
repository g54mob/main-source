using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Find All Connections")]
	public class FindAllFeatures : LayoutModule
	{
		public FeatureType Feature;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			foreach (Feature item in new List<Feature>(blueprint.Tiles.SelectMany((KeyValuePair<LayoutPosition, Room> t) => from d in LayoutHelpers.Directions
				select new LayoutPosition(d.x + t.Key.x, d.y + t.Key.y) into d
				where blueprint[d].ID != t.Value.ID
				select new Feature(t.Key, d, FeatureType.Generic))).OrderBy((Feature t) => t.Tile1.x * 1000 + t.Tile2.y))
			{
				blueprint.Features.Add(new Feature(item.Tile1, item.Tile2, Feature));
			}
		}
	}
}
