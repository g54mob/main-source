using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Pad With Room")]
	public class PadWithRoom : LayoutModule
	{
		public RoomType Type;

		public int Above;

		public int Left;

		public int Right;

		public int Below;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			Dictionary<LayoutPosition, Room> dictionary = new Dictionary<LayoutPosition, Room>();
			Bounds bounds = blueprint.GetBounds();
			bounds.Expand(0.1f);
			Room value = new Room(Type);
			for (int i = (int)bounds.min.x - Left; i <= (int)bounds.max.x + Right; i++)
			{
				for (int j = (int)bounds.min.y - Below; j <= (int)bounds.max.y + Above; j++)
				{
					if (bounds.Contains(new Vector3(i, j, 0f)))
					{
						dictionary[new LayoutPosition(i, j)] = blueprint[i, j];
					}
					else
					{
						dictionary[new LayoutPosition(i, j)] = value;
					}
				}
			}
			blueprint.Tiles = dictionary;
		}
	}
}
