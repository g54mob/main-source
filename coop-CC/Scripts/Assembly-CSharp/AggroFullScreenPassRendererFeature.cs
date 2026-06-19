using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AggroFullScreenPassRendererFeature : FullScreenPassRendererFeature
{
	public bool showInSceneView;

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		CameraType cameraType = renderingData.cameraData.cameraType;
		if (showInSceneView || cameraType != CameraType.SceneView)
		{
			base.AddRenderPasses(renderer, ref renderingData);
		}
	}
}
