using NaughtyAttributes;
using UnityEngine;

namespace Data.Lighting
{
	[CreateAssetMenu(menuName = "MainMaterialsConfig", fileName = "MainMaterialsConfig", order = 0)]
	public class MainMaterialsConfig : ScriptableObject
	{
		private static readonly int GroundTilesColor = Shader.PropertyToID("_GroundTilesColor");

		private static readonly int GroundTilesVariationColor = Shader.PropertyToID("_GroundTilesVariationColor");

		private static readonly int GroundGrassColor = Shader.PropertyToID("_GroundGrassColor");

		private static readonly int GroundDirtColor = Shader.PropertyToID("_GroundDirtColor");

		private static readonly int GrassBaseColor = Shader.PropertyToID("_GrassBaseColor");

		private static readonly int GrassTipColor = Shader.PropertyToID("_GrassTipColor");

		private static readonly int GrassVariationColor = Shader.PropertyToID("_GrassVariationColor");

		private static readonly int GrassWindColor = Shader.PropertyToID("_GrassWindColor");

		private static readonly int WaterMainColor = Shader.PropertyToID("_WaterMainColor");

		private static readonly int WaterTextureColor = Shader.PropertyToID("_WaterTextureColor");

		private static readonly int WaterDepthColor = Shader.PropertyToID("_WaterDepthColor");

		private static readonly int WaterFoamColor = Shader.PropertyToID("_WaterFoamColor");

		[Header("Ground")]
		[SerializeField]
		private Color _groundTilesColor;

		[SerializeField]
		private Color _groundTilesVariationColor;

		[SerializeField]
		private Color _groundGrassColor;

		[SerializeField]
		private Color _groundDirtColor;

		[Header("Grass")]
		[SerializeField]
		private Color _grassBaseColor;

		[SerializeField]
		private Color _grassTipColor;

		[ColorUsage(true, true)]
		[SerializeField]
		private Color _grassVariationColor;

		[ColorUsage(true, true)]
		[SerializeField]
		private Color _grassWindColor;

		[Header("Water")]
		[ColorUsage(true, true)]
		[SerializeField]
		private Color _waterMainColor;

		[ColorUsage(true, true)]
		[SerializeField]
		private Color _waterTextureColor;

		[ColorUsage(true, true)]
		[SerializeField]
		private Color _waterDepthColor;

		[SerializeField]
		private Color _waterFoamColor;

		[Button("Apply Config", EButtonEnableMode.Always)]
		public void ApplyConfig()
		{
			Shader.SetGlobalColor(GroundTilesColor, _groundTilesColor.linear);
			Shader.SetGlobalColor(GroundTilesVariationColor, _groundTilesVariationColor.linear);
			Shader.SetGlobalColor(GroundGrassColor, _groundGrassColor.linear);
			Shader.SetGlobalColor(GroundDirtColor, _groundDirtColor.linear);
			Shader.SetGlobalColor(GrassBaseColor, _grassBaseColor.linear);
			Shader.SetGlobalColor(GrassTipColor, _grassTipColor.linear);
			Shader.SetGlobalColor(GrassVariationColor, _grassVariationColor);
			Shader.SetGlobalColor(GrassWindColor, _grassWindColor);
			Shader.SetGlobalColor(WaterMainColor, _waterMainColor);
			Shader.SetGlobalColor(WaterTextureColor, _waterTextureColor);
			Shader.SetGlobalColor(WaterDepthColor, _waterDepthColor);
			Shader.SetGlobalColor(WaterFoamColor, _waterFoamColor.linear);
		}
	}
}
