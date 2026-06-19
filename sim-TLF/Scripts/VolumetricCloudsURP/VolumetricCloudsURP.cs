using System;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

[DisallowMultipleRendererFeature("Volumetric Clouds URP")]
[Tooltip("Add this Renderer Feature to support volumetric clouds in URP Volume.")]
[HelpURL("https://github.com/jiaozi158/UnityVolumetricCloudsURP/tree/main")]
public class VolumetricCloudsURP : ScriptableRendererFeature
{
	public enum CloudsRenderMode
	{
		[Tooltip("Always use Blit() to copy render textures.")]
		BlitTexture = 0,
		[Tooltip("Use CopyTexture() to copy render textures when supported.")]
		CopyTexture = 1
	}

	public enum CloudsAmbientMode
	{
		[Tooltip("Use URP default static ambient probe for volumetric clouds rendering.")]
		Static = 0,
		[Tooltip("Use a fast dynamic ambient probe for volumetric clouds rendering.")]
		Dynamic = 1
	}

	public enum CloudsUpscaleMode
	{
		[Tooltip("Use simple but fast filtering for volumetric clouds upscale.")]
		Bilinear = 0,
		[Tooltip("Use more computationally expensive filtering for volumetric clouds upscale. \nThis blurs the cloud details but reduces the noise that may appear at lower clouds resolutions.")]
		Bilateral = 1
	}

	public class VolumetricCloudsPass : ScriptableRenderPass
	{
		private class PassData
		{
			internal Material cloudsMaterial;

			internal Camera camera;

			internal CloudsUpscaleMode upscaleMode;

			internal float resolutionScale;

			internal bool canCopy;

			internal bool denoiseClouds;

			internal bool dynamicAmbientProbe;

			internal bool outputDepth;

			internal bool outputToSceneDepth;

			internal bool hasAtmosphericScattering;

			internal TextureHandle cameraColorHandle;

			internal TextureHandle activeDepthHandle;

			internal TextureHandle cameraDepthHandle;

			internal TextureHandle cloudsColorHandle;

			internal TextureHandle cloudsDepthHandle;

			internal TextureHandle accumulateHandle;

			internal TextureHandle historyHandle;

			internal TextureHandle cameraTempDepthHandle;
		}

		private class RasterPassData
		{
			internal Material cloudsMaterial;

			internal TextureHandle cameraColorHandle;

			internal TextureHandle cameraDepthHandle;
		}

		private const string rasterPassProfilerTag = "Trace Volumetric Clouds";

		private const string profilerTag = "Volumetric Clouds";

		private readonly ProfilingSampler m_ProfilingSampler = new ProfilingSampler("Volumetric Clouds");

		public VolumetricClouds cloudsVolume;

		public ColorAdjustments colorAdjustments;

		public CloudsRenderMode renderMode;

		public float resolutionScale;

		public CloudsUpscaleMode upscaleMode;

		public bool dynamicAmbientProbe;

		public bool resetWindOnStart;

		public bool outputDepth;

		public bool outputToSceneDepth;

		public bool sunAttenuation;

		public bool hasAtmosphericScattering;

		private bool denoiseClouds;

		private RTHandle cloudsColorHandle;

		private RTHandle cloudsDepthHandle;

		private RTHandle accumulateHandle;

		private RTHandle historyHandle;

		private RTHandle cameraTempDepthHandle;

		private readonly Material cloudsMaterial;

		private readonly bool fastCopy = (SystemInfo.copyTextureSupport & CopyTextureSupport.Basic) != 0;

		private static readonly int numPrimarySteps = Shader.PropertyToID("_NumPrimarySteps");

		private static readonly int numLightSteps = Shader.PropertyToID("_NumLightSteps");

		private static readonly int maxStepSize = Shader.PropertyToID("_MaxStepSize");

		private static readonly int highestCloudAltitude = Shader.PropertyToID("_HighestCloudAltitude");

		private static readonly int lowestCloudAltitude = Shader.PropertyToID("_LowestCloudAltitude");

		private static readonly int shapeNoiseOffset = Shader.PropertyToID("_ShapeNoiseOffset");

		private static readonly int verticalShapeNoiseOffset = Shader.PropertyToID("_VerticalShapeNoiseOffset");

		private static readonly int globalOrientation = Shader.PropertyToID("_WindDirection");

		private static readonly int globalSpeed = Shader.PropertyToID("_WindVector");

		private static readonly int verticalShapeDisplacement = Shader.PropertyToID("_VerticalShapeWindDisplacement");

		private static readonly int verticalErosionDisplacement = Shader.PropertyToID("_VerticalErosionWindDisplacement");

		private static readonly int shapeSpeedMultiplier = Shader.PropertyToID("_MediumWindSpeed");

		private static readonly int erosionSpeedMultiplier = Shader.PropertyToID("_SmallWindSpeed");

		private static readonly int altitudeDistortion = Shader.PropertyToID("_AltitudeDistortion");

		private static readonly int densityMultiplier = Shader.PropertyToID("_DensityMultiplier");

		private static readonly int powderEffectIntensity = Shader.PropertyToID("_PowderEffectIntensity");

		private static readonly int shapeScale = Shader.PropertyToID("_ShapeScale");

		private static readonly int shapeFactor = Shader.PropertyToID("_ShapeFactor");

		private static readonly int erosionScale = Shader.PropertyToID("_ErosionScale");

		private static readonly int erosionFactor = Shader.PropertyToID("_ErosionFactor");

		private static readonly int erosionOcclusion = Shader.PropertyToID("_ErosionOcclusion");

		private static readonly int microErosionScale = Shader.PropertyToID("_MicroErosionScale");

		private static readonly int microErosionFactor = Shader.PropertyToID("_MicroErosionFactor");

		private static readonly int fadeInStart = Shader.PropertyToID("_FadeInStart");

		private static readonly int fadeInDistance = Shader.PropertyToID("_FadeInDistance");

		private static readonly int multiScattering = Shader.PropertyToID("_MultiScattering");

		private static readonly int scatteringTint = Shader.PropertyToID("_ScatteringTint");

		private static readonly int ambientProbeDimmer = Shader.PropertyToID("_AmbientProbeDimmer");

		private static readonly int sunLightDimmer = Shader.PropertyToID("_SunLightDimmer");

		private static readonly int earthRadius = Shader.PropertyToID("_EarthRadius");

		private static readonly int accumulationFactor = Shader.PropertyToID("_AccumulationFactor");

		private static readonly int improvedTransmittanceBlend = Shader.PropertyToID("_ImprovedTransmittanceBlend");

		private static readonly int cloudsCurveLut = Shader.PropertyToID("_CloudCurveTexture");

		private static readonly int cloudnearPlane = Shader.PropertyToID("_CloudNearPlane");

		private static readonly int sunColor = Shader.PropertyToID("_SunColor");

		private static readonly int planetCenterRadius = Shader.PropertyToID("_PlanetCenterRadius");

		private static readonly int postExposure = Shader.PropertyToID("_PostExposure");

		private static readonly int cameraDepthTexture = Shader.PropertyToID("_CameraDepthTexture");

		private static readonly int volumetricCloudsColorTexture = Shader.PropertyToID("_VolumetricCloudsColorTexture");

		private static readonly int volumetricCloudsHistoryTexture = Shader.PropertyToID("_VolumetricCloudsHistoryTexture");

		private static readonly int volumetricCloudsDepthTexture = Shader.PropertyToID("_VolumetricCloudsDepthTexture");

		private static readonly int volumetricCloudsLightingTexture = Shader.PropertyToID("_VolumetricCloudsLightingTexture");

		private static readonly int shAr = Shader.PropertyToID("clouds_SHAr");

		private static readonly int shAg = Shader.PropertyToID("clouds_SHAg");

		private static readonly int shAb = Shader.PropertyToID("clouds_SHAb");

		private static readonly int shBr = Shader.PropertyToID("clouds_SHBr");

		private static readonly int shBg = Shader.PropertyToID("clouds_SHBg");

		private static readonly int shBb = Shader.PropertyToID("clouds_SHBb");

		private static readonly int shC = Shader.PropertyToID("clouds_SHC");

		private const string localClouds = "_LOCAL_VOLUMETRIC_CLOUDS";

		private const string microErosion = "_CLOUDS_MICRO_EROSION";

		private const string lowResClouds = "_LOW_RESOLUTION_CLOUDS";

		private const string cloudsAmbientProbe = "_CLOUDS_AMBIENT_PROBE";

		private const string outputCloudsDepth = "_OUTPUT_CLOUDS_DEPTH";

		private const string physicallyBasedSun = "_PHYSICALLY_BASED_SUN";

		private const string perceptualBlending = "_PERCEPTUAL_BLENDING";

		private const string _CameraDepthTexture = "_CameraDepthTexture";

		private const string _VolumetricCloudsColorTexture = "_VolumetricCloudsColorTexture";

		private const string _VolumetricCloudsHistoryTexture = "_VolumetricCloudsHistoryTexture";

		private const string _VolumetricCloudsAccumulationTexture = "_VolumetricCloudsAccumulationTexture";

