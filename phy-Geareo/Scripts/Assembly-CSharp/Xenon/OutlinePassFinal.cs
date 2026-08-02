using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Xenon
{
	public class OutlinePassFinal : ScriptableRenderPass
	{
		private class PassData
		{
			internal TextureHandle FilterTextureHandle;

			internal TextureHandle OpaqueTextureHandle;

			internal Material Material;
		}

		private static readonly int FilterTexture;

		private static readonly int OutlineScale;

		private static readonly int RobertsCrossMultiplier;

		private static readonly int DepthThreshold;

		private static readonly int NormalThreshold;

		private static readonly int SteepAngleThreshold;

		private static readonly int SteepAngleMultiplier;

		private static readonly int OutlineColor;

		private readonly Material _blitMaterial;

		public OutlinePassFinal(OutlineRenderFeature.Settings settings, OutlineRenderFeature.OutlineSettings outlineSettings)
		{
		}

		private static void ExecutePass(PassData passData, RasterGraphContext context)
		{
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
		}
	}
}
