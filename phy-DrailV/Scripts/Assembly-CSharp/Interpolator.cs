using System;
using System.Collections;
using UnityEngine;

public class Interpolator : MonoBehaviour
{
	private float from;

	private float to;

	private bool reverse;

	private float current;

	private bool isRunning;

	private Coroutine TimerCoroutine;

	private Action<float> action;

	public void Interpolate(float from, float to, float seconds, Action<float> action)
	{
		this.action = action;
		if (from > to)
		{
			float num = to;
			float num2 = from;
			from = num;
			to = num2;
			reverse = true;
		}
		else
		{
			reverse = false;
		}
		float startingProgress = 0f;
		if (TimerCoroutine != null)
		{
			StopCoroutine(TimerCoroutine);
			if (isRunning)
			{
				isRunning = false;
				float num3 = Mathf.InverseLerp(from, to, current);
				if (reverse)
				{
					num3 = 1f - num3;
				}
				startingProgress = num3;
			}
		}
		else
		{
			this.from = from;
		}
		this.to = to;
		TimerCoroutine = StartCoroutine(Timer(seconds, startingProgress));
	}

	private IEnumerator Timer(float time, float startingProgress)
	{
		isRunning = true;
		float elapsedTime = time * startingProgress;
		while (elapsedTime <= time)
		{
			elapsedTime += Time.deltaTime;
			float t = elapsedTime / time;
			SetValue(Mathf.Lerp(from, to, t));
			yield return null;
		}
		isRunning = false;
	}

	private void SetValue(float value)
	{
		if (reverse)
		{
			current = to - value;
		}
		else
		{
			current = value;
		}
		action(current);
	}
}
