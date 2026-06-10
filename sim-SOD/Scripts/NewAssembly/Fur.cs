using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

internal class Fur : CustomPass
{
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, "C:\\Users\\Cole\\Documents\\Game Work\\Shadows of Doubt\\Assets\\Shaders\\Custom Pass\\CustomPasses\\Fur\\Fur.cs")]
	private struct FurData
	{
		public Vector3 position;

		public FurData(Vector3 p)
		{
			position = default(Vector3);
		}
	}

	public LayerMask furMask;

	public Mesh furMesh;

	public Material furMaterial;

	private ShaderTagId[] shaderTags;

	private Material scatterFurPointsMaterial;

	private ComputeBuffer furData;

	private ComputeBuffer drawFurBuffer;

	private uint[] drawArgs;

	protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
	{
	}

	protected override void Execute(CustomPassContext ctx)
	{
	}

	private void DrawObjectToFurify(ScriptableRenderContext renderContext, CommandBuffer cmd, HDCamera hdCamera, CullingResults cullingResult)
	{
	}

	protected override void Cleanup()
	{
	}
}
