using System;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class NMStandardSnowController : IShaderController
	{
		private static readonly string[] ShaderNames = new string[2] { "NatureManufacture Shaders/Standard Shaders/Standard Metalic Snow", "NatureManufacture Shaders/Standard Shaders/Standard Specular Snow" };

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
				Heading = "Nature Manufacture Standard Snow",
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
					return;
				}
				float floatPropertyValue = Settings.GetFloatPropertyValue("SnowAmount");
				material.SetFloat("_Snow_Amount", floatPropertyValue * 2f);
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
