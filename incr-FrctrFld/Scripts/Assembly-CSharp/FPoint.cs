using System;
using UnityEngine;

[Serializable]
public struct FPoint
{
	public FP X;

	public FP Y;

	public static FPoint Zero;

	public static FP PI;

	public static FP TwoPIF;

	public static FP PIOver180F;

	private static int[] SIN_TABLE;

	public override string ToString()
	{
		return null;
	}

	public static FPoint Create(FP X, FP Y)
	{
		return default(FPoint);
	}

	public static FPoint Create(Vector2 p)
	{
		return default(FPoint);
	}

	public static Vector2 ToVector2(FPoint f)
	{
		return default(Vector2);
	}

	public Vector2 ToPoint()
	{
		return default(Vector2);
	}

	public static FPoint VectorAdd(FPoint F1, FPoint F2)
	{
		return default(FPoint);
	}

	public static FPoint VectorSubtract(FPoint F1, FPoint F2)
	{
		return default(FPoint);
	}

	public static FPoint VectorDivide(FPoint F1, int Divisor)
	{
		return default(FPoint);
	}

	public static FPoint VectorDivide(FPoint F1, FP Divisor)
	{
		return default(FPoint);
	}

	public static FPoint VectorMultiply(FPoint F1, int multiple)
	{
		return default(FPoint);
	}

	public static FPoint VectorMultiply(FPoint F1, FP multiple)
	{
		return default(FPoint);
	}

	public FP Magnitude()
	{
		return default(FP);
	}

	public static FP Magnitude(FPoint F1)
	{
		return default(FP);
	}

	public FP Distance(FPoint other)
	{
		return default(FP);
	}

	public static FP Distance(FPoint a, FPoint b)
	{
		return default(FP);
	}

	public static FPoint Normalize(FPoint F1)
	{
		return default(FPoint);
	}

	public static FPoint MoveTowards(FPoint position, FPoint destination, FP maxDistance)
	{
		return default(FPoint);
	}

	public static FPoint MoveTowardsAbsY(FPoint start, FPoint destination, FP maxDistance)
	{
		return default(FPoint);
	}

	public static FP Sqrt(FP f, int NumberOfIterations)
	{
		return default(FP);
	}

	public static FP Sqrt(FP f)
	{
		return default(FP);
	}

	public static FP Sin(FP i)
	{
		return default(FP);
	}

	private static FP SinLookup(FP i, FP j)
	{
		return default(FP);
	}

	private static FP Mul(FP F1, FP F2)
	{
		return default(FP);
	}

	public static FP Cos(FP i)
	{
		return default(FP);
	}

	public static FP Tan(FP i)
	{
		return default(FP);
	}

	public static FP Asin(FP F)
	{
		return default(FP);
	}

	public static FP Atan(FP F)
	{
		return default(FP);
	}

	public static FP Atan2(FP F1, FP F2)
	{
		return default(FP);
	}

	public static FP Abs(FP F)
	{
		return default(FP);
	}
}
