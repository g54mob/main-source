using System.Diagnostics;
using UnityEngine;

namespace TH20
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public struct GridCoord
	{
		public int X;

		public int Y;

		public const float CellSize = 2f;

		public const float CellSizeInv = 0.5f;

		private string DebuggerDisplay => $"({X}, {Y})";

		public GridCoord(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static GridCoord operator +(GridCoord lhs, GridCoord rhs)
		{
			return new GridCoord(lhs.X + rhs.X, lhs.Y + rhs.Y);
		}

		public static GridCoord operator -(GridCoord lhs, GridCoord rhs)
		{
			return new GridCoord(lhs.X - rhs.X, lhs.Y - rhs.Y);
		}

		public static GridCoord operator /(GridCoord lhs, int rhs)
		{
			return new GridCoord(lhs.X / rhs, lhs.Y / rhs);
		}

		public static GridCoord operator *(GridCoord lhs, int rhs)
		{
			return new GridCoord(lhs.X * rhs, lhs.Y * rhs);
		}

		public static bool operator ==(GridCoord lhs, GridCoord rhs)
		{
			if (lhs.X == rhs.X)
			{
				return lhs.Y == rhs.Y;
			}
			return false;
		}

		public static bool operator !=(GridCoord lhs, GridCoord rhs)
		{
			return !(lhs == rhs);
		}

		public bool Equals(GridCoord other)
		{
			if (X == other.X)
			{
				return Y == other.Y;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is GridCoord)
			{
				return Equals((GridCoord)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (X * 397) ^ Y;
		}

		public int DistanceSquared(GridCoord other)
		{
			int num = X - other.X;
			int num2 = Y - other.Y;
			return num * num + num2 * num2;
		}

		public int Distance(GridCoord other)
		{
			return MathUtils.Sqrt(DistanceSquared(other));
		}

		private static int SignNoException(float value)
		{
			if (value < 0f)
			{
				return -1;
			}
			if (value > 0f)
			{
				return 1;
			}
			return 0;
		}

		public static GridCoord WorldPositionToGridCoord(Vector3 worldPosition)
		{
			worldPosition.x *= 0.5f;
			worldPosition.z *= 0.5f;
			return new GridCoord((int)(worldPosition.x + (float)SignNoException(worldPosition.x) * 0.5f), (int)(worldPosition.z + (float)SignNoException(worldPosition.z) * 0.5f));
		}

		public static Vector3 GridCoordToWorldPosition(GridCoord gridCoord)
		{
			return GridCoordToWorldPosition(gridCoord.X, gridCoord.Y);
		}

		public static Vector3 GridCoordToWorldPosition(int x, int y)
		{
			return new Vector3((float)x * 2f, 0f, (float)y * 2f);
		}

		public override string ToString()
		{
			return DebuggerDisplay;
		}
	}
}
