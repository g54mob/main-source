using System;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

namespace space.chikalin.textdecal
{
	public class TextDecalScreenSpaceRenderPass : ScriptableRenderPass
	{
		private class TextDecalPassData
		{
			public RendererListHandle rendererList;

			public UniversalCameraData cameraData;

			public TextDecalRendererFeature.DecalScreenSpaceSettings settings;
		}

		private static string ShaderTagId = "TextDecalScreenSpace";

		private List<ShaderTagId> m_ShaderTagIdList;

		private FilteringSettings m_FilteringSettings;

		private readonly TextDecalRendererFeature.DecalScreenSpaceSettings _settings;

		private static GlobalKeyword? _DecalNormalBlendLow;

		private static GlobalKeyword? _DecalNormalBlendMedium;

		private static GlobalKeyword? _DecalNormalBlendHigh;

		private static GlobalKeyword DecalNormalBlendLow
		{
			get
			{
				GlobalKeyword valueOrDefault = _DecalNormalBlendLow.GetValueOrDefault();
				if (!_DecalNormalBlendLow.HasValue)
				{
					valueOrDefault = GlobalKeyword.Create("_TEXT_DECAL_NORMAL_BLEND_LOW");
					_DecalNormalBlendLow = valueOrDefault;
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		private static GlobalKeyword DecalNormalBlendMedium
		{
			get
			{
				GlobalKeyword valueOrDefault = _DecalNormalBlendMedium.GetValueOrDefault();
				if (!_DecalNormalBlendMedium.HasValue)
				{
					valueOrDefault = GlobalKeyword.Create("_TEXT_DECAL_NORMAL_BLEND_MEDIUM");
					_DecalNormalBlendMedium = valueOrDefault;
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		private static GlobalKeyword DecalNormalBlendHigh
		{
			get
			{
				GlobalKeyword valueOrDefault = _DecalNormalBlendHigh.GetValueOrDefault();
				if (!_DecalNormalBlendHigh.HasValue)
				{
					valueOrDefault = GlobalKeyword.Create("_TEXT_DECAL_NORMAL_BLEND_HIGH");
					_DecalNormalBlendHigh = valueOrDefault;
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		public TextDecalScreenSpaceRenderPass(TextDecalRendererFeature.DecalScreenSpaceSettings settings)
		{
			_settings = settings;
			base.renderPassEvent = RenderPassEvent.AfterRenderingSkybox;
			ConfigureInput(ScriptableRenderPassInput.Depth);
			base.profilingSampler = new ProfilingSampler("Text Decal Draw Screen Space");
			m_FilteringSettings = new FilteringSettings(RenderQueueRange.opaque);
			m_ShaderTagIdList = new List<ShaderTagId>
			{
				new ShaderTagId(ShaderTagId)
			};
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			TextureHandle cameraDepthTexture = universalResourceData.cameraDepthTexture;
			TextDecalPassData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<TextDecalPassData>(base.passName, out passData, base.profilingSampler, ".\\Packages\\space.chikalin.textdecal\\Runtime\\TextDecalScreenSpaceRenderPass.cs", 67);
			UniversalRenderingData renderingData = frameData.Get<UniversalRenderingData>();
			UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();
			UniversalLightData lightData = frameData.Get<UniversalLightData>();
			passData.cameraData = cameraData;
			rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
			rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture, AccessFlags.Read);
			RendererListParams desc = InitRendererListParams(renderingData, passData.cameraData, lightData);
			passData.rendererList = renderGraph.CreateRendererList(in desc);
			passData.settings = _settings;
			rasterRenderGraphBuilder.UseRendererList(in passData.rendererList);
			if (cameraDepthTexture.IsValid())
			{
				rasterRenderGraphBuilder.UseTexture(in cameraDepthTexture);
			}
			rasterRenderGraphBuilder.AllowGlobalStateModification(value: true);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(TextDecalPassData data, RasterGraphContext rgContext)
			{
				ExecutePass(rgContext.cmd, data);
			});
		}

		private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData)
		{
			SortingCriteria sortingCriteria = SortingCriteria.None;
			DrawingSettings drawSettings = RenderingUtils.CreateDrawingSettings(m_ShaderTagIdList, renderingData, cameraData, lightData, sortingCriteria);
			return new RendererListParams(renderingData.cullResults, drawSettings, m_FilteringSettings);
		}

		private static void ExecutePass(RasterCommandBuffer cmd, TextDecalPassData passData)
		{
			NormalReconstruction.SetupProperties(cmd, in passData.cameraData);
			cmd.SetKeyword(DecalNormalBlendLow, passData.settings.normalBlend == TextDecalRendererFeature.DecalNormalBlend.Low);
			cmd.SetKeyword(DecalNormalBlendMedium, passData.settings.normalBlend == TextDecalRendererFeature.DecalNormalBlend.Medium);
			cmd.SetKeyword(DecalNormalBlendHigh, passData.settings.normalBlend == TextDecalRendererFeature.DecalNormalBlend.High);
			cmd.DrawRendererList(passData.rendererList);
		}

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, base.profilingSampler))
			{
				DrawingSettings drawSettings = CreateDrawingSettings(m_ShaderTagIdList, ref renderingData, SortingCriteria.None);
				RendererListParams param = new RendererListParams(renderingData.cullResults, drawSettings, m_FilteringSettings);
				RendererList rendererList = context.CreateRendererList(ref param);
				commandBuffer.DrawRendererList(rendererList);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}
	}
}
