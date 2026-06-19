using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

[DisallowMultipleRendererFeature("Physically Based Sky URP")]
[Tooltip("Add this Renderer Feature to support visual environment override in URP Volume.")]
[HelpURL("https://github.com/jiaozi158/UnityPhysicallyBasedSkyURP/tree/main")]
public class PhysicallyBasedSkyURP : ScriptableRendererFeature
{
	public enum PrecomputationQualityMode
	{
		[InspectorName("High")]
		[Tooltip("Generates full resolution look-up tables.")]
		High = 0,
		[InspectorName("Low")]
		[Tooltip("Generates half resolution look-up tables.")]
		Low = 1
	}

	public struct CelestialBodyData
	{
		public Vector3 color;

		public float radius;

		public Vector3 forward;

		public float distanceFromCamera;

		public Vector3 right;

		public float angularRadius;

		public Vector3 up;

		public int type;

		public Vector3 surfaceColor;

		public float earthshine;

		public Vector4 surfaceTextureScaleOffset;

		public Vector3 sunDirection;

		public float flareCosInner;

		public float flareCosOuter;

		public float flareSize;

		public Vector3 flareColor;

		public float flareFalloff;
	}

	private class PBSkyPrePass : ScriptableRenderPass
	{
		private class PassData
		{
			internal Vector3 mainLightColor;

			internal bool enableAtmosphericScattering;

			internal bool isReflectionCamera;
		}

		private const string profilerTag = "Setup Physically Based Sky";

		private readonly ProfilingSampler m_ProfilingSampler = new ProfilingSampler("Setup Physically Based Sky");

		public PhysicallyBasedSky pbrSky;

		public VisualEnvironment visualEnvironment;

		public Fog fog;

		public CelestialBodyData celestialBodyData;

		public Material material;

		public Material lutMaterial;

		private static readonly int _AtmosphericRadius = Shader.PropertyToID("_AtmosphericRadius");

		private static readonly int _AerosolAnisotropy = Shader.PropertyToID("_AerosolAnisotropy");

		private static readonly int _AerosolPhasePartConstant = Shader.PropertyToID("_AerosolPhasePartConstant");

		private static readonly int _AerosolSeaLevelExtinction = Shader.PropertyToID("_AerosolSeaLevelExtinction");

		private static readonly int _AirDensityFalloff = Shader.PropertyToID("_AirDensityFalloff");

		private static readonly int _AirScaleHeight = Shader.PropertyToID("_AirScaleHeight");

		private static readonly int _AerosolDensityFalloff = Shader.PropertyToID("_AerosolDensityFalloff");

		private static readonly int _AerosolScaleHeight = Shader.PropertyToID("_AerosolScaleHeight");

		private static readonly int _OzoneScaleOffset = Shader.PropertyToID("_OzoneScaleOffset");

		private static readonly int _OzoneLayerStart = Shader.PropertyToID("_OzoneLayerStart");

		private static readonly int _OzoneLayerEnd = Shader.PropertyToID("_OzoneLayerEnd");

		private static readonly int _AirSeaLevelExtinction = Shader.PropertyToID("_AirSeaLevelExtinction");

		private static readonly int _AirSeaLevelScattering = Shader.PropertyToID("_AirSeaLevelScattering");

		private static readonly int _AerosolSeaLevelScattering = Shader.PropertyToID("_AerosolSeaLevelScattering");

		private static readonly int _OzoneSeaLevelExtinction = Shader.PropertyToID("_OzoneSeaLevelExtinction");

		private static readonly int _GroundAlbedo_PlanetRadius = Shader.PropertyToID("_GroundAlbedo_PlanetRadius");

		private static readonly int _HorizonTint = Shader.PropertyToID("_HorizonTint");

		private static readonly int _ZenithTint = Shader.PropertyToID("_ZenithTint");

		private static readonly int _IntensityMultiplier = Shader.PropertyToID("_IntensityMultiplier");

		private static readonly int _ColorSaturation = Shader.PropertyToID("_ColorSaturation");

		private static readonly int _AlphaSaturation = Shader.PropertyToID("_AlphaSaturation");

		private static readonly int _AlphaMultiplier = Shader.PropertyToID("_AlphaMultiplier");

		private static readonly int _HorizonZenithShiftPower = Shader.PropertyToID("_HorizonZenithShiftPower");

		private static readonly int _HorizonZenithShiftScale = Shader.PropertyToID("_HorizonZenithShiftScale");

		private static readonly int _CelestialLightCount = Shader.PropertyToID("_CelestialLightCount");

		private static readonly int _CelestialBodyCount = Shader.PropertyToID("_CelestialBodyCount");

		private static readonly int _AtmosphericDepth = Shader.PropertyToID("_AtmosphericDepth");

		private static readonly int _RcpAtmosphericDepth = Shader.PropertyToID("_RcpAtmosphericDepth");

		private static readonly int _CelestialLightExposure = Shader.PropertyToID("_CelestialLightExposure");

		private static readonly int _DisableSunDisk = Shader.PropertyToID("_DisableSunDisk");

		private static readonly int _HasGroundAlbedoTexture = Shader.PropertyToID("_HasGroundAlbedoTexture");

		private static readonly int _GroundAlbedoTexture = Shader.PropertyToID("_GroundAlbedoTexture");

		private static readonly int _HasGroundEmissionTexture = Shader.PropertyToID("_HasGroundEmissionTexture");

		private static readonly int _GroundEmissionTexture = Shader.PropertyToID("_GroundEmissionTexture");

		private static readonly int _GroundEmissionMultiplier = Shader.PropertyToID("_GroundEmissionMultiplier");

		private static readonly int _HasSpaceEmissionTexture = Shader.PropertyToID("_HasSpaceEmissionTexture");

		private static readonly int _SpaceEmissionTexture = Shader.PropertyToID("_SpaceEmissionTexture");

		private static readonly int _SpaceEmissionMultiplier = Shader.PropertyToID("_SpaceEmissionMultiplier");

		private static readonly int _PlanetRotation = Shader.PropertyToID("_PlanetRotation");

		private static readonly int _SpaceRotation = Shader.PropertyToID("_SpaceRotation");

		private static readonly int _PlanetCenterRadius = Shader.PropertyToID("_PlanetCenterRadius");

		private static readonly int _PlanetUpAltitude = Shader.PropertyToID("_PlanetUpAltitude");

		private static readonly int _PBRSkyCameraPosPS = Shader.PropertyToID("_PBRSkyCameraPosPS");

		private static readonly int _CelestialBody_Color = Shader.PropertyToID("_CelestialBody_Color");

		private static readonly int _CelestialBody_Radius = Shader.PropertyToID("_CelestialBody_Radius");

		private static readonly int _CelestialBody_Forward = Shader.PropertyToID("_CelestialBody_Forward");

		private static readonly int _CelestialBody_DistanceFromCamera = Shader.PropertyToID("_CelestialBody_DistanceFromCamera");

		private static readonly int _CelestialBody_Right = Shader.PropertyToID("_CelestialBody_Right");

		private static readonly int _CelestialBody_AngularRadius = Shader.PropertyToID("_CelestialBody_AngularRadius");

		private static readonly int _CelestialBody_Up = Shader.PropertyToID("_CelestialBody_Up");

		private static readonly int _CelestialBody_Type = Shader.PropertyToID("_CelestialBody_Type");

		private static readonly int _CelestialBody_SurfaceColor = Shader.PropertyToID("_CelestialBody_SurfaceColor");

		private static readonly int _CelestialBody_Earthshine = Shader.PropertyToID("_CelestialBody_Earthshine");

		private static readonly int _CelestialBody_SurfaceTextureScaleOffset = Shader.PropertyToID("_CelestialBody_SurfaceTextureScaleOffset");

		private static readonly int _CelestialBody_SunDirection = Shader.PropertyToID("_CelestialBody_SunDirection");

		private static readonly int _CelestialBody_FlareCosInner = Shader.PropertyToID("_CelestialBody_FlareCosInner");

		private static readonly int _CelestialBody_FlareCosOuter = Shader.PropertyToID("_CelestialBody_FlareCosOuter");

		private static readonly int _CelestialBody_FlareSize = Shader.PropertyToID("_CelestialBody_FlareSize");

		private static readonly int _CelestialBody_FlareColor = Shader.PropertyToID("_CelestialBody_FlareColor");

		private static readonly int _CelestialBody_FlareFalloff = Shader.PropertyToID("_CelestialBody_FlareFalloff");

		private static readonly int _MainLightColor = Shader.PropertyToID("_MainLightColor");

		private static readonly int _EnableAtmosphericScattering = Shader.PropertyToID("_EnableAtmosphericScattering");

		private const string PHYSICALLY_BASED_SKY = "PHYSICALLY_BASED_SKY";

		private const string LOCAL_SKY = "LOCAL_SKY";

		private const string SKY_NOT_BAKING = "SKY_NOT_BAKING";

		private SphericalHarmonicsL2 ambientProbe;

		private const int fibonacciSamplesCount = 64;

