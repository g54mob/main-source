using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class Edge
	{
		public Vector3 p0;

		public Vector3 p1;

		public virtual Vector2 uv0
		{
			get
			{
				return Vector2.zero;
			}
			set
			{
			}
		}

		public virtual Vector2 uv1
		{
			get
			{
				return Vector2.zero;
			}
			set
			{
			}
		}

		public float length => Vector3.Distance(p0, p1);

		public Vector3 this[int index]
		{
			get
			{
				if (index == 0)
				{
					return p0;
				}
				return p1;
			}
			set
			{
				if (index == 0)
				{
					p0 = value;
				}
				else
				{
					p1 = value;
				}
			}
		}

		public AABB aabb
		{
			get
			{
				AABB aABB = new AABB();
				aABB.Reset();
				aABB.Add(p0);
				aABB.Add(p1);
				return aABB;
			}
		}

		public virtual bool ContainsUVs()
		{
			return false;
		}

		public Vector2 GetUV(int index)
		{
			return index switch
			{
				0 => uv0, 
				1 => uv1, 
				_ => Vector2.zero, 
			};
		}

		public Edge()
		{
		}

		public Edge(Vector3 _p0, Vector3 _p1)
		{
			p0 = _p0;
			p1 = _p1;
		}

		public Edge(Edge edge)
		{
			p0 = edge.p0;
			p1 = edge.p1;
			uv0 = edge.uv0;
			uv1 = edge.uv1;
		}

		public Vector3 Get(int idx)
		{
			if (idx == 0)
			{
				return p0;
			}
			return p1;
		}

		public bool FindClosestPos(Vector3 pos, out Vector3 closest_pos, out bool between_edge)
		{
			between_edge = false;
			closest_pos = new Vector3(0f, 0f, 0f);
			Vector3 vector = p1 - p0;
			float num = vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
			if (num == 0f)
			{
				return false;
			}
			Vector3 lhs = pos - p0;
			closest_pos = Vector3.Dot(lhs, vector) / num * vector + p0;
			between_edge = true;
			for (int i = 0; i < 3; i++)
			{
				if (p0[i] < p1[i])
				{
					if (closest_pos[i] < p0[i] - 0.0001f || closest_pos[i] > p1[i] + 0.0001f)
					{
						if (closest_pos[i] < p0[i])
						{
							closest_pos = p0;
						}
						else if (closest_pos[i] > p1[i])
						{
							closest_pos = p1;
						}
						between_edge = false;
						break;
					}
				}
				else if (closest_pos[i] < p1[i] - 0.0001f || closest_pos[i] > p0[i] + 0.0001f)
				{
					if (closest_pos[i] < p1[i])
					{
						closest_pos = p1;
					}
					else if (closest_pos[i] > p0[i])
					{
						closest_pos = p0;
					}
					between_edge = false;
					break;
				}
			}
			return true;
		}

		public EDistanceToEdgeDesc CalculateSquaredDistance(Vector3 pos, out float distance)
		{
			Vector3 vector = p1 - p0;
			Vector3 vector2 = pos - p0;
			float num = Vector3.Dot(vector, vector2);
			if (num < 0.0001f)
			{
				distance = Vector3.Dot(vector2, vector2);
				return EDistanceToEdgeDesc.EdgeP0;
			}
			if (num > Vector3.Dot(vector, vector) - 0.0001f)
			{
				Vector3 lhs = pos - p1;
				distance = Vector3.Dot(lhs, pos);
				return EDistanceToEdgeDesc.EdgeP1;
			}
			distance = Vector3.Dot(vector2, vector2) - num * num / Vector3.Dot(vector, vector);
			return EDistanceToEdgeDesc.Middle;
		}

		public EdgeProjectionResult FindProjectedEdges(Vector3 projected_dir)
		{
			EdgeProjectionResult result = default(EdgeProjectionResult);
			int index = 0;
			float num = Mathf.Abs(projected_dir.x);
			float num2 = Mathf.Abs(projected_dir.y);
			float num3 = Mathf.Abs(projected_dir.z);
			if (num2 > num && num2 > num3)
			{
				index = 1;
			}
			else if (num3 > num && num3 > num2)
			{
				index = 2;
			}
			result.pos[0] = p0[index];
			result.pos[1] = p1[index];
			result.bInverted = false;
			if (result.pos.x > result.pos.y)
			{
				MathUtil.Swap(ref result.pos.x, ref result.pos.y);
				result.bInverted = true;
			}
			return result;
		}

		public Edge FindInterectedEdge(Edge e)
		{
			Edge edge = null;
			if (IsEquivalent(e))
			{
				return e;
			}
			EdgeProjectionResult edgeProjectionResult = FindProjectedEdges(GetDir());
			EdgeProjectionResult edgeProjectionResult2 = e.FindProjectedEdges(GetDir());
			if (Comparer.IsEquivalent(edgeProjectionResult.pos[0], edgeProjectionResult.pos[1]) || Comparer.IsEquivalent(edgeProjectionResult2.pos[0], edgeProjectionResult2.pos[1]))
			{
				return null;
			}
			if (Mathf.Abs(edgeProjectionResult.pos[1] - edgeProjectionResult2.pos[0]) < 0.0001f)
			{
				edgeProjectionResult2.pos[0] = edgeProjectionResult.pos[1];
			}
			if (Mathf.Abs(edgeProjectionResult.pos[0] - edgeProjectionResult2.pos[1]) < 0.0001f)
			{
				edgeProjectionResult2.pos[1] = edgeProjectionResult.pos[0];
			}
			if (edgeProjectionResult2.pos[0] <= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[1] >= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[1] <= edgeProjectionResult.pos[1])
			{
				edge = new ExtendedEdge();
				if (!edgeProjectionResult.bInverted)
				{
					edge.p0 = p0;
					edge.uv0 = uv0;
				}
				else
				{
					edge.p0 = p1;
					edge.uv0 = uv1;
				}
				if (!edgeProjectionResult2.bInverted)
				{
					edge.p1 = e.p1;
					edge.uv1 = e.uv1;
				}
				else
				{
					edge.p1 = e.p0;
					edge.uv1 = e.uv0;
				}
			}
			else if (edgeProjectionResult2.pos[1] >= edgeProjectionResult.pos[1] && edgeProjectionResult2.pos[0] >= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[0] <= edgeProjectionResult.pos[1])
			{
				edge = new ExtendedEdge();
				if (!edgeProjectionResult2.bInverted)
				{
					edge.p0 = e.p0;
					edge.uv0 = e.uv0;
				}
				else
				{
					edge.p0 = e.p1;
					edge.uv0 = e.uv1;
				}
				if (!edgeProjectionResult.bInverted)
				{
					edge.p1 = p1;
					edge.uv1 = uv1;
				}
				else
				{
					edge.p1 = p0;
					edge.uv1 = uv0;
				}
			}
			else if (edgeProjectionResult2.pos[0] >= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[1] >= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[0] <= edgeProjectionResult.pos[1] && edgeProjectionResult2.pos[1] <= edgeProjectionResult.pos[1])
			{
				edge = new ExtendedEdge();
				if (!edgeProjectionResult2.bInverted)
				{
					edge.p0 = e.p0;
					edge.uv0 = e.uv0;
					edge.p1 = e.p1;
					edge.uv1 = e.uv1;
				}
				else
				{
					edge.p0 = e.p1;
					edge.uv0 = e.uv1;
					edge.p1 = e.p0;
					edge.uv1 = e.uv0;
				}
			}
			else if (edgeProjectionResult.pos[0] >= edgeProjectionResult2.pos[0] && edgeProjectionResult.pos[1] >= edgeProjectionResult2.pos[0] && edgeProjectionResult.pos[0] <= edgeProjectionResult2.pos[1] && edgeProjectionResult.pos[1] <= edgeProjectionResult2.pos[1])
			{
				edge = new ExtendedEdge();
				if (!edgeProjectionResult.bInverted)
				{
					edge.p0 = p0;
					edge.uv0 = uv0;
					edge.p1 = p1;
					edge.uv1 = uv1;
				}
				else
				{
					edge.p0 = p1;
					edge.uv0 = uv1;
					edge.p1 = p0;
					edge.uv1 = uv0;
				}
			}
			if (edge != null && edgeProjectionResult2.bInverted)
			{
				edge.Invert();
			}
			return edge;
		}

		public List<Edge> SubtractEdge(Edge e)
		{
			List<Edge> list = null;
			EdgeProjectionResult edgeProjectionResult = FindProjectedEdges(GetDir());
			EdgeProjectionResult edgeProjectionResult2 = e.FindProjectedEdges(GetDir());
			if (Comparer.IsEquivalent(edgeProjectionResult.pos[0], edgeProjectionResult.pos[1]) || Comparer.IsEquivalent(edgeProjectionResult2.pos[0], edgeProjectionResult2.pos[1]))
			{
				return null;
			}
			if (Mathf.Abs(edgeProjectionResult.pos[1] - edgeProjectionResult2.pos[0]) < 0.0001f)
			{
				edgeProjectionResult2.pos[0] = edgeProjectionResult.pos[1];
			}
			if (Mathf.Abs(edgeProjectionResult.pos[0] - edgeProjectionResult2.pos[1]) < 0.0001f)
			{
				edgeProjectionResult2.pos[1] = edgeProjectionResult.pos[0];
			}
			if (edgeProjectionResult2.pos[0] <= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[1] >= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[1] <= edgeProjectionResult.pos[1])
			{
				Edge edge = new ExtendedEdge();
				if (!edgeProjectionResult2.bInverted)
				{
					edge.p0 = e.p1;
					edge.uv0 = e.uv1;
				}
				else
				{
					edge.p0 = e.p0;
					edge.uv0 = e.uv0;
				}
				if (!edgeProjectionResult.bInverted)
				{
					edge.p1 = p1;
					edge.uv1 = uv1;
				}
				else
				{
					edge.p1 = p0;
					edge.uv1 = uv0;
				}
				if (!edge.IsPoint())
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.Add(edge);
				}
			}
			else if (edgeProjectionResult2.pos[1] >= edgeProjectionResult.pos[1] && edgeProjectionResult2.pos[0] >= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[0] <= edgeProjectionResult.pos[1])
			{
				Edge edge2 = new ExtendedEdge();
				if (!edgeProjectionResult.bInverted)
				{
					edge2.p0 = p0;
					edge2.uv0 = uv0;
				}
				else
				{
					edge2.p0 = p1;
					edge2.uv0 = uv1;
				}
				if (!edgeProjectionResult2.bInverted)
				{
					edge2.p1 = e.p0;
					edge2.uv1 = e.uv0;
				}
				else
				{
					edge2.p1 = e.p1;
					edge2.uv1 = e.uv1;
				}
				if (!edge2.IsPoint())
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.Add(edge2);
				}
			}
			else if (edgeProjectionResult2.pos[0] >= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[0] <= edgeProjectionResult.pos[1] && edgeProjectionResult2.pos[1] >= edgeProjectionResult.pos[0] && edgeProjectionResult2.pos[1] <= edgeProjectionResult.pos[1])
			{
				Edge edge3 = new ExtendedEdge();
				if (!edgeProjectionResult.bInverted)
				{
					edge3.p0 = p0;
					edge3.uv0 = uv0;
				}
				else
				{
					edge3.p0 = p1;
					edge3.uv0 = uv1;
				}
				if (!edgeProjectionResult2.bInverted)
				{
					edge3.p1 = e.p0;
					edge3.uv1 = e.uv0;
				}
				else
				{
					edge3.p1 = e.p1;
					edge3.uv1 = e.uv1;
				}
				if (!edge3.IsPoint())
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.Add(edge3);
				}
				Edge edge4 = new ExtendedEdge();
				if (!edgeProjectionResult2.bInverted)
				{
					edge4.p0 = e.p1;
					edge4.uv0 = e.uv1;
				}
				else
				{
					edge4.p0 = e.p0;
					edge4.uv0 = e.uv0;
				}
				if (!edgeProjectionResult.bInverted)
				{
					edge4.p1 = p1;
					edge4.uv1 = uv1;
				}
				else
				{
					edge4.p1 = p0;
					edge4.uv1 = uv0;
				}
				if (!edge4.IsPoint())
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.Add(edge4);
				}
			}
			if (edgeProjectionResult2.bInverted && list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].Invert();
				}
			}
			return list;
		}

		public bool IsSameDir(Edge e)
		{
			Vector3 normalized = (p1 - p0).normalized;
			Vector3 normalized2 = (e.p1 - e.p0).normalized;
			return Vector3.Dot(normalized, normalized2) > 0.0001f;
		}

		public bool IsPoint()
		{
			if (Mathf.Abs(p0.x - p1.x) < 0.0001f && Mathf.Abs(p0.y - p1.y) < 0.0001f)
			{
				return Mathf.Abs(p0.z - p1.z) < 0.0001f;
			}
			return false;
		}

		public bool IsConnected(Edge edge)
		{
			if (!Comparer.IsEquivalent(p0, edge.p1) || Comparer.IsEquivalent(p1, edge.p0))
			{
				if (Comparer.IsEquivalent(p1, edge.p0))
				{
					return !Comparer.IsEquivalent(p0, edge.p1);
				}
				return false;
			}
			return true;
		}

		public virtual Edge Invert()
		{
			MathUtil.Swap(ref p0, ref p1);
			return this;
		}

		public bool IsEquivalent(Edge rhs)
		{
			if (rhs == null)
			{
				return false;
			}
			if (this != rhs)
			{
				if (Comparer.IsEquivalent(p0, rhs.p0))
				{
					return Comparer.IsEquivalent(p1, rhs.p1);
				}
				return false;
			}
			return true;
		}

		public bool Contains(Vector3 pos)
		{
			aabb.Expand(new Vector3(0.001f, 0.001f, 0.001f));
			return aabb.Contains(pos);
		}

		public virtual Edge Clone()
		{
			return new Edge(p0, p1);
		}

		public Vector3 GetDir()
		{
			return p1 - p0;
		}

		public Vector3 GetCenter()
		{
			return (p0 + p1) * 0.5f;
		}

		public bool Raycast(Ray ray, out float t, float hit_width = 0.02f)
		{
			return RayHit(ray.origin, ray.direction, out t, hit_width);
		}

		public bool RayHit(Vector3 origin, Vector3 dir, out float t, float hit_width = 0.02f)
		{
			t = 3E+10f;
			Quaternion quaternion = Quaternion.FromToRotation((p1 - p0).normalized, Vector3.forward);
			Vector3 vector = quaternion * (origin - p0);
			Vector3 vector2 = quaternion * dir;
			float x = vector.x;
			float y = vector.y;
			float x2 = vector2.x;
			float y2 = vector2.y;
			List<float> list = MathUtil.SolveQuadraticEquation(x2 * x2 + y2 * y2, 2f * (x * x2 + y * y2), x * x + y * y - hit_width * hit_width);
			if (list == null)
			{
				return false;
			}
			t = list[0];
			Vector3 vector3 = vector + vector2 * t;
			if (vector3.z < 0f - hit_width || vector3.z > Vector3.Distance(p0, p1) + hit_width)
			{
				return false;
			}
			return true;
		}
	}
}
