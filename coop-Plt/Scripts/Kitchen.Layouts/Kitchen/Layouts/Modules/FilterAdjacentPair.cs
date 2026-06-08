using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Filters/Adjacent Pair")]
	public class FilterAdjacentPair : LayoutModule
	{
		public override void ActOn(LayoutBlueprint blueprint)
		{
			foreach (Feature f1 in blueprint.Features.OrderBy((Feature feature) => Random.value).ToList())
			{
				foreach (Feature f2 in blueprint.Features)
				{
					if (LayoutHelpers.Directions.Any((LayoutPosition d) => (f2.Tile1 == f1.Tile1 + d && f2.Tile2 == f1.Tile2 + d) || (f2.Tile2 == f1.Tile1 + d && f2.Tile1 == f1.Tile2 + d)))
					{
						blueprint.Features = new List<Feature> { f1, f2 };
						return;
					}
				}
			}
		}
	}
}
