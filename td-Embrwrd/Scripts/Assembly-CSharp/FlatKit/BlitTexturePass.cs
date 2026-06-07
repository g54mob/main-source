using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace FlatKit
{
	internal class BlitTexturePass : ScriptableRenderPass
	{
		public static readonly string CopyEffectShaderName;

		private ProfilingSampler _profilingSampler;

		private Material _effectMaterial;

		private Material _copyMaterial;

		private RenderTargetHandle _temporaryColorTexture;

		public void Setup(Material effectMaterial, bool useDepth, bool useNormals, bool useColor)
		{
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		private static void SetSourceSize(CommandBuffer cmd, RenderTextureDescriptor desc)
		{
		}
	}
}
