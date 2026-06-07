using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace PSX
{
	public class DitheringRenderFeature : ScriptableRendererFeature
	{
		private DitheringPass ditheringPass;

		public override void Create()
		{
			ditheringPass = new DitheringPass(RenderPassEvent.BeforeRenderingPostProcessing);
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			ditheringPass.Setup((RenderTargetIdentifier)renderer.cameraColorTargetHandle);
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			renderer.EnqueuePass(ditheringPass);
		}
	}
}
