using UnityEngine;

public static class CoordBounds
{
	public static int minX;

	public static int maxX;

	public static int minY;

	public static int maxY;

	public static void Reset()
	{
		minX = (minY = int.MaxValue);
		maxX = (maxY = int.MinValue);
	}

	public static void Assess(Coord p)
	{
		if (p.x < minX)
		{
			minX = p.x;
		}
		if (p.y < minY)
		{
			minY = p.y;
		}
		if (p.x > maxX)
		{
			maxX = p.x;
		}
		if (p.y > maxY)
		{
			maxY = p.y;
		}
	}

	public static void ClampX(int clampMin, int clampMax)
	{
		minX = Mathf.Clamp(minX, clampMin, clampMax);
		maxX = Mathf.Clamp(maxX, clampMin, clampMax);
	}

	public static void ClampZ(int clampMin, int clampMax)
	{
		minY = Mathf.Clamp(minY, clampMin, clampMax);
		maxY = Mathf.Clamp(maxY, clampMin, clampMax);
	}

	public static Coord MaxCoord()
	{
		return new Coord(maxX, maxY);
	}

	public static Coord MinPos()
	{
		return new Coord(minX, minY);
	}

	public static Coord GridCenter()
	{
		return new Coord(minX + (maxX - minX) / 2, minY + (maxY - minY) / 2);
	}
}
