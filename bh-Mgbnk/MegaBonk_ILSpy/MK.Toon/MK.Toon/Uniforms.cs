using UnityEngine;

namespace MK.Toon;

public static class Uniforms
{
	public static readonly Uniform workflow;

	public static readonly Uniform renderFace;

	public static readonly Uniform surface;

	public static readonly Uniform zWrite;

	public static readonly Uniform zTest;

	public static readonly Uniform blendSrc;

	public static readonly Uniform blendDst;

	public static readonly Uniform blend;

	public static readonly Uniform alphaClipping;

	public static readonly Uniform albedoColor;

	public static readonly Uniform alphaCutoff;

	public static readonly Uniform albedoMap;

	public static readonly Uniform specularColor;

	public static readonly Uniform metallic;

	public static readonly Uniform smoothness;

	public static readonly Uniform roughness;

	public static readonly Uniform specularMap;

	public static readonly Uniform roughnessMap;

	public static readonly Uniform metallicMap;

	public static readonly Uniform normalMapIntensity;

	public static readonly Uniform normalMap;

	public static readonly Uniform parallax;

	public static readonly Uniform heightMap;

	public static readonly Uniform lightTransmission;

	public static readonly Uniform lightTransmissionDistortion;

	public static readonly Uniform lightTransmissionColor;

	public static readonly Uniform thicknessMap;

	public static readonly Uniform occlusionMapIntensity;

	public static readonly Uniform occlusionMap;

	public static readonly Uniform emissionColor;

	public static readonly Uniform emissionMap;

	public static readonly Uniform detailBlend;

	public static readonly Uniform detailColor;

	public static readonly Uniform detailMix;

	public static readonly Uniform detailMap;

	public static readonly Uniform detailNormalMapIntensity;

	public static readonly Uniform detailNormalMap;

	public static readonly Uniform receiveShadows;

	public static readonly Uniform wrappedLighting;

	public static readonly Uniform diffuseSmoothness;

	public static readonly Uniform diffuseThresholdOffset;

	public static readonly Uniform specularSmoothness;

	public static readonly Uniform specularThresholdOffset;

	public static readonly Uniform rimSmoothness;

	public static readonly Uniform rimThresholdOffset;

	public static readonly Uniform lightTransmissionSmoothness;

	public static readonly Uniform lightTransmissionThresholdOffset;

	public static readonly Uniform light;

	public static readonly Uniform diffuseRamp;

	public static readonly Uniform specularRamp;

	public static readonly Uniform rimRamp;

	public static readonly Uniform lightTransmissionRamp;

	public static readonly Uniform lightBands;

	public static readonly Uniform lightBandsScale;

	public static readonly Uniform lightThreshold;

	public static readonly Uniform thresholdMap;

	public static readonly Uniform thresholdMapScale;

	public static readonly Uniform goochRampIntensity;

	public static readonly Uniform goochRamp;

	public static readonly Uniform goochBrightColor;

	public static readonly Uniform goochBrightMap;

	public static readonly Uniform goochDarkColor;

	public static readonly Uniform goochDarkMap;

	public static readonly Uniform colorGrading;

	public static readonly Uniform contrast;

	public static readonly Uniform saturation;

	public static readonly Uniform brightness;

	public static readonly Uniform iridescence;

	public static readonly Uniform iridescenceRamp;

	public static readonly Uniform iridescenceSize;

	public static readonly Uniform iridescenceThresholdOffset;

	public static readonly Uniform iridescenceSmoothness;

	public static readonly Uniform iridescenceColor;

	public static readonly Uniform rim;

	public static readonly Uniform rimColor;

	public static readonly Uniform rimBrightColor;

	public static readonly Uniform rimDarkColor;

	public static readonly Uniform rimSize;

	public static readonly Uniform vertexAnimation;

	public static readonly Uniform vertexAnimationStutter;

	public static readonly Uniform vertexAnimationMap;

	public static readonly Uniform vertexAnimationIntensity;

	public static readonly Uniform vertexAnimationFrequency;

	public static readonly Uniform dissolve;

	public static readonly Uniform dissolveMap;

	public static readonly Uniform dissolveMapScale;

	public static readonly Uniform dissolveAmount;

	public static readonly Uniform dissolveBorderSize;

	public static readonly Uniform dissolveBorderRamp;

	public static readonly Uniform dissolveBorderColor;

	public static readonly Uniform artistic;

	public static readonly Uniform artisticProjection;

	public static readonly Uniform artisticFrequency;

	public static readonly Uniform drawnMapScale;

	public static readonly Uniform drawnMap;

	public static readonly Uniform hatchingMapScale;

	public static readonly Uniform hatchingBrightMap;

	public static readonly Uniform hatchingDarkMap;

	public static readonly Uniform drawnClampMin;

	public static readonly Uniform drawnClampMax;

	public static readonly Uniform sketchMapScale;

	public static readonly Uniform sketchMap;

	public static readonly Uniform diffuse;

	public static readonly Uniform specular;

	public static readonly Uniform specularIntensity;

	public static readonly Uniform anisotropy;

	public static readonly Uniform lightTransmissionIntensity;

	public static readonly Uniform environmentReflections;

	public static readonly Uniform fresnelHighlights;

	public static readonly Uniform IndirectFade;

