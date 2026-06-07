using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings;
using Jundroo.Common.Extensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;

namespace Assets.Scripts.Craft.Parts.Fuselage
{
	[BurstCompile]
	public struct FuselageJob : IJob
	{
		private struct FuselageMeshGenerator
		{
			private const int SubmeshExterior = 0;

			private const int SubmeshFront = 1;

			private const int SubmeshRear = 2;

			private const int SubmeshInside = 3;

			private NativeList<Point> _currentPoints;

			private FuselageJob _job;

			private NativeList<Point> _lastPoints;

			private float3x3 _lastToMesh;

			private float _lastZ;

			public FuselageMeshGenerator(FuselageJob job, NativeList<Point> aPoints, NativeList<Point> bPoints)
			{
				this = default(FuselageMeshGenerator);
				_job = job;
				_lastPoints = aPoints;
				_currentPoints = bPoints;
			}

			public void GenerateBody(Span<SectionParams> sections, Span<float3> slicePositions)
			{
				Span<float2> span = stackalloc float2[4];
				Span<float2> span2 = stackalloc float2[4];
				float start = 0f;
				float end = 0f;
				int num = sections.Length - 1;
				bool flag = false;
				for (int i = 0; i < sections.Length; i++)
				{
					float3 float5 = slicePositions[i];
					bool num2 = i != 0 && float5.z >= 0f;
					bool flag2 = !num2;
					bool flag3 = num2 && !flag;
					flag = num2;
					Span<float2> attachPoints = (flag2 ? span : (flag3 ? span2 : Span<float2>.Empty));
					ref SectionParams sec = ref sections[i];
					float3 pos = slicePositions[i];
					bool fill = i == 0 || i == num;
					AddSection(in sec, pos, attachPoints, out var minSlicing, i != 0, fill, i == num, addPoints: true, 0, addMass: true);
					if (i == 0)
					{
						_job.MinSlicing[0] = minSlicing;
					}
					else if (i == num)
					{
						_job.MinSlicing[1] = minSlicing;
					}
					if (flag2)
					{
						start = float5.z;
					}
					else if (flag3)
					{
						end = float5.z;
					}
				}
				UpdateAttachPoints(span, span2, math.unlerp(start, end, 0f));
			}

			public void GenerateCone(Span<SectionParams> sections, Span<float3> slicePositions)
			{
				bool noseconeSharp = _job.NoseconeSharp;
				_ = sections.Length;
				int num = (noseconeSharp ? sections.Length : (sections.Length - 1));
				for (int i = 0; i < num; i++)
				{
					ref SectionParams sec = ref sections[i];
					float3 pos = slicePositions[i];
					Span<float2> empty = Span<float2>.Empty;
					bool fill = i == 0;
					AddSection(in sec, pos, empty, out var minSlicing, i != 0, fill, fillReverse: false, addPoints: true, 0, addMass: true);
					if (i == 0)
					{
						_job.MinSlicing[0] = minSlicing;
					}
				}
				if (!noseconeSharp)
				{
					UmbrellaFill(slicePositions[slicePositions.Length - 1]);
				}
				_job.AttachPointPositions[0] = _job.SectionPositions[0];
			}

			public void GenerateHollowCone(Span<SectionParams> sections, Span<float3> slicePositions)
			{
				bool noseconeSharp = _job.NoseconeSharp;
				_ = sections.Length;
				Span<SectionParams> span = stackalloc SectionParams[sections.Length];
				Span<float3> span2 = stackalloc float3[sections.Length];
				span2[0] = slicePositions[0];
				sections[0].AbsoluteThickness = true;
				span[0] = sections[0].Inner;
				float inset = span[0].Inset;
				float3 float5 = math.normalizesafe(slicePositions[0] - slicePositions[slicePositions.Length - 1]);
				for (int i = 1; i < sections.Length - 1; i++)
				{
					float num = (float)i / (float)sections.Length;
					float num2 = num * inset;
					span2[i] = slicePositions[i] + num2 * float5;
					SectionParams inner = sections[i].Inner;
					inner.Inset = inset * math.sqrt(1f - num * num);
					span[i] = inner;
				}
				span[span.Length - 1] = sections[sections.Length - 1];
				span2[span2.Length - 1] = slicePositions[slicePositions.Length - 1] + float5 * inset;
				if (span2[span2.Length - 1].z < span2[span2.Length - 2].z)
				{
					span2[span2.Length - 1] = span2[span2.Length - 2];
				}
				if (noseconeSharp)
				{
					AddSection(in span[span.Length - 1], span2[span2.Length - 1], joinback: false, fill: false, fillReverse: false, addPoints: true);
					AddSection(in span[span.Length - 2], span2[span2.Length - 2], joinback: true, fill: false, fillReverse: false, addPoints: false, 3);
				}
				else
				{
					AddSection(in span[span.Length - 2], span2[span2.Length - 2], joinback: false, fill: false, fillReverse: false, addPoints: true);
					UmbrellaFill(span2[span2.Length - 1], 3, addMass: false, reverse: true);
				}
				for (int num3 = sections.Length - 3; num3 >= 0; num3--)
				{
					AddSection(in span[num3], span2[num3], joinback: true, fill: false, fillReverse: false, addPoints: false, 3);
				}
				MakeSharp();
				AddSection(in sections[0], slicePositions[0], Span<float2>.Empty, out var minSlicing, joinback: true, fill: false, fillReverse: false, addPoints: false, 2, addMass: false, math.back());
				_job.MinSlicing[0] = minSlicing;
				MakeSharp();
				int num4 = (noseconeSharp ? sections.Length : (sections.Length - 1));
				for (int j = 1; j < num4; j++)
				{
					AddSection(in sections[j], slicePositions[j], joinback: true, fill: false, fillReverse: false, addPoints: false, 0, addMass: true);
				}
				if (!noseconeSharp)
				{
					UmbrellaFill(slicePositions[slicePositions.Length - 1]);
				}
				_job.AttachPointPositions[0] = _job.SectionPositions[0];
			}

			public void GenerateHollow(Span<SectionParams> sections, Span<float3> slicePositions)
			{
				Span<float2> span = stackalloc float2[4];
				Span<float2> span2 = stackalloc float2[4];
				float start = 0f;
				float end = 0f;
				int num = sections.Length - 1;
				bool flag = false;
				for (int i = 0; i < sections.Length; i++)
				{
					float3 float5 = slicePositions[i];
					bool num2 = i != 0 && float5.z >= 0f;
					bool flag2 = !num2;
					bool flag3 = num2 && !flag;
					flag = num2;
					Span<float2> attachPoints = (flag2 ? span : (flag3 ? span2 : Span<float2>.Empty));
					AddSection(in sections[i], slicePositions[i], attachPoints, out var minSlicing, i != 0, fill: false, fillReverse: false, addPoints: true, 0, addMass: true);
					if (i == 0)
					{
						_job.MinSlicing[0] = minSlicing;
					}
					else if (i == num)
					{
						_job.MinSlicing[1] = minSlicing;
					}
					if (flag2)
					{
						start = float5.z;
					}
					else if (flag3)
					{
						end = float5.z;
					}
				}
				UpdateAttachPoints(span, span2, math.unlerp(start, end, 0f));
				if (math.all(sections[num].Size >= 0f))
				{
					MakeSharp();
					AddSection(sections[num].Inner, slicePositions[num], joinback: true, fill: false, fillReverse: false, addPoints: false, 1, addMass: true, math.forward());
				}
				MakeSharp();
				for (int num3 = num - 1; num3 > 0; num3--)
				{
					AddSection(sections[num3].Inner, slicePositions[num3], joinback: true, fill: false, fillReverse: false, addPoints: false, 3);
				}
				if (math.all(sections[0].Size > 0f))
				{
					AddSection(sections[0].Inner, slicePositions[0], joinback: true, fill: false, fillReverse: false, addPoints: false, 3);
					MakeSharp();
					AddSection(in sections[0], slicePositions[0], joinback: true, fill: false, fillReverse: false, addPoints: false, 2, addMass: false, math.back());
				}
				else
				{
					AddSection(in sections[0], slicePositions[0], joinback: true, fill: false, fillReverse: false, addPoints: false, 3);
				}
			}

