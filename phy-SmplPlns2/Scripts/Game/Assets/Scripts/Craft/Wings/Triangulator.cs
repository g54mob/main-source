using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public static class Triangulator
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct TriangulatorJob : IJob
		{
			[ReadOnly]
			public byte AllowReverse;

			[ReadOnly]
			public int IndexOffset;

			[ReadOnly]
			public NativeSlice<float2> Points;

			[ReadOnly]
			public byte Reversed;

			public NativeList<int3> Triangles;

			public NativeArray<int> V;

			public static void Triangulate(NativeSlice<float2> points, NativeList<int3> triangles, int indexOffset, bool reversed, bool allowReverse)
			{
				int length = points.Length;
				NativeArray<int> arrayV = new NativeArray<int>(length, Allocator.Temp);
				if (Area(points) > 0f)
				{
					for (int i = 0; i < length; i++)
					{
						arrayV[i] = i;
					}
				}
				else
				{
					if (allowReverse)
					{
						reversed = !reversed;
					}
					for (int j = 0; j < length; j++)
					{
						arrayV[j] = length - 1 - j;
					}
				}
				int num = length;
				int num2 = 2 * num;
				int num3 = num - 1;
				while (num > 2 && num2-- > 0)
				{
					int num4 = num3;
					if (num <= num4)
					{
						num4 = 0;
					}
					num3 = num4 + 1;
					if (num <= num3)
					{
						num3 = 0;
					}
					int num5 = num3 + 1;
					if (num <= num5)
					{
						num5 = 0;
					}
					if (Snip(num4, num3, num5, num, points, arrayV))
					{
						if (!reversed)
						{
							int3 value = new int3
							{
								x = arrayV[num5] + indexOffset,
								y = arrayV[num3] + indexOffset,
								z = arrayV[num4] + indexOffset
							};
							triangles.Add(in value);
						}
						else
						{
							int3 value = new int3
							{
								x = arrayV[num4] + indexOffset,
								y = arrayV[num3] + indexOffset,
								z = arrayV[num5] + indexOffset
							};
							triangles.Add(in value);
						}
						int num6 = num3;
						for (int k = num3 + 1; k < num; k++)
						{
							arrayV[num6] = arrayV[k];
							num6++;
						}
						num--;
						num2 = 2 * num;
					}
				}
				arrayV.Dispose();
			}

			public readonly void Execute()
			{
				Triangulate(Points, Triangles, IndexOffset, Reversed != 0, AllowReverse != 0);
			}

			private static float Area(NativeSlice<float2> points)
			{
				int length = points.Length;
				float num = 0f;
				int index = length - 1;
				int num2 = 0;
				while (num2 < length)
				{
					float2 float5 = points[index];
					float2 float6 = points[num2];
					num += float5.x * float6.y - float6.x * float5.y;
					index = num2++;
				}
				return num * 0.5f;
			}

			private static byte InsideTriangle(float2 a, float2 b, float2 c, float2 p)
			{
				if (!(math.determinant(math.float2x2(c - b, p - b)) > 0f) || !(math.determinant(math.float2x2(b - a, p - a)) > 0f) || !(math.determinant(math.float2x2(a - c, p - c)) > 0f))
				{
					return 0;
				}
				return 1;
			}

			private static bool Snip(int u, int v, int w, int n, NativeSlice<float2> points, NativeArray<int> arrayV)
			{
				float2 a = points[arrayV[u]];
				float2 b = points[arrayV[v]];
				float2 c = points[arrayV[w]];
				if ((b.x - a.x) * (c.y - a.y) - (b.y - a.y) * (c.x - a.x) < 1.1920929E-07f)
				{
					return false;
				}
				for (int i = 0; i < n; i++)
				{
					if (i != u && i != v && i != w)
					{
						float2 p = points[arrayV[i]];
						if (InsideTriangle(a, b, c, p) != 0)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		private const Allocator _allocator = Allocator.TempJob;

		public static void Triangulate(NativeSlice<Point> points, NativeList<int3> triangles, bool reversed, int indexOffset = 0, bool allowReverse = false)
		{
			using NativeArray<int> v = new NativeArray<int>(points.Length, Allocator.TempJob);
			new TriangulatorJob
			{
				V = v,
				Points = points.SliceWithStride<float2>(Point.OffsetOfPosition),
				Triangles = triangles,
				IndexOffset = indexOffset,
				Reversed = (byte)(reversed ? 1 : 0),
				AllowReverse = (byte)(allowReverse ? 1 : 0)
			}.Run();
		}

		public static void Triangulate(NativeSlice<float2> points, NativeList<int3> triangles, bool reversed, int indexOffset = 0, bool allowReverse = false)
		{
			using NativeArray<int> v = new NativeArray<int>(points.Length, Allocator.TempJob);
			new TriangulatorJob
			{
				V = v,
				Points = points,
				Triangles = triangles,
				IndexOffset = indexOffset,
				Reversed = (byte)(reversed ? 1 : 0),
				AllowReverse = (byte)(allowReverse ? 1 : 0)
			}.Run();
		}
	}
}
