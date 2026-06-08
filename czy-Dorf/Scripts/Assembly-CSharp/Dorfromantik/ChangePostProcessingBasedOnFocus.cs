using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Dorfromantik
{
	public class ChangePostProcessingBasedOnFocus : MonoBehaviour, IBiomeAffectedObject
	{
		[SerializeField]
		private Volume postProcessVolume;

		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		private Biome standardBiome;

		private Bloom bloomEffect;

		private BiomeObjectConfiguration currentBiomeConfiguration;

		public GroupType GroupType => null;

		public ElementType ElementType => null;

		public ElementSubType SubType => null;

		public int Seed => 0;

		public float VariationAlpha => 0.5f;

		private void Start()
		{
			if ((bool)settingsRouter)
			{
				settingsRouter.OnEnableDynamicBackground += EnableDynamicBackground;
				EnableDynamicBackground(settingsRouter.DynamicBackgroundEnabled);
			}
		}

		public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
		{
			currentBiomeConfiguration = new BiomeObjectConfiguration(biomeConfiguration);
			if ((bool)settingsRouter && !settingsRouter.DynamicBackgroundEnabled)
			{
				return;
			}
			if (!bloomEffect)
			{
				postProcessVolume.sharedProfile.TryGet<Bloom>(typeof(Bloom), out bloomEffect);
			}
			foreach (BiomeEffectValue biomeEffectValue in biomeConfiguration.biomeEffectValues)
			{
				string key = biomeEffectValue.key;
				if (!(key == "BloomIntensity"))
				{
					if (key == "BloomTint" && biomeEffectValue.value is Color x)
					{
						bloomEffect.tint.Override(x);
					}
				}
				else if (biomeEffectValue.value is float x2)
				{
					bloomEffect.intensity.Override(x2);
				}
			}
			OverwritingSingleton<IngameUi>.Instance.UpdateCameraVolumeStack();
		}

		private void EnableDynamicBackground(bool dynamicBackgroundEnabled)
		{
			if (dynamicBackgroundEnabled)
			{
				if (currentBiomeConfiguration != null)
				{
					ApplyBiomeConfiguration(currentBiomeConfiguration);
				}
				return;
			}
			if (!bloomEffect)
			{
				postProcessVolume.sharedProfile.TryGet<Bloom>(typeof(Bloom), out bloomEffect);
			}
			bloomEffect.intensity.Override(standardBiome.BiomePostProcessing.bloomIntensity);
			bloomEffect.tint.Override(standardBiome.BiomePostProcessing.bloomColor);
		}

		private void OnDestroy()
		{
			if ((bool)settingsRouter)
			{
				settingsRouter.OnEnableDynamicBackground -= EnableDynamicBackground;
			}
		}
	}
}
