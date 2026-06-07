using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.Common.Utils
{
	public static class RenderUtils
	{
		private class PassData
		{
		}

		public static readonly int BlendModeSourceProperty;

		public static readonly int BlendModeDestinationProperty;

		private static readonly ShaderTagId UniversalForward;

		private static readonly ShaderTagId UniversalForwardOnly;

		private static readonly ShaderTagId SRPDefaultUnlit;

		public static readonly List<ShaderTagId> DefaultShaderTagIds;

		private static readonly ShaderTagId[] ShaderTagValues;

		private static readonly RenderStateBlock[] RenderStateBlocks;

		public static void CreateRendererListWithRenderStateBlock(RenderGraph renderGraph, ref CullingResults cullingResults, DrawingSettings drawingSettings, FilteringSettings filteringSettings, RenderStateBlock renderStateBlock, ref RendererListHandle rendererListHandle)
		{
		}

		public static void ClearStencil(RenderGraph renderGraph, UniversalResourceData resourceData, Material clear)
		{
		}

		public static (int, int) GetSrcDstBlend(BlendingMode blendMode)
		{
			return default((int, int));
		}
	}
}
