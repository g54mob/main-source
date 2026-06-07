using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

namespace Enviro
{
	[Serializable]
	[ExecuteInEditMode]
	public class EnviroVolumetricCloudsModule : EnviroModule
	{
		public EnviroCloudLayerSettings settingsLayer1;

		public EnviroCloudLayerSettings settingsLayer2;

		public EnviroCloudGlobalSettings settingsGlobal;

		public EnviroVolumetricCloudsQuality settingsQuality;

		public EnviroVolumetricCloudsModule preset;

		public bool showGlobalControls;

		public bool showLayer1Controls;

		public bool showLayer2Controls;

		public bool showCoverageControls;

		public bool showLightingControls;

		public bool showDensityControls;

		public bool showTextureControls;

		public bool showWindControls;

		public Vector3 cloudAnimLayer1;

		public Vector3 cloudAnimLayer2;

		public Vector3 cloudAnimNonScaledLayer1;

		public Vector3 cloudAnimNonScaledLayer2;

		public RenderTexture weatherMap;

		private Material weatherMapMat;

		private ComputeShader weatherMapCS;

		private Light dirLight;

		private Vector3 lastOffset = Vector3.zero;

		private Texture2DArray blackArray;

		private TextureDesc cloudsDescriptor;

		public override void UpdateModule()
		{
			if (active && !(EnviroManager.instance == null) && settingsQuality.volumetricClouds)
			{
				UpdateWind();
				weatherMap = EnviroManager.instance.VolumetricClouds.RenderWeatherMap();
			}
		}

		private void CreateBlackArray()
		{
			Color[] array = new Color[16];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Color(0f, 0f, 0f, 0f);
			}
			blackArray = new Texture2DArray(4, 4, 2, DefaultFormat.LDR, TextureCreationFlags.None);
			blackArray.SetPixels(array, 0);
			blackArray.SetPixels(array, 1);
			blackArray.Apply();
		}

		public override void Enable()
		{
			CreateBlackArray();
		}

		public override void Disable()
		{
			if (weatherMapMat != null)
			{
				UnityEngine.Object.DestroyImmediate(weatherMapMat);
			}
			if (weatherMap != null)
			{
				UnityEngine.Object.DestroyImmediate(weatherMap);
			}
		}

		public void RenderCloudsShadows(RenderTexture source, RenderTexture destination, EnviroVolumetricCloudRenderer renderer)
		{
			if (renderer.shadowMat == null)
			{
				renderer.shadowMat = new Material(Shader.Find("Hidden/EnviroApplyShadows"));
			}
			renderer.shadowMat.SetTexture("_CloudsTex", renderer.undersampleBuffer);
			renderer.shadowMat.SetFloat("_Intensity", EnviroManager.instance.VolumetricClouds.settingsGlobal.cloudShadowsIntensity);
			renderer.shadowMat.SetTexture("_MainTex", source);
			Graphics.Blit(source, destination, renderer.shadowMat);
		}

		public void RenderCloudsShadowsURP(EnviroURPRenderPass pass, Camera cam, CommandBuffer cmd, RenderTexture source, RenderTargetIdentifier destination, EnviroVolumetricCloudRenderer renderer)
		{
			if (renderer.shadowMat == null)
			{
				renderer.shadowMat = new Material(Shader.Find("Hidden/EnviroApplyShadows"));
			}
			renderer.shadowMat.SetTexture("_CloudsTex", renderer.undersampleBuffer);
			renderer.shadowMat.SetFloat("_Intensity", EnviroManager.instance.VolumetricClouds.settingsGlobal.cloudShadowsIntensity);
			renderer.shadowMat.EnableKeyword("ENVIROURP");
			pass.CustomBlit(cmd, cam.cameraToWorldMatrix, source, destination, renderer.shadowMat);
		}

		public void RenderCloudsShadowsURP(EnviroURPRenderGraph pass, RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, TextureHandle src, TextureHandle target, EnviroVolumetricCloudRenderer renderer)
		{
			if (renderer.shadowMat == null)
			{
				renderer.shadowMat = new Material(Shader.Find("Hidden/EnviroApplyShadowsURP"));
			}
			renderer.shadowMat.SetFloat("_Intensity", EnviroManager.instance.VolumetricClouds.settingsGlobal.cloudShadowsIntensity);
			renderer.shadowMat.EnableKeyword("ENVIROURP");
			pass.Blit("Apply Cloud Shadows", renderGraph, renderer.shadowMat, src, target, 0, renderer.undersampleBufferHandle, "_CloudsTex");
		}

