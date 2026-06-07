using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace space.chikalin.textdecal
{
	public class TextDecalDBufferRenderPass : ScriptableRenderPass
	{
		private class TextDecalPassData
		{
			public RendererListHandle rendererList;
		}

		public static readonly string DBufferDepthName = "DBufferDepth";

		private const int DBufferSize = 3;

		private static readonly string[] DBufferNames = new string[4] { "_DBufferTexture0", "_DBufferTexture1", "_DBufferTexture2", "_DBufferTexture3" };

		private static readonly string ShaderTagId = "TextDecalDBuffer";

		private readonly List<ShaderTagId> _shaderTagIdList;

		private readonly FilteringSettings _filteringSettings;

		private static readonly int s_SSAOTextureID = Shader.PropertyToID("_ScreenSpaceOcclusionTexture");

		public RTHandle _dBufferDepthHandle;

		private readonly RTHandle[] _dBufferHandles;

		private readonly RenderTargetIdentifier _dBufferDepthTargetID;

		private readonly RenderTargetIdentifier[] _dBufferTargetIDs;

		public TextDecalDBufferRenderPass(RenderPassEvent atEvent)
		{
			base.renderPassEvent = atEvent;
			ConfigureInput(ScriptableRenderPassInput.Depth | ScriptableRenderPassInput.Normal);
			base.profilingSampler = new ProfilingSampler("Text Decal Draw DBuffer");
			_filteringSettings = new FilteringSettings(RenderQueueRange.opaque);
			_shaderTagIdList = new List<ShaderTagId>
			{
				new ShaderTagId(ShaderTagId)
			};
			_dBufferDepthTargetID = new RenderTargetIdentifier(DBufferDepthName);
			_dBufferTargetIDs = new RenderTargetIdentifier[3];
			_dBufferHandles = new RTHandle[3];
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			UniversalRenderingData renderingData = frameData.Get<UniversalRenderingData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			UniversalLightData lightData = frameData.Get<UniversalLightData>();
			TextureHandle cameraDepthTexture = universalResourceData.cameraDepthTexture;
			TextureHandle cameraNormalsTexture = universalResourceData.cameraNormalsTexture;
			TextDecalPassData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<TextDecalPassData>(base.passName, out passData, base.profilingSampler, ".\\Packages\\space.chikalin.textdecal\\Runtime\\TextDecalDBufferRenderPass.cs", 62);
			TextureHandle[] dBuffer = universalResourceData.dBuffer;
			if (!dBuffer[0].IsValid())
			{
				RenderTextureDescriptor cameraTargetDescriptor = universalCameraData.cameraTargetDescriptor;
				cameraTargetDescriptor.graphicsFormat = ((QualitySettings.activeColorSpace == ColorSpace.Linear) ? GraphicsFormat.R8G8B8A8_SRGB : GraphicsFormat.R8G8B8A8_UNorm);
				cameraTargetDescriptor.depthStencilFormat = GraphicsFormat.None;
				cameraTargetDescriptor.msaaSamples = 1;
				dBuffer[0] = CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, DBufferNames[0], clear: true, new Color(0f, 0f, 0f, 1f));
			}
			rasterRenderGraphBuilder.SetRenderAttachment(dBuffer[0], 0);
			if (dBuffer.Length >= 2 && dBuffer[1].IsValid())
			{
				rasterRenderGraphBuilder.SetRenderAttachment(dBuffer[1], 1);
			}
			if (dBuffer.Length >= 3 && dBuffer[2].IsValid())
			{
				rasterRenderGraphBuilder.SetRenderAttachment(dBuffer[2], 2);
			}
			if (universalResourceData.dBufferDepth.IsValid())
			{
				rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.dBufferDepth, AccessFlags.Read);
			}
			else
			{
				rasterRenderGraphBuilder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture, AccessFlags.Read);
			}
			if (cameraDepthTexture.IsValid())
			{
				rasterRenderGraphBuilder.UseTexture(in cameraDepthTexture);
			}
			if (cameraNormalsTexture.IsValid())
			{
				rasterRenderGraphBuilder.UseTexture(in cameraNormalsTexture);
			}
			if (universalResourceData.renderingLayersTexture.IsValid())
			{
				rasterRenderGraphBuilder.UseTexture(universalResourceData.renderingLayersTexture);
			}
			if (universalResourceData.ssaoTexture.IsValid())
			{
				rasterRenderGraphBuilder.UseGlobalTexture(s_SSAOTextureID);
			}
			RendererListParams desc = InitRendererListParams(renderingData, universalCameraData, lightData);
			passData.rendererList = renderGraph.CreateRendererList(in desc);
			rasterRenderGraphBuilder.UseRendererList(in passData.rendererList);
			for (int i = 0; i < 3; i++)
			{
				if (dBuffer[i].IsValid())
				{
					rasterRenderGraphBuilder.SetGlobalTextureAfterPass(in dBuffer[i], Shader.PropertyToID(DBufferNames[i]));
				}
			}
			rasterRenderGraphBuilder.AllowPassCulling(value: false);
			rasterRenderGraphBuilder.AllowGlobalStateModification(value: true);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(TextDecalPassData data, RasterGraphContext rgContext)
			{
				rgContext.cmd.DrawRendererList(data.rendererList);
			});
			universalResourceData.dBuffer = dBuffer;
		}

		private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData)
		{
			SortingCriteria defaultOpaqueSortFlags = cameraData.defaultOpaqueSortFlags;
			DrawingSettings drawSettings = RenderingUtils.CreateDrawingSettings(_shaderTagIdList, renderingData, cameraData, lightData, defaultOpaqueSortFlags);
			return new RendererListParams(renderingData.cullResults, drawSettings, _filteringSettings);
		}

		private static TextureHandle CreateRenderGraphTexture(RenderGraph renderGraph, RenderTextureDescriptor desc, string name, bool clear, Color color, FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Clamp)
		{
			TextureDesc desc2 = new TextureDesc(desc.width, desc.height);
			desc2.dimension = desc.dimension;
			desc2.clearBuffer = clear;
			desc2.clearColor = color;
			desc2.bindTextureMS = desc.bindMS;
			desc2.format = ((desc.depthStencilFormat != GraphicsFormat.None) ? desc.depthStencilFormat : desc.graphicsFormat);
			desc2.slices = desc.volumeDepth;
			desc2.msaaSamples = (MSAASamples)desc.msaaSamples;
			desc2.name = name;
			desc2.enableRandomWrite = desc.enableRandomWrite;
			desc2.filterMode = filterMode;
			desc2.wrapMode = wrapMode;
			desc2.useDynamicScale = desc.useDynamicScale;
			desc2.useDynamicScaleExplicit = desc.useDynamicScaleExplicit;
			return renderGraph.CreateTexture(in desc2);
		}

		public void Setup(CameraData cameraData)
		{
			if (_dBufferDepthHandle == null)
			{
				_dBufferDepthHandle = RTHandles.Alloc(_dBufferDepthTargetID, DBufferDepthName);
			}
			AddDBufferHandle(0);
			AddDBufferHandle(1);
			AddDBufferHandle(2);
		}

		private void AddDBufferHandle(int i)
		{
			if (_dBufferHandles[i] == null)
			{
				_dBufferTargetIDs[i] = new RenderTargetIdentifier(DBufferNames[i]);
				_dBufferHandles[i] = RTHandles.Alloc(_dBufferTargetIDs[i], DBufferNames[i]);
			}
		}

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			ConfigureTarget(_dBufferHandles, _dBufferDepthHandle);
		}

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, base.profilingSampler))
			{
				SortingCriteria defaultOpaqueSortFlags = renderingData.cameraData.defaultOpaqueSortFlags;
				DrawingSettings drawSettings = CreateDrawingSettings(_shaderTagIdList, ref renderingData, defaultOpaqueSortFlags);
				RendererListParams param = new RendererListParams(renderingData.cullResults, drawSettings, _filteringSettings);
				RendererList rendererList = context.CreateRendererList(ref param);
				commandBuffer.DrawRendererList(rendererList);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		public void Dispose()
		{
			_dBufferDepthHandle?.Release();
			RTHandle[] dBufferHandles = _dBufferHandles;
			for (int i = 0; i < dBufferHandles.Length; i++)
			{
				dBufferHandles[i]?.Release();
			}
		}
	}
}