		private const string _VolumetricCloudsDepthTexture = "_VolumetricCloudsDepthTexture";

		private const string _VolumetricCloudsLightingTexture = "_VolumetricCloudsLightingTexture";

		private const string _CameraTempDepthTexture = "_CameraTempDepthTexture";

		private static readonly Vector4 m_ScaleBias = new Vector4(1f, 1f, 0f, 0f);

		private static readonly FieldInfo depthTextureFieldInfo = typeof(UniversalRenderer).GetField("m_DepthTexture", BindingFlags.Instance | BindingFlags.NonPublic);

		private Texture2D customLutPresetMap;

		private readonly Color[] customLutColorArray = new Color[64];

		public const float earthRad = 6378100f;

		public const float windNormalizationFactor = 100000f;

		public const int customLutMapResolution = 64;

		private bool prevIsPlaying;

		private float prevTotalTime = -1f;

		private float verticalShapeOffset;

		private float verticalErosionOffset;

		private Vector2 windVector = Vector2.zero;

		[Obsolete]
		private readonly RTHandle[] cloudsRTHandles = new RTHandle[2];

		private static float square(float x)
		{
			return x * x;
		}

		private void UpdateMaterialProperties(Camera camera)
		{
			if (cloudsVolume.localClouds.value)
			{
				cloudsMaterial.EnableKeyword("_LOCAL_VOLUMETRIC_CLOUDS");
			}
			else
			{
				cloudsMaterial.DisableKeyword("_LOCAL_VOLUMETRIC_CLOUDS");
			}
			if (cloudsVolume.microErosion.value && cloudsVolume.microErosionFactor.value > 0f)
			{
				cloudsMaterial.EnableKeyword("_CLOUDS_MICRO_EROSION");
			}
			else
			{
				cloudsMaterial.DisableKeyword("_CLOUDS_MICRO_EROSION");
			}
			if (resolutionScale < 1f && upscaleMode == CloudsUpscaleMode.Bilateral)
			{
				cloudsMaterial.EnableKeyword("_LOW_RESOLUTION_CLOUDS");
			}
			else
			{
				cloudsMaterial.DisableKeyword("_LOW_RESOLUTION_CLOUDS");
			}
			if (dynamicAmbientProbe)
			{
				cloudsMaterial.EnableKeyword("_CLOUDS_AMBIENT_PROBE");
			}
			else
			{
				cloudsMaterial.DisableKeyword("_CLOUDS_AMBIENT_PROBE");
			}
			if (outputDepth)
			{
				cloudsMaterial.EnableKeyword("_OUTPUT_CLOUDS_DEPTH");
			}
			else
			{
				cloudsMaterial.DisableKeyword("_OUTPUT_CLOUDS_DEPTH");
			}
			if (sunAttenuation)
			{
				cloudsMaterial.EnableKeyword("_PHYSICALLY_BASED_SUN");
			}
			else
			{
				cloudsMaterial.DisableKeyword("_PHYSICALLY_BASED_SUN");
			}
			if (cloudsVolume.perceptualBlending.value > 0f)
			{
				cloudsMaterial.EnableKeyword("_PERCEPTUAL_BLENDING");
			}
			else
			{
				cloudsMaterial.DisableKeyword("_PERCEPTUAL_BLENDING");
			}
			cloudsMaterial.SetFloat(numPrimarySteps, cloudsVolume.numPrimarySteps.value);
			cloudsMaterial.SetFloat(numLightSteps, cloudsVolume.numLightSteps.value);
			cloudsMaterial.SetFloat(maxStepSize, cloudsVolume.altitudeRange.value / 8f);
			float num = Mathf.Lerp(1f, 0.025f, cloudsVolume.earthCurvature.value) * 6378100f;
			cloudsMaterial.SetVector(planetCenterRadius, math.float4(0f, 0f - num, 0f, num));
			float num2 = cloudsVolume.bottomAltitude.value + num;
			float num3 = num2 + cloudsVolume.altitudeRange.value;
			cloudsMaterial.SetFloat(highestCloudAltitude, num3);
			cloudsMaterial.SetFloat(lowestCloudAltitude, num2);
			cloudsMaterial.SetVector(shapeNoiseOffset, new Vector4(cloudsVolume.shapeOffset.value.x, cloudsVolume.shapeOffset.value.z, 0f, 0f));
			cloudsMaterial.SetFloat(verticalShapeNoiseOffset, cloudsVolume.shapeOffset.value.y);
			float num4 = (Application.isPlaying ? Time.time : Time.realtimeSinceStartup);
			float num5 = num4 - prevTotalTime;
			if (prevTotalTime == -1f)
			{
				num5 = 0f;
			}
			num5 *= -0.277778f;
			float f = cloudsVolume.globalOrientation.value / 180f * MathF.PI;
			Vector2 vector = new Vector2(Mathf.Cos(f), Mathf.Sin(f));
			if (resetWindOnStart && prevIsPlaying != Application.isPlaying)
			{
				windVector = Vector2.zero;
				verticalShapeOffset = 0f;
				verticalErosionOffset = 0f;
			}
			else
			{
				windVector += num5 * cloudsVolume.globalSpeed.value * vector;
				verticalShapeOffset += num5 * cloudsVolume.verticalShapeWindSpeed.value;
				verticalErosionOffset += num5 * cloudsVolume.erosionSpeedMultiplier.value;
				windVector.x %= 100000f;
				windVector.y %= 100000f;
				verticalShapeOffset %= 100000f;
				verticalErosionOffset %= 100000f;
			}
			prevTotalTime = num4;
			prevIsPlaying = Application.isPlaying;
			cloudsMaterial.SetVector(globalOrientation, new Vector4(0f - vector.x, 0f - vector.y, 0f, 0f));
			cloudsMaterial.SetVector(globalSpeed, windVector);
			cloudsMaterial.SetFloat(shapeSpeedMultiplier, cloudsVolume.shapeSpeedMultiplier.value);
			cloudsMaterial.SetFloat(erosionSpeedMultiplier, cloudsVolume.erosionSpeedMultiplier.value);
			cloudsMaterial.SetFloat(altitudeDistortion, cloudsVolume.altitudeDistortion.value * 0.25f);
			cloudsMaterial.SetFloat(verticalShapeDisplacement, verticalShapeOffset);
			cloudsMaterial.SetFloat(verticalErosionDisplacement, verticalErosionOffset);
			cloudsMaterial.SetFloat(densityMultiplier, cloudsVolume.densityMultiplier.value * cloudsVolume.densityMultiplier.value * 2f);
			cloudsMaterial.SetFloat(powderEffectIntensity, cloudsVolume.powderEffectIntensity.value);
			cloudsMaterial.SetFloat(shapeScale, cloudsVolume.shapeScale.value);
			cloudsMaterial.SetFloat(shapeFactor, cloudsVolume.shapeFactor.value);
			cloudsMaterial.SetFloat(erosionScale, cloudsVolume.erosionScale.value);
			cloudsMaterial.SetFloat(erosionFactor, cloudsVolume.erosionFactor.value);
			cloudsMaterial.SetFloat(erosionOcclusion, cloudsVolume.erosionOcclusion.value);
			cloudsMaterial.SetFloat(microErosionScale, cloudsVolume.microErosionScale.value);
			cloudsMaterial.SetFloat(microErosionFactor, cloudsVolume.microErosionFactor.value);
			bool flag = cloudsVolume.fadeInMode.value == VolumetricClouds.CloudFadeInMode.Automatic;
			cloudsMaterial.SetFloat(fadeInStart, flag ? Mathf.Max(cloudsVolume.altitudeRange.value * 0.2f, camera.nearClipPlane) : Mathf.Max(cloudsVolume.fadeInStart.value, camera.nearClipPlane));
			cloudsMaterial.SetFloat(fadeInDistance, flag ? (cloudsVolume.altitudeRange.value * 0.3f) : cloudsVolume.fadeInDistance.value);
			cloudsMaterial.SetFloat(multiScattering, 1f - cloudsVolume.multiScattering.value * 0.95f);
			cloudsMaterial.SetColor(scatteringTint, Color.white - cloudsVolume.scatteringTint.value * 0.75f);
			cloudsMaterial.SetFloat(ambientProbeDimmer, cloudsVolume.ambientLightProbeDimmer.value);
			cloudsMaterial.SetFloat(sunLightDimmer, cloudsVolume.sunLightDimmer.value);
			cloudsMaterial.SetFloat(earthRadius, num);
			cloudsMaterial.SetFloat(accumulationFactor, cloudsVolume.temporalAccumulationFactor.value);
			cloudsMaterial.SetFloat(improvedTransmittanceBlend, cloudsVolume.perceptualBlending.value);
			Vector3 originPS = camera.transform.position - new Vector3(0f, 0f - num, 0f);
			cloudsMaterial.SetFloat(cloudnearPlane, math.max(GetCloudNearPlane(originPS, num2, num3), camera.nearClipPlane));
			float value = ((colorAdjustments != null && colorAdjustments.active) ? Mathf.Pow(2f, colorAdjustments.postExposure.value) : 1f);
			cloudsMaterial.SetFloat(postExposure, value);
			SetupAmbientProbeIfNeeded(cloudsMaterial);
			PrepareCustomLutData(cloudsVolume);
		}

