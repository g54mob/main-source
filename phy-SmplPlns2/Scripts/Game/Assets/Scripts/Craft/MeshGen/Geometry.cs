using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.MeshGen
{
	public static class Geometry
	{
		public struct Box
		{
			public float3 center;

			public float3 extents;

			public float3x3 rotation;

			public void draw(NativeMesh mesh)
			{
				float3 float5 = extents.x * rotation.c0;
				float3 float6 = extents.y * rotation.c1;
				float3 float7 = extents.z * rotation.c2;
				float3 float8 = center;
				mesh.Start();
				Span<float3> span = stackalloc float3[8];
				span[0] = float8 + float5 + float6 + float7;
				span[1] = float8 - float5 + float6 + float7;
				span[2] = float8 - float5 + float6 - float7;
				span[3] = float8 + float5 + float6 - float7;
				span[4] = float8 + float5 - float6 + float7;
				span[5] = float8 - float5 - float6 + float7;
				span[6] = float8 - float5 - float6 - float7;
				span[7] = float8 + float5 - float6 - float7;
				mesh.Quad(span[3], span[2], span[1], span[0]);
				mesh.Quad(span[4], span[5], span[6], span[7]);
				mesh.Quad(span[5], span[4], span[0], span[1]);
				mesh.Quad(span[7], span[6], span[2], span[3]);
				mesh.Quad(span[4], span[7], span[3], span[0]);
				mesh.Quad(span[2], span[6], span[5], span[1]);
			}
		}

		public struct Cylinder
		{
			public float3 centre;

			public float3 offset;

			public float3 discX;

			public float3 discY;

			public int samples;

			public void draw(NativeMesh mesh)
			{
				mesh.Start();
				float num = MathF.PI * 2f / (float)samples;
				float num2 = 0f;
				float3x2 disc = math.float3x2(discX, discY);
				float2 vec = math.float2(1f, 0f);
				float3 offset = this.offset;
				float3 centre = this.centre;
				int start = section();
				int num3 = start;
				for (int i = 1; i < samples; i++)
				{
					num2 += num;
					math.sincos(num2, out vec.y, out vec.x);
					num3 = section();
					fill(num3 - 4, num3);
				}
				fill(num3, start);
				void fill(int from, int to)
				{
					mesh.Tri(to, from + 2, from);
					mesh.Tri(to, to + 2, from + 2);
					if (from != start)
					{
						mesh.Tri(start + 1, to + 1, from + 1);
						mesh.Tri(start + 3, from + 3, to + 3);
					}
				}
				int section()
				{
					float3 float5 = math.mul(disc, vec);
					float3 float6 = centre + float5 + offset;
					int result = mesh.Vert(float6);
					mesh.Vert(float6);
					float6 = centre + float5 - offset;
					mesh.Vert(float6);
					mesh.Vert(float6);
					return result;
				}
			}
		}

		public struct LineBuilder
		{
			private int _lastTopIndex;

			private int _lastBottomIndex;

			private int _startIndex;

			private NativeMesh _mesh;

			public readonly bool HasStarted => _startIndex != -1;

			public readonly int LastTopIndex => _lastTopIndex;

			public readonly int LastBottomIndex => _lastBottomIndex;

			public LineBuilder(NativeMesh mesh)
			{
				_mesh = mesh;
				_lastTopIndex = 0;
				_lastBottomIndex = 0;
				_startIndex = -1;
				_mesh.Start();
			}

			public void AddSegment(float3 a, float3 b)
			{
				if (HasStarted)
				{
					int num = _mesh.Vert(a);
					int num2 = _mesh.Vert(b);
					_mesh.Quad(_lastTopIndex, num, num2, _lastBottomIndex);
					_lastTopIndex = num;
					_lastBottomIndex = num2;
				}
				else
				{
					_startIndex = (_lastTopIndex = _mesh.Vert(a));
					_lastBottomIndex = _mesh.Vert(b);
				}
			}

			public void CloseLoop()
			{
				if (HasStarted)
				{
					_mesh.Quad(_lastTopIndex, _startIndex, _startIndex + 1, _lastBottomIndex);
					_lastTopIndex = _startIndex;
					_lastBottomIndex = _startIndex + 1;
				}
			}
		}

		public struct QuadBarBuilder
		{
			private NativeMesh _mesh;

			private LineBuilder _ab;

			private LineBuilder _bc;

			private LineBuilder _cd;

			private LineBuilder _da;

			public QuadBarBuilder(NativeMesh mesh)
			{
				_mesh = mesh;
				_ab = new LineBuilder(mesh);
				_bc = new LineBuilder(mesh);
				_cd = new LineBuilder(mesh);
				_da = new LineBuilder(mesh);
			}

			public void AddSegment(float3 a, float3 b, float3 c, float3 d)
			{
				_ab.AddSegment(a, b);
				_bc.AddSegment(b, c);
				_cd.AddSegment(c, d);
				_da.AddSegment(d, a);
			}

			public void CloseLoop()
			{
				_ab.CloseLoop();
				_bc.CloseLoop();
				_cd.CloseLoop();
				_da.CloseLoop();
			}

			public readonly void EndCap()
			{
				NativeMesh mesh = _mesh;
				mesh.Quad(mesh.Vertices[mesh.CurrentOffset + _ab.LastTopIndex].position, mesh.Vertices[mesh.CurrentOffset + _ab.LastBottomIndex].position, mesh.Vertices[mesh.CurrentOffset + _cd.LastTopIndex].position, mesh.Vertices[mesh.CurrentOffset + _cd.LastBottomIndex].position);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Box box(float3 centre, float3 extents)
		{
			return new Box
			{
				center = centre,
				extents = extents,
				rotation = float3x3.identity
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Box box(float3 centre, float3 extents, quaternion rotation)
		{
			return new Box
			{
				center = centre,
				extents = extents,
				rotation = math.float3x3(rotation)
			};
		}

		public static Cylinder cylinder(float3 from, float3 to, float radius, int samples = 12)
		{
			Cylinder result = new Cylinder
			{
				offset = (to - from) * 0.5f,
				centre = (from + to) * 0.5f
			};
			makeortho(math.normalize(result.offset) * radius, out result.discX, out result.discY);
			result.samples = samples;
			return result;
		}

		public static void makeortho(float3 normal, out float3 vec1, out float3 vec2)
		{
			float3 x = math.right();
			if (math.abs(normal.x) > math.abs(normal.y))
			{
				x = math.up();
			}
			vec1 = math.cross(x, normal);
			vec2 = math.cross(vec1, math.normalize(normal));
		}

		public static void fanfill(NativeMesh mesh, bool reverse = false)
		{
			fanfill(mesh, 0, mesh.Vertices.Length - mesh.CurrentOffset, reverse);
		}

		public static void fanfill(NativeMesh mesh, int offset, int numPoints, bool reverse = false)
		{
			if (reverse)
			{
				for (int i = 2; i < numPoints; i++)
				{
					mesh.Tri(offset + i - 1, offset + i, offset);
				}
			}
			else
			{
				for (int j = 2; j < numPoints; j++)
				{
					mesh.Tri(offset + j - 1, offset, offset + j);
				}
			}
		}

		public static void extrudeSharp(NativeMesh mesh, NativeArray<float3> pointsA, NativeArray<float3> pointsB)
		{
			int num = math.min(pointsA.Length, pointsB.Length);
			float3 d = pointsA[num - 1];
			float3 a = pointsB[num - 1];
			for (int i = 0; i < num; i++)
			{
				float3 float5 = pointsA[i];
				float3 float6 = pointsB[i];
				mesh.Quad(a, float6, float5, d);
				d = float5;
				a = float6;
			}
		}

		public static void extrude(NativeMesh mesh, int offset1, int offset2, int numPoints)
		{
			int num = numPoints - 1;
			for (int i = 0; i < numPoints; i++)
			{
				mesh.Quad(offset2 + num, offset2 + i, offset1 + i, offset1 + num);
				num = i;
			}
		}
	}
}
