using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class AMRockShaderController : IShaderController
	{
		private static readonly string[] ShaderNames = new string[2] { "ANGRYMESH/PBR BlendTopDetail", "ANGRYMESH/VS BlendTopDetail" };

		public ShaderControllerSettings Settings { get; set; }

		public bool MatchShader(string shaderName)
		{
			if (string.IsNullOrEmpty(shaderName))
			{
				return false;
			}
			for (int i = 0; i <= ShaderNames.Length - 1; i++)
			{
				if (ShaderNames[i] == shaderName)
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
				Heading = "ANGRYMESH Rocks",
				Description = "",
				LODFadePercentage = false,
				LODFadeCrossfade = false,
				SampleWind = false,
				SupportsInstantIndirect = false,
				BillboardHDWind = false
			};
			Settings.AddLabelProperty("Base Rock settings");
			Settings.AddFloatProperty("BaseSmoothness", "Base smoothness", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_BaseSmoothness"), 0f, 1f);
			Settings.AddFloatProperty("BaseAOIntensity", "Base AO intensity", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_BaseAOIntensity"), 0f, 1f);
			Settings.AddColorProperty("BaseColor", "Base color", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_BaseColor"));
			Settings.AddLabelProperty("Top settings");
			Settings.AddFloatProperty("TopIntensity", "Top intensity", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_TopIntensity"), 0f, 1f);
			Settings.AddFloatProperty("TopOffset", "Top offset", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_TopOffset"), 0f, 1f);
			Settings.AddFloatProperty("TopContrast", "Top contrast", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_TopContrast"), 0f, 1f);
			Settings.AddFloatProperty("TopNormalIntensity", "Top normal intensity", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_TopNormalIntensity"), 0f, 1f);
			Settings.AddColorProperty("TopColor", "Top color", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_TopColor"));
		}

		public void UpdateMaterial(Material material, EnvironmentSettings environmentSettings)
		{
			if (Settings != null)
			{
				material.SetFloat("_BaseSmoothness", Settings.GetFloatPropertyValue("BaseSmoothness"));
				material.SetFloat("_BaseAOIntensity", Settings.GetFloatPropertyValue("BaseAOIntensity"));
				material.SetColor("_BaseColor", Settings.GetColorPropertyValue("BaseColor"));
				material.SetFloat("_TopIntensity", Settings.GetFloatPropertyValue("TopIntensity"));
				material.SetFloat("_TopOffset", Settings.GetFloatPropertyValue("TopOffset"));
				material.SetFloat("_TopContrast", Settings.GetFloatPropertyValue("TopContrast"));
				material.SetFloat("_TopNormalIntensity", Settings.GetFloatPropertyValue("TopNormalIntensity"));
				material.SetColor("_TopColor", Settings.GetColorPropertyValue("TopColor"));
			}
		}

		public void UpdateWind(Material material, WindSettings windSettings)
		{
		}

		public bool MatchBillboardShader(Material[] materials)
		{
			return false;
		}
	}
}
