using UnityEngine;

public class DebugExplode : MonoBehaviour
{
	public GameObject explosionPrefab;

	[Range(0f, 0.99f)]
	public float maxLightReachTimeRatio = 0.3f;

	public bool useEasing;

	public float lightFadeTime = 1f;

	public float lightIntensityMax = 25f;

	public Gradient lightColor;

	public float windIntensity;

	public float windFadeTime = 0.3f;

	public bool windMainChange;

	public bool windTurbChange;

	public bool windPulseMagChange;

	public bool windPulseFreqChange;

	private GameObject currentExplosion;

	private ParticleSystem[] particles;

	private AudioSource[] sources;

	private Light explosionLight;

	private bool lightUp;

	private float lightUpElapsedTime;

	private float windTurb;

	private float pulseMagnitude;

	private float pulseFreq;

	private float windFadeElapsedTime;

	private GameObject windGo;

	private WindZone wind;

	private bool doWind;

	public AnimationCurve windInterpolationCurve;

	[InspectorButton("Explode", true, true)]
	public bool explode;

	[InspectorButton("ToggleWind", true, true)]
	public bool toggleWind;

	[InspectorButton("MoveToPlayer", true, true)]
	public bool moveToPlayer;

	private bool windEnabled = true;

	private void Awake()
	{
		wind = GetComponentInChildren<WindZone>(includeInactive: true);
		windGo = wind.gameObject;
		windTurb = wind.windTurbulence;
		pulseMagnitude = wind.windPulseMagnitude;
		pulseFreq = wind.windPulseFrequency;
	}

	private void MoveToPlayer()
	{
		if (Application.isPlaying)
		{
			if (PlayerManager.PlayerTransform != null)
			{
				base.transform.position = PlayerManager.PlayerTransform.position;
			}
			else
			{
				Debug.Log("Couldn't find player transform. DebugExplode will not be moved.", this);
			}
		}
	}

	private void ToggleWind()
	{
		if (Application.isPlaying)
		{
			windEnabled = !windEnabled;
			windGo.SetActive(windEnabled);
		}
	}

	private void Explode()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if (currentExplosion == null)
		{
			if (!explosionPrefab)
			{
				Debug.LogError("No explosion prefab.", this);
				return;
			}
			currentExplosion = Object.Instantiate(explosionPrefab, base.transform.position, base.transform.rotation);
			particles = currentExplosion.GetComponentsInChildren<ParticleSystem>();
			sources = currentExplosion.GetComponentsInChildren<AudioSource>();
			explosionLight = currentExplosion.GetComponentInChildren<Light>();
		}
		currentExplosion.transform.position = base.transform.position;
		currentExplosion.SetActive(value: true);
		explosionLight.enabled = true;
		lightUpElapsedTime = 0f;
		explosionLight.intensity = 0f;
		lightUp = true;
		doWind = true;
		wind.windMain = windIntensity;
		wind.windTurbulence = windTurb;
		wind.windPulseMagnitude = pulseMagnitude;
		wind.windPulseFrequency = pulseFreq;
		ParticleSystem[] array = particles;
		foreach (ParticleSystem particleSystem in array)
		{
			if (particleSystem != null)
			{
				particleSystem.Stop();
				particleSystem.Play();
			}
		}
		AudioSource[] array2 = sources;
		foreach (AudioSource audioSource in array2)
		{
			if (audioSource != null)
			{
				audioSource.Stop();
				audioSource.Play();
			}
		}
	}

	private void Update()
	{
		if (lightUp)
		{
			if (lightUpElapsedTime > lightFadeTime)
			{
				lightUp = false;
				explosionLight.enabled = false;
				lightUpElapsedTime = 0f;
			}
			else
			{
				float num = Mathf.Clamp01(lightUpElapsedTime / lightFadeTime);
				if (!useEasing)
				{
					explosionLight.intensity = Mathf.Lerp(lightIntensityMax, 0f, num);
				}
				else
				{
					float num2 = lightFadeTime * maxLightReachTimeRatio;
					if (lightUpElapsedTime < num2)
					{
						explosionLight.intensity = Ease(0f, lightIntensityMax, lightUpElapsedTime / num2);
					}
					else
					{
						explosionLight.intensity = Ease(lightIntensityMax, 0f, (lightUpElapsedTime - num2) / (lightFadeTime - num2));
					}
				}
				explosionLight.color = lightColor.Evaluate(num);
				lightUpElapsedTime += Time.deltaTime;
			}
		}
		if (!doWind)
		{
			return;
		}
		if (windFadeElapsedTime < windFadeTime)
		{
			windGo.SetActive(value: true);
			float time = Mathf.Clamp01(windFadeElapsedTime / windFadeTime);
			if (windMainChange)
			{
				wind.windMain = windIntensity * windInterpolationCurve.Evaluate(time);
			}
			if (windTurbChange)
			{
				wind.windTurbulence = windTurb * windInterpolationCurve.Evaluate(time);
			}
			if (windPulseFreqChange)
			{
				wind.windPulseFrequency = pulseFreq * windInterpolationCurve.Evaluate(time);
			}
			if (windPulseMagChange)
			{
				wind.windPulseMagnitude = pulseMagnitude * windInterpolationCurve.Evaluate(time);
			}
			windFadeElapsedTime += Time.deltaTime;
		}
		else
		{
			windGo.SetActive(value: false);
			windFadeElapsedTime = 0f;
			doWind = false;
		}
	}

	private float Ease(float from, float to, float t)
	{
		t = Mathf.Clamp01(t);
		if (t == 1f)
		{
			return to;
		}
		if (t == 0f)
		{
			return from;
		}
		float num = to - from;
		float num2 = t - 1f;
		return from + num * ((t < 0.5f) ? (4f * t * t * t) : (4f * num2 * num2 * num2 + 1f));
	}
}
