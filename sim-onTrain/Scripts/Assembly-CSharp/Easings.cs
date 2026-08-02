using System;
using UnityEngine;

public static class Easings
{
	public enum Function
	{
		Linear = 0,
		QuadraticEaseIn = 1,
		QuadraticEaseOut = 2,
		QuadraticEaseInOut = 3,
		CubicEaseIn = 4,
		CubicEaseOut = 5,
		CubicEaseInOut = 6,
		QuarticEaseIn = 7,
		QuarticEaseOut = 8,
		QuarticEaseInOut = 9,
		QuinticEaseIn = 10,
		QuinticEaseOut = 11,
		QuinticEaseInOut = 12,
		SineEaseIn = 13,
		SineEaseOut = 14,
		SineEaseInOut = 15,
		CircularEaseIn = 16,
		CircularEaseOut = 17,
		CircularEaseInOut = 18,
		ExponentialEaseIn = 19,
		ExponentialEaseOut = 20,
		ExponentialEaseInOut = 21,
		ElasticEaseIn = 22,
		ElasticEaseOut = 23,
		ElasticEaseInOut = 24,
		BackEaseIn = 25,
		BackEaseOut = 26,
		BackEaseInOut = 27,
		BounceEaseIn = 28,
		BounceEaseOut = 29,
		BounceEaseInOut = 30
	}

	private const float PI = MathF.PI;

	private const float HALFPI = MathF.PI / 2f;

	public static float Interpolate(ref float currentTime, float duration, float deltaTime, bool reverse = false, Function function = Function.Linear)
	{
		currentTime = Mathf.Clamp01(currentTime + deltaTime / duration * (float)((!reverse) ? 1 : (-1)));
		return Interpolate(currentTime, function);
	}

	public static float Interpolate(float p, Function function)
	{
		return function switch
		{
			Function.QuadraticEaseOut => QuadraticEaseOut(p), 
			Function.QuadraticEaseIn => QuadraticEaseIn(p), 
			Function.QuadraticEaseInOut => QuadraticEaseInOut(p), 
			Function.CubicEaseIn => CubicEaseIn(p), 
			Function.CubicEaseOut => CubicEaseOut(p), 
			Function.CubicEaseInOut => CubicEaseInOut(p), 
			Function.QuarticEaseIn => QuarticEaseIn(p), 
			Function.QuarticEaseOut => QuarticEaseOut(p), 
			Function.QuarticEaseInOut => QuarticEaseInOut(p), 
			Function.QuinticEaseIn => QuinticEaseIn(p), 
			Function.QuinticEaseOut => QuinticEaseOut(p), 
			Function.QuinticEaseInOut => QuinticEaseInOut(p), 
			Function.SineEaseIn => SineEaseIn(p), 
			Function.SineEaseOut => SineEaseOut(p), 
			Function.SineEaseInOut => SineEaseInOut(p), 
			Function.CircularEaseIn => CircularEaseIn(p), 
			Function.CircularEaseOut => CircularEaseOut(p), 
			Function.CircularEaseInOut => CircularEaseInOut(p), 
			Function.ExponentialEaseIn => ExponentialEaseIn(p), 
			Function.ExponentialEaseOut => ExponentialEaseOut(p), 
			Function.ExponentialEaseInOut => ExponentialEaseInOut(p), 
			Function.ElasticEaseIn => ElasticEaseIn(p), 
			Function.ElasticEaseOut => ElasticEaseOut(p), 
			Function.ElasticEaseInOut => ElasticEaseInOut(p), 
			Function.BackEaseIn => BackEaseIn(p), 
			Function.BackEaseOut => BackEaseOut(p), 
			Function.BackEaseInOut => BackEaseInOut(p), 
			Function.BounceEaseIn => BounceEaseIn(p), 
			Function.BounceEaseOut => BounceEaseOut(p), 
			Function.BounceEaseInOut => BounceEaseInOut(p), 
			_ => Linear(p), 
		};
	}

	public static float Linear(float p)
	{
		return p;
	}

	public static float QuadraticEaseIn(float p)
	{
		return p * p;
	}

	public static float QuadraticEaseOut(float p)
	{
		return 0f - p * (p - 2f);
	}

	public static float QuadraticEaseInOut(float p)
	{
		if (p < 0.5f)
		{
			return 2f * p * p;
		}
		return -2f * p * p + 4f * p - 1f;
	}

	public static float CubicEaseIn(float p)
	{
		return p * p * p;
	}

	public static float CubicEaseOut(float p)
	{
		float num = p - 1f;
		return num * num * num + 1f;
	}

	public static float CubicEaseInOut(float p)
	{
		if (p < 0.5f)
		{
			return 4f * p * p * p;
		}
		float num = 2f * p - 2f;
		return 0.5f * num * num * num + 1f;
	}

	public static float QuarticEaseIn(float p)
	{
		return p * p * p * p;
	}