		private void UpdateClouds(Light mainLight, Camera camera)
		{
			if (sunAttenuation)
			{
				bool flag = QualitySettings.activeColorSpace == ColorSpace.Linear;
				Color color = Color.black;
				if (mainLight != null)
				{
					color = (flag ? mainLight.color.linear : mainLight.color.gamma) * (mainLight.useColorTemperature ? Mathf.CorrelatedColorTemperatureToRGB(mainLight.colorTemperature) : Color.white) * mainLight.intensity * MathF.PI;
				}
				cloudsMaterial.SetVector(sunColor, color);
			}
			VolumetricClouds.CloudPresets cloudPreset = cloudsVolume.cloudPreset;
			cloudsVolume.cloudPreset = cloudPreset;
			UpdateMaterialProperties(camera);
			denoiseClouds = cloudsVolume.temporalAccumulationFactor.value >= 0.01f;
		}

		private void PrepareCustomLutData(VolumetricClouds clouds)
		{
			if (customLutPresetMap == null)
			{
				customLutPresetMap = new Texture2D(1, 64, GraphicsFormat.R16G16B16A16_SFloat, TextureCreationFlags.None)
				{
					name = "Custom LUT Curve",
					filterMode = FilterMode.Bilinear,
					wrapMode = TextureWrapMode.Clamp
				};
				customLutPresetMap.hideFlags = HideFlags.HideAndDontSave;
			}
			Color[] array = customLutColorArray;
			AnimationCurve value = clouds.densityCurve.value;
			AnimationCurve value2 = clouds.erosionCurve.value;
			AnimationCurve value3 = clouds.ambientOcclusionCurve.value;
			Color white = Color.white;
			if (value == null || value.length == 0)
			{
				for (int i = 0; i < 64; i++)
				{
					array[i] = white;
				}
			}
			else
			{
				float num = 1f / 63f;
				for (int j = 0; j < 64; j++)
				{
					float time = num * (float)j;
					float r = ((j == 0 || j == 63) ? 0f : Mathf.Clamp(value.Evaluate(time), 0f, 1f));
					float g = Mathf.Clamp(value2.Evaluate(time), 0f, 1f);
					float b = Mathf.Clamp(1f - value3.Evaluate(time), 0f, 1f);
					array[j] = new Color(r, g, b, 1f);
				}
			}
			customLutPresetMap.SetPixels(array);
			customLutPresetMap.Apply();
			cloudsMaterial.SetTexture(cloudsCurveLut, customLutPresetMap);
		}

		private void SetupAmbientProbeIfNeeded(Material cloudsMaterial)
		{
			if (!dynamicAmbientProbe)
			{
				SphericalHarmonicsL2 ambientProbe = RenderSettings.ambientProbe;
				cloudsMaterial.SetVector(shAr, new Vector4(ambientProbe[0, 3], ambientProbe[0, 1], ambientProbe[0, 2], ambientProbe[0, 0] - ambientProbe[0, 6]));
				cloudsMaterial.SetVector(shAg, new Vector4(ambientProbe[1, 3], ambientProbe[1, 1], ambientProbe[1, 2], ambientProbe[1, 0] - ambientProbe[1, 6]));
				cloudsMaterial.SetVector(shAb, new Vector4(ambientProbe[2, 3], ambientProbe[2, 1], ambientProbe[2, 2], ambientProbe[2, 0] - ambientProbe[2, 6]));
				cloudsMaterial.SetVector(shBr, new Vector4(ambientProbe[0, 4], ambientProbe[0, 5], ambientProbe[0, 6] * 3f, ambientProbe[0, 7]));
				cloudsMaterial.SetVector(shBg, new Vector4(ambientProbe[1, 4], ambientProbe[1, 5], ambientProbe[1, 6] * 3f, ambientProbe[1, 7]));
				cloudsMaterial.SetVector(shBb, new Vector4(ambientProbe[2, 4], ambientProbe[2, 5], ambientProbe[2, 6] * 3f, ambientProbe[2, 7]));
				cloudsMaterial.SetVector(shC, new Vector4(ambientProbe[0, 8], ambientProbe[1, 8], ambientProbe[2, 8], 1f));
			}
		}

		private static Vector2 IntersectSphere(float sphereRadius, float cosChi, float radialDistance, float rcpRadialDistance)
		{
			float num = square(sphereRadius * rcpRadialDistance) - math.saturate(1f - cosChi * cosChi);
			if (!(num < 0f))
			{
				return radialDistance * new Vector2(0f - cosChi - math.sqrt(num), 0f - cosChi + math.sqrt(num));
			}
			return new Vector2(-1f, -1f);
		}

		private static float GetCloudNearPlane(Vector3 originPS, float lowerBoundPS, float higherBoundPS)
		{
			float num = math.length(originPS);
			float rcpRadialDistance = math.rcp(num);
			float num2 = 1f;
			Vector2 vector = IntersectSphere(lowerBoundPS, num2, num, rcpRadialDistance);
			Vector2 vector2 = IntersectSphere(higherBoundPS, 0f - num2, num, rcpRadialDistance);
			if (vector.x < 0f && vector.y >= 0f)
			{
				return vector.y;
			}
			return math.max(vector2.x, 0f);
		}

