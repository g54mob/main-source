using UnityEngine;

namespace MK.Toon
{
	public static class Properties
	{
		internal static readonly string shaderComponentOutlineName;

		internal static readonly string shaderComponentRefractionName;

		internal static readonly string shaderVariantPBSName;

		internal static readonly string shaderVariantSimpleName;

		internal static readonly string shaderVariantUnlitName;

		public static readonly EnumProperty<Workflow> workflow;

		public static readonly EnumProperty<RenderFace> renderFace;

		public static readonly SurfaceProperty surface;

		public static readonly EnumProperty<ZWrite> zWrite;

		public static readonly EnumProperty<ZTest> zTest;

		public static readonly EnumProperty<BlendFactor> blendSrc;

		public static readonly EnumProperty<BlendFactor> blendDst;

		public static readonly BlendProperty blend;

		public static readonly AlphaClippingProperty alphaClipping;

		public static readonly ColorProperty albedoColor;

		public static readonly RangeProperty alphaCutoff;

		public static readonly TextureProperty albedoMap;

		public static readonly TilingProperty mainTiling;

		public static readonly OffsetProperty mainOffset;

		public static readonly ColorProperty specularColor;

		public static readonly RangeProperty metallic;

		public static readonly RangeProperty smoothness;

		public static readonly RangeProperty roughness;

		public static readonly TextureProperty specularMap;

		public static readonly TextureProperty roughnessMap;

		public static readonly TextureProperty metallicMap;

		public static readonly FloatProperty normalMapIntensity;

		public static readonly TextureProperty normalMap;

		public static readonly RangeProperty parallax;

		public static readonly TextureProperty heightMap;

		public static readonly EnumProperty<LightTransmission> lightTransmission;

		public static readonly RangeProperty lightTransmissionDistortion;

		public static readonly ColorProperty lightTransmissionColor;

		public static readonly TextureProperty thicknessMap;

		public static readonly RangeProperty occlusionMapIntensity;

		public static readonly TextureProperty occlusionMap;

		public static readonly ColorProperty emissionColor;

		public static readonly TextureProperty emissionMap;

		public static readonly EnumProperty<DetailBlend> detailBlend;

		public static readonly ColorProperty detailColor;

		public static readonly RangeProperty detailMix;

		public static readonly TextureProperty detailMap;

		public static readonly TilingProperty detailTiling;

		public static readonly OffsetProperty detailOffset;

		public static readonly FloatProperty detailNormalMapIntensity;

		public static readonly TextureProperty detailNormalMap;

		public static readonly BoolProperty receiveShadows;

		public static readonly BoolProperty wrappedLighting;

		public static readonly RangeProperty diffuseSmoothness;

		public static readonly RangeProperty diffuseThresholdOffset;

		public static readonly RangeProperty specularSmoothness;

		public static readonly RangeProperty specularThresholdOffset;

		public static readonly RangeProperty rimSmoothness;

		public static readonly RangeProperty rimThresholdOffset;

		public static readonly RangeProperty lightTransmissionSmoothness;

		public static readonly RangeProperty lightTransmissionThresholdOffset;

		public static readonly EnumProperty<Light> light;

		public static readonly TextureProperty diffuseRamp;

		public static readonly TextureProperty specularRamp;

		public static readonly TextureProperty rimRamp;

		public static readonly TextureProperty lightTransmissionRamp;

		public static readonly StepProperty lightBands;

		public static readonly RangeProperty lightBandsScale;

		public static readonly RangeProperty lightThreshold;

		public static readonly TextureProperty thresholdMap;

		public static readonly FloatProperty thresholdMapScale;

		public static readonly RangeProperty goochRampIntensity;

		public static readonly TextureProperty goochRamp;

		public static readonly ColorProperty goochBrightColor;

		public static readonly TextureProperty goochBrightMap;

		public static readonly ColorProperty goochDarkColor;

		public static readonly TextureProperty goochDarkMap;

		public static readonly EnumProperty<ColorGrading> colorGrading;

		public static readonly FloatProperty contrast;

		public static readonly RangeProperty saturation;

