using UnityEngine;
using UnityEngine.Rendering;

namespace Aura2API
{
	public static class AuraPreset
	{
		public const string _presetVolumesName = "Aura Preset Volume";

		private static void DeletePresetVolumes()
		{
			AuraVolume[] auraVolumes = Aura.GetAuraVolumes();
			for (int i = 0; i < auraVolumes.Length; i++)
			{
				if (auraVolumes[i].name == "Aura Preset Volume")
				{
					auraVolumes[i].gameObject.Destroy();
				}
			}
		}

		public static void ApplyPreset(Presets preset)
		{
			switch (preset)
			{
			case Presets.Dawn:
				ApplyDawnPreset();
				break;
			case Presets.SunnyDay:
				ApplySunnyDayPreset();
				break;
			case Presets.RainyDay:
				ApplyRainyDayPreset();
				break;
			case Presets.Forest:
				ApplyForestPreset();
				break;
			case Presets.Desert:
				ApplyDesertPreset();
				break;
			case Presets.SnowyDay:
				ApplySnowyDayPreset();
				break;
			default:
				ApplySunnyDayPreset();
				break;
			}
		}

		public static void ApplyDawnPreset()
		{
			AuraCamera[] array = Aura.AddAuraToCameras(1);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].frustumSettings.BaseSettings.useDensity = true;
				array[i].frustumSettings.BaseSettings.density = 0.25f;
				array[i].frustumSettings.BaseSettings.useScattering = true;
				array[i].frustumSettings.BaseSettings.scattering = 0.5f;
				array[i].frustumSettings.BaseSettings.useAmbientLighting = true;
				array[i].frustumSettings.BaseSettings.ambientLightingStrength = 1f;
			}
			RenderSettings.fog = false;
			RenderSettings.ambientMode = AmbientMode.Trilight;
			ColorUtility.TryParseHtmlString("#203140", out var color);
			RenderSettings.ambientSkyColor = color;
			ColorUtility.TryParseHtmlString("#402F20", out color);
			RenderSettings.ambientEquatorColor = color;
			ColorUtility.TryParseHtmlString("#241C1C", out color);
			RenderSettings.ambientGroundColor = color;
			AuraLight[] array2 = Aura.AddAuraToDirectionalLights(1);
			for (int j = 0; j < array2.Length; j++)
			{
				Vector3 eulerAngles = array2[j].transform.rotation.eulerAngles;
				eulerAngles.x = 10f;
				array2[j].transform.rotation = Quaternion.Euler(eulerAngles);
				array2[j].GetComponent<Light>().color = Color.HSVToRGB(0.0777f, 0.92f, 1f);
				array2[j].GetComponent<Light>().intensity = 1f;
				array2[j].strength = 1f;
				array2[j].enableOutOfPhaseColor = false;
				array2[j].outOfPhaseColor = Color.HSVToRGB(0.025f, 0.6f, 1f);
				array2[j].outOfPhaseColorStrength = 0.25f;
			}
			DeletePresetVolumes();
			AuraVolume component = AuraVolume.CreateGameObject("Aura Preset Volume", VolumeType.Global).GetComponent<AuraVolume>();
			component.noiseMask.enable = true;
			component.noiseMask.transform.space = Space.World;
			component.noiseMask.transform.scale = Vector3.one * 5f;
			component.densityInjection.enable = true;
			component.densityInjection.strength = 0.1f;
			component.densityInjection.noiseMaskLevelParameters.contrast = 5f;
			component.lightInjection.injectionParameters.enable = false;
			component.scatteringInjection.enable = true;
			component.scatteringInjection.strength = 0.25f;
		}

		public static void ApplySunnyDayPreset()
		{
			AuraCamera[] array = Aura.AddAuraToCameras(1);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].frustumSettings.BaseSettings.useDensity = true;
				array[i].frustumSettings.BaseSettings.density = 0.05f;
				array[i].frustumSettings.BaseSettings.useScattering = true;
				array[i].frustumSettings.BaseSettings.scattering = 0.5f;
				array[i].frustumSettings.BaseSettings.useAmbientLighting = true;
				array[i].frustumSettings.BaseSettings.ambientLightingStrength = 1f;
			}
			RenderSettings.fog = false;
			RenderSettings.ambientMode = AmbientMode.Trilight;
			ColorUtility.TryParseHtmlString("#406381", out var color);
			RenderSettings.ambientSkyColor = color;
			ColorUtility.TryParseHtmlString("#402F20", out color);
			RenderSettings.ambientEquatorColor = color;
			ColorUtility.TryParseHtmlString("#241C1C", out color);
			RenderSettings.ambientGroundColor = color;
			AuraLight[] array2 = Aura.AddAuraToDirectionalLights(1);
			for (int j = 0; j < array2.Length; j++)
			{
				Vector3 eulerAngles = array2[j].transform.rotation.eulerAngles;
				eulerAngles.x = 50f;
				array2[j].transform.rotation = Quaternion.Euler(eulerAngles);
				ColorUtility.TryParseHtmlString("#FFD0A6", out color);
				array2[j].GetComponent<Light>().color = color;
				array2[j].GetComponent<Light>().intensity = 1.4f;
				array2[j].strength = 1f;
				array2[j].enableOutOfPhaseColor = false;
			}
			DeletePresetVolumes();
		}

		public static void ApplyRainyDayPreset()
		{
			AuraCamera[] array = Aura.AddAuraToCameras(1);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].frustumSettings.BaseSettings.useDensity = true;
				array[i].frustumSettings.BaseSettings.density = 0.5f;
				array[i].frustumSettings.BaseSettings.useScattering = true;
				array[i].frustumSettings.BaseSettings.scattering = 1f;
				array[i].frustumSettings.BaseSettings.useAmbientLighting = true;
				array[i].frustumSettings.BaseSettings.ambientLightingStrength = 1.25f;
			}
			RenderSettings.fog = false;
			RenderSettings.ambientMode = AmbientMode.Trilight;
			ColorUtility.TryParseHtmlString("#406381", out var color);
			RenderSettings.ambientSkyColor = color;
			ColorUtility.TryParseHtmlString("#2C4459", out color);
			RenderSettings.ambientEquatorColor = color;
			ColorUtility.TryParseHtmlString("#131D26", out color);
			RenderSettings.ambientGroundColor = color;
			AuraLight[] array2 = Aura.AddAuraToDirectionalLights(1);
			for (int j = 0; j < array2.Length; j++)
			{
				Vector3 eulerAngles = array2[j].transform.rotation.eulerAngles;
				eulerAngles.x = 50f;
				array2[j].transform.rotation = Quaternion.Euler(eulerAngles);
				array2[j].GetComponent<Light>().color = Color.HSVToRGB(0.27f, 0.15f, 1f);
				array2[j].GetComponent<Light>().intensity = 0.8f;
				array2[j].strength = 0.5f;
				array2[j].enableOutOfPhaseColor = false;
			}
			DeletePresetVolumes();
			AuraVolume component = AuraVolume.CreateGameObject("Aura Preset Volume", VolumeType.Global).GetComponent<AuraVolume>();
			component.noiseMask.enable = true;
			component.noiseMask.speed = 0.15f;
			component.noiseMask.transform.space = Space.World;
			component.noiseMask.transform.scale = Vector3.one * 3f;
			component.densityInjection.enable = true;
			component.densityInjection.strength = 0.2f;
			component.densityInjection.noiseMaskLevelParameters.contrast = 15f;
			component.densityInjection.noiseMaskLevelParameters.outputLowValue = 0f;
			component.densityInjection.noiseMaskLevelParameters.outputHiValue = -1f;
			component.lightInjection.injectionParameters.enable = false;
			component.scatteringInjection.enable = false;
		}

		public static void ApplyForestPreset()
		{
			AuraCamera[] array = Aura.AddAuraToCameras(1);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].frustumSettings.BaseSettings.useDensity = true;
				array[i].frustumSettings.BaseSettings.density = 0.3f;
				array[i].frustumSettings.BaseSettings.useScattering = true;
				array[i].frustumSettings.BaseSettings.scattering = 0.75f;
				array[i].frustumSettings.BaseSettings.useAmbientLighting = true;
				array[i].frustumSettings.BaseSettings.ambientLightingStrength = 1f;
			}
			RenderSettings.fog = false;
			RenderSettings.ambientMode = AmbientMode.Trilight;
			ColorUtility.TryParseHtmlString("#406381", out var color);
			RenderSettings.ambientSkyColor = color;
			ColorUtility.TryParseHtmlString("#37402C", out color);
			RenderSettings.ambientEquatorColor = color;
			ColorUtility.TryParseHtmlString("#212420", out color);
			RenderSettings.ambientGroundColor = color;
			AuraLight[] array2 = Aura.AddAuraToDirectionalLights(1);
			for (int j = 0; j < array2.Length; j++)
			{
				Vector3 eulerAngles = array2[j].transform.rotation.eulerAngles;
				eulerAngles.x = 50f;
				array2[j].transform.rotation = Quaternion.Euler(eulerAngles);
				array2[j].GetComponent<Light>().color = Color.HSVToRGB(0.12f, 0.35f, 1f);
				array2[j].GetComponent<Light>().intensity = 1f;
				array2[j].strength = 0.5f;
				array2[j].enableOutOfPhaseColor = false;
			}
			DeletePresetVolumes();
			AuraVolume component = AuraVolume.CreateGameObject("Aura Preset Volume", VolumeType.Global).GetComponent<AuraVolume>();
			component.noiseMask.enable = true;
			component.noiseMask.speed = 0.15f;
			component.noiseMask.transform.space = Space.World;
			component.noiseMask.transform.scale = Vector3.one * 3f;
			component.densityInjection.enable = true;
			component.densityInjection.strength = 0.1f;
			component.densityInjection.noiseMaskLevelParameters.contrast = 15f;
			component.densityInjection.noiseMaskLevelParameters.outputLowValue = 0f;
			component.densityInjection.noiseMaskLevelParameters.outputHiValue = -1f;
			component.lightInjection.injectionParameters.enable = false;
			component.scatteringInjection.enable = false;
		}

		public static void ApplyDesertPreset()
		{
			AuraCamera[] array = Aura.AddAuraToCameras(1);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].frustumSettings.BaseSettings.useDensity = true;
				array[i].frustumSettings.BaseSettings.density = 0.5f;
				array[i].frustumSettings.BaseSettings.useScattering = true;
				array[i].frustumSettings.BaseSettings.scattering = 0.5f;
				array[i].frustumSettings.BaseSettings.useAmbientLighting = true;
				array[i].frustumSettings.BaseSettings.ambientLightingStrength = 2f;
			}
			RenderSettings.fog = false;
			RenderSettings.ambientMode = AmbientMode.Trilight;
			ColorUtility.TryParseHtmlString("#817251", out var color);
			RenderSettings.ambientSkyColor = color;
			ColorUtility.TryParseHtmlString("#403A2C", out color);
			RenderSettings.ambientEquatorColor = color;
			ColorUtility.TryParseHtmlString("#242320", out color);
			RenderSettings.ambientGroundColor = color;
			AuraLight[] array2 = Aura.AddAuraToDirectionalLights(1);
			for (int j = 0; j < array2.Length; j++)
			{
				Vector3 eulerAngles = array2[j].transform.rotation.eulerAngles;
				eulerAngles.x = 50f;
				array2[j].transform.rotation = Quaternion.Euler(eulerAngles);
				ColorUtility.TryParseHtmlString("#FFD780", out color);
				array2[j].GetComponent<Light>().color = color;
				array2[j].GetComponent<Light>().intensity = 1.4f;
				array2[j].strength = 0.25f;
				array2[j].enableOutOfPhaseColor = false;
			}
			DeletePresetVolumes();
		}

		public static void ApplySnowyDayPreset()
		{
			AuraCamera[] array = Aura.AddAuraToCameras(1);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].frustumSettings.BaseSettings.useDensity = true;
				array[i].frustumSettings.BaseSettings.density = 0.25f;
				array[i].frustumSettings.BaseSettings.useScattering = true;
				array[i].frustumSettings.BaseSettings.scattering = 1f;
				array[i].frustumSettings.BaseSettings.useAmbientLighting = true;
				array[i].frustumSettings.BaseSettings.ambientLightingStrength = 3f;
			}
			RenderSettings.fog = false;
			RenderSettings.ambientMode = AmbientMode.Trilight;
			ColorUtility.TryParseHtmlString("#70818C", out var color);
			RenderSettings.ambientSkyColor = color;
			ColorUtility.TryParseHtmlString("#546069", out color);
			RenderSettings.ambientEquatorColor = color;
			ColorUtility.TryParseHtmlString("#384046", out color);
			RenderSettings.ambientGroundColor = color;
			AuraLight[] array2 = Aura.AddAuraToDirectionalLights(1);
			for (int j = 0; j < array2.Length; j++)
			{
				Vector3 eulerAngles = array2[j].transform.rotation.eulerAngles;
				eulerAngles.x = 50f;
				array2[j].transform.rotation = Quaternion.Euler(eulerAngles);
				ColorUtility.TryParseHtmlString("#CAE8FF", out color);
				array2[j].GetComponent<Light>().color = color;
				array2[j].GetComponent<Light>().intensity = 1.4f;
				array2[j].strength = 0.25f;
				array2[j].enableOutOfPhaseColor = false;
			}
			DeletePresetVolumes();
		}
	}
}
