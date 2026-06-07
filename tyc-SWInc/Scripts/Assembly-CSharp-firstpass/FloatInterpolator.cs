using System;
using UnityEngine;

public class FloatInterpolator
{
	public float[] Values;

	public float Scale;

	public FloatInterpolator(float scale, float[] values)
	{
		Scale = scale;
		Values = values;
	}

	public FloatInterpolator(params float[] values)
	{
		Scale = 1f / (float)(values.Length - 1);
		Values = values;
	}

	public FloatInterpolator(Func<float, float> eval, int values)
	{
		Values = new float[values];
		for (int i = 0; i < values; i++)
		{
			Values[i] = eval((float)i / ((float)values - 1f));
		}
		Scale = 1f / (float)(values - 1);
	}

	public float Evaluate(float input)
	{
		float num = input / Scale;
		int num2 = Mathf.FloorToInt(num);
		if (num2 >= Values.Length - 1)
		{
			return Values[Values.Length - 1];
		}
		if (num2 < 0)
		{
			return Values[0];
		}
		return Mathf.Lerp(Values[num2], Values[num2 + 1], num - (float)num2);
	}
}
