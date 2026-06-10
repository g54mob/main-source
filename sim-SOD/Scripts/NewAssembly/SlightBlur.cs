using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

internal class SlightBlur : CustomPass
{
	private static class ShaderID
	{
		public static readonly int _BlitTexture;

		public static readonly int _BlitScaleBias;

		public static readonly int _BlitMipLevel;

		public static readonly int _Radius;

		public static readonly int _Source;

		public static readonly int _ColorBufferCopy;

		public static readonly int _Mask;

		public static readonly int _MaskDepth;

		public static readonly int _InvertMask;

		public static readonly int _ViewPortSize;
	}

	[Range(0f, 8f)]
	public float radius;

	public bool useMask;

	public LayerMask maskLayer;

	public bool invertMask;

	private Material blurMaterial;

	private Material whiteRenderersMaterial;

	private RTHandle downSampleBuffer;

	private RTHandle blurBuffer;

	private RTHandle maskBuffer;

	private RTHandle maskDepthBuffer;

	private RTHandle colorCopy;

	private ShaderTagId[] shaderTags;

	[SerializeField]
	[HideInInspector]
	private Shader blurShader;

	[HideInInspector]
	[SerializeField]
	private Shader whiteRenderersShader;

	protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
	{
	}

	private void AllocateMaskBuffersIfNeeded()
	{
	}

	protected override void Execute(CustomPassContext ctx)
	{
	}

	protected override void AggregateCullingParameters(ref ScriptableCullingParameters cullingParameters, HDCamera hdCamera)
	{
	}

	private void DrawMaskObjects(ScriptableRenderContext renderContext, CommandBuffer cmd, HDCamera hdCamera, CullingResults cullingResult)
	{
	}

	private void SetViewPortSize(CommandBuffer cmd, MaterialPropertyBlock block, RTHandle target)
	{
	}

	private void GenerateGaussianMips(CommandBuffer cmd, HDCamera hdCam)
	{
	}

	protected override void Cleanup()
	{
	}
}
