using System;
using System.Collections;
using DV.Utils;
using UnityEngine;

public class CountdownTimer
{
	private float targetCountdown;

	private float countdownStartTime;

	private Coroutine countdownCoro;

	private bool isCountdownActive;

	public float RemainingTime => Mathf.Max(targetCountdown - ElapsedTime, 0f);

	private float ElapsedTime
	{
		get
		{
			if (!isCountdownActive)
			{
				return 0f;
			}
			return Time.time - countdownStartTime;
		}
	}

	public event Action CountdownReached;

	public void StartCountdown(float countdownSeconds, float checkPeriod = 0f)
	{
		StopCountdown();
		targetCountdown = countdownSeconds;
		ResetTime();
		countdownCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(CountdownCheck(checkPeriod));
	}

	public void StopCountdown()
	{
		if (countdownCoro != null)
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(countdownCoro);
			}
			countdownCoro = null;
		}
		ClearCountdownParams();
	}

	public void ResetTime()
	{
		countdownStartTime = Time.time;
	}

	private IEnumerator CountdownCheck(float checkPeriod)
	{
		isCountdownActive = true;
		bool checkEachFrame = checkPeriod == 0f;
		while (ElapsedTime < targetCountdown)
		{
			yield return checkEachFrame ? null : WaitFor.Seconds(checkPeriod);
		}
		this.CountdownReached?.Invoke();
		ClearCountdownParams();
	}

	private void ClearCountdownParams()
	{
		targetCountdown = 0f;
		isCountdownActive = false;
		countdownCoro = null;
	}
}