		public VolumetricCloudsPass(Material material, float resolution)
		{
			cloudsMaterial = material;
			resolutionScale = resolution;
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

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.msaaSamples = 1;
			descriptor.useMipMap = false;
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateHandleIfNeeded(ref historyHandle, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsHistoryTexture");
			descriptor.colorFormat = RenderTextureFormat.ARGBHalf;
			RenderingUtils.ReAllocateHandleIfNeeded(ref accumulateHandle, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsAccumulationTexture");
			descriptor.width = (int)((float)descriptor.width * resolutionScale);
			descriptor.height = (int)((float)descriptor.height * resolutionScale);
			RenderingUtils.ReAllocateHandleIfNeeded(ref cloudsColorHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsLightingTexture");
			cloudsMaterial.SetTexture(volumetricCloudsLightingTexture, cloudsColorHandle);
			descriptor.colorFormat = RenderTextureFormat.RFloat;
			RenderingUtils.ReAllocateHandleIfNeeded(ref cloudsDepthHandle, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsDepthTexture");
			RenderingUtils.ReAllocateHandleIfNeeded(ref cameraTempDepthHandle, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_CameraTempDepthTexture");
			cmd.SetGlobalTexture(volumetricCloudsColorTexture, cloudsColorHandle);
			cmd.SetGlobalTexture(volumetricCloudsLightingTexture, cloudsColorHandle);
			cmd.SetGlobalTexture(volumetricCloudsDepthTexture, cloudsDepthHandle);
			cloudsMaterial.SetTexture(volumetricCloudsHistoryTexture, historyHandle);
			cloudsMaterial.SetTexture(volumetricCloudsDepthTexture, cloudsDepthHandle);
			ConfigureInput(ScriptableRenderPassInput.Depth);
			if (outputDepth)
			{
				cloudsRTHandles[0] = cloudsColorHandle;
				cloudsRTHandles[1] = cloudsDepthHandle;
				ConfigureTarget(cloudsRTHandles, cloudsColorHandle);
			}
			else
			{
				ConfigureTarget(cloudsColorHandle, cloudsColorHandle);
			}
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			LightData lightData = renderingData.lightData;
			Light mainLight = GetMainLight(lightData);
			UpdateClouds(mainLight, renderingData.cameraData.camera);
			cloudsMaterial.SetTexture(cameraDepthTexture, null);
			RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, m_ProfilingSampler))
			{
				Blitter.BlitTexture(commandBuffer, cameraColorTargetHandle, m_ScaleBias, cloudsMaterial, 0);
				Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, cameraColorTargetHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, cloudsMaterial, (!hasAtmosphericScattering) ? 1 : 7);
				if (outputToSceneDepth)
				{
					UniversalRenderer obj = renderingData.cameraData.renderer as UniversalRenderer;
					RTHandle rTHandle = depthTextureFieldInfo.GetValue(obj) as RTHandle;
					Blitter.BlitCameraTexture(commandBuffer, rTHandle, cameraTempDepthHandle);
					commandBuffer.SetRenderTarget(rTHandle, rTHandle);
					Blitter.BlitTexture(commandBuffer, cameraTempDepthHandle, m_ScaleBias, cloudsMaterial, 6);
				}
				if (denoiseClouds)
				{
					Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, accumulateHandle, cloudsMaterial, 2);
					Blitter.BlitCameraTexture(commandBuffer, accumulateHandle, cameraColorTargetHandle, cloudsMaterial, 3);
					if (cameraColorTargetHandle.rt.format == historyHandle.rt.format && cameraColorTargetHandle.rt.antiAliasing == 1 && fastCopy && renderMode == CloudsRenderMode.CopyTexture)
					{
						commandBuffer.CopyTexture(cameraColorTargetHandle, historyHandle);
					}
					else
					{
						Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, historyHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, cloudsMaterial, 2);
					}
				}
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
			Blitter.BlitCameraTexture(nativeCommandBuffer, data.cloudsColorHandle, data.cameraColorHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, data.cloudsMaterial, (!data.hasAtmosphericScattering) ? 1 : 7);
			if (data.outputToSceneDepth)
			{
				Blitter.BlitCameraTexture(nativeCommandBuffer, data.cameraDepthHandle, data.cameraTempDepthHandle);
				context.cmd.SetRenderTarget(data.cameraDepthHandle, data.cameraDepthHandle);
				Blitter.BlitTexture(nativeCommandBuffer, data.cameraTempDepthHandle, m_ScaleBias, data.cloudsMaterial, 6);
			}
			if (data.denoiseClouds)
			{
				Blitter.BlitCameraTexture(nativeCommandBuffer, data.cameraColorHandle, data.accumulateHandle, data.cloudsMaterial, 2);
				Blitter.BlitCameraTexture(nativeCommandBuffer, data.accumulateHandle, data.cameraColorHandle, data.cloudsMaterial, 3);
				if (data.canCopy)
				{
					nativeCommandBuffer.CopyTexture(data.cameraColorHandle, data.historyHandle);
				}
				else
				{
					Blitter.BlitCameraTexture(nativeCommandBuffer, data.cameraColorHandle, data.historyHandle, RenderBufferLoadAction.Load, RenderBufferStoreAction.Store, data.cloudsMaterial, 2);
				}
				data.cloudsMaterial.SetTexture(volumetricCloudsHistoryTexture, data.historyHandle);
			}
			context.cmd.SetRenderTarget(data.cameraColorHandle, data.activeDepthHandle);
		}

		private static void ExecuteRasterPass(RasterPassData data, RasterGraphContext rgContext)
		{
			RasterCommandBuffer cmd = rgContext.cmd;
			data.cloudsMaterial.SetTexture(cameraDepthTexture, data.cameraDepthHandle);
			Blitter.BlitTexture(cmd, data.cameraColorHandle, m_ScaleBias, data.cloudsMaterial, 0);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			UniversalLightData lightData = frameData.Get<UniversalLightData>();
			RasterPassData passData;
			using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<RasterPassData>("Trace Volumetric Clouds", out passData, "E:\\NewUnityProjects\\Escobar_Win\\Assets\\VolumetricClouds\\VolumetricCloudsURP.cs", 1040))
			{
				Light mainLight = GetMainLight(lightData);
				UpdateClouds(mainLight, universalCameraData.camera);
				passData.cameraColorHandle = universalResourceData.activeColorTexture;
				passData.cameraDepthHandle = universalResourceData.cameraDepthTexture;
				RenderTextureFormat colorFormat = RenderTextureFormat.ARGBHalf;
				RenderTextureFormat colorFormat2 = RenderTextureFormat.RFloat;
				RenderTextureDescriptor descriptor = universalCameraData.cameraTargetDescriptor;
				descriptor.msaaSamples = 1;
				descriptor.useMipMap = false;
				descriptor.depthBufferBits = 0;
				descriptor.colorFormat = colorFormat;
				descriptor.width = (int)((float)descriptor.width * resolutionScale);
				descriptor.height = (int)((float)descriptor.height * resolutionScale);
				RenderingUtils.ReAllocateHandleIfNeeded(ref cloudsColorHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsLightingTexture");
				cloudsMaterial.SetTexture(volumetricCloudsLightingTexture, cloudsColorHandle);
				TextureHandle tex = renderGraph.ImportTexture(cloudsColorHandle);
				if (outputDepth)
				{
					descriptor.colorFormat = colorFormat2;
					RenderingUtils.ReAllocateHandleIfNeeded(ref cloudsDepthHandle, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsDepthTexture");
					cloudsMaterial.SetTexture(volumetricCloudsDepthTexture, cloudsDepthHandle);
					TextureHandle tex2 = renderGraph.ImportTexture(cloudsDepthHandle);
					rasterRenderGraphBuilder.SetRenderAttachment(tex2, 1);
				}
				passData.cloudsMaterial = cloudsMaterial;
				ConfigureInput(ScriptableRenderPassInput.Depth);
				rasterRenderGraphBuilder.UseTexture(in passData.cameraColorHandle, AccessFlags.ReadWrite);
				rasterRenderGraphBuilder.UseTexture(in passData.cameraDepthHandle);
				rasterRenderGraphBuilder.SetRenderAttachment(tex, 0);
				rasterRenderGraphBuilder.SetRenderFunc(delegate(RasterPassData rasterPassData, RasterGraphContext rgContext)
				{
					ExecuteRasterPass(rasterPassData, rgContext);
				});
			}
			PassData passData2;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Volumetric Clouds", out passData2, "E:\\NewUnityProjects\\Escobar_Win\\Assets\\VolumetricClouds\\VolumetricCloudsURP.cs", 1095);
			passData2.cameraColorHandle = universalResourceData.activeColorTexture;
			passData2.activeDepthHandle = universalResourceData.activeDepthTexture;
			passData2.cameraDepthHandle = universalResourceData.cameraDepthTexture;
			RenderTextureFormat renderTextureFormat = RenderTextureFormat.ARGBHalf;
			RenderTextureFormat colorFormat3 = RenderTextureFormat.RFloat;
			RenderTextureDescriptor cameraTargetDescriptor = universalCameraData.cameraTargetDescriptor;
			cameraTargetDescriptor.msaaSamples = 1;
			cameraTargetDescriptor.useMipMap = false;
			cameraTargetDescriptor.depthBufferBits = 0;
			cameraTargetDescriptor.colorFormat = renderTextureFormat;
			TextureHandle textureHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_VolumetricCloudsAccumulationTexture", clear: false);
			TextureHandle textureHandle2 = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_VolumetricCloudsHistoryTexture", clear: false);
			RenderTextureDescriptor desc = cameraTargetDescriptor;
			TextureHandle textureHandle3 = renderGraph.ImportTexture(cloudsColorHandle);
			unsafeRenderGraphBuilder.SetGlobalTextureAfterPass(in textureHandle3, volumetricCloudsColorTexture);
			unsafeRenderGraphBuilder.SetGlobalTextureAfterPass(in textureHandle3, volumetricCloudsLightingTexture);
			if (outputDepth)
			{
				TextureHandle textureHandle4 = (passData2.cloudsDepthHandle = renderGraph.ImportTexture(cloudsDepthHandle));
				unsafeRenderGraphBuilder.UseTexture(in passData2.cloudsDepthHandle, AccessFlags.Write);
				unsafeRenderGraphBuilder.SetGlobalTextureAfterPass(in textureHandle4, volumetricCloudsDepthTexture);
			}
			if (outputToSceneDepth)
			{
				desc.colorFormat = colorFormat3;
				TextureHandle textureHandle5 = UniversalRenderer.CreateRenderGraphTexture(renderGraph, desc, "_CameraTempDepthTexture", clear: false);
				passData2.cameraTempDepthHandle = textureHandle5;
				unsafeRenderGraphBuilder.UseTexture(in passData2.cameraTempDepthHandle, AccessFlags.Write);
			}
			passData2.cloudsMaterial = cloudsMaterial;
			passData2.camera = universalCameraData.camera;
			passData2.upscaleMode = upscaleMode;
			passData2.resolutionScale = resolutionScale;
			passData2.canCopy = universalCameraData.cameraTargetDescriptor.colorFormat == renderTextureFormat && universalCameraData.cameraTargetDescriptor.msaaSamples == 1 && fastCopy;
			passData2.denoiseClouds = denoiseClouds;
			passData2.dynamicAmbientProbe = dynamicAmbientProbe;
			passData2.outputDepth = outputDepth;
			passData2.outputToSceneDepth = outputToSceneDepth && (universalCameraData.camera.cameraType == CameraType.Game || universalCameraData.camera.cameraType == CameraType.SceneView);
			passData2.hasAtmosphericScattering = hasAtmosphericScattering;
			passData2.cloudsColorHandle = textureHandle3;
			passData2.accumulateHandle = textureHandle;
			passData2.historyHandle = textureHandle2;
			ConfigureInput(ScriptableRenderPassInput.Depth);
			unsafeRenderGraphBuilder.UseTexture(in passData2.cameraColorHandle, AccessFlags.ReadWrite);
			unsafeRenderGraphBuilder.UseTexture(in passData2.activeDepthHandle, AccessFlags.None);
			unsafeRenderGraphBuilder.UseTexture(in passData2.cameraDepthHandle);
			unsafeRenderGraphBuilder.UseTexture(in passData2.cloudsColorHandle, AccessFlags.Write);
			unsafeRenderGraphBuilder.UseTexture(in passData2.accumulateHandle, AccessFlags.Write);
			unsafeRenderGraphBuilder.UseTexture(in passData2.historyHandle, AccessFlags.ReadWrite);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				ExecutePass(data, context);
			});
		}

		public void Dispose()
		{
			cloudsColorHandle?.Release();
			cloudsDepthHandle?.Release();
			historyHandle?.Release();
			accumulateHandle?.Release();
			cameraTempDepthHandle?.Release();
		}
	}

