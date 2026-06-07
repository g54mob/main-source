using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Rendering.GrabPass
{
	public class TransparentGrabPass : ScriptableRendererFeature
	{
		[Serializable]
		private class Settings
		{
			[SerializeField]
			private LayerMask _layerMask;

			[SerializeField]
			private string _textureName = "_GrabPassTransparent";

			public LayerMask LayerMask => _layerMask;

			public string TextureName => _textureName;
		}

		private class TransparentGrabPassCapture : ScriptableRenderPass
		{
			private class PassData
			{
				public TextureHandle SourceTexture { get; set; }
			}

			private Settings _settings;

			public TransparentGrabPassCapture(Settings settings)
			{
				_settings = settings;
				base.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				PassData passData;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>(base.passName, out passData, "C:\\Users\\avgar\\dev\\SimplePlanes2\\SimplePlanesNext\\Assets\\Scripts\\Rendering\\GrabPass\\TransparentGrabPass.cs", 116);
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				passData.SourceTexture = universalResourceData.activeColorTexture;
				TextureDesc desc = universalResourceData.activeColorTexture.GetDescriptor(renderGraph);
				desc.msaaSamples = MSAASamples.None;
				desc.depthBufferBits = DepthBits.None;
				desc.name = _settings.TextureName;
				TextureHandle tex = renderGraph.CreateTexture(in desc);
				rasterRenderGraphBuilder.UseTexture(passData.SourceTexture);
				rasterRenderGraphBuilder.SetRenderAttachment(tex, 0);
				rasterRenderGraphBuilder.SetGlobalTextureAfterPass(in tex, Shader.PropertyToID(_settings.TextureName));
				rasterRenderGraphBuilder.AllowPassCulling(value: false);
				rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
				{
					ExecutePass(data, context);
				});
			}

			private static void ExecutePass(PassData data, RasterGraphContext context)
			{
				Blitter.BlitTexture(context.cmd, data.SourceTexture, new Vector4(1f, 1f, 0f, 0f), 0f, bilinear: false);
			}
		}

		private class TransparentGrabPassRender : ScriptableRenderPass
		{
			private class PassData
			{
				public RendererListHandle RendererList { get; set; }
			}

			private Settings _settings;

			private ShaderTagId[] _shaderTagIds;

			public TransparentGrabPassRender(Settings settings)
			{
				_settings = settings;
				base.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
				_shaderTagIds = new ShaderTagId[3]
				{
					new ShaderTagId("SRPDefaultUnlit"),
					new ShaderTagId("UniversalForward"),
					new ShaderTagId("LightweightForward")
				};
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
				PassData passData;
				using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>(base.passName, out passData, "C:\\Users\\avgar\\dev\\SimplePlanes2\\SimplePlanesNext\\Assets\\Scripts\\Rendering\\GrabPass\\TransparentGrabPass.cs", 212);
				rasterRenderGraphBuilder.UseGlobalTexture(Shader.PropertyToID(_settings.TextureName));
				UniversalRenderingData universalRenderingData = frameData.Get<UniversalRenderingData>();
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				RendererListDesc rendererListDesc = new RendererListDesc(_shaderTagIds, universalRenderingData.cullResults, universalCameraData.camera);
				rendererListDesc.renderQueueRange = RenderQueueRange.all;
				rendererListDesc.sortingCriteria = SortingCriteria.CommonTransparent;
				rendererListDesc.layerMask = _settings.LayerMask;
				rendererListDesc.stateBlock = new RenderStateBlock(RenderStateMask.Depth)
				{
					depthState = new DepthState(writeEnabled: false, CompareFunction.LessEqual)
				};
				RendererListDesc desc = rendererListDesc;
				passData.RendererList = renderGraph.CreateRendererList(in desc);
				rasterRenderGraphBuilder.UseRendererList(passData.RendererList);
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
				rasterRenderGraphBuilder.AllowPassCulling(value: false);
				rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
				{
					ExecutePass(data, context);
				});
			}

			private static void ExecutePass(PassData data, RasterGraphContext context)
			{
				context.cmd.DrawRendererList(data.RendererList);
			}
		}

		private TransparentGrabPassCapture _capturePass;

		private TransparentGrabPassRender _renderPass;

		[SerializeField]
		private Settings _settings;

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (Game.TryGetInstance(out var instance) && instance.Settings.Quality.Craft.HeatDistortion.Value && instance.SceneManager.InFlightScene)
			{
				renderer.EnqueuePass(_capturePass);
				renderer.EnqueuePass(_renderPass);
			}
		}

		public override void Create()
		{
			_capturePass = new TransparentGrabPassCapture(_settings);
			_renderPass = new TransparentGrabPassRender(_settings);
		}
	}
}
