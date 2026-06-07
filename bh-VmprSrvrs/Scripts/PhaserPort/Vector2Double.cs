using System;

[Serializable]
[Obsolete("Vector2Double is obsolete, use float2 instead. Don't use double, please.", true)]
public struct Vector2Double
{
	public double x;

	public double y;

	public static Vector2Double zero => default(Vector2Double);

	public Vector2Double(double x, double y)
	{
		this.x = 0.0;
		this.y = 0.0;
	}

	public static Vector2Double operator +(Vector2Double a, Vector2Double b)
	{
		return default(Vector2Double);
	}

	public static Vector2Double operator -(Vector2Double a, Vector2Double b)
	{
		return default(Vector2Double);
	}

	public static Vector2Double operator *(Vector2Double a, double scale)
	{
		return default(Vector2Double);
	}

	public static Vector2Double operator /(Vector2Double a, double scale)
	{
		return default(Vector2Double);
	}

	public static Vector2Double operator *(Vector2Double a, Vector2Double b)
	{
		return default(Vector2Double);
	}

	public static bool operator ==(Vector2Double a, Vector2Double b)
	{
		return false;
	}

	public static bool operator !=(Vector2Double a, Vector2Double b)
	{
		return false;
	}

	public void Set(double x, double y)
	{
	}

	public void Set(double value)
	{
	}

	public Vector2Double setToPolar(double azimuth, double radius = 1.0)
	{
		return default(Vector2Double);
	}

	public Vector2Double normalize()
	{
		return default(Vector2Double);
	}

	public Vector2Double scale(double scalar)
	{
		return default(Vector2Double);
	}
}
