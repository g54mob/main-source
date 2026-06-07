using UnityEngine;

public struct GridNodePolygon
{
	public static Vector2 NormalUp = Vector2.up;

	public static Vector2 NormalRight = Vector2.right;

	public Vector2 Center;

	private Vector2 _boundsMin;

	private Vector2 _boundsMax;

	private Vector2[] _vertices;

	public GridNodePolygon(Vector2 center, Vector2 size)
	{
		Center = center;
		Vector2 vector = size / 2f;
		_boundsMin = center - vector;
		_boundsMax = center + vector;
		_vertices = new Vector2[4]
		{
			new Vector2(_boundsMin.x, _boundsMax.y),
			_boundsMax,
			new Vector2(_boundsMax.x, _boundsMin.y),
			_boundsMin
		};
	}

	public bool ReturnIsPolygonOverlapping(Polygon polygon)
	{
		Vector2[] vertices = polygon.ReturnPolygon();
		if (ReturnAreProjectionsOverlapping(vertices, NormalUp, _boundsMin.y, _boundsMax.y) && ReturnAreProjectionsOverlapping(vertices, NormalRight, _boundsMin.x, _boundsMax.x))
		{
			return polygon.ReturnIsPolygonOverlapping(_vertices);
		}
		return false;
	}

	private bool ReturnAreProjectionsOverlapping(Vector2[] vertices, Vector2 axis, float min, float max)
	{
		Vector2 vector = vertices[0];
		float num = axis.x * vector.x + axis.y * vector.y;
		float num2 = num;
		float num3 = num;
		int num4 = vertices.Length;
		for (int i = 1; i < num4; i++)
		{
			vector = vertices[i];
			num = axis.x * vector.x + axis.y * vector.y;
			if (num < num2)
			{
				num2 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
		}
		if (!(num3 < min))
		{
			return !(max < num2);
		}
		return false;
	}
}
