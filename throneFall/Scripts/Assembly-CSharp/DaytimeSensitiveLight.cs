using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class DaytimeSensitiveLight : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private Color dayColor = Color.white;

	[SerializeField]
	private Color sunsetColor;

	[SerializeField]
	private Color nightColor;

	[SerializeField]
	private float dayToSunsetDuration = 2f;

	[SerializeField]
	private float sunsetToNightDuration = 2f;

	private Light targetLight;

	private void Start()
	{
		targetLight = GetComponent<Light>();
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDusk()
	{
		StopAllCoroutines();
		StartCoroutine(ToNight());
	}

	public void OnDawn_BeforeSunrise()
	{
		StopAllCoroutines();
		StartCoroutine(ToDay());
	}

	private IEnumerator ToDay()
	{
		float timer = 0f;
		while (timer <= sunsetToNightDuration)
		{
			timer += Time.deltaTime;
			targetLight.color = Color.Lerp(nightColor, sunsetColor, timer / sunsetToNightDuration);
			yield return null;
		}
		timer = 0f;
		while (timer <= dayToSunsetDuration)
		{
			timer += Time.deltaTime;
			targetLight.color = Color.Lerp(sunsetColor, dayColor, timer / dayToSunsetDuration);
			yield return null;
		}
		targetLight.color = dayColor;
	}

	private IEnumerator ToNight()
	{
		float timer = 0f;
		while (timer <= dayToSunsetDuration)
		{
			timer += Time.deltaTime;
			targetLight.color = Color.Lerp(dayColor, sunsetColor, timer / dayToSunsetDuration);
			yield return null;
		}
		timer = 0f;
		while (timer <= sunsetToNightDuration)
		{
			timer += Time.deltaTime;
			targetLight.color = Color.Lerp(dayColor, nightColor, timer / sunsetToNightDuration);
			yield return null;
		}
		targetLight.color = nightColor;
	}

	public void OnDuskEarly()
	{
	}
}
