using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class FAETreeShaderController : IShaderController
	{
		private static readonly string[] BranchShaderNames = new string[1] { "FAE/Tree Branch" };

		private static readonly string[] TrunkShaderNames = new string[1] { "FAE/Tree Trunk" };

		public ShaderControllerSettings Settings { get; set; }

		public bool MatchShader(string shaderName)
		{
			if (string.IsNullOrEmpty(shaderName))
			{
				return false;
			}
			for (int i = 0; i <= BranchShaderNames.Length - 1; i++)
			{
				if (BranchShaderNames[i].Contains(shaderName))
				{
					return true;
				}
			}
			for (int j = 0; j <= TrunkShaderNames.Length - 1; j++)
			{
				if (TrunkShaderNames[j].Contains(shaderName))
				{
					return true;
				}
			}
			return false;
		}

		public bool MatchBillboardShader(Material[] materials)
		{
			for (int i = 0; i <= materials.Length - 1; i++)
			{
				if (materials[i].shader.name == "FAE/Tree Billboard")
				{
					return true;
				}
			}
			return false;
		}

		private bool IsTrunkShader(string shaderName)
		{
			for (int i = 0; i <= TrunkShaderNames.Length - 1; i++)
			{
				if (TrunkShaderNames[i].Contains(shaderName))
				{
					return true;
				}
			}
			return false;
		}

		public void CreateDefaultSettings(Material[] materials)
		{
			Settings = new ShaderControllerSettings
			{
				Heading = "Fantasy Adventure Environment Tree",
				Description = "",
				LODFadePercentage = false,
				LODFadeCrossfade = false,
				SampleWind = true,
				SupportsInstantIndirect = false
			};
			Settings.AddLabelProperty("Branch");
			Settings.AddColorProperty("HueVariation", "Hue Variation", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_HueVariation"));
			Settings.AddColorProperty("TransmissionColor", "Transmission Color", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_TransmissionColor"));
			Settings.AddLabelProperty("Trunk");
			Settings.AddFloatProperty("GradientBrightness", "Gradient Brightness", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_GradientBrightness"), 0f, 2f);
			Settings.AddFloatProperty("AmbientOcclusion", "Ambient Occlusion", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_AmbientOcclusion"), 0f, 1f);
			Settings.AddLabelProperty("Wind");
			Settings.AddFloatProperty("WindInfluence", "Influence", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_MaxWindStrength"), 0f, 1f);
			Settings.AddFloatProperty("WindAmplitude", "Amplitude Multiplier", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_WindAmplitudeMultiplier"), 0f, 10f);
		}

		public void UpdateMaterial(Material material, EnvironmentSettings environmentSettings)
		{
			if (Settings != null)
			{
				if (IsTrunkShader(material.shader.name))
				{
					float floatPropertyValue = Settings.GetFloatPropertyValue("AmbientOcclusion");
					float floatPropertyValue2 = Settings.GetFloatPropertyValue("GradientBrightness");
					material.SetFloat("_AmbientOcclusion", floatPropertyValue);
					material.SetFloat("_GradientBrightness", floatPropertyValue2);
				}
				else
				{
					material.SetColor("_HueVariation", Settings.GetColorPropertyValue("HueVariation"));
					material.SetColor("_TransmissionColor", Settings.GetColorPropertyValue("TransmissionColor"));
					material.SetFloat("_MaxWindStrength", Settings.GetFloatPropertyValue("WindInfluence"));
					material.SetFloat("_WindAmplitudeMultiplier", Settings.GetFloatPropertyValue("WindAmplitude"));
				}
			}
		}

		public void UpdateWind(Material material, WindSettings windSettings)
		{
		}
	}
}
