using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

internal class CameraDepthBake : CustomPass
{
	public Camera bakingCamera;

	public RenderTexture targetTexture;

	public bool render;

	private ShaderTagId[] shaderTags;

	protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
	{
	}

	protected override void Execute(CustomPassContext ctx)
	{
	}

	protected override void Cleanup()
	{
	}
}
