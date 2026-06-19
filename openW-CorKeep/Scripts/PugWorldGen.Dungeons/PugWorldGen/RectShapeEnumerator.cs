using System;
using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;

namespace PugWorldGen
{
	public struct RectShapeEnumerator : ShapeEnumerator, IEnumerator<int2>, IEnumerator, IDisposable
	{
		private int2 current;

		private int2 center;

		private int2 size;

		private int largestSize;

		private quaternion rotation;

		private PlacementAlignment placement;

		public int2 Current => current + center;

		object IEnumerator.Current => Current;

		public PlacementAlignment Placement => placement;

		public RectShapeEnumerator(int2 center, float2 size, float rotation)
		{
			this.center = center;
			this.size = (int2)math.ceil(size);
			this.rotation = quaternion.RotateY(0f - rotation);
			largestSize = (int)math.ceil(math.length(size));
			current = new int2(-largestSize - 1, -largestSize);
			placement = PlacementAlignment.Anywhere;
		}

		public bool MoveNext()
		{
			int num = current.x;
			int num2 = current.y;
			int2 int5;
			do
			{
				num++;
				if (num > largestSize)
				{
					num2++;
					num = -largestSize - 1;
				}
				if (num2 > largestSize)
				{
					return false;
				}
				int5 = math.rotate(rotation, new float3((float)num + 0.5f, 0f, (float)num2 + 0.5f)).FloorToInt2();
			}
			while (math.any(math.abs(int5) > size));
			current = new int2(num, num2);
			placement = GetPlacement(int5, size);
			return true;
		}

		public void Reset()
		{
			current = new int2(-largestSize - 1, -largestSize);
		}

		public void Dispose()
		{
		}

		public static PlacementAlignment GetPlacement(int2 pos, int2 size)
		{
			if (pos.x == -size.x && pos.y != -size.y && pos.y != size.y)
			{
				return PlacementAlignment.Left;
			}
			if (pos.x == size.x && pos.y != -size.y && pos.y != size.y)
			{
				return PlacementAlignment.Right;
			}
			if (pos.y == size.y && pos.x != -size.x && pos.x != size.x)
			{
				return PlacementAlignment.Forward;
			}
			if (pos.y == -size.y && pos.x != -size.x && pos.x != size.x)
			{
				return PlacementAlignment.Back;
			}
			if (pos.y == size.y && pos.x == -size.x)
			{
				return PlacementAlignment.ForwardLeft;
			}
			if (pos.y == size.y && pos.x == size.x)
			{
				return PlacementAlignment.ForwardRight;
			}
			if (pos.y == -size.y && pos.x == -size.x)
			{
				return PlacementAlignment.BackLeft;
			}
			if (pos.y == -size.y && pos.x == size.x)
			{
				return PlacementAlignment.BackRight;
			}
			return PlacementAlignment.Inside;
		}
	}
}
