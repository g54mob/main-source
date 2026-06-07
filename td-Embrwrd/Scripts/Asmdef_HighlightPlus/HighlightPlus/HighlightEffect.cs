using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace HighlightPlus
{
	[ExecuteAlways]
	[HelpURL("https://kronnect.com/guides/highlight-plus-introduction/")]
	public class HighlightEffect : MonoBehaviour
	{
		private struct ModelMaterials
		{
			public bool render;

			public Transform transform;

			public bool renderWasVisibleDuringSetup;

			public Mesh mesh;

			public Mesh originalMesh;

			public Mesh bakedSkinnedMesh;

			public Renderer renderer;

			public bool isSkinnedMesh;

			public NormalsOption normalsOption;

			public Material[] fxMatMask;

			public Material[] fxMatOutline;

			public Material[] fxMatGlow;

			public Material[] fxMatSolidColor;

			public Material[] fxMatSeeThroughInner;

			public Material[] fxMatSeeThroughBorder;

			public Material[] fxMatOverlay;

			public Material[] fxMatInnerGlow;

			public Matrix4x4 renderingMatrix;

			public bool isCombined;

			public bool preserveOriginalMesh => false;

			public void Init()
			{
			}
		}

		public enum FadingState
		{
			FadingOut = -1,
			NoFading = 0,
			FadingIn = 1
		}

		private class PerCameraOcclusionData
		{
			public float checkLastTime;

			public int occlusionRenderFrame;

			public bool lastOcclusionTestResult;

			public readonly List<Renderer> cachedOccluders;

			public Collider cachedOccluderCollider;
		}

		[Tooltip("The current profile (optional). A profile let you store Highlight Plus settings and apply those settings easily to many objects. You can also load a profile and apply its settings at runtime, using the ProfileLoad() method of the Highlight Effect component.")]
		public HighlightProfile profile;

		[Tooltip("If enabled, settings from the profile will be applied to this component automatically when game starts or when any profile setting is updated.")]
		public bool profileSync;

		[Tooltip("Which cameras can render the effect.")]
		public LayerMask camerasLayerMask;

		[Tooltip("Different options to specify which objects are affected by this Highlight Effect component.")]
		public TargetOptions effectGroup;

		[Tooltip("The target object to highlight.")]
		public Transform effectTarget;

		[Tooltip("The layer that contains the affected objects by this effect when effectGroup is set to LayerMask.")]
		public LayerMask effectGroupLayer;

		[Tooltip("Only include objects whose names contains this text.")]
		public string effectNameFilter;

		[Tooltip("Use RegEx to determine if an object name matches the effectNameFilter.")]
		public bool effectNameUseRegEx;

		[Tooltip("Combine meshes of all objects in this group affected by Highlight Effect reducing draw calls.")]
		public bool combineMeshes;

		[Tooltip("The alpha threshold for transparent cutout objects. Pixels with alpha below this value will be discarded.")]
		[Range(0f, 1f)]
		public float alphaCutOff;

		[Tooltip("If back facing triangles are ignored.Backfaces triangles are not visible but you may set this property to false to force highlight effects to act on those triangles as well.")]
		public bool cullBackFaces;

		[Tooltip("Show highlight effects even if the object is not visible. If this object or its children use GPU Instancing tools, the MeshRenderer can be disabled although the object is visible. In this case, this option is useful to enable highlighting.")]
		public bool ignoreObjectVisibility;

		[Tooltip("Support reflection probes. Enable only if you want the effects to be visible in reflections.")]
		public bool reflectionProbes;

		[Tooltip("Enables GPU instancing. Reduces draw calls in outline and outer glow effects on platforms that support GPU instancing. Should be enabled by default.")]
		public bool GPUInstancing;

		[Tooltip("Custom sorting priority for the highlight effect (useful to control which effects render on top of others")]
		public int sortingPriority;

		[Tooltip("Bakes skinned mesh to leverage GPU instancing when using outline/outer glow with mesh-based rendering. Reduces draw calls significantly on skinned meshes.")]
		public bool optimizeSkinnedMesh;

		[Tooltip("Enables depth buffer clipping. Only applies to outline or outer glow in High Quality mode.")]
		public bool depthClip;

		[Tooltip("Fades out effects based on distance to camera")]
		public bool cameraDistanceFade;

		[Tooltip("The closest distance particles can get to the camera before they fade from the camera's view.")]
		public float cameraDistanceFadeNear;

		[Tooltip("The farthest distance particles can get away from the camera before they fade from the camera's view.")]
		public float cameraDistanceFadeFar;

		[Tooltip("Normals handling option:\nPreserve original: use original mesh normals.\nSmooth: average normals to produce a smoother outline/glow mesh based effect.\nReorient: recomputes normals based on vertex direction to centroid.")]
		public NormalsOption normalsOption;

		[Tooltip("Ignore highlighting on this object.")]
		public bool ignore;

		[SerializeField]
		private bool _highlighted;

		public float fadeInDuration;

		public float fadeOutDuration;

		public bool flipY;

		[Tooltip("Keeps the outline/glow size unaffected by object distance.")]
		public bool constantWidth;

		[Tooltip("Increases the screen coverage for the outline/glow to avoid cuts when using cloth or vertex shader that transform mesh vertices")]
		public int extraCoveragePixels;

		[Tooltip("Minimum width when the constant width option is not used")]
		[Range(0f, 1f)]
		public float minimumWidth;

		[Tooltip("Mask to include or exclude certain submeshes. By default, all submeshes are included.")]
		public int subMeshMask;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the overlay effect. A value of 0 disables the overlay completely.")]
		public float overlay;

		public OverlayMode overlayMode;

		public OverlayPattern overlayPattern;

		public Vector2 overlayPatternScrolling;

		[ColorUsage(false, true)]
		public Color overlayColor;

		public float overlayAnimationSpeed;

		[Range(0f, 1f)]
		public float overlayMinIntensity;

		[Range(0f, 1f)]
		[Tooltip("Controls the blending or mix of the overlay color with the natural colors of the object.")]
		public float overlayBlending;

		[Tooltip("Optional overlay texture.")]
		public Texture2D overlayTexture;

		public TextureUVSpace overlayTextureUVSpace;

		public float overlayTextureScale;

		public Vector2 overlayTextureScrolling;

		public Visibility overlayVisibility;

		[Tooltip("Scale of the overlay pattern")]
		[Range(1f, 100f)]
		public float overlayPatternScale;

		[Range(0.01f, 1f)]
		[Tooltip("Size/Thickness of the overlay pattern")]
		public float overlayPatternSize;

		[Tooltip("Softness of the overlay pattern")]
		[Range(0.01f, 0.5f)]
		public float overlayPatternSoftness;

		[Tooltip("Rotation angle for the overlay pattern in degrees")]
		[Range(-180f, 180f)]
		public float overlayPatternRotation;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the outline. A value of 0 disables the outline completely.")]
		public float outline;

		[ColorUsage(true, true)]
		public Color outlineColor;

		public ColorStyle outlineColorStyle;

		[GradientUsage(true, ColorSpace.Linear)]
		public Gradient outlineGradient;

		public bool outlineGradientInLocalSpace;

		public float outlineWidth;

		[Range(1f, 3f)]
		public int outlineBlurPasses;

		public QualityLevel outlineQuality;

		public OutlineEdgeMode outlineEdgeMode;

		public float outlineEdgeThreshold;

		public float outlineSharpness;

		[Range(1f, 8f)]
		[Tooltip("Reduces the quality of the outline but improves performance a bit.")]
		public int outlineDownsampling;

		public Visibility outlineVisibility;

		public GlowBlendMode glowBlendMode;

		public bool outlineBlitDebug;

		[Tooltip("If enabled, this object won't combine the outline with other objects.")]
		public bool outlineIndependent;

		public ContourStyle outlineContourStyle;

		[Tooltip("Select the mask mode used with this effect.")]
		public MaskMode outlineMaskMode;

		public float outlineGradientKnee;

		public float outlineGradientPower;

		[Range(0f, 1f)]
		[Tooltip("Adds a empty margin between the outline mesh and the effects")]
		public float padding;

		[Tooltip("Enables stylized outline effect.")]
		public bool outlineStylized;

		[Tooltip("Pattern texture used for the stylized outline effect.")]
		public Texture2D outlinePattern;

		[Tooltip("Scale of the pattern texture.")]
		public float outlinePatternScale;

		[Tooltip("Threshold for the pattern texture.")]
		[Range(0f, 1f)]
		public float outlinePatternThreshold;

		[Tooltip("Distortion amount for the pattern texture.")]
		[Range(0f, 1.5f)]
		public float outlinePatternDistortionAmount;

		[Tooltip("Pattern texture used for the distortion effect.")]
		[Range(0f, 1f)]
		public Texture2D outlinePatternDistortionTexture;

		[Tooltip("Stop motion scale for the distortion effect.")]
		public float outlinePatternStopMotionScale;

		[Tooltip("Enables dashed outline effect.")]
		public bool outlineDashed;

		[Tooltip("Width of the dashed outline.")]
		[Range(0f, 1f)]
		public float outlineDashWidth;

		[Range(0f, 1f)]
		[Tooltip("Gap of the dashed outline.")]
		public float outlineDashGap;

		[Tooltip("Speed of the dashed outline.")]
		public float outlineDashSpeed;

		[Tooltip("The intensity of the outer glow effect. A value of 0 disables the glow completely.")]
		[Range(0f, 5f)]
		public float glow;

		public float glowWidth;

		public QualityLevel glowQuality;

		public BlurMethod glowBlurMethod;

		public bool glowHighPrecision;

		[Tooltip("Reduces the quality of the glow but improves performance a bit.")]
		[Range(1f, 8f)]
		public int glowDownsampling;

		[ColorUsage(true, true)]
		public Color glowHQColor;

		[Range(0f, 1f)]
		[Tooltip("When enabled, outer glow renders with dithering. When disabled, glow appears as a solid color.")]
		public float glowDithering;

		public GlowDitheringStyle glowDitheringStyle;

		[Tooltip("Seed for the dithering effect")]
		public float glowMagicNumber1;

		[Tooltip("Another seed for the dithering effect that combines with first seed to create different patterns")]
		public float glowMagicNumber2;

		public float glowAnimationSpeed;

		public Visibility glowVisibility;

		public bool glowBlitDebug;

		[Tooltip("Blends glow passes one after another. If this option is disabled, glow passes won't overlap (in this case, make sure the glow pass 1 has a smaller offset than pass 2, etc.)")]
		public bool glowBlendPasses;

		[NonReorderable]
		public GlowPassData[] glowPasses;

		[Tooltip("Select the mask mode used with this effect.")]
		public MaskMode glowMaskMode;

		[Range(0f, 5f)]
		[Tooltip("The intensity of the inner glow effect. A value of 0 disables the glow completely.")]
		public float innerGlow;

		[Range(0f, 2f)]
		public float innerGlowWidth;

		public float innerGlowPower;

		[ColorUsage(true, true)]
		public Color innerGlowColor;

		public InnerGlowBlendMode innerGlowBlendMode;

		public Visibility innerGlowVisibility;

		[Tooltip("Enables the targetFX effect. This effect draws an animated sprite over the object.")]
		public bool targetFX;

		[Tooltip("Style of the target FX effect.")]
		public TargetFXStyle targetFXStyle;

		[Tooltip("Width of the frame when using Frame style")]
		[Range(0.001f, 0.5f)]
		public float targetFXFrameWidth;

		[Tooltip("Length of the frame corners when using Frame style")]
		[Range(0f, 0.5f)]
		public float targetFXCornerLength;

		[Tooltip("Minimum opacity of the frame when using Frame style")]
		[Range(0f, 1f)]
		public float targetFXFrameMinOpacity;

		[Tooltip("If the ground is transparent, the effect won't work. You can set this property to the altitude of the transparent ground to force the effect to render at this altitude.")]
		public float targetFXGroundMinAltitude;

		public Texture2D targetFXTexture;

		[ColorUsage(true, true)]
		public Color targetFXColor;

		public Transform targetFXCenter;

		public float targetFXRotationSpeed;

		[Tooltip("Initial rotation angle for the Target FX effect")]
		public float targetFXRotationAngle;

		public float targetFXInitialScale;

		public float targetFXEndScale;

		[Tooltip("Makes target scale relative to object renderer bounds")]
		public bool targetFXScaleToRenderBounds;

		[Tooltip("Enable to render a single target FX effect at the center of the enclosing bounds")]
		public bool targetFXUseEnclosingBounds;

		[Tooltip("Makes target FX effect square")]
		public bool targetFXSquare;

		[Tooltip("Places target FX sprite at the bottom of the highlighted object")]
		public bool targetFXAlignToGround;

		[Tooltip("Optional worlds space offset for the position of the targetFX effect")]
		public Vector3 targetFXOffset;

		[Tooltip("If enabled, the target FX effect will be centered on the hit position")]
		public bool targetFxCenterOnHitPosition;

		[Tooltip("If enabled, the target FX effect will align to the hit normal")]
		public bool targetFxAlignToNormal;

		[Tooltip("Fade out effect with altitude")]
		public float targetFXFadePower;

		public float targetFXGroundMaxDistance;

		public LayerMask targetFXGroundLayerMask;

		public float targetFXTransitionDuration;

		[Tooltip("The duration of the effect. A value of 0 will keep the target sprite on screen while object is highlighted.")]
		public float targetFXStayDuration;

		public Visibility targetFXVisibility;

		[Tooltip("Enables the iconFX effect. This effect draws an animated object over the object.")]
		public bool iconFX;

		public IconAssetType iconFXAssetType;

		public GameObject iconFXPrefab;

		public Mesh iconFXMesh;

		[ColorUsage(true, true)]
		public Color iconFXLightColor;

		[ColorUsage(true, true)]
		public Color iconFXDarkColor;

		public Transform iconFXCenter;

		public float iconFXRotationSpeed;

		public IconAnimationOption iconFXAnimationOption;

		public float iconFXAnimationAmount;

		public float iconFXAnimationSpeed;

		public float iconFXScale;

		[Tooltip("Makes target scale relative to object renderer bounds.")]
		public bool iconFXScaleToRenderBounds;

		[Tooltip("Optional world space offset for the position of the iconFX effect")]
		public Vector3 iconFXOffset;

		public float iconFXTransitionDuration;

		public float iconFXStayDuration;

		[Tooltip("Enables the label effect. This effect shows a text label over the object.")]
		public bool labelEnabled;

		[Tooltip("The text to display in the label")]
		public string labelText;

		[Tooltip("The size of the label text")]
		public float labelTextSize;

		[ColorUsage(true, true)]
		public Color labelColor;

		[Tooltip("The prefab to use for the label. Must contain a Canvas and TextMeshProUGUI component.")]
		public GameObject labelPrefab;

		public float labelVerticalOffset;

		[Tooltip("The horizontal offset of the label with respect to the object center")]
		public float lineLength;

		[Tooltip("The target transform for the label")]
		public Transform labelTarget;

		[Tooltip("If enabled, the label will follow the cursor when hovering the object")]
		public bool labelFollowCursor;

		public LabelMode labelMode;

		[Tooltip("If enabled, the label will be shown in editor mode (non playing)")]
		public bool labelShowInEditorMode;

		[Tooltip("Controls the alignment of the label relative to the target object on screen.")]
		public LabelAlignment labelAlignment;

		[Tooltip("See-through mode for this Highlight Effect component.")]
		public SeeThroughMode seeThrough;

		[Tooltip("This mask setting let you specify which objects will be considered as occluders and cause the see-through effect for this Highlight Effect component. For example, you assign your walls to a different layer and specify that layer here, so only walls and not other objects, like ground or ceiling, will trigger the see-through effect.")]
		public LayerMask seeThroughOccluderMask;

		[Range(0.01f, 0.6f)]
		[Tooltip("A multiplier for the occluder volume size which can be used to reduce the actual size of occluders when Highlight Effect checks if they're occluding this object.")]
		public float seeThroughOccluderThreshold;

		[Tooltip("Uses stencil buffers to ensure pixel-accurate occlusion test. If this option is disabled, only physics raycasting is used to test for occlusion.")]
		public bool seeThroughOccluderMaskAccurate;

		[Tooltip("The interval of time between occlusion tests.")]
		public float seeThroughOccluderCheckInterval;

		[Tooltip("If enabled, occlusion test is performed for each children element. If disabled, the bounds of all children is combined and a single occlusion test is performed for the combined bounds.")]
		public bool seeThroughOccluderCheckIndividualObjects;

		[Tooltip("Shows the see-through effect only if the occluder if at this 'offset' distance from the object.")]
		public float seeThroughDepthOffset;

		[Tooltip("Hides the see-through effect if the occluder is further than this distance from the object (0 = infinite)")]
		public float seeThroughMaxDepth;

		[Range(0f, 5f)]
		public float seeThroughIntensity;

		[Range(0f, 1f)]
		public float seeThroughTintAlpha;

		[ColorUsage(true, true)]
		public Color seeThroughTintColor;

		[Range(0f, 1f)]
		public float seeThroughNoise;

		[Range(0f, 1f)]
		public float seeThroughBorder;

		public Color seeThroughBorderColor;

		[Tooltip("Only display the border instead of the full see-through effect.")]
		public bool seeThroughBorderOnly;

		public float seeThroughBorderWidth;

		[Tooltip("This option clears the stencil buffer after rendering the see-through effect which results in correct rendering order and supports other stencil-based effects that render afterwards.")]
		public bool seeThroughOrdered;

		[Tooltip("Optional see-through mask effect texture.")]
		public Texture2D seeThroughTexture;

		public TextureUVSpace seeThroughTextureUVSpace;

		public float seeThroughTextureScale;

		[Tooltip("The order by which children objects are rendered by the see-through effect")]
		public SeeThroughSortingMode seeThroughChildrenSortingMode;

		[SerializeField]
		[HideInInspector]
		private ModelMaterials[] rms;

		[HideInInspector]
		[SerializeField]
		private int rmsCount;

		[NonSerialized]
		public bool alignToGroundTried;

		[NonSerialized]
		public bool alignToGroundHitGood;

		[NonSerialized]
		public bool isVisible;

		[NonSerialized]
		public Transform target;

		[NonSerialized]
		public float highlightStartTime;

		[NonSerialized]
		public float targetFXStartTime;

		[NonSerialized]
		public float iconFXStartTime;

		private GameObject instantiatedIconPrefab;

		private List<Material> instantiatedIconMaterials;

		private bool _isSelected;

		[NonSerialized]
		public bool spriteMode;

		[NonSerialized]
		public HighlightProfile previousSettings;

		public static HighlightEffect lastHighlighted;

		public static HighlightEffect lastSelected;

		[NonSerialized]
		public string lastRegExError;

		private const float TAU = 0.70711f;

		private static Material fxMatMask;

		private static Material fxMatSolidColor;

		private static Material fxMatSeeThrough;

		private static Material fxMatSeeThroughBorder;

		private static Material fxMatOverlay;

		private static Material fxMatClearStencil;

		private static Material fxMatSeeThroughMask;

		private Material fxMatGlowTemplate;

		private Material fxMatInnerGlow;

		private Material fxMatOutlineTemplate;

		private Material fxMatTarget;

		private Material fxMatComposeGlow;

		private Material fxMatComposeOutline;

		private Material fxMatBlurGlow;

		private Material fxMatBlurOutline;

		private Material fxMatIcon;

		private static Vector4[] offsets;

		private float fadeStartTime;

		[NonSerialized]
		public FadingState fading;

		private CommandBuffer cbHighlight;

		private bool cbHighlightEmpty;

		private int[] mipGlowBuffers;

		private int[] mipOutlineBuffers;

		private static Mesh quadMesh;

		private static Mesh cubeMesh;

		private int sourceRT;

		private Matrix4x4 quadGlowMatrix;

		private Matrix4x4 quadOutlineMatrix;

		private Vector4[] corners;

		private RenderTextureDescriptor sourceDesc;

		private Color debugColor;

		private Color blackColor;

		private Visibility lastOutlineVisibility;

		private bool requireUpdateMaterial;

		private Bounds enclosingBounds;

		[NonSerialized]
		public static List<HighlightEffect> effects;

		public static bool customSorting;

		[NonSerialized]
		public float sortingOffset;

		private bool useSmoothGlow;

		private bool useSmoothOutline;

		private bool useSmoothBlend;

		private bool useGPUInstancing;

		private bool usesReversedZBuffer;

		private bool usesSeeThrough;

		private bool maskRequired;

		private bool shouldBakeSkinnedMesh;

		private bool renderMaskOnTop;

		private readonly Dictionary<Camera, PerCameraOcclusionData> perCameraOcclusionData;

		private MaterialPropertyBlock glowPropertyBlock;

		private MaterialPropertyBlock outlinePropertyBlock;

		private static readonly List<Vector4> matDataDirection;

		private static readonly List<Vector4> matDataGlow;

		private static readonly List<Vector4> matDataColor;

		private static Matrix4x4[] matrices;

		private int outlineOffsetsMin;

		private int outlineOffsetsMax;

		private int glowOffsetsMin;

		private int glowOffsetsMax;

		private Texture2D outlineGradientTex;

		private Color[] outlineGradientColors;

		private bool isInitialized;

		private float realOutlineWidth;

		private RenderTargetIdentifier colorAttachmentBuffer;

		private RenderTargetIdentifier depthAttachmentBuffer;

		private readonly List<Renderer> tempRR;

		private static List<Vector3> vertices;

		private static List<Vector3> normals;

		private static Vector3[] newNormals;

		private static int[] matches;

		private static readonly Dictionary<Vector3, int> vv;

		private static readonly List<Material> rendererSharedMaterials;

		private static readonly Dictionary<int, Mesh> smoothMeshes;

		private static readonly Dictionary<int, Mesh> reorientedMeshes;

		private static readonly Dictionary<Mesh, int> sharedMeshUsage;

		private readonly List<Mesh> instancedMeshes;

		private const int MAX_VERTEX_COUNT = 65535;

		private static CombineInstance[] combineInstances;

		private static readonly Dictionary<int, Mesh> combinedMeshes;

		private int combinedMeshesHashId;

		public static bool useUnscaledTime;

		[NonSerialized]
		public Transform currentHitTarget;

		[NonSerialized]
		public Vector3 currentHitLocalPosition;

		[NonSerialized]
		public Vector3 currentHitNormal;

		[Range(0f, 1f)]
		public float hitFxInitialIntensity;

		public HitFxMode hitFxMode;

		public HitFXTriggerMode hitFXTriggerMode;

		public float hitFxFadeOutDuration;

		[ColorUsage(true, true)]
		public Color hitFxColor;

		public float hitFxRadius;

		private float hitInitialIntensity;

		private float hitStartTime;

		private float hitFadeOutDuration;

		private Color hitColor;

		private bool hitActive;

		private Vector3 hitPosition;

		private float hitRadius;

		[NonSerialized]
		public HighlightLabel label;

		private static readonly List<HighlightSeeThroughOccluder> occluders;

		private static readonly Dictionary<Camera, int> occludersFrameCount;

		private static Material fxMatSeeThroughOccluder;

		private static Material fxMatDepthWrite;

		private static RaycastHit[] hits;

		private const int MAX_OCCLUDER_HITS = 50;

		private static RaycastHit[] occluderHits;

		public bool highlighted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int includedObjectsCount => 0;

		public Transform currentTarget => null;

		public bool isSelected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event OnObjectSelectionEvent OnObjectSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnObjectSelectionEvent OnObjectUnSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnObjectHighlightEvent OnObjectHighlightStart
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnObjectHighlightEvent OnObjectHighlightEnd
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnObjectHighlightStateEvent OnObjectHighlightStateChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnRendererHighlightEvent OnRendererHighlightStart
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnAnimateEvent OnTargetAnimates
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnAnimateEvent OnIconAnimates
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void RestorePreviousHighlightEffectSettings()
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void DomainReloadDisabledSupport()
		{
		}

		private void OnEnable()
		{
		}

		private void InitIfNeeded()
		{
		}

		private void Init()
		{
		}

		private void Start()
		{
		}

		public void OnDidApplyAnimationProperties()
		{
		}

		private void OnDisable()
		{
		}

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		private void DestroyMaterial(Material mat)
		{
		}

		private void DestroyMaterialArray(Material[] mm)
		{
		}

		private void RemoveEffect()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnBecameVisible()
		{
		}

		private void OnBecameInvisible()
		{
		}

		public void ProfileLoad(HighlightProfile profile)
		{
		}

		public void ProfileReload()
		{
		}

		public void ProfileSaveChanges(HighlightProfile profile)
		{
		}

		public void ProfileSaveChanges()
		{
		}

		public void Refresh(bool discardCachedMeshes = false)
		{
		}

		public void ResetHighlightStartTime()
		{
		}

		public void SetCommandBuffer(CommandBuffer cmd)
		{
		}

		public CommandBuffer BuildCommandBuffer(Camera cam, RenderTargetIdentifier colorAttachmentBuffer, RenderTargetIdentifier depthAttachmentBuffer, bool clearStencil, ref RenderTextureDescriptor sourceDesc)
		{
			return null;
		}

		private void BuildCommandBuffer(Camera cam, bool clearStencil)
		{
		}

		private void RenderMask(int k, Mesh mesh)
		{
		}

		private void RenderSeeThroughClearStencil(int k, Mesh mesh)
		{
		}

		private void RenderSeeThroughMask(int k, Mesh mesh)
		{
		}

		private void WorldToViewportPoint(ref Matrix4x4 m, ref Vector4 p, bool perspectiveProjection, float zBufferParamsZ, float zBufferParamsW)
		{
		}

		private void ComputeEnclosingBounds()
		{
		}

		private bool ComputeSmoothQuadMatrix(Camera cam, Bounds bounds)
		{
			return false;
		}

		private bool ComputeSmoothQuadMatrixOriginShifted(Camera cam, ref Bounds bounds, ref Vector3 shift)
		{
			return false;
		}

		private void BuildMatrix(Camera cam, Vector3 scrMin, Vector3 scrMax, int border, ref Matrix4x4 quadMatrix, ref Vector3 shift)
		{
		}

		private void SmoothGlow(int rtWidth, int rtHeight)
		{
		}

		private void SmoothOutline(int rtWidth, int rtHeight)
		{
		}

		private void ComposeSmoothBlend(Visibility smoothGlowVisibility, Visibility smoothOutlineVisibility)
		{
		}

		private void InitMaterial(ref Material material, string shaderName)
		{
		}

		private void Fork(Material mat, ref Material[] mats, Mesh mesh)
		{
		}

		private void Fork(Material material, ref Material[] array, int count)
		{
		}

		public void SetTarget(Transform transform)
		{
		}

		public void SetTargets(Transform transform, Renderer[] renderers)
		{
		}

		public void SetHighlighted(bool state)
		{
		}

		private void ImmediateFadeOut()
		{
		}

		private void SetupMaterial()
		{
		}

		private void SetupMaterial(Renderer[] rr)
		{
		}

		private bool ValidRenderer(Renderer r)
		{
			return false;
		}

		private Renderer[] FindRenderersWithLayerInScene(LayerMask layer)
		{
			return null;
		}

		private Renderer[] FindRenderersWithLayerInChildren(LayerMask layer)
		{
			return null;
		}

		private Renderer[] FindRenderersInChildren(Transform parent)
		{
			return null;
		}

		private void InitTemplateMaterials()
		{
		}

		private void InitCommandBuffer()
		{
		}

		private void ConfigureOutput()
		{
		}

		public void UpdateVisibilityState()
		{
		}

		public void UpdateMaterialProperties(bool disabling = false)
		{
		}

		private int MaterialsRenderQueueComparer(ModelMaterials m1, ModelMaterials m2)
		{
			return 0;
		}

		private int MaterialsRenderQueueInvertedComparer(ModelMaterials m1, ModelMaterials m2)
		{
			return 0;
		}

		private float ComputeCameraDistanceFade(Vector3 position, Transform cameraTransform)
		{
			return 0f;
		}

		private int GetZTestValue(Visibility param)
		{
			return 0;
		}

		private void BuildQuad()
		{
		}

		private void BuildCube()
		{
		}

		private void ReleaseInstantiatedIconPrefab()
		{
		}

		private void HideIconPrefab()
		{
		}

		public bool Includes(Transform transform)
		{
			return false;
		}

		public void SetGlowColor(Color color)
		{
		}

		private void AverageNormals(int objIndex)
		{
		}

		private void ReorientNormals(int objIndex)
		{
		}

		private void CombineMeshes()
		{
		}

		public string ValidateCombineMeshes()
		{
			return null;
		}

		private void IncrementeMeshUsage(Mesh mesh)
		{
		}

		public static void ClearMeshCache()
		{
		}

		private void RefreshCachedMeshes()
		{
		}

		public static float GetTime()
		{
			return 0f;
		}

		public void HitFX()
		{
		}

		public void HitFX(Vector3 position)
		{
		}

		public void HitFX(Color color, float fadeOutDuration, float initialIntensity = 1f)
		{
		}

		public void HitFX(Color color, float fadeOutDuration, float initialIntensity, Vector3 position, float radius)
		{
		}

		public void TargetFX()
		{
		}

		public void IconFX()
		{
		}

		private void ReleaseLabel()
		{
		}

		private void CheckLabel(bool disabling)
		{
		}

		public void SetHitPosition(Transform target, Vector3 localPosition, Vector3 offsetWS, Vector3 normalWS)
		{
		}

		public void RefreshLabel()
		{
		}

		public bool IsSeeThroughOccluded(Camera cam)
		{
			return false;
		}

		public static void RegisterOccluder(HighlightSeeThroughOccluder occluder)
		{
		}

		public static void UnregisterOccluder(HighlightSeeThroughOccluder occluder)
		{
		}

		public bool RenderSeeThroughOccluders(CommandBuffer cb, Camera cam)
		{
			return false;
		}

		private bool CheckOcclusion(Camera cam)
		{
			return false;
		}

		private void AddWithoutRepetition(List<Renderer> target, List<Renderer> source, LayerMask layerMask)
		{
		}

		private void CheckOcclusionAccurate(CommandBuffer cbuf, Camera cam)
		{
		}

		public void GetOccluders(Camera camera, List<Transform> occluders)
		{
		}
	}
}
