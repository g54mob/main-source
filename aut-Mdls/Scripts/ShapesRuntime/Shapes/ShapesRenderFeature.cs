using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Shapes
{
	public class ShapesRenderFeature : ScriptableRendererFeature
	{
		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			Camera camera = renderingData.cameraData.camera;
			if (!DrawCommand.cBuffersRendering.TryGetValue(camera, out var value))
			{
				return;
			}
			foreach (DrawCommand item in value)
			{
				renderer.EnqueuePass(ObjectPool<ShapesRenderPass>.Alloc().Init(item));
			}
		}
	}
}