	public static readonly Uniform stencil;

	public static readonly Uniform renderPriority;

	public static readonly Uniform stencilRef;

	public static readonly Uniform stencilReadMask;

	public static readonly Uniform stencilWriteMask;

	public static readonly Uniform stencilComp;

	public static readonly Uniform stencilPass;

	public static readonly Uniform stencilFail;

	public static readonly Uniform stencilZFail;

	public static readonly Uniform outline;

	public static readonly Uniform outlineData;

	public static readonly Uniform outlineMap;

	public static readonly Uniform outlineSize;

	public static readonly Uniform outlineColor;

	public static readonly Uniform outlineNoise;

	public static readonly Uniform refractionDistortionMapScale;

	public static readonly Uniform refractionDistortionMap;

	public static readonly Uniform refractionDistortion;

	public static readonly Uniform indexOfRefraction;

	public static readonly Uniform refractionDistortionFade;

	public static readonly Uniform flipbook;

	public static readonly Uniform softFade;

	public static readonly Uniform softFadeNearDistance;

	public static readonly Uniform softFadeFarDistance;

	public static readonly Uniform cameraFade;

	public static readonly Uniform cameraFadeNearDistance;

	public static readonly Uniform cameraFadeFarDistance;

	public static readonly Uniform colorBlend;

	public static readonly Uniform initialized;

	public static readonly Uniform optionsTab;

	public static readonly Uniform inputTab;

	public static readonly Uniform stylizeTab;

	public static readonly Uniform advancedTab;

	public static readonly Uniform particlesTab;

	public static readonly Uniform outlineTab;

	public static readonly Uniform refractionTab;

	public static readonly Uniform mainTex;

	public static readonly Uniform cutoff;

	public static readonly Uniform color;