			public readonly void UpdateAttachPoints(Span<float2> mid)
			{
				NativeArray<float3> attachPointPositions = _job.AttachPointPositions;
				NativeArray<float3> sectionPositions = _job.SectionPositions;
				attachPointPositions[0] = sectionPositions[sectionPositions.Length - 1];
				attachPointPositions[1] = _job.SectionPositions[0];
				for (int i = 0; i < 4; i++)
				{
					attachPointPositions[i + 2] = math.float3(mid[i], 0f);
				}
			}

			public readonly void UpdateAttachPoints(Span<float2> a, Span<float2> b, float t)
			{
				if (math.isnan(t))
				{
					t = 0f;
				}
				NativeArray<float3> attachPointPositions = _job.AttachPointPositions;
				attachPointPositions[0] = _job.SectionPositions[0];
				NativeArray<float3> sectionPositions = _job.SectionPositions;
				attachPointPositions[1] = sectionPositions[sectionPositions.Length - 1];
				for (int i = 0; i < 4; i++)
				{
					attachPointPositions[i + 2] = math.float3(math.lerp(a[i], b[i], t), 0f);
				}
			}

			private void AddSection(in SectionParams sec, float3 pos, bool joinback = false, bool fill = false, bool fillReverse = false, bool addPoints = false, int joinSubmesh = 0, bool addMass = false, float3? overrideNormal = null)
			{
				AddSection(in sec, pos, Span<float2>.Empty, out var _, joinback, fill, fillReverse, addPoints, joinSubmesh, addMass, overrideNormal);
			}

			private void AddSection(in SectionParams sec, float3 pos, Span<float2> attachPoints, out float4 minSlicing, bool joinback = false, bool fill = false, bool fillReverse = false, bool addPoints = false, int joinSubmesh = 0, bool addMass = false, float3? overrideNormal = null)
			{
				float3x3 pointToMesh = GetTransform(pos);
				GenerateSection(_currentPoints, in sec, attachPoints);
				NativeSlice<Point> nativeSlice = _currentPoints.AsArray();
				float2 float5 = -sec.HalfSize;
				float2 float6 = sec.HalfSize;
				for (int i = 0; i < nativeSlice.Length; i++)
				{
					float5 = math.min(float5, nativeSlice[i].Position);
					float6 = math.max(float6, nativeSlice[i].Position);
				}
				minSlicing = math.float4(((sec.HalfSize - float6) / sec.Size).yx, ((float5 + sec.HalfSize) / sec.Size).yx);
				minSlicing = math.select(minSlicing, 0f, math.isnan(minSlicing));
				if (joinback || addPoints)
				{
					_job.AddPointsToMesh(nativeSlice, in pointToMesh);
				}
				if (joinback)
				{
					_job.Mesh.SetRunMaterial(joinSubmesh);
					JoinSections(_lastPoints.AsArray(), nativeSlice, _job.Mesh, _lastToMesh, pointToMesh, pos.z < _lastZ, overrideNormal);
					if (addMass)
					{
						_job.CalculateSectionMass(_lastPoints.AsArray(), in _lastToMesh, nativeSlice, in pointToMesh, applyVolume: true);
					}
				}
				if (fill)
				{
					int submeshId = (fillReverse ? 1 : 2);
					FillPoints(nativeSlice, in pointToMesh, in _job.Mesh, fillReverse, submeshId);
				}
				NativeList<Point> currentPoints = _currentPoints;
				NativeList<Point> lastPoints = _lastPoints;
				_lastPoints = currentPoints;
				_currentPoints = lastPoints;
				_currentPoints.Clear();
				_lastToMesh = pointToMesh;
				_lastZ = pos.z;
			}

			private readonly float3x3 GetTransform(float3 pos)
			{
				return new float3x3(math.right(), math.up(), pos);
			}

			private void MakeSharp()
			{
				_job.AddPointsToMesh(_lastPoints.AsArray(), in _lastToMesh);
			}

