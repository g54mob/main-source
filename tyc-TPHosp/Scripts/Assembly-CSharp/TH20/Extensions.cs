using System;
using UnityEngine;

namespace TH20
{
	public static class Extensions
	{
		public static GridDirection Rotate180(this GridDirection direction)
		{
			return (direction + 2) & GridDirection.NegX;
		}

		public static GridDirection RotateClockwise(this GridDirection direction)
		{
			return (direction - 1) & GridDirection.NegX;
		}

		public static GridDirection RotateAntiClockwise(this GridDirection direction)
		{
			return (direction + 1) & GridDirection.NegX;
		}

		public static Vector3 DirectionVector(this GridDirection direction)
		{
			return direction switch
			{
				GridDirection.PosX => new Vector3(1f, 0f, 0f), 
				GridDirection.PosY => new Vector3(0f, 0f, 1f), 
				GridDirection.NegX => new Vector3(-1f, 0f, 0f), 
				GridDirection.NegY => new Vector3(0f, 0f, -1f), 
				_ => throw new ArgumentOutOfRangeException("direction", direction, null), 
			};
		}

		public static GridCoord DirectionCoord(this GridDirection direction)
		{
			return direction switch
			{
				GridDirection.PosX => new GridCoord(1, 0), 
				GridDirection.PosY => new GridCoord(0, 1), 
				GridDirection.NegX => new GridCoord(-1, 0), 
				GridDirection.NegY => new GridCoord(0, -1), 
				_ => throw new ArgumentOutOfRangeException("direction", direction, null), 
			};
		}

		public static float YawRotation(this GridDirection direction)
		{
			return direction switch
			{
				GridDirection.PosY => 0f, 
				GridDirection.PosX => 90f, 
				GridDirection.NegY => 180f, 
				GridDirection.NegX => 270f, 
				_ => throw new ArgumentOutOfRangeException("direction", direction, null), 
			};
		}

		public static GridDirection ToGridDirection(this Quaternion rotation)
		{
			return (GridDirection)((int)(rotation.eulerAngles.y / 90f) & 3);
		}

		public static GridDirection ToGridDirection(this float rotation)
		{
			return (GridDirection)((int)(rotation / 90f) & 3);
		}
	}
}
