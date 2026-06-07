using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using UnityEngine;

public class FpsStabilityMeasurer : SingletonBehaviour<FpsStabilityMeasurer>
{
	private const float MEASUREMENT_WINDOW = 0.15f;

	private const float HISTORY_WINDOW = 1.5f;

	private const int HISTORY_LIMIT = 10;

	private const int FPS_DIP_THRESHOLD = 7;

	private const int FPS_STABILISATION_TIMEOUT = 60;

	private float nextTarget;

	private int framesCount;

	private readonly List<float> fpsHistory = new List<float>();

	private bool isMeasuring;

	private Coroutine WaitForStableFpsCoro;

	public new static string AllowAutoCreate()
	{
		return "[FpsStabilityMeasurer]";
	}

	private void StartMeasurement()
	{
		fpsHistory.Clear();
		isMeasuring = true;
		framesCount = 0;
		nextTarget = Time.realtimeSinceStartup + 0.15f;
		base.enabled = true;
	}

	private void StopMeasurement()
	{
		isMeasuring = false;
	}

	private void Update()
	{
		if (!isMeasuring)
		{
			base.enabled = false;
			return;
		}
		framesCount++;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (realtimeSinceStartup > nextTarget)
		{
			float item = (float)framesCount / 0.15f;
			nextTarget = realtimeSinceStartup + 0.15f;
			framesCount = 0;
			fpsHistory.Add(item);
			if (fpsHistory.Count > 10)
			{
				fpsHistory.RemoveAt(0);
			}
		}
	}

	private bool IsStable()
	{
		if (fpsHistory.Count == 10)
		{
			return fpsHistory.All((float t) => t >= 7f);
		}
		return false;
	}

	public void WaitForStableFps(Action callback)
	{
		Cancel();
		WaitForStableFpsCoro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(WaitForStableFpsCoroutine(callback));
	}

	public IEnumerator WaitForStableFps()
	{
		bool done = false;
		WaitForStableFps(delegate
		{
			done = true;
		});
		while (!done)
		{
			yield return null;
		}
	}

	private IEnumerator WaitForStableFpsCoroutine(Action callback)
	{
		StartMeasurement();
		float timeout = Time.realtimeSinceStartup + 60f;
		while (!IsStable() && !(Time.realtimeSinceStartup > timeout))
		{
			yield return null;
		}
		StopMeasurement();
		callback();
	}

	public void Cancel()
	{
		if (WaitForStableFpsCoro != null)
		{
			StopCoroutine(WaitForStableFpsCoro);
		}
	}
}