	public class VolumetricCloudsAmbientPass : ScriptableRenderPass
	{
		private class PassData
		{
			internal Material cloudsMaterial;

			internal TextureHandle probeColorHandle;

			internal Vector3 cameraPositionWS;

			internal Vector4 cameraScreenParams;

			internal Vector4 cameraScreenSize;

			internal Matrix4x4 worldToCameraMatrix;

			internal Matrix4x4 projectionMatrix;

			internal RendererListHandle[] rendererListHandles;

			internal Matrix4x4[] skyViewMatrices;

			internal Matrix4x4 skyProjectionMatrix;

			internal bool isStereoEnabled;
		}

		private const string profilerTag = "Volumetric Clouds Ambient Probe";

		private readonly ProfilingSampler m_ProfilingSampler = new ProfilingSampler("Volumetric Clouds Ambient Probe");

		private readonly Material cloudsMaterial;

		private RTHandle probeColorHandle;

		private const string _VolumetricCloudsAmbientProbe = "_VolumetricCloudsAmbientProbe";

		private const string STEREO_INSTANCING_ON = "STEREO_INSTANCING_ON";

		private static readonly int worldSpaceCameraPos = Shader.PropertyToID("_WorldSpaceCameraPos");

		private static readonly int disableSunDisk = Shader.PropertyToID("_DisableSunDisk");

		private static readonly int unity_MatrixInvVP = Shader.PropertyToID("unity_MatrixInvVP");

		private static readonly int scaledScreenParams = Shader.PropertyToID("_ScaledScreenParams");

		private static readonly int screenSize = Shader.PropertyToID("_ScreenSize");

		private static readonly int volumetricCloudsAmbientProbe = Shader.PropertyToID("_VolumetricCloudsAmbientProbe");

