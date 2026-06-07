using System;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class NMAdvancedGrassSnowController : IShaderController
	{
		private static readonly string[] FoliageShaderNames = new string[3] { "NatureManufacture Shaders/Grass/Advanced Grass Light Snow", "NatureManufacture Shaders/Grass/Advanced Grass Specular Snow", "NatureManufacture Shaders/Grass/Advanced Grass Standard Snow" };

		public ShaderControllerSettings Settings { get; set; }

		public bool MatchShader(string shaderName)
		{
			if (string.IsNullOrEmpty(shaderName))
			{
				return false;
			}
			for (int i = 0; i <= FoliageShaderNames.Length - 1; i++)
			{
				if (FoliageShaderNames[i] == shaderName)
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
				Heading = "Nature Manufacture Advanced Grass Snow",
				Description = "",
				LODFadePercentage = false,
				LODFadeCrossfade = false,
				SampleWind = false,
				SupportsInstantIndirect = true,
				BillboardHDWind = false
			};
			Settings.AddLabelProperty("Snow settings");
			Settings.AddBooleanProperty("GlobalSnow", "Use Global Snow Value", "", defaultValue: true);
			Settings.AddFloatProperty("SnowAmount", "Snow Amount", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_Snow_Amount"), 0f, 1f);
			Settings.AddFloatProperty("SnowColorBrightness", "Snow Color Brightness", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_SnowColorBrightness"), 0f, 2f);
			Settings.AddLabelProperty("Foliage settings");
			Settings.AddColorProperty("HealthyColorTint", "Healthy color tint", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_HealthyColor"));
			Settings.AddColorProperty("DryColorTint", "Dry color tint", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_DryColor"));
			Settings.AddFloatProperty("ColorNoiseSpread", "Color noise spread", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_ColorNoiseSpread"), 1f, 150f);
			Settings.AddFloatProperty("AlphaCutoff", "Alpha cutoff", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_Cutoff"), 0f, 1f);
			Settings.AddLabelProperty("Wind settings");
			Settings.AddFloatProperty("InitialBend", "Initial Bend", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_InitialBend"), 0f, 10f);
			Settings.AddFloatProperty("Stiffness", "Stiffness", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_Stiffness"), 0f, 10f);
			Settings.AddFloatProperty("Drag", "Drag", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_Drag"), 0f, 10f);
			Settings.AddFloatProperty("ShiverDrag", "Shiver Drag", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_ShiverDrag"), 0f, 10f);
			Settings.AddFloatProperty("ShiverDirectionality", "Shiver Directionality", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_ShiverDirectionality"), 0f, 1f);
		}

		public void UpdateMaterial(Material material, EnvironmentSettings environmentSettings)
		{
			if (Settings == null || material == null)
			{
				return;
			}
			try
			{
				if (Settings.GetBooleanPropertyValue("GlobalSnow"))
				{
					material.SetFloat("_Snow_Amount", environmentSettings.SnowAmount * 2f);
				}
				else
				{
					float floatPropertyValue = Settings.GetFloatPropertyValue("SnowAmount");
					material.SetFloat("_Snow_Amount", floatPropertyValue * 2f);
				}
				material.SetFloat("_CullFarStart", 10000f);
				material.SetFloat("_SnowColorBrightness", Settings.GetFloatPropertyValue("SnowColorBrightness"));
				material.SetColor("_HealthyColor", Settings.GetColorPropertyValue("HealthyColorTint"));
				material.SetColor("_DryColor", Settings.GetColorPropertyValue("DryColorTint"));
				material.SetFloat("_ColorNoiseSpread", Settings.GetFloatPropertyValue("ColorNoiseSpread"));
				material.SetFloat("_Cutoff", Settings.GetFloatPropertyValue("AlphaCutoff"));
				material.SetFloat("_InitialBend", Settings.GetFloatPropertyValue("InitialBend"));
				material.SetFloat("_Stiffness", Settings.GetFloatPropertyValue("Stiffness"));
				material.SetFloat("_Drag", Settings.GetFloatPropertyValue("Drag"));
				material.SetFloat("_ShiverDrag", Settings.GetFloatPropertyValue("ShiverDrag"));
				material.SetFloat("_ShiverDirectionality", Settings.GetFloatPropertyValue("ShiverDirectionality"));
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				throw;
			}
		}

		public void UpdateWind(Material material, WindSettings windSettings)
		{
		}

		public bool MatchBillboardShader(Material[] materials)
		{
			return true;
		}
	}
}
