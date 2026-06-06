using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Pathfinding.Drawing
{
	public class AlineURPRenderPassFeature : ScriptableRendererFeature
	{
		public class AlineURPRenderPass : ScriptableRenderPass
		{
			private class PassData
			{
				public Camera camera;
			}

			[Obsolete]
			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
			}

			[Obsolete]
			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
			}

			public override void FrameCleanup(CommandBuffer cmd)
			{
			}
		}

		private AlineURPRenderPass m_ScriptablePass;

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		public void AddRenderPasses(ScriptableRenderer renderer)
		{
		}
	}
}
