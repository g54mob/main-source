using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

internal class Liquid : CustomPass
{
	private static class ShaderID
	{
		public static readonly int _BlitTexture;

		public static readonly int _BlitScaleBias;

		public static readonly int _BlitMipLevel;

		public static readonly int _Radius;

		public static readonly int _Source;

		public static readonly int _ViewPortSize;
	}

	[Range(0f, 64f)]
	public float radius;

	public LayerMask layerMask;

	public Material transparentFullscreenShader;

	private Material blurMaterial;

	private Material compositingMaterial;

	private RTHandle downSampleBuffer;

	private RTHandle blurBuffer;

	private Mesh quad;

	private ShaderTagId[] shaderTags;

	protected override void AggregateCullingParameters(ref ScriptableCullingParameters cullingParameters, HDCamera camera)
	{
	}

	protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
	{
	}

	protected override void Execute(CustomPassContext ctx)
	{
	}

	private void SetBlurParams(CommandBuffer cmd, MaterialPropertyBlock block, RTHandle target, Camera cam)
	{
	}

	private void BlurCustomBuffer(CustomPassContext ctx)
	{
	}

	protected override void Cleanup()
	{
	}
}
