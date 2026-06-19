using System;
using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;

namespace PugWorldGen
{
	public struct CircleShapeEnumerator : ShapeEnumerator, IEnumerator<int2>, IEnumerator, IDisposable
	{
		private int2 current;

		private int2 center;

		private int largestSize;

		private float2 sizeSq;

		private quaternion rotation;

		public int2 Current => current + center;

		object IEnumerator.Current => Current;

		public CircleShapeEnumerator(int2 center, float2 size, float rotation)
		{
			this.center = center;
			sizeSq = size * size;
			largestSize = (int)math.ceil(math.length(size));
			current = -largestSize;
			this.rotation = quaternion.RotateY(0f - rotation);
		}

		public bool MoveNext()
		{
			int i = current.x + 1;
			for (int j = current.y; j < largestSize; j++)
			{
				for (; i < largestSize; i++)
				{
					int2 int5 = math.rotate(rotation, new float3((float)i + 0.5f, 0f, (float)j + 0.5f)).FloorToInt2();
					int num = int5.x * int5.x;
					int num2 = int5.y * int5.y;
					if ((float)num / sizeSq.x + (float)num2 / sizeSq.y <= 1f)
					{
						current = new int2(i, j);
						return true;
					}
				}
				i = -largestSize;
			}
			return false;
		}

		public void Reset()
		{
			current = -largestSize;
		}

		public void Dispose()
		{
		}
	}
}
