using System;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class NMTreeSnowShaderControler : IShaderController
	{
		private static readonly string[] FoliageShaderNames = new string[2] { "NatureManufacture Shaders/Trees/Tree Leaves Metalic Snow", "NatureManufacture Shaders/Trees/Tree Leaves Specular Snow" };

		private static readonly string[] BarkShaderNames = new string[2] { "NatureManufacture Shaders/Trees/Tree Bark Metalic Snow", "NatureManufacture Shaders/Trees/Tree Bark Specular Snow" };

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
			for (int j = 0; j <= BarkShaderNames.Length - 1; j++)
			{
				if (BarkShaderNames[j] == shaderName)
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
				if (materials[i].shader.name == "NatureManufacture Shaders/Trees/Cross Model Shader Snow")
				{
					return true;
				}
			}
			return false;
		}

		private bool IsBarkShader(string shaderName)
		{
			for (int i = 0; i <= BarkShaderNames.Length - 1; i++)
			{
				if (BarkShaderNames[i].Contains(shaderName))
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
				Heading = "Nature Manufacture tree with snow",
				Description = "",
				LODFadePercentage = false,
				LODFadeCrossfade = false,
				SampleWind = false,
				SupportsInstantIndirect = true,
				BillboardSnow = true,
				BillboardHDWind = true
			};
			Settings.AddLabelProperty("Snow settings");
			Settings.AddBooleanProperty("GlobalSnow", "Use Global Snow Value", "", defaultValue: true);
			Settings.AddFloatProperty("SnowAmount", "Snow Amount", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_Snow_Amount"), 0f, 1f);
			Settings.AddFloatProperty("SnowBrightnessReduction", "Brightness Reduction", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_SnowBrightnessReduction"), 0f, 1f);
			Settings.AddLabelProperty("Foliage settings");
			Settings.AddColorProperty("HealtyColor", "Healthy Color", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_HealthyColor"));
			Settings.AddColorProperty("DryColor", "DryColor", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_DryColor"));
			Settings.AddLabelProperty("Bark settings");
			Settings.AddColorProperty("BarkColor", "Bark Color", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_Color"));
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
				bool num = IsBarkShader(material.shader.name);
				if (Settings.GetBooleanPropertyValue("GlobalSnow"))
				{
					material.SetFloat("_Snow_Amount", environmentSettings.SnowAmount);
				}
				else
				{
					float floatPropertyValue = Settings.GetFloatPropertyValue("SnowAmount");
					material.SetFloat("_Snow_Amount", floatPropertyValue);
				}
				if (num)
				{
					Color colorPropertyValue = Settings.GetColorPropertyValue("BarkColor");
					material.SetColor("_Color", colorPropertyValue);
				}
				else
				{
					Color colorPropertyValue2 = Settings.GetColorPropertyValue("HealtyColor");
					Color colorPropertyValue3 = Settings.GetColorPropertyValue("DryColor");
					material.SetColor("_HealthyColor", colorPropertyValue2);
					material.SetColor("_DryColor", colorPropertyValue3);
					float floatPropertyValue2 = Settings.GetFloatPropertyValue("ShiverDrag");
					float floatPropertyValue3 = Settings.GetFloatPropertyValue("ShiverDirectionality");
					material.SetFloat("_ShiverDrag", floatPropertyValue2);
					material.SetFloat("_ShiverDirectionality", floatPropertyValue3);
					float floatPropertyValue4 = Settings.GetFloatPropertyValue("SnowBrightnessReduction");
					material.SetFloat("_SnowBrightnessReduction", floatPropertyValue4);
				}
				float floatPropertyValue5 = Settings.GetFloatPropertyValue("InitialBend");
				float floatPropertyValue6 = Settings.GetFloatPropertyValue("Stiffness");
				float floatPropertyValue7 = Settings.GetFloatPropertyValue("Drag");
				material.SetFloat("_InitialBend", floatPropertyValue5);
				material.SetFloat("_Stiffness", floatPropertyValue6);
				material.SetFloat("_Drag", floatPropertyValue7);
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
	}
}
