using UnityEngine;

public class Vector2D
{
	public double x;

	public double y;

	public static double round(double value, int places = 1)
	{
		return 0.0;
	}

	public new string ToString()
	{
		return null;
	}

	public static Vector2D Zero()
	{
		return null;
	}

	public Vector2D(double px, double py)
	{
	}

	public Vector2D(Vector2D point)
	{
	}

	public Vector2D(Vector2 point)
	{
	}

	public Vector2D Copy()
	{
		return null;
	}

	public void Set(double px, double py)
	{
	}

	public void Set(Vector2D point)
	{
	}

	public void Push(double rot, double distance)
	{
	}

	public void Push(double rot, double distance, Vector2 scale)
	{
	}

	public Vector2D InverseTransformPoint(Transform transform)
	{
		return null;
	}

	public void Inc(double px, double py)
	{
	}

	public void Dec(double px, double py)
	{
	}

	public void Inc(Vector2D point)
	{
	}

	public void Dec(Vector2D point)
	{
	}

	public static double Distance(Vector2D a, Vector2D b)
	{
		return 0.0;
	}

	public static double DistanceSqr(Vector2D a, Vector2D b)
	{
		return 0.0;
	}

	public static double Atan2(Vector2D a, Vector2D b)
	{
		return 0.0;
	}

	public static double Atan2(Vector2 a, Vector2 b)
	{
		return 0.0;
	}

	public static Vector2D RotToVec(double rotation)
	{
		return null;
	}

	public static double VecToRot(Vector2 vec)
	{
		return 0.0;
	}

	public Vector2 ToVector2()
	{
		return default(Vector2);
	}

	public Vector3 ToVector3(float z = 0f)
	{
		return default(Vector3);
	}

	public void RotToVecItself(double rotation)
	{
	}

	public static Vector2D operator +(Vector2D c1, Vector2D c2)
	{
		return null;
	}

	public static Vector2D operator -(Vector2D c1, Vector2D c2)
	{
		return null;
	}

	public static Vector2D operator /(Vector2D c1, float c2)
	{
		return null;
	}

	public static Vector2D operator *(Vector2D c1, float c2)
	{
		return null;
	}

	public static Vector2D operator -(Vector2D c1, float c2)
	{
		return null;
	}

	public static Vector2D operator +(Vector2D c1, float c2)
	{
		return null;
	}
}
