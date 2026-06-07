using System;
using System.Collections.Generic;
using FixMath;
using Motorways.Models;
using UnityEngine;

namespace Motorways
{
	public static class TileUtilities
	{
		public const int DirectionCount = 8;

		public static readonly Vector2Int[] DirectionToTileAdjacencyOffset = new Vector2Int[8]
		{
			Vector2Int.up,
			Vector2Int.up + Vector2Int.right,
			Vector2Int.right,
			Vector2Int.down + Vector2Int.right,
			Vector2Int.down,
			Vector2Int.down + Vector2Int.left,
			Vector2Int.left,
			Vector2Int.up + Vector2Int.left
		};

		public static readonly TileDirection[] NonDiagonalDirections = new TileDirection[4]
		{
			TileDirection.North,
			TileDirection.East,
			TileDirection.South,
			TileDirection.West
		};

		public static readonly TileDirection[] DiagonalDirections = new TileDirection[4]
		{
			TileDirection.NorthEast,
			TileDirection.SouthEast,
			TileDirection.SouthWest,
			TileDirection.NorthWest
		};

		public static readonly TileDirection[] Directions = new TileDirection[8]
		{
			TileDirection.North,
			TileDirection.NorthEast,
			TileDirection.East,
			TileDirection.SouthEast,
			TileDirection.South,
			TileDirection.SouthWest,
			TileDirection.West,
			TileDirection.NorthWest
		};

		private static readonly Vector2[] DirectionToVector = new Vector2[8]
		{
			Vector2.up,
			(Vector2.up + Vector2.right).normalized,
			Vector2.right,
			(Vector2.down + Vector2.right).normalized,
			Vector2.down,
			(Vector2.down + Vector2.left).normalized,
			Vector2.left,
			(Vector2.up + Vector2.left).normalized
		};

		private static readonly Vector2Fixed[] DirectionToVectorFixed = new Vector2Fixed[8]
		{
			Vector2Fixed.up,
			(Vector2Fixed.up + Vector2Fixed.right).normalized,
			Vector2Fixed.right,
			(Vector2Fixed.down + Vector2Fixed.right).normalized,
			Vector2Fixed.down,
			(Vector2Fixed.down + Vector2Fixed.left).normalized,
			Vector2Fixed.left,
			(Vector2Fixed.up + Vector2Fixed.left).normalized
		};

		private static readonly Vector2Fixed[] DirectionToTileEdgeVectorFixed = new Vector2Fixed[8]
		{
			Vector2Fixed.up,
			Vector2Fixed.up + Vector2Fixed.right,
			Vector2Fixed.right,
			Vector2Fixed.down + Vector2Fixed.right,
			Vector2Fixed.down,
			Vector2Fixed.down + Vector2Fixed.left,
			Vector2Fixed.left,
			Vector2Fixed.up + Vector2Fixed.left
		};

		public static Vector2Int GetAdjacentCoordinates(Vector2Int originCoordinates, TileDirection direction)
		{
			return originCoordinates + DirectionToTileAdjacencyOffset[(int)direction];
		}

		public static TileDirection GetDirectionBetweenAdjacentCoordinates(Vector2Int originCoordinates, Vector2Int adjacentCoordinates)
		{
			Vector2Int vector2Int = adjacentCoordinates - originCoordinates;
			for (int i = 0; i < DirectionToTileAdjacencyOffset.Length; i++)
			{
				if (DirectionToTileAdjacencyOffset[i] == vector2Int)
				{
					return (TileDirection)i;
				}
			}
			return TileDirection.None;
		}

		public static TileDirection GetRotatedDirection(TileDirection direction, RoadTileRotation rotation)
		{
			return GetRotatedDirection(direction, (int)rotation * 2);
		}

		public static TileDirection GetRotatedDirection(TileDirection direction, int rotationCount)
		{
			if (direction == TileDirection.None)
			{
				return TileDirection.None;
			}
			return (TileDirection)Wrap((int)(direction + rotationCount), 8);
		}

		public static Vector2Fixed GetRotatedVector(Vector2Fixed original, RoadTileRotation rotation)
		{
			return rotation switch
			{
				RoadTileRotation.None => original, 
				RoadTileRotation.QuarterTurn => new Vector2Fixed(original.y, -original.x), 
				RoadTileRotation.HalfTurn => new Vector2Fixed(-original.x, -original.y), 
				RoadTileRotation.ThreeQuarterTurn => new Vector2Fixed(-original.y, original.x), 
				_ => original, 
			};
		}

		public static Vector2 GetRotatedVector(Vector2 original, RoadTileRotation rotation)
		{
			return rotation switch
			{
				RoadTileRotation.None => original, 
				RoadTileRotation.QuarterTurn => new Vector2(original.y, 0f - original.x), 
				RoadTileRotation.HalfTurn => new Vector2(0f - original.x, 0f - original.y), 
				RoadTileRotation.ThreeQuarterTurn => new Vector2(0f - original.y, original.x), 
				_ => original, 
			};
		}

		public static TileDirection GetOppositeDirection(TileDirection direction)
		{
			return GetRotatedDirection(direction, RoadTileRotation.HalfTurn);
		}

		public static Vector2Int GetAdjacencyOffsetForDirection(TileDirection direction)
		{
			if (direction == TileDirection.None)
			{
				return Vector2Int.zero;
			}
			return DirectionToTileAdjacencyOffset[(int)direction];
		}