		public static readonly RangeProperty brightness;

		public static readonly EnumProperty<Iridescence> iridescence;

		public static readonly TextureProperty iridescenceRamp;

		public static readonly RangeProperty iridescenceSize;

		public static readonly RangeProperty iridescenceThresholdOffset;

		public static readonly RangeProperty iridescenceSmoothness;

		public static readonly ColorProperty iridescenceColor;

		public static readonly EnumProperty<Rim> rim;

		public static readonly ColorProperty rimColor;

		public static readonly ColorProperty rimBrightColor;

		public static readonly ColorProperty rimDarkColor;

		public static readonly RangeProperty rimSize;

		public static readonly EnumProperty<VertexAnimation> vertexAnimation;

		public static readonly BoolProperty vertexAnimationStutter;

		public static readonly TextureProperty vertexAnimationMap;

		public static readonly RangeProperty vertexAnimationIntensity;

		public static readonly Vector3Property vertexAnimationFrequency;

		public static readonly EnumProperty<Dissolve> dissolve;

		public static readonly TextureProperty dissolveMap;

		public static readonly FloatProperty dissolveMapScale;

		public static readonly RangeProperty dissolveAmount;

		public static readonly RangeProperty dissolveBorderSize;

		public static readonly TextureProperty dissolveBorderRamp;

		public static readonly ColorProperty dissolveBorderColor;

		public static readonly EnumProperty<Artistic> artistic;

		public static readonly EnumProperty<ArtisticProjection> artisticProjection;

		public static readonly RangeProperty artisticFrequency;

		public static readonly FloatProperty drawnMapScale;

		public static readonly TextureProperty drawnMap;

		public static readonly FloatProperty hatchingMapScale;

		public static readonly TextureProperty hatchingBrightMap;

		public static readonly TextureProperty hatchingDarkMap;

		public static readonly RangeProperty drawnClampMin;

		public static readonly RangeProperty drawnClampMax;

		public static readonly FloatProperty sketchMapScale;

		public static readonly TextureProperty sketchMap;

		public static readonly EnumProperty<Diffuse> diffuse;

		public static readonly SpecularProperty specular;

		public static readonly RangeProperty specularIntensity;

		public static readonly RangeProperty anisotropy;

		public static readonly RangeProperty lightTransmissionIntensity;

		public static readonly EnvironmentReflectionProperty environmentReflections;

		public static readonly BoolProperty fresnelHighlights;

		public static readonly BoolProperty indirectFade;

		public static readonly RenderPriorityProperty renderPriority;

		public static readonly StencilModeProperty stencil;

		public static readonly StepProperty stencilRef;

		public static readonly StepProperty stencilReadMask;

		public static readonly StepProperty stencilWriteMask;

		public static readonly EnumProperty<StencilComparison> stencilComp;

		public static readonly EnumProperty<StencilOperation> stencilPass;

		public static readonly EnumProperty<StencilOperation> stencilFail;

		public static readonly EnumProperty<StencilOperation> stencilZFail;

		public static readonly EnumProperty<Outline> outline;

		public static readonly EnumProperty<OutlineData> outlineData;

		public static readonly TextureProperty outlineMap;

		public static readonly RangeProperty outlineSize;

		public static readonly ColorProperty outlineColor;

		public static readonly RangeProperty outlineNoise;

		public static readonly FloatProperty refractionDistortionMapScale;

		public static readonly TextureProperty refractionDistortionMap;

		public static readonly FloatProperty refractionDistortion;

		public static readonly RangeProperty refractionDistortionFade;

		public static readonly RangeProperty indexOfRefraction;

		public static readonly BoolProperty flipbook;

		public static readonly BoolProperty softFade;

		public static readonly FloatProperty softFadeNearDistance;

		public static readonly FloatProperty softFadeFarDistance;

		public static readonly BoolProperty cameraFade;

		public static readonly FloatProperty cameraFadeNearDistance;

		public static readonly FloatProperty cameraFadeFarDistance;

		public static readonly EnumProperty<ColorBlend> colorBlend;

		public static void UpdateSystemProperties(Material material)
		{
		}
	}
}
