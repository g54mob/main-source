using System;
using UnityEngine;

public class oe
{
	[Serializable]
	public struct Curve
	{
		public CurveType easeType;

		public AnimationCurve animationCurve;

		public Curve(CurveType type)
		{
			easeType = default(CurveType);
			animationCurve = null;
		}
	}

	public enum CurveType
	{
		Linear = 0,
		Sine = 1,
		Cubic = 2,
		Custom = 3
	}

	public static float djl(AnimationCurve a)
	{
		return 0f;
	}

	public static float kbk(AnimationCurve a)
	{
		return 0f;
	}

	public static float eoi(float a, float b, float c)
	{
		return 0f;
	}

	public static float ety(AnimationCurve a)
	{
		return 0f;
	}

	public static float dgp(AnimationCurve a)
	{
		return 0f;
	}

	public static float fnb(float a, float b, float c, AnimationCurve d)
	{
		return 0f;
	}

	public static float fsy(float a, float b, float c, AnimationCurve d)
	{
		return 0f;
	}

	public static float zg(float a, float b, float c, Curve d)
	{
		return 0f;
	}

	public static float fsw(float a, float b, float c)
	{
		return 0f;
	}

	public static float cwb(float a, float b, float c, Curve d)
	{
		return 0f;
	}

	public static float dvq(float a, float b, float c, Curve d)
	{
		return 0f;
	}

	public static float fsu(AnimationCurve a)
	{
		return 0f;
	}

	public static float py(float a, float b, float c, Curve d)
	{
		return 0f;
	}

	public static float fsx(float a, float b, float c)
	{
		return 0f;
	}

	public static float fsv(float a, float b, float c, Curve d)
	{
		return 0f;
	}

	public static float crg(float a, float b, float c, AnimationCurve d)
	{
		return 0f;
	}

	public static float olg(float a, float b, float c, AnimationCurve d)
	{
		return 0f;
	}
}
