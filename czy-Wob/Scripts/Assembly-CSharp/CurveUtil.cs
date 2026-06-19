using System.Collections.Generic;
using UnityEngine;

public class CurveUtil
{
	private static float staticVal;

	private static int staticNumValues;

	private static AnimationCurve staticCurve;

	private static List<float> staticTimes = new List<float>();

	public static float EvaluateAverageCurveTime(AnimationCurve curve, float time, float previousTime)
	{
		if (previousTime < 0f)
		{
			previousTime = 0f;
		}
		float num = curve.Evaluate(time) + curve.Evaluate(previousTime);
		int num2 = 2;
		for (int i = 0; i < curve.length; i++)
		{
			float time2 = curve.keys[i].time;
			if (time2 > previousTime && time2 < time)
			{
				num += curve.Evaluate(time2);
				num2++;
			}
		}
		return num / (float)num2;
	}

	public static float EvaluateAverageCurveWrapperTime(AnimationCurveWrapper wrapper, float time, float previousTime)
	{
		if (previousTime < 0f)
		{
			previousTime = 0f;
		}
		if (wrapper == null)
		{
			return 0f;
		}
		staticCurve = wrapper.GetCurve();
		staticTimes.Clear();
		staticTimes.AddRange(wrapper.KeyframeTimes());
		staticVal = staticCurve.Evaluate(time) + staticCurve.Evaluate(previousTime);
		staticNumValues = 2;
		for (int i = 0; i < staticTimes.Count; i++)
		{
			float num = staticTimes[i];
			if (num > previousTime && num < time)
			{
				staticVal += staticCurve.Evaluate(num);
				staticNumValues++;
			}
		}
		staticVal /= staticNumValues;
		return staticVal;
	}
}
