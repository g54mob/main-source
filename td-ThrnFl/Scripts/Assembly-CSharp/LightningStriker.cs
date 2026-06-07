using System.Collections;
using UnityEngine;

public class LightningStriker : MonoBehaviour
{
	public float minSecondsBetweenStrikes = 20f;

	public float maxSecondsBetweenStrikes = 120f;

	public AnimationCurve intensityCurve;

	public float maxIntensity = 3f;

	public float strikeDuration = 1f;

	public Color lightningLightColor = Color.white;

	public AudioClip thunder;

	private Light mainLight;

	private Light lightningLight;

	private AudioSource aSource;

	private bool inAnimation;

	private float timer;

	private void Start()
	{
		if (ColorAndLightManager.Instance == null || ColorAndLightManager.Instance.Sunlight == null)
		{
			base.enabled = false;
			return;
		}
		mainLight = ColorAndLightManager.Instance.Sunlight;
		lightningLight = GetComponent<Light>();
		aSource = GetComponent<AudioSource>();
		ResetTimer();
		if (ColorAndLightManager.Instance != null && ColorAndLightManager.Instance.Sunlight != null)
		{
			base.transform.rotation = ColorAndLightManager.Instance.Sunlight.transform.rotation;
		}
	}

	private void Update()
	{
		if (!inAnimation)
		{
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				StartCoroutine(AnimateLightningStrike());
			}
		}
	}

	private IEnumerator AnimateLightningStrike()
	{
		inAnimation = true;
		lightningLight.color = mainLight.color;
		lightningLight.intensity = mainLight.intensity;
		lightningLight.enabled = true;
		mainLight.enabled = false;
		aSource.pitch = Random.Range(0.8f, 1.2f);
		aSource.PlayOneShot(thunder);
		float clock = 0f;
		while (clock <= strikeDuration)
		{
			clock += Time.deltaTime;
			float t = intensityCurve.Evaluate(Mathf.InverseLerp(0f, strikeDuration, clock));
			lightningLight.color = Color.Lerp(mainLight.color, lightningLight.color, t);
			lightningLight.intensity = Mathf.Lerp(mainLight.intensity, maxIntensity, t);
			yield return null;
		}
		lightningLight.enabled = false;
		mainLight.enabled = true;
		ResetTimer();
		inAnimation = false;
	}

	private void ResetTimer()
	{
		timer = Random.Range(minSecondsBetweenStrikes, maxSecondsBetweenStrikes);
	}
}
