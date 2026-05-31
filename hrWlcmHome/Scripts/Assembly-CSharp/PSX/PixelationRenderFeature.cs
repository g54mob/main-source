using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace PSX
{
	public class PixelationRenderFeature : ScriptableRendererFeature
	{
		private PixelationPass pixelationPass;

		public override void Create()
		{
			pixelationPass = new PixelationPass(RenderPassEvent.BeforeRenderingPostProcessing);
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			pixelationPass.Setup((RenderTargetIdentifier)renderer.cameraColorTargetHandle);
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			renderer.EnqueuePass(pixelationPass);
		}
	}
}
