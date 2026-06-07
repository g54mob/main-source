using System;
using System.Collections.Generic;
using Unity.Collections;
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

		public static readonly int BlendModeSourceProperty = Shader.PropertyToID("_SrcBlend");

		public static readonly int BlendModeDestinationProperty = Shader.PropertyToID("_DstBlend");

		private static readonly ShaderTagId UniversalForward = new ShaderTagId("UniversalForward");

		private static readonly ShaderTagId UniversalForwardOnly = new ShaderTagId("UniversalForwardOnly");

		private static readonly ShaderTagId SRPDefaultUnlit = new ShaderTagId("SRPDefaultUnlit");

		public static readonly List<ShaderTagId> DefaultShaderTagIds = new List<ShaderTagId> { UniversalForward, UniversalForwardOnly, SRPDefaultUnlit };

		private static readonly ShaderTagId[] ShaderTagValues = new ShaderTagId[1];

		private static readonly RenderStateBlock[] RenderStateBlocks = new RenderStateBlock[1];

		public static void CreateRendererListWithRenderStateBlock(RenderGraph renderGraph, ref CullingResults cullingResults, DrawingSettings drawingSettings, FilteringSettings filteringSettings, RenderStateBlock renderStateBlock, ref RendererListHandle rendererListHandle)
		{
			ShaderTagValues[0] = ShaderTagId.none;
			RenderStateBlocks[0] = renderStateBlock;
			NativeArray<ShaderTagId> value = new NativeArray<ShaderTagId>(ShaderTagValues, Allocator.Temp);
			NativeArray<RenderStateBlock> value2 = new NativeArray<RenderStateBlock>(RenderStateBlocks, Allocator.Temp);
			RendererListParams rendererListParams = new RendererListParams(cullingResults, drawingSettings, filteringSettings);
			rendererListParams.tagValues = value;
			rendererListParams.stateBlocks = value2;
			rendererListParams.isPassTagName = false;
			RendererListParams desc = rendererListParams;
			rendererListHandle = renderGraph.CreateRendererList(in desc);
		}

		public static void ClearStencil(RenderGraph renderGraph, UniversalResourceData resourceData, Material clear)
		{
			PassData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Clear Stencil (Fast Outline)", out passData, "./Packages/dev.ameye.linework/Runtime/Common/Utils/RenderUtils.cs", 150);
			rasterRenderGraphBuilder.SetRenderAttachment(resourceData.activeColorTexture, 0);
			rasterRenderGraphBuilder.SetRenderAttachmentDepth(resourceData.activeDepthTexture);
			rasterRenderGraphBuilder.AllowPassCulling(value: false);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData _, RasterGraphContext context)
			{
				context.cmd.DrawProcedural(Matrix4x4.identity, clear, 0, MeshTopology.Triangles, 3, 1);
			});
		}

		public static (int, int) GetSrcDstBlend(BlendingMode blendMode)
		{
			(int, int) result = (0, 0);
			switch (blendMode)
			{
			case BlendingMode.Alpha:
				result.Item1 = 5;
				result.Item2 = 10;
				break;
			case BlendingMode.Premultiply:
				result.Item1 = 1;
				result.Item2 = 10;
				break;
			case BlendingMode.Additive:
				result.Item1 = 1;
				result.Item2 = 1;
				break;
			case BlendingMode.SoftAdditive:
				result.Item1 = 4;
				result.Item2 = 1;
				break;
			default:
				throw new ArgumentOutOfRangeException("blendMode", blendMode, null);
			}
			return result;
		}
	}
}
