using System;
using Unity.Collections;

namespace Assets.Scripts.Craft.Wings
{
	public struct LoopCutout
	{
		public Point EndPoint;

		public int Length;

		public NativeSlice<Point> Slice1;

		public NativeSlice<Point> Slice2;

		public Point StartPoint;

		public Point this[int index]
		{
			get
			{
				if (index > Length)
				{
					throw new IndexOutOfRangeException();
				}
				if (index < Slice1.Length)
				{
					return Slice1[index];
				}
				return Slice2[index - Slice1.Length];
			}
			set
			{
				if (index > Length)
				{
					throw new IndexOutOfRangeException();
				}
				if (index < Slice1.Length)
				{
					Slice1[index] = value;
				}
				else
				{
					Slice2[index - Slice1.Length] = value;
				}
			}
		}

		public LoopCutout(NativeArray<Point> points, Point startPoint, Point endPoint, int startIndex, int endIndex)
		{
			StartPoint = startPoint;
			EndPoint = endPoint;
			if (endIndex >= startIndex)
			{
				Length = endIndex - startIndex;
				Slice1 = points.Slice(startIndex, Length);
				Slice2 = default(NativeSlice<Point>);
			}
			else
			{
				Slice1 = points.Slice(startIndex);
				Slice2 = points.Slice(0, endIndex);
				Length = Slice1.Length + Slice2.Length;
			}
		}
	}
}
