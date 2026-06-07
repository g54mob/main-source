using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class Line2D
	{
		private Vector2 normal_;

		private float distance_;

		public Vector2 normal
		{
			get
			{
				return normal_;
			}
			set
			{
				normal_ = value;
			}
		}

		public float distance
		{
			get
			{
				return distance_;
			}
			set
			{
				distance_ = value;
			}
		}

		public Line2D(Edge2D edge)
		{
			Set(ref edge.p0, ref edge.p1);
		}

		public Line2D(Vector2 v0, Vector2 v1)
		{
			Set(ref v0, ref v1);
		}

		public void Set(ref Vector2 v0, ref Vector2 v1)
		{
			Vector3 vector = Vector3.Cross(rhs: new Vector3(v1.x - v0.x, v1.y - v0.y, 0f), lhs: new Vector3(0f, 0f, -1f));
			normal_.x = vector.x;
			normal_.y = vector.y;
			normal_.Normalize();
			distance_ = 0f - Vector2.Dot(normal_, v0);
		}

		public HitResult Raycast(Ray ray)
		{
			return RayHit(ray.origin, ray.direction);
		}

		public HitResult RayHit(Vector2 origin, Vector2 direction)
		{
			float num = Vector2.Dot(direction, normal_);
			if (Mathf.Abs(num) < 0.0001f)
			{
				return null;
			}
			HitResult hitResult = new HitResult();
			hitResult.t = (0f - Distance(origin)) / num;
			hitResult.pos = origin + hitResult.t * direction;
			return hitResult;
		}

		public float Distance(Vector2 pos)
		{
			return Vector2.Dot(pos, normal) + distance;
		}

		public ESplitResult SplitEdge(PlaneEx plane, Edge edge, List<Edge> correspoinding_edges_to_this_line, out Edge outPositive, out Edge outNegative)
		{
			Edge edge2 = edge.Clone();
			for (int i = 0; i < correspoinding_edges_to_this_line.Count; i++)
			{
				if (Comparer.IsEquivalent(edge2.p0, correspoinding_edges_to_this_line[i].p0))
				{
					edge2.p0 = correspoinding_edges_to_this_line[i].p0;
				}
				else if (Comparer.IsEquivalent(edge2.p0, correspoinding_edges_to_this_line[i].p1))
				{
					edge2.p0 = correspoinding_edges_to_this_line[i].p1;
				}
				if (Comparer.IsEquivalent(edge2.p1, correspoinding_edges_to_this_line[i].p0))
				{
					edge2.p1 = correspoinding_edges_to_this_line[i].p0;
				}
				else if (Comparer.IsEquivalent(edge2.p1, correspoinding_edges_to_this_line[i].p1))
				{
					edge2.p1 = correspoinding_edges_to_this_line[i].p1;
				}
			}
			Vector3 p = correspoinding_edges_to_this_line[0].p0;
			Vector3 vector = correspoinding_edges_to_this_line[0].p1 - correspoinding_edges_to_this_line[0].p0;
			float sqrMagnitude = vector.sqrMagnitude;
			Vector3 vector2 = Vector3.Dot(vector, edge2.p0 - p) / sqrMagnitude * vector;
			float magnitude = (edge2.p0 - p - vector2).magnitude;
			Vector3 vector3 = Vector3.Dot(vector, edge2.p1 - p) / sqrMagnitude * vector;
			float magnitude2 = (edge2.p1 - p - vector3).magnitude;
			Edge2D edge2D = new Edge2D(plane.ToPlaneCoord(edge2.p0), plane.ToPlaneCoord(edge2.p1));
			float num = Distance(edge2D.p0);
			float num2 = Distance(edge2D.p1);
			num = ((!(num < 0f)) ? magnitude : (0f - magnitude));
			num2 = ((!(num2 < 0f)) ? magnitude2 : (0f - magnitude2));
			num = ((Mathf.Abs(num) < 0.0001f) ? 0f : num);
			num2 = ((Mathf.Abs(num2) < 0.0001f) ? 0f : num2);
			if (num == 0f && num2 == 0f)
			{
				outPositive = edge2;
				outNegative = edge2;
				return ESplitResult.Coincidence;
			}
			outPositive = new ExtendedEdge();
			outNegative = new ExtendedEdge();
			if ((num < 0f && num2 > 0f) || (num > 0f && num2 < 0f))
			{
				HitResult hitResult = RayHit(edge2D.p0, edge2D.p1 - edge2D.p0);
				Vector3 vector4 = edge2.p0 + (edge2.p1 - edge2.p0) * hitResult.t;
				Vector3 vector5 = edge2.uv0 + (edge2.uv1 - edge2.uv0) * hitResult.t;
				for (int j = 0; j < correspoinding_edges_to_this_line.Count; j++)
				{
					if (Comparer.IsEquivalent(vector4, correspoinding_edges_to_this_line[j].p0))
					{
						vector4 = correspoinding_edges_to_this_line[j].p0;
					}
					else if (Comparer.IsEquivalent(vector4, correspoinding_edges_to_this_line[j].p1))
					{
						vector4 = correspoinding_edges_to_this_line[j].p1;
					}
				}
				if (num > 0f)
				{
					outPositive = new ExtendedEdge(edge2.p0, vector4, edge2.uv0, vector5);
					outNegative = new ExtendedEdge(vector4, edge2.p1, vector5, edge2.uv1);
				}
				else
				{
					outNegative = new ExtendedEdge(edge2.p0, vector4, edge2.uv0, vector5);
					outPositive = new ExtendedEdge(vector4, edge2.p1, vector5, edge2.uv1);
				}
			}
			else if ((num > 0f && num2 > 0f) || (num == 0f && num2 > 0f) || (num > 0f && num2 == 0f))
			{
				outPositive = edge2;
			}
			else if ((num < 0f && num2 < 0f) || (num == 0f && num2 < 0f) || (num < 0f && num2 == 0f))
			{
				outNegative = edge2;
			}
			bool flag = Vector3.Distance(outPositive.p0, outPositive.p1) > 0.0001f;
			bool flag2 = Vector3.Distance(outNegative.p0, outNegative.p1) > 0.0001f;
			if (flag && flag2)
			{
				return ESplitResult.Cross;
			}
			if (flag)
			{
				return ESplitResult.Positive;
			}
			if (flag2)
			{
				return ESplitResult.Negative;
			}
			return ESplitResult.Coincidence;
		}

		public bool IsEquivalent(Line2D line)
		{
			if (Comparer.IsEquivalent(line.normal, normal))
			{
				return Comparer.IsEquivalent(line.distance, distance);
			}
			return false;
		}

		public bool Intersect(Line2D line, out Vector2 intersection)
		{
			intersection = default(Vector2);
			float num = (0f - line.normal.x) * distance + normal.x * line.distance;
			float num2 = line.normal.x * normal.y - normal.x * line.normal.y;
			float num3 = (0f - line.normal.y) * distance + normal.y * line.distance;
			float num4 = line.normal.y * normal.x - normal.y * line.normal.x;
			if (Mathf.Abs(num2) < 0.0001f || Mathf.Abs(num4) < 0.0001f)
			{
				return false;
			}
			intersection.x = num3 / num4;
			intersection.y = num / num2;
			return true;
		}

		public Vector2 MirrorPos(Vector2 pos)
		{
			return pos - normal_ * Distance(pos) * 2f;
		}
	}
}
