using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Xenon
{
	public class OutlinePassFilter : ScriptableRenderPass
	{
		private class PassData
		{
			internal RendererListHandle RendererListHandle;

			internal UniversalCameraData CameraData;

			internal bool ClearDepth;
		}

		private readonly bool _clearDepth;

		private readonly Material _overrideMaterial;

		private readonly LayerMask _layerMask;

		private readonly RenderingLayerMask _renderingLayerMask;

		private readonly List<ShaderTagId> _shaderTagIds;

		public OutlinePassFilter(OutlineRenderFeature.Settings settings)
		{
		}

		private void InitRendererLists(ContextContainer context, ref PassData passData, RenderGraph renderGraph)
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