	public static float QuarticEaseOut(float p)
	{
		float num = p - 1f;
		return num * num * num * (1f - p) + 1f;
	}

	public static float QuarticEaseInOut(float p)
	{
		if (p < 0.5f)
		{
			return 8f * p * p * p * p;
		}
		float num = p - 1f;
		return -8f * num * num * num * num + 1f;
	}

	public static float QuinticEaseIn(float p)
	{
		return p * p * p * p * p;
	}

	public static float QuinticEaseOut(float p)
	{
		float num = p - 1f;
		return num * num * num * num * num + 1f;
	}

	public static float QuinticEaseInOut(float p)
	{
		if (p < 0.5f)
		{
			return 16f * p * p * p * p * p;
		}
		float num = 2f * p - 2f;
		return 0.5f * num * num * num * num * num + 1f;
	}

	public static float SineEaseIn(float p)
	{
		return Mathf.Sin((p - 1f) * (MathF.PI / 2f)) + 1f;
	}

	public static float SineEaseOut(float p)
	{
		return Mathf.Sin(p * (MathF.PI / 2f));
	}

	public static float SineEaseInOut(float p)
	{
		return 0.5f * (1f - Mathf.Cos(p * MathF.PI));
	}

	public static float CircularEaseIn(float p)
	{
		return 1f - Mathf.Sqrt(1f - p * p);
	}

	public static float CircularEaseOut(float p)
	{
		return Mathf.Sqrt((2f - p) * p);
	}

	public static float CircularEaseInOut(float p)
	{
		if (p < 0.5f)
		{
			return 0.5f * (1f - Mathf.Sqrt(1f - 4f * (p * p)));
		}
		return 0.5f * (Mathf.Sqrt((0f - (2f * p - 3f)) * (2f * p - 1f)) + 1f);
	}

	public static float ExponentialEaseIn(float p)
	{
		if (p != 0f)
		{
			return Mathf.Pow(2f, 10f * (p - 1f));
		}
		return p;
	}

	public static float ExponentialEaseOut(float p)
	{
		if (p != 1f)
		{
			return 1f - Mathf.Pow(2f, -10f * p);
		}
		return p;
	}

	public static float ExponentialEaseInOut(float p)
	{
		if ((double)p == 0.0 || (double)p == 1.0)
		{
			return p;
		}
		if (p < 0.5f)
		{
			return 0.5f * Mathf.Pow(2f, 20f * p - 10f);
		}
		return -0.5f * Mathf.Pow(2f, -20f * p + 10f) + 1f;
	}

	public static float ElasticEaseIn(float p)
	{
		return Mathf.Sin(20.420353f * p) * Mathf.Pow(2f, 10f * (p - 1f));
	}

	public static float ElasticEaseOut(float p)
	{
		return Mathf.Sin(-20.420353f * (p + 1f)) * Mathf.Pow(2f, -10f * p) + 1f;
	}

	public static float ElasticEaseInOut(float p)
	{
		if (p < 0.5f)
		{
			return 0.5f * Mathf.Sin(20.420353f * (2f * p)) * Mathf.Pow(2f, 10f * (2f * p - 1f));
		}
		return 0.5f * (Mathf.Sin(-20.420353f * (2f * p - 1f + 1f)) * Mathf.Pow(2f, -10f * (2f * p - 1f)) + 2f);
	}

	public static float BackEaseIn(float p)
	{
		return p * p * p - p * Mathf.Sin(p * MathF.PI);
	}

	public static float BackEaseOut(float p)
	{
		float num = 1f - p;
		return 1f - (num * num * num - num * Mathf.Sin(num * MathF.PI));
	}

	public static float BackEaseInOut(float p)
	{
		if (p < 0.5f)
		{
			float num = 2f * p;
			return 0.5f * (num * num * num - num * Mathf.Sin(num * MathF.PI));
		}
		float num2 = 1f - (2f * p - 1f);
		return 0.5f * (1f - (num2 * num2 * num2 - num2 * Mathf.Sin(num2 * MathF.PI))) + 0.5f;
	}

	public static float BounceEaseIn(float p)
	{
		return 1f - BounceEaseOut(1f - p);
	}

	public static float BounceEaseOut(float p)
	{
		if (p < 0.36363637f)
		{
			return 121f * p * p / 16f;
		}
		if (p < 0.72727275f)
		{
			return 9.075f * p * p - 9.9f * p + 3.4f;
		}
		if (p < 0.9f)
		{
			return 12.066482f * p * p - 19.635458f * p + 8.898061f;
		}
		return 10.8f * p * p - 20.52f * p + 10.72f;
	}

	public static float BounceEaseInOut(float p)
	{
		if (p < 0.5f)
		{
			return 0.5f * BounceEaseIn(p * 2f);
		}
		return 0.5f * BounceEaseOut(p * 2f - 1f) + 0.5f;
	}
}
