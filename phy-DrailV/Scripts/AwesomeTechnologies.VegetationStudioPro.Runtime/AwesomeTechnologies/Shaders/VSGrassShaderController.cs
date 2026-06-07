using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class VSGrassShaderController : IShaderController
	{
		private static readonly string[] FoliageShaderNames = new string[2] { "AwesomeTechnologies/Grass/Grass", "AwesomeTechnologies/Release/Grass/Grass" };

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
				Heading = "Vegetation Studio Grass",
				Description = "",
				LODFadePercentage = true,
				LODFadeCrossfade = true,
				SampleWind = false,
				SupportsInstantIndirect = true,
				BillboardHDWind = false
			};
			Settings.AddLabelProperty("Foliage settings");
			Settings.AddColorProperty("TintColor1", "Dry color tint", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_Color"));
			Settings.AddColorProperty("TintColor2", "Healthy color tint", "", ShaderControllerSettings.GetColorFromMaterials(materials, "_ColorB"));
			Vector4 vector4FromMaterials = ShaderControllerSettings.GetVector4FromMaterials(materials, "_AG_ColorNoiseArea");
			Settings.AddFloatProperty("TintAreaScale", "Tint area scale", "", vector4FromMaterials.y, 10f, 150f);
			Settings.AddFloatProperty("RandomDarkening", "Random darkening", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_RandomDarkening"), 0f, 1f);
			Settings.AddFloatProperty("RootAmbient", "Root ambient", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_RootAmbient"), 0f, 1f);
			Settings.AddFloatProperty("AlphaCutoff", "Alpha cutoff", "", ShaderControllerSettings.GetFloatFromMaterials(materials, "_Cutoff"), 0f, 1f);
		}

		public void UpdateMaterial(Material material, EnvironmentSettings environmentSettings)
		{
			if (Settings != null)
			{
				material.SetColor("_Color", Settings.GetColorPropertyValue("TintColor1"));
				material.SetColor("_ColorB", Settings.GetColorPropertyValue("TintColor2"));
				material.SetFloat("_Cutoff", Settings.GetFloatPropertyValue("AlphaCutoff"));
				material.SetFloat("_RandomDarkening", Settings.GetFloatPropertyValue("RandomDarkening"));
				material.SetFloat("_RootAmbient", Settings.GetFloatPropertyValue("RootAmbient"));
				Vector4 vector = material.GetVector("_AG_ColorNoiseArea");
				vector = new Vector4(vector.x, Settings.GetFloatPropertyValue("TintAreaScale"), vector.z, vector.w);
				material.SetVector("_AG_ColorNoiseArea", vector);
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
