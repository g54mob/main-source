using System.Collections.Generic;

public class MergeCollision
{
	public class Point
	{
		public enum Type
		{
			Intersection = 0,
			Outside = 1
		}

		public Vector2D vector;

		public Type collision;

		public Point(Vector2D pos, Type col)
		{
		}
	}

	public bool error;

	public int collisionCount;

	public List<Point> collisionSlice;

	public Vector2D First()
	{
		return null;
	}

	public Vector2D Last()
	{
		return null;
	}

	public List<Vector2D> GetPoints()
	{
		return null;
	}

	public void Reverse()
	{
	}

	public MergeCollision(Polygon2D polygon, List<Vector2D> slice)
	{
	}
}
