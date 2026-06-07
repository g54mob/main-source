using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class PlaneEx
	{
		[SerializeField]
		private Vector3 normal_;

		[SerializeField]
		private float distance_;

		[NonSerialized]
		private Matrix4x4Ex basis_;

		[NonSerialized]
		private Vector3 up_ = Vector3.up;

		public Vector3 normal
		{
			get
			{
				return normal_;
			}
			set
			{
				normal_ = value;
				Invalidate();
			}
		}

		public Vector3 up
		{
			get
			{
				GetBasis();
				return up_;
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
				Invalidate();
			}
		}

		public PlaneEx()
		{
			normal = Vector3.zero;
			distance = 0f;
			Invalidate();
		}

		public PlaneEx(Plane plane)
		{
			normal = plane.normal;
			distance = plane.distance;
			Invalidate();
		}

		public PlaneEx(Vector3 in_normal, float d)
		{
			normal = in_normal;
			distance = d;
			Invalidate();
		}

		public PlaneEx(Vector3 in_normal, Vector3 in_point)
		{
			normal = in_normal;
			distance = 0f - Vector3.Dot(normal, in_point);
			Invalidate();
		}

		public PlaneEx(Vector3 a, Vector3 b, Vector3 c)
		{
			SetPlane(a, b, c);
		}

		public bool Raycast(Ray ray, out float t, bool excludeBackface = false)
		{
			return RayHit(ray.origin, ray.direction, out t, excludeBackface);
		}

		public float CalcDistanceToPoint(Vector3 pt)
		{
			return Vector3.Dot(normal, pt) + distance;
		}

		public bool IsOnPlane(Vector3 pos)
		{
			return Mathf.Abs(CalcDistanceToPoint(pos)) < 0.0001f;
		}

		private Matrix4x4Ex GetBasis()
		{
			if (basis_ == null)
			{
				UpdateBasis();
			}
			return basis_;
		}

		public void SetPlane(Vector3 a, Vector3 b, Vector3 c)
		{
			normal_ = Vector3.Cross(Vector3.Normalize(c - b), Vector3.Normalize(a - b));
			normal_.Normalize();
			distance_ = 0f - Vector3.Dot(normal, b);
			Invalidate();
		}

		public bool IsValid()
		{
			return normal != Vector3.zero;
		}

		public Vector2 ToPlaneCoord(Vector3 pos)
		{
			Vector3 vector = ToPlaneCoord3D(pos);
			return new Vector2(vector.x, vector.y);
		}

		public Vector3 ToPlaneCoord3D(Vector3 pos)
		{
			return GetBasis().m.MultiplyVector(pos);
		}

		public Vector3 FromPlaneCoord(Vector2 pos)
		{
			Vector3 vector = GetBasis().inv_m.MultiplyVector(new Vector3(pos.x, pos.y, 0f - distance));
			float t = 0f;
			if (RayHit(vector, normal, out t))
			{
				vector += normal * t;
			}
			return vector;
		}

		public bool IsEquivalent(PlaneEx plane, float epsilon = 0.0001f)
		{
			if (Comparer.IsEquivalent(normal, plane.normal))
			{
				return Comparer.IsEquivalent(distance, plane.distance, epsilon);
			}
			return false;
		}

		public bool IsPerpendicular(PlaneEx plane)
		{
			return Mathf.Abs(Vector3.Dot(plane.normal, normal)) < 0.0001f;
		}

		public PlaneEx Clone()
		{
			PlaneEx planeEx = new PlaneEx(normal, distance);
			if (basis_ != null)
			{
				planeEx.basis_ = new Matrix4x4Ex();
				planeEx.basis_.m = basis_.m;
				planeEx.basis_.inv_m = GetBasis().inv_m;
			}
			return planeEx;
		}

		public PlaneEx Flip()
		{
			normal_ = -normal_;
			distance_ = 0f - distance_;
			return this;
		}

		public bool IsTowardSameDirection(PlaneEx plane)
		{
			return Vector3.Dot(normal, plane.normal) > -0.0001f;
		}

		public void Invalidate()
		{
			basis_ = null;
		}

		private void UpdateBasis()
		{
			basis_ = new Matrix4x4Ex();
			if (Comparer.IsEquivalent(normal, Vector3.zero))
			{
				basis_.m = (basis_.inv_m = Matrix4x4.identity);
				up_ = Vector3.up;
				return;
			}
			Vector3 rhs = default(Vector3);
			if (Mathf.Abs(normal.x) >= Mathf.Abs(normal.y))
			{
				float num = 1f / Mathf.Sqrt(normal.x * normal.x + normal.z * normal.z);
				rhs.x = normal.z * num;
				rhs.y = 0f;
				rhs.z = (0f - normal.x) * num;
			}
			else
			{
				float num2 = 1f / Mathf.Sqrt(normal.y * normal.y + normal.z * normal.z);
				rhs.x = 0f;
				rhs.y = normal.z * num2;
				rhs.z = (0f - normal.y) * num2;
			}
			Vector3 vector = (up_ = Vector3.Cross(normal, rhs));
			basis_.m = default(Matrix4x4);
			basis_.m.SetRow(0, new Vector4(rhs.x, rhs.y, rhs.z, 0f));
			basis_.m.SetRow(1, new Vector4(vector.x, vector.y, vector.z, 0f));
			basis_.m.SetRow(2, new Vector4(normal.x, normal.y, normal.z, 0f));
			basis_.m.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
			basis_.inv_m = basis_.m.transpose;
		}

		public EPlanePolygonIntersection IntersectionTest(SimplePolygon polygon)
		{
			if (IsEquivalent(polygon.plane))
			{
				return EPlanePolygonIntersection.BorderPlus;
			}
			if (Clone().Flip().IsEquivalent(polygon.plane))
			{
				return EPlanePolygonIntersection.BorderMinus;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < polygon.GetVertexCount(); i++)
			{
				float num4 = CalcDistanceToPoint(polygon.GetVertex(i).pos);
				if (num4 > 0.0001f)
				{
					num++;
				}
				else if (num4 < -0.0001f)
				{
					num2++;
				}
				else
				{
					num3++;
				}
			}
			if (num2 == 0)
			{
				return EPlanePolygonIntersection.Plus;
			}
			if (num == 0)
			{
				return EPlanePolygonIntersection.Minus;
			}
			return EPlanePolygonIntersection.Crossed;
		}

		public Vertex FindClosestDistance(SimplePolygon polygon, Vector3 direction, out float closest_distance)
		{
			closest_distance = 10000000f;
			Vertex result = null;
			for (int i = 0; i < polygon.GetVertexCount(); i++)
			{
				float t = 0f;
				if (RayHit(polygon.GetVertex(i).pos, direction, out t))
				{
					t = Mathf.Abs(t);
					if (t < closest_distance)
					{
						closest_distance = t;
						result = polygon.GetVertex(i);
					}
				}
			}
			return result;
		}

		public bool RayHit(Vector3 origin, Vector3 direction, out float t, bool excludeBackface = false)
		{
			float num = Vector3.Dot(normal, direction);
			if (num == 0f || (excludeBackface && num < 0f))
			{
				t = 0f;
				return false;
			}
			t = (0f - (Vector3.Dot(normal, origin) + distance)) / num;
			return true;
		}

		public ESplitResult SplitEdge(Edge edge, List<Edge> correspoinding_edges_to_this_line, out Edge outPositive, out Edge outNegative)
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
			float num = CalcDistanceToPoint(edge2.p0);
			float num2 = CalcDistanceToPoint(edge2.p1);
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
				float t = 0f;
				RayHit(edge2.p0, edge2.p1 - edge2.p0, out t);
				Vector3 vector4 = edge2.p0 + (edge2.p1 - edge2.p0) * t;
				Vector2 vector5 = edge2.uv0 + (edge2.uv1 - edge2.uv0) * t;
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
	}
}
