using UnityEngine;

namespace HighlightPlus
{
	[CreateAssetMenu(menuName = "Highlight Plus Profile", fileName = "Highlight Plus Profile", order = 100)]
	[HelpURL("https://www.dropbox.com/s/1p9h8xys68lm4a3/Documentation.pdf?dl=0")]
	public class HighlightProfile : ScriptableObject
	{
		[Tooltip("Different options to specify which objects are affected by this Highlight Effect component.")]
		public TargetOptions effectGroup;

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

		[Tooltip("Adds a empty margin between the mesh and the effects")]
		public float padding;

		[Tooltip("Normals handling option:\nPreserve original: use original mesh normals.\nSmooth: average normals to produce a smoother outline/glow mesh based effect.\nReorient: recomputes normals based on vertex direction to centroid.")]
		public NormalsOption normalsOption;

		public float fadeInDuration;

		public float fadeOutDuration;

		[Tooltip("Fades out effects based on distance to camera")]
		public bool cameraDistanceFade;

		[Tooltip("The closest distance particles can get to the camera before they fade from the camera’s view.")]
		public float cameraDistanceFadeNear;

		[Tooltip("The farthest distance particles can get away from the camera before they fade from the camera’s view.")]
		public float cameraDistanceFadeFar;

		[Tooltip("Keeps the outline/glow size unaffected by object distance.")]
		public bool constantWidth;

		[Tooltip("Increases the screen coverage for the outline/glow to avoid cuts when using cloth or vertex shader that transform mesh vertices")]
		public int extraCoveragePixels;

		[Tooltip("Minimum width when the constant width option is not used")]
		[Range(0f, 1f)]
		public float minimumWidth;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the overlay effect. A value of 0 disables the overlay completely.")]
		public float overlay;

		public OverlayMode overlayMode;

		[ColorUsage(true, true)]
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

		[Range(0f, 1f)]
		[Tooltip("Intensity of the outline. A value of 0 disables the outline completely.")]
		public float outline;

		[ColorUsage(true, true)]
		public Color outlineColor;

		public ColorStyle outlineColorStyle;

		[GradientUsage(true, ColorSpace.Linear)]
		public Gradient outlineGradient;

		public bool outlineGradientInLocalSpace;

		[Range(1f, 3f)]
		public int outlineBlurPasses;

		public float outlineWidth;

		public QualityLevel outlineQuality;

		public OutlineEdgeMode outlineEdgeMode;

		public float outlineEdgeThreshold;

		public float outlineSharpness;

		[Range(1f, 8f)]
		[Tooltip("Reduces the quality of the outline but improves performance a bit.")]
		public int outlineDownsampling;

		public ContourStyle outlineContourStyle;

		public Visibility outlineVisibility;

		[Tooltip("If enabled, this object won't combine the outline with other objects.")]
		public bool outlineIndependent;

		[Tooltip("Select the mask mode used with this effect.")]
		public MaskMode outlineMaskMode;

		[Range(0f, 5f)]
		[Tooltip("The intensity of the outer glow effect. A value of 0 disables the glow completely.")]
		public float glow;

		public float glowWidth;

		public QualityLevel glowQuality;

		public BlurMethod glowBlurMethod;

		[Range(1f, 8f)]
		[Tooltip("Reduces the quality of the glow but improves performance a bit.")]
		public int glowDownsampling;

		[ColorUsage(true, true)]
		public Color glowHQColor;

		[Tooltip("When enabled, outer glow renders with dithering. When disabled, glow appears as a solid color.")]
		[Range(0f, 1f)]
		public float glowDithering;

		public GlowDitheringStyle glowDitheringStyle;

		[Tooltip("Seed for the dithering effect")]
		public float glowMagicNumber1;

		[Tooltip("Another seed for the dithering effect that combines with first seed to create different patterns")]
		public float glowMagicNumber2;

		public float glowAnimationSpeed;

		public Visibility glowVisibility;

		public GlowBlendMode glowBlendMode;

		[Tooltip("Blends glow passes one after another. If this option is disabled, glow passes won't overlap (in this case, make sure the glow pass 1 has a smaller offset than pass 2, etc.)")]
		public bool glowBlendPasses;

		public GlowPassData[] glowPasses;

		[Tooltip("Select the mask mode used with this effect.")]
		public MaskMode glowMaskMode;

