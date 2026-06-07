using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class FAEGrassShaderController : IShaderController
	{
		public ShaderControllerSettings Settings { get; set; }

		public bool MatchShader(string shaderName)
		{
			if (string.IsNullOrEmpty(shaderName))
			{
				return false;
			}
			if (!(shaderName == "FAE/Grass"))
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
				Heading = "Fantasy Adventure Environment Grass",
				Description = "Description text",
				LODFadePercentage = false,
				LODFadeCrossfade = false,
				SampleWind = true,
				SupportsInstantIndirect = true
			};
			bool defaultValue = Shader.GetGlobalTexture("_PigmentMap");
			Settings.AddLabelProperty("Color");
			Settings.AddBooleanProperty("EnablePigmentMap", "Use pigment map", "", defaultValue);
			Settings.AddColorProperty("TopColor", "Top", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_ColorTop"));
			Settings.AddColorProperty("BottomColor", "Bottom", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_ColorBottom"));
			Settings.AddFloatProperty("WindTint", "Wind tint", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_ColorVariation"), 0f, 1f);
			Settings.AddFloatProperty("AmbientOcclusion", "Ambient Occlusion", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_AmbientOcclusion"), 0f, 1f);
			Settings.AddLabelProperty("Translucency");
			Settings.AddFloatProperty("TranslucencyAmount", "Amount", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_TransmissionAmount"), 0f, 10f);
			Settings.AddFloatProperty("TranslucencySize", "Size", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_TransmissionSize"), 1f, 20f);
			Settings.AddLabelProperty("Wind");
			Settings.AddFloatProperty("WindInfluence", "Influence", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_MaxWindStrength"), 0f, 1f);
			Settings.AddFloatProperty("WindSwinging", "Swinging", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_WindSwinging"), 0f, 1f);
			Settings.AddFloatProperty("WindAmplitude", "Amplitude Multiplier", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_WindAmplitudeMultiplier"), 0f, 10f);
			Settings.AddLabelProperty("Touch React");
			Settings.AddFloatProperty("BendingInfluence", "Influence", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_BendingInfluence"), 0f, 1f);
		}

		public void UpdateMaterial(Material material, EnvironmentSettings environmentSettings)
		{
			if (Settings != null)
			{
				material.SetFloat("_VS_TOUCHBEND", 0f);
				material.SetFloat("_PigmentMapInfluence", Settings.GetBooleanPropertyValue("EnablePigmentMap") ? 1 : 0);
				material.SetFloat("_MaxHeight", 0.5f);
				material.SetColor("_ColorTop", Settings.GetColorPropertyValue("TopColor"));
				material.SetColor("_ColorBottom", Settings.GetColorPropertyValue("BottomColor"));
				material.SetFloat("_ColorVariation", Settings.GetFloatPropertyValue("WindTint"));
				material.SetFloat("_AmbientOcclusion", Settings.GetFloatPropertyValue("AmbientOcclusion"));
				material.SetFloat("_TransmissionAmount", Settings.GetFloatPropertyValue("TranslucencyAmount"));
				material.SetFloat("_TransmissionSize", Settings.GetFloatPropertyValue("TranslucencySize"));
				material.SetFloat("_MaxWindStrength", Settings.GetFloatPropertyValue("WindInfluence"));
				material.SetFloat("_WindSwinging", Settings.GetFloatPropertyValue("WindSwinging"));
				material.SetFloat("_WindAmplitudeMultiplier", Settings.GetFloatPropertyValue("WindAmplitude"));
				material.SetFloat("_BendingInfluence", Settings.GetFloatPropertyValue("BendingInfluence"));
			}
		}

		public void UpdateWind(Material material, WindSettings windSettings)
		{
		}
	}
}
