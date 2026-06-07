using System.Collections.Generic;

public class ComplexCollision
{
	public class Point
	{
		public enum Type
		{
			Intersection = 0,
			Inside = 1,
			Outside = 2
		}

		public Vector2D vector;

		public Type collision;

		public Point(Vector2D pos, Type col)
		{
		}
	}

	public List<Point> collisionSlice;

	public int collisionCount;

	public bool error;

	private Pair2D outside;

	private Pair2D inside;

	private bool calculated;

	private List<Vector2D> points;

	public List<Pair2D> polygonCollisionPairs;

	public static double precision;

	public ComplexCollision(Polygon2D polygon, List<Vector2D> slice)
	{
	}

	public Vector2D First()
	{
		return null;
	}

	public Vector2D Last()
	{
		return null;
	}

	public void Reverse()
	{
	}

	public List<Vector2D> GetPoints()
	{
		return null;
	}

	public List<Vector2D> GetPointsInside()
	{
		return null;
	}

	public List<Vector2D> GetPointsInsidePlus()
	{
		return null;
	}

	public List<Vector2D> GetSlicePoints()
	{
		return null;
	}
}
