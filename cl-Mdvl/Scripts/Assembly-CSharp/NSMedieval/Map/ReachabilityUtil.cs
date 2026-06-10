using System;
using System.Collections.Generic;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.Map
{
	public static class ReachabilityUtil
	{
		public static readonly Dictionary<WorldDirection, Vec3Int> DirectionToVector = new Dictionary<WorldDirection, Vec3Int>
		{
			{
				WorldDirection.N,
				new Vec3Int(0, 0, 1)
			},
			{
				WorldDirection.NE,
				new Vec3Int(1, 0, 1)
			},
			{
				WorldDirection.E,
				new Vec3Int(1, 0, 0)
			},
			{
				WorldDirection.SE,
				new Vec3Int(1, 0, -1)
			},
			{
				WorldDirection.S,
				new Vec3Int(0, 0, -1)
			},
			{
				WorldDirection.SW,
				new Vec3Int(-1, 0, -1)
			},
			{
				WorldDirection.W,
				new Vec3Int(-1, 0, 0)
			},
			{
				WorldDirection.NW,
				new Vec3Int(-1, 0, 1)
			},
			{
				WorldDirection.C,
				new Vec3Int(0, 0, 0)
			},
			{
				WorldDirection.UN,
				new Vec3Int(0, 1, 1)
			},
			{
				WorldDirection.UNE,
				new Vec3Int(1, 1, 1)
			},
			{
				WorldDirection.UE,
				new Vec3Int(1, 1, 0)
			},
			{
				WorldDirection.USE,
				new Vec3Int(1, 1, -1)
			},
			{
				WorldDirection.US,
				new Vec3Int(0, 1, -1)
			},
			{
				WorldDirection.USW,
				new Vec3Int(-1, 1, -1)
			},
			{
				WorldDirection.UW,
				new Vec3Int(-1, 1, 0)
			},
			{
				WorldDirection.UNW,
				new Vec3Int(-1, 1, 1)
			},
			{
				WorldDirection.UC,
				new Vec3Int(0, 1, 0)
			},
			{
				WorldDirection.DN,
				new Vec3Int(0, -1, 1)
			},
			{
				WorldDirection.DNE,
				new Vec3Int(1, -1, 1)
			},
			{
				WorldDirection.DE,
				new Vec3Int(1, -1, 0)
			},
			{
				WorldDirection.DSE,
				new Vec3Int(1, -1, -1)
			},
			{
				WorldDirection.DS,
				new Vec3Int(0, -1, -1)
			},
			{
				WorldDirection.DSW,
				new Vec3Int(-1, -1, -1)
			},
			{
				WorldDirection.DW,
				new Vec3Int(-1, -1, 0)
			},
			{
				WorldDirection.DNW,
				new Vec3Int(-1, -1, 1)
			},
			{
				WorldDirection.DC,
				new Vec3Int(0, -1, 0)
			}
		};

		public static readonly Dictionary<Vec3Int, WorldDirection> VectorToDirection = new Dictionary<Vec3Int, WorldDirection>
		{
			{
				new Vec3Int(0, 0, 1),
				WorldDirection.N
			},
			{
				new Vec3Int(1, 0, 1),
				WorldDirection.NE
			},
			{
				new Vec3Int(1, 0, 0),
				WorldDirection.E
			},
			{
				new Vec3Int(1, 0, -1),
				WorldDirection.SE
			},
			{
				new Vec3Int(0, 0, -1),
				WorldDirection.S
			},
			{
				new Vec3Int(-1, 0, -1),
				WorldDirection.SW
			},
			{
				new Vec3Int(-1, 0, 0),
				WorldDirection.W
			},
			{
				new Vec3Int(-1, 0, 1),
				WorldDirection.NW
			},
			{
				new Vec3Int(0, 0, 0),
				WorldDirection.C
			},
			{
				new Vec3Int(0, 1, 1),
				WorldDirection.UN
			},
			{
				new Vec3Int(1, 1, 1),
				WorldDirection.UNE
			},
			{
				new Vec3Int(1, 1, 0),
				WorldDirection.UE
			},
			{
				new Vec3Int(1, 1, -1),
				WorldDirection.USE
			},
			{
				new Vec3Int(0, 1, -1),
				WorldDirection.US
			},
			{
				new Vec3Int(-1, 1, -1),
				WorldDirection.USW
			},
			{
				new Vec3Int(-1, 1, 0),
				WorldDirection.UW
			},
			{
				new Vec3Int(-1, 1, 1),
				WorldDirection.UNW
			},
			{
				new Vec3Int(0, 1, 0),
				WorldDirection.UC
			},
			{
				new Vec3Int(0, -1, 1),
				WorldDirection.DN
			},
			{
				new Vec3Int(1, -1, 1),
				WorldDirection.DNE
			},
			{
				new Vec3Int(1, -1, 0),
				WorldDirection.DE
			},
			{
				new Vec3Int(1, -1, -1),
				WorldDirection.DSE
			},
			{
				new Vec3Int(0, -1, -1),
				WorldDirection.DS
			},
			{
				new Vec3Int(-1, -1, -1),
				WorldDirection.DSW
			},
			{
				new Vec3Int(-1, -1, 0),
				WorldDirection.DW
			},
			{
				new Vec3Int(-1, -1, 1),
				WorldDirection.DNW
			},
			{
				new Vec3Int(0, -1, 0),
				WorldDirection.DC
			}
		};

		public static void GatherReachablePositions(Vec3Int center, ReachabilityInfo info, ISet<Vec3Int> reachablePositions, Func<MapNode, bool> additionalCheck = null)
		{
			GatherReachablePositions(center, info, delegate(MapNode node)
			{
				if (additionalCheck == null || additionalCheck(node))
				{
					reachablePositions.Add(node.Position);
				}
			});
		}

		public static WorldDirection GetNeighbourDirection(MapNode node, MapNode neighbour)
		{
			return GetNeighbourDirection(node.Position, neighbour.Position);
		}

		public static WorldDirection GetNeighbourDirection(Vec3Int nodePosition, Vec3Int neighbourPosition)
		{
			Vec3Int key = neighbourPosition - nodePosition;
			key.x = Math.Clamp(key.x, -1, 1);
			key.y = Math.Clamp(key.y, -1, 1);
			key.z = Math.Clamp(key.z, -1, 1);
			return VectorToDirection.GetValueOrDefault(key);
		}

		public static void IterateTroughReachablePositions(Vec3Int center, WorldDirection direction, Action<MapNode> callback)
		{
			foreach (KeyValuePair<WorldDirection, Vec3Int> item in DirectionToVector)
			{
				if ((direction & item.Key) == item.Key)
				{
					MapNode nodeIfValid = GetNodeIfValid(center + item.Value);
					if (nodeIfValid != null)
					{
						callback(nodeIfValid);
					}
				}
			}
		}

		private static void GatherReachablePositions(Vec3Int center, ReachabilityInfo info, Action<MapNode> callback)
		{
			info.ForEachYAccess(delegate(int offset, WorldDirection direction)
			{
				Vec3Int center2 = center;
				center2.y += offset;
				IterateTroughReachablePositions(center2, direction, callback);
			});
		}

		private static MapNode GetNodeIfValid(Vec3Int pos)
		{
			MapNode node = VillageManager.ActiveVillage.Map.GetNode(pos);
			if (node == null)
			{
				return null;
			}
			if (node.IsWalkable && !node.IsFire)
			{
				return node;
			}
			return null;
		}
	}
}
