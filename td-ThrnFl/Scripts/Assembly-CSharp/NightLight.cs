using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class NightLight : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public float targetIntensity = 0.75f;

	public float intensityFlickerRange = 0.15f;

	public float distanceFlickerRange = 5f;

	public float flickerSpeed = 1f;

	public float fadeInTime = 2.5f;

	public float fadeOutTime = 1f;

	public ParticleSystem flames;

	private float transitionTime;

	private float targetRange;

	private Light targetLight;

	private bool fullyFadedIn;

	private float currentIntensity => targetIntensity + Mathf.Lerp(0f - intensityFlickerRange, intensityFlickerRange, Mathf.PerlinNoise(Time.time * flickerSpeed, Time.time * flickerSpeed));

	private float currentRange => targetRange + Mathf.Lerp(0f - distanceFlickerRange, distanceFlickerRange, Mathf.PerlinNoise(Time.time * flickerSpeed, Time.time * flickerSpeed));

	private void Start()
	{
		transitionTime = DayNightCycle.Instance.sunriseTime;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		targetLight = GetComponent<Light>();
		targetLight.intensity = 0f;
		targetRange = targetLight.range;
		if ((bool)ColorAndLightManager.Instance)
		{
			ColorAndLightManager.Instance.RegisterBonfireLight(targetLight);
		}
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (fullyFadedIn)
		{
			targetLight.intensity = currentIntensity;
		}
		targetLight.range = currentRange;
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		StopAllCoroutines();
		StartCoroutine(FadeLightOut());
	}

	public void OnDusk()
	{
		base.gameObject.SetActive(value: true);
		StopAllCoroutines();
		StartCoroutine(FadeLightIn());
	}

	private IEnumerator FadeLightIn()
	{
		fullyFadedIn = false;
		float clock = 0f;
		yield return new WaitForSeconds(transitionTime * 0.1f);
		flames.Play();
		while (clock < fadeInTime)
		{
			clock += Time.deltaTime;
			targetLight.intensity = currentIntensity * Mathf.InverseLerp(0f, fadeInTime, clock);
			yield return null;
		}
		targetLight.intensity = targetIntensity;
		fullyFadedIn = true;
	}

	private IEnumerator FadeLightOut()
	{
		float clock = 0f;
		flames.Stop();
		while (clock < fadeOutTime)
		{
			clock += Time.deltaTime;
			targetLight.intensity = currentIntensity * Mathf.InverseLerp(fadeOutTime, 0f, clock);
			yield return null;
		}
		targetLight.intensity = 0f;
		base.gameObject.SetActive(value: false);
	}

	public void OnDuskEarly()
	{
	}
}
