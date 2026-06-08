using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Mirror")]
	public class Mirror : LayoutModule
	{
		public bool IsVertical;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			int max = (IsVertical ? ((int)blueprint.GetBounds().max.y) : ((int)blueprint.GetBounds().max.x));
			foreach (KeyValuePair<LayoutPosition, Room> item in blueprint.Tiles.ToList())
			{
				blueprint[mirror(item.Key)] = item.Value;
			}
			for (int num = blueprint.Features.Count - 1; num >= 0; num--)
			{
				Feature feature = blueprint.Features[num];
				if (feature.Type != FeatureType.FrontDoor)
				{
					Feature feature2 = new Feature(feature);
					feature2.Tile1 = mirror(feature2.Tile1);
					feature2.Tile2 = mirror(feature2.Tile2);
					blueprint.Features.Add(feature2);
				}
			}
			LayoutPosition mirror(LayoutPosition p)
			{
				if (!IsVertical)
				{
					return new LayoutPosition(max + (max + 1 - p.x), p.y);
				}
				return new LayoutPosition(p.x, max + (max + 1 - p.y));
			}
		}
	}
}
