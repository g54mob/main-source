using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public interface IShaderController
	{
		ShaderControllerSettings Settings { get; set; }

		bool MatchShader(string shaderName);

		void CreateDefaultSettings(Material[] materials);

		void UpdateMaterial(Material material, EnvironmentSettings environmentSettings);

		void UpdateWind(Material material, WindSettings windSettings);

		bool MatchBillboardShader(Material[] materials);
	}
}
