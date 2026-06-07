using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Camera))]
public class CommandBufferPP_Outline : MonoBehaviour
{
	protected static readonly Color _bufferClearColor = new Color(0f, 0f, 0f, 0f);

	protected static readonly string _defaultRenderBuffername = "CommandBuffer";

	[Header("CommandBuffer")]
	public CameraEvent CommandBufferEvent = CameraEvent.BeforeImageEffectsOpaque;

	protected CommandBufferPPOutlineTargetEntry CommandBufferPPTargetHighlightEntry;

	protected CommandBufferPPOutlineTargetEntry CommandBufferPPTargetNoHighlightEntry;

	protected Material _commandBufferCompositeMaterial;

	public Shader CommandBufferCompositeShaderOverride;

	protected Camera _owningCamera;

	protected int _cachedCameraPixelWidth = -1;

	protected int _cachedCameraPixelHeight = -1;

	[Header("Outline")]
	public Material RenderMaterialOverride;

	public bool UpdateOutlineColorsEachFrame;

	[Space(10f)]
	public Color OutlineColor = new Color(0.75f, 0.75f, 0.75f, 1f);

	public Color OutlineHighlightedColor = new Color(1f, 1f, 1f, 1f);

	protected Material _defaultOutlineRenderMaterial;

	protected Material _defaultHighlightRenderMaterial;

	[Space(10f)]
	public OutlineColorDefinitionScriptableObject ColorDefinition;

	protected OutlineTypeMaterialEntry _materialEntry;

	[Space(10f)]
	[Tooltip("How many times do we want to blur our shape?")]
	public int BlurIterations = 3;

	[Tooltip("With each blur how far should we spread the shape in all six directions (in pixels)")]
	public int BlurMinSpread = 1;

	[Tooltip("How much should the blurminspread increase with each blur iteration? (ex:BlurIterations = 3,BlurMinSpread = 1,BlurIterationSpread = 3 -> blur at iteration 3 will be 1+(3*3) ")]
	public int BlurIterationSpread;

	[Range(0f, 1f)]
	[Tooltip("Controls how much the blur alpha should be reduced with each blur pass. Lower values= soft feather. 1 =  hard outline")]
	public float BlurIntensityFalloff = 1f;

	protected int _blur01IDIndex;

	protected int _blur02IDIndex = 1;

	protected RenderTargetIdentifier _blur01TargetIdentifier;

	protected RenderTargetIdentifier _blur02TargetIdentifier;

	protected Material _blurMat;

	protected Material _stencilCutMat;

	protected const string cString_CommandBuffer = "_CommandBuffer";

	protected const string cSting_Cutout = "_Cutout";

	protected const string cString_Original = "_Original";

	protected const string cString_OutlineBlurOffset = "_BlurOffset";

	protected const string cString_OutlineColor = "_Color";

	protected const string cString_Intensity = "_Intensity";

	protected int _commandBufferMatID = Shader.PropertyToID("_CommandBuffer");

	protected int _cutoutMatID = Shader.PropertyToID("_Cutout");

	protected int _originalMatID = Shader.PropertyToID("_Original");

	protected int _outlineBlurOffsetMatID = Shader.PropertyToID("_BlurOffset");

	protected int _outlineColorMatID = Shader.PropertyToID("_Color");

	protected int _intensityMatID = Shader.PropertyToID("_Intensity");

	public virtual string RenderBufferName => _defaultRenderBuffername;

	protected virtual void Awake()
	{
		if ((bool)CommandBufferCompositeShaderOverride)
		{
			_commandBufferCompositeMaterial = new Material(CommandBufferCompositeShaderOverride);
		}
		else
		{
			_commandBufferCompositeMaterial = new Material(Shader.Find("Custom/PostProcessing/CommandBufferPP/Composite"));
		}
		if ((bool)RenderMaterialOverride)
		{
			_defaultOutlineRenderMaterial = new Material(RenderMaterialOverride);
		}
		else
		{
			_defaultOutlineRenderMaterial = new Material(Shader.Find("Custom/PostProcessing/CommandBufferPP/Outline/OutlineReplacement"));
		}
		if ((bool)_defaultOutlineRenderMaterial)
		{
			_defaultHighlightRenderMaterial = new Material(_defaultOutlineRenderMaterial);
		}
		else
		{
			Debug.LogError("[CommandBufferPP_Silhouette] - UNABLE TO LOAD A VALID RENDER MATERIAL.");
		}
		_blurMat = new Material(Shader.Find("Custom/PostProcessing/CommandBufferPP/Outline/Blur"));
		_stencilCutMat = new Material(Shader.Find("Custom/PostProcessing/CommandBufferPP/Outline/StencilCut"));
		RefreshMaterialEntryList();
	}

