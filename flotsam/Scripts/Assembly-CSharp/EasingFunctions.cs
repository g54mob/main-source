using System;
using UnityEngine;

public static class EasingFunctions
{
	public delegate float EasingFunction(float from, float change, float time, float duration);

	private const float DOUBLE_PI = MathF.PI * 2f;

	private const float HALF_PI = MathF.PI / 2f;

	private const float BACK_S = 1.70158f;

	public static EasingFunction Get(Easing easing)
	{
		return easing switch
		{
			Easing.Linear => Linear, 
			Easing.SineIn => SineIn, 
			Easing.SineOut => SineOut, 
			Easing.SineInOut => SineInOut, 
			Easing.ElasticIn => ElasticIn, 
			Easing.ElasticOut => ElasticOut, 
			Easing.ElasticInOut => ElasticeInOut, 
			Easing.BackIn => BackIn, 
			Easing.BackOut => BackOut, 
			Easing.BackInOut => BackInOut, 
			Easing.BounceIn => BounceIn, 
			Easing.BounceOut => BounceOut, 
			_ => null, 
		};
	}

	public static float Linear(float from, float change, float time, float duration)
	{
		return from + change * time / duration;
	}

	public static float SineIn(float start, float change, float time, float duration)
	{
		return (0f - change) * Mathf.Cos(time / duration * (MathF.PI / 2f)) + change + start;
	}

	public static float SineOut(float start, float change, float time, float duration)
	{
		return change * Mathf.Sin(time / duration * (MathF.PI / 2f)) + start;
	}

	public static float SineInOut(float start, float change, float time, float duration)
	{
		return (0f - change) / 2f * (Mathf.Cos(MathF.PI * time / duration) - 1f) + start;
	}

	public static float ElasticIn(float start, float change, float time, float duration)
	{
		if (time == 0f)
		{
			return start;
		}
		if ((time /= duration) == 1f)
		{
			return start + change;
		}
		float num = duration * 0.3f;
		float num2 = num / 4f;
		return 0f - change * Mathf.Pow(2f, 10f * (time -= 1f)) * Mathf.Sin((time * duration - num2) * (MathF.PI * 2f) / num) + start;
	}

	public static float ElasticOut(float start, float change, float time, float duration)
	{
		if (time == 0f)
		{
			return start;
		}
		if ((time /= duration) == 1f)
		{
			return start + change;
		}
		float num = duration * 0.3f;
		float num2 = num / 4f;
		return change * Mathf.Pow(2f, -10f * time) * Mathf.Sin((time * duration - num2) * (MathF.PI * 2f) / num) + change + start;
	}

	public static float ElasticeInOut(float start, float change, float time, float duration)
	{
		if (time == 0f)
		{
			return start;
		}
		if ((time /= duration / 2f) == 2f)
		{
			return time + change;
		}
		float num = duration * 0.45000002f;
		float num2 = num / 4f;
		if (time < 1f)
		{
			return -0.5f * (change * Mathf.Pow(2f, 10f * (time -= 1f)) * Mathf.Sin((time * duration - num2) * (MathF.PI * 2f) / num)) + start;
		}
		return change * Mathf.Pow(2f, -10f * (time -= 1f)) * Mathf.Sin((time * duration - num2) * (MathF.PI * 2f) / num) * 0.5f + change + start;
	}

	public static float BackIn(float start, float change, float time, float duration)
	{
		return change * (time /= duration) * time * (2.70158f * time - 1.70158f) + start;
	}

	public static float BackOut(float start, float change, float time, float duration)
	{
		return change * ((time = time / duration - 1f) * time * (2.70158f * time + 1.70158f) + 1f) + start;
	}

	public static float BackInOut(float start, float change, float time, float duration)
	{
		float num = 2.5949094f;
		if ((time /= duration / 2f) < 1f)
		{
			return change / 2f * (time * time * ((num + 1f) * time - num)) + start;
		}
		return change / 2f * ((time -= 2f) * time * ((num + 1f) * time + num) + 2f) + start;
	}

	public static float BounceIn(float from, float change, float time, float duration)
	{
		return change - BounceOut(0f, change, duration - time, duration) + from;
	}

	public static float BounceOut(float from, float change, float time, float duration)
	{
		if ((time /= duration) < 0.36363637f)
		{
			return change * (7.5625f * time * time) + from;
		}
		if ((double)time < 0.7272727272727273)
		{
			return change * (7.5625f * (time -= 0.54545456f) * time + 0.75f) + from;
		}
		if ((double)time < 0.9090909090909091)
		{
			return change * (7.5625f * (time -= 0.8181818f) * time + 0.9375f) + from;
		}
		return change * (7.5625f * (time -= 21f / 22f) * time + 63f / 64f) + from;
	}
}
