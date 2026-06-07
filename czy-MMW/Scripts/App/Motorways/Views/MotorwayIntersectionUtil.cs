using System.Collections.Generic;
using UnityEngine;
using Utils.Geometry;

namespace Motorways.Views
{
	public static class MotorwayIntersectionUtil
	{
		public class MotorwayIntersection
		{
			public readonly Vector2 point;

			public readonly (MotorwayEdgeType, MotorwayEdgeType) type;

			public readonly (MotorwayEdge A, MotorwayEdge B) edges;

			public readonly bool isSeparatingOrJoining;

			public MotorwayIntersection(Vector2 point, (MotorwayEdge, MotorwayEdge) edges, (MotorwayEdgeType, MotorwayEdgeType) type)
			{
				this.point = point;
				this.edges = edges;
				this.type = type;
				if (this.edges.A.type == MotorwayEdgeType.End || this.edges.B.type == MotorwayEdgeType.End)
				{
					isSeparatingOrJoining = false;
					return;
				}
				Vector2 normalized = (this.edges.A.to.position - this.edges.A.from.position).normalized;
				Vector2 normalized2 = (this.edges.B.to.position - this.edges.B.from.position).normalized;
				isSeparatingOrJoining = Vector2.Dot((Vector2.Dot(normalized, this.edges.B.normal) > 0f) ? normalized : (-normalized), (Vector2.Dot(normalized2, this.edges.A.normal) > 0f) ? normalized2 : (-normalized2)) > 0f;
			}

			public bool Equals(MotorwayIntersection other)
			{
				if (point.Equals(other.point))
				{
					return type.Equals(other.type);
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is MotorwayIntersection other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (point.GetHashCode() * 397) ^ type.GetHashCode();
			}
		}

		public static bool PolygonIntersectsPolygon(MotorwayPolygon polygonA, MotorwayPolygon polygonB, out List<MotorwayIntersection> intersections)
		{
			intersections = new List<MotorwayIntersection>();
			foreach (MotorwayEdge edge in polygonA.edges)
			{
				EdgeIntersectsPolygon(polygonB, edge, out var intersection);
				if (intersection != null)
				{
					intersections.Add(intersection);
				}
			}
			return intersections.Count > 0;
		}

		private static bool EdgeIntersectsPolygon(MotorwayPolygon polygon, MotorwayEdge edge, out MotorwayIntersection intersection)
		{
			Vector2 endB = edge.to.position - edge.from.position;
			foreach (MotorwayEdge edge2 in polygon.edges)
			{
				Vector2 endA = edge2.to.position - edge2.from.position;
				LineIntersection.IntersectionInfo intersectionInfo = LineIntersection.LineLineIntersection(edge2.from.position, endA, edge.from.position, endB);
				if (intersectionInfo.type == LineIntersection.IntersectionInfo.IntersectionType.Point)
				{
					intersection = new MotorwayIntersection(intersectionInfo.intersection, (edge2, edge), (edge2.type, edge.type));
					return true;
				}
			}
			intersection = null;
			return false;
		}

		public static bool EitherEndEdgeIntersectsBoundingBox(MotorwayGeometryInfo.MotorwayEndEdges motorwayEndEdges, Bounds boundingBox)
		{
			AxisAlignedBoundingBox axisAlignedBoundingBox = new AxisAlignedBoundingBox(boundingBox.min, boundingBox.max);
			if (!axisAlignedBoundingBox.IntersectWithLine(motorwayEndEdges.start.from, motorwayEndEdges.start.to))
			{
				return axisAlignedBoundingBox.IntersectWithLine(motorwayEndEdges.end.from, motorwayEndEdges.end.to);
			}
			return true;
		}

		public static bool EndEdgeIntersectsPolygon(MotorwayPolygon motorwayPolygon, MotorwayGeometryInfo.MotorwayEndEdge edge, AxisAlignedBoundingBox boundingBox)
		{
			if (!boundingBox.IntersectWithLine(edge.from, edge.to))
			{
				return false;
			}
			if (LineIntersectsMotorwayPolygon(motorwayPolygon, edge.from, edge.to, out var _))
			{
				return true;
			}
			if (!PointIsInsidePolygon(motorwayPolygon, edge.from))
			{
				return PointIsInsidePolygon(motorwayPolygon, edge.to);
			}
			return true;
		}

		private static bool PointIsInsidePolygon(MotorwayPolygon polygon, Vector2 point)
		{
			IReadOnlyList<MotorwayPoint> points = polygon.points;
			bool flag = false;
			int num = 0;
			int index = points.Count - 1;
			while (num < points.Count)
			{
				bool num2 = points[num].position.y > point.y != points[index].position.y > point.y;
				bool flag2 = point.x < (points[index].position.x - points[num].position.x) * (point.y - points[num].position.y) / (points[index].position.y - points[num].position.y) + points[num].position.x;
				if (num2 && flag2)
				{
					flag = !flag;
				}
				index = num++;
			}
			return flag;
		}

		private static bool LineIntersectsMotorwayPolygon(MotorwayPolygon polygon, Vector2 from, Vector2 to, out LineIntersection.IntersectionInfo? intersectionInfo)
		{
			Vector2 endB = to - from;
			foreach (MotorwayEdge edge in polygon.edges)
			{
				Vector2 endA = edge.to.position - edge.from.position;
				LineIntersection.IntersectionInfo value = LineIntersection.LineLineIntersection(edge.from.position, endA, from, endB);
				if (value.type == LineIntersection.IntersectionInfo.IntersectionType.Point)
				{
					intersectionInfo = value;
					return true;
				}
			}
			intersectionInfo = null;
			return false;
		}
	}
}
