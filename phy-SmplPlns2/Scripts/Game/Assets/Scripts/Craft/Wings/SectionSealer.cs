using System;
using System.Text;
using Assets.Scripts.Craft.MeshGen;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public static class SectionSealer
	{
		[BurstCompile]
		internal struct SectionSealerJob : IJob
		{
			internal struct Point
			{
				public int correspond;

				public float2 position;

				public bool used;

				public Point(float2 pos)
				{
					position = pos;
					used = false;
					correspond = -1;
				}

				public Point(Point other)
				{
					this = other;
				}

				public override string ToString()
				{
					return $"{position.x}:{position.y}:1:{correspond}:{(used ? 1 : 0)}";
				}
			}

			[ReadOnly]
			public float MaxDistForCorrelation;

			[ReadOnly]
			public CrossSection SectionA;

			[ReadOnly]
			public CrossSection SectionB;

			public NativeMesh Mesh;

			private const float ParallelLinesEpsilon = 0.0001f;

			public void Execute()
			{
				CrossSection sectionA = SectionA;
				CrossSection sectionB = SectionB;
				if (Hint.Unlikely(sectionA.Points.Length < 3 || sectionB.Points.Length < 3))
				{
					return;
				}
				using NativeList<Point> nativeList = new NativeList<Point>(sectionA.Points.Length + 8, Allocator.Temp);
				using NativeList<Point> nativeList2 = new NativeList<Point>(sectionB.Points.Length + 8, Allocator.Temp);
				InputToPoints(SectionA, SectionB, nativeList, nativeList2);
				if (MaxDistForCorrelation != 0f)
				{
					MatchColocatedPoints(nativeList, nativeList2, MaxDistForCorrelation);
				}
				RemoveDegenerates(nativeList, nativeList2, 0.0001f);
				using NativeList<float2> nativeList3 = new NativeList<float2>(32, Allocator.Temp);
				while (RunTrace(nativeList, nativeList2, nativeList3))
				{
					TriangulatePoints(nativeList3, SectionA, Mesh);
					nativeList3.Clear();
				}
			}

			[BurstDiscard]
			internal static string CheckCorresponds(NativeList<Point> a, NativeList<Point> b, float epsilon)
			{
				for (int i = 0; i < a.Length; i++)
				{
					int correspond = a[i].correspond;
					if (correspond != -1)
					{
						if (correspond < 0 || correspond > b.Length)
						{
							return $"Out of bounds on A: {correspond} at {i}";
						}
						int correspond2 = b[correspond].correspond;
						if (correspond2 != i)
						{
							return $"Mismatched on A at {i} -> {correspond} -> {correspond2}";
						}
						if (math.any(math.abs(a[i].position - b[correspond].position) > epsilon))
						{
							return $"Not colocated on A at {i} -> {correspond}: {a[i].position.ShortStr()} -> {b[i].position.ShortStr()}";
						}
					}
				}
				for (int j = 0; j < b.Length; j++)
				{
					int correspond3 = b[j].correspond;
					if (correspond3 != -1)
					{
						if (correspond3 < 0 || correspond3 > a.Length)
						{
							return $"Out of bounds on B: {correspond3} at {j}";
						}
						int correspond4 = a[correspond3].correspond;
						if (correspond4 != j)
						{
							return $"Mismatched on B at {j} -> {correspond3} -> {correspond4}";
						}
						if (math.any(math.abs(a[j].position - b[correspond3].position) > epsilon))
						{
							return $"Not colocated on A at {j} -> {correspond3}: {a[j].position.ShortStr()} -> {b[j].position.ShortStr()}";
						}
					}
				}
				return "OK";
			}

			internal static bool ClosestIntersect(Point a, Point b, NativeList<Point> shape, out float2 pos, out int hitA, out int hitB)
			{
				bool flag = false;
				float num = 0f;
				int i = 0;
				hitA = 0;
				hitB = 0;
				int a2;
				int b2;
				while (IterLines(ref i, shape, out a2, out b2))
				{
					if ((a.correspond == -1 || (a.correspond != a2 && a.correspond != b2)) && (b.correspond == -1 || (b.correspond != a2 && b.correspond != b2)) && IntersectionT(a.position, b.position, shape[a2].position, shape[b2].position, out var t) && (!flag || t < num))
					{
						flag = true;
						num = t;
						hitA = a2;
						hitB = b2;
					}
				}
				if (flag)
				{
					pos = math.lerp(a.position, b.position, num);
				}
				else
				{
					pos = default(float2);
				}
				return flag;
			}

			[BurstDiscard]
			internal static string Dump(NativeList<Point> a, NativeList<Point> b)
			{
				StringBuilder s = new StringBuilder();
				DumpList(a);
				s.Append(';');
				DumpList(b);
				return s.ToString();
				void DumpList(NativeList<Point> l)
				{
					bool flag = false;
					for (int i = 0; i < l.Length; i++)
					{
						if (flag)
						{
							s.Append('|');
						}
						else
						{
							flag = true;
						}
						s.Append(l[i].ToString());
					}
				}
			}

			[BurstDiscard]
			internal static string DumpCoords(NativeList<float2> buffer, StringBuilder s)
			{
				s.Append('[');
				for (int i = 0; i < buffer.Length; i++)
				{
					if (i != 0)
					{
						s.Append(',');
					}
					s.Append("float2(");
					s.Append(buffer[i].x);
					s.Append(',');
					s.Append(buffer[i].y);
					s.Append(')');
				}
				s.Append("], ");
				return s.ToString();
			}

			internal unsafe static void InputToPoints(CrossSection inputA, CrossSection inputB, NativeList<Point> pointsA, NativeList<Point> pointsB)
			{
				float2 float5 = float.NaN;
				for (int i = 0; i < inputA.Points.Length; i++)
				{
					Assets.Scripts.Craft.Wings.Point point = inputA.Points[i];
					if (!math.all(point.Position == float5))
					{
						pointsA.Add(new Point(point.Position));
						float5 = point.Position;
					}
				}
				float5 = float.NaN;
				for (int num = inputB.Points.Length - 1; num >= 0; num--)
				{
					Assets.Scripts.Craft.Wings.Point point2 = inputB.Points[num];
					if (!math.all(point2.Position == float5))
					{
						pointsB.Add(new Point(point2.Position));
						float5 = point2.Position;
					}
				}
				NativeList<Assets.Scripts.Craft.Wings.Point> points = inputA.Points;
				NativeList<Assets.Scripts.Craft.Wings.Point> sb = inputB.Points;
				Point* pa = pointsA.GetUnsafePtr();
				Point* pb = pointsB.GetUnsafePtr();
				int num2 = 0;
				for (int j = 0; j < points.Length; j++)
				{
					int sharedPointID = points[j].SharedPointID;
					int sharedPointID2 = sb[num2].SharedPointID;
					if (sharedPointID == -1 || sharedPointID < sharedPointID2)
					{
						j++;
					}
					else if (sharedPointID2 == -1 || sharedPointID2 < sharedPointID)
					{
						num2++;
					}
					else
					{
						LinkPoints(j++, num2++);
					}
				}
				unsafe void LinkPoints(int a, int b)
				{
					b = sb.Length - 1 - b;
					pa[a].correspond = b;
					pb[b].correspond = a;
				}
			}

			internal unsafe static void InsertPoint(Point point, int index, NativeList<Point> into, NativeList<Point> otherList, ref Point* pRef)
			{
				if (index == into.Length)
				{
					into.Add(in point);
					return;
				}
				Point* unsafePtr = into.GetUnsafePtr();
				ulong num = (ulong)(long)(IntPtr)(unsafePtr + index);
				ulong num2 = (ulong)(long)(IntPtr)(unsafePtr + into.Length);
				ulong num3 = (ulong)(long)(IntPtr)pRef;
				into.InsertRangeWithBeginEnd(index, index + 1);
				into[index] = point;
				if (num3 < num2 && num3 >= num)
				{
					pRef++;
				}
				Point* unsafePtr2 = otherList.GetUnsafePtr();
				for (int i = 0; i < otherList.Length; i++)
				{
					if (unsafePtr2[i].correspond >= index)
					{
						unsafePtr2[i].correspond++;
					}
				}
			}

			internal static bool IntersectionT(float2 a1, float2 a2, float2 b1, float2 b2, out float t)
			{
				float2 a3 = a2 - a1;
				float invSqMag = 1f / math.lengthsq(a3);
				float2 float5 = Transform(b1);
				float2 float6 = Transform(b2);
				float2 float7 = float6 - float5;
				if (math.abs(float7.y) < 0.0001f || math.sign(float5.y) == math.sign(float6.y))
				{
					t = 0f;
					return false;
				}
				t = float5.y / (0f - float7.y) * float7.x + float5.x;
				if (t >= 0f)
				{
					return t <= 1f;
				}
				return false;
				float2 Transform(float2 p)
				{
					p -= a1;
					return invSqMag * math.float2(p.x * a3.x + p.y * a3.y, p.y * a3.x - p.x * a3.y);
				}
			}

			internal unsafe static bool IterLines(ref int i, NativeList<Point> points, out int a, out int b)
			{
				Point* unsafePtr = points.GetUnsafePtr();
				while (i + 1 < points.Length)
				{
					a = i++;
					if (!unsafePtr[a].used)
					{
						b = a + 1;
						return true;
					}
				}
				a = points.Length - 1;
				b = 0;
				if (i++ == points.Length)
				{
					return false;
				}
				if (!unsafePtr[a].used)
				{
					return true;
				}
				return false;
			}

			internal static void MatchColocatedPoints(NativeList<Point> points1, NativeList<Point> points2, float distance)
			{
				for (int i = 0; i < points1.Length; i++)
				{
					Point value = points1[i];
					if (value.correspond != -1)
					{
						continue;
					}
					for (int j = 0; j < points2.Length; j++)
					{
						Point value2 = points2[j];
						if (value2.correspond == -1 && math.all(math.abs(value.position - value2.position) < distance))
						{
							value.correspond = j;
							value2.correspond = i;
							points1[i] = value;
							points2[j] = value2;
							break;
						}
					}
				}
			}

			internal unsafe static void RemoveDegenerates(NativeList<Point> points1, NativeList<Point> points2, float parallel_epsilon)
			{
				int i = 0;
				int a;
				int b;
				while (IterLines(ref i, points1, out a, out b))
				{
					int correspond = points1[a].correspond;
					int correspond2 = points1[b].correspond;
					if (correspond != -1 && correspond2 != -1 && (correspond2 + 1) % points2.Length == correspond)
					{
						points1[a] = new Point(points1[a])
						{
							used = true
						};
						points2[correspond2] = new Point(points2[correspond2])
						{
							used = true
						};
					}
				}
				Point* unsafePtr = points1.GetUnsafePtr();
				points1.GetUnsafePtr();
				i = 0;
				int a2;
				int b2;
				while (IterLines(ref i, points1, out a2, out b2))
				{
					if (unsafePtr[b2].correspond != -1)
					{
						int correspond3 = unsafePtr[b2].correspond;
						int d = (correspond3 + 1) % points2.Length;
						if (TestPair(a2, b2, correspond3, d, points1, points2, parallel_epsilon))
						{
							continue;
						}
					}
					if (unsafePtr[a2].correspond != -1)
					{
						int correspond4 = unsafePtr[a2].correspond;
						int num = correspond4 - 1;
						if (num == -1)
						{
							num += points2.Length;
						}
						TestPair(num, correspond4, a2, b2, points2, points1, parallel_epsilon);
					}
				}
				unsafe static bool TestPair(int num2, int num3, int c, int num4, NativeList<Point> list, NativeList<Point> list2, float epsilon)
				{
					Point* unsafePtr2 = list.GetUnsafePtr();
					Point* unsafePtr3 = list2.GetUnsafePtr();
					Point* ptr = unsafePtr2 + num2;
					Point* ptr2 = unsafePtr2 + num3;
					Point* ptr3 = unsafePtr3 + c;
					Point* ptr4 = unsafePtr3 + num4;
					float2 x = ptr4->position - ptr3->position;
					float2 float5 = ptr2->position - ptr->position;
					float num5 = math.length(x);
					float num6 = math.length(float5);
					if (math.abs(math.dot(x, float5) / (num5 * num6) + 1f) < epsilon)
					{
						if (num6 < num5)
						{
							ptr->used = true;
							ptr3->position = ptr->position;
							ptr3->correspond = num2;
							ptr->correspond = c;
						}
						else
						{
							ptr3->used = true;
							ptr2->position = ptr4->position;
							ptr2->correspond = num4;
							ptr4->correspond = num3;
						}
						return true;
					}
					return false;
				}
			}

			internal unsafe static bool RunTrace(NativeList<Point> p1, NativeList<Point> p2, NativeList<float2> buffer)
			{
				int i;
				for (i = 0; i < p1.Length && p1[i].used; i++)
				{
				}
				if (i == p1.Length)
				{
					return false;
				}
				Point* ptr = p1.GetUnsafePtr() + i;
				buffer.Add(in ptr->position);
				int endIdx = (i + 1) % p1.Length;
				TraceRecurse(i, endIdx, p1, p2, ptr, buffer);
				return true;
			}

			internal unsafe static void TraceRecurse(int startIdx, int endIdx, NativeList<Point> shape, NativeList<Point> otherShape, Point* terminateAt, NativeList<float2> result, bool canEditStart = true)
			{
				Point* unsafePtr = shape.GetUnsafePtr();
				Point* ptr = unsafePtr + startIdx;
				Point* ptr2 = unsafePtr + endIdx;
				if (ClosestIntersect(*ptr, *ptr2, otherShape, out var pos, out var _, out var hitB))
				{
					result.Add(in pos);
					Point point = otherShape[hitB];
					otherShape[hitB] = new Point(otherShape[hitB])
					{
						position = pos,
						used = true
					};
					InsertPoint(point, hitB + 1, otherShape, shape, ref terminateAt);
					if (canEditStart)
					{
						ptr->position = pos;
						ptr->correspond = hitB;
						otherShape[hitB] = new Point(otherShape[hitB])
						{
							correspond = startIdx
						};
					}
					else
					{
						Point point2 = new Point(pos);
						point2.correspond = hitB;
						InsertPoint(point2, endIdx, shape, otherShape, ref terminateAt);
						otherShape[hitB] = new Point(otherShape[hitB])
						{
							correspond = endIdx
						};
					}
					TraceRecurse(hitB, hitB + 1, otherShape, shape, terminateAt, result, canEditStart: false);
					return;
				}
				if (canEditStart)
				{
					ptr->used = true;
				}
				result.Add(in ptr2->position);
				Point* unsafePtr2 = otherShape.GetUnsafePtr();
				if (ptr2->correspond != -1)
				{
					Point* ptr3 = unsafePtr2 + ptr2->correspond;
					if (ptr3 == terminateAt)
					{
						result.Length--;
						return;
					}
					if (!ptr3->used)
					{
						int endIdx2 = (ptr2->correspond + 1) % otherShape.Length;
						TraceRecurse(ptr2->correspond, endIdx2, otherShape, shape, terminateAt, result);
						return;
					}
				}
				if (!ptr2->used)
				{
					int num = (endIdx + 1) % shape.Length;
					if (unsafePtr + num == terminateAt)
					{
						ptr2->used = true;
					}
					else
					{
						TraceRecurse(endIdx, num, shape, otherShape, terminateAt, result);
					}
				}
			}

			internal static void TriangulatePoints(NativeList<float2> points, CrossSection sectionRef, NativeMesh mesh)
			{
				int length = mesh.Vertices.Length;
				for (int i = 0; i < points.Length; i++)
				{
					mesh.Vert(sectionRef.SliceToMeshPos(points[i]));
				}
				Triangulator.TriangulatorJob.Triangulate(points.AsArray(), mesh.Triangles, length, reversed: false, allowReverse: true);
			}
		}

		public static void SealSections(CrossSection sectionA, CrossSection sectionB, MeshBuilder mesh, float correlationDistance = 1E-05f)
		{
			new SectionSealerJob
			{
				SectionA = sectionA,
				SectionB = sectionB,
				Mesh = mesh,
				MaxDistForCorrelation = correlationDistance
			}.Run();
		}
	}
}