			private void UmbrellaFill(float3 pos, int submesh = 0, bool addMass = false, bool reverse = false)
			{
				float3 c = _lastToMesh.c2;
				float3 float5 = pos - c;
				float num = math.length(float5);
				if (num < 0.01f)
				{
					float5 = math.forward();
				}
				else
				{
					float5 /= num;
				}
				if (reverse)
				{
					float5 = -float5;
				}
				NativeMesh mesh = _job.Mesh;
				mesh.SetRunMaterial(submesh);
				int y = mesh.Vert(new Vertex
				{
					position = pos,
					normal = float5
				});
				NativeArray<Point> nativeArray = _lastPoints.AsArray();
				for (int i = 0; i < nativeArray.Length; i++)
				{
					Point point = nativeArray[i];
					Point point2 = nativeArray[(i + 1) % nativeArray.Length];
					int3 int5 = math.int3(point.MeshIndices.y, y, point2.MeshIndices.x);
					int5 = (reverse ? int5.zyx : int5);
					mesh.Tri(int5);
				}
				if (addMass)
				{
					float4 item = CalculateSectionStats(nativeArray, _lastToMesh, _job.CuttingPlanesForMass).Area;
					_job.AreaVolumeOut[0] += item;
				}
				float num2 = (reverse ? (-1f) : 1f);
				for (int j = 0; j < nativeArray.Length; j++)
				{
					Point point3 = nativeArray[j];
					float3 x = pos - math.mul(_lastToMesh, math.float3(point3.Position, 1f));
					x *= num2;
					float3 y2 = math.mul(_lastToMesh, math.float3(point3.Tangent, 0f));
					float3 float6 = math.normalizesafe(math.cross(x, y2));
					Vertex value = mesh.Vertices[point3.MeshIndices.x];
					value.normal = math.normalizesafe(value.normal + float6);
					mesh.Vertices[point3.MeshIndices.x] = value;
					if (point3.Sharp)
					{
						y2 = math.mul(_lastToMesh, math.float3(point3.TangentB, 0f));
						float6 = math.normalizesafe(math.cross(x, y2));
						value = mesh.Vertices[point3.MeshIndices.y];
						value.normal = math.normalizesafe(value.normal + float6, value.normal);
						mesh.Vertices[point3.MeshIndices.y] = value;
					}
				}
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct LineCrossingComparer : IComparer<(int PointIndex, float TangentPos)>
		{
			public readonly int Compare((int PointIndex, float TangentPos) x, (int PointIndex, float TangentPos) y)
			{
				return x.TangentPos.CompareTo(y.TangentPos);
			}
		}

		public NativeArray<float4> AreaVolumeOut;

		public NativeArray<float3> AttachPointPositions;

		public NativeReference<MinMaxAABB> BoundsOut;

		public int ColliderCornerSamples;

		public NativeList<ColliderOut> ColliderOutput;

		public NativeList<int3> ColliderTriangles;

		public FuselageColliderType ColliderType;

		public NativeList<float3> ColliderVertices;

		public NativeArray<float4> CuttingPlanesForMass;

		public float MaxEdgeRotationPerSlice;

		public NativeMesh Mesh;

		public int MinInterpSlices;

		public NativeArray<float4> MinSlicing;

		public bool NoseconeSharp;

		public int NumColliders;

		public NativeArray<float3> SectionPositions;

		public NativeArray<SectionParams> Sections;

		public FuselageStyle Style;

		private static readonly float2x2[] CornerTransform = new float2x2[4]
		{
			new float2x2(0f, -1f, 1f, 0f),
			new float2x2(1f, 0f, 0f, 1f),
			new float2x2(0f, 1f, -1f, 0f),
			new float2x2(-1f, 0f, 0f, -1f)
		};

		private const int Corners = 4;

		private static int AngleToCorner(float angleRadians)
		{
			return (math.clamp((int)(angleRadians * 4f / (MathF.PI * 2f)), 0, 3) + 1) % 4;
		}

		private static float CornerToAngle(int corner)
		{
			return MathUtils.Repeat(((float)corner - 0.5f) * (MathF.PI * 2f) * 0.25f, MathF.PI * 2f);
		}

		private static int GetMaxX(NativeArray<Point> points)
		{
			int result = 0;
			float num = points[0].Position.x;
			for (int i = 1; i < points.Length; i++)
			{
				float x = points[i].Position.x;
				if (x > num)
				{
					result = i;
					num = x;
				}
			}
			return result;
		}

		private static void ColliderPointsTo3D(NativeArray<float2> pointsIn, NativeList<float3> pointsOut, float3 offset)
		{
			for (int i = 0; i < pointsIn.Length; i++)
			{
				pointsOut.Add(offset + math.float3(pointsIn[i], 0f));
			}
		}

		private static void FanFill(int baseIndex, int count, NativeList<int3> triangles, bool reverse)
		{
			for (int i = 1; i < count - 1; i++)
			{
				triangles.Add(reverse ? new int3(baseIndex, baseIndex + i, baseIndex + i + 1) : new int3(baseIndex + i + 1, baseIndex + i, baseIndex));
			}
		}

		private static void Dedupe2d(NativeList<float2> points)
		{
			using NativeList<float2> nativeList = new NativeList<float2>(points.Length, Allocator.Temp);
			float2 float5 = points[points.Length - 1];
			for (int i = 0; i < points.Length; i++)
			{
				float2 value = points[i];
				if (math.lengthsq(value - float5) > 6E-45f)
				{
					nativeList.Add(in value);
				}
				float5 = value;
			}
			if (nativeList.Length == 0)
			{
				points.Length = 1;
				return;
			}
			points.Clear();
			points.AddRange(nativeList.AsArray());
		}

		private static void Convexify2d(NativeArray<Point> pointsIn, NativeList<float2> pointsOut)
		{
			int maxX = GetMaxX(pointsIn);
			pointsOut.Clear();
			float2 value = pointsIn[maxX].Position;
			pointsOut.Add(in value);
			float2 value2 = pointsIn[(maxX + 1) % pointsIn.Length].Position;
			for (int i = 2; i < pointsIn.Length + 1; i++)
			{
				float2 position = pointsIn[(i + maxX) % pointsIn.Length].Position;
				float2 y = (value2 - value).yx * math.float2(-1f, 1f);
				if (math.dot(position - value2, y) > 0f)
				{
					value2 = position;
					continue;
				}
				pointsOut.Add(in value2);
				value = value2;
				value2 = position;
			}
			Dedupe2d(pointsOut);
		}

		private static float LineCastIn(NativeArray<float2> shape, float2 origin, float2 direction)
		{
			float x = float.PositiveInfinity;
			float num = 0f;
			for (int i = 0; i < shape.Length; i++)
			{
				float2 float5 = shape[i];
				float2 x2 = shape[(i + 1) % shape.Length] - float5;
				if (!(math.lengthsq(x2) < 1.1920929E-07f))
				{
					float2 x3 = math.float2(x2.y, 0f - x2.x);
					float num2 = math.dot(x3, float5);
					float num3 = math.dot(x3, direction);
					float y = (num2 - math.dot(x3, origin)) / num3;
					if (num3 < -1.1920929E-07f)
					{
						x = math.min(x, y);
					}
					else if (num3 > 1.1920929E-07f)
					{
						num = math.max(num, y);
					}
				}
			}
			return num;
		}

		private static bool LineCastOut(NativeArray<float2> shape, float2 origin, float2 direction, out int i1, out float t)
		{
			float num = 0f;
			float2x2 a = math.float2x2(direction.yx, direction * math.float2(-1f, 1f));
			for (i1 = 0; i1 < shape.Length; i1++)
			{
				int index = (i1 + 1) % shape.Length;
				num += math.length(shape[index] - shape[i1]);
				float2 float5 = math.mul(a, shape[i1] - origin);
				float2 float6 = math.mul(a, shape[index] - origin);
				if (float5.x <= 0f && float6.x > 0f)
				{
					t = math.unlerp(float5.x, float6.x, 0f);
					return math.lerp(float5.y, float6.y, t) > 0f;
				}
			}
			if (num <= float.Epsilon)
			{
				i1 = 0;
				t = 0f;
				return false;
			}
			i1 = -1;
			t = -1f;
			return false;
		}

		private static bool SplitSectionOfOuterCollider(NativeArray<float2> outer, float startAngle, float endAngle, float2 startPoint, float2 endPoint, NativeList<float2> result)
		{
			float2 direction = default(float2);
			math.sincos(startAngle, out direction.x, out direction.y);
			LineCastOut(outer, startPoint, direction, out var i, out var t);
			int num = (i + 1) % outer.Length;
			if (i == -1)
			{
				return false;
			}
			if (t < 0.99f)
			{
				if (t > 0.01f)
				{
					result.Add(math.lerp(outer[i], outer[num], t));
				}
				else
				{
					result.Add(outer[i]);
				}
			}
			math.sincos(endAngle, out direction.x, out direction.y);
			LineCastOut(outer, endPoint, direction, out var i2, out t);
			if (i2 == -1)
			{
				return false;
			}
			if (i2 != i)
			{
				for (int num2 = num; num2 != i2; num2 = (num2 + 1) % outer.Length)
				{
					result.Add(outer[num2]);
				}
				result.Add(outer[i2]);
			}
			if (t > 0.01f)
			{
				int index = (i2 + 1) % outer.Length;
				if (t < 0.99f)
				{
					result.Add(math.lerp(outer[i2], outer[index], t));
				}
				else
				{
					result.Add(outer[index]);
				}
			}
			result.Add(in endPoint);
			result.Add(in startPoint);
			Dedupe2d(result);
			return true;
		}

		private static float2 Intersect(float2 n1, float2 n2, float v1, float v2)
		{
			return math.mul(math.inverse(math.float2x2(n1.x, n1.y, n2.x, n2.y)), math.float2(v1, v2));
		}

		private static bool MakeInnerShape(NativeArray<float2> internalSection, NativeArray<float2> externalSection, Span<float2> normals, Span<float> outPlaneValues, Span<float> outEdgeLengths)
		{
			int numColliders = normals.Length;
			Span<float> span = stackalloc float[numColliders];
			Span<float2> span2 = stackalloc float2[numColliders];
			Span<float> span3 = stackalloc float[numColliders];
			Span<float2> span4 = stackalloc float2[numColliders];
			for (int i = 0; i < numColliders; i++)
			{
				float2 x = normals[i];
				float num = float.NegativeInfinity;
				for (int j = 0; j < internalSection.Length; j++)
				{
					num = math.max(num, math.dot(x, internalSection[j]));
				}
				span[i] = num;
			}
			for (int k = 0; k < numColliders; k++)
			{
				int index = Next(k);
				span2[k] = Intersect(normals[k], normals[index], span[k], span[index]);
			}
			Span<bool> span5 = stackalloc bool[numColliders];
			int num2 = -1;
			int num3 = 0;
			float2 y = span2[span2.Length - 1];
			for (int l = 0; l < numColliders; l++)
			{
				float2 obj = span2[l];
				bool flag = math.distancesq(obj, y) < 1.1920929E-07f;
				span5[l] = flag;
				y = obj;
				if (flag)
				{
					num3++;
				}
				else
				{
					num2 = l;
				}
			}
			if (span5.Length - num3 < 3)
			{
				return false;
			}
			Span<int> span6 = stackalloc int[numColliders];
			Span<int> span7 = stackalloc int[numColliders];
			int num4 = Prev(num2);
			for (int m = 0; m < numColliders; m++)
			{
				int num5 = (num2 + m) % numColliders;
				span7[num5] = num4;
				if (!span5[Next(num5)])
				{
					num4 = num5;
				}
			}
			int num6 = num2;
			for (int num7 = numColliders - 1; num7 >= 0; num7--)
			{
				int num8 = (num2 + num7) % numColliders;
				span6[num8] = num6;
				if (!span5[num8])
				{
					num6 = num8;
				}
			}
			for (int n = 0; n < numColliders; n++)
			{
				float2 float5 = span2[n];
				float2 inVec = float5 - span2[span7[n]];
				float2 outVec = span2[span6[n]] - float5;
				float num9 = SimpleInset.ComputePointShrinkage(inVec, outVec);
				float2 float6 = SimpleInset.ComputePointVelocity(num9, inVec);
				span3[n] = num9;
				span4[n] = float6;
			}
			float num10 = 0f;
			for (int num11 = 0; num11 < numColliders; num11++)
			{
				float y2 = LineCastIn(externalSection, span2[num11], span4[num11]);
				num10 = math.max(num10, y2);
			}
			for (int num12 = 0; num12 < numColliders; num12++)
			{
				int index2 = Prev(num12);
				outPlaneValues[num12] = span[num12] - num10;
				outEdgeLengths[num12] = math.distance(span2[index2], span2[num12]) - (span3[index2] + span3[num12]) * num10;
			}
			return true;
			int Next(int num13)
			{
				return (num13 + 1) % numColliders;
			}
			int Prev(int num13)
			{
				return (num13 - 1 + numColliders) % numColliders;
			}
		}

		private static void MakeColliderSegment(NativeArray<float2> convex, float2 planeNormal, float planeValue, NativeList<float2> output)
		{
			Span<float> span = stackalloc float[convex.Length];
			for (int i = 0; i < convex.Length; i++)
			{
				span[i] = math.dot(convex[i], planeNormal) - planeValue;
			}
			for (int j = 0; j < convex.Length; j++)
			{
				float num = span[j];
				float num2 = span[(j + 1) % convex.Length];
				bool num3 = num >= 0f;
				bool flag = num2 >= 0f;
				if (num3)
				{
					output.Add(convex[j]);
				}
				if (num3 != flag)
				{
					float t = math.unlerp(num, num2, 0f);
					output.Add(math.lerp(convex[j], convex[(j + 1) % convex.Length], t));
				}
			}
		}

		private readonly SectionParams GetColliderSection(Index index)
		{
			NativeArray<SectionParams> sections = Sections;
			SectionParams result = sections[index.GetOffset(sections.Length)];
			result.CornerSamples = ColliderCornerSamples;
			result.EdgeSamples = ColliderCornerSamples;
			return result;
		}

		private readonly void GenerateInteriorSectionsForCollider(NativeList<float2> convexA, NativeList<float2> convexB)
		{
			using NativeList<Point> points = new NativeList<Point>(ColliderCornerSamples * 4, Allocator.Temp);
			SectionParams section = GetColliderSection(0);
			if (section.AbsoluteThickness)
			{
				GenerateSection(points, in section, Span<float2>.Empty);
				section = section.Inner;
				Inset(points, in section);
			}
			else
			{
				GenerateSection(points, section.Inner, Span<float2>.Empty);
			}
			Convexify2d(points.AsArray(), convexA);
			points.Clear();
			section = GetColliderSection(^1);
			if (section.AbsoluteThickness)
			{
				GenerateSection(points, in section, Span<float2>.Empty);
				section = section.Inner;
				Inset(points, in section);
			}
			else
			{
				GenerateSection(points, section.Inner, Span<float2>.Empty);
			}
			Convexify2d(points.AsArray(), convexB);
		}

		private readonly void GenerateSectionsForCollider(NativeList<float2> convexA, NativeList<float2> convexB)
		{
			using NativeList<Point> points = new NativeList<Point>(ColliderCornerSamples * 4, Allocator.Temp);
			GenerateSection(points, GetColliderSection(0), Span<float2>.Empty);
			Convexify2d(points.AsArray(), convexA);
			points.Clear();
			GenerateSection(points, GetColliderSection(^1), Span<float2>.Empty);
			Convexify2d(points.AsArray(), convexB);
		}

		private void GenerateHollowCollider()
		{
			if (ColliderCornerSamples == 0 || NumColliders == 0)
			{
				return;
			}
			if (NumColliders < 3)
			{
				GenerateSolidCollider();
				return;
			}
			int numColliders = NumColliders;
			float num = MathF.PI * 2f / (float)numColliders;
			float num2 = MathF.PI % num;
			Span<float2> normals = stackalloc float2[numColliders];
			Span<float2> normals2 = stackalloc float2[numColliders];
			float2 float5 = default(float2);
			for (int i = 0; i < numColliders; i++)
			{
				math.sincos((float)i * num + num2, out float5.x, out float5.y);
				normals[i] = ColliderAngleWithTrapezium(float5, Sections[0]);
				ref float2 reference = ref normals2[i];
				float2 normal = float5;
				ref NativeArray<SectionParams> sections = ref Sections;
				reference = ColliderAngleWithTrapezium(normal, sections[sections.Length - 1]);
			}
			Span<float> outPlaneValues = stackalloc float[numColliders];
			Span<float> outPlaneValues2 = stackalloc float[numColliders];
			Span<float> span = stackalloc float[numColliders];
			Span<float> span2 = stackalloc float[numColliders];
			NativeList<float2> convexA = new NativeList<float2>(ColliderCornerSamples * 4, Allocator.Temp);
			NativeList<float2> convexB = new NativeList<float2>(ColliderCornerSamples * 4, Allocator.Temp);
			GenerateSectionsForCollider(convexA, convexB);
			NativeList<float2> convexA2 = new NativeList<float2>(numColliders, Allocator.Temp);
			NativeList<float2> convexB2 = new NativeList<float2>(numColliders, Allocator.Temp);
			GenerateInteriorSectionsForCollider(convexA2, convexB2);
			MakeInnerShape(convexA2.AsArray(), convexA.AsArray(), normals, outPlaneValues, span);
			MakeInnerShape(convexB2.AsArray(), convexB.AsArray(), normals2, outPlaneValues2, span2);
			float num3 = Max(span);
			float num4 = Max(span2);
			NativeArray<float2> convex = convexA.AsArray();
			NativeArray<float2> convex2 = convexB.AsArray();
			using (NativeList<float2> output = new NativeList<float2>(ColliderCornerSamples * 4, Allocator.Temp))
			{
				using NativeList<float2> output2 = new NativeList<float2>(ColliderCornerSamples * 4, Allocator.Temp);
				ColliderOutput.EnsureFreeCapacity(numColliders);
				for (int j = 0; j < numColliders; j++)
				{
					if (!(span[j] < num3 * 0.001f) || !(span2[j] < num4 * 0.001f))
					{
						ColliderOut value = new ColliderOut
						{
							BaseTriangle = ColliderTriangles.Length,
							BaseVertex = ColliderVertices.Length
						};
						output.Clear();
						output2.Clear();
						MakeColliderSegment(convex, normals[j], outPlaneValues[j], output);
						MakeColliderSegment(convex2, normals2[j], outPlaneValues2[j], output2);
						ColliderPointsTo3D(output.AsArray(), ColliderVertices, SectionPositions[0]);
						NativeArray<float2> pointsIn = output2.AsArray();
						NativeList<float3> colliderVertices = ColliderVertices;
						ref NativeArray<float3> sectionPositions = ref SectionPositions;
						ColliderPointsTo3D(pointsIn, colliderVertices, sectionPositions[sectionPositions.Length - 1]);
						FanFill(0, output.Length, ColliderTriangles, reverse: true);
						FanFill(output.Length, output2.Length, ColliderTriangles, reverse: false);
						JoinColliderSections(output.AsArray(), output2.AsArray());
						value.VertexCount = ColliderVertices.Length - value.BaseVertex;
						value.TriangleCount = ColliderTriangles.Length - value.BaseTriangle;
						ColliderOutput.AddNoResize(value);
					}
				}
			}
			static float2 ColliderAngleWithTrapezium(float2 float6, SectionParams section)
			{
				if (math.abs(section.Size.y) < 1.1920929E-07f)
				{
					return float6;
				}
				float num5 = section.Size.x / section.Size.y;
				float6.y -= math.abs(float6.x) * section.Trapezium * num5;
				return math.normalize(float6);
			}
			static float Max(Span<float> span3)
			{
				float num5 = float.NaN;
				for (int k = 0; k < span3.Length; k++)
				{
					num5 = math.max(num5, span3[k]);
				}
				return num5;
			}
		}

		private void GenerateSolidCollider()
		{
			if (ColliderCornerSamples == 0)
			{
				return;
			}
			using NativeList<float2> convexA = new NativeList<float2>(ColliderCornerSamples * 4, Allocator.Temp);
			using NativeList<float2> convexB = new NativeList<float2>(ColliderCornerSamples * 4, Allocator.Temp);
			GenerateSectionsForCollider(convexA, convexB);
			ColliderOut value = new ColliderOut
			{
				BaseTriangle = ColliderTriangles.Length,
				BaseVertex = ColliderVertices.Length,
				VertexCount = convexA.Length + convexB.Length
			};
			ColliderPointsTo3D(convexA.AsArray(), ColliderVertices, SectionPositions[0]);
			NativeArray<float2> pointsIn = convexB.AsArray();
			NativeList<float3> colliderVertices = ColliderVertices;
			ref NativeArray<float3> sectionPositions = ref SectionPositions;
			ColliderPointsTo3D(pointsIn, colliderVertices, sectionPositions[sectionPositions.Length - 1]);
			FanFill(0, convexA.Length, ColliderTriangles, reverse: true);
			FanFill(convexA.Length, convexB.Length, ColliderTriangles, reverse: false);
			JoinColliderSections(convexA.AsArray(), convexB.AsArray());
			value.TriangleCount = ColliderTriangles.Length - value.BaseTriangle;
			ColliderOutput.Add(in value);
		}

		private readonly void JoinColliderSections(NativeArray<float2> convexA, NativeArray<float2> convexB)
		{
			JoinColliderSections(convexA, convexB, convexA.Length, convexB.Length);
		}

		private readonly void JoinColliderSections(NativeArray<float2> convexA, NativeArray<float2> convexB, int proportionalAfterA, int proportionalAfterB)
		{
			NativeList<int3> colliderTriangles = ColliderTriangles;
			int num = 0;
			int num2 = 0;
			float2 float5 = convexA[0];
			float2 float6 = convexB[0];
			int num3 = 0;
			int num4 = 0;
			while (num < convexA.Length || num2 < convexB.Length)
			{
				bool flag;
				if (num == convexA.Length)
				{
					flag = false;
				}
				else if (num2 == convexB.Length)
				{
					flag = true;
				}
				else if (num >= proportionalAfterA || num2 >= proportionalAfterB)
				{
					if (num < proportionalAfterA)
					{
						flag = true;
					}
					else if (num2 < proportionalAfterB)
					{
						flag = false;
					}
					else if (num3 > num4)
					{
						flag = false;
						num4++;
					}
					else
					{
						flag = true;
						num3++;
					}
				}
				else
				{
					float2 obj = convexA[(num + 1) % convexA.Length];
					float2 float7 = convexB[(num2 + 1) % convexB.Length];
					float2 y = (obj - float5).yx * math.float2(-1f, 1f);
					flag = math.dot(float7 - float6, y) < 0f;
				}
				if (flag)
				{
					int index = (num + 1) % convexA.Length;
					int num5 = num2 % convexB.Length;
					colliderTriangles.Add(new int3(num, convexA.Length + num5, (num + 1) % convexA.Length));
					float5 = convexA[index];
					num++;
				}
				else
				{
					int num6 = (num2 + 1) % convexB.Length;
					int x = num % convexA.Length;
					colliderTriangles.Add(new int3(x, convexA.Length + num2, convexA.Length + num6));
					float6 = convexB[num6];
					num2++;
				}
			}
		}

		unsafe void IJob.Execute()
		{
			int num = 0;
			SectionParams* unsafePtr = (SectionParams*)Sections.GetUnsafePtr();
			bool flag = false;
			for (int i = 0; i < Sections.Length; i++)
			{
				ref SectionParams reference = ref unsafePtr[i];
				ClampCornerRadii(ref reference);
				num = math.max(math.csum(reference.CornerSamples) + math.csum(reference.EdgeSamples), num);
				flag &= reference.IsAllSharpCorners;
			}
			using NativeList<Point> aPoints = new NativeList<Point>(num, Allocator.Temp);
			using NativeList<Point> bPoints = new NativeList<Point>(num, Allocator.Temp);
			int num2 = RequiredIntermediateSlices(in *unsafePtr, in unsafePtr[1]);
			Span<SectionParams> sections = stackalloc SectionParams[num2 + 2];
			Span<float3> slicePositions = stackalloc float3[num2 + 2];
			sections[0] = Sections[0];
			slicePositions[0] = SectionPositions[0];
			ref SectionParams reference2 = ref sections[sections.Length - 1];
			ref NativeArray<SectionParams> sections2 = ref Sections;
			reference2 = sections2[sections2.Length - 1];
			ref float3 reference3 = ref slicePositions[slicePositions.Length - 1];
			ref NativeArray<float3> sectionPositions = ref SectionPositions;
			reference3 = sectionPositions[sectionPositions.Length - 1];
			for (int j = 0; j < num2; j++)
			{
				float t = (float)(j + 1) / (float)(num2 + 1);
				sections[j + 1] = InterpolateSection(t);
				slicePositions[j + 1] = InterpolatePosition(t);
			}
			FuselageMeshGenerator fuselageMeshGenerator = new FuselageMeshGenerator(this, aPoints, bPoints);
			switch (Style)
			{
			case FuselageStyle.Body:
				fuselageMeshGenerator.GenerateBody(sections, slicePositions);
				break;
			case FuselageStyle.Hollow:
				fuselageMeshGenerator.GenerateHollow(sections, slicePositions);
				break;
			case FuselageStyle.Cone:
				fuselageMeshGenerator.GenerateCone(sections, slicePositions);
				break;
			case FuselageStyle.HollowCone:
				fuselageMeshGenerator.GenerateHollowCone(sections, slicePositions);
				break;
			default:
				throw new NotImplementedException();
			}
			Mesh.SortSubmeshes();
			BoundsOut.Value = Mesh.CalculateAABB();
			switch (ColliderType)
			{
			case FuselageColliderType.SingleConvex:
				GenerateSolidCollider();
				break;
			case FuselageColliderType.ConvexSegments:
				GenerateHollowCollider();
				break;
			}
		}

		private static (float4 Area, float4 Perimeter) CalculateSectionStats(NativeSlice<Point> points, float3x3 transform, NativeArray<float4> planes)
		{
			float3 b;
			float3 b2;
			if (planes.Length <= 0)
			{
				(b, b2) = CalculateSectionStatsNoCutting(points.SliceWithStride<float2>(0));
			}
			else
			{
				float3x3 a = math.transpose(transform);
				NativeArray<float3> lines = new NativeArray<float3>(planes.Length, Allocator.Temp);
				for (int i = 0; i < planes.Length; i++)
				{
					float4 float5 = planes[i];
					float3 float6 = math.mul(a, float5.xyz);
					float3 float7 = math.float3(float6.xy, float5.w - float6.z);
					lines[i] = float7 / math.length(float7.xy);
				}
				(b, b2) = CalculateSectionStatsWithCutting(points.SliceWithStride<float2>(0), lines);
				lines.Dispose();
			}
			return (Area: math.float4(math.mul(transform, b), b.z), Perimeter: math.float4(math.mul(transform, b2), b2.z));
		}

		private static (float3 Area, float3 Perimeter) CalculateSectionStatsNoCutting(NativeSlice<float2> input)
		{
			float2 float5 = input[input.Length - 1];
			float3 item = 0f;
			float3 item2 = 0f;
			for (int i = 0; i < input.Length; i++)
			{
				float2 float6 = input[i];
				float3 float7 = math.float3(0.5f * (float6 + float5), 1f);
				item2 += math.length(float6 - float5) * float7;
				item += float7.y * (float6.x - float5.x) * float7;
				float5 = float6;
			}
			return (Area: item, Perimeter: item2);
		}

		private static (float3 Area, float3 Perimeter) CalculateSectionStatsWithCutting(NativeSlice<float2> input, NativeArray<float3> lines)
		{
			NativeList<float2> nativeList = new NativeList<float2>(input.Length * 2, Allocator.Temp);
			NativeList<sbyte> nativeList2 = new NativeList<sbyte>(input.Length * 2, Allocator.Temp);
			NativeList<int2> nativeList3 = new NativeList<int2>(input.Length * 2, Allocator.Temp);
			NativeList<int2> nativeList4 = new NativeList<int2>(input.Length * 2, Allocator.Temp);
			NativeList<(int, float)> list = new NativeList<(int, float)>(8, Allocator.Temp);
			NativeList<(int, float)> list2 = new NativeList<(int, float)>(8, Allocator.Temp);
			nativeList.Length = input.Length;
			input.CopyTo(nativeList.AsArray());
			for (int i = 0; i < nativeList.Length; i++)
			{
				nativeList3.AddNoResize(math.int2(i, (i + 1) % nativeList.Length));
			}
			for (int j = 0; j < lines.Length; j++)
			{
				float3 line = lines[j];
				float2 float5 = math.float2(0f - line.y, line.x);
				nativeList2.Clear();
				for (int k = 0; k < nativeList.Length; k++)
				{
					nativeList2.Add(Classify(nativeList[k]));
				}
				for (int l = 0; l < nativeList3.Length; l++)
				{
					int2 value = nativeList3[l];
					int num = nativeList2[value.x];
					int num2 = nativeList2[value.y];
					int num3 = num + num2;
					if (num3 < 0)
					{
						continue;
					}
					if (num != num2)
					{
						if (num3 == 0)
						{
							float2 obj = nativeList[value.x];
							float2 float6 = nativeList[value.y];
							float start = math.dot(obj, line.xy);
							float end = math.dot(float6, line.xy);
							float t = math.unlerp(start, end, line.z);
							float2 value2 = math.lerp(obj, float6, t);
							int length = nativeList.Length;
							nativeList.Add(in value2);
							nativeList2.Add((sbyte)0);
							float item = math.dot(float5, value2);
							if (num == 1)
							{
								value.y = length;
								list2.Add((length, item));
							}
							else
							{
								value.x = length;
								list.Add((length, item));
							}
						}
						else if (num == 0)
						{
							list.Add((value.x, math.dot(nativeList[value.x], float5)));
						}
						else
						{
							list2.Add((value.y, math.dot(nativeList[value.y], float5)));
						}
					}
					nativeList4.Add(in value);
				}
				list.Sort<(int, float), LineCrossingComparer>(default(LineCrossingComparer));
				list2.Sort<(int, float), LineCrossingComparer>(default(LineCrossingComparer));
				for (int m = 0; m < list.Length && m < list2.Length; m++)
				{
					nativeList4.Add(math.int2(list2[m].Item1, list[m].Item1));
				}
				nativeList3.Clear();
				NativeList<int2> nativeList5 = nativeList4;
				NativeList<int2> nativeList6 = nativeList3;
				nativeList3 = nativeList5;
				nativeList4 = nativeList6;
				list.Clear();
				list2.Clear();
				sbyte Classify(float2 p)
				{
					float num4 = math.dot(p, line.xy) - line.z;
					if (!(math.abs(num4) < 6E-45f))
					{
						if (!(num4 > 0f))
						{
							return -1;
						}
						return 1;
					}
					return 0;
				}
			}
			nativeList2.Dispose();
			nativeList4.Dispose();
			list.Dispose();
			list2.Dispose();
			float3 item2 = 0f;
			float3 item3 = 0f;
			for (int n = 0; n < nativeList3.Length; n++)
			{
				int2 int5 = nativeList3[n];
				float2 float7 = nativeList[int5.x];
				float2 float8 = nativeList[int5.y];
				float3 float9 = math.float3(0.5f * (float7 + float8), 1f);
				item3 += math.length(float8 - float7) * float9;
				item2 += float9.y * (float8.x - float7.x) * float9;
			}
			nativeList.Dispose();
			nativeList3.Dispose();
			return (Area: item2, Perimeter: item3);
		}

		private static void ClampCornerRadii(ref SectionParams section)
		{
			float4 maxCornerRadii = GetMaxCornerRadii(in section);
			section.CornerRadii = math.min(section.CornerRadii, maxCornerRadii);
		}

		[BurstDiscard]
		private static string DumpEdges(NativeList<int2> edges, NativeList<float2> points)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < edges.Length; i++)
			{
				int2 int5 = edges[i];
				float2 float5 = points[int5.x];
				float2 float6 = points[int5.y];
				stringBuilder.AppendLine($"{float5.x:F10}, {float5.y:F10}, {float6.x:F10}, {float6.y:F10}");
			}
			return stringBuilder.ToString();
		}

