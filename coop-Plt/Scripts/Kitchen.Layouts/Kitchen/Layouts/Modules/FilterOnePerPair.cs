using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Filters/One Per Room Pair")]
	public class FilterOnePerPair : LayoutModule
	{
		public override void ActOn(LayoutBlueprint blueprint)
		{
			List<(int, int)> pairs = blueprint.Rooms().SelectMany((Room r) => from room in blueprint.Rooms()
				where r.ID < room.ID
				select (r.ID, room.ID)).ToList();
			List<Feature> list = blueprint.Features.OrderBy((Feature r) => Random.value).ToList();
			list.RemoveAll(delegate(Feature x)
			{
				(int, int) item = (Mathf.Min(blueprint[x.Tile1].ID, blueprint[x.Tile2].ID), Mathf.Max(blueprint[x.Tile1].ID, blueprint[x.Tile2].ID));
				if (pairs.Contains(item))
				{
					pairs.Remove(item);
					return false;
				}
				return true;
			});
			blueprint.Features = list;
		}
	}
}
