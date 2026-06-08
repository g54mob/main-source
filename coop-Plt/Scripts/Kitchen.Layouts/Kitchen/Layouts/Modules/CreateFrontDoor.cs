using System;
using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Create Front Door")]
	public class CreateFrontDoor : LayoutModule
	{
		public RoomType Type;

		public bool ForceFirstHalf;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			if (blueprint.Tiles.Count != 0)
			{
				Bounds bounds = blueprint.GetBounds();
				float min_y = bounds.min.y;
				List<KeyValuePair<LayoutPosition, Room>> list = blueprint.Tiles.Where((KeyValuePair<LayoutPosition, Room> t) => Math.Abs((float)t.Key.y - min_y) < 0.05f && t.Value.Type == Type && (!ForceFirstHalf || (float)t.Key.x < bounds.center.x)).ToList();
				if (!list.Any())
				{
					throw new ModuleException("No suitable front door");
				}
				LayoutPosition key = list[UnityEngine.Random.Range(0, list.Count)].Key;
				LayoutPosition tile = new LayoutPosition(key.x, key.y - 1);
				blueprint.Features.Add(new Feature(key, tile, FeatureType.FrontDoor));
			}
		}
	}
}