		private static void FillPoints(NativeSlice<Point> slice, in float3x3 faceToMesh, in NativeMesh mesh, bool reverseFaces, int submeshId)
		{
			float3 normal = math.normalizesafe(math.cross(faceToMesh.c0, faceToMesh.c1), math.forward()) * (reverseFaces ? 1f : (-1f));
			mesh.SetRunMaterial(submeshId);
			int length = mesh.Vertices.Length;
			for (int i = 0; i < slice.Length; i++)
			{
				mesh.Vert(new Vertex
				{
					position = math.mul(faceToMesh, math.float3(slice[i].Position, 1f)),
					normal = normal
				});
			}
			int length2 = mesh.Triangles.Length;
			Triangulator.TriangulatorJob.Triangulate(slice.SliceWithStride<float2>(0), mesh.Triangles, length, reverseFaces, allowReverse: false);
			if (mesh.Triangles.Length == length2)
			{
				mesh.SetRunMaterial(63);
				Geometry.fanfill(mesh, length, slice.Length, !reverseFaces);
			}
		}

		private static void JoinSections(NativeSlice<Point> secA, NativeSlice<Point> secB, NativeMesh mesh, float3x3 transformA, float3x3 transformB, bool reverseQuads, float3? overrideNormal = null)
		{
			NativeArray<int> nativeArray = new NativeArray<int>(secA.Length, Allocator.Temp);
			NativeArray<int> nativeArray2 = new NativeArray<int>(secB.Length, Allocator.Temp);
			FindClosestLinks(secA, secB, nativeArray);
			FindClosestLinks(secB, secA, nativeArray2);
			int num = 0;
			int num2 = nativeArray[num];
			int num3 = 0;
			int num4 = 0;
			while (num3 < secA.Length || num4 < secB.Length)
			{
				int num5 = (num + 1) % secA.Length;
				int num6 = (num2 + 1) % secB.Length;
				int2 meshIndices = secA[num].MeshIndices;
				int2 meshIndices2 = secB[num2].MeshIndices;
				int2 meshIndices3 = secA[num5].MeshIndices;
				int2 meshIndices4 = secB[num6].MeshIndices;
				if (num3 < secA.Length && (num4 == secB.Length || nativeArray2[num2] == num5 || nativeArray[num5] == num2))
				{
					bool flag = IsAfter(num5, nativeArray2[num2], secA.Length);
					mesh.Tri(meshIndices.y, flag ? meshIndices2.y : meshIndices2.x, meshIndices3.x);
					num = num5;
					num3++;
					continue;
				}
				if (num3 == secA.Length || nativeArray[num] == num6 || nativeArray2[num6] == num)
				{
					bool flag2 = IsAfter(num6, nativeArray[num], secB.Length);
					mesh.Tri(flag2 ? meshIndices.y : meshIndices.x, meshIndices2.y, meshIndices4.x);
					num2 = num6;
					num4++;
					continue;
				}
				if (reverseQuads)
				{
					mesh.Tri(meshIndices.y, meshIndices2.y, meshIndices4.x);
					mesh.Tri(meshIndices.y, meshIndices4.x, meshIndices3.x);
				}
				else
				{
					mesh.Tri(meshIndices.y, meshIndices2.y, meshIndices3.x);
					mesh.Tri(meshIndices3.x, meshIndices2.y, meshIndices4.x);
				}
				num = num5;
				num2 = num6;
				num3++;
				num4++;
			}
			if (overrideNormal.HasValue)
			{
				SetNormals(secA, overrideNormal.Value);
				SetNormals(secB, overrideNormal.Value);
			}
			else
			{
				UpdateNormals(secA, secB, nativeArray, transformA, transformB, 1f);
				UpdateNormals(secB, secA, nativeArray2, transformB, transformA, -1f);
			}
			nativeArray.Dispose();
			nativeArray2.Dispose();
			static void FindClosestLinks(NativeSlice<Point> p1, NativeSlice<Point> p2, NativeArray<int> l1)
			{
				int num7 = 0;
				for (int i = 0; i < p1.Length; i++)
				{
					float fraction = p1[i].Fraction;
					float num8 = 0f;
					bool flag3 = false;
					int num9 = 0;
					for (int j = -1; j < p2.Length + 1; j++)
					{
						int num10 = (num7 + j + p2.Length) % p2.Length;
						float num11 = math.abs(p2[num10].Fraction - fraction);
						num11 = math.min(num11, 1f - num11);
						if (j >= 0)
						{
							bool flag4 = num11 < num8;
							bool flag5 = num11 > num8;
							if (flag5 && flag3)
							{
								break;
							}
							flag3 = flag4 || (flag3 && !flag5);
						}
						num8 = num11;
						num9 = num10;
					}
					num7 = (l1[i] = num9);
				}
			}
			static bool IsAfter(int test, int against, int length)
			{
				int num7 = (test - against + length) % length;
				int num8 = (against - test + length) % length;
				return num7 < num8;
			}
			void SetNormals(NativeSlice<Point> section, float3 normal)
			{
				normal = math.normalizesafe(normal);
				for (int i = 0; i < section.Length; i++)
				{
					Point point = section[i];
					Vertex value = mesh.Vertices[point.MeshIndices.x];
					value.normal = normal;
					mesh.Vertices[point.MeshIndices.x] = value;
					if (point.Sharp)
					{
						value = mesh.Vertices[point.MeshIndices.y];
						value.normal = normal;
						mesh.Vertices[point.MeshIndices.y] = value;
					}
				}
			}
			void UpdateNormals(NativeSlice<Point> section, NativeSlice<Point> others, NativeArray<int> links, float3x3 a2, float3x3 a, float flip)
			{
				for (int i = 0; i < section.Length; i++)
				{
					Point point = section[i];
					float3 x = math.mul(a, math.float3(others[links[i]].Position, 1f)) - math.mul(a2, math.float3(point.Position, 1f));
					x *= flip;
					float3 y = math.mul(a2, math.float3(point.Tangent, 0f));
					float3 float5 = math.normalizesafe(math.cross(x, y));
					Vertex value = mesh.Vertices[point.MeshIndices.x];
					value.normal = math.normalizesafe(value.normal + float5);
					mesh.Vertices[point.MeshIndices.x] = value;
					if (point.Sharp)
					{
						y = math.mul(a2, math.float3(point.TangentB, 0f));
						float5 = math.normalizesafe(math.cross(x, y));
						value = mesh.Vertices[point.MeshIndices.y];
						value.normal = math.normalizesafe(value.normal + float5, value.normal);
						mesh.Vertices[point.MeshIndices.y] = value;
					}
				}
			}
		}