		public static Vector2 GetVectorForDirection(TileDirection direction)
		{
			if (direction == TileDirection.None)
			{
				return Vector2.zero;
			}
			return DirectionToVector[(int)direction];
		}

		public static Vector2Fixed GetVectorFixedForDirection(TileDirection direction)
		{
			if (direction == TileDirection.None)
			{
				return Vector2Fixed.zero;
			}
			return DirectionToVectorFixed[(int)direction];
		}

		public static Vector2Fixed GetTileEdgeForDirection(TileDirection direction)
		{
			if (direction == TileDirection.None)
			{
				return Vector2Fixed.zero;
			}
			return DirectionToTileEdgeVectorFixed[(int)direction];
		}

		public static int GetDistanceBetweenDirections(TileDirection start, TileDirection end)
		{
			int num = Math.Max((int)start, (int)end) - Math.Min((int)start, (int)end);
			if (num > 4)
			{
				return 8 - num;
			}
			return num;
		}

		public static TileDirection GetClosestDirection(Vector2 direction)
		{
			int result = -1;
			float num = float.MinValue;
			for (int i = 0; i < DirectionToVector.Length; i++)
			{
				float num2 = Vector2.Dot(DirectionToVector[i], direction);
				if (num2 > num)
				{
					result = i;
					num = num2;
				}
			}
			return (TileDirection)result;
		}

		public static TileDirection GetClosestDirection(Vector2Fixed direction)
		{
			int result = -1;
			Fix64 fix = -Fix64.One;
			for (int i = 0; i < DirectionToVectorFixed.Length; i++)
			{
				Fix64 fix2 = Vector2Fixed.Dot(DirectionToVectorFixed[i], direction);
				if (fix2 > fix)
				{
					result = i;
					fix = fix2;
				}
			}
			return (TileDirection)result;
		}

		public static IEnumerable<TileDirection> GetRadiatedDirections(TileDirection startDirection, bool preferClockwise = true)
		{
			yield return startDirection;
			for (int i = 1; i < 4; i++)
			{
				yield return GetRotatedDirection(startDirection, i * (preferClockwise ? 1 : (-1)));
				yield return GetRotatedDirection(startDirection, i * ((!preferClockwise) ? 1 : (-1)));
			}
			yield return GetOppositeDirection(startDirection);
		}

		public static Fix64 GetRotationAngle(RoadTileRotation rotation)
		{
			return new Fix64((int)rotation) * (Fix64)90L;
		}

		private static RoadTileRotation GetRotatedRotation(RoadTileRotation startingRotation, int rotationsNeeded)
		{
			return (RoadTileRotation)Wrap((int)(startingRotation + rotationsNeeded), 4);
		}

		public static RoadTileRotation AddRotation(RoadTileRotation original, RoadTileRotation add)
		{
			return GetRotatedRotation(original, (int)add);
		}

		public static RoadTileRotation SubtractRotation(RoadTileRotation original, RoadTileRotation subtract)
		{
			return GetRotatedRotation(original, 0 - subtract);
		}

		public static bool IsDirectionDiagonal(TileDirection direction)
		{
			if (direction != TileDirection.NorthEast && direction != TileDirection.SouthEast && direction != TileDirection.SouthWest)
			{
				return direction == TileDirection.NorthWest;
			}
			return true;
		}

		public static RailDirection GetOppositeDirection(RailDirection direction)
		{
			if (direction != RailDirection.Forwards)
			{
				return RailDirection.Forwards;
			}
			return RailDirection.Backwards;
		}

		public static int Wrap(int value, int maximum)
		{
			if (!Diagnostics.Verify(maximum > 0, "Illegal wrap maximum of 0 or negative."))
			{
				return 0;
			}
			int num = value % maximum;
			if (num < 0)
			{
				num += maximum;
			}
			return num;
		}

		public static List<Vector2Int> GetThePerpendicularDiagonalPositions(Vector2Int firstPosition, Vector2Int secondPosition)
		{
			List<Vector2Int> list = new List<Vector2Int>();
			TileDirection directionBetweenAdjacentCoordinates = GetDirectionBetweenAdjacentCoordinates(firstPosition, secondPosition);
			TileDirection[] nonDiagonalDirections = NonDiagonalDirections;
			foreach (TileDirection tileDirection in nonDiagonalDirections)
			{
				if (directionBetweenAdjacentCoordinates == tileDirection)
				{
					return null;
				}
			}
			TileDirection rotatedDirection = GetRotatedDirection(directionBetweenAdjacentCoordinates, 1);
			TileDirection rotatedDirection2 = GetRotatedDirection(directionBetweenAdjacentCoordinates, -1);
			list.Add(firstPosition + GetAdjacencyOffsetForDirection(rotatedDirection));
			list.Add(firstPosition + GetAdjacencyOffsetForDirection(rotatedDirection2));
			return list;
		}

		public static RectInt GetBoundsWithBoundary(Vector2Int topLeftCoordinate, Vector2Int footprint, int boundary = 1)
		{
			int xMin = topLeftCoordinate.x - boundary;
			int yMin = topLeftCoordinate.y - (footprint.y - 1) - boundary;
			return new RectInt(xMin, yMin, footprint.x + boundary * 2, footprint.y + boundary * 2);
		}

		public static TileDirection DeserializeDirection(byte serializedDirection)
		{
			if (serializedDirection > 7)
			{
				return TileDirection.None;
			}
			return (TileDirection)serializedDirection;
		}
	}
}
