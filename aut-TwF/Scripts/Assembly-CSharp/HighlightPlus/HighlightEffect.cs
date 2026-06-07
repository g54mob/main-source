using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

			public bool preserveOriginalMesh
			{
				get
				{
					if (!isCombined)
					{
						return normalsOption == NormalsOption.PreserveOriginal;
					}
					return false;
				}
			}

			public void Init()
			{
				render = false;
				transform = null;
				mesh = (originalMesh = null);
				if (bakedSkinnedMesh != null)
				{
					UnityEngine.Object.DestroyImmediate(bakedSkinnedMesh);
				}
				renderer = null;
				isSkinnedMesh = false;
				normalsOption = NormalsOption.Smooth;
				isCombined = false;
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
			public float checkLastTime = -10000f;

			public int occlusionRenderFrame;

			public bool lastOcclusionTestResult;

			public readonly List<Renderer> cachedOccluders = new List<Renderer>();

			public Collider cachedOccluderCollider;
		}

		[Tooltip("The current profile (optional). A profile let you store Highlight Plus settings and apply those settings easily to many objects. You can also load a profile and apply its settings at runtime, using the ProfileLoad() method of the Highlight Effect component.")]
		public HighlightProfile profile;

		[Tooltip("If enabled, settings from the profile will be applied to this component automatically when game starts or when any profile setting is updated.")]
		public bool profileSync;

		[Tooltip("Which cameras can render the effect.")]
		public LayerMask camerasLayerMask = -1;

		[Tooltip("Different options to specify which objects are affected by this Highlight Effect component.")]
		public TargetOptions effectGroup;

		[Tooltip("The target object to highlight.")]
		public Transform effectTarget;

		[Tooltip("The layer that contains the affected objects by this effect when effectGroup is set to LayerMask.")]
		public LayerMask effectGroupLayer = -1;

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
		public bool cullBackFaces = true;

		[Tooltip("Adds a empty margin between the mesh and the effects")]
		public float padding;

		[Tooltip("Show highlight effects even if the object is not visible. If this object or its children use GPU Instancing tools, the MeshRenderer can be disabled although the object is visible. In this case, this option is useful to enable highlighting.")]
		public bool ignoreObjectVisibility;

		[Tooltip("Support reflection probes. Enable only if you want the effects to be visible in reflections.")]
		public bool reflectionProbes;

		[Tooltip("Enables GPU instancing. Reduces draw calls in outline and outer glow effects on platforms that support GPU instancing. Should be enabled by default.")]
		public bool GPUInstancing = true;

		[Tooltip("Custom sorting priority for the highlight effect (useful to control which effects render on top of others")]
		public int sortingPriority;

		[Tooltip("Bakes skinned mesh to leverage GPU instancing when using outline/outer glow with mesh-based rendering. Reduces draw calls significantly on skinned meshes.")]
		public bool optimizeSkinnedMesh = true;

		[Tooltip("Enables depth buffer clipping. Only applies to outline or outer glow in High Quality mode.")]
		public bool depthClip;

		[Tooltip("Fades out effects based on distance to camera")]
		public bool cameraDistanceFade;

		[Tooltip("The closest distance particles can get to the camera before they fade from the camera’s view.")]
		public float cameraDistanceFadeNear;

		[Tooltip("The farthest distance particles can get away from the camera before they fade from the camera’s view.")]
		public float cameraDistanceFadeFar = 1000f;

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
		public bool constantWidth = true;

		[Tooltip("Increases the screen coverage for the outline/glow to avoid cuts when using cloth or vertex shader that transform mesh vertices")]
		public int extraCoveragePixels;

		[Tooltip("Minimum width when the constant width option is not used")]
		[Range(0f, 1f)]
		public float minimumWidth;

		[Tooltip("Mask to include or exclude certain submeshes. By default, all submeshes are included.")]
		public int subMeshMask = -1;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the overlay effect. A value of 0 disables the overlay completely.")]
		public float overlay;

		public OverlayMode overlayMode;

		[ColorUsage(true, true)]
		public Color overlayColor = Color.yellow;

		public float overlayAnimationSpeed = 1f;

		[Range(0f, 1f)]
		public float overlayMinIntensity = 0.5f;

		[Range(0f, 1f)]
		[Tooltip("Controls the blending or mix of the overlay color with the natural colors of the object.")]
		public float overlayBlending = 1f;

		[Tooltip("Optional overlay texture.")]
		public Texture2D overlayTexture;

		public TextureUVSpace overlayTextureUVSpace;

		public float overlayTextureScale = 1f;

		public Vector2 overlayTextureScrolling;

		public Visibility overlayVisibility;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the outline. A value of 0 disables the outline completely.")]
		public float outline = 1f;

		[ColorUsage(true, true)]
		public Color outlineColor = Color.black;

		public ColorStyle outlineColorStyle;

		[GradientUsage(true, ColorSpace.Linear)]
		public Gradient outlineGradient;

		public bool outlineGradientInLocalSpace;

		public float outlineWidth = 0.45f;

		[Range(1f, 3f)]
		public int outlineBlurPasses = 2;

		public QualityLevel outlineQuality = QualityLevel.Medium;

		public OutlineEdgeMode outlineEdgeMode;

		public float outlineEdgeThreshold = 0.995f;

		public float outlineSharpness = 1f;

		[Range(1f, 8f)]
		[Tooltip("Reduces the quality of the outline but improves performance a bit.")]
		public int outlineDownsampling = 1;

		public Visibility outlineVisibility;

		public GlowBlendMode glowBlendMode;

		public bool outlineBlitDebug;

		[Tooltip("If enabled, this object won't combine the outline with other objects.")]
		public bool outlineIndependent;

		public ContourStyle outlineContourStyle;

		[Tooltip("Select the mask mode used with this effect.")]
		public MaskMode outlineMaskMode;

		[Range(0f, 5f)]
		[Tooltip("The intensity of the outer glow effect. A value of 0 disables the glow completely.")]
		public float glow;

		public float glowWidth = 0.4f;

		public QualityLevel glowQuality = QualityLevel.Medium;

		public BlurMethod glowBlurMethod;

		[Range(1f, 8f)]
		[Tooltip("Reduces the quality of the glow but improves performance a bit.")]
		public int glowDownsampling = 2;

		[ColorUsage(true, true)]
		public Color glowHQColor = new Color(0.64f, 1f, 0f, 1f);

		[Tooltip("When enabled, outer glow renders with dithering. When disabled, glow appears as a solid color.")]
		[Range(0f, 1f)]
		public float glowDithering = 1f;

		public GlowDitheringStyle glowDitheringStyle;

		[Tooltip("Seed for the dithering effect")]
		public float glowMagicNumber1 = 0.75f;

		[Tooltip("Another seed for the dithering effect that combines with first seed to create different patterns")]
		public float glowMagicNumber2 = 0.5f;

		public float glowAnimationSpeed = 1f;

		public Visibility glowVisibility;

		public bool glowBlitDebug;

		[Tooltip("Blends glow passes one after another. If this option is disabled, glow passes won't overlap (in this case, make sure the glow pass 1 has a smaller offset than pass 2, etc.)")]
		public bool glowBlendPasses = true;

		[NonReorderable]
		public GlowPassData[] glowPasses;

		[Tooltip("Select the mask mode used with this effect.")]
		public MaskMode glowMaskMode;

		[Range(0f, 5f)]
		[Tooltip("The intensity of the inner glow effect. A value of 0 disables the glow completely.")]
		public float innerGlow;

		[Range(0f, 2f)]
		public float innerGlowWidth = 1f;

		[ColorUsage(true, true)]
		public Color innerGlowColor = Color.white;

		public InnerGlowBlendMode innerGlowBlendMode;

		public Visibility innerGlowVisibility;

		[Tooltip("Enables the targetFX effect. This effect draws an animated sprite over the object.")]
		public bool targetFX;

		public Texture2D targetFXTexture;

		[ColorUsage(true, true)]
		public Color targetFXColor = Color.white;

		public Transform targetFXCenter;

		public float targetFXRotationSpeed = 50f;

		public float targetFXInitialScale = 4f;

		public float targetFXEndScale = 1.5f;

		[Tooltip("Makes target scale relative to object renderer bounds")]
		public bool targetFXScaleToRenderBounds = true;

		[Tooltip("Enable to render a single target FX effect at the center of the enclosing bounds")]
		public bool targetFXUseEnclosingBounds;

		[Tooltip("Places target FX sprite at the bottom of the highlighted object.")]
		public bool targetFXAlignToGround;

		[Tooltip("Optional worlds space offset for the position of the targetFX effect")]
		public Vector3 targetFXOffset;

		[Tooltip("Fade out effect with altitude")]
		public float targetFXFadePower = 32f;

		public float targetFXGroundMaxDistance = 10f;

		public LayerMask targetFXGroundLayerMask = -1;

		public float targetFXTransitionDuration = 0.5f;

		[Tooltip("The duration of the effect. A value of 0 will keep the target sprite on screen while object is highlighted.")]
		public float targetFXStayDuration = 1.5f;

		public Visibility targetFXVisibility = Visibility.AlwaysOnTop;

		[Tooltip("Enables the iconFX effect. This effect draws an animated object over the object.")]
		public bool iconFX;

		public Mesh iconFXMesh;

		[ColorUsage(true, true)]
		public Color iconFXLightColor = Color.white;

		[ColorUsage(true, true)]
		public Color iconFXDarkColor = Color.gray;

		public Transform iconFXCenter;

		public float iconFXRotationSpeed = 50f;

		public IconAnimationOption iconFXAnimationOption;

		public float iconFXAnimationAmount = 0.1f;

		public float iconFXAnimationSpeed = 3f;

		public float iconFXScale = 1f;

		[Tooltip("Makes target scale relative to object renderer bounds.")]
		public bool iconFXScaleToRenderBounds;

		[Tooltip("Optional world space offset for the position of the iconFX effect")]
		public Vector3 iconFXOffset = new Vector3(0f, 1f, 0f);

		public float iconFXTransitionDuration = 0.5f;

		public float iconFXStayDuration = 1.5f;

		[Tooltip("See-through mode for this Highlight Effect component.")]
		public SeeThroughMode seeThrough = SeeThroughMode.Never;

		[Tooltip("This mask setting let you specify which objects will be considered as occluders and cause the see-through effect for this Highlight Effect component. For example, you assign your walls to a different layer and specify that layer here, so only walls and not other objects, like ground or ceiling, will trigger the see-through effect.")]
		public LayerMask seeThroughOccluderMask = -1;

		[Tooltip("A multiplier for the occluder volume size which can be used to reduce the actual size of occluders when Highlight Effect checks if they're occluding this object.")]
		[Range(0.01f, 0.6f)]
		public float seeThroughOccluderThreshold = 0.3f;

		[Tooltip("Uses stencil buffers to ensure pixel-accurate occlusion test. If this option is disabled, only physics raycasting is used to test for occlusion.")]
		public bool seeThroughOccluderMaskAccurate;

		[Tooltip("The interval of time between occlusion tests.")]
		public float seeThroughOccluderCheckInterval = 1f;

		[Tooltip("If enabled, occlusion test is performed for each children element. If disabled, the bounds of all children is combined and a single occlusion test is performed for the combined bounds.")]
		public bool seeThroughOccluderCheckIndividualObjects;

		[Tooltip("Shows the see-through effect only if the occluder if at this 'offset' distance from the object.")]
		public float seeThroughDepthOffset;

		[Tooltip("Hides the see-through effect if the occluder is further than this distance from the object (0 = infinite)")]
		public float seeThroughMaxDepth;

		[Range(0f, 5f)]
		public float seeThroughIntensity = 0.8f;

		[Range(0f, 1f)]
		public float seeThroughTintAlpha = 0.5f;

		[ColorUsage(true, true)]
		public Color seeThroughTintColor = Color.red;

		[Range(0f, 1f)]
		public float seeThroughNoise = 1f;

		[Range(0f, 1f)]
		public float seeThroughBorder;

		public Color seeThroughBorderColor = Color.black;

		[Tooltip("Only display the border instead of the full see-through effect.")]
		public bool seeThroughBorderOnly;

		public float seeThroughBorderWidth = 0.45f;

		[Tooltip("This option clears the stencil buffer after rendering the see-through effect which results in correct rendering order and supports other stencil-based effects that render afterwards.")]
		public bool seeThroughOrdered;

		[Tooltip("Optional see-through mask effect texture.")]
		public Texture2D seeThroughTexture;

		public TextureUVSpace seeThroughTextureUVSpace;

		public float seeThroughTextureScale = 1f;

		[Tooltip("The order by which children objects are rendered by the see-through effect")]
		public SeeThroughSortingMode seeThroughChildrenSortingMode;

		[SerializeField]
		[HideInInspector]
		private ModelMaterials[] rms;

		[SerializeField]
		[HideInInspector]
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

		private bool _isSelected;

		[NonSerialized]
		public bool spriteMode;

		[NonSerialized]
		public HighlightProfile previousSettings;

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

		[NonSerialized]
		public static List<HighlightEffect> effects = new List<HighlightEffect>();

		public static bool customSorting;

		[NonSerialized]
		public float sortingOffset;

		private bool useSmoothGlow;

		private bool useSmoothOutline;

		private bool useSmoothBlend;

		private bool useGPUInstancing;

		private bool usesReversedZBuffer;

		private bool usesSeeThrough;

		private readonly Dictionary<Camera, PerCameraOcclusionData> perCameraOcclusionData = new Dictionary<Camera, PerCameraOcclusionData>();

		private MaterialPropertyBlock glowPropertyBlock;

		private MaterialPropertyBlock outlinePropertyBlock;

		private static readonly List<Vector4> matDataDirection = new List<Vector4>();

		private static readonly List<Vector4> matDataGlow = new List<Vector4>();

		private static readonly List<Vector4> matDataColor = new List<Vector4>();

		private static Matrix4x4[] matrices;

		private int outlineOffsetsMin;

		private int outlineOffsetsMax;

		private int glowOffsetsMin;

		private int glowOffsetsMax;

		private static CombineInstance[] combineInstances;

		private bool maskRequired;

		private Texture2D outlineGradientTex;

		private Color[] outlineGradientColors;

		private bool shouldBakeSkinnedMesh;

		public static HighlightEffect lastHighlighted;

		public static HighlightEffect lastSelected;

		[NonSerialized]
		public string lastRegExError;

		private bool isInitialized;

		private RenderTargetIdentifier colorAttachmentBuffer;

		private RenderTargetIdentifier depthAttachmentBuffer;

		private readonly List<Renderer> tempRR = new List<Renderer>();

		private static List<Vector3> vertices;

		private static List<Vector3> normals;

		private static Vector3[] newNormals;

		private static int[] matches;

		private static readonly Dictionary<Vector3, int> vv = new Dictionary<Vector3, int>();

		private static readonly List<Material> rendererSharedMaterials = new List<Material>();

		private static readonly Dictionary<int, Mesh> smoothMeshes = new Dictionary<int, Mesh>();

		private static readonly Dictionary<int, Mesh> reorientedMeshes = new Dictionary<int, Mesh>();

		private static readonly Dictionary<int, Mesh> combinedMeshes = new Dictionary<int, Mesh>();

		private int combinedMeshesHashId;

		private static readonly Dictionary<Mesh, int> sharedMeshUsage = new Dictionary<Mesh, int>();

		private readonly List<Mesh> instancedMeshes = new List<Mesh>();

		private const int MAX_VERTEX_COUNT = 65535;

		public static bool useUnscaledTime;

		[Range(0f, 1f)]
		public float hitFxInitialIntensity;

		public HitFxMode hitFxMode;

		public float hitFxFadeOutDuration = 0.25f;

		[ColorUsage(true, true)]
		public Color hitFxColor = Color.white;

		public float hitFxRadius = 0.5f;

		private float hitInitialIntensity;

		private float hitStartTime;

		private float hitFadeOutDuration;

		private Color hitColor;

		private bool hitActive;

		private Vector3 hitPosition;

		private float hitRadius;

		private static readonly List<HighlightSeeThroughOccluder> occluders = new List<HighlightSeeThroughOccluder>();

		private static readonly Dictionary<Camera, int> occludersFrameCount = new Dictionary<Camera, int>();

		private static Material fxMatSeeThroughOccluder;

		private static Material fxMatDepthWrite;

		private static RaycastHit[] hits;

		private const int MAX_OCCLUDER_HITS = 50;

		private static RaycastHit[] occluderHits;

		public bool highlighted
		{
			get
			{
				return _highlighted;
			}
			set
			{
				SetHighlighted(value);
			}
		}

		public int includedObjectsCount => rmsCount;

		public Transform currentTarget
		{
			get
			{
				if (!(effectTarget != null))
				{
					return base.transform;
				}
				return effectTarget;
			}
		}

		public bool isSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				if (_isSelected == value)
				{
					return;
				}
				if (value)
				{
					if (this.OnObjectSelected != null)
					{
						this.OnObjectSelected(base.gameObject);
					}
				}
				else if (this.OnObjectUnSelected != null)
				{
					this.OnObjectUnSelected(base.gameObject);
				}
				_isSelected = value;
				if (_isSelected)
				{
					lastSelected = this;
				}
			}
		}

		public event OnObjectSelectionEvent OnObjectSelected;

		public event OnObjectSelectionEvent OnObjectUnSelected;

		public event OnObjectHighlightEvent OnObjectHighlightStart;

		public event OnObjectHighlightEvent OnObjectHighlightEnd;

		public event OnObjectHighlightStateEvent OnObjectHighlightStateChange;

		public event OnRendererHighlightEvent OnRendererHighlightStart;

		public event OnAnimateEvent OnTargetAnimates;

		public event OnAnimateEvent OnIconAnimates;

		public void RestorePreviousHighlightEffectSettings()
		{
			if (previousSettings != null)
			{
				previousSettings.Load(this);
			}
		}

		[RuntimeInitializeOnLoadMethod]
		private static void DomainReloadDisabledSupport()
		{
			lastHighlighted = (lastSelected = null);
			effects.RemoveAll((HighlightEffect i) => i == null);
		}

		private void OnEnable()
		{
			InitIfNeeded();
		}

		private void InitIfNeeded()
		{
			if (rms == null || !isInitialized || fxMatOutlineTemplate == null)
			{
				Init();
			}
			HighlightPlusRenderPassFeature.sortFrameCount = 0;
			if (!effects.Contains(this))
			{
				effects.Add(this);
			}
			UpdateVisibilityState();
		}

		private void Init()
		{
			lastOutlineVisibility = outlineVisibility;
			debugColor = new Color(1f, 0f, 0f, 0.5f);
			blackColor = new Color(0f, 0f, 0f, 0f);
			if (offsets == null || offsets.Length != 8)
			{
				offsets = new Vector4[8]
				{
					new Vector4(0f, 1f),
					new Vector4(1f, 0f),
					new Vector4(0f, -1f),
					new Vector4(-1f, 0f),
					new Vector4(-0.70711f, 0.70711f),
					new Vector4(0.70711f, 0.70711f),
					new Vector4(0.70711f, -0.70711f),
					new Vector4(-0.70711f, -0.70711f)
				};
			}
			if (corners == null || corners.Length != 8)
			{
				corners = new Vector4[8];
			}
			InitCommandBuffer();
			if (quadMesh == null)
			{
				BuildQuad();
			}
			if (cubeMesh == null)
			{
				BuildCube();
			}
			if (target == null)
			{
				target = currentTarget;
			}
			if (glowPasses == null || glowPasses.Length == 0)
			{
				glowPasses = new GlowPassData[4];
				glowPasses[0] = new GlowPassData
				{
					offset = 4f,
					alpha = 0.1f,
					color = new Color(0.64f, 1f, 0f, 1f)
				};
				glowPasses[1] = new GlowPassData
				{
					offset = 3f,
					alpha = 0.2f,
					color = new Color(0.64f, 1f, 0f, 1f)
				};
				glowPasses[2] = new GlowPassData
				{
					offset = 2f,
					alpha = 0.3f,
					color = new Color(0.64f, 1f, 0f, 1f)
				};
				glowPasses[3] = new GlowPassData
				{
					offset = 1f,
					alpha = 0.4f,
					color = new Color(0.64f, 1f, 0f, 1f)
				};
			}
			sourceRT = Shader.PropertyToID("_HPSourceRT");
			useGPUInstancing = GPUInstancing && SystemInfo.supportsInstancing;
			usesReversedZBuffer = SystemInfo.usesReversedZBuffer;
			if (useGPUInstancing)
			{
				if (glowPropertyBlock == null)
				{
					glowPropertyBlock = new MaterialPropertyBlock();
				}
				if (outlinePropertyBlock == null)
				{
					outlinePropertyBlock = new MaterialPropertyBlock();
				}
			}
			InitTemplateMaterials();
			if (profileSync && profile != null)
			{
				profile.Load(this);
			}
			isInitialized = true;
		}

		private void Start()
		{
			SetupMaterial();
		}

		public void OnDidApplyAnimationProperties()
		{
			UpdateMaterialProperties();
		}

		private void OnDisable()
		{
			UpdateMaterialProperties();
			RemoveEffect();
		}

		private void Reset()
		{
			SetupMaterial();
		}

		private void DestroyMaterial(Material mat)
		{
			if (mat != null)
			{
				UnityEngine.Object.DestroyImmediate(mat);
			}
		}

		private void DestroyMaterialArray(Material[] mm)
		{
			if (mm != null)
			{
				for (int i = 0; i < mm.Length; i++)
				{
					DestroyMaterial(mm[i]);
				}
			}
		}

		private void RemoveEffect()
		{
			effects.Remove(this);
		}

		private void OnDestroy()
		{
			RemoveEffect();
			if (rms != null)
			{
				for (int i = 0; i < rms.Length; i++)
				{
					DestroyMaterialArray(rms[i].fxMatMask);
					DestroyMaterialArray(rms[i].fxMatOutline);
					DestroyMaterialArray(rms[i].fxMatGlow);
					DestroyMaterialArray(rms[i].fxMatSolidColor);
					DestroyMaterialArray(rms[i].fxMatSeeThroughInner);
					DestroyMaterialArray(rms[i].fxMatSeeThroughBorder);
					DestroyMaterialArray(rms[i].fxMatOverlay);
					DestroyMaterialArray(rms[i].fxMatInnerGlow);
				}
			}
			DestroyMaterial(fxMatGlowTemplate);
			DestroyMaterial(fxMatInnerGlow);
			DestroyMaterial(fxMatOutlineTemplate);
			DestroyMaterial(fxMatTarget);
			DestroyMaterial(fxMatComposeGlow);
			DestroyMaterial(fxMatComposeOutline);
			DestroyMaterial(fxMatBlurGlow);
			DestroyMaterial(fxMatBlurOutline);
			DestroyMaterial(fxMatIcon);
			if (combinedMeshes.ContainsKey(combinedMeshesHashId))
			{
				combinedMeshes.Remove(combinedMeshesHashId);
			}
			foreach (Mesh instancedMesh in instancedMeshes)
			{
				if (!(instancedMesh == null) && sharedMeshUsage.TryGetValue(instancedMesh, out var value))
				{
					if (value <= 1)
					{
						sharedMeshUsage.Remove(instancedMesh);
						UnityEngine.Object.DestroyImmediate(instancedMesh);
					}
					else
					{
						sharedMeshUsage[instancedMesh] = value - 1;
					}
				}
			}
		}

		private void OnBecameVisible()
		{
			isVisible = true;
		}

		private void OnBecameInvisible()
		{
			if (rms == null || rms.Length != 1 || rms[0].transform != base.transform)
			{
				isVisible = true;
			}
			else
			{
				isVisible = false;
			}
		}

		public void ProfileLoad(HighlightProfile profile)
		{
			if (profile != null)
			{
				this.profile = profile;
				profile.Load(this);
			}
		}

		public void ProfileReload()
		{
			if (profile != null)
			{
				profile.Load(this);
			}
		}

		public void ProfileSaveChanges(HighlightProfile profile)
		{
			if (profile != null)
			{
				profile.Save(this);
			}
		}

		public void ProfileSaveChanges()
		{
			if (profile != null)
			{
				profile.Save(this);
			}
		}

		public void Refresh(bool discardCachedMeshes = false)
		{
			if (discardCachedMeshes)
			{
				RefreshCachedMeshes();
			}
			InitIfNeeded();
			if (base.enabled)
			{
				SetupMaterial();
			}
		}

		public void ResetHighlightStartTime()
		{
			highlightStartTime = (targetFXStartTime = (iconFXStartTime = GetTime()));
		}

		public void SetCommandBuffer(CommandBuffer cmd)
		{
			cbHighlight = cmd;
			cbHighlightEmpty = false;
		}

		public CommandBuffer BuildCommandBuffer(Camera cam, RenderTargetIdentifier colorAttachmentBuffer, RenderTargetIdentifier depthAttachmentBuffer, bool clearStencil, ref RenderTextureDescriptor sourceDesc)
		{
			this.colorAttachmentBuffer = colorAttachmentBuffer;
			this.depthAttachmentBuffer = depthAttachmentBuffer;
			this.sourceDesc = sourceDesc;
			BuildCommandBuffer(cam, clearStencil);
			if (!cbHighlightEmpty)
			{
				return cbHighlight;
			}
			return null;
		}

		private void BuildCommandBuffer(Camera cam, bool clearStencil)
		{
			if (colorAttachmentBuffer == 0)
			{
				colorAttachmentBuffer = BuiltinRenderTextureType.CameraTarget;
			}
			if (depthAttachmentBuffer == 0)
			{
				depthAttachmentBuffer = BuiltinRenderTextureType.CameraTarget;
			}
			InitCommandBuffer();
			if (requireUpdateMaterial)
			{
				requireUpdateMaterial = false;
				UpdateMaterialProperties();
			}
			bool flag = true;
			if (clearStencil)
			{
				ConfigureOutput();
				cbHighlight.DrawMesh(quadMesh, Matrix4x4.identity, fxMatClearStencil, 0, 0);
				flag = false;
			}
			bool flag2 = usesSeeThrough;
			if (flag2)
			{
				ConfigureOutput();
				flag2 = RenderSeeThroughOccluders(cbHighlight, cam);
				if (flag2 && (int)seeThroughOccluderMask != -1)
				{
					if (seeThroughOccluderMaskAccurate)
					{
						CheckOcclusionAccurate(cbHighlight, cam);
					}
					else
					{
						flag2 = CheckOcclusion(cam);
					}
				}
			}
			bool flag3 = hitActive || overlayMode == OverlayMode.Always;
			if (!_highlighted && !flag2 && !flag3)
			{
				return;
			}
			ConfigureOutput();
			if (rms == null)
			{
				SetupMaterial();
				if (rms == null)
				{
					return;
				}
			}
			int cullingMask = cam.cullingMask;
			if (!ignoreObjectVisibility)
			{
				for (int i = 0; i < rmsCount; i++)
				{
					if (rms[i].renderer != null && rms[i].renderer.isVisible != rms[i].renderWasVisibleDuringSetup)
					{
						SetupMaterial();
						break;
					}
				}
			}
			float num = (_highlighted ? glow : 0f);
			if (fxMatMask == null)
			{
				return;
			}
			float time = GetTime();
			Visibility visibility = glowVisibility;
			Visibility visibility2 = outlineVisibility;
			float aspect = cam.aspect;
			bool flag4 = false;
			for (int j = 0; j < rmsCount; j++)
			{
				rms[j].render = false;
				Transform transform = rms[j].transform;
				if (transform == null)
				{
					continue;
				}
				if (rms[j].isSkinnedMesh && shouldBakeSkinnedMesh)
				{
					SkinnedMeshRenderer obj = (SkinnedMeshRenderer)rms[j].renderer;
					if (rms[j].bakedSkinnedMesh == null)
					{
						rms[j].bakedSkinnedMesh = new Mesh();
					}
					obj.BakeMesh(rms[j].bakedSkinnedMesh, useScale: true);
					rms[j].mesh = rms[j].bakedSkinnedMesh;
					rms[j].normalsOption = NormalsOption.Smooth;
				}
				Mesh mesh = rms[j].mesh;
				if (mesh == null)
				{
					continue;
				}
				if (!ignoreObjectVisibility)
				{
					int layer = transform.gameObject.layer;
					if (((1 << layer) & cullingMask) == 0 || !rms[j].renderer.isVisible)
					{
						continue;
					}
				}
				rms[j].render = true;
				flag4 = true;
				if (rms[j].isCombined)
				{
					rms[j].renderingMatrix = transform.localToWorldMatrix;
				}
				if (!outlineIndependent)
				{
					continue;
				}
				if (useSmoothBlend)
				{
					if (flag)
					{
						flag = false;
						cbHighlight.DrawMesh(quadMesh, Matrix4x4.identity, fxMatClearStencil, 0, 0);
					}
				}
				else
				{
					if (!(outline > 0f) && !(glow > 0f))
					{
						continue;
					}
					bool flag5 = useGPUInstancing && (shouldBakeSkinnedMesh || !rms[j].isSkinnedMesh);
					float num2 = outlineWidth;
					if (glow > 0f)
					{
						num2 = Mathf.Max(num2, glowWidth);
					}
					for (int k = 0; k < mesh.subMeshCount; k++)
					{
						if (((1 << k) & subMeshMask) == 0)
						{
							continue;
						}
						if (outlineQuality.UsesMultipleOffsets())
						{
							matDataDirection.Clear();
							for (int l = outlineOffsetsMin; l <= outlineOffsetsMax; l++)
							{
								Vector4 vector = offsets[l] * (num2 / 100f);
								vector.y *= aspect;
								if (flag5)
								{
									matDataDirection.Add(vector);
									continue;
								}
								cbHighlight.SetGlobalVector(ShaderParams.OutlineDirection, vector);
								if (rms[j].isCombined)
								{
									cbHighlight.DrawMesh(rms[j].mesh, rms[j].renderingMatrix, rms[j].fxMatOutline[k], k, 1);
								}
								else
								{
									cbHighlight.DrawRenderer(rms[j].renderer, rms[j].fxMatOutline[k], k, 1);
								}
							}
							if (!flag5)
							{
								continue;
							}
							int count = matDataDirection.Count;
							if (count <= 0)
							{
								continue;
							}
							outlinePropertyBlock.Clear();
							outlinePropertyBlock.SetVectorArray(ShaderParams.OutlineDirection, matDataDirection);
							if (matrices == null || matrices.Length < count)
							{
								matrices = new Matrix4x4[count];
							}
							if (rms[j].isCombined)
							{
								for (int m = 0; m < count; m++)
								{
									matrices[m] = rms[j].renderingMatrix;
								}
							}
							else
							{
								Matrix4x4 localToWorldMatrix = rms[j].transform.localToWorldMatrix;
								for (int n = 0; n < count; n++)
								{
									matrices[n] = localToWorldMatrix;
								}
							}
							cbHighlight.DrawMeshInstanced(mesh, k, rms[j].fxMatOutline[k], 1, matrices, count, outlinePropertyBlock);
						}
						else
						{
							cbHighlight.SetGlobalVector(ShaderParams.OutlineDirection, Vector4.zero);
							if (rms[j].isCombined)
							{
								cbHighlight.DrawMesh(rms[j].mesh, rms[j].renderingMatrix, rms[j].fxMatOutline[k], k, 1);
							}
							else
							{
								cbHighlight.DrawRenderer(rms[j].renderer, rms[j].fxMatOutline[k], k, 1);
							}
						}
					}
				}
			}
			bool flag6 = _highlighted && ((outline > 0f && visibility2 != Visibility.Normal) || (glow > 0f && visibility != Visibility.Normal) || (innerGlow > 0f && innerGlowVisibility != Visibility.Normal));
			flag6 |= useSmoothBlend && outlineContourStyle == ContourStyle.AroundObjectShape;
			if (maskRequired)
			{
				for (int num3 = 0; num3 < rmsCount; num3++)
				{
					if (rms[num3].render)
					{
						RenderMask(num3, rms[num3].mesh, flag6);
					}
				}
			}
			float num4 = 1f;
			float num5 = 1f;
			if (fading != FadingState.NoFading)
			{
				if (fading == FadingState.FadingIn)
				{
					if (fadeInDuration > 0f)
					{
						num4 = (time - fadeStartTime) / fadeInDuration;
						if (num4 > 1f)
						{
							num4 = 1f;
							fading = FadingState.NoFading;
						}
					}
				}
				else if (fadeOutDuration > 0f)
				{
					num4 = 1f - (time - fadeStartTime) / fadeOutDuration;
					if (num4 < 0f)
					{
						num4 = 0f;
						fading = FadingState.NoFading;
						_highlighted = false;
						requireUpdateMaterial = true;
						if (this.OnObjectHighlightEnd != null)
						{
							this.OnObjectHighlightEnd(base.gameObject);
						}
						SendMessage("HighlightEnd", null, SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			if (glowQuality == QualityLevel.High)
			{
				num *= 0.25f;
			}
			else if (glowQuality == QualityLevel.Medium)
			{
				num *= 0.5f;
			}
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = seeThroughBorder * seeThroughBorderWidth > 0f;
			Bounds bounds = default(Bounds);
			if (useSmoothBlend || (targetFX && targetFXUseEnclosingBounds) || iconFX)
			{
				for (int num6 = 0; num6 < rmsCount; num6++)
				{
					if (rms[num6].render)
					{
						if (num6 == 0)
						{
							bounds = rms[num6].renderer.bounds;
						}
						else
						{
							bounds.Encapsulate(rms[num6].renderer.bounds);
						}
					}
				}
			}
			for (int num7 = 0; num7 < rmsCount; num7++)
			{
				if (!rms[num7].render)
				{
					continue;
				}
				Mesh mesh2 = rms[num7].mesh;
				num5 = num4;
				if (cameraDistanceFade)
				{
					num5 *= ComputeCameraDistanceFade(rms[num7].transform.position, cam.transform);
				}
				cbHighlight.SetGlobalFloat(ShaderParams.FadeFactor, num5);
				if (_highlighted || flag3)
				{
					Color color = overlayColor;
					float y = overlayMinIntensity;
					float z = overlayBlending;
					Color value = innerGlowColor;
					float num8 = innerGlow;
					if (hitActive)
					{
						color.a = (_highlighted ? overlay : 0f);
						value.a = (_highlighted ? num8 : 0f);
						float num9 = ((hitFadeOutDuration > 0f) ? ((time - hitStartTime) / hitFadeOutDuration) : 1f);
						if (num9 >= 1f)
						{
							hitActive = false;
						}
						else if (hitFxMode == HitFxMode.InnerGlow)
						{
							bool flag10 = _highlighted && num8 > 0f;
							value = (flag10 ? Color.Lerp(hitColor, innerGlowColor, num9) : hitColor);
							value.a = (flag10 ? Mathf.Lerp(1f - num9, num8, num9) : (1f - num9));
							value.a *= hitInitialIntensity;
						}
						else
						{
							bool flag11 = _highlighted && overlay > 0f;
							color = (flag11 ? Color.Lerp(hitColor, color, num9) : hitColor);
							color.a = (flag11 ? Mathf.Lerp(1f - num9, overlay, num9) : (1f - num9));
							color.a *= hitInitialIntensity;
							y = 1f;
							z = 0f;
						}
					}
					else
					{
						color.a = overlay * num5;
						value.a = num8 * num5;
					}
					for (int num10 = 0; num10 < mesh2.subMeshCount; num10++)
					{
						if (((1 << num10) & subMeshMask) == 0)
						{
							continue;
						}
						if (color.a > 0f)
						{
							Material material = rms[num7].fxMatOverlay[num10];
							material.SetColor(ShaderParams.OverlayColor, color);
							material.SetVector(ShaderParams.OverlayData, new Vector4(overlayAnimationSpeed, y, z, overlayTextureScale));
							if (hitActive && hitFxMode == HitFxMode.LocalHit)
							{
								material.SetVector(ShaderParams.OverlayHitPosData, new Vector4(hitPosition.x, hitPosition.y, hitPosition.z, hitRadius));
								material.SetFloat(ShaderParams.OverlayHitStartTime, hitStartTime);
							}
							else
							{
								material.SetVector(ShaderParams.OverlayHitPosData, Vector4.zero);
							}
							if (rms[num7].isCombined)
							{
								cbHighlight.DrawMesh(mesh2, rms[num7].renderingMatrix, rms[num7].fxMatOverlay[num10], num10);
							}
							else
							{
								cbHighlight.DrawRenderer(rms[num7].renderer, rms[num7].fxMatOverlay[num10], num10);
							}
						}
						if (value.a > 0f)
						{
							rms[num7].fxMatInnerGlow[num10].SetColor(ShaderParams.InnerGlowColor, value);
							if (rms[num7].isCombined)
							{
								cbHighlight.DrawMesh(rms[num7].mesh, rms[num7].renderingMatrix, rms[num7].fxMatInnerGlow[num10], num10);
							}
							else
							{
								cbHighlight.DrawRenderer(rms[num7].renderer, rms[num7].fxMatInnerGlow[num10], num10);
							}
						}
					}
				}
				if (!_highlighted)
				{
					continue;
				}
				bool flag12 = useGPUInstancing && (shouldBakeSkinnedMesh || !rms[num7].isSkinnedMesh);
				for (int num11 = 0; num11 < mesh2.subMeshCount; num11++)
				{
					if (((1 << num11) & subMeshMask) == 0)
					{
						continue;
					}
					if (glow > 0f && glowQuality != QualityLevel.Highest)
					{
						matDataGlow.Clear();
						matDataColor.Clear();
						matDataDirection.Clear();
						for (int num12 = 0; num12 < glowPasses.Length; num12++)
						{
							if (glowQuality.UsesMultipleOffsets())
							{
								for (int num13 = glowOffsetsMin; num13 <= glowOffsetsMax; num13++)
								{
									Vector4 vector2 = offsets[num13];
									vector2.y *= aspect;
									Color color2 = glowPasses[num12].color;
									Vector4 vector3 = new Vector4(num5 * num * glowPasses[num12].alpha, glowPasses[num12].offset * glowWidth / 100f, glowMagicNumber1, glowMagicNumber2);
									if (flag12)
									{
										matDataDirection.Add(vector2);
										matDataGlow.Add(vector3);
										matDataColor.Add(new Vector4(color2.r, color2.g, color2.b, color2.a));
										continue;
									}
									cbHighlight.SetGlobalVector(ShaderParams.GlowDirection, vector2);
									cbHighlight.SetGlobalColor(ShaderParams.GlowColor, color2);
									cbHighlight.SetGlobalVector(ShaderParams.Glow, vector3);
									if (rms[num7].isCombined)
									{
										cbHighlight.DrawMesh(mesh2, rms[num7].renderingMatrix, rms[num7].fxMatGlow[num11], num11);
									}
									else
									{
										cbHighlight.DrawRenderer(rms[num7].renderer, rms[num7].fxMatGlow[num11], num11);
									}
								}
								continue;
							}
							Vector4 vector4 = new Vector4(num5 * num * glowPasses[num12].alpha, glowPasses[num12].offset * glowWidth / 100f, glowMagicNumber1, glowMagicNumber2);
							Color color3 = glowPasses[num12].color;
							if (flag12)
							{
								matDataDirection.Add(Vector4.zero);
								matDataGlow.Add(vector4);
								matDataColor.Add(new Vector4(color3.r, color3.g, color3.b, color3.a));
								continue;
							}
							cbHighlight.SetGlobalColor(ShaderParams.GlowColor, color3);
							cbHighlight.SetGlobalVector(ShaderParams.Glow, vector4);
							cbHighlight.SetGlobalVector(ShaderParams.GlowDirection, Vector4.zero);
							if (rms[num7].isCombined)
							{
								cbHighlight.DrawMesh(mesh2, rms[num7].renderingMatrix, rms[num7].fxMatGlow[num11], num11);
							}
							else
							{
								cbHighlight.DrawRenderer(rms[num7].renderer, rms[num7].fxMatGlow[num11], num11);
							}
						}
						if (flag12)
						{
							int count2 = matDataDirection.Count;
							if (count2 > 0)
							{
								glowPropertyBlock.Clear();
								glowPropertyBlock.SetVectorArray(ShaderParams.GlowDirection, matDataDirection);
								glowPropertyBlock.SetVectorArray(ShaderParams.GlowColor, matDataColor);
								glowPropertyBlock.SetVectorArray(ShaderParams.Glow, matDataGlow);
								if (matrices == null || matrices.Length < count2)
								{
									matrices = new Matrix4x4[count2];
								}
								if (rms[num7].isCombined)
								{
									for (int num14 = 0; num14 < count2; num14++)
									{
										matrices[num14] = rms[num7].renderingMatrix;
									}
								}
								else
								{
									Matrix4x4 localToWorldMatrix2 = rms[num7].transform.localToWorldMatrix;
									for (int num15 = 0; num15 < count2; num15++)
									{
										matrices[num15] = localToWorldMatrix2;
									}
								}
								cbHighlight.DrawMeshInstanced(mesh2, num11, rms[num7].fxMatGlow[num11], 0, matrices, count2, glowPropertyBlock);
							}
						}
					}
					if (!(outline > 0f) || outlineQuality == QualityLevel.Highest)
					{
						continue;
					}
					Color value2 = outlineColor;
					if (outlineColorStyle == ColorStyle.Gradient)
					{
						value2.a *= outline * num5;
						Bounds bounds2 = (outlineGradientInLocalSpace ? mesh2.bounds : rms[num7].renderer.bounds);
						cbHighlight.SetGlobalVector(ShaderParams.OutlineVertexData, new Vector4(bounds2.min.y, bounds2.size.y + 0.0001f, 0f, 0f));
					}
					else
					{
						value2.a = outline * num5;
						cbHighlight.SetGlobalVector(ShaderParams.OutlineVertexData, new Vector4(-1000000f, 1f, 0f, 0f));
					}
					cbHighlight.SetGlobalColor(ShaderParams.OutlineColor, value2);
					if (outlineQuality.UsesMultipleOffsets())
					{
						matDataDirection.Clear();
						for (int num16 = outlineOffsetsMin; num16 <= outlineOffsetsMax; num16++)
						{
							Vector4 vector5 = offsets[num16] * (outlineWidth / 100f);
							vector5.y *= aspect;
							if (flag12)
							{
								matDataDirection.Add(vector5);
								continue;
							}
							cbHighlight.SetGlobalVector(ShaderParams.OutlineDirection, vector5);
							if (rms[num7].isCombined)
							{
								cbHighlight.DrawMesh(mesh2, rms[num7].renderingMatrix, rms[num7].fxMatOutline[num11], num11, 0);
							}
							else
							{
								cbHighlight.DrawRenderer(rms[num7].renderer, rms[num7].fxMatOutline[num11], num11, 0);
							}
						}
						if (!flag12)
						{
							continue;
						}
						int count3 = matDataDirection.Count;
						if (count3 <= 0)
						{
							continue;
						}
						outlinePropertyBlock.Clear();
						outlinePropertyBlock.SetVectorArray(ShaderParams.OutlineDirection, matDataDirection);
						if (matrices == null || matrices.Length < count3)
						{
							matrices = new Matrix4x4[count3];
						}
						if (rms[num7].isCombined)
						{
							for (int num17 = 0; num17 < count3; num17++)
							{
								matrices[num17] = rms[num7].renderingMatrix;
							}
						}
						else
						{
							Matrix4x4 localToWorldMatrix3 = rms[num7].transform.localToWorldMatrix;
							for (int num18 = 0; num18 < count3; num18++)
							{
								matrices[num18] = localToWorldMatrix3;
							}
						}
						cbHighlight.DrawMeshInstanced(mesh2, num11, rms[num7].fxMatOutline[num11], 0, matrices, count3, outlinePropertyBlock);
					}
					else
					{
						cbHighlight.SetGlobalColor(ShaderParams.OutlineColor, value2);
						cbHighlight.SetGlobalVector(ShaderParams.OutlineDirection, Vector4.zero);
						if (rms[num7].isSkinnedMesh)
						{
							cbHighlight.DrawRenderer(rms[num7].renderer, rms[num7].fxMatOutline[num11], num11, 0);
						}
						else
						{
							cbHighlight.DrawMesh(mesh2, rms[num7].transform.localToWorldMatrix, rms[num7].fxMatOutline[num11], num11, 0);
						}
					}
				}
				if (targetFX)
				{
					float num19 = 1f;
					if (targetFXStayDuration > 0f && Application.isPlaying)
					{
						num19 = time - targetFXStartTime;
						if (num19 >= targetFXStayDuration)
						{
							num19 -= targetFXStayDuration;
							num19 = 1f - num19;
						}
						if (num19 > 1f)
						{
							num19 = 1f;
						}
					}
					bool flag13 = targetFXCenter != null;
					if (num19 > 0f && (!flag7 || (!flag13 && !targetFXUseEnclosingBounds)))
					{
						flag7 = true;
						float t = 1f;
						float num20 = 0f;
						float num21;
						if (Application.isPlaying)
						{
							num20 = (time - targetFXStartTime) / targetFXTransitionDuration;
							if (num20 > 1f)
							{
								num20 = 1f;
							}
							t = Mathf.Sin(num20 * MathF.PI * 0.5f);
							num21 = time;
						}
						else
						{
							num21 = (float)DateTime.Now.Subtract(DateTime.Today).TotalSeconds;
						}
						Bounds bounds3 = (targetFXUseEnclosingBounds ? bounds : rms[num7].renderer.bounds);
						if (!targetFXScaleToRenderBounds)
						{
							bounds3.size = Vector3.one;
						}
						Vector3 size = bounds3.size;
						float num22 = size.x;
						if (size.y < num22)
						{
							num22 = size.y;
						}
						if (size.z < num22)
						{
							num22 = size.z;
						}
						size.x = (size.y = (size.z = num22));
						size = Vector3.Lerp(size * targetFXInitialScale, size * targetFXEndScale, t);
						Vector3 center = (flag13 ? targetFXCenter.position : bounds3.center);
						center += targetFXOffset;
						if (targetFXAlignToGround)
						{
							Quaternion quaternion = Quaternion.Euler(90f, 0f, 0f);
							center.y += 0.5f;
							alignToGroundTried = true;
							alignToGroundHitGood = Physics.Raycast(center, Vector3.down, out var hitInfo, targetFXGroundMaxDistance, targetFXGroundLayerMask);
							if (alignToGroundHitGood)
							{
								center = hitInfo.point;
								center.y += 0.01f;
								Vector4 value3 = hitInfo.normal;
								value3.w = targetFXFadePower;
								fxMatTarget.SetVector(ShaderParams.TargetFXRenderData, value3);
								quaternion = Quaternion.Euler(0f, num21 * targetFXRotationSpeed, 0f);
								if (this.OnTargetAnimates != null)
								{
									this.OnTargetAnimates(ref center, ref quaternion, ref size, num20);
								}
								Matrix4x4 matrix = Matrix4x4.TRS(center, quaternion, size);
								Color color4 = targetFXColor;
								color4.a *= num5 * num19;
								fxMatTarget.color = color4;
								cbHighlight.DrawMesh(cubeMesh, matrix, fxMatTarget, 0, 0);
							}
						}
						else
						{
							alignToGroundTried = false;
							Quaternion quaternion = Quaternion.LookRotation(cam.transform.position - rms[num7].transform.position);
							Quaternion quaternion2 = Quaternion.Euler(0f, 0f, num21 * targetFXRotationSpeed);
							quaternion *= quaternion2;
							if (this.OnTargetAnimates != null)
							{
								this.OnTargetAnimates(ref center, ref quaternion, ref size, num20);
							}
							Matrix4x4 matrix2 = Matrix4x4.TRS(center, quaternion, size);
							Color color5 = targetFXColor;
							color5.a *= num5 * num19;
							fxMatTarget.color = color5;
							cbHighlight.DrawMesh(quadMesh, matrix2, fxMatTarget, 0, 1);
						}
					}
				}
				if (!iconFX)
				{
					continue;
				}
				float num23 = 1f;
				if (iconFXStayDuration > 0f && Application.isPlaying)
				{
					num23 = time - iconFXStartTime;
					if (num23 >= iconFXStayDuration)
					{
						num23 -= iconFXStayDuration;
						num23 = 1f - num23;
					}
					if (num23 > 1f)
					{
						num23 = 1f;
					}
				}
				bool flag14 = iconFXCenter != null;
				if (!(num23 > 0f) || (flag8 && flag14))
				{
					continue;
				}
				flag8 = true;
				float num24 = 0f;
				float num25;
				if (Application.isPlaying)
				{
					num25 = time;
					num24 = (num25 - iconFXStartTime) / iconFXTransitionDuration;
					if (num24 > 1f)
					{
						num24 = 1f;
					}
					Mathf.Sin(num24 * MathF.PI * 0.5f);
				}
				else
				{
					num25 = (float)DateTime.Now.Subtract(DateTime.Today).TotalSeconds;
				}
				Bounds bounds4 = bounds;
				if (!iconFXScaleToRenderBounds)
				{
					bounds4.size = Vector3.one;
				}
				Vector3 scale = bounds4.size * iconFXScale;
				Vector3 center2 = (flag14 ? iconFXCenter.position : bounds4.center);
				center2 += iconFXOffset;
				if (iconFXAnimationOption == IconAnimationOption.VerticalBounce)
				{
					center2.y += iconFXAnimationAmount * Mathf.Abs(Mathf.Sin((time - iconFXStartTime) * iconFXAnimationSpeed));
				}
				Quaternion rotation = Quaternion.Euler(0f, num25 * iconFXRotationSpeed, 0f);
				if (this.OnIconAnimates != null)
				{
					this.OnIconAnimates(ref center2, ref rotation, ref scale, num24);
				}
				Matrix4x4 matrix3 = Matrix4x4.TRS(center2, rotation, scale);
				Color color6 = iconFXLightColor;
				color6.a *= num5 * num23;
				Color value4 = iconFXDarkColor;
				value4.a *= num5 * num23;
				Material material2 = fxMatIcon;
				material2.color = color6;
				material2.SetColor(ShaderParams.IconFXDarkColor, value4);
				cbHighlight.DrawMesh(iconFXMesh, matrix3, material2);
			}
			if (useSmoothBlend && _highlighted && flag4)
			{
				sourceDesc.colorFormat = ((!useSmoothOutline || outlineEdgeMode != OutlineEdgeMode.Any) ? RenderTextureFormat.R8 : RenderTextureFormat.ARGB32);
				sourceDesc.msaaSamples = 1;
				sourceDesc.useMipMap = false;
				sourceDesc.depthBufferBits = 0;
				int width = sourceDesc.width;
				int height = sourceDesc.height;
				cbHighlight.GetTemporaryRT(sourceRT, sourceDesc, FilterMode.Bilinear);
				RenderTargetIdentifier renderTarget = new RenderTargetIdentifier(sourceRT, 0, CubemapFace.Unknown, -1);
				cbHighlight.SetRenderTarget(renderTarget);
				cbHighlight.ClearRenderTarget(clearDepth: false, clearColor: true, new Color(0f, 0f, 0f, 0f));
				for (int num26 = 0; num26 < rmsCount; num26++)
				{
					if (!rms[num26].render)
					{
						continue;
					}
					Mesh mesh3 = rms[num26].mesh;
					for (int num27 = 0; num27 < mesh3.subMeshCount; num27++)
					{
						if (((1 << num27) & subMeshMask) != 0 && num27 < rms[num26].fxMatSolidColor.Length)
						{
							if (rms[num26].isCombined)
							{
								cbHighlight.DrawMesh(rms[num26].mesh, rms[num26].renderingMatrix, rms[num26].fxMatSolidColor[num27], num27);
							}
							else
							{
								cbHighlight.DrawRenderer(rms[num26].renderer, rms[num26].fxMatSolidColor[num27], num27);
							}
						}
					}
				}
				if (ComputeSmoothQuadMatrix(cam, bounds))
				{
					if (useSmoothGlow)
					{
						float num28 = glow * num5;
						fxMatComposeGlow.color = new Color(glowHQColor.r * num28, glowHQColor.g * num28, glowHQColor.b * num28, glowHQColor.a * num28);
						SmoothGlow(width / glowDownsampling, height / glowDownsampling);
					}
					if (useSmoothOutline)
					{
						float num29 = outline * num5;
						fxMatComposeOutline.color = new Color(outlineColor.r, outlineColor.g, outlineColor.b, outlineColor.a * num29 * 10f);
						SmoothOutline(width / outlineDownsampling, height / outlineDownsampling);
					}
					ComposeSmoothBlend(visibility, visibility2);
				}
			}
			if (!flag2)
			{
				return;
			}
			if (flag6)
			{
				for (int num30 = 0; num30 < rmsCount; num30++)
				{
					if (rms[num30].render)
					{
						Mesh mesh4 = rms[num30].mesh;
						RenderSeeThroughClearStencil(num30, mesh4);
					}
				}
				for (int num31 = 0; num31 < rmsCount; num31++)
				{
					if (rms[num31].render)
					{
						Mesh mesh5 = rms[num31].mesh;
						RenderSeeThroughMask(num31, mesh5);
					}
				}
			}
			for (int num32 = 0; num32 < rmsCount; num32++)
			{
				if (!rms[num32].render)
				{
					continue;
				}
				Mesh mesh6 = rms[num32].mesh;
				for (int num33 = 0; num33 < mesh6.subMeshCount; num33++)
				{
					if (((1 << num33) & subMeshMask) != 0 && num33 < rms[num32].fxMatSeeThroughInner.Length && rms[num32].fxMatSeeThroughInner[num33] != null)
					{
						if (rms[num32].isCombined)
						{
							cbHighlight.DrawMesh(mesh6, rms[num32].renderingMatrix, rms[num32].fxMatSeeThroughInner[num33], num33);
						}
						else
						{
							cbHighlight.DrawRenderer(rms[num32].renderer, rms[num32].fxMatSeeThroughInner[num33], num33);
						}
					}
				}
			}
			if (flag9)
			{
				for (int num34 = 0; num34 < rmsCount; num34++)
				{
					if (!rms[num34].render)
					{
						continue;
					}
					Mesh mesh7 = rms[num34].mesh;
					for (int num35 = 0; num35 < mesh7.subMeshCount; num35++)
					{
						if (((1 << num35) & subMeshMask) != 0)
						{
							if (rms[num34].isCombined)
							{
								cbHighlight.DrawMesh(mesh7, rms[num34].renderingMatrix, rms[num34].fxMatSeeThroughBorder[num35], num35);
							}
							else
							{
								cbHighlight.DrawRenderer(rms[num34].renderer, rms[num34].fxMatSeeThroughBorder[num35], num35);
							}
						}
					}
				}
			}
			if (!seeThroughOrdered)
			{
				return;
			}
			for (int num36 = 0; num36 < rmsCount; num36++)
			{
				if (!rms[num36].render)
				{
					continue;
				}
				Mesh mesh8 = rms[num36].mesh;
				for (int num37 = 0; num37 < mesh8.subMeshCount; num37++)
				{
					if (((1 << num37) & subMeshMask) != 0)
					{
						if (rms[num36].isCombined)
						{
							cbHighlight.DrawMesh(mesh8, rms[num36].renderingMatrix, fxMatClearStencil, num37, 1);
						}
						else
						{
							cbHighlight.DrawRenderer(rms[num36].renderer, fxMatClearStencil, num37, 1);
						}
					}
				}
			}
		}

		private void RenderMask(int k, Mesh mesh, bool renderMaskOnTop)
		{
			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				if (((1 << i) & subMeshMask) != 0)
				{
					if (renderMaskOnTop)
					{
						rms[k].fxMatMask[i].SetInt(ShaderParams.ZTest, 8);
					}
					else
					{
						rms[k].fxMatMask[i].SetInt(ShaderParams.ZTest, 4);
					}
					if (rms[k].isCombined)
					{
						cbHighlight.DrawMesh(rms[k].mesh, rms[k].renderingMatrix, rms[k].fxMatMask[i], i, 0);
					}
					else
					{
						cbHighlight.DrawRenderer(rms[k].renderer, rms[k].fxMatMask[i], i, 0);
					}
				}
			}
		}

		private void RenderSeeThroughClearStencil(int k, Mesh mesh)
		{
			if (rms[k].isCombined)
			{
				for (int i = 0; i < mesh.subMeshCount; i++)
				{
					if (((1 << i) & subMeshMask) != 0)
					{
						cbHighlight.DrawMesh(mesh, rms[k].renderingMatrix, fxMatClearStencil, i, 1);
					}
				}
				return;
			}
			for (int j = 0; j < mesh.subMeshCount; j++)
			{
				if (((1 << j) & subMeshMask) != 0)
				{
					cbHighlight.DrawRenderer(rms[k].renderer, fxMatClearStencil, j, 1);
				}
			}
		}

		private void RenderSeeThroughMask(int k, Mesh mesh)
		{
			if (rms[k].isCombined)
			{
				for (int i = 0; i < mesh.subMeshCount; i++)
				{
					if (((1 << i) & subMeshMask) != 0)
					{
						cbHighlight.DrawMesh(mesh, rms[k].renderingMatrix, rms[k].fxMatMask[i], i, 1);
					}
				}
				return;
			}
			for (int j = 0; j < mesh.subMeshCount; j++)
			{
				if (((1 << j) & subMeshMask) != 0)
				{
					cbHighlight.DrawRenderer(rms[k].renderer, rms[k].fxMatMask[j], j, 1);
				}
			}
		}

		private void WorldToViewportPoint(ref Matrix4x4 m, ref Vector4 p, bool perspectiveProjection, float zBufferParamsZ, float zBufferParamsW)
		{
			p = m * p;
			p.x = (p.x / p.w + 1f) * 0.5f;
			p.y = (p.y / p.w + 1f) * 0.5f;
			if (perspectiveProjection)
			{
				p.z /= p.w;
				p.z = 1f / (zBufferParamsZ * p.z + zBufferParamsW);
				return;
			}
			if (usesReversedZBuffer)
			{
				p.z = 1f - p.z;
			}
			p.z = (zBufferParamsW - zBufferParamsZ) * p.z + zBufferParamsZ;
		}

		private bool ComputeSmoothQuadMatrix(Camera cam, Bounds bounds)
		{
			bool result;
			if (VRCheck.isVrRunning)
			{
				Vector3 shift = Vector3.zero;
				result = ComputeSmoothQuadMatrixOriginShifted(cam, ref bounds, ref shift);
			}
			else
			{
				Vector3 shift2 = cam.transform.position;
				cam.transform.position = Vector3.zero;
				cam.ResetWorldToCameraMatrix();
				bounds.center -= shift2;
				result = ComputeSmoothQuadMatrixOriginShifted(cam, ref bounds, ref shift2);
				cam.transform.position = shift2;
			}
			return result;
		}

		private bool ComputeSmoothQuadMatrixOriginShifted(Camera cam, ref Bounds bounds, ref Vector3 shift)
		{
			Matrix4x4 m = GL.GetGPUProjectionMatrix(cam.projectionMatrix, renderIntoTexture: false) * cam.worldToCameraMatrix;
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			corners[0] = new Vector4(min.x, min.y, min.z, 1f);
			corners[1] = new Vector4(min.x, min.y, max.z, 1f);
			corners[2] = new Vector4(max.x, min.y, min.z, 1f);
			corners[3] = new Vector4(max.x, min.y, max.z, 1f);
			corners[4] = new Vector4(min.x, max.y, min.z, 1f);
			corners[5] = new Vector4(min.x, max.y, max.z, 1f);
			corners[6] = new Vector4(max.x, max.y, min.z, 1f);
			corners[7] = new Vector4(max.x, max.y, max.z, 1f);
			Vector3 scrMin = new Vector3(float.MaxValue, float.MaxValue, 0f);
			Vector3 scrMax = new Vector3(float.MinValue, float.MinValue, 0f);
			float num = float.MaxValue;
			float num2 = float.MinValue;
			float nearClipPlane = cam.nearClipPlane;
			float farClipPlane = cam.farClipPlane;
			bool flag = !cam.orthographic;
			float zBufferParamsZ;
			float zBufferParamsW;
			if (flag)
			{
				if (usesReversedZBuffer)
				{
					float num3 = -1f + farClipPlane / nearClipPlane;
					float num4 = 1f;
					zBufferParamsZ = num3 / farClipPlane;
					zBufferParamsW = 1f / farClipPlane;
				}
				else
				{
					float num5 = 1f - farClipPlane / nearClipPlane;
					float num4 = farClipPlane / nearClipPlane;
					zBufferParamsZ = num5 / farClipPlane;
					zBufferParamsW = num4 / farClipPlane;
				}
			}
			else
			{
				zBufferParamsZ = nearClipPlane;
				zBufferParamsW = farClipPlane;
			}
			for (int i = 0; i < 8; i++)
			{
				WorldToViewportPoint(ref m, ref corners[i], flag, zBufferParamsZ, zBufferParamsW);
				if (corners[i].x < scrMin.x)
				{
					scrMin.x = corners[i].x;
				}
				if (corners[i].y < scrMin.y)
				{
					scrMin.y = corners[i].y;
				}
				if (corners[i].x > scrMax.x)
				{
					scrMax.x = corners[i].x;
				}
				if (corners[i].y > scrMax.y)
				{
					scrMax.y = corners[i].y;
				}
				if (corners[i].z < num)
				{
					num = corners[i].z;
					if (num < nearClipPlane)
					{
						num = (num2 = 0.01f + nearClipPlane);
						scrMin.x = (scrMin.y = 0f);
						scrMax.x = 1f;
						scrMax.y = 1f;
						break;
					}
				}
				if (corners[i].z > num2)
				{
					num2 = corners[i].z;
				}
			}
			if (scrMax.y == scrMin.y)
			{
				return false;
			}
			int pixelWidth = cam.pixelWidth;
			int pixelHeight = cam.pixelHeight;
			Rect pixelRect = cam.pixelRect;
			scrMin.x *= pixelWidth;
			scrMax.x *= pixelWidth;
			scrMin.y *= pixelHeight;
			scrMax.y *= pixelHeight;
			scrMin.x += pixelRect.xMin;
			scrMax.x += pixelRect.xMin;
			scrMin.y += pixelRect.yMin;
			scrMax.y += pixelRect.yMin;
			if (spriteMode)
			{
				scrMin.z = (scrMax.z = (num + num2) * 0.5f + nearClipPlane);
			}
			else
			{
				scrMin.z = (scrMax.z = (VRCheck.isVrRunning ? num : (0.05f + nearClipPlane)));
			}
			if (outline > 0f)
			{
				BuildMatrix(cam, scrMin, scrMax, (int)(10f + 20f * outlineWidth + (float)(5 * outlineDownsampling)), ref quadOutlineMatrix, ref shift);
			}
			if (glow > 0f)
			{
				BuildMatrix(cam, scrMin, scrMax, (int)(20f + 30f * glowWidth + (float)(10 * glowDownsampling)), ref quadGlowMatrix, ref shift);
			}
			return true;
		}

		private void BuildMatrix(Camera cam, Vector3 scrMin, Vector3 scrMax, int border, ref Matrix4x4 quadMatrix, ref Vector3 shift)
		{
			border += extraCoveragePixels;
			scrMin.x -= border;
			scrMin.y -= border;
			scrMax.x += border;
			scrMax.y += border;
			Vector3 position = new Vector3(scrMax.x, scrMin.y, scrMin.z);
			scrMin = cam.ScreenToWorldPoint(scrMin);
			scrMax = cam.ScreenToWorldPoint(scrMax);
			position = cam.ScreenToWorldPoint(position);
			float x = Vector3.Distance(scrMin, position);
			float y = Vector3.Distance(scrMax, position);
			quadMatrix = Matrix4x4.TRS((scrMin + scrMax) * 0.5f + shift, cam.transform.rotation, new Vector3(x, y, 1f));
		}

		private void SmoothGlow(int rtWidth, int rtHeight)
		{
			Material material = fxMatBlurGlow;
			RenderTextureDescriptor desc = sourceDesc;
			desc.depthBufferBits = 0;
			if (glowBlurMethod == BlurMethod.Gaussian)
			{
				int num = 8;
				if (mipGlowBuffers == null || mipGlowBuffers.Length != num)
				{
					mipGlowBuffers = new int[num];
					for (int i = 0; i < num; i++)
					{
						mipGlowBuffers[i] = Shader.PropertyToID("_HPSmoothGlowTemp" + i);
					}
					mipGlowBuffers[num - 2] = ShaderParams.GlowRT;
				}
				for (int j = 0; j < num; j++)
				{
					float num2 = j / 2 + 2;
					int num3 = (int)((float)rtWidth / num2);
					int num4 = (int)((float)rtHeight / num2);
					if (num3 <= 0)
					{
						num3 = 1;
					}
					if (num4 <= 0)
					{
						num4 = 1;
					}
					desc.width = num3;
					desc.height = num4;
					cbHighlight.GetTemporaryRT(mipGlowBuffers[j], desc, FilterMode.Bilinear);
				}
				for (int k = 0; k < num - 1; k += 2)
				{
					if (k == 0)
					{
						RenderingUtils.FullScreenBlit(cbHighlight, sourceRT, mipGlowBuffers[k + 1], fxMatBlurGlow, 0);
					}
					else
					{
						RenderingUtils.FullScreenBlit(cbHighlight, mipGlowBuffers[k], mipGlowBuffers[k + 1], fxMatBlurGlow, 0);
					}
					RenderingUtils.FullScreenBlit(cbHighlight, mipGlowBuffers[k + 1], mipGlowBuffers[k], fxMatBlurGlow, 1);
					if (k < num - 2)
					{
						RenderingUtils.FullScreenBlit(cbHighlight, mipGlowBuffers[k], mipGlowBuffers[k + 2], fxMatBlurGlow, 2);
					}
				}
				return;
			}
			int num5 = 4;
			if (mipGlowBuffers == null || mipGlowBuffers.Length != num5)
			{
				mipGlowBuffers = new int[num5];
				for (int l = 0; l < num5 - 1; l++)
				{
					mipGlowBuffers[l] = Shader.PropertyToID("_HPSmoothGlowTemp" + l);
				}
				mipGlowBuffers[num5 - 1] = ShaderParams.GlowRT;
			}
			for (int m = 0; m < num5; m++)
			{
				float num6 = m + 2;
				int num7 = (int)((float)rtWidth / num6);
				int num8 = (int)((float)rtHeight / num6);
				if (num7 <= 0)
				{
					num7 = 1;
				}
				if (num8 <= 0)
				{
					num8 = 1;
				}
				desc.width = num7;
				desc.height = num8;
				cbHighlight.GetTemporaryRT(mipGlowBuffers[m], desc, FilterMode.Bilinear);
			}
			RenderingUtils.FullScreenBlit(cbHighlight, sourceRT, mipGlowBuffers[0], material, 3);
			for (int n = 0; n < num5 - 1; n++)
			{
				cbHighlight.SetGlobalFloat(ShaderParams.ResampleScale, (float)n + 0.5f);
				RenderingUtils.FullScreenBlit(cbHighlight, mipGlowBuffers[n], mipGlowBuffers[n + 1], material, 3);
			}
		}

		private void SmoothOutline(int rtWidth, int rtHeight)
		{
			int num = outlineBlurPasses * 2;
			if (mipOutlineBuffers == null || mipOutlineBuffers.Length != num)
			{
				mipOutlineBuffers = new int[num];
				for (int i = 0; i < num; i++)
				{
					mipOutlineBuffers[i] = Shader.PropertyToID("_HPSmoothOutlineTemp" + i);
				}
				mipOutlineBuffers[num - 2] = ShaderParams.OutlineRT;
			}
			RenderTextureDescriptor desc = sourceDesc;
			desc.depthBufferBits = 0;
			for (int j = 0; j < num; j++)
			{
				float num2 = j / 2 + 2;
				int num3 = (int)((float)rtWidth / num2);
				int num4 = (int)((float)rtHeight / num2);
				if (num3 <= 0)
				{
					num3 = 1;
				}
				if (num4 <= 0)
				{
					num4 = 1;
				}
				desc.width = num3;
				desc.height = num4;
				cbHighlight.GetTemporaryRT(mipOutlineBuffers[j], desc, FilterMode.Bilinear);
			}
			for (int k = 0; k < num - 1; k += 2)
			{
				if (k == 0)
				{
					RenderingUtils.FullScreenBlit(cbHighlight, sourceRT, mipOutlineBuffers[k + 1], fxMatBlurOutline, 3);
				}
				else
				{
					RenderingUtils.FullScreenBlit(cbHighlight, mipOutlineBuffers[k], mipOutlineBuffers[k + 1], fxMatBlurOutline, 0);
				}
				RenderingUtils.FullScreenBlit(cbHighlight, mipOutlineBuffers[k + 1], mipOutlineBuffers[k], fxMatBlurOutline, 1);
				if (k < num - 2)
				{
					RenderingUtils.FullScreenBlit(cbHighlight, mipOutlineBuffers[k], mipOutlineBuffers[k + 2], fxMatBlurOutline, 2);
				}
			}
		}

		private void ComposeSmoothBlend(Visibility smoothGlowVisibility, Visibility smoothOutlineVisibility)
		{
			bool flag = colorAttachmentBuffer != BuiltinRenderTextureType.CameraTarget && depthAttachmentBuffer == BuiltinRenderTextureType.CameraTarget;
			cbHighlight.SetRenderTarget(colorAttachmentBuffer, flag ? colorAttachmentBuffer : depthAttachmentBuffer);
			int num;
			if (glow > 0f && glowWidth > 0f)
			{
				num = ((glowQuality == QualityLevel.Highest) ? 1 : 0);
				if (num != 0)
				{
					fxMatComposeGlow.SetVector(ShaderParams.Flip, (VRCheck.isVrRunning && flipY) ? new Vector4(1f, -1f) : new Vector4(0f, 1f));
					fxMatComposeGlow.SetInt(ShaderParams.ZTest, GetZTestValue(smoothGlowVisibility));
					cbHighlight.DrawMesh(quadMesh, quadGlowMatrix, fxMatComposeGlow, 0, 0);
				}
			}
			else
			{
				num = 0;
			}
			bool flag2 = outline > 0f && outlineWidth > 0f && outlineQuality == QualityLevel.Highest;
			if (flag2)
			{
				fxMatComposeOutline.SetVector(ShaderParams.Flip, (VRCheck.isVrRunning && flipY) ? new Vector4(1f, -1f) : new Vector4(0f, 1f));
				fxMatComposeOutline.SetInt(ShaderParams.ZTest, GetZTestValue(smoothOutlineVisibility));
				cbHighlight.DrawMesh(quadMesh, quadOutlineMatrix, fxMatComposeOutline, 0, 0);
			}
			if (num != 0)
			{
				for (int i = 0; i < mipGlowBuffers.Length; i++)
				{
					cbHighlight.ReleaseTemporaryRT(mipGlowBuffers[i]);
				}
			}
			if (flag2)
			{
				for (int j = 0; j < mipOutlineBuffers.Length; j++)
				{
					cbHighlight.ReleaseTemporaryRT(mipOutlineBuffers[j]);
				}
			}
			cbHighlight.ReleaseTemporaryRT(sourceRT);
		}

		private void InitMaterial(ref Material material, string shaderName)
		{
			if (!(material != null))
			{
				Shader shader = Shader.Find(shaderName);
				if (shader == null)
				{
					Debug.LogError("Shader " + shaderName + " not found.");
				}
				else
				{
					material = new Material(shader);
				}
			}
		}

		private void Fork(Material mat, ref Material[] mats, Mesh mesh)
		{
			if (!(mesh == null))
			{
				int subMeshCount = mesh.subMeshCount;
				Fork(mat, ref mats, subMeshCount);
			}
		}

		private void Fork(Material material, ref Material[] array, int count)
		{
			if (array == null || array.Length < count)
			{
				DestroyMaterialArray(array);
				array = new Material[count];
			}
			for (int i = 0; i < count; i++)
			{
				if (array[i] == null)
				{
					array[i] = UnityEngine.Object.Instantiate(material);
				}
			}
		}

		public void SetTarget(Transform transform)
		{
			if (transform == null)
			{
				return;
			}
			InitIfNeeded();
			if (transform != target)
			{
				if (_highlighted)
				{
					ImmediateFadeOut();
				}
				target = transform;
				SetupMaterial();
			}
			else
			{
				UpdateVisibilityState();
			}
		}

		public void SetTargets(Transform transform, Renderer[] renderers)
		{
			if (!(transform == null))
			{
				InitIfNeeded();
				if (_highlighted)
				{
					ImmediateFadeOut();
				}
				effectGroup = TargetOptions.Scripting;
				target = transform;
				SetupMaterial(renderers);
			}
		}

		public void SetHighlighted(bool state)
		{
			if (state != _highlighted && this.OnObjectHighlightStateChange != null && !this.OnObjectHighlightStateChange(base.gameObject, state))
			{
				return;
			}
			if (state)
			{
				lastHighlighted = this;
			}
			if (!Application.isPlaying)
			{
				_highlighted = state;
				return;
			}
			float time = GetTime();
			if (fading == FadingState.NoFading)
			{
				fadeStartTime = time;
			}
			if (state && !ignore)
			{
				if ((_highlighted && fading == FadingState.NoFading) || (this.OnObjectHighlightStart != null && !this.OnObjectHighlightStart(base.gameObject)))
				{
					return;
				}
				SendMessage("HighlightStart", null, SendMessageOptions.DontRequireReceiver);
				highlightStartTime = (targetFXStartTime = (iconFXStartTime = time));
				if (fadeInDuration > 0f)
				{
					if (fading == FadingState.FadingOut)
					{
						float num = fadeOutDuration - (time - fadeStartTime);
						fadeStartTime = time - num;
						fadeStartTime = Mathf.Min(fadeStartTime, time);
					}
					fading = FadingState.FadingIn;
				}
				else
				{
					fading = FadingState.NoFading;
				}
				_highlighted = true;
				requireUpdateMaterial = true;
			}
			else
			{
				if (!_highlighted)
				{
					return;
				}
				if (fadeOutDuration > 0f)
				{
					if (fading == FadingState.FadingIn)
					{
						float num2 = time - fadeStartTime;
						fadeStartTime = time + num2 - fadeInDuration;
						fadeStartTime = Mathf.Min(fadeStartTime, time);
					}
					fading = FadingState.FadingOut;
				}
				else
				{
					fading = FadingState.NoFading;
					ImmediateFadeOut();
					requireUpdateMaterial = true;
				}
			}
		}

		private void ImmediateFadeOut()
		{
			fading = FadingState.NoFading;
			_highlighted = false;
			if (this.OnObjectHighlightEnd != null)
			{
				this.OnObjectHighlightEnd(base.gameObject);
			}
			SendMessage("HighlightEnd", null, SendMessageOptions.DontRequireReceiver);
		}

		private void SetupMaterial()
		{
			if (target == null || fxMatMask == null)
			{
				return;
			}
			Renderer[] rr = null;
			switch (effectGroup)
			{
			case TargetOptions.OnlyThisObject:
			{
				if (target.TryGetComponent<Renderer>(out var component2) && ValidRenderer(component2))
				{
					rr = new Renderer[1] { component2 };
				}
				break;
			}
			case TargetOptions.RootToChildren:
			{
				Transform parent = target;
				while (parent.parent != null)
				{
					parent = parent.parent;
				}
				rr = FindRenderersInChildren(parent);
				break;
			}
			case TargetOptions.LayerInScene:
			{
				HighlightEffect highlightEffect2 = this;
				if (target != base.transform && target.TryGetComponent<HighlightEffect>(out var component3))
				{
					highlightEffect2 = component3;
				}
				rr = FindRenderersWithLayerInScene(highlightEffect2.effectGroupLayer);
				break;
			}
			case TargetOptions.LayerInChildren:
			{
				HighlightEffect highlightEffect = this;
				if (target != base.transform && target.TryGetComponent<HighlightEffect>(out var component))
				{
					highlightEffect = component;
				}
				rr = FindRenderersWithLayerInChildren(highlightEffect.effectGroupLayer);
				break;
			}
			case TargetOptions.Children:
				rr = FindRenderersInChildren(target);
				break;
			case TargetOptions.Scripting:
				UpdateMaterialProperties();
				return;
			}
			SetupMaterial(rr);
		}

		private void SetupMaterial(Renderer[] rr)
		{
			if (rr == null)
			{
				rr = new Renderer[0];
			}
			if (rms == null || rms.Length < rr.Length)
			{
				rms = new ModelMaterials[rr.Length];
			}
			InitCommandBuffer();
			spriteMode = false;
			rmsCount = 0;
			for (int i = 0; i < rr.Length; i++)
			{
				rms[rmsCount].Init();
				Renderer renderer = rr[i];
				if (renderer == null)
				{
					continue;
				}
				if (effectGroup != TargetOptions.OnlyThisObject && !string.IsNullOrEmpty(effectNameFilter))
				{
					if (effectNameUseRegEx)
					{
						try
						{
							lastRegExError = "";
							if (!Regex.IsMatch(renderer.name, effectNameFilter))
							{
								continue;
							}
						}
						catch (Exception ex)
						{
							lastRegExError = ex.Message;
							continue;
						}
					}
					else if (!renderer.name.Contains(effectNameFilter))
					{
						continue;
					}
				}
				rms[rmsCount].renderer = renderer;
				rms[rmsCount].renderWasVisibleDuringSetup = renderer.isVisible;
				sortingOffset = (float)renderer.gameObject.GetInstanceID() % 0.0001f;
				if (renderer.transform != target && renderer.TryGetComponent<HighlightEffect>(out var component) && component.enabled && component.ignore)
				{
					continue;
				}
				if (this.OnRendererHighlightStart != null && !this.OnRendererHighlightStart(renderer))
				{
					rmsCount++;
					continue;
				}
				rms[rmsCount].isCombined = false;
				bool flag = renderer is SkinnedMeshRenderer;
				rms[rmsCount].isSkinnedMesh = flag;
				bool num = renderer is SpriteRenderer;
				rms[rmsCount].normalsOption = (flag ? NormalsOption.PreserveOriginal : normalsOption);
				MeshFilter component3;
				if (num)
				{
					rms[rmsCount].mesh = quadMesh;
					spriteMode = true;
				}
				else if (flag)
				{
					rms[rmsCount].mesh = ((SkinnedMeshRenderer)renderer).sharedMesh;
				}
				else if (Application.isPlaying && renderer.isPartOfStaticBatch)
				{
					if (renderer.TryGetComponent<MeshCollider>(out var component2))
					{
						rms[rmsCount].mesh = component2.sharedMesh;
					}
				}
				else if (renderer.TryGetComponent<MeshFilter>(out component3))
				{
					rms[rmsCount].mesh = component3.sharedMesh;
				}
				if (rms[rmsCount].mesh == null)
				{
					continue;
				}
				rms[rmsCount].transform = renderer.transform;
				Fork(fxMatMask, ref rms[rmsCount].fxMatMask, rms[rmsCount].mesh);
				Fork(fxMatOutlineTemplate, ref rms[rmsCount].fxMatOutline, rms[rmsCount].mesh);
				Fork(fxMatGlowTemplate, ref rms[rmsCount].fxMatGlow, rms[rmsCount].mesh);
				Fork(fxMatSeeThrough, ref rms[rmsCount].fxMatSeeThroughInner, rms[rmsCount].mesh);
				Fork(fxMatSeeThroughBorder, ref rms[rmsCount].fxMatSeeThroughBorder, rms[rmsCount].mesh);
				Fork(fxMatOverlay, ref rms[rmsCount].fxMatOverlay, rms[rmsCount].mesh);
				Fork(fxMatInnerGlow, ref rms[rmsCount].fxMatInnerGlow, rms[rmsCount].mesh);
				Fork(fxMatSolidColor, ref rms[rmsCount].fxMatSolidColor, rms[rmsCount].mesh);
				rms[rmsCount].originalMesh = rms[rmsCount].mesh;
				if (!rms[rmsCount].preserveOriginalMesh && (innerGlow > 0f || (glow > 0f && glowQuality != QualityLevel.Highest) || (outline > 0f && outlineQuality != QualityLevel.Highest)))
				{
					if (normalsOption == NormalsOption.Reorient)
					{
						ReorientNormals(rmsCount);
					}
					else
					{
						AverageNormals(rmsCount);
					}
				}
				rmsCount++;
			}
			if (spriteMode)
			{
				outlineIndependent = false;
				outlineQuality = QualityLevel.Highest;
				glowQuality = QualityLevel.Highest;
				innerGlow = 0f;
				cullBackFaces = false;
				seeThrough = SeeThroughMode.Never;
				if (alphaCutOff <= 0f)
				{
					alphaCutOff = 0.5f;
				}
			}
			else if (combineMeshes)
			{
				CombineMeshes();
			}
			UpdateMaterialProperties();
		}

		private bool ValidRenderer(Renderer r)
		{
			if (!(r is MeshRenderer) && !(r is SpriteRenderer))
			{
				return r is SkinnedMeshRenderer;
			}
			return true;
		}

		private Renderer[] FindRenderersWithLayerInScene(LayerMask layer)
		{
			Renderer[] array = Misc.FindObjectsOfType<Renderer>();
			tempRR.Clear();
			foreach (Renderer renderer in array)
			{
				if (((1 << renderer.gameObject.layer) & (int)layer) != 0 && ValidRenderer(renderer))
				{
					tempRR.Add(renderer);
				}
			}
			return tempRR.ToArray();
		}

		private Renderer[] FindRenderersWithLayerInChildren(LayerMask layer)
		{
			Renderer[] componentsInChildren = target.GetComponentsInChildren<Renderer>();
			tempRR.Clear();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (((1 << renderer.gameObject.layer) & (int)layer) != 0 && ValidRenderer(renderer))
				{
					tempRR.Add(renderer);
				}
			}
			return tempRR.ToArray();
		}

		private Renderer[] FindRenderersInChildren(Transform parent)
		{
			tempRR.Clear();
			parent.GetComponentsInChildren(tempRR);
			for (int i = 0; i < tempRR.Count; i++)
			{
				Renderer r = tempRR[i];
				if (!ValidRenderer(r))
				{
					tempRR.RemoveAt(i);
					i--;
				}
			}
			return tempRR.ToArray();
		}

		private void InitTemplateMaterials()
		{
			InitMaterial(ref fxMatMask, "HighlightPlus/Geometry/Mask");
			InitMaterial(ref fxMatGlowTemplate, "HighlightPlus/Geometry/Glow");
			if (fxMatGlowTemplate != null)
			{
				Texture2D value = Resources.Load<Texture2D>("HighlightPlus/blueNoiseVL");
				fxMatGlowTemplate.SetTexture(ShaderParams.NoiseTex, value);
				if (useGPUInstancing)
				{
					fxMatGlowTemplate.enableInstancing = true;
				}
			}
			InitMaterial(ref fxMatInnerGlow, "HighlightPlus/Geometry/InnerGlow");
			InitMaterial(ref fxMatOutlineTemplate, "HighlightPlus/Geometry/Outline");
			if (fxMatOutlineTemplate != null && useGPUInstancing)
			{
				fxMatOutlineTemplate.enableInstancing = true;
			}
			InitMaterial(ref fxMatOverlay, "HighlightPlus/Geometry/Overlay");
			InitMaterial(ref fxMatSeeThrough, "HighlightPlus/Geometry/SeeThrough");
			InitMaterial(ref fxMatSeeThroughBorder, "HighlightPlus/Geometry/SeeThroughBorder");
			InitMaterial(ref fxMatSeeThroughMask, "HighlightPlus/Geometry/SeeThroughMask");
			InitMaterial(ref fxMatTarget, "HighlightPlus/Geometry/Target");
			InitMaterial(ref fxMatComposeGlow, "HighlightPlus/Geometry/ComposeGlow");
			InitMaterial(ref fxMatComposeOutline, "HighlightPlus/Geometry/ComposeOutline");
			InitMaterial(ref fxMatSolidColor, "HighlightPlus/Geometry/SolidColor");
			InitMaterial(ref fxMatBlurGlow, "HighlightPlus/Geometry/BlurGlow");
			InitMaterial(ref fxMatBlurOutline, "HighlightPlus/Geometry/BlurOutline");
			InitMaterial(ref fxMatClearStencil, "HighlightPlus/ClearStencil");
		}

		private void InitCommandBuffer()
		{
			if (cbHighlight == null)
			{
				cbHighlight = new CommandBuffer();
				cbHighlight.name = "Highlight Plus for " + base.name;
			}
			cbHighlightEmpty = true;
		}

		private void ConfigureOutput()
		{
			if (cbHighlightEmpty)
			{
				cbHighlightEmpty = false;
				colorAttachmentBuffer = new RenderTargetIdentifier(colorAttachmentBuffer, 0, CubemapFace.Unknown, -1);
				depthAttachmentBuffer = new RenderTargetIdentifier(depthAttachmentBuffer, 0, CubemapFace.Unknown, -1);
				cbHighlight.SetRenderTarget(colorAttachmentBuffer, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, depthAttachmentBuffer, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store);
				cbHighlight.SetRenderTarget(colorAttachmentBuffer, depthAttachmentBuffer);
			}
		}

		public void UpdateVisibilityState()
		{
			if (rms == null || rms.Length != 1 || rms[0].transform != base.transform || rms[0].renderer == null)
			{
				isVisible = true;
			}
			else if (rms[0].renderer != null)
			{
				isVisible = rms[0].renderer.isVisible;
			}
		}

		public void UpdateMaterialProperties()
		{
			if (rms == null)
			{
				return;
			}
			if (ignore)
			{
				_highlighted = false;
			}
			UpdateVisibilityState();
			extraCoveragePixels = Mathf.Max(0, extraCoveragePixels);
			maskRequired = (_highlighted && ((outline > 0f && outlineMaskMode != MaskMode.IgnoreMask) || (glow > 0f && glowMaskMode != MaskMode.IgnoreMask))) || seeThrough != SeeThroughMode.Never || (targetFX && targetFXAlignToGround);
			usesSeeThrough = seeThroughIntensity > 0f && (seeThrough == SeeThroughMode.AlwaysWhenOccluded || (seeThrough == SeeThroughMode.WhenHighlighted && _highlighted));
			if (usesSeeThrough && seeThroughChildrenSortingMode != SeeThroughSortingMode.Default && rms.Length != 0)
			{
				if (seeThroughChildrenSortingMode == SeeThroughSortingMode.SortByMaterialsRenderQueue)
				{
					Array.Sort(rms, MaterialsRenderQueueComparer);
				}
				else
				{
					Array.Sort(rms, MaterialsRenderQueueInvertedComparer);
				}
			}
			Color value = seeThroughTintColor;
			value.a = seeThroughTintAlpha;
			if (lastOutlineVisibility != outlineVisibility)
			{
				if (glowQuality == QualityLevel.Highest && outlineQuality == QualityLevel.Highest)
				{
					glowVisibility = outlineVisibility;
				}
				lastOutlineVisibility = outlineVisibility;
			}
			if (outlineWidth < 0f)
			{
				outlineWidth = 0f;
			}
			if (padding < 0f)
			{
				padding = 0f;
			}
			if (outlineQuality == QualityLevel.Medium)
			{
				outlineOffsetsMin = 4;
				outlineOffsetsMax = 7;
			}
			else if (outlineQuality == QualityLevel.High)
			{
				outlineOffsetsMin = 0;
				outlineOffsetsMax = 7;
			}
			else
			{
				outlineOffsetsMin = (outlineOffsetsMax = 0);
			}
			if (glowWidth < 0f)
			{
				glowWidth = 0f;
			}
			if (glowQuality == QualityLevel.Medium)
			{
				glowOffsetsMin = 4;
				glowOffsetsMax = 7;
			}
			else if (glowQuality == QualityLevel.High)
			{
				glowOffsetsMin = 0;
				glowOffsetsMax = 7;
			}
			else
			{
				glowOffsetsMin = (glowOffsetsMax = 0);
			}
			if (targetFXTransitionDuration <= 0f)
			{
				targetFXTransitionDuration = 0.0001f;
			}
			if (targetFXStayDuration <= 0f)
			{
				targetFXStayDuration = 0f;
			}
			if (targetFXFadePower <= 0f)
			{
				targetFXFadePower = 0f;
			}
			if (iconFXTransitionDuration <= 0f)
			{
				iconFXTransitionDuration = 0.0001f;
			}
			if (iconFXAnimationAmount < 0f)
			{
				iconFXAnimationAmount = 0f;
			}
			if (iconFXAnimationSpeed < 0f)
			{
				iconFXAnimationSpeed = 0f;
			}
			if (iconFXStayDuration < 0f)
			{
				iconFXStayDuration = 0f;
			}
			if (iconFXScale < 0f)
			{
				iconFXScale = 0f;
			}
			if (seeThroughDepthOffset < 0f)
			{
				seeThroughDepthOffset = 0f;
			}
			if (seeThroughMaxDepth < 0f)
			{
				seeThroughMaxDepth = 0f;
			}
			if (seeThroughBorderWidth < 0f)
			{
				seeThroughBorderWidth = 0f;
			}
			if (outlineSharpness < 1f)
			{
				outlineSharpness = 1f;
			}
			shouldBakeSkinnedMesh = optimizeSkinnedMesh && ((outline > 0f && outlineQuality != QualityLevel.Highest) || (glow > 0f && glowQuality != QualityLevel.Highest));
			useSmoothGlow = glow > 0f && glowWidth > 0f && glowQuality == QualityLevel.Highest;
			useSmoothOutline = outline > 0f && outlineWidth > 0f && outlineQuality == QualityLevel.Highest;
			useSmoothBlend = useSmoothGlow || useSmoothOutline;
			if (useSmoothBlend)
			{
				if (useSmoothGlow && useSmoothOutline)
				{
					outlineVisibility = glowVisibility;
				}
				outlineEdgeThreshold = Mathf.Clamp01(outlineEdgeThreshold);
			}
			if (useSmoothGlow)
			{
				fxMatComposeGlow.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
				if (glowBlendMode == GlowBlendMode.Additive)
				{
					fxMatComposeGlow.SetInt(ShaderParams.BlendSrc, 1);
					fxMatComposeGlow.SetInt(ShaderParams.BlendDst, 1);
				}
				else
				{
					fxMatComposeGlow.SetInt(ShaderParams.BlendSrc, 5);
					fxMatComposeGlow.SetInt(ShaderParams.BlendDst, 10);
				}
				fxMatComposeGlow.SetColor(ShaderParams.Debug, glowBlitDebug ? debugColor : blackColor);
				fxMatComposeGlow.SetInt(ShaderParams.GlowStencilComp, (glowMaskMode != MaskMode.Stencil) ? 8 : 6);
				if (glowMaskMode == MaskMode.StencilAndCutout)
				{
					fxMatComposeGlow.EnableKeyword("HP_MASK_CUTOUT");
				}
				else
				{
					fxMatComposeGlow.DisableKeyword("HP_MASK_CUTOUT");
				}
				fxMatBlurGlow.SetFloat(ShaderParams.BlurScale, glowWidth / (float)glowDownsampling);
				fxMatBlurGlow.SetFloat(ShaderParams.Speed, glowAnimationSpeed);
			}
			if (useSmoothOutline)
			{
				fxMatComposeOutline.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
				fxMatComposeOutline.SetColor(ShaderParams.Debug, outlineBlitDebug ? debugColor : blackColor);
				fxMatComposeOutline.SetFloat(ShaderParams.OutlineSharpness, outlineSharpness);
				if (outlineEdgeMode == OutlineEdgeMode.Exterior)
				{
					fxMatComposeOutline.DisableKeyword("HP_ALL_EDGES");
				}
				else
				{
					fxMatComposeOutline.EnableKeyword("HP_ALL_EDGES");
					outlineDownsampling = 1;
				}
				if (outlineEdgeMode != OutlineEdgeMode.Exterior || outlineMaskMode == MaskMode.IgnoreMask)
				{
					fxMatComposeOutline.SetInt(ShaderParams.OutlineStencilComp, 8);
				}
				else
				{
					fxMatComposeOutline.SetInt(ShaderParams.OutlineStencilComp, 6);
				}
				if (outlineMaskMode == MaskMode.StencilAndCutout)
				{
					fxMatComposeOutline.EnableKeyword("HP_MASK_CUTOUT");
				}
				else
				{
					fxMatComposeOutline.DisableKeyword("HP_MASK_CUTOUT");
				}
				float num = outlineWidth;
				if (outlineEdgeMode == OutlineEdgeMode.Any)
				{
					num = Mathf.Clamp(num, (float)outlineBlurPasses / 5f, outlineBlurPasses);
				}
				fxMatBlurOutline.SetFloat(ShaderParams.BlurScale, num / (float)outlineDownsampling);
				fxMatBlurOutline.SetFloat(ShaderParams.BlurScaleFirstHoriz, num * 2f);
			}
			if (outlineColorStyle == ColorStyle.Gradient && outlineGradient != null)
			{
				bool flag = false;
				if (outlineGradientTex == null)
				{
					outlineGradientTex = new Texture2D(32, 1, TextureFormat.RGBA32, mipChain: false, linear: true);
					outlineGradientTex.wrapMode = TextureWrapMode.Clamp;
					flag = true;
				}
				if (outlineGradientColors == null || outlineGradientColors.Length != 32)
				{
					outlineGradientColors = new Color[32];
					flag = true;
				}
				for (int i = 0; i < 32; i++)
				{
					float time = (float)i / 32f;
					Color color = outlineGradient.Evaluate(time);
					if (color != outlineGradientColors[i])
					{
						outlineGradientColors[i] = color;
						flag = true;
					}
				}
				if (flag)
				{
					outlineGradientTex.SetPixels(outlineGradientColors);
					outlineGradientTex.Apply();
				}
			}
			if (targetFX)
			{
				if (targetFXTexture == null)
				{
					targetFXTexture = Resources.Load<Texture2D>("HighlightPlus/target");
				}
				fxMatTarget.mainTexture = targetFXTexture;
				fxMatTarget.SetInt(ShaderParams.ZTest, GetZTestValue(targetFXVisibility));
			}
			if (iconFX)
			{
				if (iconFXMesh == null)
				{
					iconFXMesh = Resources.Load<Mesh>("HighlightPlus/IconMesh");
				}
				if (fxMatIcon == null)
				{
					fxMatIcon = new Material(Shader.Find("HighlightPlus/Geometry/IconFX"));
				}
			}
			float value2 = (outlineQuality.UsesMultipleOffsets() ? 0f : (outlineWidth / 100f));
			for (int j = 0; j < rmsCount; j++)
			{
				if (!(rms[j].mesh != null))
				{
					continue;
				}
				Renderer renderer = rms[j].renderer;
				if (renderer == null)
				{
					continue;
				}
				renderer.GetSharedMaterials(rendererSharedMaterials);
				for (int k = 0; k < rms[j].mesh.subMeshCount; k++)
				{
					if (((1 << k) & subMeshMask) == 0)
					{
						continue;
					}
					Material material = null;
					if (k < rendererSharedMaterials.Count)
					{
						material = rendererSharedMaterials[k];
					}
					if (material == null)
					{
						continue;
					}
					bool flag2 = false;
					Texture texture = null;
					Vector2 mainTextureOffset = Vector2.zero;
					Vector2 mainTextureScale = Vector2.one;
					if (material.HasProperty(ShaderParams.BaseMap))
					{
						texture = material.GetTexture(ShaderParams.BaseMap);
						flag2 = true;
						if (material.HasProperty(ShaderParams.BaseMapST))
						{
							Vector4 vector = material.GetVector(ShaderParams.BaseMapST);
							mainTextureScale.x = vector.x;
							mainTextureScale.y = vector.y;
							mainTextureOffset.x = vector.z;
							mainTextureOffset.y = vector.w;
						}
					}
					else if (material.HasProperty(ShaderParams.MainTex))
					{
						texture = material.GetTexture(ShaderParams.MainTex);
						if (texture == null)
						{
							texture = material.mainTexture;
						}
						mainTextureOffset = material.mainTextureOffset;
						mainTextureScale = material.mainTextureScale;
						flag2 = true;
					}
					bool flag3 = alphaCutOff > 0f && flag2;
					if (rms[j].fxMatMask != null && rms[j].fxMatMask.Length > k)
					{
						Material material2 = rms[j].fxMatMask[k];
						if (material2 != null)
						{
							material2.mainTexture = texture;
							material2.mainTextureOffset = mainTextureOffset;
							material2.mainTextureScale = mainTextureScale;
							if (flag3)
							{
								material2.SetFloat(ShaderParams.CutOff, alphaCutOff);
								material2.EnableKeyword("HP_ALPHACLIP");
							}
							else
							{
								material2.DisableKeyword("HP_ALPHACLIP");
							}
							material2.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
							material2.SetFloat(ShaderParams.Padding, padding);
						}
					}
					if (rms[j].fxMatOutline != null && rms[j].fxMatOutline.Length > k)
					{
						Material material3 = rms[j].fxMatOutline[k];
						if (material3 != null)
						{
							material3.SetFloat(ShaderParams.OutlineWidth, value2);
							material3.SetInt(ShaderParams.OutlineZTest, GetZTestValue(outlineVisibility));
							material3.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
							material3.SetFloat(ShaderParams.ConstantWidth, constantWidth ? 1f : 0f);
							material3.SetFloat(ShaderParams.MinimumWidth, minimumWidth);
							material3.SetInt(ShaderParams.OutlineStencilComp, (outlineMaskMode == MaskMode.IgnoreMask) ? 8 : 6);
							if (flag3)
							{
								material3.mainTexture = texture;
								material3.mainTextureOffset = mainTextureOffset;
								material3.mainTextureScale = mainTextureScale;
								material3.SetFloat(ShaderParams.CutOff, alphaCutOff);
								material3.EnableKeyword("HP_ALPHACLIP");
							}
							else
							{
								material3.DisableKeyword("HP_ALPHACLIP");
							}
							material3.DisableKeyword("HP_OUTLINE_GRADIENT_LS");
							material3.DisableKeyword("HP_OUTLINE_GRADIENT_WS");
							if (outlineColorStyle == ColorStyle.Gradient)
							{
								material3.SetTexture(ShaderParams.OutlineGradientTex, outlineGradientTex);
								material3.EnableKeyword(outlineGradientInLocalSpace ? "HP_OUTLINE_GRADIENT_LS" : "HP_OUTLINE_GRADIENT_WS");
							}
						}
					}
					if (rms[j].fxMatGlow != null && rms[j].fxMatGlow.Length > k)
					{
						Material material4 = rms[j].fxMatGlow[k];
						if (material4 != null)
						{
							material4.SetVector(ShaderParams.Glow2, new Vector4((outline > 0f) ? (outlineWidth / 100f) : 0f, glowAnimationSpeed, glowDithering));
							if (glowDitheringStyle == GlowDitheringStyle.Noise)
							{
								material4.EnableKeyword("HP_DITHER_BLUENOISE");
							}
							else
							{
								material4.DisableKeyword("HP_DITHER_BLUENOISE");
							}
							material4.SetInt(ShaderParams.GlowZTest, GetZTestValue(glowVisibility));
							material4.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
							material4.SetFloat(ShaderParams.ConstantWidth, constantWidth ? 1f : 0f);
							material4.SetFloat(ShaderParams.MinimumWidth, minimumWidth);
							material4.SetInt(ShaderParams.GlowStencilOp, (!glowBlendPasses) ? 2 : 0);
							material4.SetInt(ShaderParams.GlowStencilComp, (glowMaskMode == MaskMode.IgnoreMask) ? 8 : 6);
							if (flag3)
							{
								material4.mainTexture = texture;
								material4.mainTextureOffset = mainTextureOffset;
								material4.mainTextureScale = mainTextureScale;
								material4.SetFloat(ShaderParams.CutOff, alphaCutOff);
								material4.EnableKeyword("HP_ALPHACLIP");
							}
							else
							{
								material4.DisableKeyword("HP_ALPHACLIP");
							}
						}
					}
					bool flag4 = rms[j].fxMatSeeThroughBorder != null && rms[j].fxMatSeeThroughBorder.Length > k && seeThroughBorder * seeThroughBorderWidth > 0f;
					if (rms[j].fxMatSeeThroughInner != null && rms[j].fxMatSeeThroughInner.Length > k)
					{
						Material material5 = rms[j].fxMatSeeThroughInner[k];
						if (material5 != null)
						{
							material5.SetFloat(ShaderParams.SeeThrough, seeThroughIntensity);
							material5.SetFloat(ShaderParams.SeeThroughNoise, seeThroughNoise);
							material5.SetColor(ShaderParams.SeeThroughTintColor, value);
							material5.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
							if (seeThroughOccluderMaskAccurate && (int)seeThroughOccluderMask != -1)
							{
								material5.SetInt(ShaderParams.SeeThroughStencilRef, 1);
								material5.SetInt(ShaderParams.SeeThroughStencilComp, 3);
								material5.SetInt(ShaderParams.SeeThroughStencilPassOp, 1);
							}
							else
							{
								material5.SetInt(ShaderParams.SeeThroughStencilRef, 2);
								material5.SetInt(ShaderParams.SeeThroughStencilComp, 5);
								material5.SetInt(ShaderParams.SeeThroughStencilPassOp, 2);
							}
							material5.mainTexture = texture;
							material5.mainTextureOffset = mainTextureOffset;
							material5.mainTextureScale = mainTextureScale;
							if (flag3)
							{
								material5.SetFloat(ShaderParams.CutOff, alphaCutOff);
								material5.EnableKeyword("HP_ALPHACLIP");
							}
							else
							{
								material5.DisableKeyword("HP_ALPHACLIP");
							}
							if (seeThroughDepthOffset > 0f || seeThroughMaxDepth > 0f)
							{
								material5.SetFloat(ShaderParams.SeeThroughDepthOffset, (seeThroughDepthOffset > 0f) ? seeThroughDepthOffset : (-1f));
								material5.SetFloat(ShaderParams.SeeThroughMaxDepth, (seeThroughMaxDepth > 0f) ? seeThroughMaxDepth : 999999f);
								material5.EnableKeyword("HP_DEPTH_OFFSET");
							}
							else
							{
								material5.DisableKeyword("HP_DEPTH_OFFSET");
							}
							if (seeThroughBorderOnly)
							{
								material5.EnableKeyword("HP_SEETHROUGH_ONLY_BORDER");
							}
							else
							{
								material5.DisableKeyword("HP_SEETHROUGH_ONLY_BORDER");
							}
							material5.DisableKeyword("HP_TEXTURE_TRIPLANAR");
							material5.DisableKeyword("HP_TEXTURE_OBJECTSPACE");
							material5.DisableKeyword("HP_TEXTURE_SCREENSPACE");
							if (seeThroughTexture != null)
							{
								material5.SetTexture(ShaderParams.SeeThroughTexture, seeThroughTexture);
								material5.SetFloat(ShaderParams.SeeThroughTextureScale, seeThroughTextureScale);
								switch (seeThroughTextureUVSpace)
								{
								case TextureUVSpace.ScreenSpace:
									material5.EnableKeyword("HP_TEXTURE_SCREENSPACE");
									break;
								case TextureUVSpace.ObjectSpace:
									material5.EnableKeyword("HP_TEXTURE_OBJECTSPACE");
									break;
								default:
									material5.EnableKeyword("HP_TEXTURE_TRIPLANAR");
									break;
								}
							}
						}
					}
					if (flag4)
					{
						Material material6 = rms[j].fxMatSeeThroughBorder[k];
						if (material6 != null)
						{
							material6.SetColor(ShaderParams.SeeThroughBorderColor, new Color(seeThroughBorderColor.r, seeThroughBorderColor.g, seeThroughBorderColor.b, seeThroughBorder));
							material6.SetFloat(ShaderParams.SeeThroughBorderWidth, (seeThroughBorder * seeThroughBorderWidth > 0f) ? (seeThroughBorderWidth / 100f) : 0f);
							material6.SetFloat(ShaderParams.SeeThroughBorderConstantWidth, constantWidth ? 1f : 0f);
							material6.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
							if (seeThroughOccluderMaskAccurate && (int)seeThroughOccluderMask != -1)
							{
								material6.SetInt(ShaderParams.SeeThroughStencilRef, 1);
								material6.SetInt(ShaderParams.SeeThroughStencilComp, 3);
								material6.SetInt(ShaderParams.SeeThroughStencilPassOp, 1);
							}
							else
							{
								material6.SetInt(ShaderParams.SeeThroughStencilRef, 2);
								material6.SetInt(ShaderParams.SeeThroughStencilComp, 5);
								material6.SetInt(ShaderParams.SeeThroughStencilPassOp, 0);
							}
							material6.mainTexture = texture;
							material6.mainTextureOffset = mainTextureOffset;
							material6.mainTextureScale = mainTextureScale;
							if (flag3)
							{
								material6.SetFloat(ShaderParams.CutOff, alphaCutOff);
								material6.EnableKeyword("HP_ALPHACLIP");
							}
							else
							{
								material6.DisableKeyword("HP_ALPHACLIP");
							}
							if (seeThroughDepthOffset > 0f || seeThroughMaxDepth > 0f)
							{
								material6.SetFloat(ShaderParams.SeeThroughDepthOffset, (seeThroughDepthOffset > 0f) ? seeThroughDepthOffset : (-1f));
								material6.SetFloat(ShaderParams.SeeThroughMaxDepth, (seeThroughMaxDepth > 0f) ? seeThroughMaxDepth : 999999f);
								material6.EnableKeyword("HP_DEPTH_OFFSET");
							}
							else
							{
								material6.DisableKeyword("HP_DEPTH_OFFSET");
							}
						}
					}
					if (rms[j].fxMatOverlay != null && rms[j].fxMatOverlay.Length > k)
					{
						Material material7 = rms[j].fxMatOverlay[k];
						if (material7 != null)
						{
							material7.mainTexture = texture;
							material7.mainTextureOffset = mainTextureOffset;
							material7.mainTextureScale = mainTextureScale;
							if (material.HasProperty(ShaderParams.Color))
							{
								material7.SetColor(ShaderParams.OverlayBackColor, material.GetColor(ShaderParams.Color));
							}
							material7.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
							material7.SetInt(ShaderParams.OverlayZTest, GetZTestValue(overlayVisibility));
							material7.DisableKeyword("HP_TEXTURE_TRIPLANAR");
							material7.DisableKeyword("HP_TEXTURE_OBJECTSPACE");
							material7.DisableKeyword("HP_TEXTURE_SCREENSPACE");
							if (overlayTexture != null)
							{
								material7.SetTexture(ShaderParams.OverlayTexture, overlayTexture);
								material7.SetVector(ShaderParams.OverlayTextureScrolling, overlayTextureScrolling);
								switch (overlayTextureUVSpace)
								{
								case TextureUVSpace.ScreenSpace:
									material7.EnableKeyword("HP_TEXTURE_SCREENSPACE");
									break;
								case TextureUVSpace.ObjectSpace:
									material7.EnableKeyword("HP_TEXTURE_OBJECTSPACE");
									break;
								default:
									material7.EnableKeyword("HP_TEXTURE_TRIPLANAR");
									break;
								}
							}
							if (flag3)
							{
								material7.SetFloat(ShaderParams.CutOff, alphaCutOff);
								material7.EnableKeyword("HP_ALPHACLIP");
							}
							else
							{
								material7.DisableKeyword("HP_ALPHACLIP");
							}
						}
					}
					if (rms[j].fxMatInnerGlow != null && rms[j].fxMatInnerGlow.Length > k)
					{
						Material material8 = rms[j].fxMatInnerGlow[k];
						if (material8 != null)
						{
							material8.mainTexture = texture;
							material8.mainTextureOffset = mainTextureOffset;
							material8.mainTextureScale = mainTextureScale;
							material8.SetFloat(ShaderParams.InnerGlowWidth, innerGlowWidth);
							material8.SetInt(ShaderParams.InnerGlowZTest, GetZTestValue(innerGlowVisibility));
							material8.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
							material8.SetInt(ShaderParams.InnerGlowBlendMode, (innerGlowBlendMode == InnerGlowBlendMode.Additive) ? 1 : 10);
							if (flag3)
							{
								material8.SetFloat(ShaderParams.CutOff, alphaCutOff);
								material8.EnableKeyword("HP_ALPHACLIP");
							}
							else
							{
								material8.DisableKeyword("HP_ALPHACLIP");
							}
						}
					}
					if (rms[j].fxMatSolidColor == null || rms[j].fxMatSolidColor.Length <= k)
					{
						continue;
					}
					Material material9 = rms[j].fxMatSolidColor[k];
					if (material9 != null)
					{
						material9.color = glowHQColor;
						material9.SetInt(ShaderParams.Cull, cullBackFaces ? 2 : 0);
						material9.SetFloat(ShaderParams.Padding, padding);
						material9.SetFloat(ShaderParams.OutlineEdgeThreshold, outlineEdgeThreshold);
						material9.mainTexture = texture;
						material9.mainTextureOffset = mainTextureOffset;
						material9.mainTextureScale = mainTextureScale;
						if ((glow > 0f && glowQuality == QualityLevel.Highest && glowVisibility == Visibility.Normal) || (outline > 0f && outlineQuality == QualityLevel.Highest && outlineVisibility == Visibility.Normal))
						{
							material9.DisableKeyword("HP_DEPTHCLIP_INV");
							material9.EnableKeyword("HP_DEPTHCLIP");
						}
						else if ((glow > 0f && glowQuality == QualityLevel.Highest && glowVisibility == Visibility.OnlyWhenOccluded) || (outline > 0f && outlineQuality == QualityLevel.Highest && outlineVisibility == Visibility.OnlyWhenOccluded))
						{
							material9.DisableKeyword("HP_DEPTHCLIP");
							material9.EnableKeyword("HP_DEPTHCLIP_INV");
						}
						else
						{
							material9.DisableKeyword("HP_DEPTHCLIP");
							material9.DisableKeyword("HP_DEPTHCLIP_INV");
						}
						if (flag3)
						{
							material9.SetFloat(ShaderParams.CutOff, alphaCutOff);
							material9.EnableKeyword("HP_ALPHACLIP");
						}
						else
						{
							material9.DisableKeyword("HP_ALPHACLIP");
						}
						if (outlineEdgeMode == OutlineEdgeMode.Any)
						{
							material9.EnableKeyword("HP_ALL_EDGES");
						}
						else
						{
							material9.DisableKeyword("HP_ALL_EDGES");
						}
					}
				}
			}
		}

		private int MaterialsRenderQueueComparer(ModelMaterials m1, ModelMaterials m2)
		{
			Material material = ((m1.renderer != null) ? m1.renderer.sharedMaterial : null);
			Material material2 = ((m2.renderer != null) ? m2.renderer.sharedMaterial : null);
			int num = ((material != null) ? material.renderQueue : 0);
			int value = ((material2 != null) ? material2.renderQueue : 0);
			return num.CompareTo(value);
		}

		private int MaterialsRenderQueueInvertedComparer(ModelMaterials m1, ModelMaterials m2)
		{
			Material material = ((m1.renderer != null) ? m1.renderer.sharedMaterial : null);
			Material material2 = ((m2.renderer != null) ? m2.renderer.sharedMaterial : null);
			int value = ((material != null) ? material.renderQueue : 0);
			return ((material2 != null) ? material2.renderQueue : 0).CompareTo(value);
		}

		private float ComputeCameraDistanceFade(Vector3 position, Transform cameraTransform)
		{
			float num = Vector3.Dot(position - cameraTransform.position, cameraTransform.forward);
			if (num < cameraDistanceFadeNear)
			{
				return 1f - Mathf.Min(1f, cameraDistanceFadeNear - num);
			}
			if (num > cameraDistanceFadeFar)
			{
				return 1f - Mathf.Min(1f, num - cameraDistanceFadeFar);
			}
			return 1f;
		}

		private int GetZTestValue(Visibility param)
		{
			return param switch
			{
				Visibility.AlwaysOnTop => 8, 
				Visibility.OnlyWhenOccluded => 5, 
				_ => 4, 
			};
		}

		private void BuildQuad()
		{
			quadMesh = new Mesh();
			Vector3[] array = new Vector3[4];
			float num = 0.5f;
			float num2 = 0.5f;
			array[0] = new Vector3(0f - num2, 0f - num, 0f);
			array[1] = new Vector3(0f - num2, num, 0f);
			array[2] = new Vector3(num2, 0f - num, 0f);
			array[3] = new Vector3(num2, num, 0f);
			Vector2[] array2 = new Vector2[array.Length];
			array2[0] = new Vector2(0f, 0f);
			array2[1] = new Vector2(0f, 1f);
			array2[2] = new Vector2(1f, 0f);
			array2[3] = new Vector2(1f, 1f);
			int[] triangles = new int[6] { 0, 1, 2, 3, 2, 1 };
			Vector3[] array3 = new Vector3[array.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = Vector3.forward;
			}
			quadMesh.vertices = array;
			quadMesh.uv = array2;
			quadMesh.triangles = triangles;
			quadMesh.normals = array3;
			quadMesh.RecalculateBounds();
		}

		private void BuildCube()
		{
			cubeMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
		}

		public bool Includes(Transform transform)
		{
			for (int i = 0; i < rmsCount; i++)
			{
				if (rms[i].transform == transform)
				{
					return true;
				}
			}
			return false;
		}

		public void SetGlowColor(Color color)
		{
			if (glowPasses != null)
			{
				for (int i = 0; i < glowPasses.Length; i++)
				{
					glowPasses[i].color = color;
				}
			}
			glowHQColor = color;
			UpdateMaterialProperties();
		}

		private void AverageNormals(int objIndex)
		{
			if (rms == null || objIndex >= rms.Length)
			{
				return;
			}
			Mesh mesh = rms[objIndex].mesh;
			int hashCode = mesh.GetHashCode();
			if (!smoothMeshes.TryGetValue(hashCode, out var value) || value == null)
			{
				if (!mesh.isReadable)
				{
					return;
				}
				if (normals == null)
				{
					normals = new List<Vector3>();
				}
				else
				{
					normals.Clear();
				}
				mesh.GetNormals(normals);
				int count = normals.Count;
				if (count == 0)
				{
					return;
				}
				if (vertices == null)
				{
					vertices = new List<Vector3>();
				}
				else
				{
					vertices.Clear();
				}
				mesh.GetVertices(vertices);
				int num = vertices.Count;
				if (count < num)
				{
					num = count;
				}
				if (newNormals == null || newNormals.Length < num)
				{
					newNormals = new Vector3[num];
				}
				else
				{
					Vector3 zero = Vector3.zero;
					for (int i = 0; i < num; i++)
					{
						newNormals[i] = zero;
					}
				}
				if (matches == null || matches.Length < num)
				{
					matches = new int[num];
				}
				vv.Clear();
				for (int j = 0; j < num; j++)
				{
					Vector3 key = vertices[j];
					if (!vv.TryGetValue(key, out var value2))
					{
						value2 = (vv[key] = j);
					}
					matches[j] = value2;
				}
				for (int k = 0; k < num; k++)
				{
					int num3 = matches[k];
					newNormals[num3] += normals[k];
				}
				for (int l = 0; l < num; l++)
				{
					int num4 = matches[l];
					normals[l] = newNormals[num4].normalized;
				}
				value = UnityEngine.Object.Instantiate(mesh);
				value.SetNormals(normals);
				smoothMeshes[hashCode] = value;
				IncrementeMeshUsage(value);
			}
			rms[objIndex].mesh = value;
		}

		private void ReorientNormals(int objIndex)
		{
			if (rms == null || objIndex >= rms.Length)
			{
				return;
			}
			Mesh mesh = rms[objIndex].mesh;
			int hashCode = mesh.GetHashCode();
			if (!reorientedMeshes.TryGetValue(hashCode, out var value) || value == null)
			{
				if (!mesh.isReadable)
				{
					return;
				}
				if (normals == null)
				{
					normals = new List<Vector3>();
				}
				else
				{
					normals.Clear();
				}
				if (vertices == null)
				{
					vertices = new List<Vector3>();
				}
				else
				{
					vertices.Clear();
				}
				mesh.GetVertices(vertices);
				int count = vertices.Count;
				if (count == 0)
				{
					return;
				}
				Vector3 zero = Vector3.zero;
				for (int i = 0; i < count; i++)
				{
					zero += vertices[i];
				}
				zero /= (float)count;
				for (int j = 0; j < count; j++)
				{
					normals.Add((vertices[j] - zero).normalized);
				}
				value = UnityEngine.Object.Instantiate(mesh);
				value.SetNormals(normals);
				reorientedMeshes[hashCode] = value;
				IncrementeMeshUsage(value);
			}
			rms[objIndex].mesh = value;
		}

		private void CombineMeshes()
		{
			if (rmsCount <= 1)
			{
				return;
			}
			if (combineInstances == null || combineInstances.Length != rmsCount)
			{
				combineInstances = new CombineInstance[rmsCount];
			}
			int num = -1;
			int num2 = 0;
			combinedMeshesHashId = 0;
			int num3 = 0;
			Matrix4x4 matrix4x = Matrix4x4.identity;
			for (int i = 0; i < rmsCount; i++)
			{
				combineInstances[i].mesh = null;
				if (rms[i].isSkinnedMesh)
				{
					continue;
				}
				Mesh mesh = rms[i].mesh;
				if (!(mesh == null) && mesh.isReadable)
				{
					num3 += mesh.vertexCount;
					combineInstances[num2].mesh = mesh;
					int instanceID = rms[i].renderer.gameObject.GetInstanceID();
					if (num < 0)
					{
						num = i;
						combinedMeshesHashId = instanceID;
						matrix4x = rms[i].transform.worldToLocalMatrix;
					}
					else
					{
						combinedMeshesHashId ^= instanceID;
						rms[i].mesh = null;
					}
					combineInstances[num2].transform = matrix4x * rms[i].transform.localToWorldMatrix;
					num2++;
				}
			}
			if (num2 < 2)
			{
				return;
			}
			if (num2 != rmsCount)
			{
				Array.Resize(ref combineInstances, num2);
			}
			if (!combinedMeshes.TryGetValue(combinedMeshesHashId, out var value) || value == null)
			{
				value = new Mesh();
				if (num3 > 65535)
				{
					value.indexFormat = IndexFormat.UInt32;
				}
				value.CombineMeshes(combineInstances, mergeSubMeshes: true, useMatrices: true);
				combinedMeshes[combinedMeshesHashId] = value;
				IncrementeMeshUsage(value);
			}
			rms[num].mesh = value;
			rms[num].isCombined = true;
		}

		public string ValidateCombineMeshes()
		{
			if (rms == null)
			{
				return "No objects to combine.";
			}
			ModelMaterials[] array = rms;
			for (int i = 0; i < array.Length; i++)
			{
				ModelMaterials modelMaterials = array[i];
				if (!modelMaterials.isSkinnedMesh && modelMaterials.mesh != null && !modelMaterials.mesh.isReadable)
				{
					return "The mesh of object " + modelMaterials.renderer.name + " is not readable and can't be combined (check mesh's import settings).";
				}
			}
			return null;
		}

		private void IncrementeMeshUsage(Mesh mesh)
		{
			sharedMeshUsage.TryGetValue(mesh, out var value);
			value++;
			sharedMeshUsage[mesh] = value;
			instancedMeshes.Add(mesh);
		}

		public static void ClearMeshCache()
		{
			foreach (Mesh value in combinedMeshes.Values)
			{
				if (value != null)
				{
					UnityEngine.Object.DestroyImmediate(value);
				}
			}
			foreach (Mesh value2 in smoothMeshes.Values)
			{
				if (value2 != null)
				{
					UnityEngine.Object.DestroyImmediate(value2);
				}
			}
			foreach (Mesh value3 in reorientedMeshes.Values)
			{
				if (value3 != null)
				{
					UnityEngine.Object.DestroyImmediate(value3);
				}
			}
		}

		private void RefreshCachedMeshes()
		{
			if (combinedMeshes.TryGetValue(combinedMeshesHashId, out var value))
			{
				UnityEngine.Object.DestroyImmediate(value);
				combinedMeshes.Remove(combinedMeshesHashId);
			}
			if (rms == null)
			{
				return;
			}
			for (int i = 0; i < rms.Length; i++)
			{
				Mesh mesh = rms[i].mesh;
				if (mesh != null && (smoothMeshes.ContainsValue(mesh) || reorientedMeshes.ContainsValue(mesh)))
				{
					UnityEngine.Object.DestroyImmediate(mesh);
				}
			}
		}

		public static float GetTime()
		{
			if (!useUnscaledTime)
			{
				return Time.time;
			}
			return Time.unscaledTime;
		}

		public void HitFX()
		{
			HitFX(hitFxColor, hitFxFadeOutDuration, hitFxInitialIntensity);
		}

		public void HitFX(Vector3 position)
		{
			HitFX(hitFxColor, hitFxFadeOutDuration, hitFxInitialIntensity, position, hitFxRadius);
		}

		public void HitFX(Color color, float fadeOutDuration, float initialIntensity = 1f)
		{
			hitInitialIntensity = initialIntensity;
			hitFadeOutDuration = fadeOutDuration;
			hitColor = color;
			hitStartTime = GetTime();
			hitActive = true;
			if (overlay == 0f)
			{
				UpdateMaterialProperties();
			}
		}

		public void HitFX(Color color, float fadeOutDuration, float initialIntensity, Vector3 position, float radius)
		{
			hitInitialIntensity = initialIntensity;
			hitFadeOutDuration = fadeOutDuration;
			hitColor = color;
			hitStartTime = GetTime();
			hitActive = true;
			hitPosition = position;
			hitRadius = radius;
			if (overlay == 0f)
			{
				UpdateMaterialProperties();
			}
		}

		public void TargetFX()
		{
			targetFXStartTime = GetTime();
			if (!_highlighted)
			{
				highlighted = true;
			}
			if (!targetFX)
			{
				targetFX = true;
				UpdateMaterialProperties();
			}
		}

		public void IconFX()
		{
			iconFXStartTime = GetTime();
			if (!_highlighted)
			{
				highlighted = true;
			}
			if (!iconFX)
			{
				iconFX = true;
				UpdateMaterialProperties();
			}
		}

		public bool IsSeeThroughOccluded(Camera cam)
		{
			if (rms == null)
			{
				return false;
			}
			Bounds bounds = default(Bounds);
			for (int i = 0; i < rms.Length; i++)
			{
				if (rms[i].renderer != null)
				{
					if (bounds.size.x == 0f)
					{
						bounds = rms[i].renderer.bounds;
					}
					else
					{
						bounds.Encapsulate(rms[i].renderer.bounds);
					}
				}
			}
			Vector3 center = bounds.center;
			Vector3 position = cam.transform.position;
			Vector3 vector = center - position;
			float maxDistance = Vector3.Distance(center, position);
			if (hits == null || hits.Length == 0)
			{
				hits = new RaycastHit[64];
			}
			int count = occluders.Count;
			int num = Physics.BoxCastNonAlloc(center - vector, bounds.extents * 0.9f, vector.normalized, hits, Quaternion.identity, maxDistance);
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < count; k++)
				{
					if (hits[j].collider.transform == occluders[k].transform)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static void RegisterOccluder(HighlightSeeThroughOccluder occluder)
		{
			if (!occluders.Contains(occluder))
			{
				occluders.Add(occluder);
			}
		}

		public static void UnregisterOccluder(HighlightSeeThroughOccluder occluder)
		{
			if (occluders.Contains(occluder))
			{
				occluders.Remove(occluder);
			}
		}

		public bool RenderSeeThroughOccluders(CommandBuffer cb, Camera cam)
		{
			int count = occluders.Count;
			if (count == 0 || rmsCount == 0)
			{
				return true;
			}
			bool flag = false;
			for (int i = 0; i < count; i++)
			{
				HighlightSeeThroughOccluder highlightSeeThroughOccluder = occluders[i];
				if (!(highlightSeeThroughOccluder == null) && highlightSeeThroughOccluder.isActiveAndEnabled && highlightSeeThroughOccluder.mode == OccluderMode.BlocksSeeThrough && highlightSeeThroughOccluder.detectionMethod == DetectionMethod.RayCast)
				{
					flag = true;
					break;
				}
			}
			if (flag && IsSeeThroughOccluded(cam))
			{
				return false;
			}
			occludersFrameCount.TryGetValue(cam, out var value);
			int frameCount = Time.frameCount;
			if (frameCount == value)
			{
				return true;
			}
			occludersFrameCount[cam] = frameCount;
			if (fxMatSeeThroughOccluder == null)
			{
				InitMaterial(ref fxMatSeeThroughOccluder, "HighlightPlus/Geometry/SeeThroughOccluder");
				if (fxMatSeeThroughOccluder == null)
				{
					return true;
				}
			}
			if (fxMatDepthWrite == null)
			{
				InitMaterial(ref fxMatDepthWrite, "HighlightPlus/Geometry/JustDepth");
				if (fxMatDepthWrite == null)
				{
					return true;
				}
			}
			for (int j = 0; j < count; j++)
			{
				HighlightSeeThroughOccluder highlightSeeThroughOccluder2 = occluders[j];
				if (highlightSeeThroughOccluder2 == null || !highlightSeeThroughOccluder2.isActiveAndEnabled || highlightSeeThroughOccluder2.detectionMethod != DetectionMethod.Stencil || highlightSeeThroughOccluder2.meshData == null)
				{
					continue;
				}
				int num = highlightSeeThroughOccluder2.meshData.Length;
				for (int k = 0; k < num; k++)
				{
					Renderer renderer = highlightSeeThroughOccluder2.meshData[k].renderer;
					if (renderer.isVisible)
					{
						for (int l = 0; l < highlightSeeThroughOccluder2.meshData[k].subMeshCount; l++)
						{
							cb.DrawRenderer(renderer, (highlightSeeThroughOccluder2.mode == OccluderMode.BlocksSeeThrough) ? fxMatSeeThroughOccluder : fxMatDepthWrite, l);
						}
					}
				}
			}
			return true;
		}

		private bool CheckOcclusion(Camera cam)
		{
			if (!perCameraOcclusionData.TryGetValue(cam, out var value))
			{
				value = new PerCameraOcclusionData();
				perCameraOcclusionData[cam] = value;
			}
			float time = GetTime();
			int frameCount = Time.frameCount;
			if (time - value.checkLastTime < seeThroughOccluderCheckInterval && Application.isPlaying && value.occlusionRenderFrame != frameCount)
			{
				return value.lastOcclusionTestResult;
			}
			value.cachedOccluders.Clear();
			value.cachedOccluderCollider = null;
			if (rms == null || rms.Length == 0 || rms[0].renderer == null)
			{
				return false;
			}
			value.checkLastTime = time;
			value.occlusionRenderFrame = frameCount;
			Vector3 position = cam.transform.position;
			if (seeThroughOccluderCheckIndividualObjects)
			{
				for (int i = 0; i < rms.Length; i++)
				{
					if (rms[i].renderer != null)
					{
						Bounds bounds = rms[i].renderer.bounds;
						Vector3 center = bounds.center;
						float maxDistance = Vector3.Distance(center, position);
						if (Physics.BoxCast(center, bounds.extents * seeThroughOccluderThreshold, (position - center).normalized, out var hitInfo, Quaternion.identity, maxDistance, seeThroughOccluderMask))
						{
							value.cachedOccluderCollider = hitInfo.collider;
							value.lastOcclusionTestResult = true;
							return true;
						}
					}
				}
				value.lastOcclusionTestResult = false;
				return false;
			}
			Bounds bounds2 = rms[0].renderer.bounds;
			for (int j = 1; j < rms.Length; j++)
			{
				if (rms[j].renderer != null)
				{
					bounds2.Encapsulate(rms[j].renderer.bounds);
				}
			}
			Vector3 center2 = bounds2.center;
			float maxDistance2 = Vector3.Distance(center2, position);
			value.lastOcclusionTestResult = Physics.BoxCast(center2, bounds2.extents * seeThroughOccluderThreshold, (position - center2).normalized, out var hitInfo2, Quaternion.identity, maxDistance2, seeThroughOccluderMask);
			value.cachedOccluderCollider = hitInfo2.collider;
			return value.lastOcclusionTestResult;
		}

		private void AddWithoutRepetition(List<Renderer> target, List<Renderer> source, LayerMask layerMask)
		{
			int count = source.Count;
			for (int i = 0; i < count; i++)
			{
				Renderer renderer = source[i];
				if (renderer != null && !target.Contains(renderer) && ValidRenderer(renderer) && ((1 << renderer.gameObject.layer) & (int)layerMask) != 0)
				{
					target.Add(renderer);
				}
			}
		}

		private void CheckOcclusionAccurate(CommandBuffer cbuf, Camera cam)
		{
			if (!perCameraOcclusionData.TryGetValue(cam, out var value))
			{
				value = new PerCameraOcclusionData();
				perCameraOcclusionData[cam] = value;
			}
			float time = GetTime();
			int frameCount = Time.frameCount;
			if (!(time - value.checkLastTime < seeThroughOccluderCheckInterval) || !Application.isPlaying || value.occlusionRenderFrame == frameCount)
			{
				value.cachedOccluders.Clear();
				value.cachedOccluderCollider = null;
				if (rms == null || rms.Length == 0 || rms[0].renderer == null)
				{
					return;
				}
				value.checkLastTime = time;
				value.occlusionRenderFrame = frameCount;
				Quaternion identity = Quaternion.identity;
				Vector3 position = cam.transform.position;
				if (occluderHits == null || occluderHits.Length < 50)
				{
					occluderHits = new RaycastHit[50];
				}
				if (seeThroughOccluderCheckIndividualObjects)
				{
					for (int i = 0; i < rms.Length; i++)
					{
						if (rms[i].renderer != null)
						{
							Bounds bounds = rms[i].renderer.bounds;
							Vector3 center = bounds.center;
							float maxDistance = Vector3.Distance(center, position);
							int num = Physics.BoxCastNonAlloc(center, bounds.extents * seeThroughOccluderThreshold, (position - center).normalized, occluderHits, identity, maxDistance, seeThroughOccluderMask);
							for (int j = 0; j < num; j++)
							{
								occluderHits[j].collider.transform.root.GetComponentsInChildren(tempRR);
								AddWithoutRepetition(value.cachedOccluders, tempRR, seeThroughOccluderMask);
							}
						}
					}
				}
				else
				{
					Bounds bounds2 = rms[0].renderer.bounds;
					for (int k = 1; k < rms.Length; k++)
					{
						if (rms[k].renderer != null)
						{
							bounds2.Encapsulate(rms[k].renderer.bounds);
						}
					}
					Vector3 center2 = bounds2.center;
					float maxDistance2 = Vector3.Distance(center2, position);
					int num2 = Physics.BoxCastNonAlloc(center2, bounds2.extents * seeThroughOccluderThreshold, (position - center2).normalized, occluderHits, identity, maxDistance2, seeThroughOccluderMask);
					for (int l = 0; l < num2; l++)
					{
						occluderHits[l].collider.transform.root.GetComponentsInChildren(tempRR);
						AddWithoutRepetition(value.cachedOccluders, tempRR, seeThroughOccluderMask);
					}
				}
			}
			int count = value.cachedOccluders.Count;
			if (count <= 0)
			{
				return;
			}
			for (int m = 0; m < count; m++)
			{
				Renderer renderer = value.cachedOccluders[m];
				if (renderer != null)
				{
					cbuf.DrawRenderer(renderer, fxMatSeeThroughMask);
				}
			}
		}

		public void GetOccluders(Camera camera, List<Transform> occluders)
		{
			occluders.Clear();
			if (!perCameraOcclusionData.TryGetValue(camera, out var value))
			{
				return;
			}
			if (value.cachedOccluderCollider != null)
			{
				occluders.Add(value.cachedOccluderCollider.transform);
				return;
			}
			foreach (Renderer cachedOccluder in value.cachedOccluders)
			{
				if (cachedOccluder != null)
				{
					occluders.Add(cachedOccluder.transform);
				}
			}
		}
	}
}
