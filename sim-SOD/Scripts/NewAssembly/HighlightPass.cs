using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class HighlightPass : CustomPass
{
	public LayerMask LayerMask;

	[SerializeField]
	private float _maxDistance;

	[SerializeField]
	private float _lerpMaxDistance;

	[Range(1f, 3f)]
	[SerializeField]
	private float _samplePrecision;

	[SerializeField]
	private float _outlineWidth;

	[ColorUsage(true, true)]
	[SerializeField]
	private Color _outerColor;

	[SerializeField]
	[Range(0f, 1f)]
	private float _behindFactor;

	[SerializeField]
	[ColorUsage(true, true)]
	private Color _innerColor;

	[SerializeField]
	private Texture _texture;

	[SerializeField]
	private Vector2 _texturePixelSize;

	[SerializeField]
	private Shader _fullscreenShader;

	[SerializeField]
	private Shader _objectShader;

	private static ShaderTagId[] _forwardShaderTags;

	private static readonly int MaxDist;

	private static readonly int LerpMaxDist;

	private ShaderTagId[] _cachedShaderTagIDs;

	private Material _objectMaterial;

	private int _objectPass;

	private Material _fullscreenMaterial;

	private int _fullscreenPass;

	private int _fadeValueId;

	private static readonly int SamplePrecision;

	private static readonly int OutlineWidth;

	private static readonly int InnerColor;

	private static readonly int OuterColor;

	private static readonly int Texture;

	private static readonly int TextureSize;

	private static readonly int BehindFactor;

	private ProfilingSampler outlineObjectsSampler;

	private ProfilingSampler fullscreenOutlineSampler;

	protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
	{
	}

	protected override void AggregateCullingParameters(ref ScriptableCullingParameters cullingParameters, HDCamera hdCamera)
	{
	}

	protected override void Execute(CustomPassContext ctx)
	{
	}

	private void RenderOutlineObjects(ScriptableRenderContext renderContext, CommandBuffer cmd, HDCamera hdCamera, CullingResults cullingResult)
	{
	}

	protected override void Cleanup()
	{
	}
}
