using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class Speedtree8ShaderController : IShaderController
	{
		public ShaderControllerSettings Settings { get; set; }

		public bool MatchShader(string shaderName)
		{
			return shaderName == "Nature/SpeedTree8";
		}

		public bool MatchBillboardShader(Material[] materials)
		{
			return false;
		}

		public void CreateDefaultSettings(Material[] materials)
		{
			Settings = new ShaderControllerSettings
			{
				Heading = "SpeedTree 8 settings",
				Description = "",
				LODFadePercentage = true,
				LODFadeCrossfade = true,
				SampleWind = true,
				DynamicHUE = true,
				BillboardHDWind = true,
				SupportsInstantIndirect = true
			};
			Settings.AddBooleanProperty("ReplaceShader", "Replace shader", "This will replace the speedtree shader with a Vegetation Studio version that supports instanced indirect", defaultValue: true);
			Settings.AddLabelProperty("Foliage settings");
			Settings.AddColorProperty("FoliageHue", "Foliage HUE variation", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_HueVariationColor"));
			Settings.AddColorProperty("FoliageTintColor", "Foliage tint color", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_Color"));
			Settings.AddLabelProperty("Bark settings");
			Settings.AddColorProperty("BarkHue", "Bark HUE variation", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_HueVariationColor"));
			Settings.AddColorProperty("BarkTintColor", "Bark tint color", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_Color"));
		}

		public void UpdateMaterial(Material material, EnvironmentSettings environmentSettings)
		{
			if (Settings != null)
			{
				Color colorPropertyValue = Settings.GetColorPropertyValue("FoliageHue");
				Color colorPropertyValue2 = Settings.GetColorPropertyValue("BarkHue");
				Color colorPropertyValue3 = Settings.GetColorPropertyValue("FoliageTintColor");
				Color colorPropertyValue4 = Settings.GetColorPropertyValue("BarkTintColor");
				bool booleanPropertyValue = Settings.GetBooleanPropertyValue("ReplaceShader");
				if (material.HasProperty("_Cutoff"))
				{
					material.SetFloat("_Cutoff", material.GetFloat("_Cutoff"));
				}
				if (HasKeyword(material, "GEOM_TYPE_BRANCH"))
				{
					material.SetColor("_HueVariation", colorPropertyValue2);
					material.SetColor("_Color", colorPropertyValue4);
				}
				else
				{
					material.SetColor("_HueVariation", colorPropertyValue);
					material.SetColor("_Color", colorPropertyValue3);
				}
				if (booleanPropertyValue && material.shader.name == "Nature/SpeedTree8")
				{
					material.shader = Shader.Find("AwesomeTechnologies/VS_SpeedTree8");
				}
			}
		}

		private bool HasKeyword(Material material, string keyword)
		{
			for (int i = 0; i <= material.shaderKeywords.Length - 1; i++)
			{
				if (material.shaderKeywords[i].Contains(keyword))
				{
					return true;
				}
			}
			return false;
		}

		public void UpdateWind(Material material, WindSettings windSettings)
		{
		}
	}
}
