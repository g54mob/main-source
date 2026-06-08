using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Insert Random Room")]
	public class InsertRandomRoom : LayoutModule
	{
		public RoomType Type;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			if (blueprint.Tiles.Count != 0)
			{
				List<LayoutPosition> list = blueprint.Tiles.Keys.OrderBy((LayoutPosition t) => t.x * 1000 + t.y).ToList();
				LayoutPosition pos = list[Random.Range(0, list.Count)];
				Room value = Room.New;
				value.Type = Type;
				blueprint[pos] = value;
			}
		}
	}
}
