using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InitializeRendererFeaturePass : ScriptableRendererFeature
{
	private static readonly int UNSCALED_TIME = Shader.PropertyToID("_UnscaledTime");

	public override void Create()
	{
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		float unscaledTime = Time.unscaledTime;
		Shader.SetGlobalVector(UNSCALED_TIME, new Vector4(unscaledTime / 20f, unscaledTime, unscaledTime / 2f, unscaledTime / 3f));
	}
}
