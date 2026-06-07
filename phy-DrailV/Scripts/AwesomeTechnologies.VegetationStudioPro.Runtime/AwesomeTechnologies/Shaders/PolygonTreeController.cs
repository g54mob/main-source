using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class PolygonTreeController : IShaderController
	{
		private static readonly string[] FoliageShaderNames = new string[1] { "SyntyStudios/Trees" };

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
				Heading = "Synty Studios Tree shader",
				Description = "",
				LODFadePercentage = false,
				LODFadeCrossfade = false,
				SampleWind = false,
				SupportsInstantIndirect = false,
				BillboardHDWind = false,
				OverrideBillboardAtlasNormalShader = "AwesomeTechnologies/Billboards/RenderNormalsAtlas",
				OverrideBillboardAtlasShader = "AwesomeTechnologies/Billboards/RenderDiffuseAtlasPolygonTree",
				BillboardRenderMode = BillboardRenderMode.Standard
			};
		}

		public void UpdateMaterial(Material material, EnvironmentSettings environmentSettings)
		{
			_ = Settings;
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