		private void AddPointsToMesh(NativeSlice<Point> points, in float3x3 pointToMesh)
		{
			NativeMesh mesh = Mesh;
			int2 meshIndices = default(int2);
			for (int i = 0; i < points.Length; i++)
			{
				Point value = points[i];
				float3 position = math.mul(pointToMesh, math.float3(value.Position, 1f));
				Vertex vertex = new Vertex
				{
					position = position
				};
				meshIndices.x = mesh.Vert(vertex);
				meshIndices.y = (value.Sharp ? mesh.Vert(vertex) : meshIndices.x);
				value.MeshIndices = meshIndices;
				points[i] = value;
			}
		}

		private void CalculateSectionMass(NativeSlice<Point> a, in float3x3 aPos, NativeSlice<Point> b, in float3x3 bPos, bool applyVolume)
		{
			(float4 Area, float4 Perimeter) tuple = CalculateSectionStats(a, aPos, CuttingPlanesForMass);
			float4 item = tuple.Area;
			float4 item2 = tuple.Perimeter;
			(float4 Area, float4 Perimeter) tuple2 = CalculateSectionStats(b, bPos, CuttingPlanesForMass);
			float4 item3 = tuple2.Area;
			float4 item4 = tuple2.Perimeter;
			float num = math.length(bPos.c2 - aPos.c2);
			float4 float5 = 0.5f * num * (item2 + item4);
			AreaVolumeOut[0] += float5;
			if (applyVolume)
			{
				float4 float6 = 0.5f * num * (item + item3);
				AreaVolumeOut[1] += float6;
			}
		}