		private static readonly float3[] fibonacciSamples = new float3[64]
		{
			new float3(-0f, -1f, -0f),
			new float3(0.184319f, -0.968254f, 0.168851f),
			new float3(-0.030656f, -0.936508f, -0.349304f),
			new float3(-0.259145f, -0.904762f, 0.338009f),
			new float3(0.480237f, -0.873016f, -0.084947f),
			new float3(-0.456147f, -0.84127f, -0.290163f),
			new float3(0.15241f, -0.809524f, 0.566959f),
			new float3(0.289698f, -0.777778f, -0.557796f),
			new float3(-0.625504f, -0.746032f, 0.228433f),
			new float3(0.646907f, -0.714286f, 0.267034f),
			new float3(-0.309767f, -0.68254f, -0.661955f),
			new float3(-0.227233f, -0.650794f, 0.724454f),
			new float3(0.679497f, -0.619048f, -0.393782f),
			new float3(-0.79049f, -0.587302f, -0.173787f),
			new float3(0.478208f, -0.555556f, 0.680202f),
			new float3(0.10947f, -0.52381f, -0.844772f),
			new float3(-0.665672f, -0.492063f, 0.561029f),
			new float3(0.886996f, -0.460317f, 0.03668f),
			new float3(-0.640433f, -0.428571f, -0.637316f),
			new float3(0.042399f, -0.396825f, 0.916914f),
			new float3(0.596485f, -0.365079f, -0.714788f),
			new float3(-0.934389f, -0.333333f, 0.125721f),
			new float3(0.782638f, -0.301587f, 0.544539f),
			new float3(-0.21134f, -0.269841f, -0.939426f),
			new float3(-0.482883f, -0.238095f, 0.842695f),
			new float3(0.932189f, -0.206349f, -0.297394f),
			new float3(-0.893846f, -0.174603f, -0.41298f),
			new float3(0.382101f, -0.142857f, 0.913012f),
			new float3(0.336357f, -0.111111f, -0.935157f),
			new float3(-0.882397f, -0.079365f, 0.463763f),
			new float3(0.965873f, -0.047619f, 0.254601f),
			new float3(-0.54077f, -0.015873f, -0.841021f),
			new float3(-0.169355f, 0.015873f, 0.985427f),
			new float3(0.789726f, 0.047619f, -0.611608f),
			new float3(-0.993442f, 0.079365f, -0.082305f),
			new float3(0.674874f, 0.111111f, 0.72952f),
			new float3(-0.004828f, 0.142857f, -0.989732f),
			new float3(-0.661564f, 0.174603f, 0.729278f),
			new float3(0.974303f, 0.206349f, -0.090298f),
			new float3(-0.773652f, 0.238095f, -0.587174f),
			new float3(0.172344f, 0.269841f, 0.947356f),
			new float3(0.507807f, 0.301587f, -0.806956f),
			new float3(-0.90928f, 0.333333f, 0.249196f),
			new float3(0.828277f, 0.365079f, 0.425058f),
			new float3(-0.319075f, 0.396825f, -0.860651f),
			new float3(-0.340661f, 0.428571f, 0.836825f),
			new float3(0.802224f, 0.460317f, -0.380189f),
			new float3(-0.831918f, 0.492063f, -0.256489f),
			new float3(0.430707f, 0.52381f, 0.734925f),
			new float3(0.174571f, 0.555556f, -0.812947f),
			new float3(-0.659835f, 0.587302f, 0.468716f),
			new float3(0.779324f, 0.619048f, 0.097126f),
			new float3(-0.492126f, 0.650794f, -0.578169f),
			new float3(-0.026634f, 0.68254f, 0.730363f),
			new float3(0.491237f, 0.714286f, -0.49848f),
			new float3(-0.665042f, 0.746032f, 0.034004f),
			new float3(0.484541f, 0.777778f, 0.400352f),
			new float3(-0.081124f, 0.809524f, -0.581455f),
			new float3(-0.306594f, 0.84127f, 0.44527f),
			new float3(0.475272f, 0.873016f, -0.109359f),
			new float3(-0.370575f, 0.904762f, -0.209953f),
			new float3(0.108202f, 0.936508f, 0.333534f),
			new float3(0.103734f, 0.968254f, -0.227428f),
			new float3(-0f, 1f, 0f)
		};

		private float3 mainLightColor;

		public PBSkyPrePass(Material material, CelestialBodyData celestialBodyData)
		{
			this.material = material;
			this.celestialBodyData = celestialBodyData;
		}

		private Light GetMainLight(LightData lightData)
		{
			int mainLightIndex = lightData.mainLightIndex;
			if (mainLightIndex != -1)
			{
				VisibleLight visibleLight = lightData.visibleLights[mainLightIndex];
				Light light = visibleLight.light;
				if ((light.shadows != LightShadows.None || (RenderSettings.sun != null && !RenderSettings.sun.isActiveAndEnabled)) && visibleLight.lightType == LightType.Directional)
				{
					return light;
				}
			}
			return RenderSettings.sun;
		}

