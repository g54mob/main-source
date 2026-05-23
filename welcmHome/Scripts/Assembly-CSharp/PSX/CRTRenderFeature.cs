using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace PSX
{
	public class CRTRenderFeature : ScriptableRendererFeature
	{
		private CRTPass crtPass;

		public override void Create()
		{
			crtPass = new CRTPass(RenderPassEvent.BeforeRenderingPostProcessing);
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			renderer.EnqueuePass(crtPass);
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			crtPass.Setup((RenderTargetIdentifier)renderer.cameraColorTargetHandle);
		}
	}
}
