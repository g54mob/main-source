using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class MathUtil
	{
		private delegate float Vector2_3InputFloatReturnDelegate(Vector2 p1, Vector2 p2, Vector3 p3);

		public static bool Raycast(Ray ray, Vector3 TriangleV0, Vector3 TriangleV1, Vector3 TriangleV2, out float dist, bool excludeBackface = false)
		{
			Vector3 vector = TriangleV1 - TriangleV0;
			Vector3 vector2 = TriangleV2 - TriangleV0;
			Vector3 rhs = Vector3.Cross(ray.direction, vector2);
			float num = Vector3.Dot(vector, rhs);
			dist = 0f;
			if (num == 0f || (excludeBackface && num < 0f))
			{
				return false;
			}
			float num2 = 1f / num;
			Vector3 lhs = ray.origin - TriangleV0;
			float num3 = Vector3.Dot(lhs, rhs) * num2;
			if (num3 < 0f || (double)num3 > 1.0)
			{
				return false;
			}
			Vector3 rhs2 = Vector3.Cross(lhs, vector);
			float num4 = Vector3.Dot(ray.direction, rhs2) * num2;
			if (num4 < 0f || num3 + num4 > 1f)
			{
				return false;
			}
			dist = Vector3.Dot(vector2, rhs2) * num2;
			return true;
		}

		public static bool Raycast(Ray ray, Vector3[] RectangleVert, out float dist)
		{
			dist = 0f;
			if (RectangleVert.Length != 4)
			{
				return false;
			}
			if (Raycast(ray, RectangleVert[0], RectangleVert[1], RectangleVert[2], out dist))
			{
				return true;
			}
			if (Raycast(ray, RectangleVert[0], RectangleVert[2], RectangleVert[3], out dist))
			{
				return true;
			}
			return false;
		}

		public static bool Intersect2DEdgeToAABB(AABB aabb, Vector2 p0, Vector2 p1)
		{
			float x = p0.x;
			float x2 = p1.x;
			if (p0.x > p1.x)
			{
				x = p1.x;
				x2 = p0.x;
			}
			if (x2 > aabb.max.x)
			{
				x2 = aabb.max.x;
			}
			if (x < aabb.min.x)
			{
				x = aabb.min.x;
			}
			if (x > x2)
			{
				return false;
			}
			float num = p0.y;
			float num2 = p1.y;
			float num3 = p1.x - p0.x;
			if ((double)Mathf.Abs(num3) > 1E-07)
			{
				float num4 = (p1.y - p0.y) / num3;
				float num5 = p0.y - num4 * p0.x;
				num = num4 * x + num5;
				num2 = num4 * x2 + num5;
			}
			if (num > num2)
			{
				float num6 = num2;
				num2 = num;
				num = num6;
			}
			if (num2 > aabb.max.y)
			{
				num2 = aabb.max.y;
			}
			if (num < aabb.min.y)
			{
				num = aabb.min.y;
			}
			if (num > num2)
			{
				return false;
			}
			return true;
		}

		public static void Swap<T>(ref T value0, ref T value1)
		{
			T val = value0;
			value0 = value1;
			value1 = val;
		}

		public static PlaneEx ComputePlane(List<Vector3> positions)
		{
			List<Vertex> list = new List<Vertex>();
			for (int i = 0; i < positions.Count; i++)
			{
				list.Add(new Vertex(positions[i]));
			}
			return ComputePlane(list);
		}

		public static PlaneEx ComputePlane(List<Vertex> vertices)
		{
			List<IndexPair> list = new List<IndexPair>();
			for (int i = 0; i < vertices.Count; i++)
			{
				list.Add(new IndexPair(i, (i + 1) % vertices.Count));
			}
			return ComputePlane(vertices, list);
		}

		public static PlaneEx ComputePlane(List<Vertex> vertices, List<IndexPair> edges)
		{
			if (vertices.Count < 3)
			{
				return null;
			}
			int num = -1;
			for (int i = 0; i < 3; i++)
			{
				if (Mathf.Abs(vertices[0].pos[i] - vertices[1].pos[i]) > 0.0001f)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return null;
			}
			float num2 = 3E+10f;
			int num3 = -1;
			for (int j = 0; j < vertices.Count; j++)
			{
				if (vertices[j].pos[num] < num2)
				{
					num2 = vertices[j].pos[num];
					num3 = j;
				}
			}
			if (num3 == -1)
			{
				return null;
			}
			List<IndexPair> list = new List<IndexPair>();
			FindEdgesWithVertexIndex(num3, edges, list);
			if (list.Count != 2)
			{
				return null;
			}
			return new PlaneEx(vertices[list[0].i0].pos, vertices[list[0].i1].pos, vertices[list[1].i1].pos);
		}

		public static void FindEdgesWithVertexIndex(int idx, List<IndexPair> edges, List<IndexPair> out_pairs)
		{
			for (int i = 0; i < edges.Count; i++)
			{
				IndexPair indexPair = edges[i];
				if (indexPair.i1 == idx)
				{
					out_pairs.Insert(0, indexPair);
				}
				else if (indexPair.i0 == idx)
				{
					out_pairs.Add(indexPair);
				}
			}
		}

		public static float GetHandleSize(Vector3 position, Matrix4x4 worldToLocal, float pixelSize)
		{
			Camera current = Camera.current;
			if (current == null)
			{
				return 20f;
			}
			Transform transform = current.transform;
			Vector3 vector = worldToLocal.MultiplyPoint(transform.position);
			float z = Vector3.Dot(position - vector, transform.TransformDirection(new Vector3(0f, 0f, 1f)));
			Vector3 vector2 = current.WorldToScreenPoint(vector + transform.TransformDirection(new Vector3(0f, 0f, z)));
			Vector3 vector3 = current.WorldToScreenPoint(vector + transform.TransformDirection(new Vector3(1f, 0f, z)));
			float magnitude = (vector2 - vector3).magnitude;
			return pixelSize / Mathf.Max(magnitude, 0.0001f);
		}

		public static float DistanceOnScreen(Vector3 pos0, Vector3 pos1)
		{
			Camera current = Camera.current;
			if (current == null)
			{
				return 0f;
			}
			Matrix4x4 matrix4x = ((UMContext.activeModeler == null) ? Matrix4x4.identity : UMContext.activeModeler.worldTM);
			Vector3 a = Util.ConvertWorldToScreen(current, matrix4x.MultiplyPoint(pos0));
			Vector3 b = Util.ConvertWorldToScreen(current, matrix4x.MultiplyPoint(pos1));
			a.z = (b.z = 0f);
			return Vector3.Distance(a, b);
		}

		public static bool IsConvexhull(List<Vertex> vList, PlaneEx plane)
		{
			if (plane == null)
			{
				return false;
			}
			for (int i = 0; i < vList.Count; i++)
			{
				Vector3 pos = vList[i].pos;
				Vector3 pos2 = vList[(i + 1) % vList.Count].pos;
				Vector3 pos3 = vList[(i + 2) % vList.Count].pos;
				if (Vector3.Dot(Vector3.Cross(rhs: Vector3.Normalize(pos - pos2), lhs: Vector3.Normalize(pos3 - pos2)), plane.normal) < -0.0001f)
				{
					return false;
				}
			}
			return true;
		}

		public static bool PointInTriangle(Vector2 pt, Vector2 v1, Vector2 v2, Vector2 v3)
		{
			Vector2_3InputFloatReturnDelegate vector2_3InputFloatReturnDelegate = (Vector2 p1, Vector2 p2, Vector3 p3) => (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
			bool flag = vector2_3InputFloatReturnDelegate(pt, v1, v2) < 0f;
			bool flag2 = vector2_3InputFloatReturnDelegate(pt, v2, v3) < 0f;
			bool flag3 = vector2_3InputFloatReturnDelegate(pt, v3, v1) < 0f;
			if (flag == flag2)
			{
				return flag2 == flag3;
			}
			return false;
		}

		public static bool PointInRectangle(Vector2 pt, Vector2 min, Vector2 max)
		{
			Vector2[] array = new Vector2[4]
			{
				min,
				new Vector2(min.x, max.y),
				max,
				new Vector2(max.x, min.y)
			};
			if (!PointInTriangle(pt, array[0], array[1], array[2]))
			{
				return PointInTriangle(pt, array[0], array[2], array[3]);
			}
			return true;
		}

		public static bool ComputeCircumCircleRadiusAndCenter(Vector2 v0, Vector2 v1, Vector2 v2, out float out_radius, out Vector2 out_center)
		{
			float num = Vector2.Dot(v2 - v0, v1 - v0);
			float num2 = Vector2.Dot(v2 - v1, v0 - v1);
			float num3 = Vector2.Dot(v0 - v2, v1 - v2);
			float num4 = num2 * num3;
			float num5 = num3 * num;
			float num6 = num * num2;
			float num7 = num4 + num5 + num6;
			if (Mathf.Abs(num7) < float.Epsilon)
			{
				out_radius = 0f;
				out_center = default(Vector2);
				return false;
			}
			out_radius = Mathf.Sqrt((num + num2) * (num2 + num3) * (num3 + num) / num7) * 0.5f;
			out_center = (v0 * (num5 + num6) + v1 * (num6 + num4) + v2 * (num4 + num5)) / (2f * num7);
			return true;
		}

		public static void CreatePointsOnArc(float radius, Vector2 center, float start_radian, float diff_radian, int segment_count, out List<Vector2> outPoints)
		{
			outPoints = new List<Vector2>();
			for (int num = segment_count; num >= 0; num--)
			{
				float f = start_radian + diff_radian * ((float)num / (float)segment_count);
				Vector2 vector = new Vector2(Mathf.Cos(f), Mathf.Sin(f));
				outPoints.Add(center + radius * vector);
			}
		}

		public static void CreatePointsOnArc(ArcShape arc, out List<Vector2> outPoints)
		{
			CreatePointsOnArc(arc.radius, arc.plane.ToPlaneCoord(arc.center), ComputeAngleOnDisc(arc.plane.ToPlaneCoord(arc.from).normalized, Vector3.right), MathF.PI / 180f * arc.angle, arc.segment_count, out outPoints);
		}

		public static float ComputeAngleOnDisc(Vector2 dir, Vector2 from)
		{
			float num = Mathf.Acos(Vector2.Dot(from, dir));
			if (new Line2D(Vector2.zero, -from).Distance(dir) < 0f)
			{
				num = MathF.PI * 2f - num;
			}
			return num;
		}

		public static bool CreateArc(Edge2D edge, Vector2 third_v, int segment_count, out List<Vector2> outPoints, out Vector2 circum_circle_center)
		{
			float out_radius = 0f;
			if (!ComputeCircumCircleRadiusAndCenter(edge.p0, edge.p1, third_v, out out_radius, out circum_circle_center))
			{
				outPoints = null;
				return false;
			}
			float num = ComputeAngleOnDisc((edge.p0 - circum_circle_center).normalized, Vector3.right);
			float num2 = ComputeAngleOnDisc((edge.p1 - circum_circle_center).normalized, Vector3.right) - num;
			float[] array = new float[2]
			{
				num2,
				(num2 > 0f) ? (0f - (MathF.PI * 2f - num2)) : (0f - (MathF.PI * -2f - num2))
			};
			List<Vector2>[] array2 = new List<Vector2>[2];
			float num3 = 3E+10f;
			int num4 = 0;
			for (int i = 0; i < 2; i++)
			{
				CreatePointsOnArc(out_radius, circum_circle_center, num, array[i], 4, out array2[i]);
				int count = array2[i].Count;
				for (int j = 0; j < count; j++)
				{
					float num5 = Mathf.Abs(new Edge2D(array2[i][j], array2[i][(j + 1) % count]).SquaredDistanceToPoint(third_v));
					if (num5 < num3)
					{
						num4 = i;
						num3 = num5;
					}
				}
			}
			CreatePointsOnArc(out_radius, circum_circle_center, num, array[num4], segment_count, out outPoints);
			outPoints.Reverse();
			return true;
		}

		public static float Cosine(Vector3 v0, Vector3 v1, Vector3 v2)
		{
			Vector3 lhs = Vector3.Normalize(v0 - v1);
			Vector3 rhs = Vector3.Normalize(v2 - v1);
			return Vector3.Dot(lhs, rhs);
		}

		public static List<Vertex> RemoveLinkVertices(List<Vertex> loop)
		{
			List<Vertex> list = new List<Vertex>();
			for (int i = 0; i < loop.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < loop.Count; j++)
				{
					if (i != j && Comparer.IsEquivalent(loop[i].pos, loop[j].pos))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(loop[i]);
				}
			}
			return list;
		}

		public static bool IsCCW(List<Vertex> loop, PlaneEx plane)
		{
			if (loop == null || loop.Count < 3 || plane == null)
			{
				return false;
			}
			List<Vertex> list = RemoveLinkVertices(loop);
			if (list.Count < 3)
			{
				return false;
			}
			SortedDictionary<float, int> sortedDictionary = new SortedDictionary<float, int>();
			for (int i = 0; i < list.Count; i++)
			{
				float y = plane.ToPlaneCoord(list[i].pos).y;
				if (!sortedDictionary.ContainsKey(y))
				{
					sortedDictionary.Add(y, i);
				}
			}
			SortedDictionary<float, int>.Enumerator enumerator = sortedDictionary.GetEnumerator();
			enumerator.MoveNext();
			int value = enumerator.Current.Value;
			int index = (value - 1 + list.Count) % list.Count;
			int index2 = (value + 1) % list.Count;
			Vector3 lhs = Vector3.Normalize(list[index].pos - list[value].pos);
			Vector3 rhs = Vector3.Normalize(list[index2].pos - list[value].pos);
			return Vector3.Dot(Vector3.Cross(lhs, rhs), plane.normal) < 0f;
		}

		public static bool IsRectangleSizeOver(Vector2 p0, Vector2 p1, float size)
		{
			if (!(Mathf.Abs(p0.x - p1.x) > size))
			{
				return Mathf.Abs(p0.y - p1.y) > size;
			}
			return true;
		}

		public static Vector3 Cross(Vector3 p0, Vector3 p1, Vector3 p2)
		{
			Vector3 rhs = p0 - p1;
			return Vector3.Cross(p2 - p1, rhs);
		}

		public static List<float> SolveQuadraticEquation(float a, float b, float c)
		{
			if (a == 0f)
			{
				return null;
			}
			float num = b * b - 4f * a * c;
			if (num < 0f)
			{
				return null;
			}
			List<float> list = new List<float>();
			if (num == 0f)
			{
				list.Add((0f - b) / 2f * a);
			}
			else
			{
				list.Add((0f - b - Mathf.Sqrt(num)) / (2f * a));
				list.Add((0f - b + Mathf.Sqrt(num)) / (2f * a));
			}
			return list;
		}

		public static float ComputeClosest2Power(float value)
		{
			int num = Mathf.Abs(Mathf.CeilToInt(value));
			int num2 = 0;
			int num3;
			do
			{
				num3 = (int)Mathf.Pow(2f, num2++);
			}
			while (num > num3);
			num = num3;
			return (float)num * Mathf.Sign(value);
		}

		public static bool IsOverlappedEdges(Edge e0, Edge e1)
		{
			float distance = 0f;
			float distance2 = 0f;
			bool num = e1.CalculateSquaredDistance(e0.p0, out distance) == EDistanceToEdgeDesc.Middle;
			bool flag = e1.CalculateSquaredDistance(e0.p1, out distance2) == EDistanceToEdgeDesc.Middle;
			Vector3 normalized = e0.GetDir().normalized;
			Vector3 normalized2 = e1.GetDir().normalized;
			if ((num && distance < 0.0001f) || (flag && distance2 < 0.0001f))
			{
				return Mathf.Abs(Vector3.Dot(normalized, normalized2)) > 0.9999f;
			}
			return false;
		}
	}
}