		[Obsolete]
		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			Camera camera = renderingData.cameraData.camera;
			Light mainLight = GetMainLight(renderingData.lightData);
			if (mainLight != null)
			{
				float3 float5 = EvaluateSunColorAttenuation(math.float3(camera.transform.position) - visualEnvironment.GetPlanetCenterRadius(camera.transform.position).xyz, -mainLight.transform.forward);
				Color color = mainLight.color.linear * (mainLight.useColorTemperature ? Mathf.CorrelatedColorTemperatureToRGB(mainLight.colorTemperature) : Color.white);
				mainLightColor = math.float3(color.r, color.g, color.b) * mainLight.intensity * float5;
			}
			UpdateMaterialProperties(mainLight, camera, material);
			lutMaterial.CopyPropertiesFromMaterial(material);
			if (mainLight != null && visualEnvironment.skyAmbientMode.value == VisualEnvironment.SkyAmbientMode.Dynamic)
			{
				ambientProbe = UpdateAmbientProbe(ambientProbe, mainLight.transform.forward, mainLightColor);
				RenderSettings.ambientProbe = ambientProbe;
			}
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, m_ProfilingSampler))
			{
				bool flag = renderingData.cameraData.camera.cameraType == CameraType.Reflection;
				commandBuffer.SetGlobalFloat(_DisableSunDisk, flag ? 1f : 0f);
				commandBuffer.SetGlobalVector(_MainLightColor, math.float4(mainLightColor, 0f));
				commandBuffer.EnableShaderKeyword("PHYSICALLY_BASED_SKY");
				commandBuffer.EnableShaderKeyword("SKY_NOT_BAKING");
				commandBuffer.SetGlobalFloat(_EnableAtmosphericScattering, pbrSky.atmosphericScattering.value ? 1f : 0f);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		private Light GetMainLight(UniversalLightData lightData)
		{
			int mainLightIndex = lightData.mainLightIndex;
			if (mainLightIndex != -1)
			{
				VisibleLight visibleLight = lightData.visibleLights[mainLightIndex];
				Light light = visibleLight.light;
				if ((light.shadows != LightShadows.None || (RenderSettings.sun != null && !RenderSettings.sun.isActiveAndEnabled)) && visibleLight.lightType == LightType.Directional)
				{
					return light;
				}
			}
			return RenderSettings.sun;
		}

		private static void ExecutePass(PassData data, UnsafeGraphContext context)
		{
			CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
			nativeCommandBuffer.SetGlobalFloat(_DisableSunDisk, data.isReflectionCamera ? 1f : 0f);
			nativeCommandBuffer.SetGlobalVector(_MainLightColor, data.mainLightColor);
			nativeCommandBuffer.EnableShaderKeyword("PHYSICALLY_BASED_SKY");
			nativeCommandBuffer.EnableShaderKeyword("SKY_NOT_BAKING");
			nativeCommandBuffer.SetGlobalFloat(_EnableAtmosphericScattering, data.enableAtmosphericScattering ? 1f : 0f);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Setup Physically Based Sky", out passData, ".\\Library\\PackageCache\\com.jiaozi158.unity-physically-based-sky-urp\\Runtime\\PhysicallyBasedSkyURP.cs", 697);
			UniversalLightData lightData = frameData.Get<UniversalLightData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			Light mainLight = GetMainLight(lightData);
			Camera camera = universalCameraData.camera;
			float3 float5 = 0f;
			if (mainLight != null)
			{
				float3 float6 = EvaluateSunColorAttenuation(math.float3(camera.transform.position) - visualEnvironment.GetPlanetCenterRadius(camera.transform.position).xyz, -mainLight.transform.forward);
				Color color = mainLight.color.linear * (mainLight.useColorTemperature ? Mathf.CorrelatedColorTemperatureToRGB(mainLight.colorTemperature) : Color.white);
				float5 = math.float3(color.r, color.g, color.b) * mainLight.intensity * float6;
			}
			UpdateMaterialProperties(mainLight, camera, material);
			lutMaterial.CopyPropertiesFromMaterial(material);
			if (mainLight != null && visualEnvironment.skyAmbientMode.value == VisualEnvironment.SkyAmbientMode.Dynamic)
			{
				ambientProbe = UpdateAmbientProbe(ambientProbe, mainLight.transform.forward, float5);
				RenderSettings.ambientProbe = ambientProbe;
			}
			passData.mainLightColor = float5;
			passData.enableAtmosphericScattering = pbrSky.atmosphericScattering.value;
			passData.isReflectionCamera = universalCameraData.camera.cameraType == CameraType.Reflection;
			unsafeRenderGraphBuilder.AllowGlobalStateModification(value: true);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				ExecutePass(data, context);
			});
		}

		public void Dispose()
		{
		}

		private SphericalHarmonicsL2 UpdateAmbientProbe(SphericalHarmonicsL2 ambientProbe, float3 lightDirection, float3 lightColor)
		{
			ambientProbe.Clear();
			float intensity = MathF.PI * 4f * math.rcp(64f);
			for (int i = 0; i < 64; i++)
			{
				float3 float5 = fibonacciSamples[i];
				pbrSky.RenderSky(-lightDirection, lightColor, float5, out var skyColor, out var _);
				ambientProbe.AddDirectionalLight(color: new Color(skyColor.x, skyColor.y, skyColor.z), direction: float5, intensity: intensity);
			}
			return ambientProbe;
		}

		private void UpdateMaterialProperties(Light mainLight, Camera camera, Material material)
		{
			float4 planetCenterRadius = visualEnvironment.GetPlanetCenterRadius(camera.transform.position);
			float w = planetCenterRadius.w;
			float maximumAltitude = pbrSky.GetMaximumAltitude();
			float airScaleHeight = pbrSky.GetAirScaleHeight();
			float aerosolScaleHeight = pbrSky.GetAerosolScaleHeight();
			float value = pbrSky.aerosolAnisotropy.value;
			float ozoneLayerMinimumAltitude = pbrSky.GetOzoneLayerMinimumAltitude();
			float ozoneLayerWidth = pbrSky.GetOzoneLayerWidth();
			float intensityFromSettings = pbrSky.GetIntensityFromSettings();
			float2 float5 = ComputeExponentialInterpolationParams(pbrSky.horizonZenithShift.value);
			material.SetFloat(_AtmosphericDepth, maximumAltitude);
			Shader.SetGlobalFloat(_RcpAtmosphericDepth, 1f / maximumAltitude);
			Shader.SetGlobalFloat(_AtmosphericRadius, w + maximumAltitude);
			Shader.SetGlobalFloat(_AerosolAnisotropy, value);
			Shader.SetGlobalFloat(_AerosolPhasePartConstant, CornetteShanksPhasePartConstant(value));
			Shader.SetGlobalFloat(_AirDensityFalloff, 1f / airScaleHeight);
			Shader.SetGlobalFloat(_AirScaleHeight, airScaleHeight);
			Shader.SetGlobalFloat(_AerosolDensityFalloff, 1f / aerosolScaleHeight);
			Shader.SetGlobalFloat(_AerosolScaleHeight, aerosolScaleHeight);
			Shader.SetGlobalVector(_AirSeaLevelExtinction, pbrSky.GetAirExtinctionCoefficient());
			Shader.SetGlobalFloat(_AerosolSeaLevelExtinction, pbrSky.GetAerosolExtinctionCoefficient());
			material.SetVector(_AirSeaLevelScattering, pbrSky.GetAirScatteringCoefficient());
			Shader.SetGlobalFloat(_IntensityMultiplier, intensityFromSettings);
			Shader.SetGlobalVector(_AerosolSeaLevelScattering, pbrSky.GetAerosolScatteringCoefficient());
			Shader.SetGlobalFloat(_ColorSaturation, pbrSky.colorSaturation.value);
			Shader.SetGlobalVector(_OzoneSeaLevelExtinction, pbrSky.GetOzoneExtinctionCoefficient());
			Shader.SetGlobalVector(_OzoneScaleOffset, new Vector2(2f / ozoneLayerWidth, -2f * ozoneLayerMinimumAltitude / ozoneLayerWidth - 1f));
			Shader.SetGlobalFloat(_OzoneLayerStart, w + ozoneLayerMinimumAltitude);
			Shader.SetGlobalFloat(_OzoneLayerEnd, w + ozoneLayerMinimumAltitude + ozoneLayerWidth);
			material.SetVector(_GroundAlbedo_PlanetRadius, new Vector4(pbrSky.groundTint.value.r, pbrSky.groundTint.value.g, pbrSky.groundTint.value.b, w));
			Shader.SetGlobalFloat(_AlphaSaturation, pbrSky.alphaSaturation.value);
			Shader.SetGlobalFloat(_AlphaMultiplier, pbrSky.alphaMultiplier.value);
			Shader.SetGlobalVector(_HorizonTint, new Vector3(pbrSky.horizonTint.value.r, pbrSky.horizonTint.value.g, pbrSky.horizonTint.value.b));
			Shader.SetGlobalFloat(_HorizonZenithShiftPower, float5.x);
			Shader.SetGlobalVector(_ZenithTint, new Vector3(pbrSky.zenithTint.value.r, pbrSky.zenithTint.value.g, pbrSky.zenithTint.value.b));
			Shader.SetGlobalFloat(_HorizonZenithShiftScale, float5.y);
			Vector3 position = camera.transform.position;
			Vector3 vector = planetCenterRadius.xyz;
			Vector3 vector2 = -(vector - position).normalized;
			float w2 = Vector3.Dot(position - (vector2 * w + vector), vector2);
			float4 float6 = math.float4(vector2, w2);
			Vector3 vector3 = position - vector;
			if (float6.w < 1f)
			{
				vector3 -= (float6.w - 1f) * (Vector3)float6.xyz;
			}
			Shader.SetGlobalVector(_PBRSkyCameraPosPS, vector3);
			Shader.SetGlobalVector(_PlanetCenterRadius, planetCenterRadius);
			Shader.SetGlobalVector(_PlanetUpAltitude, float6);
			VisualEnvironment.RenderingSpace value2 = visualEnvironment.renderingSpace.value;
			CoreUtils.SetKeyword(material, "LOCAL_SKY", value2 == VisualEnvironment.RenderingSpace.World);
			Quaternion q = Quaternion.Euler(pbrSky.planetRotation.value.x, pbrSky.planetRotation.value.y, pbrSky.planetRotation.value.z);
			Quaternion q2 = Quaternion.Euler(pbrSky.spaceRotation.value.x, pbrSky.spaceRotation.value.y, pbrSky.spaceRotation.value.z);
			Matrix4x4 value3 = Matrix4x4.Rotate(q);
			value3[0] *= -1f;
			value3[1] *= -1f;
			value3[2] *= -1f;
			material.SetInteger(_HasGroundAlbedoTexture, (!(pbrSky.groundColorTexture.value == null)) ? 1 : 0);
			material.SetTexture(_GroundAlbedoTexture, pbrSky.groundColorTexture.value);
			material.SetInteger(_HasGroundEmissionTexture, (!(pbrSky.groundEmissionTexture.value == null)) ? 1 : 0);
			material.SetTexture(_GroundEmissionTexture, pbrSky.groundEmissionTexture.value);
			material.SetFloat(_GroundEmissionMultiplier, pbrSky.groundEmissionMultiplier.value);
			material.SetInteger(_HasSpaceEmissionTexture, (!(pbrSky.spaceEmissionTexture.value == null)) ? 1 : 0);
			material.SetTexture(_SpaceEmissionTexture, pbrSky.spaceEmissionTexture.value);
			material.SetFloat(_SpaceEmissionMultiplier, pbrSky.spaceEmissionMultiplier.value);
			material.SetMatrix(_PlanetRotation, value3);
			material.SetMatrix(_SpaceRotation, Matrix4x4.Rotate(q2));
			if (mainLight != null)
			{
				material.SetInt(_CelestialLightCount, 1);
				material.SetInt(_CelestialBodyCount, 1);
				material.SetFloat(_CelestialLightExposure, 1f);
				float num = 0.004363323f;
				float num2 = Mathf.Max(MathF.PI / 90f, 5.9604645E-08f);
				float num3 = Mathf.Cos(num);
				float num4 = 1f / (MathF.PI * 2f * (1f - num3));
				Color color = mainLight.color.linear * mainLight.intensity * MathF.PI;
				color = (mainLight.useColorTemperature ? (color * Mathf.CorrelatedColorTemperatureToRGB(mainLight.colorTemperature)) : color);
				Vector4 one = Vector4.one;
				Vector4 one2 = Vector4.one;
				one *= num4;
				one2 *= num4;
				celestialBodyData.color = math.float3(color.r, color.g, color.b);
				color *= math.rcp(50f);
				one = Vector4.Scale(color, one);
				one2 = Vector4.Scale(color, one2);
				celestialBodyData.forward = mainLight.transform.forward;
				celestialBodyData.distanceFromCamera = 1.5E+11f;
				celestialBodyData.right = mainLight.transform.right.normalized;
				celestialBodyData.angularRadius = num;
				celestialBodyData.radius = Mathf.Tan(num) * 1.5E+11f;
				celestialBodyData.up = mainLight.transform.up.normalized;
				celestialBodyData.type = 0;
				celestialBodyData.surfaceColor = one;
				celestialBodyData.earthshine = 0.01f;
				celestialBodyData.surfaceTextureScaleOffset = Vector4.zero;
				celestialBodyData.sunDirection = ((mainLight != null) ? mainLight.transform.forward : Vector3.forward);
				celestialBodyData.flareSize = num2;
				celestialBodyData.flareFalloff = 4f;
				celestialBodyData.flareCosInner = num3;
				celestialBodyData.flareCosOuter = Mathf.Cos(num + num2);
				celestialBodyData.flareColor = one2;
				Shader.SetGlobalVector(_CelestialBody_Color, celestialBodyData.color);
				Shader.SetGlobalVector(_CelestialBody_Forward, celestialBodyData.forward);
				material.SetFloat(_CelestialBody_DistanceFromCamera, celestialBodyData.distanceFromCamera);
				material.SetVector(_CelestialBody_Right, celestialBodyData.right);
				material.SetFloat(_CelestialBody_AngularRadius, celestialBodyData.angularRadius);
				material.SetFloat(_CelestialBody_Radius, celestialBodyData.radius);
				material.SetVector(_CelestialBody_Up, celestialBodyData.up);
				material.SetInt(_CelestialBody_Type, celestialBodyData.type);
				material.SetVector(_CelestialBody_SurfaceColor, celestialBodyData.surfaceColor);
				material.SetFloat(_CelestialBody_Earthshine, celestialBodyData.earthshine);
				material.SetVector(_CelestialBody_SurfaceTextureScaleOffset, celestialBodyData.surfaceTextureScaleOffset);
				material.SetVector(_CelestialBody_SunDirection, celestialBodyData.sunDirection);
				material.SetFloat(_CelestialBody_FlareCosInner, celestialBodyData.flareCosInner);
				material.SetFloat(_CelestialBody_FlareCosOuter, celestialBodyData.flareCosOuter);
				material.SetFloat(_CelestialBody_FlareSize, celestialBodyData.flareSize);
				material.SetVector(_CelestialBody_FlareColor, celestialBodyData.flareColor);
				material.SetFloat(_CelestialBody_FlareFalloff, celestialBodyData.flareFalloff);
			}
		}

		private static float CornetteShanksPhasePartConstant(float anisotropy)
		{
			return 3f / (8f * MathF.PI) * (1f - anisotropy * anisotropy) / (2f + anisotropy * anisotropy);
		}

		private static float2 ComputeExponentialInterpolationParams(float k)
		{
			if (k == 0f)
			{
				k = 1E-06f;
			}
			float x = 10f * k;
			float y = 1f / (math.exp(x) - 1f);
			return math.float2(x, y);
		}

		private static float3 TransmittanceFromOpticalDepth(float3 opticalDepth)
		{
			return math.exp(-opticalDepth);
		}

		private static float Avg3(float a, float b, float c)
		{
			return (a + b + c) * (1f / 3f);
		}

		private static float3 Desaturate(float3 value, float3 saturation)
		{
			float num = Avg3(value.x, value.y, value.z);
			float3 float5 = value - num;
			return num + float5 * saturation;
		}

		private float3 EvaluateSunColorAttenuation(float3 positionPS, float3 sunDirection, bool estimatePenumbra = false)
		{
			return EvaluateSunColorAttenuation(pbrSky, visualEnvironment, positionPS, sunDirection, estimatePenumbra);
		}

		private static float3 EvaluateSunColorAttenuation(PhysicallyBasedSky pbrSky, VisualEnvironment visualEnvironment, float3 positionPS, float3 sunDirection, bool estimatePenumbra = false)
		{
			float x = math.length(positionPS);
			float num = math.dot(positionPS, sunDirection) * math.rcp(x);
			float planetRadius = visualEnvironment.GetPlanetRadius();
			x = math.max(x, planetRadius);
			float num2 = PhysicallyBasedSky.ComputeCosineOfHorizonAngle(x, planetRadius);
			if (num >= num2)
			{
				float3 opticalDepth = PhysicallyBasedSky.ComputeAtmosphericOpticalDepth(pbrSky.GetAirScaleHeight(), pbrSky.GetAerosolScaleHeight(), pbrSky.GetAirExtinctionCoefficient(), pbrSky.GetAerosolExtinctionCoefficient(), pbrSky.GetOzoneLayerMinimumAltitude(), pbrSky.GetOzoneLayerWidth(), pbrSky.GetOzoneExtinctionCoefficient(), planetRadius, x, num, alwaysAboveHorizon: true);
				float3 value = 1f - TransmittanceFromOpticalDepth(opticalDepth);
				float num3 = math.saturate((num - num2) / 0.0019f);
				float3 float5 = 1f - Desaturate(value, pbrSky.alphaSaturation.value) * pbrSky.alphaMultiplier.value;
				if (!estimatePenumbra)
				{
					return float5;
				}
				return float5 * num3;
			}
			return 0;
		}
	}

	private class SkyViewLUTPass : ScriptableRenderPass
	{
		private class PassData
		{
			internal Material lutMaterial;

			internal TextureHandle multiScatteringLUTHandle;

			internal TextureHandle skyViewLUTHandle;

			internal TextureHandle airSingleScatteringHandle;

			internal TextureHandle aerosolSingleScatteringHandle;

			internal TextureHandle multipleScatteringHandle;

			internal TextureHandle groundIrradianceHandle;

			internal RenderTargetIdentifier[] lutHandles;

			internal bool cameraSpaceSky;

			internal bool precomputedAtmosphericScattering;

			internal bool halfResolutionLuts;

			internal bool precomputationChanged;

			internal bool isStereoEnabled;
		}

		private const string profilerTag = "Precompute Physically Based Sky";

		private readonly ProfilingSampler m_ProfilingSampler = new ProfilingSampler("Precompute Physically Based Sky");

		public PhysicallyBasedSky pbrSky;

		public VisualEnvironment visualEnvironment;

		public CelestialBodyData celestialBodyData;

		private int m_LastPrecomputationParamHash;

		private int m_LastLutDataHash;

		public Material lutMaterial;

		public bool halfResolutionLuts;

		private RTHandle multiScatteringLUTHandle;

		private RTHandle skyViewLUTHandle;

		private RTHandle airSingleScatteringHandle;

		private RTHandle aerosolSingleScatteringHandle;

		private RTHandle multipleScatteringHandle;

		private RTHandle groundIrradianceHandle;

		private const string _MultiScatteringLUT = "_MultiScatteringLUT";

		private const string _SkyViewLUT = "_SkyViewLUT";

		private const string _AirSingleScatteringTexture = "_InScatteredRadianceTable0";

		private const string _AerosolSingleScatteringTexture = "_InScatteredRadianceTable1";

		private const string _MultipleScatteringTexture = "_InScatteredRadianceTable2";

		private const string _GroundIrradianceTexture = "_GroundIrradianceTable";

		private const string STEREO_INSTANCING_ON = "STEREO_INSTANCING_ON";

		private static readonly int airSingleScatteringTexture = Shader.PropertyToID("_AirSingleScatteringTexture");

		private static readonly int aerosolSingleScatteringTexture = Shader.PropertyToID("_AerosolSingleScatteringTexture");

		private static readonly int multipleScatteringTexture = Shader.PropertyToID("_MultipleScatteringTexture");

		private static readonly int groundIrradianceTexture = Shader.PropertyToID("_GroundIrradianceTexture");

		private static readonly int multiScatteringLUT = Shader.PropertyToID("_MultiScatteringLUT");

		private static readonly int skyViewLUT = Shader.PropertyToID("_SkyViewLUT");

		private static readonly int PBSky_TableCoord_Z = Shader.PropertyToID("PBSky_TableCoord_Z");

		public const int k_GroundIrradianceTableSize = 256;

		public const int k_InScatteredRadianceTableSizeX = 128;

		public const int k_InScatteredRadianceTableSizeY = 32;

		public const int k_InScatteredRadianceTableSizeZ = 16;

		public const int k_InScatteredRadianceTableSizeW = 64;

		public const int k_MultiScatteringLutWidth = 32;

		public const int k_MultiScatteringLutHeight = 32;

		public const int k_SkyViewLutWidth = 256;

		public const int k_SkyViewLutHeight = 144;

		public const int k_AtmosphericScatteringLutWidth = 32;

		public const int k_AtmosphericScatteringLutHeight = 32;

		public const int k_AtmosphericScatteringLutDepth = 64;

		private readonly RenderTargetIdentifier[] lutHandles = new RenderTargetIdentifier[3];

		private static readonly Vector4 m_ScaleBias = new Vector4(1f, 1f, 0f, 0f);

		private bool lutDataChanged;

		public SkyViewLUTPass(Material material, ref CelestialBodyData celestialBodyData)
		{
			lutMaterial = material;
			this.celestialBodyData = celestialBodyData;
		}

		[Obsolete]
		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.depthBufferBits = 0;
			descriptor.msaaSamples = 1;
			descriptor.useMipMap = false;
			descriptor.autoGenerateMips = false;
			descriptor.graphicsFormat = GraphicsFormat.B10G11R11_UFloatPack32;
			descriptor.dimension = TextureDimension.Tex2D;
			descriptor.width = 32;
			descriptor.height = 32;
			RenderingUtils.ReAllocateHandleIfNeeded(ref multiScatteringLUTHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_MultiScatteringLUT");
			descriptor.width = 256;
			descriptor.height = 144;
			RenderingUtils.ReAllocateHandleIfNeeded(ref skyViewLUTHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_SkyViewLUT");
			descriptor.width = 256;
			descriptor.height = 1;
			lutDataChanged = RenderingUtils.ReAllocateHandleIfNeeded(ref groundIrradianceHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_GroundIrradianceTable");
			descriptor.memoryless = RenderTextureMemoryless.None;
			descriptor.dimension = TextureDimension.Tex3D;
			descriptor.width = (halfResolutionLuts ? 64 : 128);
			descriptor.height = (halfResolutionLuts ? 512 : 1024);
			descriptor.volumeDepth = (halfResolutionLuts ? 16 : 32);
			lutDataChanged |= RenderingUtils.ReAllocateHandleIfNeeded(ref airSingleScatteringHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_InScatteredRadianceTable0");
			lutDataChanged |= RenderingUtils.ReAllocateHandleIfNeeded(ref aerosolSingleScatteringHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_InScatteredRadianceTable1");
			lutDataChanged |= RenderingUtils.ReAllocateHandleIfNeeded(ref multipleScatteringHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_InScatteredRadianceTable2");
			lutDataChanged |= HasLutDataChanged();
			m_LastPrecomputationParamHash = ((!lutDataChanged) ? m_LastPrecomputationParamHash : 0);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			bool flag = HasPrecomputationDataChanged() || lutDataChanged;
			bool flag2 = visualEnvironment.renderingSpace.value == VisualEnvironment.RenderingSpace.Camera;
			bool stereoEnabled = renderingData.cameraData.camera.stereoEnabled;
			using (new ProfilingScope(commandBuffer, m_ProfilingSampler))
			{
				if (stereoEnabled)
				{
					commandBuffer.DisableShaderKeyword("STEREO_INSTANCING_ON");
				}
				if (flag)
				{
					Blitter.BlitCameraTexture(commandBuffer, multiScatteringLUTHandle, multiScatteringLUTHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, lutMaterial, 1);
				}
				lutMaterial.SetTexture(multiScatteringLUT, multiScatteringLUTHandle);
				if (flag2)
				{
					Blitter.BlitCameraTexture(commandBuffer, skyViewLUTHandle, skyViewLUTHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, lutMaterial, 0);
				}
				commandBuffer.SetGlobalTexture(skyViewLUT, skyViewLUTHandle);
				if (flag)
				{
					lutHandles[0] = airSingleScatteringHandle;
					lutHandles[1] = aerosolSingleScatteringHandle;
					lutHandles[2] = multipleScatteringHandle;
					int num = (halfResolutionLuts ? 16 : 32);
					for (int i = 0; i < num; i++)
					{
						commandBuffer.SetGlobalInteger(PBSky_TableCoord_Z, i);
						commandBuffer.SetRenderTarget(lutHandles, airSingleScatteringHandle, 0, CubemapFace.Unknown, i);
						Blitter.BlitTexture(commandBuffer, airSingleScatteringHandle, m_ScaleBias, lutMaterial, 2);
					}
					if (!flag2)
					{
						Blitter.BlitCameraTexture(commandBuffer, groundIrradianceHandle, groundIrradianceHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, lutMaterial, 3);
					}
				}
				commandBuffer.SetGlobalTexture(airSingleScatteringTexture, airSingleScatteringHandle);
				commandBuffer.SetGlobalTexture(aerosolSingleScatteringTexture, aerosolSingleScatteringHandle);
				commandBuffer.SetGlobalTexture(multipleScatteringTexture, multipleScatteringHandle);
				commandBuffer.SetGlobalTexture(groundIrradianceTexture, groundIrradianceHandle);
				commandBuffer.SetRenderTarget(renderingData.cameraData.renderer.cameraColorTargetHandle, renderingData.cameraData.renderer.cameraDepthTargetHandle);
				if (stereoEnabled)
				{
					commandBuffer.EnableShaderKeyword("STEREO_INSTANCING_ON");
				}
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		private static void ExecutePass(PassData data, UnsafeGraphContext context)
		{
			CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
			if (data.isStereoEnabled)
			{
				nativeCommandBuffer.DisableShaderKeyword("STEREO_INSTANCING_ON");
			}
			if (data.precomputationChanged)
			{
				Blitter.BlitCameraTexture(nativeCommandBuffer, data.multiScatteringLUTHandle, data.multiScatteringLUTHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, data.lutMaterial, 1);
			}
			data.lutMaterial.SetTexture(multiScatteringLUT, data.multiScatteringLUTHandle);
			if (data.cameraSpaceSky)
			{
				Blitter.BlitCameraTexture(nativeCommandBuffer, data.skyViewLUTHandle, data.skyViewLUTHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, data.lutMaterial, 0);
			}
			nativeCommandBuffer.SetGlobalTexture(skyViewLUT, data.skyViewLUTHandle);
			if (data.precomputationChanged)
			{
				data.lutHandles[0] = data.airSingleScatteringHandle;
				data.lutHandles[1] = data.aerosolSingleScatteringHandle;
				data.lutHandles[2] = data.multipleScatteringHandle;
				int num = (data.halfResolutionLuts ? 16 : 32);
				for (int i = 0; i < num; i++)
				{
					nativeCommandBuffer.SetGlobalInteger(PBSky_TableCoord_Z, i);
					nativeCommandBuffer.SetRenderTarget(data.lutHandles, data.airSingleScatteringHandle, 0, CubemapFace.Unknown, i);
					Blitter.BlitTexture(nativeCommandBuffer, data.airSingleScatteringHandle, m_ScaleBias, data.lutMaterial, 2);
				}
				if (!data.cameraSpaceSky)
				{
					Blitter.BlitCameraTexture(nativeCommandBuffer, data.groundIrradianceHandle, data.groundIrradianceHandle, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, data.lutMaterial, 3);
				}
			}
			nativeCommandBuffer.SetGlobalTexture(airSingleScatteringTexture, data.airSingleScatteringHandle);
			nativeCommandBuffer.SetGlobalTexture(aerosolSingleScatteringTexture, data.aerosolSingleScatteringHandle);
			nativeCommandBuffer.SetGlobalTexture(multipleScatteringTexture, data.multipleScatteringHandle);
			nativeCommandBuffer.SetGlobalTexture(groundIrradianceTexture, data.groundIrradianceHandle);
			if (data.isStereoEnabled)
			{
				nativeCommandBuffer.EnableShaderKeyword("STEREO_INSTANCING_ON");
			}
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Precompute Physically Based Sky", out passData, ".\\Library\\PackageCache\\com.jiaozi158.unity-physically-based-sky-urp\\Runtime\\PhysicallyBasedSkyURP.cs", 1374);
			frameData.Get<UniversalRenderingData>();
			frameData.Get<UniversalResourceData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			bool flag = HasPrecomputationDataChanged();
			RenderTextureDescriptor descriptor = universalCameraData.cameraTargetDescriptor;
			descriptor.depthBufferBits = 0;
			descriptor.msaaSamples = 1;
			descriptor.useMipMap = false;
			descriptor.autoGenerateMips = false;
			descriptor.graphicsFormat = GraphicsFormat.B10G11R11_UFloatPack32;
			descriptor.dimension = TextureDimension.Tex2D;
			descriptor.width = 32;
			descriptor.height = 32;
			RenderingUtils.ReAllocateHandleIfNeeded(ref multiScatteringLUTHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_MultiScatteringLUT");
			TextureHandle textureHandle = renderGraph.ImportTexture(multiScatteringLUTHandle);
			descriptor.width = 256;
			descriptor.height = 144;
			RenderingUtils.ReAllocateHandleIfNeeded(ref skyViewLUTHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_SkyViewLUT");
			TextureHandle textureHandle2 = renderGraph.ImportTexture(skyViewLUTHandle);
			descriptor.width = 256;
			descriptor.height = 1;
			bool flag2 = RenderingUtils.ReAllocateHandleIfNeeded(ref groundIrradianceHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_GroundIrradianceTable");
			TextureHandle textureHandle3 = renderGraph.ImportTexture(groundIrradianceHandle);
			descriptor.dimension = TextureDimension.Tex3D;
			descriptor.width = (halfResolutionLuts ? 64 : 128);
			descriptor.height = (halfResolutionLuts ? 512 : 1024);
			descriptor.volumeDepth = (halfResolutionLuts ? 16 : 32);
			flag2 |= RenderingUtils.ReAllocateHandleIfNeeded(ref airSingleScatteringHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_InScatteredRadianceTable0");
			TextureHandle textureHandle4 = renderGraph.ImportTexture(airSingleScatteringHandle);
			flag2 |= RenderingUtils.ReAllocateHandleIfNeeded(ref aerosolSingleScatteringHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_InScatteredRadianceTable1");
			TextureHandle textureHandle5 = renderGraph.ImportTexture(aerosolSingleScatteringHandle);
			flag2 |= RenderingUtils.ReAllocateHandleIfNeeded(ref multipleScatteringHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_InScatteredRadianceTable2");
			TextureHandle textureHandle6 = renderGraph.ImportTexture(multipleScatteringHandle);
			flag2 |= HasLutDataChanged();
			m_LastPrecomputationParamHash = ((!flag2) ? m_LastPrecomputationParamHash : 0);
			passData.lutHandles = lutHandles;
			passData.multiScatteringLUTHandle = textureHandle;
			passData.skyViewLUTHandle = textureHandle2;
			passData.airSingleScatteringHandle = textureHandle4;
			passData.aerosolSingleScatteringHandle = textureHandle5;
			passData.multipleScatteringHandle = textureHandle6;
			passData.groundIrradianceHandle = textureHandle3;
			passData.cameraSpaceSky = visualEnvironment.renderingSpace.value == VisualEnvironment.RenderingSpace.Camera;
			passData.precomputedAtmosphericScattering = pbrSky.atmosphericScattering.value;
			passData.halfResolutionLuts = halfResolutionLuts;
			passData.precomputationChanged = flag || flag2;
			passData.isStereoEnabled = universalCameraData.camera.stereoEnabled;
			passData.lutMaterial = lutMaterial;
			unsafeRenderGraphBuilder.UseTexture(in passData.multiScatteringLUTHandle, AccessFlags.ReadWrite);
			unsafeRenderGraphBuilder.UseTexture(in passData.skyViewLUTHandle, AccessFlags.ReadWrite);
			unsafeRenderGraphBuilder.AllowGlobalStateModification(value: true);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				ExecutePass(data, context);
			});
		}

		public void Dispose()
		{
			m_LastPrecomputationParamHash = 0;
			m_LastLutDataHash = 0;
			multiScatteringLUTHandle?.Release();
			skyViewLUTHandle?.Release();
			airSingleScatteringHandle?.Release();
			aerosolSingleScatteringHandle?.Release();
			multipleScatteringHandle?.Release();
			groundIrradianceHandle?.Release();
		}

		private int GetLutDataHash()
		{
			return (((13 * 23 + airSingleScatteringHandle.GetHashCode()) * 23 + aerosolSingleScatteringHandle.GetHashCode()) * 23 + multipleScatteringHandle.GetHashCode()) * 23 + groundIrradianceHandle.GetHashCode();
		}

		private bool HasPrecomputationDataChanged()
		{
			int precomputationHashCode = pbrSky.GetPrecomputationHashCode();
			precomputationHashCode = precomputationHashCode * 23 + visualEnvironment.planetRadius.GetHashCode();
			precomputationHashCode = precomputationHashCode * 23 + visualEnvironment.renderingSpace.GetHashCode();
			precomputationHashCode += halfResolutionLuts.GetHashCode();
			if (precomputationHashCode != m_LastPrecomputationParamHash || m_LastPrecomputationParamHash == 0)
			{
				m_LastPrecomputationParamHash = precomputationHashCode;
				return true;
			}
			return false;
		}

		private bool HasLutDataChanged()
		{
			int lutDataHash = GetLutDataHash();
			if (lutDataHash != m_LastLutDataHash || m_LastLutDataHash == 0)
			{
				m_LastLutDataHash = lutDataHash;
				return true;
			}
			return false;
		}
	}

	private class AtmosphericScatteringPass : ScriptableRenderPass
	{
		private class PassData
		{
			internal Material lutMaterial;

			internal TextureHandle cameraColorHandle;

			internal bool enableFog;
		}

		private const string profilerTag = "Opaque Atmospheric Scattering";

		private readonly ProfilingSampler m_ProfilingSampler = new ProfilingSampler("Opaque Atmospheric Scattering");

		public PhysicallyBasedSky pbrSky;

		public VisualEnvironment visualEnvironment;

		public Fog fog;

		public Material lutMaterial;

		private static readonly int _FogEnabled = Shader.PropertyToID("_FogEnabled");

		private static readonly int _MaxFogDistance = Shader.PropertyToID("_MaxFogDistance");

		private static readonly int _FogColor = Shader.PropertyToID("_FogColor");

		private static readonly int _FogColorMode = Shader.PropertyToID("_FogColorMode");

		private static readonly int _MipFogParameters = Shader.PropertyToID("_MipFogParameters");

		private static readonly int _HeightFogBaseScattering = Shader.PropertyToID("_HeightFogBaseScattering");

		private static readonly int _HeightFogBaseExtinction = Shader.PropertyToID("_HeightFogBaseExtinction");

		private static readonly int _HeightFogBaseHeight = Shader.PropertyToID("_HeightFogBaseHeight");

		private static readonly int _HeightFogExponents = Shader.PropertyToID("_HeightFogExponents");

		private static readonly int _PlanetUpAltitude = Shader.PropertyToID("_PlanetUpAltitude");

		private static readonly int _UnderWaterEnabled = Shader.PropertyToID("_UnderWaterEnabled");

		private static readonly int _FogWaterHeight = Shader.PropertyToID("_FogWaterHeight");

		public AtmosphericScatteringPass(Material lutMaterial)
		{
			this.lutMaterial = lutMaterial;
		}

		[Obsolete]
		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			if (fog != null && fog.IsActive())
			{
				UpdateFogProperties(renderingData.cameraData.camera);
			}
			ConfigureInput(ScriptableRenderPassInput.Depth);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, m_ProfilingSampler))
			{
				bool flag = fog != null && fog.IsActive();
				commandBuffer.SetGlobalInteger(_FogEnabled, flag ? 1 : 0);
				RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
				if (cameraColorTargetHandle != null)
				{
					Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, cameraColorTargetHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, lutMaterial, 4);
				}
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		private static void ExecutePass(PassData data, UnsafeGraphContext context)
		{
			CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
			nativeCommandBuffer.SetGlobalInteger(_FogEnabled, data.enableFog ? 1 : 0);
			Blitter.BlitCameraTexture(nativeCommandBuffer, data.cameraColorHandle, data.cameraColorHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, data.lutMaterial, 4);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Opaque Atmospheric Scattering", out passData, ".\\Library\\PackageCache\\com.jiaozi158.unity-physically-based-sky-urp\\Runtime\\PhysicallyBasedSkyURP.cs", 1660);
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			bool flag = fog != null && fog.IsActive();
			if (flag)
			{
				UpdateFogProperties(universalCameraData.camera);
			}
			passData.lutMaterial = lutMaterial;
			passData.cameraColorHandle = universalResourceData.activeColorTexture;
			passData.enableFog = flag;
			ConfigureInput(ScriptableRenderPassInput.Depth);
			unsafeRenderGraphBuilder.UseTexture(universalResourceData.activeColorTexture, AccessFlags.ReadWrite);
			unsafeRenderGraphBuilder.AllowGlobalStateModification(value: true);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				ExecutePass(data, context);
			});
		}

		public void Dispose()
		{
		}

		public void UpdateFogProperties(Camera camera)
		{
			Vector3 position = camera.transform.position;
			float4 planetCenterRadius = visualEnvironment.GetPlanetCenterRadius(position);
			float w = planetCenterRadius.w;
			Vector3 vector = planetCenterRadius.xyz;
			Vector3 vector2 = -(vector - position).normalized;
			float w2 = Vector3.Dot(position - (vector2 * w + vector), vector2);
			float4 float5 = math.float4(vector2, w2);
			Shader.SetGlobalInteger(_FogEnabled, 1);
			Shader.SetGlobalFloat(_MaxFogDistance, fog.maxFogDistance.value);
			Color color = ((fog.colorMode.value == Fog.FogColorMode.ConstantColor) ? fog.color.value : fog.tint.value);
			Shader.SetGlobalFloat(_FogColorMode, (float)fog.colorMode.value);
			Shader.SetGlobalVector(_FogColor, new Color(color.r, color.g, color.b, 0f));
			Shader.SetGlobalVector(_MipFogParameters, new Vector4(fog.mipFogNear.value, fog.mipFogFar.value, fog.mipFogMaxMip.value, 0f));
			float num = ExtinctionFromMeanFreePath(fog.meanFreePath.value);
			Shader.SetGlobalVector(_HeightFogBaseScattering, Vector4.one * num);
			Shader.SetGlobalFloat(_HeightFogBaseExtinction, num);
			float value = fog.baseHeight.value;
			Shader.SetGlobalVector(_PlanetUpAltitude, float5);
			Shader.SetGlobalFloat(_HeightFogBaseHeight, value - float5.w);
			float num2 = ScaleHeightFromLayerDepth(Mathf.Max(0.01f, fog.maximumHeight.value - fog.baseHeight.value));
			Shader.SetGlobalVector(_HeightFogExponents, new Vector2(1f / num2, num2));
			Shader.SetGlobalFloat(_UnderWaterEnabled, fog.underWater.value ? 1f : 0f);
			Shader.SetGlobalFloat(_FogWaterHeight, fog.waterHeight.value);
		}

		private static float ExtinctionFromMeanFreePath(float meanFreePath)
		{
			return 1f / meanFreePath;
		}

		private static float ScaleHeightFromLayerDepth(float d)
		{
			return d * 0.144765f;
		}
	}

	private class PBSkyPostPass : ScriptableRenderPass
	{
		private class PassData
		{
		}

		private const string profilerTag = "Cleanup Physically Based Sky";

		private readonly ProfilingSampler m_ProfilingSampler = new ProfilingSampler("Cleanup Physically Based Sky");

		public PhysicallyBasedSky pbrSky;

		private const string PHYSICALLY_BASED_SKY = "PHYSICALLY_BASED_SKY";

		private const string SKY_NOT_BAKING = "SKY_NOT_BAKING";

		private static readonly int _EnableAtmosphericScattering = Shader.PropertyToID("_EnableAtmosphericScattering");

		private static readonly int _FogEnabled = Shader.PropertyToID("_FogEnabled");

		private static readonly int _SkyTextureMipCounts = Shader.PropertyToID("_SkyTextureMipCounts");

		[Obsolete]
		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, m_ProfilingSampler))
			{
				commandBuffer.SetGlobalFloat(_EnableAtmosphericScattering, 0f);
				commandBuffer.SetGlobalInteger(_FogEnabled, 0);
				commandBuffer.SetGlobalFloat(_SkyTextureMipCounts, 0f);
				commandBuffer.DisableShaderKeyword("PHYSICALLY_BASED_SKY");
				commandBuffer.DisableShaderKeyword("SKY_NOT_BAKING");
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		private static void ExecutePass(UnsafeGraphContext context)
		{
			CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
			nativeCommandBuffer.SetGlobalFloat(_EnableAtmosphericScattering, 0f);
			nativeCommandBuffer.SetGlobalInteger(_FogEnabled, 0);
			nativeCommandBuffer.SetGlobalFloat(_SkyTextureMipCounts, 0f);
			nativeCommandBuffer.DisableShaderKeyword("PHYSICALLY_BASED_SKY");
			nativeCommandBuffer.DisableShaderKeyword("SKY_NOT_BAKING");
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Cleanup Physically Based Sky", out passData, ".\\Library\\PackageCache\\com.jiaozi158.unity-physically-based-sky-urp\\Runtime\\PhysicallyBasedSkyURP.cs", 1829);
			unsafeRenderGraphBuilder.AllowGlobalStateModification(value: true);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				ExecutePass(context);
			});
		}

		public void Dispose()
		{
		}
	}

	private class AmbientProbePass : ScriptableRenderPass
	{
		private class PassData
		{
			internal Material cloudsMaterial;

			internal TextureHandle probeColorHandle;

			internal TextureHandle skyColorHandle;

			internal Vector3 cameraPositionWS;

			internal Vector4 cameraScreenParams;

			internal Vector4 cameraScreenSize;

			internal Matrix4x4 worldToCameraMatrix;

			internal Matrix4x4 projectionMatrix;

			internal RendererListHandle[] rendererListHandles;

			internal Matrix4x4[] skyViewMatrices;

			internal Matrix4x4 skyProjectionMatrix;

			internal bool isDynamicAmbientMode;

			internal bool isPbrSky;

			internal bool hasVolumetricClouds;

			internal bool isStereoEnabled;

			internal int skyTextureMipCounts;
		}

		private const string profilerTag = "Update Environment Reflection";

		private readonly ProfilingSampler m_ProfilingSampler = new ProfilingSampler("Update Environment Reflection");

		public VisualEnvironment visualEnvironment;

		public Material cloudsMaterial;

		public bool isPbrSky;

		private RTHandle probeColorHandle;

		private RTHandle skyColorHandle;

		private static readonly int reflectionResolution = 128;

		private const string _GlossyEnvironmentCubeMap = "_GlossyEnvironmentCubeMap";

		private const string _SkyTexture = "_SkyTexture";

		private const string VOLUMETRIC_CLOUDS = "VOLUMETRIC_CLOUDS";

		private const string STEREO_INSTANCING_ON = "STEREO_INSTANCING_ON";

		private static readonly int glossyEnvironmentCubeMap = Shader.PropertyToID("_GlossyEnvironmentCubeMap");

		private static readonly int skyTexture = Shader.PropertyToID("_SkyTexture");

		private static readonly int worldSpaceCameraPos = Shader.PropertyToID("_WorldSpaceCameraPos");

		private static readonly int disableSunDisk = Shader.PropertyToID("_DisableSunDisk");

		private static readonly int unity_MatrixInvVP = Shader.PropertyToID("unity_MatrixInvVP");

		private static readonly int scaledScreenParams = Shader.PropertyToID("_ScaledScreenParams");

		private static readonly int screenSize = Shader.PropertyToID("_ScreenSize");

		private static readonly int skyTextureMipCounts = Shader.PropertyToID("_SkyTextureMipCounts");

		private static readonly Matrix4x4 frontView = new Matrix4x4(math.float4(-1f, 0f, 0f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(0f, 0f, -1f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 backView = new Matrix4x4(math.float4(1f, 0f, 0f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(0f, 0f, 1f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 upView = new Matrix4x4(math.float4(1f, 0f, 0f, 0f), math.float4(0f, 0f, -1f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 downView = new Matrix4x4(math.float4(1f, 0f, 0f, 0f), math.float4(0f, 0f, 1f, 0f), math.float4(0f, 1f, 0f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 rightView = new Matrix4x4(math.float4(0f, 0f, -1f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(1f, 0f, 0f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 leftView = new Matrix4x4(math.float4(0f, 0f, 1f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(-1f, 0f, 0f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4[] skyViews = new Matrix4x4[6] { rightView, leftView, upView, downView, backView, frontView };

		private readonly RendererListHandle[] rendererListHandles = new RendererListHandle[6];

		private readonly Matrix4x4[] skyViewMatrices = new Matrix4x4[6];

		private static readonly Vector4 m_ScaleBias = new Vector4(1f, 1f, 0f, 0f);

		private static readonly Matrix4x4 skyProjectionMatrix = Matrix4x4.Perspective(90f, 1f, 0.1f, 10f);

		private static readonly Vector4 skyViewScreenParams = new Vector4(reflectionResolution, reflectionResolution, 1f + math.rcp(reflectionResolution), 1f + math.rcp(reflectionResolution));

		private static readonly Vector4 skyViewScreenSize = new Vector4(reflectionResolution, reflectionResolution, math.rcp(reflectionResolution), math.rcp(reflectionResolution));

		public AmbientProbePass(Material material)
		{
			cloudsMaterial = material;
		}

		[Obsolete]
		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.msaaSamples = 1;
			descriptor.useMipMap = true;
			descriptor.autoGenerateMips = true;
			descriptor.width = reflectionResolution;
			descriptor.height = reflectionResolution;
			descriptor.dimension = TextureDimension.Cube;
			descriptor.graphicsFormat = GraphicsFormat.B10G11R11_UFloatPack32;
			descriptor.depthStencilFormat = GraphicsFormat.None;
			descriptor.depthBufferBits = 0;
			bool num = cloudsMaterial != null && Shader.IsKeywordEnabled("VOLUMETRIC_CLOUDS");
			RenderingUtils.ReAllocateHandleIfNeeded(ref probeColorHandle, in descriptor, FilterMode.Trilinear, TextureWrapMode.Clamp, 1, 0f, "_GlossyEnvironmentCubeMap");
			if (num)
			{
				RenderingUtils.ReAllocateHandleIfNeeded(ref skyColorHandle, in descriptor, FilterMode.Trilinear, TextureWrapMode.Clamp, 1, 0f, "_SkyTexture");
			}
			ConfigureTarget(probeColorHandle, probeColorHandle);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			Camera camera = renderingData.cameraData.camera;
			RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
			bool stereoEnabled = camera.stereoEnabled;
			using (new ProfilingScope(commandBuffer, m_ProfilingSampler))
			{
				if (stereoEnabled)
				{
					commandBuffer.DisableShaderKeyword("STEREO_INSTANCING_ON");
				}
				float2 float5 = math.float2(cameraTargetDescriptor.width, cameraTargetDescriptor.height);
				Vector3 position = camera.transform.position;
				Vector4 value = new Vector4(float5.x, float5.y, math.rcp(float5.x), math.rcp(float5.y));
				Vector4 value2 = new Vector4(float5.x, float5.y, 1f + value.z, 1f + value.w);
				bool flag = visualEnvironment.skyAmbientMode.value == VisualEnvironment.SkyAmbientMode.Dynamic;
				Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(skyProjectionMatrix, renderIntoTexture: true);
				commandBuffer.SetGlobalVector(worldSpaceCameraPos, Vector3.zero);
				commandBuffer.SetGlobalFloat(disableSunDisk, 1f);
				commandBuffer.SetGlobalVector(scaledScreenParams, skyViewScreenParams);
				commandBuffer.SetGlobalVector(screenSize, skyViewScreenSize);
				bool flag2 = cloudsMaterial != null && Shader.IsKeywordEnabled("VOLUMETRIC_CLOUDS");
				for (int i = 0; i < 6; i++)
				{
					CoreUtils.SetRenderTarget(commandBuffer, flag2 ? skyColorHandle : probeColorHandle, ClearFlag.None, 0, (CubemapFace)i);
					Matrix4x4 matrix4x = skyViews[i];
					matrix4x *= Matrix4x4.Scale(new Vector3(1f, 1f, -1f));
					skyViewMatrices[i] = matrix4x;
					Matrix4x4 matrix4x2 = gPUProjectionMatrix * skyViewMatrices[i];
					commandBuffer.SetViewMatrix(skyViewMatrices[i]);
					commandBuffer.SetGlobalMatrix(unity_MatrixInvVP, matrix4x2.inverse);
					if (isPbrSky)
					{
						Blitter.BlitTexture(commandBuffer, probeColorHandle, m_ScaleBias, RenderSettings.skybox, 1);
						continue;
					}
					RendererList rendererList = context.CreateSkyboxRendererList(camera, skyProjectionMatrix, skyViewMatrices[i]);
					commandBuffer.DrawRendererList(rendererList);
				}
				commandBuffer.SetGlobalTexture(skyTexture, flag2 ? skyColorHandle : probeColorHandle);
				int num = ((visualEnvironment.skyAmbientMode.value == VisualEnvironment.SkyAmbientMode.Dynamic) ? (flag2 ? skyColorHandle.rt.mipmapCount : probeColorHandle.rt.mipmapCount) : 0);
				commandBuffer.SetGlobalFloat(skyTextureMipCounts, num);
				if (flag2)
				{
					commandBuffer.CopyTexture(skyColorHandle, probeColorHandle);
					for (int j = 0; j < 6; j++)
					{
						Matrix4x4 matrix4x3 = gPUProjectionMatrix * skyViewMatrices[j];
						commandBuffer.SetViewMatrix(skyViewMatrices[j]);
						commandBuffer.SetGlobalMatrix(unity_MatrixInvVP, matrix4x3.inverse);
						CoreUtils.SetRenderTarget(commandBuffer, probeColorHandle, ClearFlag.None, 0, (CubemapFace)j);
						Blitter.BlitTexture(commandBuffer, probeColorHandle, m_ScaleBias, cloudsMaterial, 8);
					}
				}
				commandBuffer.SetGlobalTexture(glossyEnvironmentCubeMap, probeColorHandle);
				RenderSettings.defaultReflectionMode = (flag ? DefaultReflectionMode.Custom : RenderSettings.defaultReflectionMode);
				RenderSettings.customReflectionTexture = (flag ? probeColorHandle : null);
				commandBuffer.SetGlobalVector(worldSpaceCameraPos, position);
				commandBuffer.SetGlobalFloat(disableSunDisk, 0f);
				Matrix4x4 matrix4x4 = GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: true) * camera.worldToCameraMatrix;
				commandBuffer.SetViewMatrix(camera.worldToCameraMatrix);
				commandBuffer.SetGlobalMatrix(unity_MatrixInvVP, matrix4x4.inverse);
				commandBuffer.SetGlobalVector(scaledScreenParams, value2);
				commandBuffer.SetGlobalVector(screenSize, value);
				if (stereoEnabled)
				{
					commandBuffer.EnableShaderKeyword("STEREO_INSTANCING_ON");
				}
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		private static void ExecutePass(PassData data, UnsafeGraphContext context)
		{
			CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
			if (data.isStereoEnabled)
			{
				nativeCommandBuffer.DisableShaderKeyword("STEREO_INSTANCING_ON");
			}
			context.cmd.SetGlobalVector(worldSpaceCameraPos, Vector3.zero);
			context.cmd.SetGlobalFloat(disableSunDisk, 1f);
			context.cmd.SetGlobalVector(scaledScreenParams, skyViewScreenParams);
			context.cmd.SetGlobalVector(screenSize, skyViewScreenSize);
			Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(data.skyProjectionMatrix, renderIntoTexture: true);
			for (int i = 0; i < 6; i++)
			{
				CoreUtils.SetRenderTarget(nativeCommandBuffer, data.hasVolumetricClouds ? data.skyColorHandle : data.probeColorHandle, ClearFlag.None, 0, (CubemapFace)i);
				Matrix4x4 matrix4x = gPUProjectionMatrix * data.skyViewMatrices[i];
				nativeCommandBuffer.SetViewMatrix(data.skyViewMatrices[i]);
				context.cmd.SetGlobalMatrix(unity_MatrixInvVP, matrix4x.inverse);
				if (data.isPbrSky)
				{
					Blitter.BlitTexture(nativeCommandBuffer, data.probeColorHandle, m_ScaleBias, RenderSettings.skybox, 1);
				}
				else
				{
					context.cmd.DrawRendererList(data.rendererListHandles[i]);
				}
			}
			nativeCommandBuffer.SetGlobalTexture(skyTexture, data.hasVolumetricClouds ? data.skyColorHandle : data.probeColorHandle);
			nativeCommandBuffer.SetGlobalFloat(skyTextureMipCounts, data.skyTextureMipCounts);
			if (data.hasVolumetricClouds)
			{
				nativeCommandBuffer.CopyTexture(data.skyColorHandle, data.probeColorHandle);
				for (int j = 0; j < 6; j++)
				{
					Matrix4x4 matrix4x2 = gPUProjectionMatrix * data.skyViewMatrices[j];
					nativeCommandBuffer.SetViewMatrix(data.skyViewMatrices[j]);
					context.cmd.SetGlobalMatrix(unity_MatrixInvVP, matrix4x2.inverse);
					CoreUtils.SetRenderTarget(nativeCommandBuffer, data.probeColorHandle, ClearFlag.None, 0, (CubemapFace)j);
					Blitter.BlitTexture(nativeCommandBuffer, data.probeColorHandle, m_ScaleBias, data.cloudsMaterial, 8);
				}
			}
			context.cmd.SetGlobalTexture(glossyEnvironmentCubeMap, data.probeColorHandle);
			RenderSettings.defaultReflectionMode = (data.isDynamicAmbientMode ? DefaultReflectionMode.Custom : RenderSettings.defaultReflectionMode);
			RenderSettings.customReflectionTexture = (data.isDynamicAmbientMode ? ((Texture)data.probeColorHandle) : null);
			context.cmd.SetGlobalVector(worldSpaceCameraPos, data.cameraPositionWS);
			context.cmd.SetGlobalFloat(disableSunDisk, 0f);
			Matrix4x4 matrix4x3 = GL.GetGPUProjectionMatrix(data.projectionMatrix, renderIntoTexture: true) * data.worldToCameraMatrix;
			nativeCommandBuffer.SetViewMatrix(data.worldToCameraMatrix);
			context.cmd.SetGlobalMatrix(unity_MatrixInvVP, matrix4x3.inverse);
			context.cmd.SetGlobalVector(scaledScreenParams, data.cameraScreenParams);
			context.cmd.SetGlobalVector(screenSize, data.cameraScreenSize);
			if (data.isStereoEnabled)
			{
				nativeCommandBuffer.EnableShaderKeyword("STEREO_INSTANCING_ON");
			}
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Update Environment Reflection", out passData, ".\\Library\\PackageCache\\com.jiaozi158.unity-physically-based-sky-urp\\Runtime\\PhysicallyBasedSkyURP.cs", 2167);
			frameData.Get<UniversalRenderingData>();
			frameData.Get<UniversalResourceData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			bool flag = cloudsMaterial != null && Shader.IsKeywordEnabled("VOLUMETRIC_CLOUDS");
			RenderTextureDescriptor descriptor = universalCameraData.cameraTargetDescriptor;
			float2 float5 = math.float2(descriptor.width, descriptor.height);
			descriptor.msaaSamples = 1;
			descriptor.useMipMap = true;
			descriptor.autoGenerateMips = true;
			descriptor.width = reflectionResolution;
			descriptor.height = reflectionResolution;
			descriptor.dimension = TextureDimension.Cube;
			descriptor.graphicsFormat = GraphicsFormat.B10G11R11_UFloatPack32;
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateHandleIfNeeded(ref probeColorHandle, in descriptor, FilterMode.Trilinear, TextureWrapMode.Clamp, 1, 0f, "_GlossyEnvironmentCubeMap");
			TextureHandle textureHandle = renderGraph.ImportTexture(probeColorHandle);
			passData.probeColorHandle = textureHandle;
			if (flag)
			{
				RenderingUtils.ReAllocateHandleIfNeeded(ref skyColorHandle, in descriptor, FilterMode.Trilinear, TextureWrapMode.Clamp, 1, 0f, "_SkyTexture");
				TextureHandle textureHandle2 = renderGraph.ImportTexture(skyColorHandle);
				passData.skyColorHandle = textureHandle2;
			}
			passData.skyTextureMipCounts = ((visualEnvironment.skyAmbientMode.value == VisualEnvironment.SkyAmbientMode.Dynamic) ? (flag ? skyColorHandle.rt.mipmapCount : probeColorHandle.rt.mipmapCount) : 0);
			passData.cloudsMaterial = cloudsMaterial;
			for (int i = 0; i < 6; i++)
			{
				Matrix4x4 matrix4x = skyViews[i];
				matrix4x *= Matrix4x4.Scale(new Vector3(1f, 1f, -1f));
				skyViewMatrices[i] = matrix4x;
				rendererListHandles[i] = renderGraph.CreateSkyboxRendererList(in universalCameraData.camera, skyProjectionMatrix, matrix4x);
				unsafeRenderGraphBuilder.UseRendererList(in rendererListHandles[i]);
			}
			passData.rendererListHandles = rendererListHandles;
			passData.skyViewMatrices = skyViewMatrices;
			passData.skyProjectionMatrix = skyProjectionMatrix;
			passData.cloudsMaterial = cloudsMaterial;
			passData.cameraPositionWS = universalCameraData.camera.transform.position;
			passData.cameraScreenSize = new Vector4(float5.x, float5.y, math.rcp(float5.x), math.rcp(float5.y));
			passData.cameraScreenParams = new Vector4(float5.x, float5.y, 1f + passData.cameraScreenSize.z, 1f + passData.cameraScreenSize.w);
			passData.worldToCameraMatrix = universalCameraData.camera.worldToCameraMatrix;
			passData.projectionMatrix = universalCameraData.camera.projectionMatrix;
			passData.isDynamicAmbientMode = visualEnvironment.skyAmbientMode.value == VisualEnvironment.SkyAmbientMode.Dynamic;
			passData.isPbrSky = isPbrSky;
			passData.hasVolumetricClouds = flag;
			passData.isStereoEnabled = universalCameraData.camera.stereoEnabled;
			unsafeRenderGraphBuilder.UseTexture(in passData.probeColorHandle, AccessFlags.Write);
			if (flag)
			{
				unsafeRenderGraphBuilder.UseTexture(in passData.skyColorHandle, AccessFlags.Write);
			}
			unsafeRenderGraphBuilder.AllowGlobalStateModification(value: true);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				ExecutePass(data, context);
			});
		}

		public void Dispose()
		{
			probeColorHandle?.Release();
			skyColorHandle?.Release();
		}
	}

	private Material m_PbrSkyMaterial;

	private Material m_PbrSkyLUTMaterial;

	[Header("Setup")]
	[Tooltip("The shader of physically based sky.")]
	[SerializeField]
	private Shader m_Shader;

	[Tooltip("The precomputation shader of physically based sky.")]
	[SerializeField]
	private Shader m_LutShader;

	[Header("Performance")]
	[Tooltip("The precomputation quality of physically based sky.")]
	[SerializeField]
	private PrecomputationQualityMode m_Precomputation;

	private bool isShaderMismatchLogPrinted;

	private int lastSkyType;

	private VisualEnvironment.SkyAmbientMode lastSkyAmbientMode;

	private CelestialBodyData m_CelestialBodyData;

	private PBSkyPrePass m_PBSkyPrePass;

	private SkyViewLUTPass m_SkyViewLUTPass;

	private AtmosphericScatteringPass m_AtmosphericScatteringPass;

	private AmbientProbePass m_AmbientProbePass;

	private PBSkyPostPass m_PBSkyPostPass;

	[Header("Sky")]
	[Tooltip("The fallback sky material when physically based sky is disabled.")]
	[SerializeField]
	private Material m_FallbackSkyMaterial;

	[Header("Volumetric Clouds")]
	[Tooltip("[Optional] The material of volumetric clouds used when updating sky reflection.")]
	[SerializeField]
	private Material m_VolumetricCloudsMaterial;

	private const string k_PbrSkyShaderName = "Hidden/Skybox/PhysicallyBasedSky";

	private const string k_PbrSkyLutShaderName = "Hidden/Sky/PhysicallyBasedSkyPrecomputation";

	private const string k_CloudsShaderName = "Hidden/Sky/VolumetricClouds";

	private const string k_PbrSkyMaterialName = "Physically Based Sky";

	private const string k_DynamicAmbientProbeKeywordName = "VISUAL_ENVIRONMENT_DYNAMIC_SKY";

	private const string k_AtmosphericScatteringLowResolutionKeywordName = "ATMOSPHERIC_SCATTERING_LOW_RES";

	public Material PBRSkyMaterial => m_PbrSkyMaterial;

	public Material FallbackSkyMaterial
	{
		get
		{
			return m_FallbackSkyMaterial;
		}
		set
		{
			m_FallbackSkyMaterial = value;
		}
	}

	public Material CloudsMaterial
	{
		get
		{
			return m_VolumetricCloudsMaterial;
		}
		set
		{
			m_VolumetricCloudsMaterial = value;
			ValidateCloudsMaterial();
		}
	}

	public Shader PBSkyShader
	{
		get
		{
			return m_Shader;
		}
		set
		{
			m_Shader = value;
		}
	}

	public Shader PBSkyLutShader
	{
		get
		{
			return m_LutShader;
		}
		set
		{
			m_LutShader = value;
		}
	}

	public PrecomputationQualityMode PrecomputationQuality
	{
		get
		{
			return m_Precomputation;
		}
		set
		{
			m_Precomputation = value;
		}
	}

	public override void Create()
	{
		VolumeStack stack = VolumeManager.instance.stack;
		if (stack == null)
		{
			return;
		}
		stack.GetComponent<PhysicallyBasedSky>();
		VisualEnvironment component = stack.GetComponent<VisualEnvironment>();
		bool flag = true;
		if (m_Shader != Shader.Find("Hidden/Skybox/PhysicallyBasedSky"))
		{
			flag = false;
		}
		if (m_LutShader != Shader.Find("Hidden/Sky/PhysicallyBasedSkyPrecomputation"))
		{
			flag = false;
		}
		if (!flag)
		{
			return;
		}
		isShaderMismatchLogPrinted = false;
		if (!base.isActive)
		{
			RenderSettings.skybox = ((component != null && component.IsActive() && component.skyType.value == 5 && component.customSkyMaterial.value != null) ? component.customSkyMaterial.value : m_FallbackSkyMaterial);
			RenderSettings.customReflectionTexture = null;
			RenderSettings.defaultReflectionMode = DefaultReflectionMode.Skybox;
			Shader.DisableKeyword("VISUAL_ENVIRONMENT_DYNAMIC_SKY");
			return;
		}
		m_PbrSkyMaterial = CoreUtils.CreateEngineMaterial(m_Shader);
		m_PbrSkyLUTMaterial = CoreUtils.CreateEngineMaterial(m_LutShader);
		m_PbrSkyMaterial.name = "Physically Based Sky";
		if (m_PBSkyPrePass == null)
		{
			m_PBSkyPrePass = new PBSkyPrePass(m_PbrSkyMaterial, m_CelestialBodyData)
			{
				renderPassEvent = RenderPassEvent.BeforeRenderingPrePasses
			};
		}
		m_PBSkyPrePass.material = m_PbrSkyMaterial;
		m_PBSkyPrePass.lutMaterial = m_PbrSkyLUTMaterial;
		if (m_SkyViewLUTPass == null)
		{
			m_SkyViewLUTPass = new SkyViewLUTPass(m_PbrSkyLUTMaterial, ref m_CelestialBodyData)
			{
				renderPassEvent = RenderPassEvent.AfterRenderingPrePasses
			};
		}
		m_SkyViewLUTPass.lutMaterial = m_PbrSkyLUTMaterial;
		if (m_AtmosphericScatteringPass == null)
		{
			m_AtmosphericScatteringPass = new AtmosphericScatteringPass(m_PbrSkyLUTMaterial)
			{
				renderPassEvent = (RenderPassEvent)401
			};
		}
		m_AtmosphericScatteringPass.lutMaterial = m_PbrSkyLUTMaterial;
		if (m_AmbientProbePass == null)
		{
			m_AmbientProbePass = new AmbientProbePass(m_VolumetricCloudsMaterial)
			{
				renderPassEvent = RenderPassEvent.AfterRenderingPrePasses
			};
		}
		if (m_PBSkyPostPass == null)
		{
			m_PBSkyPostPass = new PBSkyPostPass
			{
				renderPassEvent = RenderPassEvent.AfterRendering
			};
		}
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (!((isShaderMismatchLogPrinted || m_PbrSkyMaterial == null || m_PbrSkyLUTMaterial == null) | (renderingData.cameraData.camera == null) | (renderingData.cameraData.camera.cameraType == CameraType.Preview)))
		{
			VolumeStack stack = VolumeManager.instance.stack;
			PhysicallyBasedSky component = stack.GetComponent<PhysicallyBasedSky>();
			VisualEnvironment component2 = stack.GetComponent<VisualEnvironment>();
			Fog component3 = stack.GetComponent<Fog>();
			bool flag = component != null && component2 != null && component2.IsActive() && component2.skyType.value == 4;
			bool flag2 = m_Precomputation == PrecomputationQualityMode.Low;
			m_PBSkyPrePass.pbrSky = component;
			m_SkyViewLUTPass.pbrSky = component;
			m_AtmosphericScatteringPass.pbrSky = component;
			m_PBSkyPrePass.visualEnvironment = component2;
			m_SkyViewLUTPass.visualEnvironment = component2;
			m_AtmosphericScatteringPass.visualEnvironment = component2;
			m_PBSkyPrePass.fog = component3;
			m_AtmosphericScatteringPass.fog = component3;
			m_SkyViewLUTPass.halfResolutionLuts = flag2;
			if (flag)
			{
				CoreUtils.SetKeyword(m_PbrSkyMaterial, "ATMOSPHERIC_SCATTERING_LOW_RES", flag2);
			}
			CoreUtils.SetKeyword(m_PbrSkyLUTMaterial, "ATMOSPHERIC_SCATTERING_LOW_RES", flag2);
			bool num = (flag && component.atmosphericScattering.value) || (component3 != null && component3.IsActive());
			if (flag)
			{
				renderer.EnqueuePass(m_PBSkyPrePass);
				m_SkyViewLUTPass.celestialBodyData = m_PBSkyPrePass.celestialBodyData;
				renderer.EnqueuePass(m_SkyViewLUTPass);
			}
			if (num && renderingData.cameraData.camera.cameraType != CameraType.Reflection)
			{
				renderer.EnqueuePass(m_AtmosphericScatteringPass);
			}
			renderer.EnqueuePass(m_PBSkyPostPass);
			if (component2.skyAmbientMode.value == VisualEnvironment.SkyAmbientMode.Dynamic && renderingData.cameraData.camera.cameraType != CameraType.Reflection && RenderSettings.skybox != null)
			{
				m_AmbientProbePass.visualEnvironment = component2;
				m_AmbientProbePass.cloudsMaterial = ValidateCloudsMaterial();
				m_AmbientProbePass.isPbrSky = flag;
				Shader.EnableKeyword("VISUAL_ENVIRONMENT_DYNAMIC_SKY");
				renderer.EnqueuePass(m_AmbientProbePass);
			}
			else
			{
				Shader.DisableKeyword("VISUAL_ENVIRONMENT_DYNAMIC_SKY");
			}
			UpdateSkySettings(flag, component2);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (m_PBSkyPrePass != null)
		{
			m_PBSkyPrePass.Dispose();
		}
		if (m_SkyViewLUTPass != null)
		{
			m_SkyViewLUTPass.Dispose();
		}
		if (m_AtmosphericScatteringPass != null)
		{
			m_AtmosphericScatteringPass.Dispose();
		}
		if (m_AmbientProbePass != null)
		{
			m_AmbientProbePass.Dispose();
		}
		if (m_PBSkyPostPass != null)
		{
			m_PBSkyPostPass.Dispose();
		}
		if (m_PbrSkyMaterial != null)
		{
			CoreUtils.Destroy(m_PbrSkyMaterial);
		}
		if (m_PbrSkyLUTMaterial != null)
		{
			CoreUtils.Destroy(m_PbrSkyLUTMaterial);
		}
	}

	private Material ValidateCloudsMaterial()
	{
		if (!(m_VolumetricCloudsMaterial != null) || !(m_VolumetricCloudsMaterial.shader == Shader.Find("Hidden/Sky/VolumetricClouds")))
		{
			return null;
		}
		return m_VolumetricCloudsMaterial;
	}

	private void UpdateSkySettings(bool isPbrSky, VisualEnvironment visualEnvVolume)
	{
		bool flag = visualEnvVolume.skyType.value == 5;
		bool flag2 = visualEnvVolume.customSkyMaterial.value != null;
		bool num = visualEnvVolume.skyAmbientMode.value == VisualEnvironment.SkyAmbientMode.Dynamic;
		bool flag3 = lastSkyType != visualEnvVolume.skyType.value;
		bool flag4 = lastSkyAmbientMode != visualEnvVolume.skyAmbientMode.value;
		if (!num && flag4)
		{
			RenderSettings.customReflectionTexture = null;
			RenderSettings.defaultReflectionMode = DefaultReflectionMode.Skybox;
		}
		RenderSettings.skybox = (isPbrSky ? m_PbrSkyMaterial : ((flag && flag2) ? visualEnvVolume.customSkyMaterial.value : (flag3 ? m_FallbackSkyMaterial : RenderSettings.skybox)));
		lastSkyType = visualEnvVolume.skyType.value;
		lastSkyAmbientMode = visualEnvVolume.skyAmbientMode.value;
	}
}
