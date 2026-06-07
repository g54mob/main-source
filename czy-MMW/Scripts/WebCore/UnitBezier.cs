using System;

public class UnitBezier
{
	private readonly float _cx;

	private readonly float _bx;

	private readonly float _ax;

	private readonly float _cy;

	private readonly float _by;

	private readonly float _ay;

	public static float SolveEpsilon(float duration)
	{
		return 1f / (200f * duration);
	}

	public float Solve(float x, float epsilon)
	{
		return SampleCurveY(SolveCurveX(x, epsilon));
	}

	public UnitBezier(float p1x, float p1y, float p2x, float p2y)
	{
		_cx = 3f * p1x;
		_bx = 3f * (p2x - p1x) - _cx;
		_ax = 1f - _cx - _bx;
		_cy = 3f * p1y;
		_by = 3f * (p2y - p1y) - _cy;
		_ay = 1f - _cy - _by;
	}

	private float SampleCurveX(float t)
	{
		return ((_ax * t + _bx) * t + _cx) * t;
	}

	private float SampleCurveY(float t)
	{
		return ((_ay * t + _by) * t + _cy) * t;
	}

	private float SampleCurveDerivativeX(float t)
	{
		return (3f * _ax * t + 2f * _bx) * t + _cx;
	}

	private float SolveCurveX(float x, float epsilon)
	{
		float num = x;
		for (int i = 0; i < 8; i++)
		{
			float num2 = SampleCurveX(num) - x;
			if (Math.Abs(num2) < epsilon)
			{
				return num;
			}
			float num3 = SampleCurveDerivativeX(num);
			if ((double)Math.Abs(num3) < 1E-06)
			{
				break;
			}
			num -= num2 / num3;
		}
		float num4 = 0f;
		float num5 = 1f;
		num = x;
		if (num < num4)
		{
			return num4;
		}
		if (num > num5)
		{
			return num5;
		}
		while (num4 < num5)
		{
			float num2 = SampleCurveX(num);
			if (Math.Abs(num2 - x) < epsilon)
			{
				return num;
			}
			if (x > num2)
			{
				num4 = num;
			}
			else
			{
				num5 = num;
			}
			num = (num5 - num4) * 0.5f + num4;
		}
		return num;
	}
}
