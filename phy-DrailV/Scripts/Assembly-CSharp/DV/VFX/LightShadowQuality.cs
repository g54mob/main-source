using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace DV.VFX
{
	public class LightShadowQuality : MonoBehaviour
	{
		[Serializable]
		public class LightShadowQualitySettings
		{
			[Tooltip("Quality Index setting at which light inherits these values. Always takes highest one that is less or equal than setting.")]
			[Range(0f, 6f)]
			public int qualityIndex;

			public LightShadows shadows;

			public LightShadowResolution resolution;
		}

		public LightShadowQualitySettings[] settings;

		private Light light;

		private void Awake()
		{
			if ((bool)GetComponent<ItemLight>())
			{
				Debug.LogError("ItemLight and LightShadowQuality are not compatible with each other! Remove one!");
				base.enabled = false;
				return;
			}
			light = GetComponent<Light>();
			settings = settings.OrderBy((LightShadowQualitySettings c) => c.qualityIndex).ToArray();
			GamePreferences.RegisterToPreferenceUpdated(Preferences.ShadowsQualityIndex, OnQualityChanged);
			OnQualityChanged();
		}

		private void OnQualityChanged()
		{
			int num = GamePreferences.Get<int>(Preferences.ShadowsQualityIndex);
			for (int num2 = settings.Length - 1; num2 >= 0; num2--)
			{
				LightShadowQualitySettings lightShadowQualitySettings = settings[num2];
				if (lightShadowQualitySettings.qualityIndex <= num)
				{
					light.shadowResolution = lightShadowQualitySettings.resolution;
					light.shadows = lightShadowQualitySettings.shadows;
					break;
				}
			}
		}

		private void OnDestroy()
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.ShadowsQualityIndex, OnQualityChanged);
		}

		private void OnValidate()
		{
			if (settings == null || settings.Length == 0)
			{
				settings = new LightShadowQualitySettings[2];
				settings[0] = new LightShadowQualitySettings
				{
					qualityIndex = 0,
					resolution = LightShadowResolution.Low,
					shadows = LightShadows.None
				};
				settings[1] = new LightShadowQualitySettings
				{
					qualityIndex = 6,
					resolution = LightShadowResolution.Medium,
					shadows = LightShadows.Hard
				};
			}
		}
	}
}
