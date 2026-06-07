using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace WaveHarmonic.Crest
{
	internal sealed class MaskRendererURP : MaskRenderer
	{
		private sealed class MaskRenderPass : ScriptableRenderPass
		{
			private class PassData
			{
				public UniversalCameraData _CameraData;

				public MaskRenderer _Renderer;
			}

			private const string k_Name = "Crest.DrawMask";

			internal MaskRenderer _Renderer;

			public MaskRenderPass()
			{
				base.renderPassEvent = RenderPassEvent.BeforeRenderingPrePasses;
			}

			internal void EnqueuePass(Camera camera)
			{
				ScriptableRenderer scriptableRenderer = camera.GetUniversalAdditionalCameraData().scriptableRenderer;
				_Renderer.Allocate();
				scriptableRenderer.EnqueuePass(this);
			}

			public override void RecordRenderGraph(RenderGraph graph, ContextContainer frame)
			{
				PassData passData;
				using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = graph.AddUnsafePass<PassData>("Crest.DrawMask", out passData, ".\\Packages\\com.waveharmonic.crest\\Runtime\\Scripts\\Mask\\MaskRenderer.Universal.cs", 73);
				unsafeRenderGraphBuilder.AllowPassCulling(value: false);
				passData._CameraData = frame.Get<UniversalCameraData>();
				passData._Renderer = _Renderer;
				unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
				{
					CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
					data._Renderer.ReAllocate(data._CameraData.cameraTargetDescriptor);
					data._Renderer.Execute(data._CameraData.camera, nativeCommandBuffer);
				});
			}

			[Obsolete]
			public override void Execute(ScriptableRenderContext context, ref RenderingData data)
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get("Crest.DrawMask");
				_Renderer.ReAllocate(data.cameraData.cameraTargetDescriptor);
				_Renderer.Execute(data.cameraData.camera, commandBuffer);
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
			}
		}

		private readonly MaskRenderPass _MaskRenderPass = new MaskRenderPass();

		public MaskRendererURP(WaterRenderer water)
			: base(water)
		{
		}

		public override void OnBeginCameraRendering(Camera camera)
		{
			if (ShouldExecute(camera))
			{
				_MaskRenderPass._Renderer = this;
				_MaskRenderPass.EnqueuePass(camera);
			}
		}

		public override void OnEndCameraRendering(Camera camera)
		{
		}
	}
}
