using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class AABB
	{
		public Vector3 min;

		public Vector3 max;

		public static Vector3 minInit = new Vector3(3E+10f, 3E+10f, 3E+10f);

		public static Vector3 maxInit = new Vector3(-3E+10f, -3E+10f, -3E+10f);

		public float radius => Vector3.Distance(min, max) * 0.5f;

		public AABB Clone()
		{
			return new AABB
			{
				min = min,
				max = max
			};
		}

		public void Reset()
		{
			min = minInit;
			max = maxInit;
		}

		public void Add(Vector3 v)
		{
			min = new Vector3(Mathf.Min(v.x, min.x), Mathf.Min(v.y, min.y), Mathf.Min(v.z, min.z));
			max = new Vector3(Mathf.Max(v.x, max.x), Mathf.Max(v.y, max.y), Mathf.Max(v.z, max.z));
		}

		public void Add(AABB aabb)
		{
			Add(aabb.min);
			Add(aabb.max);
		}

		public bool Contains(Vector3 point, float space = 0f)
		{
			if (point.x < min.x - space)
			{
				return false;
			}
			if (point.y < min.y - space)
			{
				return false;
			}
			if (point.z < min.z - space)
			{
				return false;
			}
			if (point.x > max.x + space)
			{
				return false;
			}
			if (point.y > max.y + space)
			{
				return false;
			}
			if (point.z > max.z + space)
			{
				return false;
			}
			return true;
		}

		public bool Contains2D(Vector3 point, float space = 0f)
		{
			if (point.x < min.x - space)
			{
				return false;
			}
			if (point.y < min.y - space)
			{
				return false;
			}
			if (point.x > max.x + space)
			{
				return false;
			}
			if (point.y > max.y + space)
			{
				return false;
			}
			return true;
		}

		public bool Contains(AABB aabb)
		{
			if (Contains(aabb.min))
			{
				return Contains(aabb.max);
			}
			return false;
		}

		public bool IsIntersectBox(AABB aabb)
		{
			if ((aabb.max.x < min.x && Mathf.Abs(aabb.max.x - min.x) > 0.0001f) || (aabb.max.y < min.y && Mathf.Abs(aabb.max.y - min.y) > 0.0001f) || (aabb.max.z < min.z && Mathf.Abs(aabb.max.z - min.z) > 0.0001f) || (aabb.min.x > max.x && Mathf.Abs(max.x - aabb.min.x) > 0.0001f) || (aabb.min.y > max.y && Mathf.Abs(max.y - aabb.min.y) > 0.0001f) || (aabb.min.y > max.y && Mathf.Abs(max.z - aabb.min.z) > 0.0001f))
			{
				return false;
			}
			return true;
		}

		public bool IsIntersectBox2D(AABB aabb)
		{
			if (aabb.max.x < min.x || aabb.max.y < min.y || aabb.min.x > max.x || aabb.min.y > max.y)
			{
				return false;
			}
			return true;
		}

		public AABB Expand(Vector3 v)
		{
			min -= v;
			max += v;
			return this;
		}

		public Vector3 GetCenter()
		{
			return (min + max) * 0.5f;
		}

		public Vector3 GetSize()
		{
			return max - min;
		}

		public List<Vector3> GetMajorPoints()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						list.Add(new Vector3(min.x + (max.x - min.x) * 0.5f * (float)k, min.y + (max.y - min.y) * 0.5f * (float)j, min.z + (max.z - min.z) * 0.5f * (float)i));
					}
				}
			}
			return list;
		}

		public bool Raycast(Ray ray, out float t)
		{
			float num = 1f / ((ray.direction.x == 0f) ? 0.0001f : ray.direction.x);
			float num2 = 1f / ((ray.direction.y == 0f) ? 0.0001f : ray.direction.y);
			float num3 = 1f / ((ray.direction.z == 0f) ? 0.0001f : ray.direction.z);
			float a = (min.x - ray.origin.x) * num;
			float b = (max.x - ray.origin.x) * num;
			float a2 = (min.y - ray.origin.y) * num2;
			float b2 = (max.y - ray.origin.y) * num2;
			float a3 = (min.z - ray.origin.z) * num3;
			float b3 = (max.z - ray.origin.z) * num3;
			float num4 = Mathf.Max(Mathf.Max(Mathf.Min(a, b), Mathf.Min(a2, b2)), Mathf.Min(a3, b3));
			float num5 = Mathf.Min(Mathf.Min(Mathf.Max(a, b), Mathf.Max(a2, b2)), Mathf.Max(a3, b3));
			if (num5 < 0f || num4 > num5)
			{
				t = num5;
				return false;
			}
			t = num4;
			return true;
		}
	}
}
