using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Enviro
{
	public class EnviroURPRenderFeature : ScriptableRendererFeature
	{
		private EnviroURPRenderGraph graph;

		private EnviroURPRenderPass pass;

		public override void Create()
		{
			pass = new EnviroURPRenderPass("Enviro Render Pass");
			graph = new EnviroURPRenderGraph();
			graph.renderPassEvent = (RenderPassEvent)449;
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode)
			{
				if (pass != null && EnviroHelper.CanRenderOnCamera(renderingData.cameraData.camera))
				{
					pass.scriptableRenderer = renderer;
					renderer.EnqueuePass(pass);
				}
			}
			else if (graph != null && EnviroHelper.CanRenderOnCamera(renderingData.cameraData.camera))
			{
				renderer.EnqueuePass(graph);
			}
		}
	}
}
