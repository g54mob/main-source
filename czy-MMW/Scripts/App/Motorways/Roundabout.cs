using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	public class Roundabout
	{
		private static List<Vector2Int> CoordinatesOffsets;

		private static Dictionary<RoadTileConnection, Vector2Int> ConnectionsToCoordinatesOffset;

		private static Dictionary<Vector2Int, RoadTileConnection> CoordinatesOffsetsToConnection;

		private static List<Vector2Int> NeighborCoordinatesOffsets;

		private static Dictionary<Vector2Int, TileDirectionBitfield> NeighborCoordinatesOffsetsToInvalidNodeDirections;

		static Roundabout()
		{
			InitializeConstants();
		}

		public static void InitializeConstants()
		{
			ConnectionsToCoordinatesOffset = new Dictionary<RoadTileConnection, Vector2Int>
			{
				{
					new RoadTileConnection(new RoadTileNode(TileDirection.NorthWest, RoadType.Roundabout), new RoadTileNode(TileDirection.NorthEast, RoadType.Roundabout)),
					new Vector2Int(0, -1)
				},
				{
					new RoadTileConnection(new RoadTileNode(TileDirection.SouthWest, RoadType.Roundabout), new RoadTileNode(TileDirection.NorthWest, RoadType.Roundabout)),
					new Vector2Int(1, 0)
				},
				{
					new RoadTileConnection(new RoadTileNode(TileDirection.SouthEast, RoadType.Roundabout), new RoadTileNode(TileDirection.SouthWest, RoadType.Roundabout)),
					new Vector2Int(0, 1)
				},
				{
					new RoadTileConnection(new RoadTileNode(TileDirection.NorthEast, RoadType.Roundabout), new RoadTileNode(TileDirection.SouthEast, RoadType.Roundabout)),
					new Vector2Int(-1, 0)
				}
			};
			CoordinatesOffsetsToConnection = new Dictionary<Vector2Int, RoadTileConnection>();
			foreach (RoadTileConnection key in ConnectionsToCoordinatesOffset.Keys)
			{
				CoordinatesOffsetsToConnection[ConnectionsToCoordinatesOffset[key]] = key;
			}
			CoordinatesOffsets = new List<Vector2Int>(CoordinatesOffsetsToConnection.Keys);
			List<Vector2Int> list = new List<Vector2Int>
			{
				Vector2Int.left,
				Vector2Int.right,
				Vector2Int.up,
				Vector2Int.down
			};
			NeighborCoordinatesOffsets = new List<Vector2Int>();
			foreach (Vector2Int coordinatesOffset in CoordinatesOffsets)
			{
				foreach (Vector2Int item2 in list)
				{
					Vector2Int item = coordinatesOffset + item2;
					if (!CoordinatesOffsets.Contains(item) && !NeighborCoordinatesOffsets.Contains(item))
					{
						NeighborCoordinatesOffsets.Add(item);
					}
				}
			}
			NeighborCoordinatesOffsetsToInvalidNodeDirections = new Dictionary<Vector2Int, TileDirectionBitfield>();
			foreach (Vector2Int neighborCoordinatesOffset in NeighborCoordinatesOffsets)
			{
				TileDirectionBitfield value = default(TileDirectionBitfield);
				foreach (Vector2Int coordinatesOffset2 in CoordinatesOffsets)
				{
					TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(coordinatesOffset2, neighborCoordinatesOffset);
					if (directionBetweenAdjacentCoordinates != TileDirection.None && !CanConnectionAddExitNode(CoordinatesOffsetsToConnection[coordinatesOffset2], new RoadTileNode(directionBetweenAdjacentCoordinates)))
					{
						value[TileUtilities.GetOppositeDirection(directionBetweenAdjacentCoordinates)] = true;
					}
				}
				if (neighborCoordinatesOffset == GetCenterOffset())
				{
					value[TileDirection.NorthEast] = true;
					value[TileDirection.SouthEast] = true;
					value[TileDirection.SouthWest] = true;
					value[TileDirection.NorthWest] = true;
				}
				NeighborCoordinatesOffsetsToInvalidNodeDirections[neighborCoordinatesOffset] = value;
			}
		}

		public static Vector2Int GetCenterOffset()
		{
			return Vector2Int.zero;
		}

		public static IList<Vector2Int> GetCoordinatesOffsets()
		{
			return CoordinatesOffsets;
		}

		public static bool IsCoordinatesOffsetInRoundabout(Vector2Int coordinatesOffset)
		{
			return CoordinatesOffsetsToConnection.ContainsKey(coordinatesOffset);
		}

		public static RoadTileConnection GetConnectionForCoordinatesOffset(Vector2Int coordinatesOffset)
		{
			return CoordinatesOffsetsToConnection[coordinatesOffset];
		}

		public static Vector2Int GetCoordinatesOffsetForConnection(RoadTileConnection roundaboutConnection)
		{
			if (Diagnostics.Verify(ConnectionsToCoordinatesOffset.TryGetValue(roundaboutConnection, out var value), "{0} is not a recognised roundabout connection.", roundaboutConnection))
			{
				return value;
			}
			return default(Vector2Int);
		}

		public static IEnumerable<Vector2Int> GetNeighborCoordinatesOffsets()
		{
			return NeighborCoordinatesOffsets;
		}

		public static TileDirectionBitfield GetInvalidNodeDirectionsForNeighbor(Vector2Int neighborCoordinatesOffset)
		{
			if (NeighborCoordinatesOffsetsToInvalidNodeDirections.TryGetValue(neighborCoordinatesOffset, out var value))
			{
				return value;
			}
			return TileDirectionBitfield.None;
		}

		public static bool DoesConnectionOwnRoundabout(RoadTileConnection roundaboutConnection)
		{
			TileDirection direction = roundaboutConnection.input.direction;
			TileDirection direction2 = roundaboutConnection.output.direction;
			if (direction != TileDirection.NorthWest || direction2 != TileDirection.NorthEast)
			{
				if (direction == TileDirection.NorthEast)
				{
					return direction2 == TileDirection.NorthWest;
				}
				return false;
			}
			return true;
		}

		public static bool CanConnectionAddExitNode(RoadTileConnection roundaboutConnection, RoadTileNode exitNode)
		{
			return CanConnectionAddExitNode(roundaboutConnection.input.direction, roundaboutConnection.output.direction, exitNode);
		}

		public static bool CanConnectionAddExitNode(TileDirection roundaboutInput, TileDirection roundaboutOutput, RoadTileNode exitNode)
		{
			return GetValidExitsForConnection(roundaboutInput, roundaboutOutput)[exitNode.direction];
		}

		public static TileDirectionBitfield GetValidExitsForConnection(TileDirection roundaboutInput, TileDirection roundaboutOutput)
		{
			TileDirectionBitfield result = default(TileDirectionBitfield);
			if (roundaboutInput == TileUtilities.GetOppositeDirection(roundaboutOutput))
			{
				result[TileUtilities.GetRotatedDirection(roundaboutOutput, 2)] = true;
			}
			else if (Diagnostics.Verify(roundaboutOutput == TileUtilities.GetRotatedDirection(roundaboutInput, 2), "{0} -> {1} is a peculiar roundabout connection that is not a corner or straight.", roundaboutInput, roundaboutOutput))
			{
				TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(roundaboutInput);
				result[oppositeDirection] = true;
				result[TileUtilities.GetRotatedDirection(oppositeDirection, -1)] = true;
				result[TileUtilities.GetRotatedDirection(oppositeDirection, 1)] = true;
				result[TileUtilities.GetRotatedDirection(oppositeDirection, 2)] = true;
				result[TileUtilities.GetRotatedDirection(oppositeDirection, 3)] = true;
			}
			return result;
		}

		public static TileDirectionBitfield GetInvalidExitsForConnection(TileDirection roundaboutInput, TileDirection roundaboutOutput)
		{
			return ~GetValidExitsForConnection(roundaboutInput, roundaboutOutput);
		}

		public static Tile GetCenterTile(Tile roundaboutTile, RoadState roundaboutState)
		{
			if (IsTileCenterOfRoundabout(roundaboutTile, roundaboutState))
			{
				return roundaboutTile;
			}
			RoadTileConnection roundaboutConnection = roundaboutTile.GetRoundaboutConnection(roundaboutState);
			if (!Diagnostics.Verify(roundaboutConnection.IsRoundabout, "Tile {0} is not a roundabout!", roundaboutTile))
			{
				return null;
			}
			return roundaboutTile.Tilemap.GetTile(roundaboutTile.Coordinates - GetCoordinatesOffsetForConnection(roundaboutConnection));
		}

		public static IEnumerable<Tile> GetTilesInRoundabout(Tile roundaboutTile, RoadState roundaboutState)
		{
			ITilemap tilemap = roundaboutTile.Tilemap;
			if (IsTileCenterOfRoundabout(roundaboutTile, roundaboutState))
			{
				roundaboutTile = tilemap.GetTile(TileUtilities.GetAdjacentCoordinates(roundaboutTile.Coordinates, TileDirection.North));
			}
			RoadTileConnection roundaboutConnection = roundaboutTile.GetRoundaboutConnection(roundaboutState);
			if (!Diagnostics.Verify(roundaboutConnection.IsRoundabout, "GetTilesOnRoundabout called on a non-roundabout tile."))
			{
				yield break;
			}
			foreach (Tile item in GetTilesInRoundabout(roundaboutTile, roundaboutConnection))
			{
				yield return item;
			}
		}

		public static IEnumerable<Tile> GetTilesInRoundabout(Tile roundaboutTile, RoadTileConnection roundaboutConnection)
		{
			ITilemap tilemap = roundaboutTile.Tilemap;
			Vector2Int coordinatesOffsetForConnection = GetCoordinatesOffsetForConnection(roundaboutConnection);
			Vector2Int roundaboutOrigin = roundaboutTile.Coordinates - coordinatesOffsetForConnection;
			foreach (Vector2Int coordinatesOffset in CoordinatesOffsets)
			{
				yield return tilemap.GetTile(roundaboutOrigin + coordinatesOffset);
			}
		}

		public static bool IsTileCenterOfRoundabout(Tile tile, RoadState roadState = RoadState.VisiblyActive)
		{
			using Dictionary<Vector2Int, RoadTileConnection>.Enumerator enumerator = CoordinatesOffsetsToConnection.GetEnumerator();
			enumerator.MoveNext();
			KeyValuePair<Vector2Int, RoadTileConnection> current = enumerator.Current;
			Tile tile2 = tile.Tilemap.GetTile(tile.Coordinates + current.Key);
			if (tile2 != null && tile2.HasRoundabout(roadState))
			{
				return tile2.GetRoundaboutConnection(roadState).Equals(current.Value);
			}
			return false;
		}
	}
}
