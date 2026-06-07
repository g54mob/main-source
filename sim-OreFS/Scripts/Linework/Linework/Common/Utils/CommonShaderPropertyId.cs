using UnityEngine;

namespace Linework.Common.Utils
{
	public static class CommonShaderPropertyId
	{
		public static readonly int ZTest = Shader.PropertyToID("_ZTest");

		public static readonly int ZWrite = Shader.PropertyToID("_ZWrite");

		public static readonly int CullMode = Shader.PropertyToID("_Cull");

		public static readonly int BlendModeSource = Shader.PropertyToID("_SrcBlend");

		public static readonly int BlendModeDestination = Shader.PropertyToID("_DstBlend");

		public static readonly int FullScreenColorBlendModeSource = Shader.PropertyToID("_Fullscreen_SrcColorBlend");

		public static readonly int FullScreenColorBlendModeDestination = Shader.PropertyToID("_Fullscreen_DstColorBlend");

		public static readonly int FullScreenStencilReference = Shader.PropertyToID("_Fullscreen_StencilReference");

		public static readonly int FullScreenStencilComparison = Shader.PropertyToID("_Fullscreen_StencilComparison");

		public static readonly int FullScreenStencilReadMask = Shader.PropertyToID("_Fullscreen_StencilReadMask");

		public static readonly int FullScreenStencilPass = Shader.PropertyToID("_Fullscreen_StencilPass");

		public static readonly int FullScreenStencilFail = Shader.PropertyToID("_Fullscreen_StencilFail");

		public static readonly int OutlineColor = Shader.PropertyToID("_OutlineColor");

		public static readonly int AlphaCutoutTexture = Shader.PropertyToID("_AlphaCutoutTexture");

		public static readonly int AlphaCutoutThreshold = Shader.PropertyToID("_AlphaCutoutThreshold");

		public static readonly int ReferenceResolution = Shader.PropertyToID("_ReferenceResolution");
	}
}
