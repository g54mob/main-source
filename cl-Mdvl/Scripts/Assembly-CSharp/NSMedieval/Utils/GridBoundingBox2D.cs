using System;
using UnityEngine;

namespace NSMedieval.Utils
{
	public struct GridBoundingBox2D
	{
		private int pointCount;

		private Vector2 lowerLeft;

		private Vector2 upperRight;

		public Vector2 LowerLeft
		{
			get
			{
				if (pointCount != 0)
				{
					return lowerLeft;
				}
				throw new Exception("Bounding box has no points");
			}
		}

		public Vector2 UpperRight
		{
			get
			{
				if (pointCount != 0)
				{
					return upperRight;
				}
				throw new Exception("Bounding box has no points");
			}
		}

		public int XLen
		{
			get
			{
				if (pointCount != 0)
				{
					return (int)(upperRight.x - lowerLeft.x + 1f);
				}
				throw new Exception("Bounding box has no points");
			}
		}

		public int YLen
		{
			get
			{
				if (pointCount != 0)
				{
					return (int)(upperRight.y - lowerLeft.y + 1f);
				}
				throw new Exception("Bounding box has no points");
			}
		}

		public float AspectRatio
		{
			get
			{
				if (pointCount == 0)
				{
					throw new Exception("Bounding box has no points");
				}
				int num = Math.Max(XLen, YLen);
				int num2 = Math.Min(XLen, YLen);
				return (float)num / (float)num2;
			}
		}

		public float Area
		{
			get
			{
				if (pointCount == 0)
				{
					throw new Exception("Bounding box has no points");
				}
				return XLen * YLen;
			}
		}

		public float FillPercent
		{
			get
			{
				if (pointCount == 0)
				{
					throw new Exception("Bounding box has no points");
				}
				return (float)pointCount / Area;
			}
		}

		public void Clear()
		{
			pointCount = 0;
		}

		public void AddPoint(int x, int y)
		{
			Vector2 vector = new Vector2(x, y);
			if (pointCount == 0)
			{
				lowerLeft = vector;
				upperRight = vector;
				pointCount = 1;
			}
			else
			{
				pointCount++;
				lowerLeft.x = Math.Min(lowerLeft.x, vector.x);
				lowerLeft.y = Math.Min(lowerLeft.y, vector.y);
				upperRight.x = Math.Max(upperRight.x, vector.x);
				upperRight.y = Math.Max(upperRight.y, vector.y);
			}
		}
	}
}
