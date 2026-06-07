using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public struct SgtPosition
	{
		public static readonly double CellSize;

		public double LocalX;

		public double LocalY;

		public double LocalZ;

		public long GlobalX;

		public long GlobalY;

		public long GlobalZ;

		public SgtPosition(Vector3 localXYZ, double scale = 1.0)
		{
			LocalX = 0.0;
			LocalY = 0.0;
			LocalZ = 0.0;
			GlobalX = 0L;
			GlobalY = 0L;
			GlobalZ = 0L;
		}

		public static double Distance(ref SgtPosition a, ref SgtPosition b)
		{
			return 0.0;
		}

		public static double SqrDistance(ref SgtPosition a, ref SgtPosition b)
		{
			return 0.0;
		}

		public static SgtPosition Delta(ref SgtPosition a, ref SgtPosition b)
		{
			return default(SgtPosition);
		}

		public static bool Equal(ref SgtPosition a, ref SgtPosition b)
		{
			return false;
		}

		public static Vector3 Direction(ref SgtPosition a, ref SgtPosition b)
		{
			return default(Vector3);
		}

		public static SgtPosition Lerp(SgtPosition a, SgtPosition b, double t)
		{
			return default(SgtPosition);
		}

		public static Vector3 Vector(ref SgtPosition a, ref SgtPosition b)
		{
			return default(Vector3);
		}

		public bool SnapLocal()
		{
			return false;
		}

		public static SgtPosition operator +(SgtPosition a, SgtPosition b)
		{
			return default(SgtPosition);
		}

		public override string ToString()
		{
			return null;
		}

		private long CalculateShift(double coordinate, double cellSize)
		{
			return 0L;
		}
	}
}
