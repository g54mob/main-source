using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

internal class ScrollingFormulas : CustomPass
{
	public Texture2D scrollingFormula;

	private Material scrollingFullscreen;

	protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
	{
	}

	protected override void Execute(ScriptableRenderContext renderContext, CommandBuffer cmd, HDCamera camera, CullingResults cullingResult)
	{
	}

	protected override void Cleanup()
	{
	}
}
