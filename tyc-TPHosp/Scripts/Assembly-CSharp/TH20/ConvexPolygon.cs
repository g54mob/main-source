using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class ConvexPolygon
	{
		private static List<Vector2> _seperationAxis = new List<Vector2>();

		public List<Vector2> Points { get; private set; }

		public Vector3 Center { get; private set; }

		public ConvexPolygon()
		{
			Points = new List<Vector2>();
		}

		public void Calculate()
		{
			Points.Sort(delegate(Vector2 a, Vector2 b)
			{
				if (a.x.Equals(b.x))
				{
					if (!a.y.Equals(b.y))
					{
						if (!(a.y > b.y))
						{
							return -1;
						}
						return 1;
					}
					return 0;
				}
				return (!a.x.Equals(b.x)) ? ((a.x > b.x) ? 1 : (-1)) : 0;
			});
			List<Vector2> list = new List<Vector2>();
			for (int num = 0; num < Points.Count; num++)
			{
				while (list.Count >= 2 && Cross(list[list.Count - 2], list[list.Count - 1], Points[num]) <= 0f)
				{
					list.Pop();
				}
				list.Add(Points[num]);
			}
			List<Vector2> list2 = new List<Vector2>();
			for (int num2 = Points.Count - 1; num2 >= 0; num2--)
			{
				while (list2.Count >= 2 && Cross(list2[list2.Count - 2], list2[list2.Count - 1], Points[num2]) <= 0f)
				{
					list2.Pop();
				}
				list2.Add(Points[num2]);
			}
			list2.Pop();
			list.Pop();
			Points = list;
			Points.AddRange(list2);
			Center = CalculateCenter();
		}

		public void Move(Vector3 delta)
		{
			Move(delta.Xz());
		}

		public void Move(Vector2 delta)
		{
			for (int i = 0; i < Points.Count; i++)
			{
				Vector2 value = Points[i];
				value += delta;
				Points[i] = value;
			}
		}

		private static float Cross(Vector2 o, Vector2 a, Vector2 b)
		{
			return (a.x - o.x) * (b.y - o.y) - (a.y - o.y) * (b.x - o.x);
		}

		private Vector2 CalculateCenter()
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			int i;
			float x;
			float y;
			float x2;
			float y2;
			float num4;
			for (i = 0; i < Points.Count - 1; i++)
			{
				x = Points[i].x;
				y = Points[i].y;
				x2 = Points[i + 1].x;
				y2 = Points[i + 1].y;
				num4 = x * y2 - x2 * y;
				num3 += num4;
				num += (x + x2) * num4;
				num2 += (y + y2) * num4;
			}
			x = Points[i].x;
			y = Points[i].y;
			x2 = Points[0].x;
			y2 = Points[0].y;
			num4 = x * y2 - x2 * y;
			num3 += num4;
			num += (x + x2) * num4;
			num2 += (y + y2) * num4;
			num3 *= 0.5f;
			num /= 6f * num3;
			num2 /= 6f * num3;
			return new Vector2(num, num2);
		}

		public static ConvexPolygon Enlarge(ConvexPolygon shape, float offset)
		{
			ConvexPolygon convexPolygon = new ConvexPolygon();
			List<Vector2> newPoints = convexPolygon.Points;
			Enlarge(shape, offset, ref newPoints);
			return convexPolygon;
		}

		public static void Enlarge(ConvexPolygon shape, float offset, ref List<Vector2> newPoints)
		{
			List<Vector2> points = shape.Points;
			int count = shape.Points.Count;
			newPoints.Clear();
			for (int i = 0; i < count; i++)
			{
				int num = i - 1;
				if (num < 0)
				{
					num += count;
				}
				int index = (i + 1) % count;
				Vector2 vector = new Vector2(points[i].x - points[index].x, points[i].y - points[index].y);
				vector.Normalize();
				vector *= offset;
				Vector2 vector2 = new Vector2(0f - vector.y, vector.x);
				Vector2 p = new Vector2(points[index].x + vector2.x, points[index].y + vector2.y);
				Vector2 p2 = new Vector2(points[i].x + vector2.x, points[i].y + vector2.y);
				Vector2 vector3 = new Vector2(points[num].x - points[i].x, points[num].y - points[i].y);
				vector3.Normalize();
				vector3 *= offset;
				Vector2 vector4 = new Vector2(0f - vector3.y, vector3.x);
				Vector2 p3 = new Vector2(points[i].x + vector4.x, points[i].y + vector4.y);
				Vector2 p4 = new Vector2(points[num].x + vector4.x, points[num].y + vector4.y);
				MathUtils.SegmentSegmentIntersection(p, p2, p3, p4, out var _, out var _, out var intersection, out var _, out var _);
				newPoints.Add(intersection);
			}
		}

		public bool PointInPoly(float x, float y)
		{
			bool flag = false;
			int num = 0;
			int index = Points.Count - 1;
			while (num < Points.Count)
			{
				float x2 = Points[num].x;
				float y2 = Points[num].y;
				float x3 = Points[index].x;
				float y3 = Points[index].y;
				if (((y2 <= y && y < y3) || (y3 <= y && y < y2)) && x < (x3 - x2) * (y - y2) / (y3 - y2) + x2)
				{
					flag = !flag;
				}
				index = num++;
			}
			return flag;
		}

		public static bool Overlaps(ConvexPolygon polyA, ConvexPolygon polyB)
		{
			if (!HasSeparatingAxis(polyA, polyB))
			{
				return !HasSeparatingAxis(polyB, polyA);
			}
			return false;
		}

		public static bool Intersect(ConvexPolygon A, ConvexPolygon B, out Vector2 resolveVector)
		{
			int count = A.Points.Count;
			int count2 = B.Points.Count;
			int index = count - 1;
			_seperationAxis.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector2 vector = A.Points[i] - A.Points[index];
				Vector2 seperationAxis = new Vector2(0f - vector.y, vector.x);
				if (CalculateAxisSeparatingPolygons(ref seperationAxis, A, B))
				{
					resolveVector = Vector2.zero;
					return false;
				}
				_seperationAxis.Add(seperationAxis);
				index = i;
			}
			index = count2 - 1;
			for (int j = 0; j < count2; j++)
			{
				Vector2 vector2 = B.Points[j] - B.Points[index];
				Vector2 seperationAxis2 = new Vector2(0f - vector2.y, vector2.x);
				if (CalculateAxisSeparatingPolygons(ref seperationAxis2, A, B))
				{
					resolveVector = Vector2.zero;
					return false;
				}
				_seperationAxis.Add(seperationAxis2);
				index = j;
			}
			resolveVector = CalculateResolveVector(_seperationAxis);
			if (Vector2.Dot(A.Center - B.Center, resolveVector) < 0f)
			{
				resolveVector = -resolveVector;
			}
			return true;
		}

		private static bool CalculateAxisSeparatingPolygons(ref Vector2 seperationAxis, ConvexPolygon A, ConvexPolygon B)
		{
			GatherProjectionExtents(A, seperationAxis, out var outMin, out var outMax);
			GatherProjectionExtents(B, seperationAxis, out var outMin2, out var outMax2);
			if (outMin > outMax2 || outMin2 > outMax)
			{
				return true;
			}
			float num = outMax - outMin2;
			float num2 = outMax2 - outMin;
			float num3 = ((num < num2) ? num : num2);
			float num4 = Vector2.Dot(seperationAxis, seperationAxis);
			seperationAxis *= num3 / num4;
			return false;
		}

		private static bool HasSeparatingAxis(ConvexPolygon polyA, ConvexPolygon polyB)
		{
			int index = polyA.Points.Count - 1;
			for (int i = 0; i < polyA.Points.Count; i++)
			{
				Vector2 vector = polyA.Points[i] - polyA.Points[index];
				Vector2 axis = new Vector2(vector.y, 0f - vector.x);
				GatherProjectionExtents(polyA, axis, out var outMin, out var outMax);
				GatherProjectionExtents(polyB, axis, out var outMin2, out var outMax2);
				if (outMax <= outMin2)
				{
					return true;
				}
				if (outMax2 <= outMin)
				{
					return true;
				}
				index = i;
			}
			return false;
		}

		private static void GatherProjectionExtents(ConvexPolygon poly, Vector2 axis, out float outMin, out float outMax)
		{
			outMin = (outMax = Vector2.Dot(axis, poly.Points[0]));
			for (int i = 1; i < poly.Points.Count; i++)
			{
				float num = Vector2.Dot(axis, poly.Points[i]);
				if (num < outMin)
				{
					outMin = num;
				}
				else if (num > outMax)
				{
					outMax = num;
				}
			}
		}

		private static Vector2 CalculateResolveVector(List<Vector2> seperationAxis)
		{
			Vector2 result = seperationAxis[0];
			float num = Vector2.Dot(seperationAxis[0], seperationAxis[0]);
			for (int i = 1; i < seperationAxis.Count; i++)
			{
				float num2 = Vector2.Dot(seperationAxis[i], seperationAxis[i]);
				if (num2 < num)
				{
					num = num2;
					result = seperationAxis[i];
				}
			}
			return result;
		}

		private static bool MoveAwayFromLine(Vector2 p0, Vector2 p1, ref Vector2 p)
		{
			Vector2 normalized = (p1 - p0).normalized;
			Vector2 vector = new Vector2(0f - normalized.y, normalized.x);
			float num = Vector2.Dot(vector, p - p0);
			if (num >= 0f)
			{
				return false;
			}
			p -= vector * num;
			return true;
		}

		public Vector2 ClampToBounds(Vector2 point)
		{
			if (Points.Count != 0)
			{
				bool flag = false;
				int num = 0;
				while (!flag && num < 10)
				{
					flag = true;
					if (MoveAwayFromLine(Points[Points.Count - 1], Points[0], ref point))
					{
						flag = false;
					}
					for (int i = 1; i < Points.Count; i++)
					{
						if (MoveAwayFromLine(Points[i - 1], Points[i], ref point))
						{
							flag = false;
						}
					}
					num++;
				}
			}
			return point;
		}
	}
}
