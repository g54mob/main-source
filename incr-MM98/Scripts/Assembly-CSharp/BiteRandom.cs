using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class BiteRandom
{
	public static Xoshiro256StarStarRandom Shared { get; }

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color NextColor()
	{
		return NextVector4();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color NextColor(float alpha)
	{
		return new Color(NextFloat(), NextFloat(), NextFloat(), alpha);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color NextColor(Color max)
	{
		return NextVector4(max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color NextColor(Color max, float alpha)
	{
		return new Color(NextFloat(max.r), NextFloat(max.g), NextFloat(max.b), alpha);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color NextColor(Color min, Color max)
	{
		return NextVector4(min, max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color NextColor(Color min, Color max, float alpha)
	{
		return new Color(NextFloat(min.r, max.r), NextFloat(min.g, max.g), NextFloat(min.b, max.b), alpha);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color NextColor(Gradient gradient)
	{
		return gradient.Evaluate(NextFloat());
	}

	public static Color NextColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax)
	{
		float h = Mathf.Lerp(hueMin, hueMax, NextFloat());
		float s = Mathf.Lerp(saturationMin, saturationMax, NextFloat());
		float v = Mathf.Lerp(valueMin, valueMax, NextFloat());
		return Color.HSVToRGB(h, s, v, hdr: true);
	}

	public static Color NextColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax, float alphaMin, float alphaMax)
	{
		Color result = NextColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);
		result.a = Mathf.Lerp(alphaMin, alphaMax, NextFloat());
		return result;
	}

	static BiteRandom()
	{
		Shared = new Xoshiro256StarStarRandom();
		Shared.InitState();
	}

	public static Xoshiro256StarStarRandom Instance()
	{
		Xoshiro256StarStarRandom xoshiro256StarStarRandom = new Xoshiro256StarStarRandom();
		xoshiro256StarStarRandom.InitState(Shared.State);
		return xoshiro256StarStarRandom;
	}

	public static void InitState(uint seed)
	{
		Shared.InitState(seed);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool NextBool()
	{
		return (Shared.NextUInt() & 1) == 1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool NextBool(float probability)
	{
		if (!(probability <= 0f))
		{
			if (probability >= 1f)
			{
				return true;
			}
			return NextDouble() < (double)probability;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int NegOrPos(float probability = 0.5f)
	{
		if (!NextBool(probability))
		{
			return -1;
		}
		return 1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int NextInt()
	{
		return (int)Shared.NextUInt() ^ int.MinValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int NextInt(int max)
	{
		return (int)((ulong)(Shared.NextUInt() * max) >> 32);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int NextInt(int min, int max)
	{
		return (int)((ulong)(Shared.NextUInt() * (max - min)) >> 32) + min;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int NextIntOffset(int value, int offset)
	{
		return NextInt(value - Math.Abs(offset), value + Math.Abs(offset));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long NextLong()
	{
		return (long)Shared.NextULong();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long NextLong(long max)
	{
		if (max <= int.MaxValue)
		{
			return (int)((ulong)(Shared.NextUInt() * max) >> 32);
		}
		return (long)Shared.NextULong();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long NextLong(long min, long max)
	{
		return NextLong(max - min) + min;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long NextLongOffset(long value, long offset)
	{
		return NextLong(value - Math.Abs(offset), value + Math.Abs(offset));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float NextFloat()
	{
		return (float)(Shared.NextUInt() >> 8) * 5.9604645E-08f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float NextFloat(float max)
	{
		return NextFloat() * max;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float NextFloat(float min, float max)
	{
		float num = NextFloat(max - min) + min;
		if (num >= max)
		{
			num = BitDecrement(max);
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float NextLongOffset(float value, float offset)
	{
		return NextFloat(value - Math.Abs(offset), value + Math.Abs(offset));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double NextDouble()
	{
		return (double)(Shared.NextULong() >> 11) * 1.1102230246251565E-16;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double NextDouble(double max)
	{
		return NextDouble() * max;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double NextDouble(double min, double max)
	{
		double num = NextDouble(max - min) + min;
		if (num >= max)
		{
			num = BitDecrement(max);
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double NextDoubleOffset(double value, double offset)
	{
		return NextDouble(value - Math.Abs(offset), value + Math.Abs(offset));
	}

	public static double NextDoubleGaussian()
	{
		double num;
		double num3;
		do
		{
			num = 2.0 * NextDouble() - 1.0;
			double num2 = 2.0 * NextDouble() - 1.0;
			num3 = num * num + num2 * num2;
		}
		while (num3 >= 1.0 || num3 == 0.0);
		return num * Math.Sqrt(-2.0 * Math.Log(num3) / num3);
	}

	private static float BitDecrement(float x)
	{
		int num = BitConverter.SingleToInt32Bits(x);
		if ((num & 0x7F800000) >= 2139095040)
		{
			if (num != 2139095040)
			{
				return x;
			}
			return float.MaxValue;
		}
		if (num == 0)
		{
			return -1E-45f;
		}
		num += ((num < 0) ? 1 : (-1));
		return BitConverter.Int32BitsToSingle(num);
	}

	private static double BitDecrement(double x)
	{
		long num = BitConverter.DoubleToInt64Bits(x);
		if (((num >> 32) & 0x7FF00000) >= 2146435072)
		{
			if (num != 9218868437227405312L)
			{
				return x;
			}
			return double.MaxValue;
		}
		if (num == 0L)
		{
			return -5E-324;
		}
		num += ((num < 0) ? 1 : (-1));
		return BitConverter.Int64BitsToDouble(num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2 NextVector2()
	{
		return new Vector2(NextFloat(), NextFloat());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2 NextVector2(Vector2 max)
	{
		return new Vector2(NextFloat(max.x), NextFloat(max.y));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2 NextVector2(Vector2 min, Vector2 max)
	{
		return new Vector2(NextFloat(min.x, max.x), NextFloat(min.y, max.y));
	}

	public static Vector2 NextVector2Direction()
	{
		float f = NextFloat() * MathF.PI * 2f;
		return new Vector2(Mathf.Cos(f), Mathf.Sin(f));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2 NextVector2InsideCircle()
	{
		return NextVector2Direction() * NextFloat();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3 NextVector3()
	{
		return new Vector3(NextFloat(), NextFloat(), NextFloat());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3 NextVector3(Vector3 max)
	{
		return new Vector3(NextFloat(max.x), NextFloat(max.y), NextFloat(max.z));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3 NextVector3(Vector3 min, Vector3 max)
	{
		return new Vector3(NextFloat(min.x, max.x), NextFloat(min.y, max.y), NextFloat(min.z, max.z));
	}

	public static Vector3 NextVector3Direction()
	{
		Vector2 vector = NextVector2();
		float num = vector.x * 2f - 1f;
		float num2 = Mathf.Sqrt(Mathf.Max(1f - num * num, 0f));
		float f = vector.y * MathF.PI * 2f;
		return new Vector3(Mathf.Cos(f) * num2, Mathf.Sin(f) * num2, num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3 NextVector3InsideSphere()
	{
		return NextVector3Direction() * NextFloat();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NextVector4()
	{
		return new Vector4(NextFloat(), NextFloat(), NextFloat(), NextFloat());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NextVector4(Vector4 max)
	{
		return new Vector4(NextFloat(max.x), NextFloat(max.y), NextFloat(max.z), NextFloat(max.w));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NextVector4(Vector4 min, Vector4 max)
	{
		return new Vector4(NextFloat(min.x, max.x), NextFloat(min.y, max.y), NextFloat(min.z, max.z), NextFloat(min.w, max.w));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2Int NextVector2Int()
	{
		return new Vector2Int(NextInt(), NextInt());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2Int NextVector2Int(Vector2Int max)
	{
		return new Vector2Int(NextInt(max.x), NextInt(max.y));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2Int NextVector2Int(Vector2Int min, Vector2Int max)
	{
		return new Vector2Int(NextInt(min.x, max.x), NextInt(min.y, max.y));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3Int NextVector3Int()
	{
		return new Vector3Int(NextInt(), NextInt(), NextInt());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3Int NextVector3Int(Vector3Int max)
	{
		return new Vector3Int(NextInt(max.x), NextInt(max.y), NextInt(max.z));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3Int NextVector3Int(Vector3Int min, Vector3Int max)
	{
		return new Vector3Int(NextInt(min.x, max.x), NextInt(min.y, max.y), NextInt(min.z, max.z));
	}

	public static Quaternion NextQuaternionRotation()
	{
		Vector3 vector = NextVector3(new Vector3(MathF.PI * 2f, MathF.PI * 2f, 1f));
		float z = vector.z;
		Vector2 vector2 = vector;
		float num = Mathf.Sqrt(1f - z);
		float num2 = Mathf.Sqrt(z);
		Vector2 vector3 = new Vector2(Mathf.Sin(vector2.x), Mathf.Sin(vector2.y));
		Vector2 vector4 = new Vector2(Mathf.Cos(vector2.x), Mathf.Cos(vector2.y));
		Quaternion result = new Quaternion(num * vector3.x, num * vector4.x, num2 * vector3.y, num2 * vector4.y);
		if (!(result.w < 0f))
		{
			return new Quaternion(0f - result.x, 0f - result.y, 0f - result.z, 0f - result.w);
		}
		return result;
	}
}
