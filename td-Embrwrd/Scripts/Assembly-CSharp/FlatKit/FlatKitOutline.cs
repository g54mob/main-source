using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FlatKit
{
	public class FlatKitOutline : ScriptableRendererFeature
	{
		[Tooltip("To create new settings use 'Create > FlatKit > Outline Settings'.")]
		public OutlineSettings settings;

		[SerializeField]
		[HideInInspector]
		private Material _effectMaterial;

		private BlitTexturePass _blitTexturePass;

		[HideInInspector]
		[SerializeField]
		private Shader _blitShader;

		private static readonly string OutlineShaderName;

		private static readonly int EdgeColor;

		private static readonly int Thickness;

		private static readonly int DepthThresholdMin;

		private static readonly int DepthThresholdMax;

		private static readonly int NormalThresholdMin;

		private static readonly int NormalThresholdMax;

		private static readonly int ColorThresholdMin;

		private static readonly int ColorThresholdMax;

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private bool CreateMaterials()
		{
			return false;
		}

		private void SetMaterialProperties()
		{
		}
	}
}
