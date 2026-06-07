using System;
using UnityEngine;

public static class MathUtility
{
	public static double Pressure(double value, ModifierType modifier)
	{
		return Pressure(value, modifier.Double());
	}

	public static double Pressure(double value, double softCap)
	{
		if (softCap == 0.0)
		{
			return 0.0;
		}
		double num = Math.Clamp(0.0, 1.0, value / softCap);
		return num * num;
	}

	public static float Pressure(float value, ModifierType modifier)
	{
		return Pressure(value, modifier.Float());
	}

	public static float Pressure(float value, float softCap)
	{
		if (softCap == 0f)
		{
			return 0f;
		}
		float num = Mathf.Clamp01(value / softCap);
		return num * num;
	}

	public static double Resistance(double value, ModifierType modifier)
	{
		return Pressure(value, modifier.Double());
	}

	public static double Resistance(double value, double softCap)
	{
		if (softCap == 0.0)
		{
			return 0.0;
		}
		double num = value / softCap;
		return 1.0 / (1.0 + num * num);
	}

	public static float Resistance(float value, ModifierType modifier)
	{
		return Resistance(value, modifier.Float());
	}

	public static float Resistance(float value, float softCap)
	{
		if (softCap == 0f)
		{
			return 0f;
		}
		float num = value / softCap;
		return 1f / (1f + num * num);
	}

	public static float Resistance(float value, ModifierType modifier, float power)
	{
		return Resistance(value, modifier.Float(), power);
	}

	public static float Resistance(float value, float softCap, float power)
	{
		if (softCap == 0f)
		{
			return 0f;
		}
		float f = value / softCap;
		return 1f / (1f + Mathf.Pow(f, power));
	}

	public static double DataGainFormula(double value, float factor, double target, float factorPower, double max, float extra)
	{
		double num = value / target;
		double num2 = Math.Pow(factor, factorPower);
		return max * (1.0 - Math.Exp((0.0 - num) * (double)extra)) * num2;
	}

	public static double FansGainFormula(double value, float valuePower, float factor, float factorPower)
	{
		return Math.Pow(value, valuePower) * (double)Mathf.Pow(factor, factorPower);
	}
}