		[Range(0f, 5f)]
		[Tooltip("The intensity of the inner glow effect. A value of 0 disables the glow completely.")]
		public float innerGlow;

		[Range(0f, 2f)]
		public float innerGlowWidth;

		public InnerGlowBlendMode innerGlowBlendMode;

		[ColorUsage(true, true)]
		public Color innerGlowColor;

		public Visibility innerGlowVisibility;

		[Tooltip("Enables the targetFX effect. This effect draws an animated sprite over the object.")]
		public bool targetFX;

		public Texture2D targetFXTexture;

		[ColorUsage(true, true)]
		public Color targetFXColor;

		public float targetFXRotationSpeed;

		public float targetFXInitialScale;

		public float targetFXEndScale;

		[Tooltip("Makes target scale relative to object renderer bounds.")]
		public bool targetFXScaleToRenderBounds;

		[Tooltip("Places target FX sprite at the bottom of the highlighted object.")]
		public bool targetFXAlignToGround;

		[Tooltip("Max distance from the center of the highlighted object to the ground.")]
		public float targetFXGroundMaxDistance;

		public LayerMask targetFXGroundLayerMask;

		[Tooltip("Fade out effect with altitude")]
		public float targetFXFadePower;

		[Tooltip("Enable to render a single target FX effect at the center of the enclosing bounds")]
		public bool targetFXUseEnclosingBounds;

		[Tooltip("Optional world space offset for the position of the targetFX effect")]
		public Vector3 targetFXOffset;

		public float targetFXTransitionDuration;

		[Tooltip("0 = stay forever")]
		public float targetFXStayDuration;

		public Visibility targetFXVisibility;

		[Tooltip("Enables the iconFX effect. This effect draws an animated object over the object.")]
		public bool iconFX;

		public Mesh iconFXMesh;

		[ColorUsage(true, true)]
		public Color iconFXLightColor;

		[ColorUsage(true, true)]
		public Color iconFXDarkColor;

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

		[Tooltip("0 = stay forever")]
		public float iconFXStayDuration;

		[Tooltip("See-through mode for this Highlight Effect component.")]
		public SeeThroughMode seeThrough;

		[Tooltip("This mask setting let you specify which objects will be considered as occluders and cause the see-through effect for this Highlight Effect component. For example, you assign your walls to a different layer and specify that layer here, so only walls and not other objects, like ground or ceiling, will trigger the see-through effect.")]
		public LayerMask seeThroughOccluderMask;

		[Tooltip("Uses stencil buffers to ensure pixel-accurate occlusion test. If this option is disabled, only physics raycasting is used to test for occlusion.")]
		public bool seeThroughOccluderMaskAccurate;

		[Tooltip("A multiplier for the occluder volume size which can be used to reduce the actual size of occluders when Highlight Effect checks if they're occluding this object.")]
		[Range(0.01f, 0.9f)]
		public float seeThroughOccluderThreshold;

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

		public Color seeThroughTintColor;

		[Range(0f, 1f)]
		public float seeThroughNoise;

		[Range(0f, 1f)]
		public float seeThroughBorder;

		public Color seeThroughBorderColor;

		public float seeThroughBorderWidth;

		[Tooltip("Only display the border instead of the full see-through effect.")]
		public bool seeThroughBorderOnly;

		[Tooltip("This option clears the stencil buffer after rendering the see-through effect which results in correct rendering order and supports other stencil-based effects that render afterwards.")]
		public bool seeThroughOrdered;

		[Tooltip("Optional see-through mask effect texture.")]
		public Texture2D seeThroughTexture;

		public TextureUVSpace seeThroughTextureUVSpace;

		public float seeThroughTextureScale;

		[Tooltip("The order by which children objects are rendered by the see-through effect")]
		public SeeThroughSortingMode seeThroughChildrenSortingMode;

		[Range(0f, 1f)]
		public float hitFxInitialIntensity;

		public HitFxMode hitFxMode;

		public float hitFxFadeOutDuration;

		[ColorUsage(true, true)]
		public Color hitFxColor;

		public float hitFxRadius;

		public void Load(HighlightEffect effect)
		{
		}

		public void Save(HighlightEffect effect)
		{
		}

		private GlowPassData[] GetGlowPassesCopy(GlowPassData[] glowPasses)
		{
			return null;
		}

		public void OnValidate()
		{
		}
	}
}
