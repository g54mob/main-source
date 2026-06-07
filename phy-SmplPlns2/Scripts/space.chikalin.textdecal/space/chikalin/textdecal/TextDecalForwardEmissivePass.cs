using System;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace space.chikalin.textdecal
{
	public class TextDecalForwardEmissivePass : ScriptableRenderPass
	{
		private class PassData
		{
			public RendererListHandle rendererList;
		}

		public const string TextDecalForwardEmissive = "TextDecalForwardEmissive";

		private readonly FilteringSettings _filteringSettings;

		private readonly List<ShaderTagId> _shaderTagIdList;

		public TextDecalForwardEmissivePass()
		{
			base.renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
			ConfigureInput(ScriptableRenderPassInput.Depth);
			base.profilingSampler = new ProfilingSampler("Text Decal Forward Emissive");
			_filteringSettings = new FilteringSettings(RenderQueueRange.opaque);
			_shaderTagIdList = new List<ShaderTagId>
			{
				new ShaderTagId("TextDecalForwardEmissive")
			};
		}

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CameraData cameraData = renderingData.cameraData;
			SortingCriteria defaultOpaqueSortFlags = cameraData.defaultOpaqueSortFlags;
			DrawingSettings drawSettings = RenderingUtils.CreateDrawingSettings(_shaderTagIdList, ref renderingData, defaultOpaqueSortFlags);
			RendererListParams param = new RendererListParams(renderingData.cullResults, drawSettings, _filteringSettings);
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			RendererList rendererList = context.CreateRendererList(ref param);
			using (new ProfilingScope(commandBuffer, base.profilingSampler))
			{
				commandBuffer.DrawRendererList(rendererList);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData)
		{
			SortingCriteria defaultOpaqueSortFlags = cameraData.defaultOpaqueSortFlags;
			DrawingSettings drawSettings = RenderingUtils.CreateDrawingSettings(_shaderTagIdList, renderingData, cameraData, lightData, defaultOpaqueSortFlags);
			return new RendererListParams(renderingData.cullResults, drawSettings, _filteringSettings);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>(base.passName, out passData, base.profilingSampler, ".\\Packages\\space.chikalin.textdecal\\Runtime\\TextDecalForwardEmissivePass.cs", 68);
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			UniversalRenderingData renderingData = frameData.Get<UniversalRenderingData>();
			UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();
			UniversalLightData lightData = frameData.Get<UniversalLightData>();
			RendererListParams desc = InitRendererListParams(renderingData, cameraData, lightData);
			passData.rendererList = renderGraph.CreateRendererList(in desc);
			rasterRenderGraphBuilder.UseRendererList(in passData.rendererList);
			rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
			rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture, AccessFlags.Read);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext rgContext)
			{
				rgContext.cmd.DrawRendererList(data.rendererList);
			});
		}
	}
}
