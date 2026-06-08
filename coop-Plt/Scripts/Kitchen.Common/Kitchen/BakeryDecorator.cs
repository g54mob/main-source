using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class BakeryDecorator : Decorator
	{
		[UsedImplicitly]
		public class DecorationsConfiguration : IDecorationConfiguration
		{
			public List<Appliance> Ingredients = new List<Appliance>();

			public IDecorator Decorator => new BakeryDecorator();
		}

		public override bool Decorate(Room _)
		{
			if (!(Configuration is DecorationsConfiguration decorationsConfiguration))
			{
				return false;
			}
			Queue<GameDataObject> queue = new Queue<GameDataObject>(decorationsConfiguration.Ingredients);
			List<Vector3> used_tiles = new List<Vector3>(Decorations.Select((CLayoutAppliancePlacement d) => d.Position));
			foreach (Room item in Blueprint.Rooms())
			{
				switch (item.Type)
				{
				case RoomType.Unassigned:
				{
					HashSet<LayoutPosition> hashSet = Blueprint.TilesOfRoom(item);
					foreach (LayoutPosition item2 in hashSet)
					{
						if (Blueprint.HasFeature(item2, FeatureType.Hatch) && !Blueprint.HasFeature(item2, FeatureType.Door))
						{
							Decorations.Add(new CLayoutAppliancePlacement
							{
								Appliance = Profile.Counter.ID,
								Position = item2,
								Rotation = FindWallRotation(item2)
							});
						}
					}
					break;
				}
				case RoomType.Storage:
				{
					HashSet<LayoutPosition> hashSet = Blueprint.TilesOfRoom(item);
					LayoutPosition layoutPosition = next_tile(hashSet, hashSet.Where((LayoutPosition x) => !used_tiles.Contains(x)).ToList().Random());
					while (queue.Count > 0)
					{
						Decorations.Add(new CLayoutAppliancePlacement
						{
							Appliance = queue.Dequeue().ID,
							Position = layoutPosition,
							Rotation = FindWallRotation(layoutPosition)
						});
						used_tiles.Add(layoutPosition);
						layoutPosition = next_tile(hashSet, layoutPosition);
					}
					break;
				}
				}
			}
			return true;
			LayoutPosition next_tile(HashSet<LayoutPosition> room_tiles, LayoutPosition tile)
			{
				foreach (LayoutPosition item3 in Blueprint.AdjacentInRoom(tile).Concat(room_tiles))
				{
					if (Blueprint.IsTileAccessible(item3) && !Blueprint.HasFeature(item3) && Blueprint.IsTileFlatWall(item3) && !used_tiles.Contains(item3))
					{
						used_tiles.Add(item3);
						return item3;
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
