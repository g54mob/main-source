using System.Collections.Generic;
using Kitchen.Layouts;
using Kitchen.Layouts.Features;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public static class LayoutExtensions
	{
		public static void FromEntity(this LayoutBlueprint bp, EntityManager em, Entity ent)
		{
			bp.Tiles.Clear();
			bp.Features.Clear();
			if (em.HasComponent<CLayoutRoomTile>(ent))
			{
				foreach (CLayoutRoomTile item in em.GetBuffer<CLayoutRoomTile>(ent))
				{
					Room value = new Room
					{
						ID = item.RoomID,
						Type = item.Type
					};
					bp.Tiles.Add(item.Position, value);
				}
			}
			if (em.HasComponent<CLayoutFeature>(ent))
			{
				foreach (CLayoutFeature item2 in em.GetBuffer<CLayoutFeature>(ent))
				{
					bp.Features.Add(new Feature(item2.Tile1, item2.Tile2, item2.Type));
				}
			}
			bp.ID = ent.Index * 6997 + ent.Version;
		}

		public static void ToEntity(this LayoutBlueprint bp, EntityManager em, Entity ent)
		{
			DynamicBuffer<CLayoutRoomTile> buffer = em.GetBuffer<CLayoutRoomTile>(ent);
			foreach (KeyValuePair<LayoutPosition, Room> tile in bp.Tiles)
			{
				CLayoutRoomTile elem = new CLayoutRoomTile
				{
					Position = tile.Key,
					Type = tile.Value.Type,
					RoomID = tile.Value.ID,
					HasFeature = bp.HasFeature(tile.Key),
					Reachability = bp.GetReachability(tile.Key.x, tile.Key.y)
				};
				buffer.Add(elem);
			}
			em.AddComponentData(ent, new CBounds
			{
				Bounds = bp.GetWorldBounds()
			});
			em.AddComponent<CFrontDoorMarker>(ent);
			em.AddComponent<CRoadMarker>(ent);
			DynamicBuffer<CLayoutFeature> buffer2 = em.GetBuffer<CLayoutFeature>(ent);
			foreach (Feature feature in bp.Features)
			{
				buffer2.Add(new CLayoutFeature
				{
					Tile1 = feature.Tile1,
					Tile2 = feature.Tile2,
					Type = feature.Type
				});
			}
			Vector3 frontDoor = bp.GetFrontDoor();
			em.SetComponentData(ent, new CFrontDoorMarker
			{
				Location = frontDoor
			});
			frontDoor.z -= 2f;
			em.SetComponentData(ent, new CRoadMarker
			{
				Location = frontDoor
			});
		}

		private static bool CanDirectReach(this LayoutBlueprint bp, LayoutPosition a, LayoutPosition b)
		{
			if (!bp.Tiles.TryGetValue(a, out var value))
			{
				return false;
			}
			if (!bp.Tiles.TryGetValue(b, out var value2))
			{
				return false;
			}
			if (value.ID != value2.ID)
			{
				return bp.HasReachingFeature(a, b);
			}
			return true;
		}

		private static Reachability GetReachability(this LayoutBlueprint bp, int x, int y)
		{
			Reachability result = new Reachability { [0, 0] = true };
			LayoutPosition layoutPosition = new LayoutPosition(x, y);
			if (!bp.Tiles.TryGetValue(layoutPosition, out var _))
			{
				return result;
			}
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if ((i != 0 || j != 0) && (i == 0 || j == 0))
					{
						LayoutPosition b = new LayoutPosition(x + i, y + j);
						result[i, j] = bp.CanDirectReach(layoutPosition, b);
					}
				}
			}
			for (int k = -1; k <= 1; k++)
			{
				for (int l = -1; l <= 1; l++)
				{
					if (k == 0 || l == 0)
					{
						continue;
					}
					LayoutPosition a = new LayoutPosition(x + k, y + l);
					for (int m = 0; m <= 1; m++)
					{
						int num = m * k;
						int num2 = (1 - m) * l;
						LayoutPosition b2 = new LayoutPosition(x + num, y + num2);
						if (result[num, num2])
						{
							result[k, l] |= bp.CanDirectReach(a, b2);
						}
					}
				}
			}
			for (int n = -2; n <= 2; n++)
			{
				for (int num3 = -2; num3 <= 2; num3++)
				{
					if ((n >= 2 || n <= -2 || num3 >= 2 || num3 <= -2) && ((n != 2 && n != -2) || (num3 != 2 && num3 != -2)))
					{
						LayoutPosition a2 = new LayoutPosition(x + n, y + num3);
						LayoutPosition b3 = new LayoutPosition(x + Mathf.Clamp(n, -1, 1), y + Mathf.Clamp(num3, -1, 1));
						result[n, num3] |= result[Mathf.Clamp(n, -1, 1), Mathf.Clamp(num3, -1, 1)] && bp.CanDirectReach(a2, b3);
					}
				}
			}
			return result;
		}

		public static Vector3 GetFrontDoor(this LayoutBlueprint bp)
		{
			foreach (Feature feature in bp.Features)
			{
				if (feature.Type == FeatureType.FrontDoor)
				{
					Vector3 result = feature.Tile1;
					result.x = Mathf.Min(feature.Tile1.x, feature.Tile2.x);
					result.z = Mathf.Min(feature.Tile1.y, feature.Tile2.y) + 1;
					return result;
				}
			}
			return default(Vector3);
		}
	}
}