	static Uniforms()
	{
		Uniform uniform = new Uniform(null)
		{
			_name = "_Workflow"
		};
		int id = Shader.PropertyToID("_Workflow");
		uniform._id = id;
		workflow = uniform;
		Uniform uniform2 = new Uniform(null)
		{
			_name = "_RenderFace"
		};
		int id2 = Shader.PropertyToID("_RenderFace");
		uniform2._id = id2;
		renderFace = uniform2;
		Uniform uniform3 = new Uniform(null)
		{
			_name = "_Surface"
		};
		int id3 = Shader.PropertyToID("_Surface");
		uniform3._id = id3;
		surface = uniform3;
		Uniform uniform4 = new Uniform(null)
		{
			_name = "_ZWrite"
		};
		int id4 = Shader.PropertyToID("_ZWrite");
		uniform4._id = id4;
		zWrite = uniform4;
		Uniform uniform5 = new Uniform(null)
		{
			_name = "_ZTest"
		};
		int id5 = Shader.PropertyToID("_ZTest");
		uniform5._id = id5;
		zTest = uniform5;
		Uniform uniform6 = new Uniform(null)
		{
			_name = "_BlendSrc"
		};
		int id6 = Shader.PropertyToID("_BlendSrc");
		uniform6._id = id6;
		blendSrc = uniform6;
		Uniform uniform7 = new Uniform(null)
		{
			_name = "_BlendDst"
		};
		int id7 = Shader.PropertyToID("_BlendDst");
		uniform7._id = id7;
		blendDst = uniform7;
		Uniform uniform8 = new Uniform(null)
		{
			_name = "_Blend"
		};
		int id8 = Shader.PropertyToID("_Blend");
		uniform8._id = id8;
		blend = uniform8;
		Uniform uniform9 = new Uniform(null)
		{
			_name = "_AlphaClipping"
		};
		int id9 = Shader.PropertyToID("_AlphaClipping");
		uniform9._id = id9;
		alphaClipping = uniform9;
		Uniform uniform10 = new Uniform(null)
		{
			_name = "_AlbedoColor"
		};
		int id10 = Shader.PropertyToID("_AlbedoColor");
		uniform10._id = id10;
		albedoColor = uniform10;
		Uniform uniform11 = new Uniform(null)
		{
			_name = "_AlphaCutoff"
		};
		int id11 = Shader.PropertyToID("_AlphaCutoff");
		uniform11._id = id11;
		alphaCutoff = uniform11;
		Uniform uniform12 = new Uniform(null)
		{
			_name = "_AlbedoMap"
		};
		int id12 = Shader.PropertyToID("_AlbedoMap");
		uniform12._id = id12;
		albedoMap = uniform12;
		Uniform uniform13 = new Uniform(null)
		{
			_name = "_SpecularColor"
		};
		int id13 = Shader.PropertyToID("_SpecularColor");
		uniform13._id = id13;
		specularColor = uniform13;
		Uniform uniform14 = new Uniform(null)
		{
			_name = "_Metallic"
		};
		int id14 = Shader.PropertyToID("_Metallic");
		uniform14._id = id14;
		metallic = uniform14;
		Uniform uniform15 = new Uniform(null)
		{
			_name = "_Smoothness"
		};
		int id15 = Shader.PropertyToID("_Smoothness");
		uniform15._id = id15;
		smoothness = uniform15;
		Uniform uniform16 = new Uniform(null)
		{
			_name = "_Roughness"
		};
		int id16 = Shader.PropertyToID("_Roughness");
		uniform16._id = id16;
		roughness = uniform16;
		Uniform uniform17 = new Uniform(null)
		{
			_name = "_SpecularMap"
		};
		int id17 = Shader.PropertyToID("_SpecularMap");
		uniform17._id = id17;
		specularMap = uniform17;
		Uniform uniform18 = new Uniform(null)
		{
			_name = "_RoughnessMap"
		};
		int id18 = Shader.PropertyToID("_RoughnessMap");
		uniform18._id = id18;
		roughnessMap = uniform18;
		Uniform uniform19 = new Uniform(null)
		{
			_name = "_MetallicMap"
		};
		int id19 = Shader.PropertyToID("_MetallicMap");
		uniform19._id = id19;
		metallicMap = uniform19;
		Uniform uniform20 = new Uniform(null)
		{
			_name = "_NormalMapIntensity"
		};
		int id20 = Shader.PropertyToID("_NormalMapIntensity");
		uniform20._id = id20;
		normalMapIntensity = uniform20;
		Uniform uniform21 = new Uniform(null)
		{
			_name = "_NormalMap"
		};
		int id21 = Shader.PropertyToID("_NormalMap");
		uniform21._id = id21;
		normalMap = uniform21;
		Uniform uniform22 = new Uniform(null)
		{
			_name = "_Parallax"
		};
		int id22 = Shader.PropertyToID("_Parallax");
		uniform22._id = id22;
		parallax = uniform22;
		Uniform uniform23 = new Uniform(null)
		{
			_name = "_HeightMap"
		};
		int id23 = Shader.PropertyToID("_HeightMap");
		uniform23._id = id23;
		heightMap = uniform23;
		Uniform uniform24 = new Uniform(null)
		{
			_name = "_LightTransmission"
		};
		int id24 = Shader.PropertyToID("_LightTransmission");
		uniform24._id = id24;
		lightTransmission = uniform24;
		Uniform uniform25 = new Uniform(null)
		{
			_name = "_LightTransmissionDistortion"
		};
		int id25 = Shader.PropertyToID("_LightTransmissionDistortion");
		uniform25._id = id25;
		lightTransmissionDistortion = uniform25;
		Uniform uniform26 = new Uniform(null)
		{
			_name = "_LightTransmissionColor"
		};
		int id26 = Shader.PropertyToID("_LightTransmissionColor");
		uniform26._id = id26;
		lightTransmissionColor = uniform26;
		Uniform uniform27 = new Uniform(null)
		{
			_name = "_ThicknessMap"
		};
		int id27 = Shader.PropertyToID("_ThicknessMap");
		uniform27._id = id27;
		thicknessMap = uniform27;
		Uniform uniform28 = new Uniform(null)
		{
			_name = "_OcclusionMapIntensity"
		};
		int id28 = Shader.PropertyToID("_OcclusionMapIntensity");
		uniform28._id = id28;
		occlusionMapIntensity = uniform28;
		Uniform uniform29 = new Uniform(null)
		{
			_name = "_OcclusionMap"
		};
		int id29 = Shader.PropertyToID("_OcclusionMap");
		uniform29._id = id29;
		occlusionMap = uniform29;
		Uniform uniform30 = new Uniform(null)
		{
			_name = "_EmissionColor"
		};
		int id30 = Shader.PropertyToID("_EmissionColor");
		uniform30._id = id30;
		emissionColor = uniform30;
		Uniform uniform31 = new Uniform(null)
		{
			_name = "_EmissionMap"
		};
		int id31 = Shader.PropertyToID("_EmissionMap");
		uniform31._id = id31;
		emissionMap = uniform31;
		Uniform uniform32 = new Uniform(null)
		{
			_name = "_DetailBlend"
		};
		int id32 = Shader.PropertyToID("_DetailBlend");
		uniform32._id = id32;
		detailBlend = uniform32;
		Uniform uniform33 = new Uniform(null)
		{
			_name = "_DetailColor"
		};
		int id33 = Shader.PropertyToID("_DetailColor");
		uniform33._id = id33;
		detailColor = uniform33;
		Uniform uniform34 = new Uniform(null)
		{
			_name = "_DetailMix"
		};
		int id34 = Shader.PropertyToID("_DetailMix");
		uniform34._id = id34;
		detailMix = uniform34;
		Uniform uniform35 = new Uniform(null)
		{
			_name = "_DetailMap"
		};
		int id35 = Shader.PropertyToID("_DetailMap");
		uniform35._id = id35;
		detailMap = uniform35;
		Uniform uniform36 = new Uniform(null)
		{
			_name = "_DetailNormalMapIntensity"
		};
		int id36 = Shader.PropertyToID("_DetailNormalMapIntensity");
		uniform36._id = id36;
		detailNormalMapIntensity = uniform36;
		Uniform uniform37 = new Uniform(null)
		{
			_name = "_DetailNormalMap"
		};
		int id37 = Shader.PropertyToID("_DetailNormalMap");
		uniform37._id = id37;
		detailNormalMap = uniform37;
		Uniform uniform38 = new Uniform(null)
		{
			_name = "_ReceiveShadows"
		};
		int id38 = Shader.PropertyToID("_ReceiveShadows");
		uniform38._id = id38;
		receiveShadows = uniform38;
		Uniform uniform39 = new Uniform(null)
		{
			_name = "_WrappedLighting"
		};
		int id39 = Shader.PropertyToID("_WrappedLighting");
		uniform39._id = id39;
		wrappedLighting = uniform39;
		Uniform uniform40 = new Uniform(null)
		{
			_name = "_DiffuseSmoothness"
		};
		int id40 = Shader.PropertyToID("_DiffuseSmoothness");
		uniform40._id = id40;
		diffuseSmoothness = uniform40;
		Uniform uniform41 = new Uniform(null)
		{
			_name = "_DiffuseThresholdOffset"
		};
		int id41 = Shader.PropertyToID("_DiffuseThresholdOffset");
		uniform41._id = id41;
		diffuseThresholdOffset = uniform41;
		Uniform uniform42 = new Uniform(null)
		{
			_name = "_SpecularSmoothness"
		};
		int id42 = Shader.PropertyToID("_SpecularSmoothness");
		uniform42._id = id42;
		specularSmoothness = uniform42;
		Uniform uniform43 = new Uniform(null)
		{
			_name = "_SpecularThresholdOffset"
		};
		int id43 = Shader.PropertyToID("_SpecularThresholdOffset");
		uniform43._id = id43;
		specularThresholdOffset = uniform43;
		Uniform uniform44 = new Uniform(null)
		{
			_name = "_RimSmoothness"
		};
		int id44 = Shader.PropertyToID("_RimSmoothness");
		uniform44._id = id44;
		rimSmoothness = uniform44;
		Uniform uniform45 = new Uniform(null)
		{
			_name = "_RimThresholdOffset"
		};
		int id45 = Shader.PropertyToID("_RimThresholdOffset");
		uniform45._id = id45;
		rimThresholdOffset = uniform45;
		Uniform uniform46 = new Uniform(null)
		{
			_name = "_LightTransmissionSmoothness"
		};
		int id46 = Shader.PropertyToID("_LightTransmissionSmoothness");
		uniform46._id = id46;
		lightTransmissionSmoothness = uniform46;
		Uniform uniform47 = new Uniform(null)
		{
			_name = "_LightTransmissionThresholdOffset"
		};
		int id47 = Shader.PropertyToID("_LightTransmissionThresholdOffset");
		uniform47._id = id47;
		lightTransmissionThresholdOffset = uniform47;
		Uniform uniform48 = new Uniform(null)
		{
			_name = "_Light"
		};
		int id48 = Shader.PropertyToID("_Light");
		uniform48._id = id48;
		light = uniform48;
		Uniform uniform49 = new Uniform(null)
		{
			_name = "_DiffuseRamp"
		};
		int id49 = Shader.PropertyToID("_DiffuseRamp");
		uniform49._id = id49;
		diffuseRamp = uniform49;
		Uniform uniform50 = new Uniform(null)
		{
			_name = "_SpecularRamp"
		};
		int id50 = Shader.PropertyToID("_SpecularRamp");
		uniform50._id = id50;
		specularRamp = uniform50;
		Uniform uniform51 = new Uniform(null)
		{
			_name = "_RimRamp"
		};
		int id51 = Shader.PropertyToID("_RimRamp");
		uniform51._id = id51;
		rimRamp = uniform51;
		Uniform uniform52 = new Uniform(null)
		{
			_name = "_LightTransmissionRamp"
		};
		int id52 = Shader.PropertyToID("_LightTransmissionRamp");
		uniform52._id = id52;
		lightTransmissionRamp = uniform52;
		Uniform uniform53 = new Uniform(null)
		{
			_name = "_LightBands"
		};
		int id53 = Shader.PropertyToID("_LightBands");
		uniform53._id = id53;
		lightBands = uniform53;
		Uniform uniform54 = new Uniform(null)
		{
			_name = "_LightBandsScale"
		};
		int id54 = Shader.PropertyToID("_LightBandsScale");
		uniform54._id = id54;
		lightBandsScale = uniform54;
		Uniform uniform55 = new Uniform(null)
		{
			_name = "_LightThreshold"
		};
		int id55 = Shader.PropertyToID("_LightThreshold");
		uniform55._id = id55;
		lightThreshold = uniform55;
		Uniform uniform56 = new Uniform(null)
		{
			_name = "_ThresholdMap"
		};
		int id56 = Shader.PropertyToID("_ThresholdMap");
		uniform56._id = id56;
		thresholdMap = uniform56;
		Uniform uniform57 = new Uniform(null)
		{
			_name = "_ThresholdMapScale"
		};
		int id57 = Shader.PropertyToID("_ThresholdMapScale");
		uniform57._id = id57;
		thresholdMapScale = uniform57;
		Uniform uniform58 = new Uniform(null)
		{
			_name = "_GoochRampIntensity"
		};
		int id58 = Shader.PropertyToID("_GoochRampIntensity");
		uniform58._id = id58;
		goochRampIntensity = uniform58;
		Uniform uniform59 = new Uniform(null)
		{
			_name = "_GoochRamp"
		};
		int id59 = Shader.PropertyToID("_GoochRamp");
		uniform59._id = id59;
		goochRamp = uniform59;
		Uniform uniform60 = new Uniform(null)
		{
			_name = "_GoochBrightColor"
		};
		int id60 = Shader.PropertyToID("_GoochBrightColor");
		uniform60._id = id60;
		goochBrightColor = uniform60;
		Uniform uniform61 = new Uniform(null)
		{
			_name = "_GoochBrightMap"
		};
		int id61 = Shader.PropertyToID("_GoochBrightMap");
		uniform61._id = id61;
		goochBrightMap = uniform61;
		Uniform uniform62 = new Uniform(null)
		{
			_name = "_GoochDarkColor"
		};
		int id62 = Shader.PropertyToID("_GoochDarkColor");
		uniform62._id = id62;
		goochDarkColor = uniform62;
		Uniform uniform63 = new Uniform(null)
		{
			_name = "_GoochDarkMap"
		};
		int id63 = Shader.PropertyToID("_GoochDarkMap");
		uniform63._id = id63;
		goochDarkMap = uniform63;
		Uniform uniform64 = new Uniform(null)
		{
			_name = "_ColorGrading"
		};
		int id64 = Shader.PropertyToID("_ColorGrading");
		uniform64._id = id64;
		colorGrading = uniform64;
		Uniform uniform65 = new Uniform(null)
		{
			_name = "_Contrast"
		};
		int id65 = Shader.PropertyToID("_Contrast");
		uniform65._id = id65;
		contrast = uniform65;
		Uniform uniform66 = new Uniform(null)
		{
			_name = "_Saturation"
		};
		int id66 = Shader.PropertyToID("_Saturation");
		uniform66._id = id66;
		saturation = uniform66;
		Uniform uniform67 = new Uniform(null)
		{
			_name = "_Brightness"
		};
		int id67 = Shader.PropertyToID("_Brightness");
		uniform67._id = id67;
		brightness = uniform67;
		Uniform uniform68 = new Uniform(null)
		{
			_name = "_Iridescence"
		};
		int id68 = Shader.PropertyToID("_Iridescence");
		uniform68._id = id68;
		iridescence = uniform68;
		Uniform uniform69 = new Uniform(null)
		{
			_name = "_IridescenceRamp"
		};
		int id69 = Shader.PropertyToID("_IridescenceRamp");
		uniform69._id = id69;
		iridescenceRamp = uniform69;
		Uniform uniform70 = new Uniform(null)
		{
			_name = "_IridescenceSize"
		};
		int id70 = Shader.PropertyToID("_IridescenceSize");
		uniform70._id = id70;
		iridescenceSize = uniform70;
		Uniform uniform71 = new Uniform(null)
		{
			_name = "_IridescenceThresholdOffset"
		};
		int id71 = Shader.PropertyToID("_IridescenceThresholdOffset");
		uniform71._id = id71;
		iridescenceThresholdOffset = uniform71;
		Uniform uniform72 = new Uniform(null)
		{
			_name = "_IridescenceSmoothness"
		};
		int id72 = Shader.PropertyToID("_IridescenceSmoothness");
		uniform72._id = id72;
		iridescenceSmoothness = uniform72;
		Uniform uniform73 = new Uniform(null)
		{
			_name = "_IridescenceColor"
		};
		int id73 = Shader.PropertyToID("_IridescenceColor");
		uniform73._id = id73;
		iridescenceColor = uniform73;
		Uniform uniform74 = new Uniform(null)
		{
			_name = "_Rim"
		};
		int id74 = Shader.PropertyToID("_Rim");
		uniform74._id = id74;
		rim = uniform74;
		Uniform uniform75 = new Uniform(null)
		{
			_name = "_RimColor"
		};
		int id75 = Shader.PropertyToID("_RimColor");
		uniform75._id = id75;
		rimColor = uniform75;
		Uniform uniform76 = new Uniform(null)
		{
			_name = "_RimBrightColor"
		};
		int id76 = Shader.PropertyToID("_RimBrightColor");
		uniform76._id = id76;
		rimBrightColor = uniform76;
		Uniform uniform77 = new Uniform(null)
		{
			_name = "_RimDarkColor"
		};
		int id77 = Shader.PropertyToID("_RimDarkColor");
		uniform77._id = id77;
		rimDarkColor = uniform77;
		Uniform uniform78 = new Uniform(null)
		{
			_name = "_RimSize"
		};
		int id78 = Shader.PropertyToID("_RimSize");
		uniform78._id = id78;
		rimSize = uniform78;
		Uniform uniform79 = new Uniform(null)
		{
			_name = "_VertexAnimation"
		};
		int id79 = Shader.PropertyToID("_VertexAnimation");
		uniform79._id = id79;
		vertexAnimation = uniform79;
		Uniform uniform80 = new Uniform(null)
		{
			_name = "_VertexAnimationStutter"
		};
		int id80 = Shader.PropertyToID("_VertexAnimationStutter");
		uniform80._id = id80;
		vertexAnimationStutter = uniform80;
		Uniform uniform81 = new Uniform(null)
		{
			_name = "_VertexAnimationMap"
		};
		int id81 = Shader.PropertyToID("_VertexAnimationMap");
		uniform81._id = id81;
		vertexAnimationMap = uniform81;
		Uniform uniform82 = new Uniform(null)
		{
			_name = "_VertexAnimationIntensity"
		};
		int id82 = Shader.PropertyToID("_VertexAnimationIntensity");
		uniform82._id = id82;
		vertexAnimationIntensity = uniform82;
		Uniform uniform83 = new Uniform(null)
		{
			_name = "_VertexAnimationFrequency"
		};
		int id83 = Shader.PropertyToID("_VertexAnimationFrequency");
		uniform83._id = id83;
		vertexAnimationFrequency = uniform83;
		Uniform uniform84 = new Uniform(null)
		{
			_name = "_Dissolve"
		};
		int id84 = Shader.PropertyToID("_Dissolve");
		uniform84._id = id84;
		dissolve = uniform84;
		Uniform uniform85 = new Uniform(null)
		{
			_name = "_DissolveMap"
		};
		int id85 = Shader.PropertyToID("_DissolveMap");
		uniform85._id = id85;
		dissolveMap = uniform85;
		Uniform uniform86 = new Uniform(null)
		{
			_name = "_DissolveMapScale"
		};
		int id86 = Shader.PropertyToID("_DissolveMapScale");
		uniform86._id = id86;
		dissolveMapScale = uniform86;
		Uniform uniform87 = new Uniform(null)
		{
			_name = "_DissolveAmount"
		};
		int id87 = Shader.PropertyToID("_DissolveAmount");
		uniform87._id = id87;
		dissolveAmount = uniform87;
		Uniform uniform88 = new Uniform(null)
		{
			_name = "_DissolveBorderSize"
		};
		int id88 = Shader.PropertyToID("_DissolveBorderSize");
		uniform88._id = id88;
		dissolveBorderSize = uniform88;
		Uniform uniform89 = new Uniform(null)
		{
			_name = "_DissolveBorderRamp"
		};
		int id89 = Shader.PropertyToID("_DissolveBorderRamp");
		uniform89._id = id89;
		dissolveBorderRamp = uniform89;
		Uniform uniform90 = new Uniform(null)
		{
			_name = "_DissolveBorderColor"
		};
		int id90 = Shader.PropertyToID("_DissolveBorderColor");
		uniform90._id = id90;
		dissolveBorderColor = uniform90;
		Uniform uniform91 = new Uniform(null)
		{
			_name = "_Artistic"
		};
		int id91 = Shader.PropertyToID("_Artistic");
		uniform91._id = id91;
		artistic = uniform91;
		Uniform uniform92 = new Uniform(null)
		{
			_name = "_ArtisticProjection"
		};
		int id92 = Shader.PropertyToID("_ArtisticProjection");
		uniform92._id = id92;
		artisticProjection = uniform92;
		Uniform uniform93 = new Uniform(null)
		{
			_name = "_ArtisticFrequency"
		};
		int id93 = Shader.PropertyToID("_ArtisticFrequency");
		uniform93._id = id93;
		artisticFrequency = uniform93;
		Uniform uniform94 = new Uniform(null)
		{
			_name = "_DrawnMapScale"
		};
		int id94 = Shader.PropertyToID("_DrawnMapScale");
		uniform94._id = id94;
		drawnMapScale = uniform94;
		Uniform uniform95 = new Uniform(null)
		{
			_name = "_DrawnMap"
		};
		int id95 = Shader.PropertyToID("_DrawnMap");
		uniform95._id = id95;
		drawnMap = uniform95;
		Uniform uniform96 = new Uniform(null)
		{
			_name = "_HatchingMapScale"
		};
		int id96 = Shader.PropertyToID("_HatchingMapScale");
		uniform96._id = id96;
		hatchingMapScale = uniform96;
		Uniform uniform97 = new Uniform(null)
		{
			_name = "_HatchingBrightMap"
		};
		int id97 = Shader.PropertyToID("_HatchingBrightMap");
		uniform97._id = id97;
		hatchingBrightMap = uniform97;
		Uniform uniform98 = new Uniform(null)
		{
			_name = "_HatchingDarkMap"
		};
		int id98 = Shader.PropertyToID("_HatchingDarkMap");
		uniform98._id = id98;
		hatchingDarkMap = uniform98;
		Uniform uniform99 = new Uniform(null)
		{
			_name = "_DrawnClampMin"
		};
		int id99 = Shader.PropertyToID("_DrawnClampMin");
		uniform99._id = id99;
		drawnClampMin = uniform99;
		Uniform uniform100 = new Uniform(null)
		{
			_name = "_DrawnClampMax"
		};
		int id100 = Shader.PropertyToID("_DrawnClampMax");
		uniform100._id = id100;
		drawnClampMax = uniform100;
		Uniform uniform101 = new Uniform(null)
		{
			_name = "_SketchMapScale"
		};
		int id101 = Shader.PropertyToID("_SketchMapScale");
		uniform101._id = id101;
		sketchMapScale = uniform101;
		Uniform uniform102 = new Uniform(null)
		{
			_name = "_SketchMap"
		};
		int id102 = Shader.PropertyToID("_SketchMap");
		uniform102._id = id102;
		sketchMap = uniform102;
		Uniform uniform103 = new Uniform(null)
		{
			_name = "_Diffuse"
		};
		int id103 = Shader.PropertyToID("_Diffuse");
		uniform103._id = id103;
		diffuse = uniform103;
		Uniform uniform104 = new Uniform(null)
		{
			_name = "_Specular"
		};
		int id104 = Shader.PropertyToID("_Specular");
		uniform104._id = id104;
		specular = uniform104;
		Uniform uniform105 = new Uniform(null)
		{
			_name = "_SpecularIntensity"
		};
		int id105 = Shader.PropertyToID("_SpecularIntensity");
		uniform105._id = id105;
		specularIntensity = uniform105;
		Uniform uniform106 = new Uniform(null)
		{
			_name = "_Anisotropy"
		};
		int id106 = Shader.PropertyToID("_Anisotropy");
		uniform106._id = id106;
		anisotropy = uniform106;
		Uniform uniform107 = new Uniform(null)
		{
			_name = "_LightTransmissionIntensity"
		};
		int id107 = Shader.PropertyToID("_LightTransmissionIntensity");
		uniform107._id = id107;
		lightTransmissionIntensity = uniform107;
		Uniform uniform108 = new Uniform(null)
		{
			_name = "_EnvironmentReflections"
		};
		int id108 = Shader.PropertyToID("_EnvironmentReflections");
		uniform108._id = id108;
		environmentReflections = uniform108;
		Uniform uniform109 = new Uniform(null)
		{
			_name = "_FresnelHighlights"
		};
		int id109 = Shader.PropertyToID("_FresnelHighlights");
		uniform109._id = id109;
		fresnelHighlights = uniform109;
		Uniform uniform110 = new Uniform(null)
		{
			_name = "_IndirectFade"
		};
		int id110 = Shader.PropertyToID("_IndirectFade");
		uniform110._id = id110;
		IndirectFade = uniform110;
		Uniform uniform111 = new Uniform(null)
		{
			_name = "_Stencil"
		};
		int id111 = Shader.PropertyToID("_Stencil");
		uniform111._id = id111;
		stencil = uniform111;
		Uniform uniform112 = new Uniform(null)
		{
			_name = "_RenderPriority"
		};
		int id112 = Shader.PropertyToID("_RenderPriority");
		uniform112._id = id112;
		renderPriority = uniform112;
		Uniform uniform113 = new Uniform(null)
		{
			_name = "_StencilRef"
		};
		int id113 = Shader.PropertyToID("_StencilRef");
		uniform113._id = id113;
		stencilRef = uniform113;
		Uniform uniform114 = new Uniform(null)
		{
			_name = "_StencilReadMask"
		};
		int id114 = Shader.PropertyToID("_StencilReadMask");
		uniform114._id = id114;
		stencilReadMask = uniform114;
		Uniform uniform115 = new Uniform(null)
		{
			_name = "_StencilWriteMask"
		};
		int id115 = Shader.PropertyToID("_StencilWriteMask");
		uniform115._id = id115;
		stencilWriteMask = uniform115;
		Uniform uniform116 = new Uniform(null)
		{
			_name = "_StencilComp"
		};
		int id116 = Shader.PropertyToID("_StencilComp");
		uniform116._id = id116;
		stencilComp = uniform116;
		Uniform uniform117 = new Uniform(null)
		{
			_name = "_StencilPass"
		};
		int id117 = Shader.PropertyToID("_StencilPass");
		uniform117._id = id117;
		stencilPass = uniform117;
		Uniform uniform118 = new Uniform(null)
		{
			_name = "_StencilFail"
		};
		int id118 = Shader.PropertyToID("_StencilFail");
		uniform118._id = id118;
		stencilFail = uniform118;
		Uniform uniform119 = new Uniform(null)
		{
			_name = "_StencilZFail"
		};
		int id119 = Shader.PropertyToID("_StencilZFail");
		uniform119._id = id119;
		stencilZFail = uniform119;
		Uniform uniform120 = new Uniform(null)
		{
			_name = "_Outline"
		};
		int id120 = Shader.PropertyToID("_Outline");
		uniform120._id = id120;
		outline = uniform120;
		Uniform uniform121 = new Uniform(null)
		{
			_name = "_OutlineData"
		};
		int id121 = Shader.PropertyToID("_OutlineData");
		uniform121._id = id121;
		outlineData = uniform121;
		Uniform uniform122 = new Uniform(null)
		{
			_name = "_OutlineMap"
		};
		int id122 = Shader.PropertyToID("_OutlineMap");
		uniform122._id = id122;
		outlineMap = uniform122;
		Uniform uniform123 = new Uniform(null)
		{
			_name = "_OutlineSize"
		};
		int id123 = Shader.PropertyToID("_OutlineSize");
		uniform123._id = id123;
		outlineSize = uniform123;
		Uniform uniform124 = new Uniform(null)
		{
			_name = "_OutlineColor"
		};
		int id124 = Shader.PropertyToID("_OutlineColor");
		uniform124._id = id124;
		outlineColor = uniform124;
		Uniform uniform125 = new Uniform(null)
		{
			_name = "_OutlineNoise"
		};
		int id125 = Shader.PropertyToID("_OutlineNoise");
		uniform125._id = id125;
		outlineNoise = uniform125;
		Uniform uniform126 = new Uniform(null)
		{
			_name = "_RefractionDistortionMapScale"
		};
		int id126 = Shader.PropertyToID("_RefractionDistortionMapScale");
		uniform126._id = id126;
		refractionDistortionMapScale = uniform126;
		Uniform uniform127 = new Uniform(null)
		{
			_name = "_RefractionDistortionMap"
		};
		int id127 = Shader.PropertyToID("_RefractionDistortionMap");
		uniform127._id = id127;
		refractionDistortionMap = uniform127;
		Uniform uniform128 = new Uniform(null)
		{
			_name = "_RefractionDistortion"
		};
		int id128 = Shader.PropertyToID("_RefractionDistortion");
		uniform128._id = id128;
		refractionDistortion = uniform128;
		Uniform uniform129 = new Uniform(null)
		{
			_name = "_IndexOfRefraction"
		};
		int id129 = Shader.PropertyToID("_IndexOfRefraction");
		uniform129._id = id129;
		indexOfRefraction = uniform129;
		Uniform uniform130 = new Uniform(null)
		{
			_name = "_RefractionDistortionFade"
		};
		int id130 = Shader.PropertyToID("_RefractionDistortionFade");
		uniform130._id = id130;
		refractionDistortionFade = uniform130;
		Uniform uniform131 = new Uniform(null)
		{
			_name = "_Flipbook"
		};
		int id131 = Shader.PropertyToID("_Flipbook");
		uniform131._id = id131;
		flipbook = uniform131;
		Uniform uniform132 = new Uniform(null)
		{
			_name = "_SoftFade"
		};
		int id132 = Shader.PropertyToID("_SoftFade");
		uniform132._id = id132;
		softFade = uniform132;
		Uniform uniform133 = new Uniform(null)
		{
			_name = "_SoftFadeNearDistance"
		};
		int id133 = Shader.PropertyToID("_SoftFadeNearDistance");
		uniform133._id = id133;
		softFadeNearDistance = uniform133;
		Uniform uniform134 = new Uniform(null)
		{
			_name = "_SoftFadeFarDistance"
		};
		int id134 = Shader.PropertyToID("_SoftFadeFarDistance");
		uniform134._id = id134;
		softFadeFarDistance = uniform134;
		Uniform uniform135 = new Uniform(null)
		{
			_name = "_CameraFade"
		};
		int id135 = Shader.PropertyToID("_CameraFade");
		uniform135._id = id135;
		cameraFade = uniform135;
		Uniform uniform136 = new Uniform(null)
		{
			_name = "_CameraFadeNearDistance"
		};
		int id136 = Shader.PropertyToID("_CameraFadeNearDistance");
		uniform136._id = id136;
		cameraFadeNearDistance = uniform136;
		Uniform uniform137 = new Uniform(null)
		{
			_name = "_CameraFadeFarDistance"
		};
		int id137 = Shader.PropertyToID("_CameraFadeFarDistance");
		uniform137._id = id137;
		cameraFadeFarDistance = uniform137;
		Uniform uniform138 = new Uniform(null)
		{
			_name = "_ColorBlend"
		};
		int id138 = Shader.PropertyToID("_ColorBlend");
		uniform138._id = id138;
		colorBlend = uniform138;
		Uniform uniform139 = new Uniform(null)
		{
			_name = "_Initialized"
		};
		int id139 = Shader.PropertyToID("_Initialized");
		uniform139._id = id139;
		initialized = uniform139;
		Uniform uniform140 = new Uniform(null)
		{
			_name = "_OptionsTab"
		};
		int id140 = Shader.PropertyToID("_OptionsTab");
		uniform140._id = id140;
		optionsTab = uniform140;
		Uniform uniform141 = new Uniform(null)
		{
			_name = "_InputTab"
		};
		int id141 = Shader.PropertyToID("_InputTab");
		uniform141._id = id141;
		inputTab = uniform141;
		Uniform uniform142 = new Uniform(null)
		{
			_name = "_StylizeTab"
		};
		int id142 = Shader.PropertyToID("_StylizeTab");
		uniform142._id = id142;
		stylizeTab = uniform142;
		Uniform uniform143 = new Uniform(null)
		{
			_name = "_AdvancedTab"
		};
		int id143 = Shader.PropertyToID("_AdvancedTab");
		uniform143._id = id143;
		advancedTab = uniform143;
		Uniform uniform144 = new Uniform(null)
		{
			_name = "_ParticlesTab"
		};
		int id144 = Shader.PropertyToID("_ParticlesTab");
		uniform144._id = id144;
		particlesTab = uniform144;
		Uniform uniform145 = new Uniform(null)
		{
			_name = "_OutlineTab"
		};
		int id145 = Shader.PropertyToID("_OutlineTab");
		uniform145._id = id145;
		outlineTab = uniform145;
		Uniform uniform146 = new Uniform(null)
		{
			_name = "_RefractionTab"
		};
		int id146 = Shader.PropertyToID("_RefractionTab");
		uniform146._id = id146;
		refractionTab = uniform146;
		Uniform uniform147 = new Uniform(null)
		{
			_name = "_MainTex"
		};
		int id147 = Shader.PropertyToID("_MainTex");
		uniform147._id = id147;
		mainTex = uniform147;
		Uniform uniform148 = new Uniform(null)
		{
			_name = "_Cutoff"
		};
		int id148 = Shader.PropertyToID("_Cutoff");
		uniform148._id = id148;
		cutoff = uniform148;
		Uniform uniform149 = new Uniform(null)
		{
			_name = "_Color"
		};
		int id149 = Shader.PropertyToID("_Color");
		uniform149._id = id149;
		color = uniform149;
	}
}