	protected virtual void OnDestroy()
	{
		if ((bool)_commandBufferCompositeMaterial)
		{
			Object.Destroy(_commandBufferCompositeMaterial);
		}
		if ((bool)_blurMat)
		{
			Object.Destroy(_blurMat);
		}
		if ((bool)_stencilCutMat)
		{
			Object.Destroy(_stencilCutMat);
		}
		if ((bool)_defaultHighlightRenderMaterial)
		{
			Object.Destroy(_defaultHighlightRenderMaterial);
		}
		if ((bool)_defaultOutlineRenderMaterial)
		{
			Object.Destroy(_defaultOutlineRenderMaterial);
		}
		Object.Destroy(_materialEntry.OutlineMaterial);
		Object.Destroy(_materialEntry.HighlightMaterial);
	}

	protected virtual void OnEnable()
	{
		if (_owningCamera == null)
		{
			_owningCamera = GetComponent<Camera>();
		}
		InitializeCommandBufferTargets();
		_blur01IDIndex = Shader.PropertyToID("_OutlineBlur01");
		_blur02IDIndex = Shader.PropertyToID("_OutlineBlur02");
		_blur01TargetIdentifier = new RenderTargetIdentifier(_blur01IDIndex);
		_blur02TargetIdentifier = new RenderTargetIdentifier(_blur02IDIndex);
	}

	protected virtual void OnDisable()
	{
		CleanupCommandBufferTargets();
	}

	protected void InitializeCommandBufferTargets()
	{
		if (CommandBufferPPTargetHighlightEntry == null)
		{
			CommandBufferPPTargetHighlightEntry = new CommandBufferPPOutlineTargetEntry(isHighlighted: true);
			if (base.isActiveAndEnabled && (bool)_owningCamera)
			{
				_owningCamera.AddCommandBuffer(CommandBufferEvent, CommandBufferPPTargetHighlightEntry.TargetCommandBuffer);
			}
		}
		else
		{
			Debug.LogWarning("[CommandBufferPP] - AddCommandBufferTarget - Attempting to add a new commandbuffer target for highlights when one already exists.");
		}
		if (CommandBufferPPTargetNoHighlightEntry == null)
		{
			CommandBufferPPTargetNoHighlightEntry = new CommandBufferPPOutlineTargetEntry(isHighlighted: false);
			if (base.isActiveAndEnabled && (bool)_owningCamera)
			{
				_owningCamera.AddCommandBuffer(CommandBufferEvent, CommandBufferPPTargetNoHighlightEntry.TargetCommandBuffer);
			}
		}
		else
		{
			Debug.LogWarning("[CommandBufferPP] - AddCommandBufferTarget - Attempting to add a new commandbuffer target for no highlights when one already exists.");
		}
	}

	protected void CleanupCommandBufferTargets()
	{
		CleanCommandBufferTarget(CommandBufferPPTargetHighlightEntry);
		CleanCommandBufferTarget(CommandBufferPPTargetNoHighlightEntry);
	}

	private void CleanCommandBufferTarget(CommandBufferPPOutlineTargetEntry target)
	{
		if (target.TargetCommandBuffer != null)
		{
			_owningCamera.RemoveCommandBuffer(CommandBufferEvent, target.TargetCommandBuffer);
			target.TargetCommandBuffer = null;
		}
		if (target.TargetRenderTexture != null && target.TargetRenderTexture.IsCreated())
		{
			target.TargetRenderTexture.Release();
			target.TargetRenderTexture = null;
		}
		if (target.BasicShapeRenderTexture != null && target.BasicShapeRenderTexture.IsCreated())
		{
			target.BasicShapeRenderTexture.Release();
			target.BasicShapeRenderTexture = null;
		}
	}

