using UnityEngine.Rendering.Universal;

namespace CTS.Rendering
{
	public class RenderDepthFeature : ScriptableRendererFeature
	{
		private RenderDepthPass _pass;

		public override void Create()
		{
			_pass = new RenderDepthPass
			{
				renderPassEvent = RenderPassEvent.BeforeRenderingTransparents
			};
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			renderer.EnqueuePass(_pass);
		}
	}
}