		private void CalculateSliceMass(NativeSlice<Point> slice, in float3x3 pos)
		{
			float4 item = CalculateSectionStats(slice, pos, CuttingPlanesForMass).Area;
			AreaVolumeOut[0] += item;
		}

		private float3 InterpolatePosition(float t)
		{
			if (SectionPositions.Length == 2)
			{
				return math.lerp(SectionPositions[0], SectionPositions[1], t);
			}
			if (SectionPositions.Length == 3)
			{
				return MathUtils.Bezier(SectionPositions[0], SectionPositions[1], SectionPositions[2], t);
			}
			throw new NotSupportedException("Only linear (2 slices) and quadratic bezier (3 slices) are supported");
		}

		private unsafe SectionParams InterpolateSection(float t)
		{
			SectionParams* unsafePtr = (SectionParams*)Sections.GetUnsafePtr();
			if (Sections.Length == 2)
			{
				return SectionParams.Lerp(in *unsafePtr, in unsafePtr[1], t);
			}
			if (Sections.Length == 3)
			{
				return SectionParams.Bezier(in *unsafePtr, in unsafePtr[1], in unsafePtr[2], t);
			}
			throw new NotSupportedException("Only linear (2 slices) and quadratic bezier (3 slices) are supported");
		}

		private readonly int RequiredIntermediateSlices(in SectionParams a, in SectionParams b)
		{
			int x = ((!a.IsAllSharpCorners || !b.IsAllSharpCorners) ? 1 : 0);
			x = math.max(x, MinInterpSlices);
			Span<float2> corners = stackalloc float2[4];
			Span<float2> unscaledCorners = stackalloc float2[4];
			GetOutlineShape(unscaledCorners, corners, in a);
			float num = GetAngle(corners[1], corners[2]);
			GetOutlineShape(unscaledCorners, corners, in b);
			float num2 = math.abs(GetAngle(corners[1], corners[2]) - num);
			num2 = math.min(num2, MathF.PI * 2f - num2);
			int y = math.min(16, (int)(num2 / MaxEdgeRotationPerSlice));
			return math.max(x, y);
			static float GetAngle(float2 float7, float2 float6)
			{
				float2 float5 = float6 - float7;
				return math.atan2(float5.x, float5.y);
			}
		}

