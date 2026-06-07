using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FlatKit
{
	public class FlatKitFog : ScriptableRendererFeature
	{
		[Tooltip("To create new settings use 'Create > FlatKit > Fog Settings'.")]
		public FogSettings settings;

		[HideInInspector]
		[SerializeField]
		private Material _effectMaterial;

		private BlitTexturePass _blitTexturePass;

		[HideInInspector]
		[SerializeField]
		private Shader _blitShader;

		private RenderTargetHandle _fogTexture;

		private Texture2D _lutDepth;

		private Texture2D _lutHeight;

		private static readonly string FogShaderName;

		private static readonly int DistanceLut;

		private static readonly int Near;

		private static readonly int Far;

		private static readonly int UseDistanceFog;

		private static readonly int UseDistanceFogOnSky;

		private static readonly int DistanceFogIntensity;

		private static readonly int HeightLut;

		private static readonly int LowWorldY;

		private static readonly int HighWorldY;

		private static readonly int UseHeightFog;

		private static readonly int UseHeightFogOnSky;

		private static readonly int HeightFogIntensity;

		private static readonly int DistanceHeightBlend;

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

		private void UpdateDistanceLut()
		{
		}

		private void UpdateHeightLut()
		{
		}
	}
}
