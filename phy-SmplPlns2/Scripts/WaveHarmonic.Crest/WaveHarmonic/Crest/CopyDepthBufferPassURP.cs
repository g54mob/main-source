using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace WaveHarmonic.Crest
{
	internal sealed class CopyDepthBufferPassURP : ScriptableRenderPass
	{
		private class PassData
		{
			public UniversalCameraData cameraData;

			public RenderGraphHelper.Handle colorTargetHandle;

			public RenderGraphHelper.Handle depthTargetHandle;

			public void Init(ContextContainer frameData, IUnsafeRenderGraphBuilder builder = null)
			{
				UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
				cameraData = frameData.Get<UniversalCameraData>();
				if (builder == null)
				{
					colorTargetHandle = cameraData.renderer.cameraColorTargetHandle;
					depthTargetHandle = cameraData.renderer.cameraDepthTargetHandle;
				}
				else
				{
					colorTargetHandle = universalResourceData.activeColorTexture;
					depthTargetHandle = universalResourceData.activeDepthTexture;
					builder.UseTexture((TextureHandle)depthTargetHandle, AccessFlags.ReadWrite);
				}
			}
		}

		private const string k_Name = "Crest Copy Depth Buffer";

		private RTHandle _ColorBuffer;

		private RTHandle _DepthBuffer;

		public RTHandle _DepthBufferCopy;

		private readonly PassData _PassData = new PassData();

		public CopyDepthBufferPassURP(RenderPassEvent @event)
		{
			base.renderPassEvent = @event;
		}

		private void OnSetup(CommandBuffer buffer, PassData data)
		{
			RenderTextureDescriptor descriptor = data.cameraData.cameraTargetDescriptor;
			descriptor.graphicsFormat = GraphicsFormat.None;
			descriptor.bindMS = descriptor.msaaSamples > 1;
			RenderingUtils.ReAllocateHandleIfNeeded(ref _DepthBufferCopy, in descriptor, FilterMode.Point, TextureWrapMode.Repeat, 1, 0f, "Crest Copied Depth Buffer");
			_ColorBuffer = data.colorTargetHandle;
			_DepthBuffer = data.depthTargetHandle;
		}

		private void Execute(ScriptableRenderContext context, CommandBuffer buffer, PassData data)
		{
			if (_ColorBuffer != null && _DepthBuffer != null)
			{
				buffer.CopyTexture(_DepthBuffer.rt, _DepthBufferCopy.rt);
				CoreUtils.SetRenderTarget(buffer, _ColorBuffer, _DepthBufferCopy, ClearFlag.Stencil);
				CoreUtils.SetRenderTarget(buffer, _ColorBuffer, _DepthBuffer);
			}
		}

		public void Release()
		{
			_DepthBuffer = null;
			_DepthBufferCopy?.Release();
		}

		public override void RecordRenderGraph(RenderGraph graph, ContextContainer frame)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = graph.AddUnsafePass<PassData>("Crest Copy Depth Buffer", out passData, ".\\Packages\\com.waveharmonic.crest\\Runtime\\Scripts\\Volume\\UnderwaterEffectPassURP.RenderGraph.cs", 92);
			passData.Init(frame, unsafeRenderGraphBuilder);
			unsafeRenderGraphBuilder.AllowPassCulling(value: false);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
				OnSetup(nativeCommandBuffer, data);
				Execute(context.GetRenderContext(), nativeCommandBuffer, data);
			});
		}

		[Obsolete]
		public override void OnCameraSetup(CommandBuffer buffer, ref RenderingData data)
		{
			_PassData.Init(data.GetFrameData());
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData data)
		{
			_PassData.Init(data.GetFrameData());
			CommandBuffer commandBuffer = CommandBufferPool.Get("Crest Copy Depth Buffer");
			OnSetup(commandBuffer, _PassData);
			Execute(context, commandBuffer, _PassData);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}
	}
}
