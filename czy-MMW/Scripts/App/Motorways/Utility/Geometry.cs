using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Utility
{
	public static class Geometry
	{
		public struct CircleLineIntersection
		{
			public Vector2 first;

			public Vector2 second;

			public int count;

			public Vector2 GetIntersection(int index)
			{
				if (index == 0)
				{
					return first;
				}
				return second;
			}
		}

		public static bool TryLineSegmentIntersection(LineSegment line0, LineSegment line1, out Vector2 intersection, bool extendToForceIntersection = false)
		{
			intersection = Vector2.zero;
			Vector2 vector = line0.Direction * line0.Length;
			Vector2 vector2 = line1.Direction * line1.Length;
			float num = vector.Cross(vector2);
			float num2 = (line1.Start - line0.Start).Cross(vector2);
			float num3 = (line1.Start - line0.Start).Cross(vector);
			if (num == 0f)
			{
				if (num3 == 0f)
				{
					float num4 = Vector2.Dot(vector, vector);
					float num5 = Vector2.Dot(vector, line1.Start - line0.Start) / num4;
					float num6 = Vector2.Dot(vector, line1.Start + vector2 - line0.Start) / num4;
					if ((num5 < 0f && num6 < 0f) || (num5 > 1f && num6 > 1f))
					{
						return false;
					}
					num5 = Mathf.Clamp01(num5);
					num6 = Mathf.Clamp01(num6);
					intersection = line0.Start + vector * (num5 + num6) * 0.5f;
					return true;
				}
				return false;
			}
			float num7 = num2 / num;
			float num8 = num3 / num;
			if (extendToForceIntersection || (Mathf.Approximately(num7, Mathf.Clamp01(num7)) && Mathf.Approximately(num8, Mathf.Clamp01(num8))))
			{
				intersection = line0.Start + num7 * line0.Direction * line0.Length;
				return true;
			}
			return false;
		}

		public static Vector2 GetExtrudedLineSegmentIntersection(LineSegment line0, LineSegment line1, float extrusion)
		{
			if (line0.IsNull)
			{
				return line1.Start + line1.Normal * (0f - extrusion);
			}
			if (line1.IsNull)
			{
				return line0.End + line0.Normal * (0f - extrusion);
			}
			if (line0.Direction == line1.Direction)
			{
				return line0.End + line0.Normal * (0f - extrusion);
			}
			if (extrusion == 0f)
			{
				return line0.End;
			}
			Vector2 vector = line0.Normal * (0f - extrusion);
			Vector2 vector2 = line1.Normal * (0f - extrusion);
			LineSegment line2 = new LineSegment(line0.Start + vector, line0.End + vector);
			LineSegment line3 = new LineSegment(line1.Start + vector2, line1.End + vector2);
			if (TryLineSegmentIntersection(line2, line3, out var intersection, extendToForceIntersection: true))
			{
				return intersection;
			}
			Vector2 vector3 = ((line0.Normal + line1.Normal) * 0.5f).normalized * (0f - extrusion);
			return line0.End + vector3;
		}

		public static CircleLineIntersection TryCircleLineSegmentIntersection(Circle circle, LineSegment lineSegment)
		{
			CircleLineIntersection result = default(CircleLineIntersection);
			float num = Vector2.Dot(circle.Origin - lineSegment.Start, lineSegment.Direction);
			Vector2 position = lineSegment.GetPosition(num);
			float magnitude = (circle.Origin - position).magnitude;
			if (Mathf.Approximately(magnitude, circle.Radius))
			{
				if (num >= 0f && num <= lineSegment.Length)
				{
					result.count = 1;
					result.first = position;
					return result;
				}
			}
			else if (magnitude < circle.Radius)
			{
				float num2 = circle.Radius - magnitude;
				float num3 = Mathf.Sqrt(8f * circle.Radius * num2 - 4f * num2 * num2) * 0.5f;
				if (num - num3 >= 0f && num - num3 <= lineSegment.Length)
				{
					result.count = 1;
					result.first = lineSegment.GetPosition(num - num3);
				}
				if (num + num3 >= 0f && num + num3 <= lineSegment.Length)
				{
					Vector2 position2 = lineSegment.GetPosition(num + num3);
					if (result.count == 0)
					{
						result.count = 1;
						result.first = position2;
					}
					else
					{
						result.count = 2;
						result.second = position2;
					}
				}
				return result;
			}
			return result;
		}

		public static List<Vector2Int> GetTileCoordinatesUnderLine(Vector2Int start, Vector2Int end)
		{
			int num = end.x - start.x;
			int num2 = end.y - start.y;
			int num3 = Mathf.Abs(num);
			int num4 = Mathf.Abs(num2);
			int num5 = ((num > 0) ? 1 : (-1));
			int num6 = ((num2 > 0) ? 1 : (-1));
			Vector2Int item = start;
			List<Vector2Int> list = new List<Vector2Int> { item };
			int num7 = 0;
			int num8 = 0;
			while (num7 < num3 || num8 < num4)
			{
				int num9 = (1 + 2 * num7) * num4 - (1 + 2 * num8) * num3;
				if (num9 == 0)
				{
					item.x += num5;
					item.y += num6;
					num7++;
					num8++;
				}
				else if (num9 < 0)
				{
					item.x += num5;
					num7++;
				}
				else
				{
					item.y += num6;
					num8++;
				}
				list.Add(item);
			}
			return list;
		}
	}
}