		public void RenderVolumetricClouds(Camera cam, RenderTexture source, RenderTexture destination, EnviroVolumetricCloudRenderer renderer, EnviroQuality quality)
		{
			int downsampling = settingsQuality.downsampling;
			if (quality != null)
			{
				downsampling = quality.volumetricCloudsOverride.downsampling;
			}
			int width = cam.pixelWidth / downsampling;
			int height = cam.pixelHeight / downsampling;
			if (cam.cameraType != CameraType.Reflection)
			{
				if (renderer.fullBuffer == null || renderer.fullBuffer.Length != 2)
				{
					renderer.fullBuffer = new RenderTexture[2];
				}
				renderer.fullBufferIndex = (renderer.fullBufferIndex + 1) % 2;
				renderer.firstFrame |= CreateRenderTexture(ref renderer.fullBuffer[0], width, height, RenderTextureFormat.ARGBHalf, FilterMode.Bilinear, source.descriptor);
				renderer.firstFrame |= CreateRenderTexture(ref renderer.fullBuffer[1], width, height, RenderTextureFormat.ARGBHalf, FilterMode.Bilinear, source.descriptor);
			}
			renderer.firstFrame |= CreateRenderTexture(ref renderer.undersampleBuffer, width, height, RenderTextureFormat.ARGBHalf, FilterMode.Bilinear, source.descriptor);
			renderer.frame++;
			if (renderer.frame > 64)
			{
				renderer.frame = 0;
			}
			if (renderer.depthMat == null)
			{
				renderer.depthMat = new Material(Shader.Find("Hidden/EnviroVolumetricCloudsDepth"));
			}
			CreateRenderTexture(ref renderer.downsampledDepth, width, height, RenderTextureFormat.RFloat, FilterMode.Point, source.descriptor);
			renderer.depthMat.SetTexture("_MainTex", source);
			renderer.depthMat.SetVector("_CameraDepthTexture_TexelSize", new Vector4(1 / source.width, 1 / source.height, source.width, source.height));
			if (downsampling > 1)
			{
				Graphics.Blit(source, renderer.downsampledDepth, renderer.depthMat, 0);
			}
			else
			{
				Graphics.Blit(source, renderer.downsampledDepth, renderer.depthMat, 1);
			}
			SetRaymarchShader(cam, renderer, quality);
			renderer.raymarchMat.SetTexture("_MainTex", source);
			Graphics.Blit(source, renderer.undersampleBuffer, renderer.raymarchMat);
			if (cam.cameraType != CameraType.Reflection)
			{
				if (renderer.reprojectMat == null)
				{
					renderer.reprojectMat = new Material(Shader.Find("Hidden/EnviroVolumetricCloudsReproject"));
				}
				SetReprojectShader(cam, renderer, quality);
				if (renderer.firstFrame)
				{
					Graphics.Blit(renderer.undersampleBuffer, renderer.fullBuffer[renderer.fullBufferIndex]);
				}
				renderer.reprojectMat.SetTexture("_MainTex", renderer.fullBuffer[renderer.fullBufferIndex]);
				Graphics.Blit(renderer.fullBuffer[renderer.fullBufferIndex], renderer.fullBuffer[renderer.fullBufferIndex ^ 1], renderer.reprojectMat);
			}
			if (renderer.blendAndLightingMat == null)
			{
				renderer.blendAndLightingMat = new Material(Shader.Find("Hidden/EnviroVolumetricCloudsBlend"));
			}
			SetBlendShader(cam, renderer);
			renderer.blendAndLightingMat.SetTexture("_MainTex", source);
			Graphics.Blit(source, destination, renderer.blendAndLightingMat);
			renderer.prevV = cam.worldToCameraMatrix;
			renderer.firstFrame = false;
		}

