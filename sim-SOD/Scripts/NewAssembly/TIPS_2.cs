using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

internal class TIPS_2 : CustomPass
{
	public Mesh mesh;

	public float size;

	public float rotationSpeed;

	public float edgeDetectThreshold;

	public int edgeRadius;

	public Color glowColor;

	public Material tipsMeshMaterial;

	private Material fullscreenMaterial;

	private RTHandle tipsBuffer;

	private int compositingPass;

	private int copyPass;

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
