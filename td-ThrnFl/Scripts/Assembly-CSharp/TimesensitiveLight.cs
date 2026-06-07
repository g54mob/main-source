using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class TimesensitiveLight : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public float dayIntensity = 1f;

	public float nightIntensity;

	public float blendTime = 3f;

	private Light target;

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		StopAllCoroutines();
		StartCoroutine(BlendToDay(blendTime));
	}

	public void OnDusk()
	{
		StopAllCoroutines();
		StartCoroutine(BlendToNight(blendTime));
	}

	private void Start()
	{
		target = GetComponent<Light>();
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			StartCoroutine(BlendToDay(0f));
		}
		else
		{
			StartCoroutine(BlendToNight(0f));
		}
	}

	private IEnumerator BlendToNight(float duration)
	{
		float timer = 0f;
		while (timer <= duration)
		{
			timer += Time.deltaTime;
			target.intensity = Mathf.Lerp(dayIntensity, nightIntensity, Mathf.InverseLerp(0f, duration, timer));
			yield return null;
		}
		target.intensity = nightIntensity;
	}

	private IEnumerator BlendToDay(float duration)
	{
		float timer = 0f;
		while (timer <= duration)
		{
			timer += Time.deltaTime;
			target.intensity = Mathf.Lerp(nightIntensity, dayIntensity, Mathf.InverseLerp(0f, duration, timer));
			yield return null;
		}
		target.intensity = dayIntensity;
	}

	public void OnDuskEarly()
	{
	}
}
