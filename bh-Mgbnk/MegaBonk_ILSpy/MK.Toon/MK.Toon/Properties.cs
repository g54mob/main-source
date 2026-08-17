using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

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

	public unsafe static void UpdateSystemProperties(Material material)
	{
		//IL_00a3: Expected O, but got Ref
		Uniform mainTex = Uniforms.mainTex;
		Texture value = albedoMap.GetValue(material);
		material.SetTextureImpl(mainTex._id, value);
		Uniform cutoff = Uniforms.cutoff;
		float value2 = alphaCutoff.GetValue(material);
		float value3 = default(float);
		material.SetFloat(cutoff._id, value3);
		Uniform color = Uniforms.color;
		Color value4 = albedoColor.GetValue(material);
		object obj = default(object);
		material.SetColor(color._id, (Color)(&obj));
	}

	static Properties()
	{
		//IL_0033: Expected O, but got I
		//IL_1353: Expected O, but got I
		//IL_00a1: Expected O, but got I
		//IL_00d6: Expected O, but got I
		//IL_010b: Expected O, but got I
		//IL_139b: Expected O, but got I
		//IL_13d1: Expected O, but got I
		//IL_13ef: Expected O, but got I
		//IL_1425: Expected O, but got I
		//IL_1457: Expected O, but got I
		//IL_1475: Expected O, but got I
		//IL_1493: Expected O, but got I
		//IL_14b1: Expected O, but got I
		//IL_14cf: Expected O, but got I
		//IL_14ed: Expected O, but got I
		//IL_150c: Expected O, but got I
		//IL_152a: Expected O, but got I
		//IL_1548: Expected O, but got I
		//IL_1566: Expected O, but got I
		//IL_1584: Expected O, but got I
		//IL_1607: Expected O, but got I
		//IL_099f: Expected F4, but got O
		//IL_1625: Expected O, but got I
		//IL_09b6: Expected F4, but got O
		//IL_165f: Expected O, but got I
		//IL_169a: Expected O, but got I
		//IL_16b8: Expected O, but got I
		//IL_16d7: Expected O, but got I
		//IL_16f5: Expected O, but got I
		//IL_1713: Expected O, but got I
		//IL_174a: Expected O, but got I
		//IL_1768: Expected O, but got I
		//IL_1786: Expected O, but got I
		//IL_17a4: Expected O, but got I
		//IL_0d06: Expected F4, but got O
		//IL_17d5: Expected O, but got I
		//IL_17f3: Expected O, but got I
		//IL_1811: Expected O, but got I
		//IL_182f: Expected O, but got I
		//IL_184d: Expected O, but got I
		//IL_186b: Expected O, but got I
		//IL_1889: Expected O, but got I
		//IL_18b0: Expected F4, but got O
		//IL_18c9: Expected O, but got I
		//IL_0ecd: Expected F4, but got O
		//IL_1903: Expected O, but got I
		//IL_1977: Expected O, but got I
		//IL_1995: Expected O, but got I
		//IL_19b3: Expected O, but got I
		//IL_19ed: Expected O, but got I
		//IL_1a27: Expected O, but got I
		//IL_0fad: Expected O, but got I
		//IL_0fe2: Expected O, but got I
		//IL_1017: Expected O, but got I
		//IL_104c: Expected O, but got I
		//IL_1112: Expected F4, but got O
		//IL_1a95: Expected O, but got I
		//IL_1ab4: Expected O, but got I
		//IL_1b02: Expected O, but got I
		//IL_12d6: Expected I, but got O
		//IL_1b40: Expected O, but got I
		//IL_1b40: Expected O, but got I
		shaderComponentOutlineName = "Outline";
		shaderComponentRefractionName = "Refraction";
		shaderVariantPBSName = "Physically Based";
		shaderVariantSimpleName = "Simple";
		shaderVariantUnlitName = "Unlit";
		((EnumProperty<Workflow>)0)._002Ector((Uniform)(object)(workflow = new EnumProperty<Workflow>(Uniforms.workflow, Keywords.workflow)), Keywords.workflow);
		EnumProperty<Workflow> keywords = default(EnumProperty<Workflow>);
		EnumProperty<RenderFace> enumProperty = new EnumProperty<RenderFace>(Uniforms.renderFace, (string[])(object)keywords);
		renderFace = enumProperty;
		((Property<Surface, bool>)0)._002Ector((Uniform)(object)(surface = new SurfaceProperty(Uniforms.surface, Keywords.surface)), Keywords.surface);
		Property<Surface, bool> keywords2 = default(Property<Surface, bool>);
		((EnumProperty<ZWrite>)0)._002Ector((Uniform)(object)(zWrite = new EnumProperty<ZWrite>(Uniforms.zWrite, (string[])(object)keywords2)), (string[])(object)keywords2);
		EnumProperty<ZWrite> keywords3 = default(EnumProperty<ZWrite>);
		((EnumProperty<ZTest>)0)._002Ector((Uniform)(object)(zTest = new EnumProperty<ZTest>(Uniforms.zTest, (string[])(object)keywords3)), (string[])(object)keywords3);
		EnumProperty<ZTest> keywords4 = default(EnumProperty<ZTest>);
		((EnumProperty<BlendFactor>)0)._002Ector((Uniform)(object)(blendSrc = new EnumProperty<BlendFactor>(Uniforms.blendSrc, (string[])(object)keywords4)), (string[])(object)keywords4);
		EnumProperty<BlendFactor> keywords5 = default(EnumProperty<BlendFactor>);
		EnumProperty<BlendFactor> enumProperty2 = new EnumProperty<BlendFactor>(Uniforms.blendDst, (string[])(object)keywords5);
		blendDst = enumProperty2;
		BlendProperty blendProperty = new BlendProperty(Uniforms.blend, Keywords.blend);
		blend = blendProperty;
		string[] keyword = default(string[]);
		AlphaClippingProperty alphaClippingProperty = new AlphaClippingProperty(Uniforms.alphaClipping, (string)(object)keyword);
		keyword = new string[1] { Keywords.alphaClipping };
		alphaClippingProperty._002Ector(Uniforms.alphaClipping, (string)(object)keyword);
		alphaClipping = alphaClippingProperty;
		Property<bool> keyword2 = default(Property<bool>);
		ColorProperty colorProperty = new ColorProperty(Uniforms.albedoColor, (string)(object)keyword2);
		((Property<bool>)0)._002Ector((Uniform)(object)alphaClippingProperty, keyword);
		albedoColor = colorProperty;
		RangeProperty rangeProperty = new RangeProperty(Uniforms.alphaCutoff, 0f, 1f);
		alphaCutoff = rangeProperty;
		TextureProperty textureProperty = new TextureProperty(Uniforms.albedoMap, Keywords.albedoMap);
		albedoMap = textureProperty;
		string[] keywords6 = default(string[]);
		TilingProperty uniform = (TilingProperty)new Property<Vector2>(Uniforms.albedoMap, keywords6);
		keywords6 = Array.Empty<string>();
		mainTiling = uniform;
		Property<Vector2> keywords7 = default(Property<Vector2>);
		OffsetProperty uniform2 = (OffsetProperty)new Property<Vector2>(Uniforms.albedoMap, (string[])(object)keywords7);
		((Property<Vector2>)0)._002Ector((Uniform)(object)uniform, keywords6);
		mainOffset = uniform2;
		Property<Vector2> keyword3 = default(Property<Vector2>);
		ColorProperty colorProperty2 = new ColorProperty(Uniforms.specularColor, (string)(object)keyword3);
		((Property<Vector2>)0)._002Ector((Uniform)(object)uniform2, (string[])(object)keywords7);
		specularColor = colorProperty2;
		RangeProperty rangeProperty2 = new RangeProperty(Uniforms.metallic, 0f, 1f);
		metallic = rangeProperty2;
		RangeProperty rangeProperty3 = new RangeProperty(Uniforms.smoothness, 0f, 1f);
		smoothness = rangeProperty3;
		RangeProperty rangeProperty4 = new RangeProperty(Uniforms.roughness, 0f, 1f);
		roughness = rangeProperty4;
		TextureProperty textureProperty2 = new TextureProperty(Uniforms.specularMap, Keywords.pbsMap0);
		specularMap = textureProperty2;
		TextureProperty textureProperty3 = new TextureProperty(Uniforms.roughnessMap, Keywords.pbsMap1);
		roughnessMap = textureProperty3;
		TextureProperty textureProperty4 = new TextureProperty(Uniforms.metallicMap, Keywords.pbsMap0);
		metallicMap = textureProperty4;
		string[] keywords8 = default(string[]);
		FloatProperty floatProperty = (FloatProperty)new Property<float>(Uniforms.normalMapIntensity, keywords8);
		keywords8 = Array.Empty<string>();
		normalMapIntensity = floatProperty;
		TextureProperty textureProperty5 = new TextureProperty(Uniforms.normalMap, Keywords.normalMap);
		normalMap = textureProperty5;
		float keywordDisabled = default(float);
		RangeProperty rangeProperty5 = new RangeProperty(Uniforms.parallax, Keywords.parallax, 0f, keywordDisabled);
		parallax = rangeProperty5;
		TextureProperty textureProperty6 = new TextureProperty(Uniforms.heightMap, Keywords.heightMap);
		heightMap = textureProperty6;
		string[] keywords9 = Array.Empty<string>();
		EnumProperty<LightTransmission> enumProperty3 = new EnumProperty<LightTransmission>(Uniforms.lightTransmission, keywords9);
		lightTransmission = enumProperty3;
		RangeProperty uniform3 = (lightTransmissionDistortion = new RangeProperty(Uniforms.lightTransmissionDistortion, 0f, 1f));
		EnumProperty<LightTransmission> keyword4 = default(EnumProperty<LightTransmission>);
		ColorProperty colorProperty3 = new ColorProperty(Uniforms.lightTransmissionColor, (string)(object)keyword4);
		((EnumProperty<LightTransmission>)0)._002Ector((Uniform)(object)uniform3, keywords9);
		lightTransmissionColor = colorProperty3;
		TextureProperty textureProperty7 = new TextureProperty(Uniforms.thicknessMap, Keywords.thicknessMap);
		thicknessMap = textureProperty7;
		RangeProperty rangeProperty6 = new RangeProperty(Uniforms.occlusionMapIntensity, 0f, 1f);
		occlusionMapIntensity = rangeProperty6;
		TextureProperty textureProperty8 = new TextureProperty(Uniforms.occlusionMap, Keywords.occlusionMap);
		occlusionMap = textureProperty8;
		string[] keyword5 = default(string[]);
		ColorProperty colorProperty4 = new ColorProperty(Uniforms.emissionColor, (string)(object)keyword5);
		keyword5 = new string[1] { Keywords.emission };
		emissionColor = colorProperty4;
		TextureProperty textureProperty9 = new TextureProperty(Uniforms.emissionMap, Keywords.emissionMap);
		emissionMap = textureProperty9;
		EnumProperty<DetailBlend> uniform4 = (detailBlend = new EnumProperty<DetailBlend>(Uniforms.detailBlend, Keywords.detailBlend));
		EnumProperty<DetailBlend> enumProperty4 = default(EnumProperty<DetailBlend>);
		ColorProperty colorProperty5 = new ColorProperty(Uniforms.detailColor, (string)(object)enumProperty4);
		((EnumProperty<DetailBlend>)0)._002Ector((Uniform)(object)uniform4, Keywords.detailBlend);
		detailColor = colorProperty5;
		RangeProperty uniform5 = (detailMix = new RangeProperty(Uniforms.detailMix, 0f, 1f));
		Property<Color> property = default(Property<Color>);
		TextureProperty uniform6 = new TextureProperty(Uniforms.detailMap, (string)(object)property);
		((Property<Color>)0)._002Ector((Uniform)(object)uniform5, (string[])(object)enumProperty4);
		detailMap = uniform6;
		Property<Texture> keywords10 = default(Property<Texture>);
		TilingProperty uniform7 = (TilingProperty)new Property<Vector2>(Uniforms.detailMap, (string[])(object)keywords10);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform6, (string[])(object)property);
		detailTiling = uniform7;
		Property<Vector2> keywords11 = default(Property<Vector2>);
		OffsetProperty uniform8 = (OffsetProperty)new Property<Vector2>(Uniforms.detailMap, (string[])(object)keywords11);
		((Property<Vector2>)0)._002Ector((Uniform)(object)uniform7, (string[])(object)keywords10);
		detailOffset = uniform8;
		Property<Vector2> keywords12 = default(Property<Vector2>);
		FloatProperty uniform9 = (FloatProperty)new Property<float>(Uniforms.detailNormalMapIntensity, (string[])(object)keywords12);
		((Property<Vector2>)0)._002Ector((Uniform)(object)uniform8, (string[])(object)keywords11);
		detailNormalMapIntensity = uniform9;
		Property<float> keyword6 = default(Property<float>);
		TextureProperty textureProperty10 = new TextureProperty(Uniforms.detailNormalMap, (string)(object)keyword6);
		((Property<float>)0)._002Ector((Uniform)(object)uniform9, (string[])(object)keywords12);
		detailNormalMap = textureProperty10;
		BoolProperty boolProperty = new BoolProperty(Uniforms.receiveShadows, Keywords.receiveShadows);
		receiveShadows = boolProperty;
		BoolProperty boolProperty2 = new BoolProperty(Uniforms.wrappedLighting, Keywords.wrappedLighting);
		wrappedLighting = boolProperty2;
		RangeProperty rangeProperty7 = new RangeProperty(Uniforms.diffuseSmoothness, 0f, 1f);
		diffuseSmoothness = rangeProperty7;
		RangeProperty rangeProperty8 = new RangeProperty(Uniforms.diffuseThresholdOffset, 0f, 1f);
		diffuseThresholdOffset = rangeProperty8;
		RangeProperty rangeProperty9 = new RangeProperty(Uniforms.specularSmoothness, 0f, 1f);
		specularSmoothness = rangeProperty9;
		RangeProperty rangeProperty10 = new RangeProperty(Uniforms.specularThresholdOffset, 0f, 1f);
		specularThresholdOffset = rangeProperty10;
		RangeProperty rangeProperty11 = new RangeProperty(Uniforms.rimSmoothness, 0f, 1f);
		rimSmoothness = rangeProperty11;
		RangeProperty rangeProperty12 = new RangeProperty(Uniforms.rimThresholdOffset, 0f, 1f);
		rimThresholdOffset = rangeProperty12;
		RangeProperty rangeProperty13 = new RangeProperty(Uniforms.lightTransmissionSmoothness, 0f, 1f);
		lightTransmissionSmoothness = rangeProperty13;
		RangeProperty rangeProperty14 = new RangeProperty(Uniforms.lightTransmissionThresholdOffset, 0f, 1f);
		lightTransmissionThresholdOffset = rangeProperty14;
		EnumProperty<Light> uniform10 = (light = new EnumProperty<Light>(Uniforms.light, Keywords.light));
		EnumProperty<Light> enumProperty5 = default(EnumProperty<Light>);
		TextureProperty uniform11 = new TextureProperty(Uniforms.diffuseRamp, (string)(object)enumProperty5);
		((EnumProperty<Light>)0)._002Ector((Uniform)(object)uniform10, Keywords.light);
		diffuseRamp = uniform11;
		Property<Texture> property2 = default(Property<Texture>);
		TextureProperty uniform12 = new TextureProperty(Uniforms.specularRamp, (string)(object)property2);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform11, (string[])(object)enumProperty5);
		specularRamp = uniform12;
		Property<Texture> property3 = default(Property<Texture>);
		TextureProperty uniform13 = new TextureProperty(Uniforms.rimRamp, (string)(object)property3);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform12, (string[])(object)property2);
		rimRamp = uniform13;
		Property<Texture> property4 = default(Property<Texture>);
		TextureProperty uniform14 = new TextureProperty(Uniforms.lightTransmissionRamp, (string)(object)property4);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform13, (string[])(object)property3);
		lightTransmissionRamp = uniform14;
		Property<Texture> keywords13 = default(Property<Texture>);
		StepProperty stepProperty = (StepProperty)new Property<int>(Uniforms.lightBands, (string[])(object)keywords13);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform14, (string[])(object)property4);
		stepProperty._minValue = 2;
		stepProperty._maxValue = 12;
		lightBands = stepProperty;
		RangeProperty rangeProperty15 = new RangeProperty(Uniforms.lightBandsScale, 0f, 1f);
		lightBandsScale = rangeProperty15;
		RangeProperty rangeProperty16 = new RangeProperty(Uniforms.lightThreshold, 0f, 1f);
		lightThreshold = rangeProperty16;
		TextureProperty textureProperty11 = new TextureProperty(Uniforms.thresholdMap, Keywords.thresholdMap);
		thresholdMap = textureProperty11;
		string[] keywords14 = default(string[]);
		FloatProperty floatProperty2 = (FloatProperty)new Property<float>(Uniforms.thresholdMapScale, keywords14);
		keywords14 = Array.Empty<string>();
		thresholdMapScale = floatProperty2;
		RangeProperty rangeProperty17 = new RangeProperty(Uniforms.goochRampIntensity, 0f, 1f);
		goochRampIntensity = rangeProperty17;
		TextureProperty textureProperty12 = new TextureProperty(Uniforms.goochRamp, Keywords.goochRamp);
		goochRamp = textureProperty12;
		string[] keyword7 = default(string[]);
		ColorProperty colorProperty6 = new ColorProperty(Uniforms.goochBrightColor, (string)(object)keyword7);
		keyword7 = Array.Empty<string>();
		goochBrightColor = colorProperty6;
		TextureProperty textureProperty13 = new TextureProperty(Uniforms.goochBrightMap, Keywords.goochBrightMap);
		goochBrightMap = textureProperty13;
		string[] keyword8 = default(string[]);
		ColorProperty colorProperty7 = new ColorProperty(Uniforms.goochDarkColor, (string)(object)keyword8);
		keyword8 = Array.Empty<string>();
		goochDarkColor = colorProperty7;
		TextureProperty textureProperty14 = new TextureProperty(Uniforms.goochDarkMap, Keywords.goochDarkMap);
		goochDarkMap = textureProperty14;
		EnumProperty<ColorGrading> uniform15 = (colorGrading = new EnumProperty<ColorGrading>(Uniforms.colorGrading, Keywords.colorGrading));
		EnumProperty<ColorGrading> keywords15 = default(EnumProperty<ColorGrading>);
		FloatProperty uniform16 = (FloatProperty)new Property<float>(Uniforms.contrast, (string[])(object)keywords15);
		((EnumProperty<ColorGrading>)0)._002Ector((Uniform)(object)uniform15, Keywords.colorGrading);
		contrast = uniform16;
		Property<float> property5 = default(Property<float>);
		RangeProperty rangeProperty18 = new RangeProperty(Uniforms.saturation, (float)property5);
		((Property<float>)0)._002Ector((Uniform)(object)uniform16, (string[])(object)keywords15);
		rangeProperty18._minValue = 0f;
		rangeProperty18._maxValue = 1f / 0f;
		saturation = rangeProperty18;
		Property<float> property6 = default(Property<float>);
		RangeProperty rangeProperty19 = new RangeProperty(Uniforms.brightness, (float)property6);
		((Property<float>)0)._002Ector((Uniform)(object)rangeProperty18, (string[])(object)property5);
		rangeProperty19._minValue = 0f;
		rangeProperty19._maxValue = 1f / 0f;
		brightness = rangeProperty19;
		EnumProperty<Iridescence> uniform17 = (iridescence = new EnumProperty<Iridescence>(Uniforms.iridescence, Keywords.iridescence));
		EnumProperty<Iridescence> enumProperty6 = default(EnumProperty<Iridescence>);
		TextureProperty textureProperty15 = new TextureProperty(Uniforms.iridescenceRamp, (string)(object)enumProperty6);
		((EnumProperty<Iridescence>)0)._002Ector((Uniform)(object)uniform17, Keywords.iridescence);
		iridescenceRamp = textureProperty15;
		RangeProperty rangeProperty20 = new RangeProperty(Uniforms.iridescenceSize, 0f, 5f);
		iridescenceSize = rangeProperty20;
		RangeProperty rangeProperty21 = new RangeProperty(Uniforms.iridescenceThresholdOffset, 0f, 1f);
		iridescenceThresholdOffset = rangeProperty21;
		RangeProperty uniform18 = (iridescenceSmoothness = new RangeProperty(Uniforms.iridescenceSmoothness, 0f, 1f));
		Property<Texture> keyword9 = default(Property<Texture>);
		ColorProperty colorProperty8 = new ColorProperty(Uniforms.iridescenceColor, (string)(object)keyword9);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform18, (string[])(object)enumProperty6);
		iridescenceColor = colorProperty8;
		EnumProperty<Rim> uniform19 = (rim = new EnumProperty<Rim>(Uniforms.rim, Keywords.rim));
		EnumProperty<Rim> enumProperty7 = default(EnumProperty<Rim>);
		ColorProperty uniform20 = new ColorProperty(Uniforms.rimColor, (string)(object)enumProperty7);
		((EnumProperty<Rim>)0)._002Ector((Uniform)(object)uniform19, Keywords.rim);
		rimColor = uniform20;
		Property<Color> property7 = default(Property<Color>);
		ColorProperty uniform21 = new ColorProperty(Uniforms.rimBrightColor, (string)(object)property7);
		((Property<Color>)0)._002Ector((Uniform)(object)uniform20, (string[])(object)enumProperty7);
		rimBrightColor = uniform21;
		Property<Color> keyword10 = default(Property<Color>);
		ColorProperty colorProperty9 = new ColorProperty(Uniforms.rimDarkColor, (string)(object)keyword10);
		((Property<Color>)0)._002Ector((Uniform)(object)uniform21, (string[])(object)property7);
		rimDarkColor = colorProperty9;
		RangeProperty rangeProperty22 = new RangeProperty(Uniforms.rimSize, 0f, 1f);
		rimSize = rangeProperty22;
		EnumProperty<VertexAnimation> enumProperty8 = new EnumProperty<VertexAnimation>(Uniforms.vertexAnimation, Keywords.vertexAnimation);
		vertexAnimation = enumProperty8;
		BoolProperty boolProperty3 = new BoolProperty(Uniforms.vertexAnimationStutter, Keywords.vertexAnimationStutter);
		vertexAnimationStutter = boolProperty3;
		TextureProperty textureProperty16 = new TextureProperty(Uniforms.vertexAnimationMap, Keywords.vertexAnimationMap);
		vertexAnimationMap = textureProperty16;
		RangeProperty rangeProperty23 = new RangeProperty(Uniforms.vertexAnimationIntensity, 0f, 1f);
		vertexAnimationIntensity = rangeProperty23;
		string[] keywords16 = default(string[]);
		Vector3Property vector3Property = (Vector3Property)new Property<Vector3>(Uniforms.vertexAnimationFrequency, keywords16);
		keywords16 = Array.Empty<string>();
		vertexAnimationFrequency = vector3Property;
		EnumProperty<Dissolve> uniform22 = (dissolve = new EnumProperty<Dissolve>(Uniforms.dissolve, Keywords.dissolve));
		EnumProperty<Dissolve> enumProperty9 = default(EnumProperty<Dissolve>);
		TextureProperty uniform23 = new TextureProperty(Uniforms.dissolveMap, (string)(object)enumProperty9);
		((EnumProperty<Dissolve>)0)._002Ector((Uniform)(object)uniform22, Keywords.dissolve);
		dissolveMap = uniform23;
		Property<Texture> keywords17 = default(Property<Texture>);
		FloatProperty floatProperty3 = (FloatProperty)new Property<float>(Uniforms.dissolveMapScale, (string[])(object)keywords17);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform23, (string[])(object)enumProperty9);
		dissolveMapScale = floatProperty3;
		RangeProperty rangeProperty24 = new RangeProperty(Uniforms.dissolveAmount, 0f, 1f);
		dissolveAmount = rangeProperty24;
		RangeProperty uniform24 = (dissolveBorderSize = new RangeProperty(Uniforms.dissolveBorderSize, 0f, 1f));
		Property<float> property8 = default(Property<float>);
		TextureProperty uniform25 = new TextureProperty(Uniforms.dissolveBorderRamp, (string)(object)property8);
		((Property<float>)0)._002Ector((Uniform)(object)uniform24, (string[])(object)keywords17);
		dissolveBorderRamp = uniform25;
		Property<Texture> keyword11 = default(Property<Texture>);
		ColorProperty colorProperty10 = new ColorProperty(Uniforms.dissolveBorderColor, (string)(object)keyword11);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform25, (string[])(object)property8);
		dissolveBorderColor = colorProperty10;
		EnumProperty<Artistic> enumProperty10 = new EnumProperty<Artistic>(Uniforms.artistic, Keywords.artistic);
		artistic = enumProperty10;
		EnumProperty<ArtisticProjection> enumProperty11 = new EnumProperty<ArtisticProjection>(Uniforms.artisticProjection, Keywords.artisticProjection);
		artisticProjection = enumProperty11;
		string[] array = default(string[]);
		RangeProperty rangeProperty25 = new RangeProperty(Uniforms.artisticFrequency, (float)array);
		array = new string[1] { Keywords.artisticAnimation };
		rangeProperty25._keywordDisabled = 10f;
		rangeProperty25._minValue = 1f;
		rangeProperty25._maxValue = 1f;
		artisticFrequency = rangeProperty25;
		Property<float> keywords18 = default(Property<float>);
		FloatProperty uniform26 = (FloatProperty)new Property<float>(Uniforms.drawnMapScale, (string[])(object)keywords18);
		((Property<float>)0)._002Ector((Uniform)(object)rangeProperty25, array);
		drawnMapScale = uniform26;
		Property<float> property9 = default(Property<float>);
		TextureProperty uniform27 = new TextureProperty(Uniforms.drawnMap, (string)(object)property9);
		((Property<float>)0)._002Ector((Uniform)(object)uniform26, (string[])(object)keywords18);
		drawnMap = uniform27;
		Property<Texture> keywords19 = default(Property<Texture>);
		FloatProperty uniform28 = (FloatProperty)new Property<float>(Uniforms.hatchingMapScale, (string[])(object)keywords19);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform27, (string[])(object)property9);
		hatchingMapScale = uniform28;
		Property<float> property10 = default(Property<float>);
		TextureProperty uniform29 = new TextureProperty(Uniforms.hatchingBrightMap, (string)(object)property10);
		((Property<float>)0)._002Ector((Uniform)(object)uniform28, (string[])(object)keywords19);
		hatchingBrightMap = uniform29;
		Property<Texture> property11 = default(Property<Texture>);
		TextureProperty textureProperty17 = new TextureProperty(Uniforms.hatchingDarkMap, (string)(object)property11);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform29, (string[])(object)property10);
		hatchingDarkMap = textureProperty17;
		RangeProperty rangeProperty26 = new RangeProperty(Uniforms.drawnClampMin, 0f, 1f);
		drawnClampMin = rangeProperty26;
		RangeProperty uniform30 = (drawnClampMax = new RangeProperty(Uniforms.drawnClampMax, 0f, 1f));
		Property<Texture> keywords20 = default(Property<Texture>);
		FloatProperty uniform31 = (FloatProperty)new Property<float>(Uniforms.sketchMapScale, (string[])(object)keywords20);
		((Property<Texture>)0)._002Ector((Uniform)(object)uniform30, (string[])(object)property11);
		sketchMapScale = uniform31;
		Property<float> keyword12 = default(Property<float>);
		TextureProperty textureProperty18 = new TextureProperty(Uniforms.sketchMap, (string)(object)keyword12);
		((Property<float>)0)._002Ector((Uniform)(object)uniform31, (string[])(object)keywords20);
		sketchMap = textureProperty18;
		EnumProperty<Diffuse> enumProperty12 = new EnumProperty<Diffuse>(Uniforms.diffuse, Keywords.diffuse);
		diffuse = enumProperty12;
		SpecularProperty uniform32 = (specular = new SpecularProperty(Uniforms.specular, Keywords.specular));
		Property<Specular> property12 = default(Property<Specular>);
		RangeProperty rangeProperty27 = new RangeProperty(Uniforms.specularIntensity, (float)property12);
		((Property<Specular>)0)._002Ector((Uniform)(object)uniform32, Keywords.specular);
		rangeProperty27._minValue = 0f;
		rangeProperty27._maxValue = 1f / 0f;
		specularIntensity = rangeProperty27;
		RangeProperty uniform33 = (anisotropy = new RangeProperty(Uniforms.anisotropy, -1f, 1f));
		Property<float> property13 = default(Property<float>);
		RangeProperty rangeProperty28 = new RangeProperty(Uniforms.lightTransmissionIntensity, (float)property13);
		((Property<float>)0)._002Ector((Uniform)(object)uniform33, (string[])(object)property12);
		rangeProperty28._minValue = 0f;
		rangeProperty28._maxValue = 1f / 0f;
		lightTransmissionIntensity = rangeProperty28;
		EnvironmentReflectionProperty environmentReflectionProperty = new EnvironmentReflectionProperty(Uniforms.environmentReflections, Keywords.environmentReflections);
		environmentReflections = environmentReflectionProperty;
		BoolProperty boolProperty4 = new BoolProperty(Uniforms.fresnelHighlights, Keywords.fresnelHighlights);
		boolProperty4._002Ector(Uniforms.fresnelHighlights, Keywords.fresnelHighlights);
		fresnelHighlights = boolProperty4;
		string[] keyword13 = default(string[]);
		BoolProperty uniform34 = new BoolProperty(Uniforms.IndirectFade, (string)(object)keyword13);
		keyword13 = Array.Empty<string>();
		indirectFade = uniform34;
		Property<bool> keywords21 = default(Property<bool>);
		RenderPriorityProperty uniform35 = (RenderPriorityProperty)new Property<int, bool>(Uniforms.renderPriority, (string[])(object)keywords21);
		((Property<bool>)0)._002Ector((Uniform)(object)uniform34, keyword13);
		renderPriority = uniform35;
		Property<int, bool> keywords22 = default(Property<int, bool>);
		StencilModeProperty uniform36 = (StencilModeProperty)new Property<Stencil>(Uniforms.stencil, (string[])(object)keywords22);
		((Property<int, bool>)0)._002Ector((Uniform)(object)uniform35, (string[])(object)keywords21);
		stencil = uniform36;
		Property<Stencil> keywords23 = default(Property<Stencil>);
		StepProperty stepProperty2 = (StepProperty)new Property<int>(Uniforms.stencilRef, (string[])(object)keywords23);
		((Property<Stencil>)0)._002Ector((Uniform)(object)uniform36, (string[])(object)keywords22);
		stepProperty2._minValue = 0;
		stepProperty2._maxValue = 255;
		stencilRef = stepProperty2;
		Property<int> keywords24 = default(Property<int>);
		StepProperty stepProperty3 = (StepProperty)new Property<int>(Uniforms.stencilReadMask, (string[])(object)keywords24);
		((Property<int>)0)._002Ector((Uniform)(object)stepProperty2, (string[])(object)keywords23);
		stepProperty3._minValue = 0;
		stepProperty3._maxValue = 255;
		stencilReadMask = stepProperty3;
		Property<int> keywords25 = default(Property<int>);
		StepProperty stepProperty4 = (StepProperty)new Property<int>(Uniforms.stencilWriteMask, (string[])(object)keywords25);
		((Property<int>)0)._002Ector((Uniform)(object)stepProperty3, (string[])(object)keywords24);
		stepProperty4._minValue = 0;
		stepProperty4._maxValue = 255;
		stencilWriteMask = stepProperty4;
		((Property<int>)0)._002Ector((Uniform)(object)stepProperty4, (string[])(object)keywords25);
		Property<int> keywords26 = default(Property<int>);
		((EnumProperty<StencilComparison>)0)._002Ector((Uniform)(object)(stencilComp = new EnumProperty<StencilComparison>(Uniforms.stencilComp, (string[])(object)keywords26)), (string[])(object)keywords26);
		EnumProperty<StencilComparison> keywords27 = default(EnumProperty<StencilComparison>);
		((EnumProperty<StencilOperation>)0)._002Ector((Uniform)(object)(stencilPass = new EnumProperty<StencilOperation>(Uniforms.stencilPass, (string[])(object)keywords27)), (string[])(object)keywords27);
		EnumProperty<StencilOperation> keywords28 = default(EnumProperty<StencilOperation>);
		((EnumProperty<StencilOperation>)0)._002Ector((Uniform)(object)(stencilFail = new EnumProperty<StencilOperation>(Uniforms.stencilFail, (string[])(object)keywords28)), (string[])(object)keywords28);
		EnumProperty<StencilOperation> keywords29 = default(EnumProperty<StencilOperation>);
		EnumProperty<StencilOperation> enumProperty13 = new EnumProperty<StencilOperation>(Uniforms.stencilZFail, (string[])(object)keywords29);
		stencilZFail = enumProperty13;
		EnumProperty<Outline> enumProperty14 = new EnumProperty<Outline>(Uniforms.outline, Keywords.outline);
		outline = enumProperty14;
		EnumProperty<OutlineData> enumProperty15 = new EnumProperty<OutlineData>(keywords: new string[1] { Keywords.outlineData }, uniform: Uniforms.outlineData);
		outlineData = enumProperty15;
		TextureProperty textureProperty19 = new TextureProperty(Uniforms.outlineMap, Keywords.outlineMap);
		outlineMap = textureProperty19;
		string[] array2 = default(string[]);
		RangeProperty rangeProperty29 = new RangeProperty(Uniforms.outlineSize, (float)array2);
		array2 = Array.Empty<string>();
		rangeProperty29._minValue = 0f;
		rangeProperty29._maxValue = 1f / 0f;
		outlineSize = rangeProperty29;
		Property<float> keyword14 = default(Property<float>);
		ColorProperty colorProperty11 = new ColorProperty(Uniforms.outlineColor, (string)(object)keyword14);
		((Property<float>)0)._002Ector((Uniform)(object)rangeProperty29, array2);
		outlineColor = colorProperty11;
		RangeProperty uniform37 = (outlineNoise = new RangeProperty(Uniforms.outlineNoise, Keywords.outlineNoise, -1f, keywordDisabled));
		Property<Color> keywords30 = default(Property<Color>);
		FloatProperty floatProperty4 = (FloatProperty)new Property<float>(Uniforms.refractionDistortionMapScale, (string[])(object)keywords30);
		((Property<Color>)0)._002Ector((Uniform)(object)uniform37, (string[])(object)Keywords.outlineNoise);
		refractionDistortionMapScale = floatProperty4;
		TextureProperty textureProperty20 = new TextureProperty(Uniforms.refractionDistortionMap, Keywords.refractionDistortionMap);
		refractionDistortionMap = textureProperty20;
		string[] keywords31 = default(string[]);
		FloatProperty floatProperty5 = (FloatProperty)new Property<float>(Uniforms.refractionDistortion, keywords31);
		keywords31 = Array.Empty<string>();
		refractionDistortion = floatProperty5;
		RangeProperty rangeProperty30 = new RangeProperty(Uniforms.refractionDistortionFade, 0f, 1f);
		refractionDistortionFade = rangeProperty30;
		RangeProperty rangeProperty31 = new RangeProperty(Uniforms.indexOfRefraction, Keywords.indexOfRefraction, 0f, keywordDisabled);
		indexOfRefraction = rangeProperty31;
		BoolProperty boolProperty5 = new BoolProperty(Uniforms.flipbook, Keywords.flipbook);
		flipbook = boolProperty5;
		BoolProperty boolProperty6 = new BoolProperty(Uniforms.softFade, Keywords.softFade);
		softFade = boolProperty6;
		string[] keywords32 = default(string[]);
		FloatProperty uniform38 = (FloatProperty)new Property<float>(Uniforms.softFadeNearDistance, keywords32);
		keywords32 = Array.Empty<string>();
		softFadeNearDistance = uniform38;
		Property<float> keywords33 = default(Property<float>);
		FloatProperty floatProperty6 = (FloatProperty)new Property<float>(Uniforms.softFadeFarDistance, (string[])(object)keywords33);
		((Property<float>)0)._002Ector((Uniform)(object)uniform38, keywords32);
		softFadeFarDistance = floatProperty6;
		BoolProperty boolProperty7 = new BoolProperty(Uniforms.cameraFade, Keywords.cameraFade);
		cameraFade = boolProperty7;
		string[] keywords34 = default(string[]);
		FloatProperty floatProperty7 = (FloatProperty)new Property<float>(Uniforms.cameraFadeNearDistance, keywords34);
		keywords34 = Array.Empty<string>();
		cameraFadeNearDistance = floatProperty7;
		nint num = (nint)typeof(Uniforms);
		Property<float> keywords35 = default(Property<float>);
		FloatProperty floatProperty8 = (FloatProperty)new Property<float>(Uniforms.cameraFadeFarDistance, (string[])(object)keywords35);
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4119 @ rax_v897 (Il2CppClass<MK.Toon.Uniforms>)+B8]");
		((Property<float>)num2)._002Ector((Uniform)0, keywords34);
		cameraFadeFarDistance = floatProperty8;
		EnumProperty<ColorBlend> enumProperty16 = new EnumProperty<ColorBlend>(Uniforms.colorBlend, Keywords.colorBlend);
		colorBlend = enumProperty16;
	}
}
