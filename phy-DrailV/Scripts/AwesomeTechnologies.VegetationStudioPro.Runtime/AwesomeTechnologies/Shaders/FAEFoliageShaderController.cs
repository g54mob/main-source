using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class FAEFoliageShaderController : IShaderController
	{
		public ShaderControllerSettings Settings { get; set; }

		public bool MatchShader(string shaderName)
		{
			if (string.IsNullOrEmpty(shaderName))
			{
				return false;
			}
			if (!(shaderName == "FAE/Foliage"))
			{
				return false;
			}
			return true;
		}

		public bool MatchBillboardShader(Material[] materials)
		{
			return false;
		}

		public void CreateDefaultSettings(Material[] materials)
		{
			Settings = new ShaderControllerSettings
			{
				Heading = "Fantasy Adventure Environment Foliage",
				Description = "Description text",
				LODFadePercentage = false,
				LODFadeCrossfade = false,
				SampleWind = true,
				SupportsInstantIndirect = true
			};
			Settings.AddLabelProperty("Color");
			Settings.AddFloatProperty("AmbientOcclusion", "Ambient Occlusion", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_AmbientOcclusion"), 0f, 1f);
			Settings.AddLabelProperty("Translucency");
			Settings.AddFloatProperty("TranslucencyAmount", "Amount", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_TransmissionAmount"), 0f, 10f);
			Settings.AddFloatProperty("TranslucencySize", "Size", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_TransmissionSize"), 1f, 20f);
			Settings.AddLabelProperty("Wind");
			Settings.AddFloatProperty("WindInfluence", "Influence", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_MaxWindStrength"), 0f, 1f);
			Settings.AddFloatProperty("GlobalWindMotion", "Global motion", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_GlobalWindMotion"), 0f, 1f);
			Settings.AddFloatProperty("LeafFlutter", "Leaf flutter", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_LeafFlutter"), 0f, 1f);
			Settings.AddFloatProperty("WindSwinging", "Swinging", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_WindSwinging"), 0f, 1f);
			Settings.AddFloatProperty("WindAmplitude", "Amplitude Multiplier", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_WindAmplitudeMultiplier"), 0f, 10f);
		}

		public void UpdateMaterial(Material material, EnvironmentSettings environmentSettings)
		{
			if (Settings != null)
			{
				material.SetFloat("_AmbientOcclusion", Settings.GetFloatPropertyValue("AmbientOcclusion"));
				material.SetFloat("_TransmissionAmount", Settings.GetFloatPropertyValue("TranslucencyAmount"));
				material.SetFloat("_TransmissionSize", Settings.GetFloatPropertyValue("TranslucencySize"));
				material.SetFloat("_MaxWindStrength", Settings.GetFloatPropertyValue("WindInfluence"));
				material.SetFloat("_GlobalWindMotion", Settings.GetFloatPropertyValue("GlobalWindMotion"));
				material.SetFloat("_LeafFlutter", Settings.GetFloatPropertyValue("LeafFlutter"));
				material.SetFloat("_WindSwinging", Settings.GetFloatPropertyValue("WindSwinging"));
				material.SetFloat("_WindAmplitudeMultiplier", Settings.GetFloatPropertyValue("WindAmplitude"));
			}
		}

		public void UpdateWind(Material material, WindSettings windSettings)
		{
		}
	}
}