		public void RenderVolumetricCloudsURP(EnviroURPRenderGraph pass, RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, TextureHandle src, TextureHandle target, EnviroVolumetricCloudRenderer renderer, EnviroQuality quality)
		{
			int downsampling = settingsQuality.downsampling;
			if (quality != null)
			{
				downsampling = quality.volumetricCloudsOverride.downsampling;
			}
			int width = cameraData.camera.pixelWidth / downsampling;
			int height = cameraData.camera.pixelHeight / downsampling;
			TextureDesc descriptor = src.GetDescriptor(renderGraph);
			RenderTextureDescriptor descriptor2 = new RenderTextureDescriptor(descriptor.width, descriptor.height, RenderTextureFormat.ARGBHalf, 0);
			descriptor2.vrUsage = descriptor.vrUsage;
			descriptor2.width = width;
			descriptor2.height = height;
			descriptor2.dimension = descriptor.dimension;
			descriptor2.volumeDepth = descriptor.slices;
			if (cameraData.camera.cameraType != CameraType.Reflection)
			{
				if (renderer.fullBufferHandles == null || renderer.fullBufferHandles.Length != 2)
				{
					renderer.fullBufferHandles = new TextureHandle[2];
				}
				if (renderer.fullBufferRTHandles == null || renderer.fullBufferRTHandles.Length != 2)
				{
					renderer.fullBufferRTHandles = new RTHandle[2];
				}
				renderer.fullBufferIndex = (renderer.fullBufferIndex + 1) % 2;
				renderer.firstFrame |= RenderingUtils.ReAllocateHandleIfNeeded(ref renderer.fullBufferRTHandles[0], in descriptor2, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "Enviro Clouds History Buffer 0");
				renderer.firstFrame |= RenderingUtils.ReAllocateHandleIfNeeded(ref renderer.fullBufferRTHandles[1], in descriptor2, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "Enviro Clouds History Buffer 1");
				renderer.fullBufferHandles[0] = renderGraph.ImportTexture(renderer.fullBufferRTHandles[0]);
				renderer.fullBufferHandles[1] = renderGraph.ImportTexture(renderer.fullBufferRTHandles[1]);
			}
			renderer.firstFrame |= RenderingUtils.ReAllocateHandleIfNeeded(ref renderer.undersampleRTBufferHandle, in descriptor2, FilterMode.Bilinear, TextureWrapMode.Clamp, 1, 0f, "Enviro Clouds Undersample Buffer");
			renderer.undersampleBufferHandle = renderGraph.ImportTexture(renderer.undersampleRTBufferHandle);
			renderer.frame++;
			if (renderer.frame > 64)
			{
				renderer.frame = 0;
			}
			if (renderer.depthMat == null)
			{
				renderer.depthMat = new Material(Shader.Find("Hidden/EnviroVolumetricCloudsDepthURP"));
			}
			renderer.depthMat.SetVector("_CameraDepthTexture_TexelSize", new Vector4(1 / cameraData.cameraTargetDescriptor.width, 1 / cameraData.cameraTargetDescriptor.height, cameraData.cameraTargetDescriptor.width, cameraData.cameraTargetDescriptor.height));
			SetToURP(renderer.depthMat);
			CreateRenderTexture(ref renderer.downsampledDepthHandle, renderGraph, width, height, GraphicsFormat.R32_SFloat, FilterMode.Point, descriptor);
			if (downsampling > 1)
			{
				pass.Blit("Downsample Depth", renderGraph, renderer.depthMat, src, renderer.downsampledDepthHandle, 0);
			}
			else
			{
				pass.Blit("Copy Depth", renderGraph, renderer.depthMat, src, renderer.downsampledDepthHandle, 1);
			}
			SetRaymarchShader(cameraData.camera, renderer, quality);
			SetToURP(renderer.raymarchMat);
			pass.Blit("Raymarch", renderGraph, renderer.raymarchMat, src, renderer.undersampleBufferHandle, 0, renderer.downsampledDepthHandle, "_DownsampledDepth");
			if (cameraData.camera.cameraType != CameraType.Reflection)
			{
				if (renderer.reprojectMat == null)
				{
					renderer.reprojectMat = new Material(Shader.Find("Hidden/EnviroVolumetricCloudsReprojectURP"));
				}
				SetReprojectShader(cameraData.camera, renderer, quality);
				SetToURP(renderer.reprojectMat);
				if (renderer.firstFrame)
				{
					pass.Blit("Reproject First Frame", renderGraph, renderer.reprojectMat, renderer.undersampleBufferHandle, renderer.fullBufferHandles[renderer.fullBufferIndex], 0, renderer.downsampledDepthHandle, "_DownsampledDepth", renderer.undersampleBufferHandle, "_UndersampleCloudTex");
				}
				pass.Blit("Reproject", renderGraph, renderer.reprojectMat, renderer.fullBufferHandles[renderer.fullBufferIndex], renderer.fullBufferHandles[renderer.fullBufferIndex ^ 1], 0, renderer.downsampledDepthHandle, "_DownsampledDepth", renderer.undersampleBufferHandle, "_UndersampleCloudTex");
			}
			if (renderer.blendAndLightingMat == null)
			{
				renderer.blendAndLightingMat = new Material(Shader.Find("Hidden/EnviroVolumetricCloudsBlendURP"));
			}
			SetBlendShader(cameraData.camera, renderer);
			SetToURP(renderer.blendAndLightingMat);
			if (cameraData.camera.cameraType != CameraType.Reflection)
			{
				pass.Blit("Blend", renderGraph, renderer.blendAndLightingMat, src, target, 0, renderer.downsampledDepthHandle, "_DownsampledDepth", renderer.fullBufferHandles[renderer.fullBufferIndex ^ 1], "_CloudTex");
			}
			else
			{
				pass.Blit("Blend", renderGraph, renderer.blendAndLightingMat, src, target, 0, renderer.downsampledDepthHandle, "_DownsampledDepth", renderer.undersampleBufferHandle, "_CloudTex");
			}
			renderer.prevV = cameraData.camera.worldToCameraMatrix;
			renderer.firstFrame = false;
		}

		public void RenderVolumetricCloudsURP(RenderingData renderingData, EnviroURPRenderPass pass, CommandBuffer cmd, RenderTexture source, RenderTargetIdentifier destination, EnviroVolumetricCloudRenderer renderer, EnviroQuality quality)
		{
			int downsampling = settingsQuality.downsampling;
			if (quality != null)
			{
				downsampling = quality.volumetricCloudsOverride.downsampling;
			}
			int width = renderingData.cameraData.camera.pixelWidth / downsampling;
			int height = renderingData.cameraData.camera.pixelHeight / downsampling;
			if (renderingData.cameraData.camera.cameraType != CameraType.Reflection)
			{
				if (renderer.fullBuffer == null || renderer.fullBuffer.Length != 2)
				{
					renderer.fullBuffer = new RenderTexture[2];
				}
				renderer.fullBufferIndex = (renderer.fullBufferIndex + 1) % 2;
				renderer.firstFrame |= CreateRenderTexture(ref renderer.fullBuffer[0], width, height, RenderTextureFormat.ARGBHalf, FilterMode.Bilinear, source.descriptor);
				renderer.firstFrame |= CreateRenderTexture(ref renderer.fullBuffer[1], width, height, RenderTextureFormat.ARGBHalf, FilterMode.Bilinear, source.descriptor);
			}
			renderer.firstFrame |= CreateRenderTexture(ref renderer.undersampleBuffer, width, height, RenderTextureFormat.ARGBHalf, FilterMode.Bilinear, source.descriptor);
			renderer.frame++;
			if (renderer.frame > 64)
			{
				renderer.frame = 0;
			}
			if (renderer.depthMat == null)
			{
				renderer.depthMat = new Material(Shader.Find("Hidden/EnviroVolumetricCloudsDepth"));
			}
			renderer.depthMat.SetVector("_CameraDepthTexture_TexelSize", new Vector4(1 / renderingData.cameraData.cameraTargetDescriptor.width, 1 / renderingData.cameraData.cameraTargetDescriptor.height, renderingData.cameraData.cameraTargetDescriptor.width, renderingData.cameraData.cameraTargetDescriptor.height));
			SetToURP(renderer.depthMat);
			CreateRenderTexture(ref renderer.downsampledDepth, width, height, RenderTextureFormat.RFloat, FilterMode.Point, source.descriptor);
			if (downsampling > 1)
			{
				pass.CustomBlit(cmd, renderingData.cameraData.camera.cameraToWorldMatrix, source, renderer.downsampledDepth, renderer.depthMat, 0);
			}
			else
			{
				pass.CustomBlit(cmd, renderingData.cameraData.camera.cameraToWorldMatrix, source, renderer.downsampledDepth, renderer.depthMat, 1);
			}
			SetRaymarchShader(renderingData.cameraData.camera, renderer, quality);
			SetToURP(renderer.raymarchMat);
			pass.CustomBlit(cmd, renderingData.cameraData.camera.cameraToWorldMatrix, source, renderer.undersampleBuffer, renderer.raymarchMat);
			if (renderingData.cameraData.camera.cameraType != CameraType.Reflection)
			{
				if (renderer.reprojectMat == null)
				{
					renderer.reprojectMat = new Material(Shader.Find("Hidden/EnviroVolumetricCloudsReproject"));
				}
				SetReprojectShader(renderingData.cameraData.camera, renderer, quality);
				SetToURP(renderer.reprojectMat);
				if (renderer.firstFrame)
				{
					pass.CustomBlit(cmd, renderingData.cameraData.camera.cameraToWorldMatrix, renderer.undersampleBuffer, renderer.fullBuffer[renderer.fullBufferIndex]);
				}
				pass.CustomBlit(cmd, renderingData.cameraData.camera.cameraToWorldMatrix, renderer.fullBuffer[renderer.fullBufferIndex], renderer.fullBuffer[renderer.fullBufferIndex ^ 1], renderer.reprojectMat);
			}
			if (renderer.blendAndLightingMat == null)
			{
				renderer.blendAndLightingMat = new Material(Shader.Find("Hidden/EnviroVolumetricCloudsBlend"));
			}
			SetBlendShader(renderingData.cameraData.camera, renderer);
			SetToURP(renderer.blendAndLightingMat);
			pass.CustomBlit(cmd, renderingData.cameraData.camera.cameraToWorldMatrix, source, destination, renderer.blendAndLightingMat);
			renderer.prevV = renderingData.cameraData.camera.worldToCameraMatrix;
			renderer.firstFrame = false;
		}

