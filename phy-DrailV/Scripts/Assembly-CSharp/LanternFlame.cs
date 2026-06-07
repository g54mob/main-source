using System.Collections;
using DV;
using DV.Utils;
using UnityEngine;

public class LanternFlame : ItemFlameBase
{
	private const string EMISSION_COLOR_NAME = "_EmissionColor";

	private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

	[ColorUsage(true, true)]
	[SerializeField]
	private Color glassColorMin;

	[ColorUsage(true, true)]
	[SerializeField]
	private Color glassColorMax;

	[SerializeField]
	private Renderer[] glassRenderers;

	private MaterialPropertyBlock colorPropertyBlock;

	protected override void Awake()
	{
		base.Awake();
		colorPropertyBlock = new MaterialPropertyBlock();
		SetGlassColor(Color.clear);
	}

	private void SetGlassColor(Color color)
	{
		colorPropertyBlock.SetColor(EmissionColor, color);
		Renderer[] array = glassRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetPropertyBlock(colorPropertyBlock);
		}
	}

	protected override void UpdateFlame(Vector3 vel, bool forced)
	{
		base.UpdateFlame(vel, forced);
		if (!SingletonBehaviour<AppUtil>.Instance.IsTimePausedSafer && base.IsLit)
		{
			float t = CalculateEmissionLerpFactor();
			SetGlassColor(Color.Lerp(glassColorMin, glassColorMax, t));
		}
	}

	private float CalculateEmissionLerpFactor()
	{
		return currentFlameIntensity + (Mathf.Clamp01(Mathf.PerlinNoise(noiseOffset, Time.time * perlinFactorL)) - 0.5f) * 0.25f;
	}

	protected override void HandleForcedIntensityChange(bool shouldBeLit, bool shouldExtinguishByEnvironment)
	{
		base.HandleForcedIntensityChange(shouldBeLit, shouldExtinguishByEnvironment);
		float t = (shouldBeLit ? CalculateEmissionLerpFactor() : 0f);
		SetGlassColor(Color.Lerp(glassColorMin, glassColorMax, t));
	}

	protected override IEnumerator FlameExtinguishCoroutine()
	{
		currentFlameIntensity = 0f;
		flameCurrentScale = (flameRequestedScale = flameMinScale);
		lightIntensity = lightIntensityMin;
		lightRange = lightRangeMin;
		flameLight.range = lightRange;
		flameLight.intensity = lightIntensity;
		flameLight.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
		SetGlassColor(Color.clear);
		FireEvent(ignited: false);
		extinguishCoroutine = null;
		yield break;
	}

	protected override IEnumerator FlameIgniteCoroutine(float intensity)
	{
		base.IsIgniting = true;
		base.transform.localScale = Vector3.zero;
		currentFlameIntensity = (requestedFlameIntensity = intensity);
		float elapsedIgnitionTime = 0f;
		flameLight.intensity = 0f;
		flameLight.range = 0f;
		flameLight.gameObject.SetActive(value: true);
		flameCurrentScale = Vector3.zero;
		flameRequestedScale = Vector3.Lerp(flameMinScale, flameMaxScale, intensity);
		lightRange = Mathf.Lerp(lightRangeMin, lightRangeMax, intensity);
		lightIntensity = Mathf.Lerp(lightIntensityMin, lightIntensityMax, intensity);
		Color emissionColor = Color.Lerp(glassColorMin, glassColorMax, intensity);
		if (ignitionSound != null)
		{
			ignitionSound.Play(base.transform.position, 1f, 1.5f, 0f, 0.5f, 20f);
		}
		while (elapsedIgnitionTime < ignitionTime)
		{
			elapsedIgnitionTime += Time.deltaTime;
			LerpFlameVariables(Mathf.Clamp01(elapsedIgnitionTime / ignitionTime));
			yield return null;
		}
		LerpFlameVariables(1f);
		base.IsIgniting = false;
		FireEvent(ignited: true);
		ignitionCoroutine = null;
		void LerpFlameVariables(float lerpFactor)
		{
			flameCurrentScale = flameRequestedScale * lerpFactor;
			base.transform.localScale = flameCurrentScale;
			flameLight.intensity = lightIntensity * lerpFactor;
			flameLight.range = lightRange * lerpFactor;
			SetGlassColor(Color.Lerp(Color.clear, emissionColor, lerpFactor));
		}
	}
}
