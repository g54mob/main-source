using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public static class MeshTriangulator
	{
		[BurstCompile(CompileSynchronously = true)]
		private struct TriangulatorJob : IJob
		{
			public struct Triangle
			{
				public int a;

				public int b;

				public int c;

				public Triangle(int a, int b, int c)
				{
					this.a = a;
					this.b = b;
					this.c = c;
				}
			}

			[ReadOnly]
			public int IndexOffset;

			[ReadOnly]
			public NativeArray<float2> Points;

			[ReadOnly]
			public byte Reversed;

			public NativeArray<Triangle> Triangles;

			public NativeArray<int> V;

			public static void Triangulate(int IndexOffset, byte Reversed, NativeArray<float2> Points, NativeArray<Triangle> Triangles, NativeArray<int> V)
			{
				int length = Points.Length;
				int num = 0;
				if (Area(ref Points) > 0f)
				{
					for (int i = 0; i < length; i++)
					{
						V[i] = i;
					}
				}
				else
				{
					for (int j = 0; j < length; j++)
					{
						V[j] = length - 1 - j;
					}
				}
				int num2 = length;
				int num3 = 2 * num2;
				byte b = 1;
				int num4 = num2 - 1;
				while (num2 > 2)
				{
					if (num3-- <= 0)
					{
						b = 0;
						break;
					}
					int num5 = num4;
					if (num2 <= num5)
					{
						num5 = 0;
					}
					num4 = num5 + 1;
					if (num2 <= num4)
					{
						num4 = 0;
					}
					int num6 = num4 + 1;
					if (num2 <= num6)
					{
						num6 = 0;
					}
					if (Snip(num5, num4, num6, num2, ref Points, ref V) != 0)
					{
						if (Reversed == 0)
						{
							Triangles[num] = new Triangle
							{
								a = V[num5] + IndexOffset,
								b = V[num4] + IndexOffset,
								c = V[num6] + IndexOffset
							};
						}
						else
						{
							Triangles[num] = new Triangle
							{
								c = V[num5] + IndexOffset,
								b = V[num4] + IndexOffset,
								a = V[num6] + IndexOffset
							};
						}
						num++;
						int num7 = num4;
						for (int k = num4 + 1; k < num2; k++)
						{
							V[num7] = V[k];
							num7++;
						}
						num2--;
						num3 = 2 * num2;
					}
				}
				if (b == 1)
				{
					for (int l = 0; l < Triangles.Length; l++)
					{
						Triangle triangle = Triangles[l];
						Triangles[l] = new Triangle
						{
							a = triangle.c,
							b = triangle.b,
							c = triangle.a
						};
					}
				}
			}

			public void Execute()
			{
				Triangulate(IndexOffset, Reversed, Points, Triangles, V);
			}

			private static float Area(ref NativeArray<float2> points)
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
				if (!(math.determinant(math.float2x2(c - b, p - b)) >= 0f) || !(math.determinant(math.float2x2(b - a, p - a)) >= 0f) || !(math.determinant(math.float2x2(a - c, p - c)) >= 0f))
				{
					return 0;
				}
				return 1;
			}

			private static byte Snip(int u, int v, int w, int n, ref NativeArray<float2> points, ref NativeArray<int> V)
			{
				float2 a = points[V[u]];
				float2 b = points[V[v]];
				float2 c = points[V[w]];
				if (1.1920929E-07f > (b.x - a.x) * (c.y - a.y) - (b.y - a.y) * (c.x - a.x))
				{
					return 0;
				}
				for (int i = 0; i < n; i++)
				{
					if (i != u && i != v && i != w)
					{
						float2 p = points[V[i]];
						if (InsideTriangle(a, b, c, p) != 0)
						{
							return 0;
						}
					}
				}
				return 1;
			}
		}

		public const Allocator DefaultAllocator = Allocator.TempJob;

		public unsafe static int[] Triangulate(float2[] points, bool reversed, int indexOffset = 0)
		{
			if (points.Length < 3)
			{
				throw new ArgumentException($"Cannot triangulate with a point count of: {points.Length}");
			}
			using NativeArray<float2> points2 = new NativeArray<float2>(points, Allocator.TempJob);
			using NativeArray<TriangulatorJob.Triangle> triangles = new NativeArray<TriangulatorJob.Triangle>(points.Length - 2, Allocator.TempJob);
			using NativeArray<int> v = new NativeArray<int>(points.Length, Allocator.TempJob);
			new TriangulatorJob
			{
				Points = points2,
				Reversed = ((!reversed) ? ((byte)1) : ((byte)0)),
				Triangles = triangles,
				IndexOffset = indexOffset,
				V = v
			}.Run();
			return triangles.Reinterpret<int>(sizeof(TriangulatorJob.Triangle)).ToArray();
		}

		public unsafe static NativeArray<int> Triangulate(NativeArray<float2> points, bool reversed, int indexOffset = 0)
		{
			if (points.Length < 3)
			{
				throw new ArgumentException($"Cannot triangulate with a point count of: {points.Length}");
			}
			NativeArray<TriangulatorJob.Triangle> triangles = new NativeArray<TriangulatorJob.Triangle>(points.Length - 2, Allocator.TempJob);
			using (NativeArray<int> v = new NativeArray<int>(points.Length, Allocator.TempJob))
			{
				new TriangulatorJob
				{
					Points = points,
					Reversed = ((!reversed) ? ((byte)1) : ((byte)0)),
					Triangles = triangles,
					IndexOffset = indexOffset,
					V = v
				}.Run();
			}
			return triangles.Reinterpret<int>(sizeof(TriangulatorJob.Triangle));
		}
	}
}
