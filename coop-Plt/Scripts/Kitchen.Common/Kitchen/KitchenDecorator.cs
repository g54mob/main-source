using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class KitchenDecorator : Decorator
	{
		public override bool Decorate(Room room)
		{
			Queue<GameDataObject> queue = new Queue<GameDataObject>(Profile.RequiredAppliances);
			List<Vector3> used_tiles = new List<Vector3>(Decorations.Select((CLayoutAppliancePlacement d) => d.Position));
			HashSet<LayoutPosition> room_tiles = Blueprint.TilesOfRoom(room);
			foreach (LayoutPosition item in room_tiles)
			{
				if (Blueprint.HasFeature(item, FeatureType.Hatch))
				{
					Decorations.Add(new CLayoutAppliancePlacement
					{
						Appliance = Profile.Counter.ID,
						Position = item,
						Rotation = FindWallRotation(item)
					});
					used_tiles.Add(item);
				}
			}
			LayoutPosition layoutPosition = next_tile(room_tiles.Where((LayoutPosition x) => !used_tiles.Contains(x)).ToList().Random());
			while (queue.Count > 0)
			{
				Decorations.Add(new CLayoutAppliancePlacement
				{
					Appliance = queue.Dequeue().ID,
					Position = layoutPosition,
					Rotation = FindWallRotation(layoutPosition)
				});
				used_tiles.Add(layoutPosition);
				layoutPosition = next_tile(layoutPosition);
			}
			return true;
			LayoutPosition next_tile(LayoutPosition tile)
			{
				foreach (LayoutPosition item2 in Blueprint.AdjacentInRoom(tile).Concat(room_tiles))
				{
					if (Blueprint.IsTileAccessible(item2) && !Blueprint.HasFeature(item2) && Blueprint.IsTileFlatWall(item2) && !used_tiles.Contains(item2))
					{
						used_tiles.Add(item2);
						return item2;
					}
				}
				throw new LayoutFailureException("Not enough spaces to place kitchen equipment");
			}
		}

		private Quaternion FindWallRotation(LayoutPosition pos)
		{
			Room room = Blueprint[pos];
			foreach (LayoutPosition direction in LayoutHelpers.Directions)
			{
				LayoutPosition pos2 = direction + pos;
				if (Blueprint[pos2].ID != room.ID)
				{
					return Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y), Vector3.up);
				}
			}
			return Quaternion.identity;
		}
	}
}
