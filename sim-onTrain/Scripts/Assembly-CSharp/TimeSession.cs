using System;
using UnityEngine;

[Serializable]
public class TimeSession
{
	[Range(0f, 23.99f)]
	public float startHour;

	[Range(0f, 23.99f)]
	public float endHour = 6f;

	[Range(0f, 3f)]
	public float lightIntensity = 1f;

	public Color lightColor = Color.white;

	public Color skyColor = Color.white;

	public Color equatorColor = new Color(0.5f, 0.5f, 0.5f);

	public Color groundColor = Color.gray;

	public FogMode fogMode = FogMode.Exponential;

	public Color fogColor = Color.gray;

	[Range(0f, 0.1f)]
	public float fogDensity = 0.01f;

	[Range(-5f, 5f)]
	public float postExposure;

	[Range(-100f, 100f)]
	public float contrast;

	[Range(-1f, 3f)]
	public float gamma = 1f;

	public Vector4 gammaRGBW = new Vector4(0f, 0f, 0f, 1f);

	[Range(1f, 120f)]
	[Tooltip("Geçiş sırasında OYUN İÇİNDE kaç DAKİKA ilerleyeceği\nÖrnek: 30 = oyunda 30 dakika ilerler (12:00 → 12:30)")]
	public float transitionTime = 30f;

	public string TimeRangeInfo => $"{startHour:F1}h - {endHour:F1}h ({GetDuration():F1}h duration)";

	private float GetDuration()
	{
		if (startHour > endHour)
		{
			return 24f - startHour + endHour;
		}
		return endHour - startHour;
	}

	public bool IsInTimeRange(float currentTime)
	{
		if (startHour > endHour)
		{
			if (!(currentTime >= startHour))
			{
				return currentTime < endHour;
			}
			return true;
		}
		if (currentTime >= startHour)
		{
			return currentTime < endHour;
		}
		return false;
	}
}
