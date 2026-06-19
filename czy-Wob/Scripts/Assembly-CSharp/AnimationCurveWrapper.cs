using System.Collections.Generic;
using UnityEngine;

public class AnimationCurveWrapper
{
	private float totalTime;

	private AnimationCurve curve;

	private List<float> keyframeTimes = new List<float>();

	public AnimationCurveWrapper(AnimationCurve curve)
	{
		SetCurve(curve);
	}

	public float Evaluate(float time)
	{
		return curve.Evaluate(time);
	}

	public float GetTotalTime()
	{
		return totalTime;
	}

	public void SetCurve(AnimationCurve newCurve)
	{
		curve = newCurve;
		CacheCurveFrameTimes();
	}

	public void AddKey(float time, float value)
	{
		curve.AddKey(time, value);
		CacheCurveFrameTimes();
	}

	public AnimationCurve GetCurve()
	{
		return curve;
	}

	public List<float> KeyframeTimes()
	{
		return keyframeTimes;
	}

	public void SetPostWrapMode(WrapMode newMode)
	{
		curve.postWrapMode = newMode;
	}

	private void CacheCurveFrameTimes()
	{
		if (curve.length != 0)
		{
			keyframeTimes.Clear();
			for (int i = 0; i < curve.length; i++)
			{
				keyframeTimes.Add(curve[i].time);
			}
			totalTime = keyframeTimes[keyframeTimes.Count - 1];
		}
	}
}
