using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace WaveHarmonic.Crest
{
	internal sealed class SampleShadowsURP : ScriptableRenderPass
	{
		private class PassData
		{
			public UniversalCameraData cameraData;

			public UniversalLightData lightData;

			public CullingResults cullResults;

			public void Init(ContextContainer frameData, IUnsafeRenderGraphBuilder builder = null)
			{
				cameraData = frameData.Get<UniversalCameraData>();
				lightData = frameData.Get<UniversalLightData>();
				cullResults = frameData.Get<UniversalRenderingData>().cullResults;
			}
		}

		private static SampleShadowsURP s_Instance;

		private WaterRenderer _Water;

		private readonly PassData _PassData = new PassData();

		internal static bool Created => s_Instance != null;

		private SampleShadowsURP(RenderPassEvent renderPassEvent)
		{
			base.renderPassEvent = renderPassEvent;
		}

		internal static void Enable(WaterRenderer water)
		{
			if (s_Instance == null)
			{
				s_Instance = new SampleShadowsURP(RenderPassEvent.AfterRenderingShadows);
			}
			s_Instance._Water = water;
		}

		internal static void EnqueuePass(ScriptableRenderContext context, Camera camera)
		{
			if (s_Instance != null && camera.TryGetComponent<UniversalAdditionalCameraData>(out var component))
			{
				component.scriptableRenderer.EnqueuePass(s_Instance);
			}
		}

		private void Execute(ScriptableRenderContext context, CommandBuffer buffer, PassData renderingData)
		{
			WaterRenderer water = _Water;
			if (!(water == null) && water._ShadowLod.Enabled && renderingData.lightData.mainLightIndex != -1)
			{
				_ = renderingData.cameraData.camera;
				water._ShadowLod.BuildCommandBuffer(water, buffer);
			}
		}

		public override void RecordRenderGraph(RenderGraph graph, ContextContainer frame)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = graph.AddUnsafePass<PassData>("Crest.LodData", out passData, ".\\Packages\\com.waveharmonic.crest\\Runtime\\Scripts\\Data\\SampleShadowsURP.RenderGraph.cs", 35);
			passData.Init(frame, unsafeRenderGraphBuilder);
			unsafeRenderGraphBuilder.AllowPassCulling(value: false);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
				Execute(context.GetRenderContext(), nativeCommandBuffer, data);
			});
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData data)
		{
			_PassData.Init(data.GetFrameData());
			CommandBuffer commandBuffer = CommandBufferPool.Get("Crest.LodData");
			Execute(context, commandBuffer, _PassData);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}
	}
}