		private void SetRaymarchShader(Camera cam, EnviroVolumetricCloudRenderer renderer, EnviroQuality quality)
		{
			if (renderer.raymarchMat == null)
			{
				if (GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode)
				{
					renderer.raymarchMat = new Material(Shader.Find("Hidden/EnviroCloudsRaymarch"));
				}
				else
				{
					renderer.raymarchMat = new Material(Shader.Find("Hidden/EnviroCloudsRaymarchURP"));
				}
			}
			if (dirLight == null)
			{
				dirLight = EnviroHelper.GetDirectionalLight();
			}
			else if (EnviroManager.instance.Lighting != null && EnviroManager.instance.Lighting.Settings.lightingMode == EnviroLighting.LightingMode.Dual)
			{
				dirLight = EnviroHelper.GetDirectionalLight();
			}
			EnviroCloudLayerSettings enviroCloudLayerSettings = settingsLayer1;
			EnviroCloudLayerSettings enviroCloudLayerSettings2 = settingsLayer2;
			_ = settingsGlobal;
			float blueNoiseIntensity = settingsQuality.blueNoiseIntensity;
			float lodDistance = settingsQuality.lodDistance;
			Vector4 value = new Vector4(settingsQuality.stepsLayer1, settingsQuality.stepsLayer1, settingsQuality.stepsLayer2, settingsQuality.stepsLayer2);
			_ = settingsQuality.downsampling;
			if (quality != null)
			{
				blueNoiseIntensity = quality.volumetricCloudsOverride.blueNoiseIntensity;
				value = new Vector4(quality.volumetricCloudsOverride.stepsLayer1, quality.volumetricCloudsOverride.stepsLayer1, quality.volumetricCloudsOverride.stepsLayer2, quality.volumetricCloudsOverride.stepsLayer2);
				lodDistance = quality.volumetricCloudsOverride.lodDistance;
				_ = quality.volumetricCloudsOverride.downsampling;
			}
			renderer.raymarchMat.SetTexture("_Noise", settingsGlobal.noise);
			renderer.raymarchMat.SetTexture("_DetailNoise", settingsGlobal.detailNoise);
			renderer.raymarchMat.SetTexture("_CurlNoise", settingsGlobal.curlTex);
			if (weatherMap != null)
			{
				renderer.raymarchMat.SetTexture("_WeatherMap", weatherMap);
			}
			else if (settingsGlobal.customWeatherMap != null)
			{
				renderer.raymarchMat.SetTexture("_WeatherMap", settingsGlobal.customWeatherMap);
			}
			if (XRSettings.enabled && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced && cam.stereoEnabled)
			{
				renderer.raymarchMat.SetMatrix("_InverseProjection", cam.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left).inverse);
				renderer.raymarchMat.SetMatrix("_InverseRotation", cam.GetStereoViewMatrix(Camera.StereoscopicEye.Left).inverse);
				renderer.raymarchMat.SetMatrix("_InverseProjectionRight", cam.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right).inverse);
				renderer.raymarchMat.SetMatrix("_InverseRotationRight", cam.GetStereoViewMatrix(Camera.StereoscopicEye.Right).inverse);
			}
			else
			{
				renderer.raymarchMat.SetMatrix("_InverseProjection", cam.projectionMatrix.inverse);
				renderer.raymarchMat.SetMatrix("_InverseRotation", cam.cameraToWorldMatrix);
			}
			if (EnviroManager.instance.Objects.worldAnchor != null)
			{
				settingsGlobal.floatingPointOriginMod = EnviroManager.instance.Objects.worldAnchor.transform.position;
			}
			else
			{
				settingsGlobal.floatingPointOriginMod = Vector3.zero;
			}
			renderer.raymarchMat.SetVector("_CameraPosition", cam.transform.position - settingsGlobal.floatingPointOriginMod);
			renderer.raymarchMat.SetVector("_WorldOffset", settingsGlobal.floatingPointOriginMod);
			renderer.raymarchMat.SetVector("_Steps", value);
			if (dirLight != null)
			{
				renderer.raymarchMat.SetVector("_LightDir", -dirLight.transform.forward);
			}
			else
			{
				renderer.raymarchMat.SetVector("_LightDir", Vector3.zero);
			}
			renderer.raymarchMat.SetVector("_CloudsNoiseSettings", new Vector4(enviroCloudLayerSettings.baseNoiseUV, enviroCloudLayerSettings.detailNoiseUV, enviroCloudLayerSettings2.baseNoiseUV, enviroCloudLayerSettings2.detailNoiseUV));
			renderer.raymarchMat.SetVector("_CloudsLighting", new Vector4(enviroCloudLayerSettings.scatteringIntensity, 0f, 0f, enviroCloudLayerSettings.silverLiningSpread));
			renderer.raymarchMat.SetVector("_CloudsLighting2", new Vector4(enviroCloudLayerSettings2.scatteringIntensity, 0f, 0f, enviroCloudLayerSettings2.silverLiningSpread));
			renderer.raymarchMat.SetVector("_CloudsLightingExtended", new Vector4(enviroCloudLayerSettings.powderIntensity, enviroCloudLayerSettings.curlIntensity, enviroCloudLayerSettings.lightStepModifier, enviroCloudLayerSettings.lightAbsorbtion));
			renderer.raymarchMat.SetVector("_CloudsLightingExtended2", new Vector4(enviroCloudLayerSettings2.powderIntensity, enviroCloudLayerSettings2.curlIntensity, enviroCloudLayerSettings2.lightStepModifier, enviroCloudLayerSettings2.lightAbsorbtion));
			renderer.raymarchMat.SetVector("_CloudsMultiScattering", new Vector4(enviroCloudLayerSettings.multiScatteringA, enviroCloudLayerSettings.multiScatteringB, enviroCloudLayerSettings.multiScatteringC, 0f));
			renderer.raymarchMat.SetVector("_CloudsMultiScattering2", new Vector4(enviroCloudLayerSettings2.multiScatteringA, enviroCloudLayerSettings2.multiScatteringB, enviroCloudLayerSettings2.multiScatteringC, 0f));
			renderer.raymarchMat.SetVector("_CloudsParameter", new Vector4(enviroCloudLayerSettings.bottomCloudsHeight, enviroCloudLayerSettings.topCloudsHeight, 1f / (enviroCloudLayerSettings.topCloudsHeight - enviroCloudLayerSettings.bottomCloudsHeight), settingsGlobal.cloudsWorldScale));
			renderer.raymarchMat.SetVector("_CloudsParameter2", new Vector4(enviroCloudLayerSettings2.bottomCloudsHeight, enviroCloudLayerSettings2.topCloudsHeight, 1f / (enviroCloudLayerSettings2.topCloudsHeight - enviroCloudLayerSettings2.bottomCloudsHeight), settingsGlobal.cloudsWorldScale));
			renderer.raymarchMat.SetFloat("_BlueNoiseIntensity", blueNoiseIntensity);
			renderer.raymarchMat.SetVector("_CloudDensityScale", new Vector4(enviroCloudLayerSettings.density, enviroCloudLayerSettings2.density, enviroCloudLayerSettings.densitySmoothness, enviroCloudLayerSettings2.densitySmoothness));
			renderer.raymarchMat.SetVector("_CloudsCoverageSettings", new Vector4(enviroCloudLayerSettings.coverage, settingsGlobal.maxRenderDistance, enviroCloudLayerSettings.anvilBias, enviroCloudLayerSettings2.anvilBias));
			renderer.raymarchMat.SetVector("_CloudsAnimation", new Vector4(cloudAnimLayer1.x, cloudAnimLayer1.y, cloudAnimLayer1.z, 0f));
			if (EnviroManager.instance.Environment != null)
			{
				renderer.raymarchMat.SetVector("_CloudsWindDirection", new Vector4(EnviroManager.instance.Environment.Settings.windDirectionX * settingsLayer1.cloudsWindDirectionXModifier, EnviroManager.instance.Environment.Settings.windDirectionY * settingsLayer1.cloudsWindDirectionYModifier, cloudAnimNonScaledLayer1.x, cloudAnimNonScaledLayer1.y));
			}
			else
			{
				renderer.raymarchMat.SetVector("_CloudsWindDirection", new Vector4(settingsLayer1.cloudsWindDirectionXModifier, settingsLayer1.cloudsWindDirectionYModifier, cloudAnimNonScaledLayer1.x, cloudAnimNonScaledLayer1.y));
			}
			renderer.raymarchMat.SetVector("_CloudsErosionIntensity", new Vector4(1f - enviroCloudLayerSettings.baseErosionIntensity, enviroCloudLayerSettings.detailErosionIntensity, 1f - enviroCloudLayerSettings2.baseErosionIntensity, enviroCloudLayerSettings2.detailErosionIntensity));
			renderer.raymarchMat.SetFloat("_LODDistance", lodDistance);
			if (GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode)
			{
				renderer.raymarchMat.SetTexture("_DownsampledDepth", renderer.downsampledDepth);
			}
			renderer.raymarchMat.SetInt("_Frame", renderer.frame);
			renderer.raymarchMat.SetTexture("_BlueNoise", settingsGlobal.blueNoise);
			renderer.raymarchMat.SetVector("_Randomness", new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value));
			renderer.raymarchMat.SetVector("_Resolution", new Vector4(cam.pixelWidth, cam.pixelHeight, 0f, 0f));
			if (settingsGlobal.dualLayer)
			{
				renderer.raymarchMat.EnableKeyword("ENVIRO_DUAL_LAYER");
			}
			else
			{
				renderer.raymarchMat.DisableKeyword("ENVIRO_DUAL_LAYER");
			}
			if (settingsGlobal.cloudShadows)
			{
				renderer.raymarchMat.EnableKeyword("ENVIRO_CLOUD_SHADOWS");
			}
			else
			{
				renderer.raymarchMat.DisableKeyword("ENVIRO_CLOUD_SHADOWS");
			}
			renderer.raymarchMat.SetFloat("_DepthTest", settingsGlobal.depthTest ? 1f : 0f);
			SetDepthBlending(renderer.raymarchMat);
		}

		private void SetReprojectShader(Camera cam, EnviroVolumetricCloudRenderer renderer, EnviroQuality quality)
		{
			float reprojectionBlendTime = settingsQuality.reprojectionBlendTime;
			if (quality != null)
			{
				reprojectionBlendTime = quality.volumetricCloudsOverride.reprojectionBlendTime;
			}
			SetDepthBlending(renderer.reprojectMat);
			if (GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode)
			{
				renderer.reprojectMat.SetTexture("_DownsampledDepth", renderer.downsampledDepth);
				renderer.reprojectMat.SetTexture("_UndersampleCloudTex", renderer.undersampleBuffer);
			}
			if (XRSettings.enabled && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced)
			{
				renderer.reprojectMat.SetMatrix("_PrevVP", renderer.prevV);
				renderer.reprojectMat.SetVector("_ProjectionExtents", EnviroHelper.GetProjectionExtents(cam, Camera.StereoscopicEye.Left));
				renderer.reprojectMat.SetVector("_ProjectionExtentsRight", EnviroHelper.GetProjectionExtents(cam, Camera.StereoscopicEye.Right));
			}
			else
			{
				renderer.reprojectMat.SetMatrix("_PrevVP", renderer.prevV);
				renderer.reprojectMat.SetVector("_ProjectionExtents", EnviroHelper.GetProjectionExtents(cam));
			}
			if (lastOffset != settingsGlobal.floatingPointOriginMod)
			{
				Matrix4x4 value = Matrix4x4.TRS(cam.transform.position - (settingsGlobal.floatingPointOriginMod - lastOffset), cam.transform.rotation, Vector3.one);
				renderer.reprojectMat.SetMatrix("_CamToWorld", value);
				lastOffset = settingsGlobal.floatingPointOriginMod;
			}
			else
			{
				Matrix4x4 value = Matrix4x4.TRS(cam.transform.position, cam.transform.rotation, Vector3.one);
				renderer.reprojectMat.SetMatrix("_CamToWorld", value);
			}
			renderer.reprojectMat.SetFloat("_BlendTime", reprojectionBlendTime);
		}

		private void SetBlendShader(Camera cam, EnviroVolumetricCloudRenderer renderer)
		{
			SetDepthBlending(renderer.blendAndLightingMat);
			if (XRSettings.enabled && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced)
			{
				renderer.blendAndLightingMat.SetVector("_ProjectionExtents", EnviroHelper.GetProjectionExtents(cam, Camera.StereoscopicEye.Left));
				renderer.blendAndLightingMat.SetVector("_ProjectionExtentsRight", EnviroHelper.GetProjectionExtents(cam, Camera.StereoscopicEye.Right));
			}
			else
			{
				renderer.blendAndLightingMat.SetVector("_ProjectionExtents", EnviroHelper.GetProjectionExtents(cam));
			}
			if (GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode)
			{
				renderer.blendAndLightingMat.SetTexture("_DownsampledDepth", renderer.downsampledDepth);
			}
			Matrix4x4 value = Matrix4x4.TRS(cam.transform.position, cam.transform.rotation, Vector3.one);
			renderer.blendAndLightingMat.SetMatrix("_CamToWorld", value);
			Color value2 = (EnviroManager.instance.isNight ? settingsGlobal.moonLightColorGradient.Evaluate(EnviroManager.instance.lunarTime) : settingsGlobal.sunLightColorGradient.Evaluate(EnviroManager.instance.solarTime));
			Shader.SetGlobalColor("_DirectLightColor", value2);
			Shader.SetGlobalColor("_AmbientColor", settingsGlobal.ambientColorGradient.Evaluate(EnviroManager.instance.solarTime) * settingsGlobal.ambientLighIntensity);
			Shader.SetGlobalFloat("_AtmosphereColorSaturateDistance", settingsGlobal.atmosphereColorSaturateDistance);
			if (GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode)
			{
				if (cam.cameraType == CameraType.Reflection)
				{
					renderer.blendAndLightingMat.SetTexture("_CloudTex", renderer.undersampleBuffer);
				}
				else
				{
					renderer.blendAndLightingMat.SetTexture("_CloudTex", renderer.fullBuffer[renderer.fullBufferIndex ^ 1]);
				}
			}
			if (renderer.camera != null && renderer.camera.transform.position.y - settingsGlobal.floatingPointOriginMod.y <= settingsLayer1.bottomCloudsHeight)
			{
				if (cam.stereoEnabled)
				{
					if (blackArray == null)
					{
						CreateBlackArray();
					}
					Shader.SetGlobalTexture("_EnviroClouds", blackArray);
				}
				else
				{
					Shader.SetGlobalTexture("_EnviroClouds", Texture2D.blackTexture);
				}
			}
			else if (renderer != null && renderer.fullBufferRTHandles != null && renderer.fullBufferRTHandles.Length >= 2 && renderer.fullBufferRTHandles[renderer.fullBufferIndex ^ 1] != null)
			{
				Shader.SetGlobalTexture("_EnviroClouds", renderer.fullBufferRTHandles[renderer.fullBufferIndex ^ 1]);
			}
		}

		private void SetDepthBlending(Material mat)
		{
			if (settingsGlobal.depthBlending)
			{
				mat.EnableKeyword("ENVIRO_DEPTH_BLENDING");
			}
			else
			{
				mat.DisableKeyword("ENVIRO_DEPTH_BLENDING");
			}
		}

		private void SetToURP(Material mat)
		{
			mat.EnableKeyword("ENVIROURP");
		}

		public bool CreateRenderTexture(ref TextureHandle texture, RenderGraph renderGraph, int width, int height, GraphicsFormat format, FilterMode filterMode, TextureDesc dsc)
		{
			dsc.width = width;
			dsc.height = height;
			dsc.colorFormat = format;
			dsc.depthBufferBits = DepthBits.None;
			dsc.msaaSamples = MSAASamples.None;
			dsc.filterMode = filterMode;
			texture = renderGraph.CreateTexture(in dsc);
			if (cloudsDescriptor.width != dsc.width || cloudsDescriptor.height != dsc.height || cloudsDescriptor.vrUsage != dsc.vrUsage)
			{
				cloudsDescriptor = dsc;
				return true;
			}
			cloudsDescriptor = dsc;
			return false;
		}

		public bool CreateRenderTexture(ref RenderTexture texture, int width, int height, RenderTextureFormat format, FilterMode filterMode, RenderTextureDescriptor dsc)
		{
			if (texture != null && (texture.width != width || texture.height != height || texture.vrUsage != dsc.vrUsage))
			{
				UnityEngine.Object.DestroyImmediate(texture);
				texture = null;
			}
			if (texture == null)
			{
				RenderTextureDescriptor desc = dsc;
				desc.width = width;
				desc.height = height;
				desc.colorFormat = format;
				desc.depthBufferBits = 0;
				texture = new RenderTexture(desc);
				texture.antiAliasing = 1;
				texture.useMipMap = false;
				texture.filterMode = filterMode;
				texture.Create();
				return true;
			}
			return false;
		}

		public RenderTexture RenderWeatherMap()
		{
			if (settingsGlobal.customWeatherMap != null)
			{
				return null;
			}
			if (weatherMapMat == null)
			{
				weatherMapMat = new Material(Shader.Find("Enviro3/Standard/WeatherTexture"));
			}
			if (weatherMap == null)
			{
				RenderTextureFormat format = RenderTextureFormat.ARGBFloat;
				weatherMap = new RenderTexture(512, 512, 0, format);
				weatherMap.wrapMode = TextureWrapMode.Repeat;
			}
			weatherMapMat.SetFloat("_CoverageLayer1", settingsLayer1.coverage);
			weatherMapMat.SetFloat("_WorleyFreq1Layer1", settingsLayer1.worleyFreq1);
			weatherMapMat.SetFloat("_WorleyFreq2Layer1", settingsLayer1.worleyFreq2);
			weatherMapMat.SetFloat("_DilateCoverageLayer1", settingsLayer1.dilateCoverage);
			weatherMapMat.SetFloat("_DilateTypeLayer1", settingsLayer1.dilateType);
			weatherMapMat.SetFloat("_CloudsTypeModifierLayer1", settingsLayer1.cloudsTypeModifier);
			if (settingsGlobal.dualLayer)
			{
				weatherMapMat.EnableKeyword("ENVIRO_DUAL_LAYER");
				weatherMapMat.SetFloat("_CoverageLayer2", settingsLayer2.coverage);
				weatherMapMat.SetFloat("_WorleyFreq1Layer2", settingsLayer2.worleyFreq1);
				weatherMapMat.SetFloat("_WorleyFreq2Layer2", settingsLayer2.worleyFreq2);
				weatherMapMat.SetFloat("_DilateCoverageLayer2", settingsLayer2.dilateCoverage);
				weatherMapMat.SetFloat("_DilateTypeLayer2", settingsLayer2.dilateType);
				weatherMapMat.SetFloat("_CloudsTypeModifierLayer2", settingsLayer2.cloudsTypeModifier);
			}
			else
			{
				weatherMapMat.DisableKeyword("ENVIRO_DUAL_LAYER");
			}
			weatherMapMat.SetVector("_LocationOffset", new Vector4(settingsLayer1.locationOffset.x, settingsLayer1.locationOffset.y, settingsLayer2.locationOffset.x, settingsLayer2.locationOffset.y));
			weatherMapMat.SetVector("_WindDirectionLayer1", cloudAnimNonScaledLayer1);
			weatherMapMat.SetVector("_WindDirectionLayer2", cloudAnimNonScaledLayer2);
			Graphics.Blit(null, weatherMap, weatherMapMat);
			return weatherMap;
		}

		private void UpdateWind()
		{
			if (EnviroManager.instance.Environment != null)
			{
				cloudAnimLayer1 += new Vector3(EnviroManager.instance.Environment.Settings.windSpeed * settingsLayer1.windSpeedModifier * EnviroManager.instance.Environment.Settings.windDirectionX * settingsLayer1.cloudsWindDirectionXModifier * Time.deltaTime, EnviroManager.instance.Environment.Settings.windSpeed * settingsLayer1.windSpeedModifier * EnviroManager.instance.Environment.Settings.windDirectionY * settingsLayer1.cloudsWindDirectionYModifier * Time.deltaTime, -1f * settingsLayer1.windUpwards * Time.deltaTime);
				cloudAnimLayer1 = EnviroHelper.PingPong(cloudAnimLayer1);
				if (settingsGlobal.dualLayer)
				{
					cloudAnimLayer2 += new Vector3(EnviroManager.instance.Environment.Settings.windSpeed * settingsLayer2.windSpeedModifier * EnviroManager.instance.Environment.Settings.windDirectionX * settingsLayer2.cloudsWindDirectionXModifier * Time.deltaTime, EnviroManager.instance.Environment.Settings.windSpeed * settingsLayer2.windSpeedModifier * EnviroManager.instance.Environment.Settings.windDirectionY * settingsLayer2.cloudsWindDirectionYModifier * Time.deltaTime, -1f * settingsLayer2.windUpwards * Time.deltaTime);
					cloudAnimLayer2 = EnviroHelper.PingPong(cloudAnimLayer2);
				}
				cloudAnimNonScaledLayer1 += new Vector3(settingsLayer1.windSpeedModifier * EnviroManager.instance.Environment.Settings.windSpeed * EnviroManager.instance.Environment.Settings.windDirectionX * settingsLayer1.cloudsWindDirectionXModifier * Time.deltaTime * 4f, settingsLayer1.windSpeedModifier * EnviroManager.instance.Environment.Settings.windSpeed * EnviroManager.instance.Environment.Settings.windDirectionY * settingsLayer1.cloudsWindDirectionYModifier * Time.deltaTime * 4f, -1f * EnviroManager.instance.Environment.Settings.windSpeed * Time.deltaTime) * settingsGlobal.cloudsTravelSpeed * 0.2f;
				cloudAnimNonScaledLayer2 += new Vector3(settingsLayer2.windSpeedModifier * EnviroManager.instance.Environment.Settings.windSpeed * EnviroManager.instance.Environment.Settings.windDirectionX * settingsLayer2.cloudsWindDirectionXModifier * Time.deltaTime * 4f, settingsLayer2.windSpeedModifier * EnviroManager.instance.Environment.Settings.windSpeed * EnviroManager.instance.Environment.Settings.windDirectionY * settingsLayer2.cloudsWindDirectionYModifier * Time.deltaTime * 4f, -1f * EnviroManager.instance.Environment.Settings.windSpeed * Time.deltaTime) * settingsGlobal.cloudsTravelSpeed * 0.2f;
			}
			else
			{
				cloudAnimLayer1 += new Vector3(settingsLayer1.windSpeedModifier * settingsLayer1.cloudsWindDirectionXModifier * Time.deltaTime, settingsLayer1.windSpeedModifier * settingsLayer1.cloudsWindDirectionYModifier * Time.deltaTime, -1f * settingsLayer1.windUpwards * Time.deltaTime);
				cloudAnimLayer1 = EnviroHelper.PingPong(cloudAnimLayer1);
				if (settingsGlobal.dualLayer)
				{
					cloudAnimLayer2 += new Vector3(settingsLayer2.windSpeedModifier * settingsLayer2.cloudsWindDirectionXModifier * Time.deltaTime, settingsLayer2.windSpeedModifier * settingsLayer2.cloudsWindDirectionYModifier * Time.deltaTime, -1f * settingsLayer2.windUpwards * Time.deltaTime);
					cloudAnimLayer2 = EnviroHelper.PingPong(cloudAnimLayer2);
				}
				cloudAnimNonScaledLayer1 += new Vector3(settingsLayer1.windSpeedModifier * settingsLayer1.cloudsWindDirectionXModifier * Time.deltaTime * 4f, settingsLayer1.windSpeedModifier * settingsLayer1.cloudsWindDirectionYModifier * Time.deltaTime * 4f, -1f * settingsLayer1.windUpwards * Time.deltaTime) * settingsGlobal.cloudsTravelSpeed * 0.2f;
				cloudAnimNonScaledLayer2 += new Vector3(settingsLayer2.windSpeedModifier * settingsLayer2.cloudsWindDirectionXModifier * Time.deltaTime * 4f, settingsLayer2.windSpeedModifier * settingsLayer2.cloudsWindDirectionYModifier * Time.deltaTime * 4f, -1f * settingsLayer2.windUpwards * Time.deltaTime) * settingsGlobal.cloudsTravelSpeed * 0.2f;
			}
		}

		public void LoadModuleValues()
		{
			if (preset != null)
			{
				settingsLayer1 = JsonUtility.FromJson<EnviroCloudLayerSettings>(JsonUtility.ToJson(preset.settingsLayer1));
				settingsLayer2 = JsonUtility.FromJson<EnviroCloudLayerSettings>(JsonUtility.ToJson(preset.settingsLayer2));
				settingsGlobal = JsonUtility.FromJson<EnviroCloudGlobalSettings>(JsonUtility.ToJson(preset.settingsGlobal));
			}
			else
			{
				Debug.Log("Please assign a saved module to load from!");
			}
		}

		public void SaveModuleValues()
		{
		}

		public void SaveModuleValues(EnviroVolumetricCloudsModule module)
		{
			module.settingsLayer1 = JsonUtility.FromJson<EnviroCloudLayerSettings>(JsonUtility.ToJson(settingsLayer1));
			module.settingsLayer2 = JsonUtility.FromJson<EnviroCloudLayerSettings>(JsonUtility.ToJson(settingsLayer2));
			module.settingsGlobal = JsonUtility.FromJson<EnviroCloudGlobalSettings>(JsonUtility.ToJson(settingsGlobal));
		}
	}
}