		public static float4 GetMaxCornerRadii(in SectionParams section, bool stretched)
		{
			return GetMaxCornerRadii(in section, stretched ? 1f : 0f);
		}

		public static float4 GetMaxCornerRadii(in SectionParams section, float? stretched = null)
		{
			Span<float2> corners = stackalloc float2[4];
			Span<float2> unscaledCorners = stackalloc float2[4];
			float4 result = 0f;
			GetOutlineShape(unscaledCorners, corners, in section);
			for (int i = 0; i < 4; i++)
			{
				_ = section.CornerRadii[i];
				float t = stretched ?? section.CornersStretch[i];
				float2 float5 = math.lerp(section.HalfSize, 1, t);
				_ = section.HalfSize / float5;
				float2 float6 = float5 * unscaledCorners[(i + 4 - 1) % 4];
				float2 float7 = float5 * unscaledCorners[i];
				float2 obj = float5 * unscaledCorners[(i + 1) % 4];
				float2 x = float7 - float6;
				float2 x2 = obj - float7;
				float x3 = math.length(x);
				float y = math.length(x2);
				float num = math.atan2(x.x, x.y);
				float num2 = (math.atan2(x2.x, x2.y) - num + MathF.PI * 2f) % (MathF.PI * 2f);
				float num3 = math.min(x3, y);
				float num4 = math.tan((MathF.PI - num2) * 0.5f);
				result[i] = num3 * 0.5f * num4;
			}
			return result;
		}

