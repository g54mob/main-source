using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MathUtility : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Vector2, float> _003C_003E9__4_0;

		internal float _003CGetIntersectionPointFromRectCenter_003Eb__4_0(Vector2 x)
		{
			return x.magnitude;
		}
	}

	public static float DistancePointToRectangle(Vector2 point, Rect rect)
	{
		if (point.x < rect.xMin)
		{
			if (point.y < rect.yMin)
			{
				return (point - new Vector2(rect.xMin, rect.yMin)).magnitude;
			}
			if (point.y > rect.yMax)
			{
				return (point - new Vector2(rect.xMin, rect.yMax)).magnitude;
			}
			return rect.xMin - point.x;
		}
		if (point.x > rect.xMax)
		{
			if (point.y < rect.yMin)
			{
				return (point - new Vector2(rect.xMax, rect.yMin)).magnitude;
			}
			if (point.y > rect.yMax)
			{
				return (point - new Vector2(rect.xMax, rect.yMax)).magnitude;
			}
			return point.x - rect.xMax;
		}
		if (point.y < rect.yMin)
		{
			return rect.yMin - point.y;
		}
		if (point.y > rect.yMax)
		{
			return point.y - rect.yMax;
		}
		return 0f;
	}

	public static Vector2 ClosestPointInRect(Vector2 point, Rect rect)
	{
		if (point.x < rect.xMin)
		{
			if (point.y < rect.yMin)
			{
				return new Vector2(rect.xMin, rect.yMin);
			}
			if (point.y > rect.yMax)
			{
				return new Vector2(rect.xMin, rect.yMax);
			}
			return new Vector2(rect.xMin, point.y);
		}
		if (point.x > rect.xMax)
		{
			if (point.y < rect.yMin)
			{
				return new Vector2(rect.xMax, rect.yMin);
			}
			if (point.y > rect.yMax)
			{
				return new Vector2(rect.xMax, rect.yMax);
			}
			return new Vector2(rect.xMax, point.y);
		}
		if (point.y < rect.yMin)
		{
			return new Vector2(point.x, rect.yMin);
		}
		if (point.y > rect.yMax)
		{
			return new Vector2(point.x, rect.yMax);
		}
		return point;
	}

	public static Vector2 RandomPointOnRect(Rect rect)
	{
		return UnityEngine.Random.Range(0, 4) switch
		{
			0 => new Vector2(UnityEngine.Random.Range(rect.xMin, rect.xMax), rect.yMin), 
			1 => new Vector2(UnityEngine.Random.Range(rect.xMin, rect.xMax), rect.yMax), 
			2 => new Vector2(rect.xMin, UnityEngine.Random.Range(rect.yMin, rect.yMax)), 
			_ => new Vector2(rect.xMax, UnityEngine.Random.Range(rect.yMin, rect.yMax)), 
		};
	}

	public static Vector2 RandomPointInRect(Rect rect)
	{
		return new Vector2(UnityEngine.Random.Range(rect.xMin, rect.xMax), UnityEngine.Random.Range(rect.yMin, rect.yMax));
	}

	public static Vector2 GetIntersectionPointFromRectCenter(Vector2 direction, Rect rect)
	{
		List<Vector2> list = new List<Vector2>();
		if (direction.x > 0f)
		{
			bool found;
			Vector2 intersectionPointCoordinates = GetIntersectionPointCoordinates(Vector2.zero, direction, new Vector2(rect.xMax, rect.yMin), new Vector2(rect.xMax, rect.yMax), out found);
			if (found)
			{
				list.Add(intersectionPointCoordinates);
			}
		}
		else if (direction.x < 0f)
		{
			bool found2;
			Vector2 intersectionPointCoordinates2 = GetIntersectionPointCoordinates(Vector2.zero, direction, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMin, rect.yMax), out found2);
			if (found2)
			{
				list.Add(intersectionPointCoordinates2);
			}
		}
		if (direction.y < 0f)
		{
			bool found3;
			Vector2 intersectionPointCoordinates3 = GetIntersectionPointCoordinates(Vector2.zero, direction, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMax, rect.yMin), out found3);
			if (found3)
			{
				list.Add(intersectionPointCoordinates3);
			}
		}
		else if (direction.y > 0f)
		{
			bool found4;
			Vector2 intersectionPointCoordinates4 = GetIntersectionPointCoordinates(Vector2.zero, direction, new Vector2(rect.xMin, rect.yMax), new Vector2(rect.xMax, rect.yMax), out found4);
			if (found4)
			{
				list.Add(intersectionPointCoordinates4);
			}
		}
		return Enumerable.First(Enumerable.OrderBy(list, (Vector2 x) => x.magnitude));
	}

	public static Vector2 GetIntersectionPointCoordinates(Vector2 A1, Vector2 A2, Vector2 B1, Vector2 B2, out bool found)
	{
		float num = (B2.x - B1.x) * (A2.y - A1.y) - (B2.y - B1.y) * (A2.x - A1.x);
		if (num == 0f)
		{
			found = false;
			return Vector2.zero;
		}
		float num2 = ((A1.x - B1.x) * (A2.y - A1.y) - (A1.y - B1.y) * (A2.x - A1.x)) / num;
		found = true;
		return new Vector2(B1.x + (B2.x - B1.x) * num2, B1.y + (B2.y - B1.y) * num2);
	}

	public static float DistancePointToRay(Ray ray, Vector3 point)
	{
		return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
	}

	public static List<int> DigitsOf(int value, bool abs = false, int numberBase = 10)
	{
		List<int> list = new List<int>();
		while (value > 0)
		{
			int num = value % numberBase;
			if (abs)
			{
				num = Mathf.Abs(num);
			}
			list.Add(num);
			value /= numberBase;
		}
		return list;
	}

	public static List<int> DigitsOf(long value, int numberBase = 10)
	{
		List<int> list = new List<int>();
		while (value > 0)
		{
			list.Add((int)(value % numberBase));
			value /= numberBase;
		}
		return list;
	}
}
