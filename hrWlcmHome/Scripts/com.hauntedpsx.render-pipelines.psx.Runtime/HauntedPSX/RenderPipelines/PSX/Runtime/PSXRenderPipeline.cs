using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	public class PSXRenderPipeline : RenderPipeline
	{
		public enum MixedLightingSetup
		{
			None = 0,
			ShadowMask = 1,
			Subtractive = 2
		}

		private readonly PSXRenderPipelineAsset m_Asset;

		internal const PerObjectData k_RendererConfigurationBakedLighting = PerObjectData.LightProbe | PerObjectData.LightProbeProxyVolume | PerObjectData.Lightmaps;

		internal const PerObjectData k_RendererConfigurationBakedLightingWithShadowMask = PerObjectData.LightProbe | PerObjectData.LightProbeProxyVolume | PerObjectData.Lightmaps | PerObjectData.OcclusionProbe | PerObjectData.OcclusionProbeProxyVolume | PerObjectData.ShadowMask;

		internal const PerObjectData k_RendererConfigurationDynamicLighting = PerObjectData.LightData | PerObjectData.LightIndices;

		private Material skyMaterial;

		private Material accumulationMotionBlurMaterial;

		private Material copyColorRespectFlipYMaterial;

		private Material crtMaterial;

		private int[] compressionCSKernels;

		private int frameCount;

		public static PSXRenderPipeline instance = null;

		private static Mesh s_FullscreenMesh = null;

		private static Cubemap s_whiteCubemap = null;

		private Vector4 k_DefaultLightPosition = new Vector4(0f, 0f, 1f, 0f);

		private Vector4 k_DefaultLightColor = Color.black;

		private Vector4 k_DefaultLightAttenuation = new Vector4(0f, 1f, 0f, 1f);

		private Vector4 k_DefaultLightSpotDirection = new Vector4(0f, 0f, 1f, 0f);

		private Vector4 k_DefaultLightsProbeChannel = new Vector4(-1f, 1f, 0f, 0f);

		private Vector4[] m_AdditionalLightPositions;

		private Vector4[] m_AdditionalLightColors;

		private Vector4[] m_AdditionalLightAttenuations;

		private Vector4[] m_AdditionalLightSpotDirections;

		private Vector4[] m_AdditionalLightOcclusionProbeChannels;

		private MixedLightingSetup m_MixedLightingSetup;

		private static Lightmapping.RequestLightsDelegate lightsDelegate = delegate(Light[] requests, NativeArray<LightDataGI> lightsOutput)
		{
			LightDataGI value = default(LightDataGI);
			for (int i = 0; i < requests.Length; i++)
			{
				Light light = requests[i];
				value.InitNoBake(light.GetInstanceID());
				lightsOutput[i] = value;
			}
			Debug.LogWarning("Realtime GI is not supported in HPSXRP.");
		};

		public PSXRenderPipelineAsset asset => m_Asset;

		private static Mesh fullscreenMesh
		{
			get
			{
				if (s_FullscreenMesh != null)
				{
					return s_FullscreenMesh;
				}
				float y = 0f;
				float y2 = 1f;
				s_FullscreenMesh = new Mesh
				{
					name = "Fullscreen Quad"
				};
				s_FullscreenMesh.SetVertices(new List<Vector3>
				{
					new Vector3(-1f, -1f, 0f),
					new Vector3(-1f, 1f, 0f),
					new Vector3(1f, -1f, 0f),
					new Vector3(1f, 1f, 0f)
				});
				s_FullscreenMesh.SetUVs(0, new List<Vector2>
				{
					new Vector2(0f, y2),
					new Vector2(0f, y),
					new Vector2(1f, y2),
					new Vector2(1f, y)
				});
				s_FullscreenMesh.SetIndices(new int[6] { 0, 1, 2, 2, 1, 3 }, MeshTopology.Triangles, 0, calculateBounds: false);
				s_FullscreenMesh.UploadMeshData(markNoLongerReadable: true);
				return s_FullscreenMesh;
			}
		}

		private static Cubemap whiteCubemap
		{
			get
			{
				if (s_whiteCubemap != null)
				{
					return s_whiteCubemap;
				}
				s_whiteCubemap = new Cubemap(1, GraphicsFormat.R8G8B8A8_UNorm, TextureCreationFlags.None);
				s_whiteCubemap.SetPixel(CubemapFace.NegativeX, 0, 0, Color.white);
				s_whiteCubemap.SetPixel(CubemapFace.NegativeY, 0, 0, Color.white);
				s_whiteCubemap.SetPixel(CubemapFace.NegativeZ, 0, 0, Color.white);
				s_whiteCubemap.SetPixel(CubemapFace.PositiveX, 0, 0, Color.white);
				s_whiteCubemap.SetPixel(CubemapFace.PositiveY, 0, 0, Color.white);
				s_whiteCubemap.SetPixel(CubemapFace.PositiveZ, 0, 0, Color.white);
				s_whiteCubemap.Apply(updateMipmaps: false, makeNoLongerReadable: true);
				return s_whiteCubemap;
			}
		}

		internal PSXRenderPipeline(PSXRenderPipelineAsset asset)
		{
			instance = this;
			m_Asset = asset;
			if (!VolumeManager.instance.isInitialized)
			{
				VolumeManager.instance.Initialize();
			}
			Build();
			Allocate();
		}

		protected internal void Build()
		{
			ConfigureGlobalRenderPipelineTag();
			ConfigureSRPBatcherFromAsset(m_Asset);
		}

		private static void ConfigureGlobalRenderPipelineTag()
		{
			Shader.globalRenderPipeline = PSXStringConstants.s_GlobalRenderPipelineStr;
		}

		private static void ConfigureSRPBatcherFromAsset(PSXRenderPipelineAsset asset)
		{
			GraphicsSettings.useScriptableRenderPipelineBatching = false;
		}

		private void FindComputeKernels()
		{
			if (IsComputeShaderSupportedPlatform())
			{
				compressionCSKernels = FindCompressionKernels(m_Asset);
			}
		}

		protected internal void Allocate()
		{
			skyMaterial = CoreUtils.CreateEngineMaterial(m_Asset.renderPipelineResources.shaders.skyPS);
			accumulationMotionBlurMaterial = CoreUtils.CreateEngineMaterial(m_Asset.renderPipelineResources.shaders.accumulationMotionBlurPS);
			copyColorRespectFlipYMaterial = CoreUtils.CreateEngineMaterial(m_Asset.renderPipelineResources.shaders.copyColorRespectFlipYPS);
			crtMaterial = CoreUtils.CreateEngineMaterial(m_Asset.renderPipelineResources.shaders.crtPS);
			FindComputeKernels();
			AllocateLighting();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			PSXCamera.ClearAll();
			CoreUtils.Destroy(skyMaterial);
			CoreUtils.Destroy(accumulationMotionBlurMaterial);
			CoreUtils.Destroy(copyColorRespectFlipYMaterial);
			CoreUtils.Destroy(crtMaterial);
			compressionCSKernels = null;
			DisposeLighting();
		}

		private void PushCameraParameters(Camera camera, PSXCamera psxCamera, CommandBuffer cmd, out int rasterizationWidth, out int rasterizationHeight, out Vector4 cameraAspectModeUVScaleBias, bool isPSXQualityEnabled)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushCameraParameters))
			{
				CameraVolume cameraVolume = VolumeManager.instance.stack.GetComponent<CameraVolume>();
				if (!cameraVolume)
				{
					cameraVolume = CameraVolume.@default;
				}
				if (isPSXQualityEnabled && cameraVolume.isFrameLimitEnabled.value)
				{
					QualitySettings.vSyncCount = 0;
					Application.targetFrameRate = cameraVolume.frameLimit.value;
				}
				else
				{
					QualitySettings.vSyncCount = 1;
					Application.targetFrameRate = -1;
				}
				camera.ResetAspect();
				rasterizationWidth = camera.pixelWidth;
				rasterizationHeight = camera.pixelHeight;
				cameraAspectModeUVScaleBias = new Vector4(1f, 1f, 0f, 0f);
				if (isPSXQualityEnabled && cameraVolume.aspectMode.value != CameraVolume.CameraAspectMode.Native)
				{
					rasterizationWidth = Mathf.Min(rasterizationWidth, cameraVolume.targetRasterizationResolutionWidth.value);
					rasterizationHeight = Mathf.Min(rasterizationHeight, cameraVolume.targetRasterizationResolutionHeight.value);
					if (!IsMainGameView(camera) || cameraVolume.aspectMode.value == CameraVolume.CameraAspectMode.FreeStretch || cameraVolume.aspectMode.value == CameraVolume.CameraAspectMode.FreeFitPixelPerfect || cameraVolume.aspectMode.value == CameraVolume.CameraAspectMode.FreeCropPixelPerfect || cameraVolume.aspectMode.value == CameraVolume.CameraAspectMode.FreeBleedPixelPerfect)
					{
						if (camera.pixelWidth >= camera.pixelHeight)
						{
							rasterizationWidth = Mathf.FloorToInt((float)rasterizationHeight * (float)camera.pixelWidth / (float)camera.pixelHeight + 0.5f);
						}
						else
						{
							rasterizationHeight = Mathf.FloorToInt((float)rasterizationHeight * (float)camera.pixelHeight / (float)camera.pixelWidth + 0.5f);
						}
					}
					if (cameraVolume.aspectMode.value == CameraVolume.CameraAspectMode.FreeBleedPixelPerfect)
					{
						rasterizationWidth = camera.pixelWidth / Mathf.CeilToInt((float)camera.pixelWidth / (float)rasterizationWidth);
						rasterizationHeight = camera.pixelHeight / Mathf.CeilToInt((float)camera.pixelHeight / (float)rasterizationHeight);
					}
					if (cameraVolume.aspectMode.value == CameraVolume.CameraAspectMode.FreeFitPixelPerfect || cameraVolume.aspectMode.value == CameraVolume.CameraAspectMode.LockedFitPixelPerfect)
					{
						float num = (float)rasterizationWidth / (float)camera.pixelWidth;
						float num2 = (float)rasterizationHeight / (float)camera.pixelHeight;
						float num3 = Mathf.Max(num, num2);
						float num4 = 1f / (num * Mathf.Floor(1f / num3));
						float num5 = 1f / (num2 * Mathf.Floor(1f / num3));
						cameraAspectModeUVScaleBias = new Vector4(num4, num5, 0.5f - 0.5f * num4, 0.5f - 0.5f * num5);
					}
					else if (cameraVolume.aspectMode.value == CameraVolume.CameraAspectMode.FreeCropPixelPerfect)
					{
						float num6 = (float)rasterizationWidth / (float)camera.pixelWidth;
						float num7 = (float)rasterizationHeight / (float)camera.pixelHeight;
						float num8 = Mathf.Min(num6, num7);
						float num9 = 1f / (num6 * Mathf.Ceil(1f / num8));
						float num10 = 1f / (num7 * Mathf.Ceil(1f / num8));
						cameraAspectModeUVScaleBias = new Vector4(num9, num10, 0.5f - 0.5f * num9, 0.5f - 0.5f * num10);
					}
					else if (cameraVolume.aspectMode.value == CameraVolume.CameraAspectMode.LockedFit)
					{
						float num11 = (float)rasterizationWidth / (float)camera.pixelWidth;
						float num12 = (float)rasterizationHeight / (float)camera.pixelHeight;
						float num13 = Mathf.Max(num11, num12);
						float num14 = 1f / (num11 / num13);
						float num15 = 1f / (num12 / num13);
						cameraAspectModeUVScaleBias = new Vector4(num14, num15, 0.5f - 0.5f * num14, 0.5f - 0.5f * num15);
					}
					else
					{
						cameraAspectModeUVScaleBias = new Vector4(1f, 1f, 0f, 0f);
					}
					camera.aspect = (float)rasterizationWidth / (float)rasterizationHeight;
				}
				bool flag = false;
				bool flag2 = false;
				AccumulationMotionBlurVolume accumulationMotionBlurVolume = VolumeManager.instance.stack.GetComponent<AccumulationMotionBlurVolume>();
				if (!accumulationMotionBlurVolume)
				{
					accumulationMotionBlurVolume = AccumulationMotionBlurVolume.@default;
				}
				flag = accumulationMotionBlurVolume.weight.value > 1E-05f;
				flag2 = flag && !accumulationMotionBlurVolume.applyToUIOverlay.value;
				psxCamera.UpdateBeginFrame(new PSXCamera.PSXCameraUpdateContext
				{
					rasterizationWidth = rasterizationWidth,
					rasterizationHeight = rasterizationHeight,
					rasterizationHistoryRequested = flag,
					rasterizationPreUICopyRequested = flag2,
					rasterizationRandomWriteRequested = IsComputeShaderSupportedPlatform(),
					rasterizationDepthBufferRequested = EvaluateIsDepthBufferEnabledFromVolume()
				});
			}
		}

		protected override void Render(ScriptableRenderContext context, Camera[] cameras)
		{
			if (TryUpdateFrameCount(cameras))
			{
				PSXCamera.CleanUnused();
			}
			if (cameras.Length == 0)
			{
				return;
			}
			RenderPipeline.BeginFrameRendering(context, cameras);
			foreach (Camera camera in cameras)
			{
				if (camera == null)
				{
					continue;
				}
				RenderPipeline.BeginCameraRendering(context, camera);
				DrawSceneViewUI(camera);
				if (camera.TryGetCullingParameters(camera.stereoEnabled, out var cullingParameters))
				{
					VolumeManager.instance.Update(camera.transform, camera.cullingMask);
					bool flag = EvaluateIsPSXQualityEnabledFromVolume();
					flag &= CoreUtils.ArePostProcessesEnabled(camera);
					CommandBuffer commandBuffer = CommandBufferPool.Get(PSXStringConstants.s_CommandBufferRenderForwardStr);
					PSXCamera orCreate = PSXCamera.GetOrCreate(camera);
					PushCameraParameters(camera, orCreate, commandBuffer, out var rasterizationWidth, out var rasterizationHeight, out var cameraAspectModeUVScaleBias, flag);
					cullingParameters.cullingOptions &= ~CullingOptions.ShadowCasters;
					if (!ComputeDynamicLightingIsEnabled(camera))
					{
						cullingParameters.cullingOptions &= ~CullingOptions.NeedsLighting;
					}
					cullingParameters.cullingOptions &= ~CullingOptions.Stereo;
					cullingParameters.cullingOptions &= ~CullingOptions.NeedsReflectionProbes;
					CullingResults cullingResults = context.Cull(ref cullingParameters);
					context.SetupCameraProperties(camera);
					bool hdrIsSupported = false;
					RTHandle currentFrameRT = orCreate.GetCurrentFrameRT(0);
					RTHandle currentFrameRT2 = orCreate.GetCurrentFrameRT(1);
					commandBuffer.SetRenderTarget(currentFrameRT.rt, currentFrameRT2.rt);
					SetViewport(commandBuffer, currentFrameRT);
					PushGlobalRasterizationParameters(camera, commandBuffer, currentFrameRT, rasterizationWidth, rasterizationHeight, hdrIsSupported);
					PushQualityOverrideParameters(camera, commandBuffer, flag);
					PushPrecisionParameters(camera, commandBuffer, m_Asset);
					PushFogParameters(camera, commandBuffer);
					PushLightingParameters(camera, commandBuffer);
					PushTonemapperParameters(camera, commandBuffer);
					PushDynamicLightingParameters(camera, commandBuffer, ref cullingResults);
					PushSkyParameters(camera, commandBuffer, skyMaterial, m_Asset, rasterizationWidth, rasterizationHeight);
					PushTerrainGrassParameters(camera, commandBuffer, m_Asset, rasterizationWidth, rasterizationHeight);
					DrawFullScreenQuad(commandBuffer, skyMaterial);
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Release();
					DrawBackgroundOpaque(context, camera, ref cullingResults);
					DrawBackgroundTransparent(context, camera, ref cullingResults);
					commandBuffer = CommandBufferPool.Get(PSXStringConstants.s_CommandBufferRenderPreMainStr);
					PushPreMainParameters(camera, commandBuffer);
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Release();
					DrawMainOpaque(context, camera, ref cullingResults);
					DrawMainTransparent(context, camera, ref cullingResults);
					commandBuffer = CommandBufferPool.Get(PSXStringConstants.s_CommandBufferRenderPreUIOverlayStr);
					TryDrawAccumulationMotionBlurPreUIOverlay(orCreate, commandBuffer, accumulationMotionBlurMaterial, copyColorRespectFlipYMaterial);
					PushPreUIOverlayParameters(camera, commandBuffer);
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Release();
					DrawUIOverlayOpaque(context, camera, ref cullingResults);
					DrawUIOverlayTransparent(context, camera, ref cullingResults);
					DrawLegacyCanvasUI(context, camera, ref cullingResults);
					DrawGizmos(context, camera, GizmoSubset.PreImageEffects);
					DrawGizmos(context, camera, GizmoSubset.PostImageEffects);
					commandBuffer = CommandBufferPool.Get(PSXStringConstants.s_CommandBufferRenderPostProcessStr);
					TryDrawAccumulationMotionBlurPostUIOverlay(orCreate, commandBuffer, accumulationMotionBlurMaterial);
					commandBuffer.SetRenderTarget(camera.targetTexture);
					SetViewport(commandBuffer, camera, camera.targetTexture);
					PushGlobalPostProcessingParameters(camera, commandBuffer, m_Asset, currentFrameRT, rasterizationWidth, rasterizationHeight, cameraAspectModeUVScaleBias);
					PushCompressionParameters(camera, commandBuffer, m_Asset, currentFrameRT, compressionCSKernels);
					PushCathodeRayTubeParameters(camera, commandBuffer, crtMaterial);
					DrawFullScreenQuad(commandBuffer, crtMaterial);
					TryDrawAccumulationMotionBlurFinalBlit(orCreate, commandBuffer, camera.targetTexture, copyColorRespectFlipYMaterial);
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Release();
					context.Submit();
					orCreate.UpdateEndFrame();
					camera.ResetAspect();
					RenderPipeline.EndCameraRendering(context, camera);
				}
			}
		}

		private bool TryUpdateFrameCount(Camera[] cameras)
		{
			int num = Time.frameCount;
			if (num != frameCount)
			{
				frameCount = num;
				return true;
			}
			return false;
		}

		private static bool IsMainGameView(Camera camera)
		{
			return camera.cameraType == CameraType.Game;
		}

		private static Color ComputeClearColorFromVolume()
		{
			Color fogColorFromFogVolume = GetFogColorFromFogVolume();
			ComputeTonemapperSettingsFromVolume(out var isEnabled, out var contrast, out var shoulder, out var _, out var graypointCoefficients, out var crossTalk, out var saturation, out var crossTalkSaturation);
			Vector3 rgb = PSXColor.RGBFromSRGB(new Vector3(fogColorFromFogVolume.r, fogColorFromFogVolume.g, fogColorFromFogVolume.b)) * fogColorFromFogVolume.a;
			if (!isEnabled)
			{
				Vector3 vector = PSXColor.SRGBFromRGB(rgb);
				return new Color(vector.x, vector.y, vector.z, fogColorFromFogVolume.a);
			}
			Vector3 vector2 = PSXColor.SRGBFromRGB(PSXColor.TonemapperGeneric(rgb, contrast, shoulder, graypointCoefficients, crossTalk, saturation, crossTalkSaturation));
			return new Color(vector2.x, vector2.y, vector2.z, fogColorFromFogVolume.a);
		}

		private static Color GetFogColorFromFogVolume()
		{
			FogVolume fogVolume = VolumeManager.instance.stack.GetComponent<FogVolume>();
			if (!fogVolume)
			{
				fogVolume = FogVolume.@default;
			}
			return fogVolume.color.value;
		}

		private static void ComputeTonemapperSettingsFromVolume(out bool isEnabled, out float contrast, out float shoulder, out float whitepoint, out Vector2 graypointCoefficients, out float crossTalk, out float saturation, out float crossTalkSaturation)
		{
			TonemapperVolume tonemapperVolume = VolumeManager.instance.stack.GetComponent<TonemapperVolume>();
			if (!tonemapperVolume)
			{
				tonemapperVolume = TonemapperVolume.@default;
			}
			isEnabled = tonemapperVolume.isEnabled.value;
			contrast = Mathf.Lerp(1E-05f, 1.95f, tonemapperVolume.contrast.value);
			shoulder = Mathf.Lerp(0.9f, 1.1f, tonemapperVolume.shoulder.value);
			whitepoint = tonemapperVolume.whitepoint.value;
			float num = contrast;
			float num2 = shoulder;
			float f = whitepoint;
			float value = tonemapperVolume.graypointIn.value;
			float value2 = tonemapperVolume.graypointOut.value;
			float x = (0f - (value2 * Mathf.Pow(f, num) - Mathf.Pow(value, num))) / (value2 * (Mathf.Pow(value, num * num2) - Mathf.Pow(f, num * num2)));
			float num3 = (value2 * Mathf.Pow(value, num * num2) * Mathf.Pow(f, num) - Mathf.Pow(value, num) * Mathf.Pow(f, num * num2)) / (value2 * (Mathf.Pow(value, num * num2) - Mathf.Pow(f, num * num2)));
			graypointCoefficients = new Vector2(x, num3 + 1E-05f);
			crossTalk = Mathf.Lerp(1E-05f, 32f, tonemapperVolume.crossTalk.value);
			saturation = Mathf.Lerp(0f, 32f, tonemapperVolume.saturation.value);
			crossTalkSaturation = Mathf.Lerp(1E-05f, 32f, tonemapperVolume.crossTalkSaturation.value);
		}

		private static bool EvaluateIsPSXQualityEnabledFromVolume()
		{
			QualityOverrideVolume qualityOverrideVolume = VolumeManager.instance.stack.GetComponent<QualityOverrideVolume>();
			if (!qualityOverrideVolume)
			{
				qualityOverrideVolume = QualityOverrideVolume.@default;
			}
			return qualityOverrideVolume.isPSXQualityEnabled.value;
		}

		private static bool EvaluateIsDepthBufferEnabledFromVolume()
		{
			CameraVolume cameraVolume = VolumeManager.instance.stack.GetComponent<CameraVolume>();
			if (!cameraVolume)
			{
				cameraVolume = CameraVolume.@default;
			}
			return cameraVolume.isDepthBufferEnabled.value;
		}

		private static void PushQualityOverrideParameters(Camera cmaera, CommandBuffer cmd, bool isPSXQualityEnabled)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushQualityOverrideParameters))
			{
				cmd.SetGlobalInt(PSXShaderIDs._IsPSXQualityEnabled, isPSXQualityEnabled ? 1 : 0);
			}
		}

		private static void PushTonemapperParameters(Camera camera, CommandBuffer cmd)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushTonemapperParameters))
			{
				ComputeTonemapperSettingsFromVolume(out var isEnabled, out var contrast, out var shoulder, out var whitepoint, out var graypointCoefficients, out var crossTalk, out var saturation, out var crossTalkSaturation);
				cmd.SetGlobalInt(PSXShaderIDs._TonemapperIsEnabled, isEnabled ? 1 : 0);
				cmd.SetGlobalFloat(PSXShaderIDs._TonemapperContrast, contrast);
				cmd.SetGlobalFloat(PSXShaderIDs._TonemapperShoulder, shoulder);
				cmd.SetGlobalVector(PSXShaderIDs._TonemapperGraypointCoefficients, graypointCoefficients);
				cmd.SetGlobalFloat(PSXShaderIDs._TonemapperWhitepoint, whitepoint);
				cmd.SetGlobalFloat(PSXShaderIDs._TonemapperCrossTalk, crossTalk);
				cmd.SetGlobalFloat(PSXShaderIDs._TonemapperSaturation, saturation);
				cmd.SetGlobalFloat(PSXShaderIDs._TonemapperCrossTalkSaturation, crossTalkSaturation);
			}
		}

		private static void PushLightingParameters(Camera camera, CommandBuffer cmd)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushLightingParameters))
			{
				LightingVolume lightingVolume = VolumeManager.instance.stack.GetComponent<LightingVolume>();
				if (!lightingVolume)
				{
					lightingVolume = LightingVolume.@default;
				}
				bool value = lightingVolume.lightingIsEnabled.value;
				value &= !CoreUtils.IsSceneLightingDisabled(camera);
				cmd.SetGlobalInt(PSXShaderIDs._LightingIsEnabled, value ? 1 : 0);
				cmd.SetGlobalFloat(PSXShaderIDs._BakedLightingMultiplier, lightingVolume.bakedLightingMultiplier.value);
				cmd.SetGlobalFloat(PSXShaderIDs._VertexColorLightingMultiplier, lightingVolume.vertexColorLightingMultiplier.value);
				cmd.SetGlobalFloat(PSXShaderIDs._DynamicLightingMultiplier, lightingVolume.dynamicLightingMultiplier.value);
			}
		}

		private static void PushPreMainParameters(Camera camera, CommandBuffer cmd)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PreMainParameters))
			{
				CameraVolume cameraVolume = VolumeManager.instance.stack.GetComponent<CameraVolume>();
				if (!cameraVolume)
				{
					cameraVolume = CameraVolume.@default;
				}
				if (cameraVolume.isClearDepthAfterBackgroundEnabled.value)
				{
					Color black = Color.black;
					CoreUtils.ClearRenderTarget(cmd, ClearFlag.Depth, black);
				}
			}
		}

		private static void PushPreUIOverlayParameters(Camera camera, CommandBuffer cmd)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PreUIOverlayParameters))
			{
				CameraVolume cameraVolume = VolumeManager.instance.stack.GetComponent<CameraVolume>();
				if (!cameraVolume)
				{
					cameraVolume = CameraVolume.@default;
				}
				if (cameraVolume.isClearDepthBeforeUIEnabled.value)
				{
					Color black = Color.black;
					CoreUtils.ClearRenderTarget(cmd, ClearFlag.Depth, black);
				}
			}
		}

		private static PerObjectData ComputePerObjectDataFromLightingVolume(Camera camera)
		{
			LightingVolume lightingVolume = VolumeManager.instance.stack.GetComponent<LightingVolume>();
			if (!lightingVolume)
			{
				lightingVolume = LightingVolume.@default;
			}
			bool num = lightingVolume.lightingIsEnabled.value & !CoreUtils.IsSceneLightingDisabled(camera);
			PerObjectData perObjectData = PerObjectData.None;
			if (num)
			{
				if (lightingVolume.bakedLightingMultiplier.value > 0f)
				{
					perObjectData |= PerObjectData.LightProbe | PerObjectData.LightProbeProxyVolume | PerObjectData.Lightmaps | PerObjectData.OcclusionProbe | PerObjectData.OcclusionProbeProxyVolume | PerObjectData.ShadowMask;
				}
				if (lightingVolume.dynamicLightingMultiplier.value > 0f)
				{
					perObjectData |= PerObjectData.LightData | PerObjectData.LightIndices;
				}
			}
			return perObjectData;
		}

		private static bool ComputeDynamicLightingIsEnabled(Camera camera)
		{
			LightingVolume lightingVolume = VolumeManager.instance.stack.GetComponent<LightingVolume>();
			if (!lightingVolume)
			{
				lightingVolume = LightingVolume.@default;
			}
			return lightingVolume.lightingIsEnabled.value & !CoreUtils.IsSceneLightingDisabled(camera) & (lightingVolume.dynamicLightingMultiplier.value > 0f);
		}

		public static Vector2 ComputePrecisionGeometryParameters(float precisionGeometryNormalized)
		{
			float p = Mathf.Lerp(6f, 0f, precisionGeometryNormalized);
			float num = Mathf.Pow(2f, p);
			return new Vector2(1f / num, num);
		}

		private static void PushPrecisionParameters(Camera camera, CommandBuffer cmd, PSXRenderPipelineAsset asset)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushPrecisionParameters))
			{
				PrecisionVolume precisionVolume = VolumeManager.instance.stack.GetComponent<PrecisionVolume>();
				if (!precisionVolume)
				{
					precisionVolume = PrecisionVolume.@default;
				}
				cmd.SetGlobalVector(PSXShaderIDs._GeometryPushbackParameters, new Vector4(precisionVolume.geometryPushbackEnabled.value ? 1f : 0f, precisionVolume.geometryPushbackMinMax.value.x, precisionVolume.geometryPushbackMinMax.value.y, 0f));
				bool value = precisionVolume.geometryEnabled.value;
				if (value)
				{
					Vector2 vector = ComputePrecisionGeometryParameters(precisionVolume.geometry.value);
					cmd.SetGlobalVector(PSXShaderIDs._PrecisionGeometry, new Vector4(vector.x, vector.y, precisionVolume.geometry.value, value ? 1f : 0f));
				}
				else
				{
					cmd.SetGlobalVector(PSXShaderIDs._PrecisionGeometry, Vector4.zero);
				}
				int num = Mathf.FloorToInt(precisionVolume.color.value * 7f + 0.5f);
				float value2 = precisionVolume.chroma.value;
				Vector3 vector2 = Vector3.zero;
				switch (num)
				{
				case 7:
					vector2 = new Vector3(255f, 255f, 255f);
					break;
				case 6:
					vector2 = new Vector3(127f, Mathf.Pow(2f, 7f + value2 * 1f) - 1f, 127f);
					break;
				case 5:
					vector2 = new Vector3(63f, Mathf.Pow(2f, 6f + value2 * 2f) - 1f, 63f);
					break;
				case 4:
					vector2 = new Vector3(31f, Mathf.Pow(2f, 5f + value2 * 3f) - 1f, 31f);
					break;
				case 3:
					vector2 = new Vector3(15f, Mathf.Pow(2f, 4f + value2 * 4f) - 1f, 15f);
					break;
				case 2:
					vector2 = new Vector3(7f, Mathf.Pow(2f, 3f + value2 * 5f) - 1f, 7f);
					break;
				case 1:
					vector2 = new Vector3(3f, Mathf.Pow(2f, 2f + value2 * 6f) - 1f, 3f);
					break;
				case 0:
					vector2 = new Vector3(1f, Mathf.Pow(2f, 1f + value2 * 7f) - 1f, 1f);
					break;
				}
				cmd.SetGlobalVector(PSXShaderIDs._PrecisionColor, new Vector4(vector2.x, vector2.y, vector2.z, (float)num / 7f));
				cmd.SetGlobalVector(PSXShaderIDs._PrecisionColorInverse, new Vector4(1f / vector2.x, 1f / vector2.y, 1f / vector2.z, value2));
				int num2 = Mathf.FloorToInt(precisionVolume.alpha.value * 7f + 0.5f);
				float num3 = 0f;
				switch (num2)
				{
				case 7:
					num3 = 255f;
					break;
				case 6:
					num3 = 127f;
					break;
				case 5:
					num3 = 63f;
					break;
				case 4:
					num3 = 31f;
					break;
				case 3:
					num3 = 15f;
					break;
				case 2:
					num3 = 7f;
					break;
				case 1:
					num3 = 3f;
					break;
				case 0:
					num3 = 1f;
					break;
				}
				cmd.SetGlobalVector(PSXShaderIDs._PrecisionAlphaAndInverse, new Vector2(num3, 1f / num3));
				float value3 = precisionVolume.affineTextureWarping.value;
				cmd.SetGlobalFloat(PSXShaderIDs._AffineTextureWarping, value3);
				cmd.SetGlobalFloat(PSXShaderIDs._FramebufferDither, precisionVolume.framebufferDither.value);
				Texture2D framebufferDitherTexFromAssetAndFrame = GetFramebufferDitherTexFromAssetAndFrame(asset, (uint)Time.frameCount);
				cmd.SetGlobalTexture(PSXShaderIDs._FramebufferDitherTexture, framebufferDitherTexFromAssetAndFrame);
				cmd.SetGlobalVector(PSXShaderIDs._FramebufferDitherSize, new Vector4(framebufferDitherTexFromAssetAndFrame.width, framebufferDitherTexFromAssetAndFrame.height, 1f / (float)framebufferDitherTexFromAssetAndFrame.width, 1f / (float)framebufferDitherTexFromAssetAndFrame.height));
				cmd.SetGlobalVector(PSXShaderIDs._FramebufferDitherScaleAndInverse, new Vector2(precisionVolume.ditherSize.value, 1f / (float)precisionVolume.ditherSize.value));
				int value4 = (int)precisionVolume.drawDistanceFalloffMode.value;
				cmd.SetGlobalInt(PSXShaderIDs._DrawDistanceFalloffMode, value4);
				cmd.SetGlobalVector(PSXShaderIDs._DrawDistance, new Vector2(precisionVolume.drawDistance.value, precisionVolume.drawDistance.value * precisionVolume.drawDistance.value));
			}
		}

		private static void PushFogParameters(Camera camera, CommandBuffer cmd)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushFogParameters))
			{
				FogVolume fogVolume = VolumeManager.instance.stack.GetComponent<FogVolume>();
				if (!fogVolume)
				{
					fogVolume = FogVolume.@default;
				}
				Vector4 value = new Vector4(1f / (fogVolume.distanceMax.value - fogVolume.distanceMin.value), (0f - fogVolume.distanceMin.value) / (fogVolume.distanceMax.value - fogVolume.distanceMin.value), -1f / (fogVolume.heightMax.value - fogVolume.heightMin.value), fogVolume.heightMax.value / (fogVolume.heightMax.value - fogVolume.heightMin.value));
				float value2 = ((fogVolume.fogFalloffCurve.value > 0f) ? (1f - Mathf.Min(0.999f, fogVolume.fogFalloffCurve.value)) : (1f / (1f + Mathf.Max(-0.999f, fogVolume.fogFalloffCurve.value))));
				bool flag = fogVolume.isEnabled.value && CoreUtils.IsSceneViewFogEnabled(camera);
				if (!flag)
				{
					value = new Vector4(0f, 0f, 0f, 0f);
					value2 = 1f;
				}
				else if (!fogVolume.heightFalloffEnabled.value)
				{
					value.z = 0f;
					value.w = 1f;
				}
				FogVolume.FogBlendMode value3 = fogVolume.blendMode.value;
				cmd.SetGlobalInt(PSXShaderIDs._FogBlendMode, (int)value3);
				cmd.SetGlobalInt(PSXShaderIDs._FogHeightFalloffMirrored, fogVolume.heightFalloffMirrored.value ? 1 : 0);
				cmd.SetGlobalInt(PSXShaderIDs._FogHeightFalloffMirroredLayer1, fogVolume.heightFalloffMirroredLayer1.value ? 1 : 0);
				int value4 = (int)fogVolume.fogFalloffMode.value;
				cmd.SetGlobalInt(PSXShaderIDs._FogFalloffMode, value4);
				cmd.SetGlobalVector(PSXShaderIDs._FogColor, new Vector4(fogVolume.color.value.r, fogVolume.color.value.g, fogVolume.color.value.b, fogVolume.color.value.a));
				int num = Mathf.FloorToInt(fogVolume.precisionAlpha.value * 7f + 0.5f);
				float num2 = 0f;
				switch (num)
				{
				case 7:
					num2 = 255f;
					break;
				case 6:
					num2 = 127f;
					break;
				case 5:
					num2 = 63f;
					break;
				case 4:
					num2 = 31f;
					break;
				case 3:
					num2 = 15f;
					break;
				case 2:
					num2 = 7f;
					break;
				case 1:
					num2 = 3f;
					break;
				case 0:
					num2 = 1f;
					break;
				}
				cmd.SetGlobalVector(PSXShaderIDs._FogPrecisionAlphaAndInverse, new Vector2(num2, 1f / num2));
				Texture texture = ((fogVolume.precisionAlphaDitherTexture.value != null) ? fogVolume.precisionAlphaDitherTexture.value : Texture2D.grayTexture);
				cmd.SetGlobalTexture(PSXShaderIDs._FogPrecisionAlphaDitherTexture, texture);
				cmd.SetGlobalVector(PSXShaderIDs._FogPrecisionAlphaDitherSize, new Vector4(texture.width, texture.height, 1f / (float)texture.width, 1f / (float)texture.height));
				cmd.SetGlobalFloat(PSXShaderIDs._FogPrecisionAlphaDither, fogVolume.precisionAlphaDither.value);
				cmd.SetGlobalVector(PSXShaderIDs._FogDistanceScaleBias, value);
				cmd.SetGlobalFloat(PSXShaderIDs._FogFalloffCurvePower, value2);
				switch (fogVolume.colorLUTMode.value)
				{
				case FogVolume.FogColorLUTMode.Disabled:
					cmd.SetGlobalTexture(PSXShaderIDs._FogColorLUTTexture2D, Texture2D.whiteTexture);
					cmd.SetGlobalTexture(PSXShaderIDs._FogColorLUTTextureCube, whiteCubemap);
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTRotationTangent, Vector3.zero);
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTRotationBitangent, Vector3.zero);
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTRotationNormal, Vector3.zero);
					cmd.EnableShaderKeyword(PSXShaderKeywords.s_FOG_COLOR_LUT_MODE_DISABLED);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_FOG_COLOR_LUT_MODE_TEXTURE2D_DISTANCE_AND_HEIGHT);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_FOG_COLOR_LUT_MODE_TEXTURECUBE);
					break;
				case FogVolume.FogColorLUTMode.Texture2DDistanceAndHeight:
					cmd.SetGlobalTexture(PSXShaderIDs._FogColorLUTTexture2D, fogVolume.colorLUTTexture.value);
					cmd.SetGlobalTexture(PSXShaderIDs._FogColorLUTTextureCube, whiteCubemap);
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTRotationTangent, Vector3.zero);
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTRotationBitangent, Vector3.zero);
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTRotationNormal, Vector3.zero);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_FOG_COLOR_LUT_MODE_DISABLED);
					cmd.EnableShaderKeyword(PSXShaderKeywords.s_FOG_COLOR_LUT_MODE_TEXTURE2D_DISTANCE_AND_HEIGHT);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_FOG_COLOR_LUT_MODE_TEXTURECUBE);
					break;
				case FogVolume.FogColorLUTMode.TextureCube:
				{
					cmd.SetGlobalTexture(PSXShaderIDs._FogColorLUTTexture2D, Texture2D.whiteTexture);
					cmd.SetGlobalTexture(PSXShaderIDs._FogColorLUTTextureCube, fogVolume.colorLUTTexture.value);
					Quaternion quaternion = Quaternion.Euler(fogVolume.colorLUTRotationDegrees.value);
					Vector3 vector = quaternion * Vector3.right;
					Vector3 vector2 = quaternion * Vector3.up;
					Vector3 vector3 = quaternion * Vector3.forward;
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTRotationTangent, vector);
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTRotationBitangent, vector2);
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTRotationNormal, vector3);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_FOG_COLOR_LUT_MODE_DISABLED);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_FOG_COLOR_LUT_MODE_TEXTURE2D_DISTANCE_AND_HEIGHT);
					cmd.EnableShaderKeyword(PSXShaderKeywords.s_FOG_COLOR_LUT_MODE_TEXTURECUBE);
					break;
				}
				}
				cmd.SetGlobalVector(PSXShaderIDs._FogColorLUTWeight, new Vector2(fogVolume.colorLUTWeight.value, fogVolume.colorLUTWeightLayer1.value));
				bool value5 = fogVolume.isAdditionalLayerEnabled.value;
				cmd.SetGlobalInt(PSXShaderIDs._FogIsAdditionalLayerEnabled, value5 ? 1 : 0);
				if (value5)
				{
					int value6 = (int)fogVolume.fogFalloffModeLayer1.value;
					cmd.SetGlobalInt(PSXShaderIDs._FogFalloffModeLayer1, value6);
					cmd.SetGlobalVector(PSXShaderIDs._FogColorLayer1, new Vector4(fogVolume.colorLayer1.value.r, fogVolume.colorLayer1.value.g, fogVolume.colorLayer1.value.b, fogVolume.colorLayer1.value.a));
					Vector4 value7 = new Vector4(1f / (fogVolume.distanceMaxLayer1.value - fogVolume.distanceMinLayer1.value), (0f - fogVolume.distanceMinLayer1.value) / (fogVolume.distanceMaxLayer1.value - fogVolume.distanceMinLayer1.value), -1f / (fogVolume.heightMaxLayer1.value - fogVolume.heightMinLayer1.value), fogVolume.heightMaxLayer1.value / (fogVolume.heightMaxLayer1.value - fogVolume.heightMinLayer1.value));
					float value8 = ((fogVolume.fogFalloffCurveLayer1.value > 0f) ? (1f - Mathf.Min(0.999f, fogVolume.fogFalloffCurveLayer1.value)) : (1f / (1f + Mathf.Max(-0.999f, fogVolume.fogFalloffCurveLayer1.value))));
					if (!flag)
					{
						value7 = new Vector4(0f, 0f, 0f, 0f);
						value8 = 1f;
					}
					else if (!fogVolume.heightFalloffEnabledLayer1.value)
					{
						value7.z = 0f;
						value7.w = 1f;
					}
					cmd.SetGlobalVector(PSXShaderIDs._FogDistanceScaleBiasLayer1, value7);
					cmd.SetGlobalFloat(PSXShaderIDs._FogFalloffCurvePowerLayer1, value8);
				}
			}
		}

		private void PushGlobalRasterizationParameters(Camera camera, CommandBuffer cmd, RTHandle rasterizationRT, int rasterizationWidth, int rasterizationHeight, bool hdrIsSupported)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushGlobalRasterizationParameters))
			{
				Color black = Color.black;
				cmd.ClearRenderTarget(clearDepth: true, clearColor: false, black);
				cmd.SetGlobalVector(PSXShaderIDs._ScreenSize, new Vector4(rasterizationWidth, rasterizationHeight, 1f / (float)rasterizationWidth, 1f / (float)rasterizationHeight));
				cmd.SetGlobalVector(PSXShaderIDs._ScreenSizeRasterization, new Vector4(rasterizationWidth, rasterizationHeight, 1f / (float)rasterizationWidth, 1f / (float)rasterizationHeight));
				cmd.SetGlobalVector(PSXShaderIDs._ScreenSizeRasterizationRTScaled, new Vector4(rasterizationRT.rt.width, rasterizationRT.rt.height, 1f / (float)rasterizationRT.rt.width, 1f / (float)rasterizationRT.rt.height));
				cmd.SetGlobalVector(value: new Vector4(0.5f / (float)rasterizationRT.rt.width, 0.5f / (float)rasterizationRT.rt.height, ((float)rasterizationWidth - 0.5f) / (float)rasterizationRT.rt.width, ((float)rasterizationHeight - 0.5f) / (float)rasterizationRT.rt.height), nameID: PSXShaderIDs._RasterizationRTScaledClampBoundsUV);
				Vector4 value = (rasterizationRT.useScaling ? new Vector4(rasterizationWidth, rasterizationHeight, (float)rasterizationWidth / (float)rasterizationRT.rt.width, (float)rasterizationHeight / (float)rasterizationRT.rt.height) : new Vector4(rasterizationRT.rt.width, rasterizationRT.rt.height, 1f, 1f));
				cmd.SetGlobalVector(PSXShaderIDs._RasterizationRTScaledMaxSSAndUV, value);
				cmd.SetGlobalVector(PSXShaderIDs._WorldSpaceCameraPos, camera.transform.position);
				float animatedMaterialsTime = GetAnimatedMaterialsTime(camera);
				cmd.SetGlobalVector(PSXShaderIDs._Time, new Vector4(animatedMaterialsTime / 20f, animatedMaterialsTime, animatedMaterialsTime * 2f, animatedMaterialsTime * 3f));
				Texture2D alphaClippingDitherTexFromAssetAndFrame = GetAlphaClippingDitherTexFromAssetAndFrame(asset, (uint)Time.frameCount);
				cmd.SetGlobalTexture(PSXShaderIDs._AlphaClippingDitherTexture, alphaClippingDitherTexFromAssetAndFrame);
				cmd.SetGlobalVector(PSXShaderIDs._AlphaClippingDitherSize, new Vector4(alphaClippingDitherTexFromAssetAndFrame.width, alphaClippingDitherTexFromAssetAndFrame.height, 1f / (float)alphaClippingDitherTexFromAssetAndFrame.width, 1f / (float)alphaClippingDitherTexFromAssetAndFrame.height));
				bool flag = ComputeCameraProjectionIsFlippedY(camera);
				float nearClipPlane = camera.nearClipPlane;
				float farClipPlane = camera.farClipPlane;
				Vector4 value2 = new Vector4((!flag) ? 1 : (-1), nearClipPlane, farClipPlane, 1f / farClipPlane);
				cmd.SetGlobalVector(PSXShaderIDs._ProjectionParams, value2);
				if (hdrIsSupported)
				{
					Shader.EnableKeyword(PSXShaderKeywords.s_OUTPUT_HDR);
				}
				else
				{
					Shader.EnableKeyword(PSXShaderKeywords.s_OUTPUT_LDR);
				}
			}
		}

		private static void PushGlobalPostProcessingParameters(Camera camera, CommandBuffer cmd, PSXRenderPipelineAsset asset, RTHandle rasterizationRT, int rasterizationWidth, int rasterizationHeight, Vector4 cameraAspectModeUVScaleBias)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushGlobalPostProcessingParameters))
			{
				bool flag = ((ComputeCameraProjectionIsFlippedY(camera) && IsMainGameView(camera) && camera.targetTexture == null) ? true : false);
				Vector4 value = cameraAspectModeUVScaleBias;
				if (rasterizationRT.useScaling)
				{
					Vector2 vector = new Vector2((float)rasterizationWidth / (float)rasterizationRT.rt.width, (float)rasterizationHeight / (float)rasterizationRT.rt.height);
					value.x *= vector.x;
					value.y *= vector.y;
					value.z *= vector.x;
					value.w *= vector.y;
				}
				cmd.SetGlobalInt(PSXShaderIDs._FlipY, flag ? 1 : 0);
				cmd.SetGlobalVector(PSXShaderIDs._CameraAspectModeUVScaleBias, value);
				cmd.SetGlobalVector(PSXShaderIDs._ScreenSize, new Vector4(camera.pixelWidth, camera.pixelHeight, 1f / (float)camera.pixelWidth, 1f / (float)camera.pixelHeight));
				cmd.SetGlobalVector(PSXShaderIDs._ScreenSizeRasterization, new Vector4(rasterizationWidth, rasterizationHeight, 1f / (float)rasterizationWidth, 1f / (float)rasterizationHeight));
				cmd.SetGlobalVector(PSXShaderIDs._ScreenSizeRasterizationRTScaled, new Vector4(rasterizationRT.rt.width, rasterizationRT.rt.height, 1f / (float)rasterizationRT.rt.width, 1f / (float)rasterizationRT.rt.height));
				cmd.SetGlobalTexture(PSXShaderIDs._FrameBufferTexture, rasterizationRT);
				Texture2D whiteNoise1024RGBTexFromAssetAndFrame = GetWhiteNoise1024RGBTexFromAssetAndFrame(asset, (uint)Time.frameCount);
				cmd.SetGlobalTexture(PSXShaderIDs._WhiteNoiseTexture, whiteNoise1024RGBTexFromAssetAndFrame);
				cmd.SetGlobalVector(PSXShaderIDs._WhiteNoiseSize, new Vector4(whiteNoise1024RGBTexFromAssetAndFrame.width, whiteNoise1024RGBTexFromAssetAndFrame.height, 1f / (float)whiteNoise1024RGBTexFromAssetAndFrame.width, 1f / (float)whiteNoise1024RGBTexFromAssetAndFrame.height));
				Texture2D blueNoise16RGBTexFromAssetAndFrame = GetBlueNoise16RGBTexFromAssetAndFrame(asset, (uint)Time.frameCount);
				cmd.SetGlobalTexture(PSXShaderIDs._BlueNoiseTexture, blueNoise16RGBTexFromAssetAndFrame);
				cmd.SetGlobalVector(PSXShaderIDs._BlueNoiseSize, new Vector4(blueNoise16RGBTexFromAssetAndFrame.width, blueNoise16RGBTexFromAssetAndFrame.height, 1f / (float)blueNoise16RGBTexFromAssetAndFrame.width, 1f / (float)blueNoise16RGBTexFromAssetAndFrame.height));
				float animatedMaterialsTime = GetAnimatedMaterialsTime(camera);
				cmd.SetGlobalVector(PSXShaderIDs._Time, new Vector4(animatedMaterialsTime / 20f, animatedMaterialsTime, animatedMaterialsTime * 2f, animatedMaterialsTime * 3f));
			}
		}

		private static Texture2D GetFramebufferDitherTexFromAssetAndFrame(PSXRenderPipelineAsset asset, uint frameCount)
		{
			Texture2D result = Texture2D.grayTexture;
			if (asset.renderPipelineResources.textures.framebufferDitherTex != null && asset.renderPipelineResources.textures.framebufferDitherTex.Length != 0)
			{
				uint num = frameCount % (uint)asset.renderPipelineResources.textures.framebufferDitherTex.Length;
				result = asset.renderPipelineResources.textures.framebufferDitherTex[num];
			}
			return result;
		}

		private static Texture2D GetAlphaClippingDitherTexFromAssetAndFrame(PSXRenderPipelineAsset asset, uint frameCount)
		{
			Texture2D result = Texture2D.grayTexture;
			if (asset.renderPipelineResources.textures.alphaClippingDitherTex != null && asset.renderPipelineResources.textures.alphaClippingDitherTex.Length != 0)
			{
				uint num = frameCount % (uint)asset.renderPipelineResources.textures.alphaClippingDitherTex.Length;
				result = asset.renderPipelineResources.textures.alphaClippingDitherTex[num];
			}
			return result;
		}

		private static Texture2D GetWhiteNoise1024RGBTexFromAssetAndFrame(PSXRenderPipelineAsset asset, uint frameCount)
		{
			Texture2D result = Texture2D.grayTexture;
			if (asset.renderPipelineResources.textures.whiteNoise1024RGBTex != null && asset.renderPipelineResources.textures.whiteNoise1024RGBTex.Length != 0)
			{
				uint num = frameCount % (uint)asset.renderPipelineResources.textures.whiteNoise1024RGBTex.Length;
				result = asset.renderPipelineResources.textures.whiteNoise1024RGBTex[num];
			}
			return result;
		}

		private static Texture2D GetBlueNoise16RGBTexFromAssetAndFrame(PSXRenderPipelineAsset asset, uint frameCount)
		{
			Texture2D result = Texture2D.grayTexture;
			if (asset.renderPipelineResources.textures.blueNoise16RGBTex != null && asset.renderPipelineResources.textures.blueNoise16RGBTex.Length != 0)
			{
				uint num = frameCount % (uint)asset.renderPipelineResources.textures.blueNoise16RGBTex.Length;
				result = asset.renderPipelineResources.textures.blueNoise16RGBTex[num];
			}
			return result;
		}

		private static int ComputeCompressionKernelIndex(CompressionVolume.CompressionMode mode, CompressionVolume.CompressionColorspace colorspace)
		{
			return (int)((int)mode * 6 + colorspace);
		}

		private int[] FindCompressionKernels(PSXRenderPipelineAsset asset)
		{
			int[] array = new int[PSXComputeKernels.s_COMPRESSION.Length];
			int i = 0;
			for (int num = PSXComputeKernels.s_COMPRESSION.Length; i < num; i++)
			{
				array[i] = asset.renderPipelineResources.shaders.compressionCS.FindKernel(PSXComputeKernels.s_COMPRESSION[i]);
			}
			return array;
		}

		private static void PushCompressionParameters(Camera camera, CommandBuffer cmd, PSXRenderPipelineAsset asset, RenderTexture rasterizationRT, int[] compressionCSKernels)
		{
			if (!IsComputeShaderSupportedPlatform())
			{
				return;
			}
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushCompressionParameters))
			{
				CompressionVolume compressionVolume = VolumeManager.instance.stack.GetComponent<CompressionVolume>();
				if (!compressionVolume)
				{
					compressionVolume = CompressionVolume.@default;
				}
				if (compressionVolume.isEnabled.value || compressionVolume.weight.value < 1E-05f)
				{
					int num = ComputeCompressionKernelIndex(compressionVolume.mode.value, compressionVolume.colorspace.value);
					int kernelIndex = compressionCSKernels[num];
					cmd.SetComputeFloatParam(asset.renderPipelineResources.shaders.compressionCS, PSXShaderIDs._CompressionWeight, compressionVolume.weight.value);
					float num2 = Mathf.Lerp(4f, 1E-05f, compressionVolume.accuracy.value);
					float y = 1f / num2;
					cmd.SetComputeVectorParam(asset.renderPipelineResources.shaders.compressionCS, PSXShaderIDs._CompressionAccuracyThresholdAndInverse, new Vector2(num2, y));
					cmd.SetComputeVectorParam(asset.renderPipelineResources.shaders.compressionCS, PSXShaderIDs._CompressionSourceIndicesMinMax, new Vector4(0f, 0f, rasterizationRT.width - 1, rasterizationRT.height - 1));
					float num3 = Mathf.Lerp(16f, 256f, compressionVolume.accuracy.value);
					cmd.SetComputeVectorParam(asset.renderPipelineResources.shaders.compressionCS, PSXShaderIDs._CompressionChromaQuantizationScaleAndInverse, new Vector2(num3, 1f / num3));
					cmd.SetComputeTextureParam(asset.renderPipelineResources.shaders.compressionCS, kernelIndex, PSXShaderIDs._CompressionSource, rasterizationRT);
					cmd.DispatchCompute(asset.renderPipelineResources.shaders.compressionCS, kernelIndex, (rasterizationRT.width + 7) / 8, (rasterizationRT.height + 7) / 8, 1);
				}
			}
		}

		private static void PushSkyParameters(Camera camera, CommandBuffer cmd, Material skyMaterial, PSXRenderPipelineAsset asset, int rasterizationWidth, int rasterizationHeight)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushSkyParameters))
			{
				SkyVolume skyVolume = VolumeManager.instance.stack.GetComponent<SkyVolume>();
				if (!skyVolume)
				{
					skyVolume = SkyVolume.@default;
				}
				SkyVolume.SkyMode value = skyVolume.skyMode.value;
				switch (value)
				{
				case SkyVolume.SkyMode.FogColor:
					skyMaterial.EnableKeyword(PSXShaderKeywords.s_SKY_MODE_FOG_COLOR);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_BACKGROUND_COLOR);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_SKYBOX);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_TILED_LAYERS);
					break;
				case SkyVolume.SkyMode.BackgroundColor:
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_FOG_COLOR);
					skyMaterial.EnableKeyword(PSXShaderKeywords.s_SKY_MODE_BACKGROUND_COLOR);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_SKYBOX);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_TILED_LAYERS);
					break;
				case SkyVolume.SkyMode.Skybox:
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_FOG_COLOR);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_BACKGROUND_COLOR);
					skyMaterial.EnableKeyword(PSXShaderKeywords.s_SKY_MODE_SKYBOX);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_TILED_LAYERS);
					break;
				case SkyVolume.SkyMode.TiledLayers:
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_FOG_COLOR);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_BACKGROUND_COLOR);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_SKY_MODE_SKYBOX);
					skyMaterial.EnableKeyword(PSXShaderKeywords.s_SKY_MODE_TILED_LAYERS);
					break;
				}
				switch (skyVolume.textureFilterMode.value)
				{
				case SkyVolume.TextureFilterMode.TextureImportSettings:
					skyMaterial.EnableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				case SkyVolume.TextureFilterMode.Point:
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					skyMaterial.EnableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				case SkyVolume.TextureFilterMode.PointMipmaps:
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT);
					skyMaterial.EnableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				case SkyVolume.TextureFilterMode.N64:
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					skyMaterial.EnableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				case SkyVolume.TextureFilterMode.N64Mipmaps:
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					skyMaterial.DisableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64);
					skyMaterial.EnableKeyword(PSXShaderKeywords.s_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				}
				cmd.SetGlobalVector(value: value switch
				{
					SkyVolume.SkyMode.FogColor => GetFogColorFromFogVolume(), 
					SkyVolume.SkyMode.BackgroundColor => camera.backgroundColor, 
					_ => Color.black, 
				}, nameID: PSXShaderIDs._SkyColor);
				if (value == SkyVolume.SkyMode.Skybox)
				{
					Texture texture = skyVolume.skyboxTexture.value;
					if (texture == null)
					{
						texture = asset.renderPipelineResources.textures.skyboxTextureCubeDefault;
					}
					cmd.SetGlobalTexture(PSXShaderIDs._SkyboxTextureCube, texture);
				}
				if (value == SkyVolume.SkyMode.Skybox || value == SkyVolume.SkyMode.TiledLayers)
				{
					Matrix4x4 matrix4x = ComputePixelCoordToWorldSpaceViewDirectionMatrix(resolution: new Vector4(rasterizationWidth, rasterizationHeight, 1f / (float)rasterizationWidth, 1f / (float)rasterizationHeight), camera: camera, viewMatrix: camera.worldToCameraMatrix);
					Vector3 value2 = skyVolume.skyRotation.value;
					Matrix4x4 matrix4x2 = Matrix4x4.Rotate(Quaternion.Euler(value2.x, value2.y, value2.z));
					cmd.SetGlobalMatrix(PSXShaderIDs._SkyPixelCoordToWorldSpaceViewDirectionMatrix, matrix4x * matrix4x2);
				}
				else
				{
					cmd.SetGlobalMatrix(PSXShaderIDs._SkyPixelCoordToWorldSpaceViewDirectionMatrix, Matrix4x4.identity);
				}
				if (value == SkyVolume.SkyMode.TiledLayers)
				{
					cmd.SetGlobalFloat(PSXShaderIDs._SkyTiledLayersSkyHeightScaleInverse, 1f / skyVolume.tiledLayersSkyHeightScale.value);
					cmd.SetGlobalFloat(PSXShaderIDs._SkyTiledLayersSkyHorizonOffset, skyVolume.tiledLayersSkyHorizonOffset.value);
					cmd.SetGlobalVector(PSXShaderIDs._SkyTiledLayersSkyColorLayer0, skyVolume.tiledLayersSkyColorLayer0.value);
					cmd.SetGlobalTexture(PSXShaderIDs._SkyTiledLayersSkyTextureLayer0, skyVolume.tiledLayersSkyTextureLayer0.value);
					cmd.SetGlobalVector(PSXShaderIDs._SkyTiledLayersSkyTextureScaleOffsetLayer0, skyVolume.tiledLayersSkyTextureScaleOffsetLayer0.value);
					cmd.SetGlobalFloat(PSXShaderIDs._SkyTiledLayersSkyRotationLayer0, MathF.PI / 180f * skyVolume.tiledLayersSkyRotationLayer0.value);
					cmd.SetGlobalVector(PSXShaderIDs._SkyTiledLayersSkyScrollScaleLayer0, skyVolume.tiledLayersSkyScrollScaleLayer0.value * 0.1f);
					cmd.SetGlobalFloat(PSXShaderIDs._SkyTiledLayersSkyScrollRotationLayer0, MathF.PI / 180f * skyVolume.tiledLayersSkyScrollRotationLayer0.value);
					cmd.SetGlobalVector(PSXShaderIDs._SkyTiledLayersSkyColorLayer1, skyVolume.tiledLayersSkyColorLayer1.value);
					cmd.SetGlobalTexture(PSXShaderIDs._SkyTiledLayersSkyTextureLayer1, skyVolume.tiledLayersSkyTextureLayer1.value);
					cmd.SetGlobalVector(PSXShaderIDs._SkyTiledLayersSkyTextureScaleOffsetLayer1, skyVolume.tiledLayersSkyTextureScaleOffsetLayer1.value);
					cmd.SetGlobalFloat(PSXShaderIDs._SkyTiledLayersSkyRotationLayer1, MathF.PI / 180f * skyVolume.tiledLayersSkyRotationLayer1.value);
					cmd.SetGlobalVector(PSXShaderIDs._SkyTiledLayersSkyScrollScaleLayer1, skyVolume.tiledLayersSkyScrollScaleLayer1.value * 0.1f);
					cmd.SetGlobalFloat(PSXShaderIDs._SkyTiledLayersSkyScrollRotationLayer1, MathF.PI / 180f * skyVolume.tiledLayersSkyScrollRotationLayer1.value);
				}
				cmd.SetGlobalFloat(PSXShaderIDs._SkyFramebufferDitherWeight, skyVolume.framebufferDitherWeight.value);
			}
		}

		private static void PushTerrainGrassParameters(Camera camera, CommandBuffer cmd, PSXRenderPipelineAsset asset, int rasterizationWidth, int rasterizationHeight)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushTerrainGrassParameters))
			{
				TerrainGrassVolume terrainGrassVolume = VolumeManager.instance.stack.GetComponent<TerrainGrassVolume>();
				if (!terrainGrassVolume)
				{
					terrainGrassVolume = TerrainGrassVolume.@default;
				}
				switch (terrainGrassVolume.textureFilterMode.value)
				{
				case TerrainGrassVolume.TextureFilterMode.TextureImportSettings:
					cmd.EnableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				case TerrainGrassVolume.TextureFilterMode.Point:
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					cmd.EnableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				case TerrainGrassVolume.TextureFilterMode.PointMipmaps:
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT);
					cmd.EnableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				case TerrainGrassVolume.TextureFilterMode.N64:
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					cmd.EnableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				case TerrainGrassVolume.TextureFilterMode.N64Mipmaps:
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_TEXTURE_IMPORT_SETTINGS);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_POINT_MIPMAPS);
					cmd.DisableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64);
					cmd.EnableShaderKeyword(PSXShaderKeywords.s_TERRAIN_GRASS_TEXTURE_FILTER_MODE_N64_MIPMAPS);
					break;
				}
			}
		}

		private static void TryDrawAccumulationMotionBlurPreUIOverlay(PSXCamera psxCamera, CommandBuffer cmd, Material accumulationMotionBlurMaterial, Material copyColorRespectFlipYMaterial)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_DrawAccumulationMotionBlurPreUIOverlay))
			{
				AccumulationMotionBlurVolume accumulationMotionBlurVolume = VolumeManager.instance.stack.GetComponent<AccumulationMotionBlurVolume>();
				if (!accumulationMotionBlurVolume)
				{
					accumulationMotionBlurVolume = AccumulationMotionBlurVolume.@default;
				}
				if (accumulationMotionBlurVolume.weight.value <= 1E-05f)
				{
					psxCamera.ResetAccumulationMotionBlurFrameCount();
				}
				if (psxCamera.GetCameraAccumulationMotionBlurFrameCount() != 0 && !accumulationMotionBlurVolume.applyToUIOverlay.value)
				{
					PushAccumulationMotionBlurParameters(psxCamera, cmd, accumulationMotionBlurVolume);
					DrawFullScreenQuad(cmd, accumulationMotionBlurMaterial);
					RTHandle currentFrameRT = psxCamera.GetCurrentFrameRT(0);
					RTHandle currentFrameRT2 = psxCamera.GetCurrentFrameRT(2);
					CopyColorRespectFlipY(psxCamera.camera, cmd, currentFrameRT, currentFrameRT2, copyColorRespectFlipYMaterial);
					RTHandle currentFrameRT3 = psxCamera.GetCurrentFrameRT(1);
					cmd.SetRenderTarget(currentFrameRT, currentFrameRT3);
					SetViewport(cmd, currentFrameRT);
				}
			}
		}

		private static void TryDrawAccumulationMotionBlurPostUIOverlay(PSXCamera psxCamera, CommandBuffer cmd, Material accumulationMotionBlurMaterial)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_DrawAccumulationMotionBlurPostUIOverlay))
			{
				AccumulationMotionBlurVolume accumulationMotionBlurVolume = VolumeManager.instance.stack.GetComponent<AccumulationMotionBlurVolume>();
				if (!accumulationMotionBlurVolume)
				{
					accumulationMotionBlurVolume = AccumulationMotionBlurVolume.@default;
				}
				if (accumulationMotionBlurVolume.weight.value <= 1E-05f)
				{
					psxCamera.ResetAccumulationMotionBlurFrameCount();
				}
				if (psxCamera.GetCameraAccumulationMotionBlurFrameCount() != 0 && accumulationMotionBlurVolume.applyToUIOverlay.value)
				{
					PushAccumulationMotionBlurParameters(psxCamera, cmd, accumulationMotionBlurVolume);
					DrawFullScreenQuad(cmd, accumulationMotionBlurMaterial);
				}
			}
		}

		private static void TryDrawAccumulationMotionBlurFinalBlit(PSXCamera psxCamera, CommandBuffer cmd, RenderTexture renderTargetCurrent, Material copyColorRespectFlipYMaterial)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_DrawAccumulationMotionBlurFinalBlit))
			{
				AccumulationMotionBlurVolume accumulationMotionBlurVolume = VolumeManager.instance.stack.GetComponent<AccumulationMotionBlurVolume>();
				if (!accumulationMotionBlurVolume)
				{
					accumulationMotionBlurVolume = AccumulationMotionBlurVolume.@default;
				}
				if (psxCamera.GetCameraAccumulationMotionBlurFrameCount() != 0 && !accumulationMotionBlurVolume.applyToUIOverlay.value)
				{
					RTHandle currentFrameRT = psxCamera.GetCurrentFrameRT(2);
					RTHandle currentFrameRT2 = psxCamera.GetCurrentFrameRT(0);
					CopyColorRespectFlipY(psxCamera.camera, cmd, currentFrameRT, currentFrameRT2, copyColorRespectFlipYMaterial);
					cmd.SetRenderTarget(renderTargetCurrent);
					SetViewport(cmd, psxCamera.camera, renderTargetCurrent);
				}
			}
		}

		private static void PushAccumulationMotionBlurParameters(PSXCamera psxCamera, CommandBuffer cmd, AccumulationMotionBlurVolume volumeSettings)
		{
			RTHandle previousFrameRT = psxCamera.GetPreviousFrameRT(0);
			float value = volumeSettings.weight.value;
			value = Mathf.Min(value, 0.9999f);
			value = Mathf.Min(value, 1f - 1f / (float)(psxCamera.GetCameraAccumulationMotionBlurFrameCount() + 1));
			cmd.SetGlobalFloat(PSXShaderIDs._RasterizationHistoryWeight, value);
			cmd.SetGlobalFloat(PSXShaderIDs._RasterizationHistoryCompositeDither, volumeSettings.dither.value);
			cmd.SetGlobalVector(PSXShaderIDs._AccumulationMotionBlurParameters, new Vector4(volumeSettings.zoom.value * 10f, volumeSettings.vignette.value, volumeSettings.zoomDither.value, volumeSettings.anisotropy.value));
			cmd.SetGlobalTexture(PSXShaderIDs._RasterizationHistoryRT, previousFrameRT);
		}

		private static void CopyColorRespectFlipY(Camera camera, CommandBuffer cmd, RTHandle source, RTHandle destination, Material copyColorRespectFlipYMaterial)
		{
			cmd.SetGlobalVector(PSXShaderIDs._CopyColorSourceRTSize, new Vector4(source.rt.width, source.rt.height, 1f / (float)source.rt.width, 1f / (float)source.rt.height));
			cmd.SetGlobalTexture(PSXShaderIDs._CopyColorSourceRT, source);
			cmd.SetRenderTarget(destination);
			SetViewport(cmd, destination);
			DrawFullScreenQuad(cmd, copyColorRespectFlipYMaterial);
		}

		private static void PushCathodeRayTubeParameters(Camera camera, CommandBuffer cmd, Material crtMaterial)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushCathodeRayTubeParameters))
			{
				CathodeRayTubeVolume cathodeRayTubeVolume = VolumeManager.instance.stack.GetComponent<CathodeRayTubeVolume>();
				if (!cathodeRayTubeVolume)
				{
					cathodeRayTubeVolume = CathodeRayTubeVolume.@default;
				}
				cmd.SetGlobalInt(PSXShaderIDs._CRTIsEnabled, cathodeRayTubeVolume.isEnabled.value ? 1 : 0);
				cmd.SetGlobalFloat(PSXShaderIDs._CRTBloom, cathodeRayTubeVolume.bloom.value);
				switch (cathodeRayTubeVolume.grateMaskMode.value)
				{
				case CathodeRayTubeVolume.CRTGrateMaskMode.CompressedTV:
					crtMaterial.EnableKeyword(PSXShaderKeywords.s_CRT_MASK_COMPRESSED_TV);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_APERATURE_GRILL);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA_STRETCHED);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_TEXTURE);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_DISABLED);
					break;
				case CathodeRayTubeVolume.CRTGrateMaskMode.ApertureGrill:
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_COMPRESSED_TV);
					crtMaterial.EnableKeyword(PSXShaderKeywords.s_CRT_MASK_APERATURE_GRILL);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA_STRETCHED);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_TEXTURE);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_DISABLED);
					break;
				case CathodeRayTubeVolume.CRTGrateMaskMode.VGA:
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_COMPRESSED_TV);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_APERATURE_GRILL);
					crtMaterial.EnableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA_STRETCHED);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_TEXTURE);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_DISABLED);
					break;
				case CathodeRayTubeVolume.CRTGrateMaskMode.VGAStretched:
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_COMPRESSED_TV);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_APERATURE_GRILL);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA);
					crtMaterial.EnableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA_STRETCHED);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_TEXTURE);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_DISABLED);
					break;
				case CathodeRayTubeVolume.CRTGrateMaskMode.Texture:
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_COMPRESSED_TV);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_APERATURE_GRILL);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA_STRETCHED);
					crtMaterial.EnableKeyword(PSXShaderKeywords.s_CRT_MASK_TEXTURE);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_DISABLED);
					break;
				case CathodeRayTubeVolume.CRTGrateMaskMode.Disabled:
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_COMPRESSED_TV);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_APERATURE_GRILL);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_VGA_STRETCHED);
					crtMaterial.DisableKeyword(PSXShaderKeywords.s_CRT_MASK_TEXTURE);
					crtMaterial.EnableKeyword(PSXShaderKeywords.s_CRT_MASK_DISABLED);
					break;
				}
				if (cathodeRayTubeVolume.grateMaskMode.value == CathodeRayTubeVolume.CRTGrateMaskMode.Texture && cathodeRayTubeVolume.grateMaskTexture.value != null)
				{
					Texture2D texture2D = (Texture2D)cathodeRayTubeVolume.grateMaskTexture.value;
					cmd.SetGlobalTexture(PSXShaderIDs._CRTGrateMaskTexture, texture2D);
					cmd.SetGlobalVector(PSXShaderIDs._CRTGrateMaskSize, new Vector4(texture2D.width, texture2D.height, 1f / (float)texture2D.width, 1f / (float)texture2D.height));
				}
				else
				{
					cmd.SetGlobalTexture(PSXShaderIDs._CRTGrateMaskTexture, Texture2D.whiteTexture);
					cmd.SetGlobalVector(PSXShaderIDs._CRTGrateMaskSize, new Vector4(1f, 1f, 1f, 1f));
				}
				cmd.SetGlobalVector(PSXShaderIDs._CRTGrateMaskScale, new Vector2(cathodeRayTubeVolume.grateMaskScale.value, 1f / cathodeRayTubeVolume.grateMaskScale.value));
				cmd.SetGlobalFloat(PSXShaderIDs._CRTScanlineSharpness, Mathf.Lerp(-8f, -32f, cathodeRayTubeVolume.scanlineSharpness.value));
				cmd.SetGlobalFloat(PSXShaderIDs._CRTImageSharpness, Mathf.Lerp(-2f, -4f, cathodeRayTubeVolume.imageSharpness.value));
				cmd.SetGlobalVector(PSXShaderIDs._CRTBloomSharpness, new Vector2(Mathf.Lerp(-1f, -2f, cathodeRayTubeVolume.bloomSharpnessX.value), Mathf.Lerp(-1.5f, -4f, cathodeRayTubeVolume.bloomSharpnessY.value)));
				cmd.SetGlobalFloat(PSXShaderIDs._CRTNoiseIntensity, cathodeRayTubeVolume.noiseIntensity.value);
				cmd.SetGlobalFloat(PSXShaderIDs._CRTNoiseSaturation, cathodeRayTubeVolume.noiseSaturation.value);
				cmd.SetGlobalVector(PSXShaderIDs._CRTGrateMaskIntensityMinMax, new Vector2(cathodeRayTubeVolume.grateMaskIntensityMin.value * 2f, cathodeRayTubeVolume.grateMaskIntensityMax.value * 2f));
				cmd.SetGlobalVector(PSXShaderIDs._CRTBarrelDistortion, new Vector2(cathodeRayTubeVolume.barrelDistortionX.value * 0.125f, cathodeRayTubeVolume.barrelDistortionY.value * 0.125f));
				cmd.SetGlobalFloat(PSXShaderIDs._CRTVignetteSquared, cathodeRayTubeVolume.vignette.value * cathodeRayTubeVolume.vignette.value);
			}
		}

		private static void DrawSceneViewUI(Camera camera)
		{
		}

		private static void DrawBackgroundOpaque(ScriptableRenderContext context, Camera camera, ref CullingResults cullingResults)
		{
			DrawOpaque(context, camera, PSXRenderQueue.k_RenderQueue_BackgroundAllOpaque, ref cullingResults);
		}

		private static void DrawBackgroundTransparent(ScriptableRenderContext context, Camera camera, ref CullingResults cullingResults)
		{
			DrawTransparent(context, camera, PSXRenderQueue.k_RenderQueue_BackgroundTransparent, ref cullingResults);
		}

		private static void DrawMainOpaque(ScriptableRenderContext context, Camera camera, ref CullingResults cullingResults)
		{
			DrawOpaque(context, camera, PSXRenderQueue.k_RenderQueue_MainAllOpaque, ref cullingResults);
		}

		private static void DrawMainTransparent(ScriptableRenderContext context, Camera camera, ref CullingResults cullingResults)
		{
			DrawTransparent(context, camera, PSXRenderQueue.k_RenderQueue_MainTransparent, ref cullingResults);
		}

		private static void DrawUIOverlayOpaque(ScriptableRenderContext context, Camera camera, ref CullingResults cullingResults)
		{
			DrawOpaque(context, camera, PSXRenderQueue.k_RenderQueue_UIOverlayAllOpaque, ref cullingResults);
		}

		private static void DrawUIOverlayTransparent(ScriptableRenderContext context, Camera camera, ref CullingResults cullingResults)
		{
			DrawTransparent(context, camera, PSXRenderQueue.k_RenderQueue_UIOverlayTransparent, ref cullingResults);
		}

		private static void DrawOpaque(ScriptableRenderContext context, Camera camera, RenderQueueRange range, ref CullingResults cullingResults)
		{
			SortingCriteria criteria = (EvaluateIsDepthBufferEnabledFromVolume() ? SortingCriteria.CommonOpaque : (SortingCriteria.CommonTransparent | SortingCriteria.CanvasOrder));
			SortingSettings sortingSettings = new SortingSettings(camera);
			sortingSettings.criteria = criteria;
			SortingSettings sortingSettings2 = sortingSettings;
			DrawingSettings drawingSettings = new DrawingSettings(PSXShaderPassNames.s_PSXLit, sortingSettings2);
			drawingSettings.perObjectData = ComputePerObjectDataFromLightingVolume(camera);
			DrawingSettings drawingSettings2 = drawingSettings;
			FilteringSettings filteringSettings = new FilteringSettings(range, camera.cullingMask);
			context.DrawRenderers(cullingResults, ref drawingSettings2, ref filteringSettings);
		}

		private static void DrawTransparent(ScriptableRenderContext context, Camera camera, RenderQueueRange range, ref CullingResults cullingResults)
		{
			SortingSettings sortingSettings = new SortingSettings(camera);
			sortingSettings.criteria = SortingCriteria.CommonTransparent;
			SortingSettings sortingSettings2 = sortingSettings;
			DrawingSettings drawingSettings = new DrawingSettings(PSXShaderPassNames.s_PSXLit, sortingSettings2);
			drawingSettings.perObjectData = ComputePerObjectDataFromLightingVolume(camera);
			DrawingSettings drawingSettings2 = drawingSettings;
			FilteringSettings filteringSettings = new FilteringSettings(range, camera.cullingMask);
			context.DrawRenderers(cullingResults, ref drawingSettings2, ref filteringSettings);
		}

		private static void DrawSkybox(ScriptableRenderContext context, Camera camera)
		{
			context.DrawSkybox(camera);
		}

		private static void DrawLegacyCanvasUI(ScriptableRenderContext context, Camera camera, ref CullingResults cullingResults)
		{
			SortingSettings sortingSettings = new SortingSettings(camera);
			sortingSettings.criteria = SortingCriteria.CommonTransparent;
			SortingSettings sortingSettings2 = sortingSettings;
			DrawingSettings drawingSettings = new DrawingSettings(PSXShaderPassNames.s_SRPDefaultUnlit, sortingSettings2);
			FilteringSettings filteringSettings = new FilteringSettings(RenderQueueRange.all, camera.cullingMask);
			context.DrawRenderers(cullingResults, ref drawingSettings, ref filteringSettings);
		}

		private static void SetViewport(CommandBuffer cmd, RTHandle target)
		{
			CoreUtils.SetViewport(cmd, target);
		}

		private static void SetViewport(CommandBuffer cmd, Camera camera, RenderTexture target)
		{
			int num = camera.pixelWidth;
			int num2 = camera.pixelHeight;
			if (target != null)
			{
				num = target.width;
				num2 = target.height;
			}
			cmd.SetViewport(new Rect(0f, 0f, num, num2));
		}

		private static void DrawFullScreenQuad(CommandBuffer cmd, Material material, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			cmd.DrawMesh(fullscreenMesh, Matrix4x4.identity, material);
		}

		private static void DrawGizmos(ScriptableRenderContext context, Camera camera, GizmoSubset gizmoSubset)
		{
		}

		public static bool IsComputeShaderSupportedPlatform()
		{
			if (!SystemInfo.supportsComputeShaders)
			{
				return false;
			}
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.PS4 || Application.platform == RuntimePlatform.XboxOne || Application.platform == RuntimePlatform.Switch || Application.platform == RuntimePlatform.Stadia)
			{
				return true;
			}
			return false;
		}

		public static RenderTextureFormat GetFrameBufferRenderTextureFormatHDR(out bool hdrIsSupported)
		{
			hdrIsSupported = false;
			return RenderTextureFormat.ARGB32;
		}

		private static bool ComputeCameraProjectionIsFlippedY(Camera camera)
		{
			return GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: true).inverse.MultiplyPoint(new Vector3(0f, 1f, 0f)).y < 0f;
		}

		private static Matrix4x4 ComputePixelCoordToWorldSpaceViewDirectionMatrix(Camera camera, Matrix4x4 viewMatrix, Vector4 resolution, float aspect = -1f)
		{
			float verticalFoV = camera.GetGateFittedFieldOfView() * (MathF.PI / 180f);
			Vector2 gateFittedLensShift = camera.GetGateFittedLensShift();
			return ComputePixelCoordToWorldSpaceViewDirectionMatrix(verticalFoV, gateFittedLensShift, resolution, viewMatrix, renderToCubemap: false, aspect);
		}

		private static Matrix4x4 ComputePixelCoordToWorldSpaceViewDirectionMatrix(float verticalFoV, Vector2 lensShift, Vector4 screenSize, Matrix4x4 worldToViewMatrix, bool renderToCubemap, float aspectRatio = -1f)
		{
			aspectRatio = ((aspectRatio < 0f) ? (screenSize.x * screenSize.w) : aspectRatio);
			float num = Mathf.Tan(0.5f * verticalFoV);
			float num2 = (1f - 2f * lensShift.y) * num;
			float num3 = -2f * screenSize.w * num;
			float x = (1f - 2f * lensShift.x) * num * aspectRatio;
			float x2 = -2f * screenSize.z * num * aspectRatio;
			if (renderToCubemap)
			{
				num3 = 0f - num3;
				num2 = 0f - num2;
			}
			Matrix4x4 matrix4x = new Matrix4x4(new Vector4(x2, 0f, 0f, 0f), new Vector4(0f, num3, 0f, 0f), new Vector4(x, num2, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));
			Vector4 column = new Vector4(0f, 0f, 0f, 1f);
			worldToViewMatrix.SetColumn(3, column);
			worldToViewMatrix.SetRow(2, -worldToViewMatrix.GetRow(2));
			return Matrix4x4.Transpose(worldToViewMatrix.transpose * matrix4x);
		}

		private static float GetAnimatedMaterialsTime(Camera camera)
		{
			float num = 0f;
			if (CoreUtils.AreAnimatedMaterialsEnabled(camera))
			{
				return Time.timeSinceLevelLoad;
			}
			return 0f;
		}

		private void AllocateLighting()
		{
			Lightmapping.SetDelegate(lightsDelegate);
		}

		private void DisposeLighting()
		{
			Lightmapping.ResetDelegate();
		}

		private void PushDynamicLightingParameters(Camera camera, CommandBuffer cmd, ref CullingResults cullingResults)
		{
			using (new ProfilingScope(cmd, PSXProfilingSamplers.s_PushDynamicLightingParameters))
			{
				m_MixedLightingSetup = MixedLightingSetup.None;
				CoreUtils.SetKeyword(cmd, PSXShaderKeywords.k_LIGHTMAP_SHADOW_MASK, state: false);
				LightingVolume lightingVolume = VolumeManager.instance.stack.GetComponent<LightingVolume>();
				if (!lightingVolume)
				{
					lightingVolume = LightingVolume.@default;
				}
				if (!(lightingVolume.lightingIsEnabled.value & !CoreUtils.IsSceneLightingDisabled(camera)) || lightingVolume.dynamicLightingMultiplier.value == 0f)
				{
					return;
				}
				int value = lightingVolume.dynamicLightsMaxCount.value;
				int value2 = lightingVolume.dynamicLightsMaxPerObjectCount.value;
				if (value == 0)
				{
					return;
				}
				EnsureAdditionalLightData(value);
				if (SetupPerObjectLightIndices(camera, ref cullingResults, value) == 0)
				{
					cmd.SetGlobalVector(PSXShaderIDs._AdditionalLightsCount, Vector4.zero);
					return;
				}
				int i = 0;
				int num = 0;
				for (; i < cullingResults.visibleLights.Length; i++)
				{
					if (num >= value)
					{
						break;
					}
					if (IsLightLayerVisible(cullingResults.visibleLights[i].light.gameObject.layer, camera.cullingMask))
					{
						InitializeLightConstants(cullingResults.visibleLights, i, out m_AdditionalLightPositions[num], out m_AdditionalLightColors[num], out m_AdditionalLightAttenuations[num], out m_AdditionalLightSpotDirections[num], out m_AdditionalLightOcclusionProbeChannels[num]);
						num++;
					}
				}
				cmd.SetGlobalVectorArray(PSXShaderIDs._AdditionalLightsPosition, m_AdditionalLightPositions);
				cmd.SetGlobalVectorArray(PSXShaderIDs._AdditionalLightsColor, m_AdditionalLightColors);
				cmd.SetGlobalVectorArray(PSXShaderIDs._AdditionalLightsAttenuation, m_AdditionalLightAttenuations);
				cmd.SetGlobalVectorArray(PSXShaderIDs._AdditionalLightsSpotDir, m_AdditionalLightSpotDirections);
				cmd.SetGlobalVectorArray(PSXShaderIDs._AdditionalLightOcclusionProbeChannel, m_AdditionalLightOcclusionProbeChannels);
				cmd.SetGlobalVector(PSXShaderIDs._AdditionalLightsCount, new Vector4(value2, 0f, 0f, 0f));
				CoreUtils.SetKeyword(cmd, PSXShaderKeywords.k_LIGHTMAP_SHADOW_MASK, m_MixedLightingSetup == MixedLightingSetup.ShadowMask);
			}
		}

		private bool IsLightLayerVisible(int lightLayer, int cullingMask)
		{
			return ((1 << lightLayer) & cullingMask) > 0;
		}

		private void EnsureAdditionalLightData(int capacity)
		{
			if (m_AdditionalLightPositions == null || m_AdditionalLightPositions.Length < capacity)
			{
				m_AdditionalLightPositions = new Vector4[capacity];
				m_AdditionalLightColors = new Vector4[capacity];
				m_AdditionalLightAttenuations = new Vector4[capacity];
				m_AdditionalLightSpotDirections = new Vector4[capacity];
				m_AdditionalLightOcclusionProbeChannels = new Vector4[capacity];
			}
		}

		private int SetupPerObjectLightIndices(Camera camera, ref CullingResults cullingResults, int dynamicLightsMaxCount)
		{
			NativeArray<VisibleLight> visibleLights = cullingResults.visibleLights;
			NativeArray<int> lightIndexMap = cullingResults.GetLightIndexMap(Allocator.Temp);
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < visibleLights.Length; i++)
			{
				if (num2 >= dynamicLightsMaxCount)
				{
					break;
				}
				if (!IsLightLayerVisible(visibleLights[i].light.gameObject.layer, camera.cullingMask))
				{
					lightIndexMap[i] = -1;
					num++;
				}
				else
				{
					lightIndexMap[i] -= num;
					num2++;
				}
			}
			for (int j = num + num2; j < lightIndexMap.Length; j++)
			{
				lightIndexMap[j] = -1;
			}
			cullingResults.SetLightIndexMap(lightIndexMap);
			lightIndexMap.Dispose();
			return num2;
		}

		private void InitializeLightConstants(NativeArray<VisibleLight> lights, int lightIndex, out Vector4 lightPos, out Vector4 lightColor, out Vector4 lightAttenuation, out Vector4 lightSpotDir, out Vector4 lightOcclusionProbeChannel)
		{
			lightPos = k_DefaultLightPosition;
			lightColor = k_DefaultLightColor;
			lightAttenuation = k_DefaultLightAttenuation;
			lightSpotDir = k_DefaultLightSpotDirection;
			lightOcclusionProbeChannel = k_DefaultLightsProbeChannel;
			if (lightIndex >= 0)
			{
				VisibleLight visibleLight = lights[lightIndex];
				if (visibleLight.lightType == UnityEngine.LightType.Directional)
				{
					Vector4 vector = -visibleLight.localToWorldMatrix.GetColumn(2);
					lightPos = new Vector4(vector.x, vector.y, vector.z, 0f);
				}
				else
				{
					Vector4 column = visibleLight.localToWorldMatrix.GetColumn(3);
					lightPos = new Vector4(column.x, column.y, column.z, 1f);
				}
				lightColor = visibleLight.finalColor.linear;
				if (visibleLight.lightType != UnityEngine.LightType.Directional)
				{
					float num = visibleLight.range * visibleLight.range;
					float num2 = 0.64000005f * num - num;
					float num3 = 1f / num2;
					float y = (0f - num) / num2;
					float num4 = 1f / Mathf.Max(0.0001f, visibleLight.range * visibleLight.range);
					lightAttenuation.x = ((Application.isMobilePlatform || SystemInfo.graphicsDeviceType == GraphicsDeviceType.Switch) ? num3 : num4);
					lightAttenuation.y = y;
				}
				if (visibleLight.lightType == UnityEngine.LightType.Spot)
				{
					Vector4 column2 = visibleLight.localToWorldMatrix.GetColumn(2);
					lightSpotDir = new Vector4(0f - column2.x, 0f - column2.y, 0f - column2.z, 0f);
					float num5 = Mathf.Cos(MathF.PI / 180f * visibleLight.spotAngle * 0.5f);
					float num6 = ((!(visibleLight.light != null)) ? Mathf.Cos(2f * Mathf.Atan(Mathf.Tan(visibleLight.spotAngle * 0.5f * (MathF.PI / 180f)) * 46f / 64f) * 0.5f) : Mathf.Cos(visibleLight.light.innerSpotAngle * (MathF.PI / 180f) * 0.5f));
					float num7 = Mathf.Max(0.001f, num6 - num5);
					float num8 = 1f / num7;
					float w = (0f - num5) * num8;
					lightAttenuation.z = num8;
					lightAttenuation.w = w;
				}
				Light light = visibleLight.light;
				int num9 = ((light != null) ? light.bakingOutput.occlusionMaskChannel : (-1));
				lightOcclusionProbeChannel.x = num9;
				lightOcclusionProbeChannel.y = ((num9 == -1) ? 1f : light.shadowStrength);
				if (light.bakingOutput.lightmapBakeType == LightmapBakeType.Mixed && visibleLight.light.shadows != LightShadows.None && m_MixedLightingSetup == MixedLightingSetup.None && light.bakingOutput.mixedLightingMode == MixedLightingMode.Shadowmask)
				{
					m_MixedLightingSetup = MixedLightingSetup.ShadowMask;
				}
			}
		}
	}
}
