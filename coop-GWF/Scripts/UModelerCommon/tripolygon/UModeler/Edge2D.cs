using UnityEngine;

namespace tripolygon.UModeler
{
	public struct Edge2D
	{
		public Vector2 p0;

		public Vector2 p1;

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

		public Edge2D(Vector2 _p0, Vector2 _p1)
		{
			p0 = _p0;
			p1 = _p1;
		}

		public float SquaredDistanceToPoint(Vector2 point)
		{
			Vector2 vector = p1 - p0;
			Vector2 vector2 = point - p0;
			float num = Vector2.Dot(vector, vector2);
			if (num <= 0f)
			{
				return Vector2.Dot(vector2, vector2);
			}
			float num2 = Vector2.Dot(vector, vector);
			if (num >= num2)
			{
				return Vector2.Dot(point - p1, point);
			}
			return Vector2.Dot(vector2, vector2) - num * num / num2;
		}

		public bool FindIntersection(Edge2D edge, out Vector2 out_intersection)
		{
			Line2D line2D = new Line2D(this);
			Line2D line = new Line2D(edge);
			if (!line2D.Intersect(line, out out_intersection))
			{
				return false;
			}
			if (Contains(out_intersection))
			{
				return edge.Contains(out_intersection);
			}
			return false;
		}

		public bool Contains(Vector2 pos)
		{
			if (p0.x < p1.x)
			{
				if (pos.x < p0.x - 0.0001f || pos.x > p1.x + 0.0001f)
				{
					return false;
				}
			}
			else if (pos.x > p0.x + 0.0001f || pos.x < p1.x - 0.0001f)
			{
				return false;
			}
			if (p0.y < p1.y)
			{
				if (pos.y < p0.y - 0.0001f || pos.y > p1.y + 0.0001f)
				{
					return false;
				}
			}
			else if (pos.y > p0.y + 0.0001f || pos.y < p1.y - 0.0001f)
			{
				return false;
			}
			return true;
		}

		public bool IsInside(Vector2 pos)
		{
			if (!Contains(pos))
			{
				return false;
			}
			return Mathf.Abs(new Line2D(this).Distance(pos)) < 0.0001f;
		}
	}
}
