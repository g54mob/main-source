using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace PSX
{
	public class FogRenderFeature : ScriptableRendererFeature
	{
		private FogPass fogPass;

		public override void Create()
		{
			fogPass = new FogPass(RenderPassEvent.BeforeRenderingPostProcessing);
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			fogPass.Setup((RenderTargetIdentifier)renderer.cameraColorTargetHandle);
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			renderer.EnqueuePass(fogPass);
		}
	}
}
