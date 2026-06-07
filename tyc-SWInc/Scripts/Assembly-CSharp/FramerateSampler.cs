using UnityEngine;

public class FramerateSampler
{
	private float updateInterval = 1f;

	private float newPeriod;

	private int intervalTotalFrames;

	private int intervalFrameSum;

	public int CurrentFps;

	public void Update()
	{
		intervalTotalFrames++;
		intervalFrameSum += (int)(1f / Time.deltaTime);
		if (Time.time > newPeriod)
		{
			CurrentFps = intervalFrameSum / intervalTotalFrames;
			intervalTotalFrames = 0;
			intervalFrameSum = 0;
			newPeriod += updateInterval;
		}
	}
}