		private static readonly Matrix4x4 frontView = new Matrix4x4(math.float4(-1f, 0f, 0f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(0f, 0f, -1f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 backView = new Matrix4x4(math.float4(1f, 0f, 0f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(0f, 0f, 1f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 upView = new Matrix4x4(math.float4(1f, 0f, 0f, 0f), math.float4(0f, 0f, -1f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 downView = new Matrix4x4(math.float4(1f, 0f, 0f, 0f), math.float4(0f, 0f, 1f, 0f), math.float4(0f, 1f, 0f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 rightView = new Matrix4x4(math.float4(0f, 0f, -1f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(1f, 0f, 0f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4 leftView = new Matrix4x4(math.float4(0f, 0f, 1f, 0f), math.float4(0f, -1f, 0f, 0f), math.float4(-1f, 0f, 0f, 0f), math.float4(0f, 0f, 0f, 1f));

		private static readonly Matrix4x4[] skyViews = new Matrix4x4[6] { rightView, leftView, upView, downView, backView, frontView };

		private readonly RendererListHandle[] rendererListHandles = new RendererListHandle[6];

		private readonly Matrix4x4[] skyViewMatrices = new Matrix4x4[6];

		private static readonly Matrix4x4 skyProjectionMatrix = Matrix4x4.Perspective(90f, 1f, 0.1f, 10f);

		private static readonly Vector4 skyViewScreenParams = new Vector4(16f, 16f, 1f + math.rcp(16f), 1f + math.rcp(16f));

		private static readonly Vector4 skyViewScreenSize = new Vector4(16f, 16f, math.rcp(16f), math.rcp(16f));

		public VolumetricCloudsAmbientPass(Material material)
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
			descriptor.width = 16;
			descriptor.height = 16;
			descriptor.dimension = TextureDimension.Cube;
			descriptor.depthStencilFormat = GraphicsFormat.None;
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateHandleIfNeeded(ref probeColorHandle, in descriptor, FilterMode.Trilinear, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsAmbientProbe");
			cloudsMaterial.SetTexture(volumetricCloudsAmbientProbe, probeColorHandle);
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
				Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(skyProjectionMatrix, renderIntoTexture: true);
				commandBuffer.SetGlobalVector(worldSpaceCameraPos, Vector3.zero);
				commandBuffer.SetGlobalFloat(disableSunDisk, 1f);
				commandBuffer.SetGlobalVector(scaledScreenParams, skyViewScreenParams);
				commandBuffer.SetGlobalVector(screenSize, skyViewScreenSize);
				for (int i = 0; i < 6; i++)
				{
					CoreUtils.SetRenderTarget(commandBuffer, probeColorHandle, ClearFlag.None, 0, (CubemapFace)i);
					Matrix4x4 matrix4x = skyViews[i];
					matrix4x *= Matrix4x4.Scale(new Vector3(1f, 1f, -1f));
					skyViewMatrices[i] = matrix4x;
					Matrix4x4 matrix4x2 = gPUProjectionMatrix * skyViewMatrices[i];
					commandBuffer.SetViewMatrix(skyViewMatrices[i]);
					commandBuffer.SetGlobalMatrix(unity_MatrixInvVP, matrix4x2.inverse);
					RendererList rendererList = context.CreateSkyboxRendererList(camera, skyProjectionMatrix, skyViewMatrices[i]);
					commandBuffer.DrawRendererList(rendererList);
				}
				commandBuffer.SetGlobalVector(worldSpaceCameraPos, position);
				commandBuffer.SetGlobalFloat(disableSunDisk, 0f);
				Matrix4x4 matrix4x3 = GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: true) * camera.worldToCameraMatrix;
				commandBuffer.SetViewMatrix(camera.worldToCameraMatrix);
				commandBuffer.SetGlobalMatrix(unity_MatrixInvVP, matrix4x3.inverse);
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
				CoreUtils.SetRenderTarget(nativeCommandBuffer, data.probeColorHandle, ClearFlag.None, 0, (CubemapFace)i);
				Matrix4x4 matrix4x = gPUProjectionMatrix * data.skyViewMatrices[i];
				nativeCommandBuffer.SetViewMatrix(data.skyViewMatrices[i]);
				context.cmd.SetGlobalMatrix(unity_MatrixInvVP, matrix4x.inverse);
				context.cmd.DrawRendererList(data.rendererListHandles[i]);
			}
			data.cloudsMaterial.SetTexture(volumetricCloudsAmbientProbe, data.probeColorHandle);
			context.cmd.SetGlobalVector(worldSpaceCameraPos, data.cameraPositionWS);
			context.cmd.SetGlobalFloat(disableSunDisk, 0f);
			Matrix4x4 matrix4x2 = GL.GetGPUProjectionMatrix(data.projectionMatrix, renderIntoTexture: true) * data.worldToCameraMatrix;
			nativeCommandBuffer.SetViewMatrix(data.worldToCameraMatrix);
			context.cmd.SetGlobalMatrix(unity_MatrixInvVP, matrix4x2.inverse);
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
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Volumetric Clouds Ambient Probe", out passData, "E:\\NewUnityProjects\\Escobar_Win\\Assets\\VolumetricClouds\\VolumetricCloudsURP.cs", 1411);
			frameData.Get<UniversalRenderingData>();
			frameData.Get<UniversalResourceData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			RenderTextureDescriptor descriptor = universalCameraData.cameraTargetDescriptor;
			float2 float5 = math.float2(descriptor.width, descriptor.height);
			descriptor.msaaSamples = 1;
			descriptor.useMipMap = true;
			descriptor.autoGenerateMips = true;
			descriptor.width = 16;
			descriptor.height = 16;
			descriptor.dimension = TextureDimension.Cube;
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateHandleIfNeeded(ref probeColorHandle, in descriptor, FilterMode.Trilinear, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsAmbientProbe");
			TextureHandle textureHandle = renderGraph.ImportTexture(probeColorHandle);
			passData.probeColorHandle = textureHandle;
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
			passData.isStereoEnabled = universalCameraData.camera.stereoEnabled;
			unsafeRenderGraphBuilder.UseTexture(in passData.probeColorHandle, AccessFlags.Write);
			unsafeRenderGraphBuilder.AllowGlobalStateModification(value: true);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				ExecutePass(data, context);
			});
		}

		public void Dispose()
		{
			probeColorHandle?.Release();
		}
	}

	public class VolumetricCloudsShadowsPass : ScriptableRenderPass
	{
		private class PassData
		{
			internal Material cloudsMaterial;

			internal TextureHandle intermediateShadowTexture;

			internal TextureHandle shadowTexture;

			internal Matrix4x4 mainLightWorldToLight;

			internal float mainLightCookieTextureFormat;

			internal Vector4 shadowOriginToggle;

			internal Vector4 shadowScale;

			internal bool isStereoEnabled;
		}

		private enum LightCookieShaderFormat
		{
			None = -1,
			RGB = 0,
			Alpha = 1,
			Red = 2
		}

		private const string profilerTag = "Volumetric Clouds Shadows";

		private readonly ProfilingSampler m_ProfilingSampler = new ProfilingSampler("Volumetric Clouds Shadows");

		public VolumetricClouds cloudsVolume;

		private readonly Material cloudsMaterial;

		private RTHandle shadowTextureHandle;

		private RTHandle intermediateShadowTextureHandle;

		private readonly Vector3[] frustumCorners = new Vector3[4];

		private Light targetLight;

		private static readonly int shadowCookieResolution = Shader.PropertyToID("_ShadowCookieResolution");

		private static readonly int shadowIntensity = Shader.PropertyToID("_ShadowIntensity");

		private static readonly int shadowOpacityFallback = Shader.PropertyToID("_ShadowOpacityFallback");

		private static readonly int cloudShadowSunOrigin = Shader.PropertyToID("_CloudShadowSunOrigin");

		private static readonly int cloudShadowSunRight = Shader.PropertyToID("_CloudShadowSunRight");

		private static readonly int cloudShadowSunUp = Shader.PropertyToID("_CloudShadowSunUp");

		private static readonly int cloudShadowSunForward = Shader.PropertyToID("_CloudShadowSunForward");

		private static readonly int cameraPositionPS = Shader.PropertyToID("_CameraPositionPS");

		private static readonly int volumetricCloudsShadowOriginToggle = Shader.PropertyToID("_VolumetricCloudsShadowOriginToggle");

		private static readonly int volumetricCloudsShadowScale = Shader.PropertyToID("_VolumetricCloudsShadowScale");

		private const string _VolumetricCloudsShadowTexture = "_VolumetricCloudsShadowTexture";

		private const string _VolumetricCloudsShadowTempTexture = "_VolumetricCloudsShadowTempTexture";

		private const string _LIGHT_COOKIES = "_LIGHT_COOKIES";

		private const string STEREO_INSTANCING_ON = "STEREO_INSTANCING_ON";

		private static readonly Matrix4x4 s_DirLightProj = Matrix4x4.Ortho(-0.5f, 0.5f, -0.5f, 0.5f, -0.5f, 0.5f);

		private static readonly int mainLightTexture = Shader.PropertyToID("_MainLightCookieTexture");

		private static readonly int mainLightWorldToLight = Shader.PropertyToID("_MainLightWorldToLight");

		private static readonly int mainLightCookieTextureFormat = Shader.PropertyToID("_MainLightCookieTextureFormat");

		public VolumetricCloudsShadowsPass(Material material)
		{
			cloudsMaterial = material;
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
			GraphicsFormat graphicsFormat = GraphicsFormat.R16_UNorm;
			graphicsFormat = (SystemInfo.IsFormatSupported(graphicsFormat, GraphicsFormatUsage.Render) ? graphicsFormat : GraphicsFormat.B10G11R11_UFloatPack32);
			int value = (int)cloudsVolume.shadowResolution.value;
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.msaaSamples = 1;
			descriptor.depthBufferBits = 0;
			descriptor.useMipMap = false;
			descriptor.graphicsFormat = graphicsFormat;
			descriptor.height = value;
			descriptor.width = value;
			descriptor.dimension = TextureDimension.Tex2D;
			RenderingUtils.ReAllocateHandleIfNeeded(ref shadowTextureHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsShadowTexture");
			RenderingUtils.ReAllocateHandleIfNeeded(ref intermediateShadowTextureHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsShadowTempTexture");
			ConfigureTarget(shadowTextureHandle, shadowTextureHandle);
		}

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CameraData cameraData = renderingData.cameraData;
			Camera camera = cameraData.camera;
			LightData lightData = renderingData.lightData;
			bool stereoEnabled = camera.stereoEnabled;
			Light mainLight = GetMainLight(lightData);
			if (targetLight != mainLight)
			{
				ResetShadowCookie();
				targetLight = mainLight;
			}
			if (!(targetLight != null) || !targetLight.isActiveAndEnabled || targetLight.intensity == 0f)
			{
				ResetShadowCookie();
				return;
			}
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, m_ProfilingSampler))
			{
				if (stereoEnabled)
				{
					commandBuffer.DisableShaderKeyword("STEREO_INSTANCING_ON");
				}
				Matrix4x4 worldToLocalMatrix = targetLight.transform.worldToLocalMatrix;
				Matrix4x4 localToWorldMatrix = targetLight.transform.localToWorldMatrix;
				float3 float5 = camera.transform.position;
				float a = cloudsVolume.shadowDistance.value / math.cos(camera.fieldOfView * (MathF.PI / 180f) * 0.5f);
				camera.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);
				Bounds bounds = default(Bounds);
				bounds.SetMinMax(new Vector3(float.MaxValue, float.MaxValue, float.MaxValue), new Vector3(float.MinValue, float.MinValue, float.MinValue));
				bounds.Encapsulate(worldToLocalMatrix.MultiplyPoint(float5));
				for (int i = 0; i < 4; i++)
				{
					Vector3 vector = frustumCorners[i];
					float magnitude = vector.magnitude;
					vector = vector / magnitude * Mathf.Min(a, magnitude);
					Vector3 point = worldToLocalMatrix.MultiplyPoint(new float3(vector) + float5);
					bounds.Encapsulate(point);
					point = worldToLocalMatrix.MultiplyPoint(new float3(-vector) + float5);
					bounds.Encapsulate(point);
				}
				float3 float6 = localToWorldMatrix.MultiplyPoint(bounds.center + new Vector3(0f - bounds.extents.x, 0f - bounds.extents.y, bounds.extents.z));
				float3 float7 = localToWorldMatrix.MultiplyPoint(bounds.center + new Vector3(bounds.extents.x, 0f - bounds.extents.y, bounds.extents.z));
				float3 obj = localToWorldMatrix.MultiplyPoint(bounds.center + new Vector3(0f - bounds.extents.x, bounds.extents.y, bounds.extents.z));
				float num = Mathf.Lerp(1f, 0.025f, cloudsVolume.earthCurvature.value) * 6378100f;
				float3 float8 = math.float3(0f, 0f - num, 0f);
				float3 float9 = float7 - float6;
				float3 float10 = obj - float6;
				float2 float11 = math.float2(math.length(float9), math.length(float10));
				int value = (int)cloudsVolume.shadowResolution.value;
				cloudsMaterial.SetFloat(shadowCookieResolution, value);
				cloudsMaterial.SetFloat(shadowIntensity, cloudsVolume.shadowOpacity.value);
				cloudsMaterial.SetFloat(shadowOpacityFallback, 1f - cloudsVolume.shadowOpacityFallback.value);
				cloudsMaterial.SetVector(cloudShadowSunOrigin, math.float4(float6 - float8, 1f));
				cloudsMaterial.SetVector(cloudShadowSunRight, math.float4(float9, 0f));
				cloudsMaterial.SetVector(cloudShadowSunUp, math.float4(float10, 0f));
				cloudsMaterial.SetVector(cloudShadowSunForward, math.float4(-targetLight.transform.forward, 0f));
				cloudsMaterial.SetVector(cameraPositionPS, math.float4(float5 - float8, 0f));
				commandBuffer.SetGlobalVector(volumetricCloudsShadowOriginToggle, math.float4(float6, 0f));
				commandBuffer.SetGlobalVector(volumetricCloudsShadowScale, math.float4(float11, 0f, 0f));
				targetLight.cookie = null;
				UniversalAdditionalLightData component = targetLight.GetComponent<UniversalAdditionalLightData>();
				component.lightCookieSize = Vector2.one;
				component.lightCookieOffset = Vector2.zero;
				Vector2 vector2 = 1f / float11;
				float minValue = half.MinValue;
				if (Mathf.Abs(vector2.x) < minValue)
				{
					vector2.x = Mathf.Sign(vector2.x) * minValue;
				}
				if (Mathf.Abs(vector2.y) < minValue)
				{
					vector2.y = Mathf.Sign(vector2.y) * minValue;
				}
				Matrix4x4 matrix4x = Matrix4x4.Scale(new Vector3(vector2.x, vector2.y, 1f));
				localToWorldMatrix.SetColumn(3, math.float4(float5, 1f));
				Matrix4x4 value2 = s_DirLightProj * matrix4x * localToWorldMatrix.inverse;
				float value3 = (float)GetLightCookieShaderFormat(shadowTextureHandle.rt.graphicsFormat);
				commandBuffer.SetGlobalTexture(mainLightTexture, shadowTextureHandle);
				commandBuffer.SetGlobalMatrix(mainLightWorldToLight, value2);
				commandBuffer.SetGlobalFloat(mainLightCookieTextureFormat, value3);
				commandBuffer.EnableShaderKeyword("_LIGHT_COOKIES");
				Blitter.BlitCameraTexture(commandBuffer, shadowTextureHandle, shadowTextureHandle, cloudsMaterial, 4);
				Blitter.BlitCameraTexture(commandBuffer, shadowTextureHandle, intermediateShadowTextureHandle, cloudsMaterial, 5);
				Blitter.BlitCameraTexture(commandBuffer, intermediateShadowTextureHandle, shadowTextureHandle, cloudsMaterial, 5);
				if (stereoEnabled)
				{
					commandBuffer.EnableShaderKeyword("STEREO_INSTANCING_ON");
				}
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
			if (data.isStereoEnabled)
			{
				nativeCommandBuffer.DisableShaderKeyword("STEREO_INSTANCING_ON");
			}
			Blitter.BlitCameraTexture(nativeCommandBuffer, data.shadowTexture, data.shadowTexture, data.cloudsMaterial, 4);
			Blitter.BlitCameraTexture(nativeCommandBuffer, data.shadowTexture, data.intermediateShadowTexture, data.cloudsMaterial, 5);
			Blitter.BlitCameraTexture(nativeCommandBuffer, data.intermediateShadowTexture, data.shadowTexture, data.cloudsMaterial, 5);
			nativeCommandBuffer.SetGlobalVector(volumetricCloudsShadowOriginToggle, data.shadowOriginToggle);
			nativeCommandBuffer.SetGlobalVector(volumetricCloudsShadowScale, data.shadowScale);
			nativeCommandBuffer.SetGlobalTexture(mainLightTexture, data.shadowTexture);
			nativeCommandBuffer.SetGlobalMatrix(mainLightWorldToLight, data.mainLightWorldToLight);
			nativeCommandBuffer.SetGlobalFloat(mainLightCookieTextureFormat, data.mainLightCookieTextureFormat);
			nativeCommandBuffer.EnableShaderKeyword("_LIGHT_COOKIES");
			if (data.isStereoEnabled)
			{
				nativeCommandBuffer.EnableShaderKeyword("STEREO_INSTANCING_ON");
			}
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			UniversalLightData lightData = frameData.Get<UniversalLightData>();
			frameData.Get<UniversalRenderingData>();
			frameData.Get<UniversalResourceData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			Light mainLight = GetMainLight(lightData);
			if (targetLight != mainLight)
			{
				ResetShadowCookie();
				targetLight = mainLight;
			}
			if (!(targetLight != null) || !targetLight.isActiveAndEnabled || targetLight.intensity == 0f)
			{
				ResetShadowCookie();
				return;
			}
			Camera camera = universalCameraData.camera;
			PassData passData;
			using IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Volumetric Clouds Shadows", out passData, "E:\\NewUnityProjects\\Escobar_Win\\Assets\\VolumetricClouds\\VolumetricCloudsURP.cs", 1802);
			Matrix4x4 worldToLocalMatrix = targetLight.transform.worldToLocalMatrix;
			Matrix4x4 localToWorldMatrix = targetLight.transform.localToWorldMatrix;
			float3 float5 = camera.transform.position;
			float a = cloudsVolume.shadowDistance.value / math.cos(camera.fieldOfView * (MathF.PI / 180f) * 0.5f);
			camera.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);
			Bounds bounds = default(Bounds);
			bounds.SetMinMax(new Vector3(float.MaxValue, float.MaxValue, float.MaxValue), new Vector3(float.MinValue, float.MinValue, float.MinValue));
			bounds.Encapsulate(worldToLocalMatrix.MultiplyPoint(float5));
			for (int i = 0; i < 4; i++)
			{
				Vector3 vector = frustumCorners[i];
				float magnitude = vector.magnitude;
				vector = vector / magnitude * Mathf.Min(a, magnitude);
				Vector3 point = worldToLocalMatrix.MultiplyPoint(math.float3(vector) + float5);
				bounds.Encapsulate(point);
				point = worldToLocalMatrix.MultiplyPoint(math.float3(-vector) + float5);
				bounds.Encapsulate(point);
			}
			float3 float6 = localToWorldMatrix.MultiplyPoint(bounds.center + new Vector3(0f - bounds.extents.x, 0f - bounds.extents.y, bounds.extents.z));
			float3 float7 = localToWorldMatrix.MultiplyPoint(bounds.center + new Vector3(bounds.extents.x, 0f - bounds.extents.y, bounds.extents.z));
			float3 obj = localToWorldMatrix.MultiplyPoint(bounds.center + new Vector3(0f - bounds.extents.x, bounds.extents.y, bounds.extents.z));
			float num = Mathf.Lerp(1f, 0.025f, cloudsVolume.earthCurvature.value) * 6378100f;
			float3 float8 = math.float3(0f, 0f - num, 0f);
			float3 float9 = float7 - float6;
			float3 float10 = obj - float6;
			float2 float11 = math.float2(math.length(float9), math.length(float10));
			GraphicsFormat graphicsFormat = GraphicsFormat.R16_UNorm;
			graphicsFormat = (SystemInfo.IsFormatSupported(graphicsFormat, GraphicsFormatUsage.Render) ? graphicsFormat : GraphicsFormat.B10G11R11_UFloatPack32);
			int value = (int)cloudsVolume.shadowResolution.value;
			RenderTextureDescriptor descriptor = universalCameraData.cameraTargetDescriptor;
			descriptor.msaaSamples = 1;
			descriptor.depthBufferBits = 0;
			descriptor.useMipMap = false;
			descriptor.graphicsFormat = graphicsFormat;
			descriptor.height = value;
			descriptor.width = value;
			descriptor.dimension = TextureDimension.Tex2D;
			RenderingUtils.ReAllocateHandleIfNeeded(ref shadowTextureHandle, in descriptor, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "_VolumetricCloudsShadowTexture");
			TextureHandle shadowTexture = renderGraph.ImportTexture(shadowTextureHandle);
			TextureHandle intermediateShadowTexture = renderGraph.CreateTexture(new TextureDesc(value, value)
			{
				colorFormat = graphicsFormat,
				enableRandomWrite = false,
				name = "_VolumetricCloudsShadowTempTexture"
			});
			cloudsMaterial.SetFloat(shadowCookieResolution, value);
			cloudsMaterial.SetFloat(shadowIntensity, cloudsVolume.shadowOpacity.value);
			cloudsMaterial.SetFloat(shadowOpacityFallback, 1f - cloudsVolume.shadowOpacityFallback.value);
			cloudsMaterial.SetVector(cloudShadowSunOrigin, math.float4(float6 - float8, 1f));
			cloudsMaterial.SetVector(cloudShadowSunRight, math.float4(float9, 0f));
			cloudsMaterial.SetVector(cloudShadowSunUp, math.float4(float10, 0f));
			cloudsMaterial.SetVector(cloudShadowSunForward, math.float4(-targetLight.transform.forward, 0f));
			cloudsMaterial.SetVector(cameraPositionPS, math.float4(float5 - float8, 0f));
			cloudsMaterial.SetVector(volumetricCloudsShadowOriginToggle, math.float4(float6, 0f));
			targetLight.cookie = null;
			UniversalAdditionalLightData component = targetLight.GetComponent<UniversalAdditionalLightData>();
			component.lightCookieSize = Vector2.one;
			component.lightCookieOffset = Vector2.zero;
			Vector2 vector2 = 1f / float11;
			float minValue = half.MinValue;
			if (Mathf.Abs(vector2.x) < minValue)
			{
				vector2.x = Mathf.Sign(vector2.x) * minValue;
			}
			if (Mathf.Abs(vector2.y) < minValue)
			{
				vector2.y = Mathf.Sign(vector2.y) * minValue;
			}
			Matrix4x4 matrix4x = Matrix4x4.Scale(new Vector3(vector2.x, vector2.y, 1f));
			localToWorldMatrix.SetColumn(3, math.float4(float5, 1f));
			Matrix4x4 matrix4x2 = s_DirLightProj * matrix4x * localToWorldMatrix.inverse;
			float num2 = (float)GetLightCookieShaderFormat(graphicsFormat);
			passData.cloudsMaterial = cloudsMaterial;
			passData.shadowTexture = shadowTexture;
			passData.intermediateShadowTexture = intermediateShadowTexture;
			passData.mainLightWorldToLight = matrix4x2;
			passData.mainLightCookieTextureFormat = num2;
			passData.shadowOriginToggle = math.float4(float6, 0f);
			passData.shadowScale = math.float4(float11, 0f, 0f);
			passData.isStereoEnabled = universalCameraData.camera.stereoEnabled;
			unsafeRenderGraphBuilder.UseTexture(in passData.shadowTexture, AccessFlags.Write);
			unsafeRenderGraphBuilder.UseTexture(in passData.intermediateShadowTexture, AccessFlags.Write);
			unsafeRenderGraphBuilder.AllowGlobalStateModification(value: true);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				ExecutePass(data, context);
			});
		}

		private LightCookieShaderFormat GetLightCookieShaderFormat(GraphicsFormat cookieFormat)
		{
			switch (cookieFormat)
			{
			default:
				return LightCookieShaderFormat.RGB;
			case (GraphicsFormat)54:
			case (GraphicsFormat)55:
				return LightCookieShaderFormat.Alpha;
			case GraphicsFormat.R8_SRGB:
			case GraphicsFormat.R8_UNorm:
			case GraphicsFormat.R8_SNorm:
			case GraphicsFormat.R8_UInt:
			case GraphicsFormat.R8_SInt:
			case GraphicsFormat.R16_UNorm:
			case GraphicsFormat.R16_SNorm:
			case GraphicsFormat.R16_UInt:
			case GraphicsFormat.R16_SInt:
			case GraphicsFormat.R32_UInt:
			case GraphicsFormat.R32_SInt:
			case GraphicsFormat.R16_SFloat:
			case GraphicsFormat.R32_SFloat:
			case GraphicsFormat.R_BC4_UNorm:
			case GraphicsFormat.R_BC4_SNorm:
			case GraphicsFormat.R_EAC_UNorm:
			case GraphicsFormat.R_EAC_SNorm:
				return LightCookieShaderFormat.Red;
			}
		}

		private void ResetShadowCookie()
		{
			if (targetLight != null)
			{
				targetLight.cookie = null;
				UniversalAdditionalLightData component = targetLight.GetComponent<UniversalAdditionalLightData>();
				if (component != null)
				{
					component.lightCookieSize = Vector2.one;
					component.lightCookieOffset = Vector2.zero;
				}
			}
		}

		public void Dispose()
		{
			ResetShadowCookie();
			shadowTextureHandle?.Release();
			intermediateShadowTextureHandle?.Release();
		}
	}

	[Header("Setup")]
	[Tooltip("The material of volumetric clouds shader.")]
	[SerializeField]
	private Material material;

	[Tooltip("Enable this to render volumetric clouds in Rendering Debugger view. \nThis is disabled by default to avoid affecting the individual lighting previews.")]
	[SerializeField]
	private bool renderingDebugger;

	[Header("Performance")]
	[Tooltip("Specifies if URP renders volumetric clouds in both real-time and baked reflection probes. \nVolumetric clouds in real-time reflection probes may reduce performance.")]
	[SerializeField]
	private bool reflectionProbe;

	[Range(0.25f, 1f)]
	[Tooltip("The resolution scale for volumetric clouds rendering.")]
	[SerializeField]
	private float resolutionScale = 0.5f;

	[Tooltip("Select the method to use for upscaling volumetric clouds.")]
	[SerializeField]
	private CloudsUpscaleMode upscaleMode;

	[Tooltip("Specifies the preferred texture render mode for volumetric clouds. \nThe Copy Texture mode should be more performant.")]
	[SerializeField]
	private CloudsRenderMode preferredRenderMode = CloudsRenderMode.CopyTexture;

	[Header("Lighting")]
	[Tooltip("Specifies the volumetric clouds ambient probe update frequency.")]
	[SerializeField]
	private CloudsAmbientMode ambientProbe = CloudsAmbientMode.Dynamic;

	[Tooltip("Specifies if URP calculates physically based sun attenuation for volumetric clouds.")]
	[SerializeField]
	private bool sunAttenuation;

	[Header("Wind")]
	[Tooltip("Enable to reset the wind offsets to their initial states when start playing.")]
	[SerializeField]
	private bool resetOnStart = true;

	[Header("Depth")]
	[Tooltip("Specifies if URP outputs volumetric clouds average depth to a global shader texture named \"_VolumetricCloudsDepthTexture\".")]
	[SerializeField]
	private bool outputDepth = true;

	[Header("Experimental")]
	[Tooltip("Specifies if URP also outputs volumetric clouds average depth to \"_CameraDepthTexture\".")]
	[SerializeField]
	private bool depthTexture;

	private const string shaderName = "Hidden/Sky/VolumetricClouds";

	private const string VOLUMETRIC_CLOUDS = "VOLUMETRIC_CLOUDS";

	private const string VISUAL_ENVIRONMENT_DYNAMIC_SKY = "VISUAL_ENVIRONMENT_DYNAMIC_SKY";

	private VolumetricCloudsPass volumetricCloudsPass;

	private VolumetricCloudsAmbientPass volumetricCloudsAmbientPass;

	private VolumetricCloudsShadowsPass volumetricCloudsShadowsPass;

	private bool isLogPrinted;

	private bool isCookiePrinted;

	public Material CloudsMaterial
	{
		get
		{
			return material;
		}
		set
		{
			material = ((value.shader == Shader.Find("Hidden/Sky/VolumetricClouds")) ? value : material);
		}
	}

	public bool RenderingDebugger
	{
		get
		{
			return renderingDebugger;
		}
		set
		{
			renderingDebugger = value;
		}
	}

	public float ResolutionScale
	{
		get
		{
			return resolutionScale;
		}
		set
		{
			resolutionScale = Mathf.Clamp(value, 0.25f, 1f);
		}
	}

	public CloudsRenderMode PreferredRenderMode
	{
		get
		{
			return preferredRenderMode;
		}
		set
		{
			preferredRenderMode = value;
		}
	}

	public CloudsAmbientMode AmbientUpdateMode
	{
		get
		{
			return ambientProbe;
		}
		set
		{
			ambientProbe = value;
		}
	}

	public CloudsUpscaleMode UpscaleMode
	{
		get
		{
			return upscaleMode;
		}
		set
		{
			upscaleMode = value;
		}
	}

	public bool ResetWindOnStart
	{
		get
		{
			return resetOnStart;
		}
		set
		{
			resetOnStart = value;
		}
	}

	public bool SunAttenuation
	{
		get
		{
			return sunAttenuation;
		}
		set
		{
			sunAttenuation = value;
		}
	}

	public bool OutputCloudsDepth
	{
		get
		{
			return outputDepth;
		}
		set
		{
			outputDepth = value;
		}
	}

	public bool OutputToSceneDepth
	{
		get
		{
			return depthTexture;
		}
		set
		{
			depthTexture = value;
		}
	}

	public override void Create()
	{
		if (!(material != null) || material.shader != Shader.Find("Hidden/Sky/VolumetricClouds"))
		{
			return;
		}
		bool isAnyDebugUIActive = DebugManager.instance.isAnyDebugUIActive;
		VolumeStack stack = VolumeManager.instance.stack;
		if (stack != null)
		{
			VolumetricClouds component = stack.GetComponent<VolumetricClouds>();
			bool flag = component != null && component.IsActive() && (!isAnyDebugUIActive || renderingDebugger);
			if (!base.isActive || !flag)
			{
				Shader.DisableKeyword("VOLUMETRIC_CLOUDS");
			}
			else
			{
				Shader.EnableKeyword("VOLUMETRIC_CLOUDS");
			}
			if (volumetricCloudsPass == null)
			{
				volumetricCloudsPass = new VolumetricCloudsPass(material, resolutionScale);
				volumetricCloudsPass.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
			}
			else
			{
				volumetricCloudsPass.resolutionScale = resolutionScale;
				volumetricCloudsPass.upscaleMode = upscaleMode;
				volumetricCloudsPass.dynamicAmbientProbe = ambientProbe == CloudsAmbientMode.Dynamic;
			}
			if (volumetricCloudsAmbientPass == null)
			{
				volumetricCloudsAmbientPass = new VolumetricCloudsAmbientPass(material);
				volumetricCloudsAmbientPass.renderPassEvent = (RenderPassEvent)449;
			}
			if (volumetricCloudsShadowsPass == null)
			{
				volumetricCloudsShadowsPass = new VolumetricCloudsShadowsPass(material);
				volumetricCloudsShadowsPass.renderPassEvent = RenderPassEvent.BeforeRendering;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (volumetricCloudsPass != null)
		{
			volumetricCloudsPass.Dispose();
		}
		if (volumetricCloudsAmbientPass != null)
		{
			volumetricCloudsAmbientPass.Dispose();
		}
		if (volumetricCloudsShadowsPass != null)
		{
			volumetricCloudsShadowsPass.Dispose();
		}
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (material == null)
		{
			return;
		}
		VolumeStack stack = VolumeManager.instance.stack;
		VolumetricClouds component = stack.GetComponent<VolumetricClouds>();
		ColorAdjustments component2 = stack.GetComponent<ColorAdjustments>();
		bool isAnyDebugUIActive = DebugManager.instance.isAnyDebugUIActive;
		bool num = component != null && component.IsActive() && (!isAnyDebugUIActive || renderingDebugger);
		bool flag = renderingData.cameraData.cameraType == CameraType.Reflection && reflectionProbe;
		if (num)
		{
			Shader.EnableKeyword("VOLUMETRIC_CLOUDS");
		}
		else
		{
			Shader.DisableKeyword("VOLUMETRIC_CLOUDS");
		}
		if (num && (renderingData.cameraData.cameraType == CameraType.Game || renderingData.cameraData.cameraType == CameraType.SceneView || flag))
		{
			bool flag2 = ambientProbe == CloudsAmbientMode.Dynamic;
			volumetricCloudsPass.cloudsVolume = component;
			volumetricCloudsPass.colorAdjustments = component2;
			volumetricCloudsPass.dynamicAmbientProbe = flag2;
			volumetricCloudsPass.renderMode = preferredRenderMode;
			volumetricCloudsPass.resetWindOnStart = resetOnStart;
			volumetricCloudsPass.outputDepth = depthTexture || outputDepth;
			volumetricCloudsPass.outputToSceneDepth = depthTexture;
			volumetricCloudsPass.sunAttenuation = sunAttenuation;
			volumetricCloudsShadowsPass.cloudsVolume = component;
			volumetricCloudsPass.hasAtmosphericScattering = false;
			renderer.EnqueuePass(volumetricCloudsPass);
			if (component.shadows.value && UniversalRenderPipeline.asset.supportsLightCookies)
			{
				isCookiePrinted = false;
				renderer.EnqueuePass(volumetricCloudsShadowsPass);
			}
			if (flag2 && !flag)
			{
				renderer.EnqueuePass(volumetricCloudsAmbientPass);
			}
			isLogPrinted = false;
		}
	}
}
