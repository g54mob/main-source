using System.Collections.Generic;
using UnityEngine;

public static class SplineInterp
{
	public struct Point2D
	{
		public readonly int X;

		public readonly int Y;

		public Point2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static implicit operator Vector2(Point2D p)
		{
			return new Vector2(p.X, p.Y);
		}

		public static implicit operator Point2D(Vector2 v)
		{
			return new Point2D(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y));
		}

		public static bool operator ==(Point2D p1, Point2D p2)
		{
			if (p1.X == p2.X)
			{
				return p1.Y == p2.Y;
			}
			return false;
		}

		public static bool operator !=(Point2D p1, Point2D p2)
		{
			if (p1.X == p2.X)
			{
				return p1.Y != p2.Y;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return 32768 * X + Y;
		}

		public bool Equals(Point2D p)
		{
			return this == p;
		}

		public override bool Equals(object obj)
		{
			return obj.GetHashCode() == GetHashCode();
		}
	}

	public static List<Vector2> SoftenCorners(List<Point2D> Path)
	{
		List<Vector2> list = new List<Vector2>(Path.Count);
		list.Add(new Vector2(Path[0].X, Path[0].Y));
		for (int i = 1; i < Path.Count - 1; i++)
		{
			int num = Path[i - 1].X - Path[i].X;
			int num2 = Path[i - 1].Y - Path[i].Y;
			int num3 = Path[i].X - Path[i + 1].X;
			int num4 = Path[i].Y - Path[i + 1].Y;
			if (num == num3 && num2 == num4)
			{
				list.Add(Path[i]);
				continue;
			}
			Vector2 x = Lerp(Path[i - 1], Path[i + 1]);
			list.Add(Lerp(x, Path[i]));
		}
		list.Add(new Vector2(Path[Path.Count - 1].X, Path[Path.Count - 1].Y));
		return list;
	}

	private static Vector2 Lerp(Vector2 x, Vector2 y)
	{
		float x2 = (x.x + y.x) / 2f;
		float y2 = (x.y + y.y) / 2f;
		return new Vector2(x2, y2);
	}

	public static List<Vector2> Interp(List<Vector2> input, int steps, float tension)
	{
		List<Vector2> list = new List<Vector2>();
		for (int i = 0; i < input.Count - 1; i++)
		{
			for (int j = 0; j < steps; j++)
			{
				float num = (float)j / (float)steps;
				float num2 = num * num;
				float num3 = num2 * num;
				float num4 = 2f * num3 - 3f * num2 + 1f;
				float num5 = -2f * num3 + 3f * num2;
				float num6 = num3 - 2f * num2 + num;
				float num7 = num3 - num2;
				Vector2 vector = input[Mathf.Max(0, i - 1)];
				Vector2 vector2 = input[Mathf.Min(input.Count - 1, i + 1)];
				Vector2 vector3 = new Vector2(tension * (vector2.x - vector.x), tension * (vector2.y - vector.y));
				vector = input[Mathf.Max(0, i)];
				vector2 = input[Mathf.Min(input.Count - 1, i + 2)];
				Vector2 vector4 = new Vector2(tension * (vector2.x - vector.x), tension * (vector2.y - vector.y));
				list.Add(num4 * input[i] + num5 * input[i + 1] + num6 * vector3 + num7 * vector4);
			}
		}
		list.Add(input[input.Count - 1]);
		return list;
	}

	public static List<Vector3> Interp(List<Vector3> input, int steps, float tension)
	{
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < input.Count - 1; i++)
		{
			for (int j = 0; j < steps; j++)
			{
				float num = (float)j / (float)steps;
				float num2 = num * num;
				float num3 = num2 * num;
				float num4 = 2f * num3 - 3f * num2 + 1f;
				float num5 = -2f * num3 + 3f * num2;
				float num6 = num3 - 2f * num2 + num;
				float num7 = num3 - num2;
				Vector3 vector = input[Mathf.Max(0, i - 1)];
				Vector3 vector2 = input[Mathf.Min(input.Count - 1, i + 1)];
				Vector3 vector3 = new Vector3(tension * (vector2.x - vector.x), tension * (vector2.y - vector.y), tension * (vector2.z - vector.z));
				vector = input[Mathf.Max(0, i)];
				vector2 = input[Mathf.Min(input.Count - 1, i + 2)];
				Vector3 vector4 = new Vector3(tension * (vector2.x - vector.x), tension * (vector2.y - vector.y), tension * (vector2.z - vector.z));
				list.Add(num4 * input[i] + num5 * input[i + 1] + num6 * vector3 + num7 * vector4);
			}
		}
		list.Add(input[input.Count - 1]);
		return list;
	}
}
