using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace FPL
{
	internal class URP_EnableDepthNormals : ScriptableRendererFeature
	{
		private class EnableDepthNormalsPass : ScriptableRenderPass
		{
			internal bool Setup(ScriptableRenderer renderer)
			{
				ConfigureInput(ScriptableRenderPassInput.Normal);
				return true;
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
			}
		}

		private EnableDepthNormalsPass m_depthNormalsPass;

		public override void Create()
		{
			if (m_depthNormalsPass == null)
			{
				m_depthNormalsPass = new EnableDepthNormalsPass();
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (m_depthNormalsPass.Setup(renderer))
			{
				renderer.EnqueuePass(m_depthNormalsPass);
			}
		}
	}
}
