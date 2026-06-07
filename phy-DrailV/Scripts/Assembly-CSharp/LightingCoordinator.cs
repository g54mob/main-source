using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

[RequireComponent(typeof(TOD_Components))]
public class LightingCoordinator : MonoBehaviour
{
	[Header("Input range")]
	public float intensityMin = 0.3f;

	public float intensityMax = 1f;

	[Header("Puddles")]
	public float puddleSmoothnessAtMin = 0.9f;

	public float puddleSmoothnessAtMax = 0.3f;

	[Header("Reflection intensity")]
	public float reflectionAtMin = 1f;

	public float reflectionAtMax = 0.75f;

	[Header("Fog-Cookery relations")]
	public float fogginessMin;

	public float fogginessMax = 1f;

	public float cookeryAtMin = 0.25f;

	public float cookeryAtMax = 0.5f;

	private Light sunLight;

	private int volumeRobin;

	public float SunlightIntensity01 { get; private set; }

	private void Start()
	{
		sunLight = GetComponent<TOD_Components>().LightSource;
		GamePreferences.RegisterToPreferenceUpdated(Preferences.LightingQualityIndex, OnLightingQualityChanged);
	}

	private void OnLightingQualityChanged()
	{
		int num = Mathf.Clamp(GamePreferences.Get<int>(Preferences.LightingQualityIndex), 0, 2);
		SpriteLightsSystem instance = SingletonBehaviour<SpriteLightsSystem>.Instance;
		switch (num)
		{
		case 0:
			instance.DrawVolumetrics = false;
			instance.FadeoutRange = 100f;
			break;
		case 1:
			instance.DrawVolumetrics = true;
			instance.FadeoutRange = 150f;
			break;
		case 2:
			instance.DrawVolumetrics = true;
			instance.FadeoutRange = 250f;
			break;
		}
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.LightingQualityIndex, OnLightingQualityChanged);
		}
	}

	private void Update()
	{
		SunlightIntensity01 = Mathf.InverseLerp(intensityMin, intensityMax, sunLight.intensity);
		if ((bool)SingletonBehaviour<PuddleSettings>.Instance)
		{
			SingletonBehaviour<PuddleSettings>.Instance.puddleSmoothness = Mathf.Lerp(puddleSmoothnessAtMin, puddleSmoothnessAtMax, SunlightIntensity01);
			SingletonBehaviour<PuddleSettings>.Instance.UploadSettings();
		}
		if ((bool)SingletonBehaviour<ReflectionProbeScheduler>.Instance && SingletonBehaviour<ReflectionProbeScheduler>.Instance.FullEnvironmentProbe != null)
		{
			SingletonBehaviour<ReflectionProbeScheduler>.Instance.FullEnvironmentProbe.Probe.intensity = Mathf.Lerp(reflectionAtMin, reflectionAtMax, SunlightIntensity01);
		}
		if (CookeryVolumeTracker.AllVolumes.Count > 0 && SingletonBehaviour<WeatherDriver>.Instance != null)
		{
			volumeRobin %= CookeryVolumeTracker.AllVolumes.Count;
			CookeryLightVolumeRenderer cookeryLightVolumeRenderer = CookeryVolumeTracker.AllVolumes[volumeRobin];
			if (cookeryLightVolumeRenderer.largeScale)
			{
				float t = Mathf.InverseLerp(fogginessMin, fogginessMax, SingletonBehaviour<WeatherDriver>.Instance.GetFogDensity(cookeryLightVolumeRenderer.transform.position));
				CookeryVolumeTracker.AllVolumes[volumeRobin].globalMultiplier = Mathf.Lerp(cookeryAtMin, cookeryAtMax, t);
			}
			volumeRobin++;
		}
	}
}
