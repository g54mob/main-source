using DV.Debugging;
using DV.Utils;
using UnityEngine;

public class WaterQuality : MonoBehaviour
{
	public Material ssrWaterMaterial;

	private void Start()
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.ReflectionQualityIndex, OnSettingChanged);
		OnSettingChanged();
		if ((bool)SingletonBehaviour<EffectsTogglerDebug>.Instance)
		{
			SingletonBehaviour<EffectsTogglerDebug>.Instance.SubscribeChanged(EffectsTogglerDebug.EffectType.Water, OnDebugChanged);
		}
	}

	private void OnDestroy()
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.ReflectionQualityIndex, OnSettingChanged);
		if ((bool)SingletonBehaviour<EffectsTogglerDebug>.Instance)
		{
			SingletonBehaviour<EffectsTogglerDebug>.Instance.UnsubscribeChanged(EffectsTogglerDebug.EffectType.Water, OnDebugChanged);
		}
	}

	private void OnDebugChanged(bool on)
	{
		base.gameObject.SetActive(on);
	}

	private void OnSettingChanged()
	{
		SetQuality(SingletonBehaviour<GraphicsOptions>.Instance.WaterReflectionQualityLevel);
	}

	private void SetQuality(GraphicsOptions.WaterReflectionQuality qualityLevel)
	{
		switch (qualityLevel)
		{
		case GraphicsOptions.WaterReflectionQuality.VERY_LOW:
			ssrWaterMaterial.DisableKeyword("_BGWATER_SSR_ON");
			break;
		case GraphicsOptions.WaterReflectionQuality.LOW:
			ssrWaterMaterial.DisableKeyword("_BGWATER_SSR_ON");
			break;
		case GraphicsOptions.WaterReflectionQuality.MEDIUM:
			ssrWaterMaterial.EnableKeyword("_BGWATER_SSR_ON");
			ssrWaterMaterial.SetFloat("_SSRMaxSampleCount", 0f);
			ssrWaterMaterial.SetFloat("_SSRSampleStep", 0f);
			break;
		case GraphicsOptions.WaterReflectionQuality.HIGH:
			ssrWaterMaterial.EnableKeyword("_BGWATER_SSR_ON");
			ssrWaterMaterial.SetFloat("_SSRMaxSampleCount", 18f);
			ssrWaterMaterial.SetFloat("_SSRSampleStep", 32f);
			break;
		case GraphicsOptions.WaterReflectionQuality.VERY_HIGH:
			ssrWaterMaterial.EnableKeyword("_BGWATER_SSR_ON");
			ssrWaterMaterial.SetFloat("_SSRMaxSampleCount", 64f);
			ssrWaterMaterial.SetFloat("_SSRSampleStep", 10f);
			break;
		default:
			Debug.LogError($"Unhandled water quality level '{qualityLevel}'");
			break;
		}
	}
}
