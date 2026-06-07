using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Drawing
{
	public class AlineURPRenderPassFeature : ScriptableRendererFeature
	{
		public class AlineURPRenderPass : ScriptableRenderPass
		{
			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
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