		private static void GenerateSection(NativeList<Point> points, in SectionParams section, Span<float2> attachPositions)
		{
			Span<float2> unscaledCorners = stackalloc float2[4];
			Span<float2> corners = stackalloc float2[4];
			GetOutlineShape(unscaledCorners, corners, in section);
			float4 float5 = 0;
			float4 float6 = 0;
			float6.x = MathF.PI / 2f;
			float6.z = 4.712389f;
			for (int i = 0; i < 4; i++)
			{
				float2 float7 = corners[i];
				float2 x = corners[(i + 1) % 4] - float7;
				float5[i] = math.length(x);
				if ((i & 1) == 1)
				{
					float6[i] = math.atan2(x.x, x.y);
				}
			}
			float4 float8 = (float6 + 4.712389f) % (MathF.PI * 2f);
			float4 cornerAngles = (float6 - float6.wxyz + MathF.PI * 2f) % (MathF.PI * 2f);
			float4 cornerStartAngle = float8.wxyz;
			float4 v = float8;
			float2x4 cornerCenter = default(float2x4);
			float2x4 cornerScaling = default(float2x4);
			float4 clampedCornerRadii = 0f;
			bool4 v2 = false;
			bool4 v3 = false;
			int j;
			for (j = 0; j < 4; j++)
			{
				if (section.CornerRadii[j] <= 0f)
				{
					cornerCenter[j] = corners[j];
					cornerScaling[j] = 1f;
				}
				else
				{
					GetCurveParams(j, unscaledCorners, in section, out cornerCenter[j], out IF(ref cornerAngles), out IF(ref cornerStartAngle), out IF(ref v), out cornerScaling[j], out IF(ref clampedCornerRadii), out IB(ref v2), out IB(ref v3));
				}
			}
			_ = v3 & v2.wxyz & (section.EdgeCurvature <= 0f);
			float4 float9 = math.saturate(section.EdgeCurvature);
			float4 float10 = float9.wxyz * 0.5f;
			float4 float11 = 1f - float9 * 0.5f;
			int k;
			for (k = 0; k < 4; k++)
			{
				float baseFrac = 0.25f * (float)k;
				if (clampedCornerRadii[k] <= 0f)
				{
					SamplePoint(k, float10[k], out var pos, out var tangent);
					SamplePoint(k, float11[k], out var _, out var tangent2);
					points.Add(new Point(pos, baseFrac + 0.0625f, tangent, tangent2));
				}
				else
				{
					int num = section.CornerSamples[k];
					float num2 = 1f / (float)(num - 1);
					points.EnsureFreeCapacity(num);
					AddPointNoResize(float10[k]);
					for (int l = 1; l < num - 1; l++)
					{
						float num3 = (float)l * num2;
						if (!(num3 <= float10[k] + 0.001f))
						{
							if (num3 >= float11[k] - 0.001f)
							{
								break;
							}
							AddPointNoResize(num3);
						}
					}
					if (float11[k] > float10[k] && (!v3[k] || !v2[(k + 1) % 4]))
					{
						AddPointNoResize(float11[k]);
					}
				}
				if (section.EdgeCurvature[k] > 0f && float5[k] > float.Epsilon)
				{
					int num4 = (k + 1) % 4;
					SamplePoint(k, float11[k], out var pos3, out var tangent3);
					SamplePoint(num4, float10[num4], out var pos4, out var tangent4);
					float2 y = math.float2(tangent4.y, 0f - tangent4.x);
					float num5 = math.dot(tangent3, y);
					float2 float12;
					if (math.abs(num5) < 0.001f)
					{
						float12 = 0.5f * (pos3 + pos4);
					}
					else
					{
						float num6 = math.dot(pos4 - pos3, y) / num5;
						float12 = pos3 + tangent3 * num6;
					}
					baseFrac += 0.125f;
					int num7 = section.EdgeSamples[k];
					if (num7 <= 3)
					{
						points.Add(new Point(float12, baseFrac + 0.0625f, tangent3, tangent4));
					}
					else
					{
						float num8 = 1f / (float)(num7 - 1);
						for (int m = 1; m < num7 - 1; m++)
						{
							float num9 = num8 * (float)m;
							float2 position = MathUtils.Bezier(pos3, float12, pos4, num9);
							float2 tangent5 = math.lerp(float12 - pos3, pos4 - float12, num9);
							points.Add(new Point(position, baseFrac + 0.125f * num9, tangent5));
						}
					}
					if (attachPositions.Length > k)
					{
						attachPositions[k] = MathUtils.Bezier(pos3, float12, pos4, 0.5f);
					}
				}
				else if (attachPositions.Length > k)
				{
					attachPositions[k] = 0.5f * (corners[k] + corners[(k + 1) % 4]);
				}
				void AddPointNoResize(float t)
				{
					SamplePoint(k, t, out var pos5, out var tangent6);
					points.AddNoResize(new Point(pos5, baseFrac + 0.125f * t, tangent6));
				}
			}
			Inset(points, in section);
			unsafe ref bool IB(ref bool4 reference)
			{
				fixed (bool4* ptr = &reference)
				{
					return ref *(bool*)((byte*)ptr + j);
				}
			}
			unsafe ref float IF(ref float4 reference)
			{
				fixed (float4* ptr = &reference)
				{
					return ref *(float*)((byte*)ptr + (nint)j * (nint)4);
				}
			}
			void SamplePoint(int corner, float t, out float2 reference2, out float2 reference)
			{
				float2 float13 = Vec(cornerStartAngle[corner] + t * cornerAngles[corner]);
				reference = math.float2(float13.y, 0f - float13.x) * cornerScaling[corner];
				reference2 = cornerCenter[corner] + clampedCornerRadii[corner] * float13;
				reference2 *= cornerScaling[corner];
			}
			static float2 Vec(float angle)
			{
				float2 result = default(float2);
				math.sincos(angle, out result.x, out result.y);
				return result;
			}
		}

		private static void GetCurveParams(int i, Span<float2> unscaledCorners, in SectionParams section, out float2 centre, out float angle, out float startAngle, out float endAngle, out float2 postScale, out float radius, out bool startMaxed, out bool endMaxed)
		{
			float2 float5 = math.lerp(section.HalfSize, 1, section.CornersStretch[i]);
			float2 float6 = float5 * unscaledCorners[(i + 4 - 1) % 4];
			float2 float7 = float5 * unscaledCorners[i];
			float2 obj = float5 * unscaledCorners[(i + 1) % 4];
			float2 x = float7 - float6;
			float2 x2 = obj - float7;
			float num = math.length(x);
			float num2 = math.length(x2);
			float num3 = math.atan2(x.x, x.y);
			float num4 = math.atan2(x2.x, x2.y);
			angle = (num4 - num3 + MathF.PI * 2f) % (MathF.PI * 2f);
			startAngle = (num3 + 4.712389f) % (MathF.PI * 2f);
			endAngle = (num4 + 4.712389f) % (MathF.PI * 2f);
			postScale = section.HalfSize / float5;
			postScale = math.select(postScale, 1f, math.isnan(postScale));
			float num5 = math.min(num, num2);
			float num6 = MathF.PI - angle;
			float num7 = math.tan(num6 * 0.5f);
			float x3 = num5 * 0.5f * num7;
			radius = math.min(x3, section.CornerRadii[i]);
			float num8 = radius / num7;
			startMaxed = num8 >= num * 0.4999f;
			endMaxed = num8 >= num2 * 0.4999f;
			float num9 = radius / math.sin(num6 * 0.5f);
			float2 float8 = default(float2);
			math.sincos(num4 + num6 * 0.5f, out float8.x, out float8.y);
			centre = float7 + num9 * float8;
		}

		private static void GetOutlineShape(Span<float2> unscaledCorners, Span<float2> corners, in SectionParams section)
		{
			for (int i = 0; i < 4; i++)
			{
				float2x2 float2x5 = CornerTransform[i];
				float2 float5 = float2x5.c0 + float2x5.c1;
				float5.x *= 1f + float5.y * section.Trapezium;
				unscaledCorners[i] = float5;
				corners[i] = float5 * section.HalfSize;
			}
		}

		private static void Inset(NativeList<Point> points, in SectionParams section, bool mergePoints = true)
		{
			if (section.Inset != 0f)
			{
				float value = math.cmin(section.Size) * 0.5f * 0.01f;
				SimpleInset.Inset(points, section.Inset, value, mergePoints);
			}
		}

		private static float2 SamplePoint(in SectionParams section, float angle)
		{
			angle = MathUtils.Repeat(angle, MathF.PI * 2f);
			int num = AngleToCorner(angle);
			float num2 = section.CornerRadii[num];
			Span<float2> unscaledCorners = stackalloc float2[4];
			Span<float2> corners = stackalloc float2[4];
			GetOutlineShape(unscaledCorners, corners, in section);
			if (num2 <= 0f)
			{
				return corners[num];
			}
			GetCurveParams(num, unscaledCorners, in section, out var centre, out var _, out var _, out var _, out var postScale, out var radius, out var _, out var _);
			float2 float5 = default(float2);
			math.sincos(angle, out float5.x, out float5.y);
			return postScale * (centre + float5 * radius);
		}
	}
}
