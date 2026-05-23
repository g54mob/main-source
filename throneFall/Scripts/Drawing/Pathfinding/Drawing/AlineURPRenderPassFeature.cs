using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Pathfinding.Drawing
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
				DrawingManager.instance.ExecuteCustomRenderPass(context, renderingData.cameraData.camera);
			}

			public AlineURPRenderPass()
			{
				base.profilingSampler = new ProfilingSampler("ALINE");
			}

			public override void FrameCleanup(CommandBuffer cmd)
			{
			}
		}

		private AlineURPRenderPass m_ScriptablePass;

		public override void Create()
		{
			m_ScriptablePass = new AlineURPRenderPass();
			m_ScriptablePass.renderPassEvent = (RenderPassEvent)549;
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			AddRenderPasses(renderer);
		}

		public void AddRenderPasses(ScriptableRenderer renderer)
		{
			renderer.EnqueuePass(m_ScriptablePass);
		}
	}
}
