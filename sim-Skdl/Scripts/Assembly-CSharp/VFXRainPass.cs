using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VFXRainPass : ScriptableRenderPass
{
	private RTHandle _cameraColorTarget;

	private RTHandle _cameraDepthTarget;

	private LayerMask _layerMask;

	private FilteringSettings _filteringSettings;

	private static readonly ShaderTagId[] _shaderTagIds;

	public void Setup(VFXRainFeature.Settings settings, RTHandle cameraColorTarget, RTHandle cameraDepthTarget)
	{
	}

	public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
	{
	}

	public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
	{
	}

	public void Dispose()
	{
	}
}