	protected virtual void OnPreRender()
	{
		bool isCameraDirty = false;
		if (_cachedCameraPixelWidth != _owningCamera.pixelWidth || _cachedCameraPixelHeight != _owningCamera.pixelHeight)
		{
			isCameraDirty = true;
		}
		_cachedCameraPixelWidth = _owningCamera.pixelWidth;
		_cachedCameraPixelHeight = _owningCamera.pixelHeight;
		PrepareCommandBuffer(CommandBufferPPTargetHighlightEntry, isCameraDirty);
		PrepareCommandBuffer(CommandBufferPPTargetNoHighlightEntry, isCameraDirty);
	}

	private void PrepareCommandBuffer(CommandBufferPPOutlineTargetEntry target, bool isCameraDirty)
	{
		if (target.TargetRenderTexture == null || isCameraDirty)
		{
			if (target.TargetRenderTexture != null)
			{
				if (target.TargetRenderTexture.IsCreated())
				{
					target.TargetRenderTexture.Release();
				}
				target.TargetRenderTexture = null;
			}
			target.TargetRenderTexture = new RenderTexture(_cachedCameraPixelWidth, _cachedCameraPixelHeight, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
			target.TargetRenderTexture.filterMode = FilterMode.Bilinear;
			target.TargetRenderTexture.useMipMap = false;
			target.TargetRenderTexture.wrapMode = TextureWrapMode.Clamp;
			if (!target.TargetRenderTexture.Create())
			{
				Debug.LogError("Failed to created rendertexture");
			}
			target.TargetRenderTargetIdentifier = new RenderTargetIdentifier(target.TargetRenderTexture);
		}
		if (target.BasicShapeRenderTexture == null || isCameraDirty)
		{
			if (target.BasicShapeRenderTexture != null)
			{
				if (target.BasicShapeRenderTexture.IsCreated())
				{
					target.BasicShapeRenderTexture.Release();
				}
				target.BasicShapeRenderTexture = null;
			}
			target.BasicShapeRenderTexture = new RenderTexture(_cachedCameraPixelWidth, _cachedCameraPixelHeight, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
			target.BasicShapeRenderTexture.filterMode = FilterMode.Bilinear;
			target.BasicShapeRenderTexture.useMipMap = false;
			target.BasicShapeRenderTexture.wrapMode = TextureWrapMode.Clamp;
			if (!target.BasicShapeRenderTexture.Create())
			{
				Debug.LogError("Failed to created rendertexture");
			}
			target.BasicShapeRenderTargetIdentifier = new RenderTargetIdentifier(target.BasicShapeRenderTexture);
		}
		RebuildCommandBuffer(target);
	}

	protected virtual void RebuildCommandBuffer(CommandBufferPPOutlineTargetEntry commandBufferPPTargetEntry)
	{
		commandBufferPPTargetEntry.TargetCommandBuffer.Clear();
		commandBufferPPTargetEntry.TargetCommandBuffer.SetRenderTarget(commandBufferPPTargetEntry.TargetRenderTargetIdentifier);
		commandBufferPPTargetEntry.TargetCommandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, _bufferClearColor);
		commandBufferPPTargetEntry.BasicShapeRenderTexture.DiscardContents(discardColor: true, discardDepth: true);
		FillBuffer(commandBufferPPTargetEntry);
		commandBufferPPTargetEntry.TargetCommandBuffer.Blit(commandBufferPPTargetEntry.TargetRenderTargetIdentifier, commandBufferPPTargetEntry.BasicShapeRenderTargetIdentifier);
		int width = commandBufferPPTargetEntry.TargetRenderTexture.width / 1;
		int height = commandBufferPPTargetEntry.TargetRenderTexture.height / 1;
		commandBufferPPTargetEntry.TargetCommandBuffer.GetTemporaryRT(_blur01IDIndex, width, height, 0, FilterMode.Bilinear, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
		commandBufferPPTargetEntry.TargetCommandBuffer.GetTemporaryRT(_blur02IDIndex, width, height, 0, FilterMode.Bilinear, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
		bool flag = true;
		commandBufferPPTargetEntry.TargetCommandBuffer.Blit(commandBufferPPTargetEntry.TargetRenderTargetIdentifier, _blur01TargetIdentifier);
		commandBufferPPTargetEntry.TargetCommandBuffer.SetGlobalFloat(_intensityMatID, BlurIntensityFalloff);
		for (int i = 0; i < BlurIterations; i++)
		{
			float value = BlurMinSpread + BlurIterationSpread * i;
			commandBufferPPTargetEntry.TargetCommandBuffer.SetGlobalFloat(_outlineBlurOffsetMatID, value);
			if (flag)
			{
				commandBufferPPTargetEntry.TargetCommandBuffer.Blit(_blur01TargetIdentifier, _blur02TargetIdentifier, _blurMat);
			}
			else
			{
				commandBufferPPTargetEntry.TargetCommandBuffer.Blit(_blur02TargetIdentifier, _blur01TargetIdentifier, _blurMat);
			}
			flag = !flag;
		}
		commandBufferPPTargetEntry.TargetCommandBuffer.Blit(flag ? _blur01IDIndex : _blur02IDIndex, commandBufferPPTargetEntry.TargetRenderTargetIdentifier, _stencilCutMat);
		commandBufferPPTargetEntry.TargetCommandBuffer.ReleaseTemporaryRT(_blur01IDIndex);
		commandBufferPPTargetEntry.TargetCommandBuffer.ReleaseTemporaryRT(_blur02IDIndex);
	}

	protected virtual void FillBuffer(CommandBufferPPOutlineTargetEntry commandBufferPPTargetEntry)
	{
		if (UpdateOutlineColorsEachFrame)
		{
			RefreshMaterialEntryList();
		}
	}

	public void RefreshMaterialEntryList()
	{
		if ((bool)ColorDefinition)
		{
			if (_materialEntry == null)
			{
				_materialEntry = new OutlineTypeMaterialEntry();
				_materialEntry.OutlineMaterial = new Material(_defaultOutlineRenderMaterial);
				_materialEntry.HighlightMaterial = new Material(_defaultOutlineRenderMaterial);
				_materialEntry.OutlineMaterial.SetColor(_outlineColorMatID, ColorDefinition.OutlineColor);
				_materialEntry.HighlightMaterial.SetColor(_outlineColorMatID, ColorDefinition.HighlightColor);
			}
			else
			{
				_materialEntry.OutlineMaterial.SetColor(_outlineColorMatID, ColorDefinition.OutlineColor);
				_materialEntry.HighlightMaterial.SetColor(_outlineColorMatID, ColorDefinition.HighlightColor);
			}
		}
		_defaultOutlineRenderMaterial.SetColor(_outlineColorMatID, OutlineColor);
		_defaultHighlightRenderMaterial.SetColor(_outlineColorMatID, OutlineHighlightedColor);
	}

	protected virtual void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(src.width, src.height);
		RenderTexture temporary2 = RenderTexture.GetTemporary(src.width, src.height);
		Graphics.Blit(src, temporary);
		if ((bool)_commandBufferCompositeMaterial)
		{
			_commandBufferCompositeMaterial.SetTexture(_originalMatID, src);
		}
		LinkTargetTexture(CommandBufferPPTargetHighlightEntry, temporary, temporary2);
		LinkTargetTexture(CommandBufferPPTargetNoHighlightEntry, temporary2, temporary);
		Graphics.Blit(temporary, dst);
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
	}

	private void LinkTargetTexture(CommandBufferPPOutlineTargetEntry target, RenderTexture source, RenderTexture destination)
	{
		if ((bool)_commandBufferCompositeMaterial)
		{
			_commandBufferCompositeMaterial.SetTexture(_commandBufferMatID, target.TargetRenderTexture);
			_commandBufferCompositeMaterial.SetTexture(_cutoutMatID, target.BasicShapeRenderTexture);
		}
		if (_commandBufferCompositeMaterial != null)
		{
			Graphics.Blit(source, destination, _commandBufferCompositeMaterial);
		}
		else
		{
			Graphics.Blit(source, destination);
		}
	}
}
