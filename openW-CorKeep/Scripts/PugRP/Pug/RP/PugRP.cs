using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;

namespace Pug.RP
{
	public class PugRP : RenderPipeline
	{
		public static readonly ShaderTagId[] forwardShaderTagIds = new ShaderTagId[2]
		{
			new ShaderTagId("UniversalForward"),
			new ShaderTagId("SRPDefaultUnlit")
		};

		public static readonly ShaderTagId shadowCasterShaderTagId = new ShaderTagId("ShadowCaster");

		public static readonly ShaderTagId shadowCasterCubeShaderTagId = new ShaderTagId("ShadowCasterCube");

		private static GlobalKeyword s_disableIndirectKeyword = GlobalKeyword.Create("DISABLE_INDIRECT");

		private static GlobalKeyword s_enableRaymarchedShadowKeyword = GlobalKeyword.Create("ENABLE_RAYMARCHED_SHADOW");

		private static GlobalKeyword s_enableRaymapShadowKeyword = GlobalKeyword.Create("ENABLE_RAYMAP_SHADOW");

		private static GlobalKeyword s_enableShadowmapKeyword = GlobalKeyword.Create("ENABLE_SHADOWMAP");

		private static GlobalKeyword s_enableSoftShadowKeyword = GlobalKeyword.Create("ENABLE_SOFT_SHADOW");

		private static GlobalKeyword s_shadowFilterQualityLowKeyword = GlobalKeyword.Create("SHADOW_FILTER_QUALITY_LOW");

		private static GlobalKeyword s_shadowFilterQualityMediumKeyword = GlobalKeyword.Create("SHADOW_FILTER_QUALITY_MEDIUM");

		private static GlobalKeyword s_shadowFilterQualityHighKeyword = GlobalKeyword.Create("SHADOW_FILTER_QUALITY_HIGH");

		private static GlobalKeyword s_enableSpriteLightRimKeyword = GlobalKeyword.Create("ENABLE_SPRITE_LIGHT_RIM");

		private static GlobalKeyword s_applyVolumetricLightingKeyword = GlobalKeyword.Create("APPLY_VOLUMETRIC_LIGHTING");

		private static readonly string s_directionalLightsSampleName = "Directional Lights";

		public const int DEFERRED_PASS_SCREEN = 0;

		public const int DEFERRED_PASS_SCREEN_ADDITIVE = 1;

		public const int DEFERRED_PASS_DIRECTIONAL = 2;

		public const int DEFERRED_PASS_POINTLIGHT = 3;

		public const int DEFERRED_PASS_SPOTLIGHT = 4;

		public const CullingOptions DEFAULT_CULL_OPTIONS = CullingOptions.ForceEvenIfCameraIsNotActive | CullingOptions.NeedsLighting | CullingOptions.DisablePerObjectCulling;

		private static PugRenderPipelineAsset s_currentRenderPipelineAsset;

		public static int cullOps;

		public static bool skipPixelFilter;

		public static HashSet<Light> visibleLights = new HashSet<Light>();

		public static Vector3 origin = Vector3.zero;

		private static Vector3 s_prevOrigin;

		public static CullingResults sharedCullingResults;

		private static string s_deferredLightingSampleName = "Deferred Lighting";

		private static string s_forwardOpaqueSampleName = "Forward Opaque";

		private static string s_forwardTransparentSampleName = "Forward Transparent";

		private static Dictionary<Camera, CameraData> s_cameraData = new Dictionary<Camera, CameraData>();

		private static Material s_deferredMaterial;

		private static Material s_colorResolveMaterial;

		private static Material s_finalBlitMaterial;

		private static readonly Vector4[] s_cameraCorners = new Vector4[4];

		private static readonly Vector4[] s_cameraRays = new Vector4[4];

		private static LightData s_pointLightData = new LightData();

		private static LightData s_spotlightData = new LightData();

		private static int s_forcedLightUpdateIndex = 0;

		private CameraRender m_cameraRenderer = new CameraRender();

		private Texture2D m_bluenoise64;

		private static int s_frameIndex;

		private static int s_frameIndex128;

		private CommandBuffer m_cmd;

		private Stopwatch m_frameTimer = new Stopwatch();

		private Stopwatch m_internalTimer = new Stopwatch();

		private static Camera s_sharedCullingCamera;

		private static Bounds s_sharedCullBounds;

		private static int s_sharedCullingMask;

		private static CullingOptions s_sharedCullingOptions;

		private static bool s_isMainCameraPass;

		public static readonly List<Bounds> sharedCullBounds = new List<Bounds>();

		public static Camera currentCameraPropertiesSource { get; private set; }

		public static PugRenderPipelineAsset asset => s_currentRenderPipelineAsset;

		public static float frametimeMS { get; private set; }

		public static float avgFrametimeMS => avgFrametimer.value;

		public static float minFrametimeMS => avgFrametimer.min;

		public static float maxFrametimeMS => avgFrametimer.max;

		public static int frameIndex => s_frameIndex;

		public static Vector3 originShift { get; private set; }

		public static Material deferredMaterial => s_deferredMaterial;

		public static Material colorResolveMaterial => s_colorResolveMaterial;

		public static Material finalBlitMaterial => s_finalBlitMaterial;

		public static LightData pointLightData => s_pointLightData;

		public static LightData spotlightData => s_spotlightData;

		public static AvgFloat avgFrametimer { get; private set; } = new AvgFloat(50, 500);

		public static AvgFloat avgInternalTime { get; private set; } = new AvgFloat(50, 500);

		public static bool useSharedCullPass { get; private set; }

		public static event Action<PugRPContext, CommandBuffer, RenderTargetIdentifier, RenderTargetIdentifier, RenderTextureDescriptor> onPostProcessOpaque;

		public static event Action onDispose;

		public PugRP()
		{
			Shader.globalRenderPipeline = "UniversalPipeline";
			s_frameIndex = 0;
			s_frameIndex128 = 0;
			skipPixelFilter = false;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				if (commandLineArgs[i] == "-nopixelfilter")
				{
					skipPixelFilter = true;
				}
			}
		}

		public static CameraData GetOrCreateCameraData(Camera camera)
		{
			if (!s_cameraData.TryGetValue(camera, out var value))
			{
				value = new CameraData();
				s_cameraData.Add(camera, value);
			}
			return value;
		}

		public static bool TryGetCameraData(Camera camera, out CameraData cameraData)
		{
			return s_cameraData.TryGetValue(camera, out cameraData);
		}

		public static void DrawShadowGeometry(ScriptableRenderContext context, CommandBuffer cmd, Camera camera, CullingResults cullingResults)
		{
			RendererListDesc rendererListDesc = new RendererListDesc(shadowCasterShaderTagId, cullingResults, camera);
			rendererListDesc.sortingCriteria = SortingCriteria.OptimizeStateChanges;
			rendererListDesc.renderQueueRange = RenderQueueRange.opaque;
			rendererListDesc.layerMask = asset.shadowCastingLayers;
			RendererListDesc desc = rendererListDesc;
			RendererList rendererList = context.CreateRendererList(desc);
			cmd.DrawRendererList(rendererList);
		}

		public static void DrawDeferredLight(CommandBuffer cmd, DeferredLightPass passes = DeferredLightPass.DirectAndIndirect, bool isVolumetricInput = false)
		{
			cmd.BeginSample(s_deferredLightingSampleName);
			bool flag = asset.highPerformanceLightMode && !isVolumetricInput;
			cmd.SetKeyword(in s_applyVolumetricLightingKeyword, flag);
			if (passes == DeferredLightPass.IndirectOnly || passes == DeferredLightPass.DirectAndIndirect)
			{
				cmd.SetKeyword(in s_disableIndirectKeyword, passes == DeferredLightPass.DirectOnly);
				cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, deferredMaterial, 0, isVolumetricInput ? 1 : 0);
			}
			if (!flag && (passes == DeferredLightPass.DirectOnly || passes == DeferredLightPass.DirectAndIndirect))
			{
				foreach (Light visibleLight in visibleLights)
				{
					if (visibleLight.type == LightType.Directional)
					{
						DrawDirectionalLight(cmd, visibleLight);
					}
				}
				SetShadowTypeKeywords(cmd, asset.punctualShadowsType);
				s_pointLightData.Draw(cmd);
				s_spotlightData.Draw(cmd);
			}
			cmd.SetKeyword(in s_applyVolumetricLightingKeyword, value: false);
			cmd.EndSample(s_deferredLightingSampleName);
		}

		private static void SetShadowTypeKeywords(CommandBuffer cmd, ShadowsType shadowsType)
		{
			cmd.SetKeyword(in s_enableRaymarchedShadowKeyword, shadowsType == ShadowsType.Raymarching);
			cmd.SetKeyword(in s_enableRaymapShadowKeyword, shadowsType == ShadowsType.Raymap);
		}

		private static void DrawDirectionalLight(CommandBuffer cmd, Light light)
		{
			PugLight pugLight = light.GetPugLight();
			if (light.shadows != LightShadows.None && pugLight.directionalShadowsType == ShadowsType.Shadowmap && pugLight.directionalDepthTexture != null)
			{
				RenderTexture directionalDepthTexture = pugLight.directionalDepthTexture;
				cmd.SetGlobalTexture(ShaderIDs.LightDepthTexture, directionalDepthTexture);
				cmd.SetGlobalVector(ShaderIDs.LightDepthTextureSize, new Vector4(directionalDepthTexture.width, directionalDepthTexture.height, 1f / (float)directionalDepthTexture.width, 1f / (float)directionalDepthTexture.height));
				cmd.SetGlobalFloat(ShaderIDs.DirectionalShadowBias, PugRPUtils.GetShadowBias(directionalDepthTexture.width, asset.directionalShadowBias));
				cmd.SetKeyword(in s_enableShadowmapKeyword, value: true);
				cmd.SetKeyword(in s_enableSoftShadowKeyword, light.shadows == LightShadows.Soft);
			}
			else
			{
				cmd.SetKeyword(in s_enableShadowmapKeyword, value: false);
			}
			ShadowsType shadowsType = ((light.shadows != LightShadows.None) ? pugLight.directionalShadowsType : ShadowsType.Shadowmap);
			SetShadowTypeKeywords(cmd, shadowsType);
			cmd.SetGlobalVector(ShaderIDs.LightDir, -light.transform.forward);
			cmd.SetGlobalVector(ShaderIDs.LightColor, light.color * light.intensity);
			cmd.SetGlobalTexture(ShaderIDs.LightColorTexture, pugLight.directionalColorTexture);
			cmd.SetGlobalMatrix(ShaderIDs.WorldToLight, pugLight.directionalMatrix);
			cmd.SetGlobalFloat(ShaderIDs.ShadowRange, pugLight.directionalRaymarchedShadowsRange);
			cmd.SetGlobalFloat(ShaderIDs.ShadowBias, pugLight.directionalRaymarchedShadowsBias);
			cmd.SetGlobalFloat(ShaderIDs.RaymarchSkyTest, pugLight.directionalRaymarchedSkyTest ? 1 : 0);
			cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, deferredMaterial, 0, 2);
			cmd.SetGlobalFloat(ShaderIDs.RaymarchSkyTest, 0f);
		}

		public static void DrawForwardOpaque(PugRPContext context, CommandBuffer cmd, Camera camera, CullingResults cullingResults)
		{
			cmd.BeginSample(s_forwardOpaqueSampleName);
			RendererListDesc rendererListDesc = new RendererListDesc(forwardShaderTagIds, cullingResults, camera);
			rendererListDesc.renderQueueRange = RenderQueueRange.opaque;
			rendererListDesc.sortingCriteria = SortingCriteria.OptimizeStateChanges;
			rendererListDesc.layerMask = camera.cullingMask;
			RendererListDesc desc = rendererListDesc;
			RendererList rendererList = context.srp.CreateRendererList(desc);
			cmd.DrawRendererList(rendererList);
			cmd.EndSample(s_forwardOpaqueSampleName);
		}

		public static void DrawForwardOpaque(PugRPContext context, CommandBuffer cmd)
		{
			DrawForwardOpaque(context, cmd, context.camera, context.cameraData.GetCullingResults());
		}

		public static void DrawForwardTransparent(ScriptableRenderContext context, CommandBuffer cmd, Camera camera, CullingResults cullingResults, RenderQueueRange queueRange)
		{
			RendererListDesc rendererListDesc = new RendererListDesc(forwardShaderTagIds, cullingResults, camera);
			rendererListDesc.renderQueueRange = queueRange;
			rendererListDesc.sortingCriteria = SortingCriteria.CommonTransparent;
			rendererListDesc.layerMask = camera.cullingMask;
			RendererListDesc desc = rendererListDesc;
			RendererList rendererList = context.CreateRendererList(desc);
			cmd.DrawRendererList(rendererList);
		}

		private static void DrawForwardTransparent(PugRPContext context, CommandBuffer cmd, Camera camera, CullingResults cullingResults, RenderQueueRange queueRange)
		{
			cmd.BeginSample(s_forwardTransparentSampleName);
			DrawForwardTransparent(context.srp, cmd, camera, cullingResults, queueRange);
			cmd.EndSample(s_forwardTransparentSampleName);
		}

		public static void DrawForwardTransparent(PugRPContext context, CommandBuffer cmd, Camera camera, CullingResults cullingResults)
		{
			DrawForwardTransparent(context, cmd, camera, cullingResults, RenderQueueRange.transparent);
		}

		public static void DrawForwardTransparent(PugRPContext context, CommandBuffer cmd)
		{
			if (context.shouldCreateOpaqueTexture)
			{
				RenderQueueRange transparent = RenderQueueRange.transparent;
				RenderQueueRange transparent2 = RenderQueueRange.transparent;
				transparent.upperBound = 2889;
				transparent2.lowerBound = 2890;
				CullingResults cullingResults = context.cameraData.GetCullingResults();
				DrawForwardTransparent(context, cmd, context.camera, cullingResults, transparent);
				context.UpdateOpaqueTexture(cmd);
				DrawForwardTransparent(context, cmd, context.camera, cullingResults, transparent2);
			}
			else
			{
				DrawForwardTransparent(context, cmd, context.camera, context.cameraData.GetCullingResults(), RenderQueueRange.transparent);
			}
		}

		public static void PostProcessOpaque(PugRPContext context, CommandBuffer cmd, RenderTargetIdentifier target, RenderTargetIdentifier targetDepth, RenderTextureDescriptor textureDescriptor)
		{
			cmd.SetRenderTarget(target);
			PugRP.onPostProcessOpaque?.Invoke(context, cmd, target, targetDepth, textureDescriptor);
		}

		public static Color GetCameraClearColor(Camera camera)
		{
			return camera.backgroundColor;
		}

		private static void UpdateCurrentRenderPipelineAsset()
		{
			RenderPipelineAsset renderPipelineAssetAt = QualitySettings.GetRenderPipelineAssetAt(QualitySettings.GetQualityLevel());
			s_currentRenderPipelineAsset = (renderPipelineAssetAt ? renderPipelineAssetAt : GraphicsSettings.defaultRenderPipeline) as PugRenderPipelineAsset;
		}

		protected override void Render(ScriptableRenderContext context, List<Camera> cameras)
		{
			originShift = origin - s_prevOrigin;
			UpdateCurrentRenderPipelineAsset();
			if (cameras.Count < 1)
			{
				return;
			}
			m_internalTimer.Restart();
			if (cameras.Contains(Camera.main))
			{
				frametimeMS = (float)m_frameTimer.Elapsed.TotalMilliseconds;
				avgFrametimer.AddSample(frametimeMS);
				m_frameTimer.Restart();
			}
			cullOps = 0;
			currentCameraPropertiesSource = null;
			GraphicsSettings.useScriptableRenderPipelineBatching = asset.enableSRPBatching;
			PugRPUtils.EnsureLoadedResource(ref s_deferredMaterial, "Materials/Deferred");
			if (s_colorResolveMaterial == null)
			{
				s_colorResolveMaterial = CoreUtils.CreateEngineMaterial("Hidden/PugRP/ColorResolve");
			}
			if (s_finalBlitMaterial == null)
			{
				s_finalBlitMaterial = CoreUtils.CreateEngineMaterial("Hidden/PugRP/FinalBlit");
			}
			if (m_cmd == null)
			{
				m_cmd = new CommandBuffer
				{
					name = "Camera Stack"
				};
			}
			m_cmd.Clear();
			RenderPipeline.BeginContextRendering(context, cameras);
			BeginFrame(context, cameras);
			SetGlobalShaderParameters(m_cmd);
			foreach (Camera camera in cameras)
			{
				m_cameraRenderer.RenderBeforeLightUpdate(context, m_cmd, camera);
			}
			context.ExecuteCommandBuffer(m_cmd);
			m_cmd.Clear();
			UpdateLights(context, cameras);
			m_cmd.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);
			m_cmd.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			foreach (Camera camera2 in cameras)
			{
				RenderPipeline.BeginCameraRendering(context, camera2);
				m_cameraRenderer.Render(context, m_cmd, camera2);
				RenderPipeline.EndCameraRendering(context, camera2);
			}
			context.ExecuteCommandBuffer(m_cmd);
			context.Submit();
			RenderPipeline.EndContextRendering(context, cameras);
			avgInternalTime.AddSample((float)m_internalTimer.Elapsed.TotalMilliseconds);
			s_prevOrigin = origin;
		}

		protected override void Render(ScriptableRenderContext context, Camera[] cameras)
		{
		}

		private void BeginFrame(ScriptableRenderContext context, List<Camera> cameras)
		{
			SetupAndCull(context, cameras);
		}

		public static void AppendSharedCullData(Bounds bounds, int cullingMask, CullingOptions cullingOptions)
		{
			sharedCullBounds.Add(bounds);
			s_sharedCullingMask |= cullingMask;
			s_sharedCullingOptions |= cullingOptions;
		}

		private void SetupAndCull(ScriptableRenderContext context, List<Camera> cameras)
		{
			s_isMainCameraPass = cameras.Contains(Camera.main);
			useSharedCullPass = asset.sharedCullPass && s_isMainCameraPass;
			if (useSharedCullPass)
			{
				sharedCullBounds.Clear();
				s_sharedCullBounds = new Bounds(cameras[0].transform.position, Vector3.zero);
				s_sharedCullingMask = asset.shadowCastingLayers;
				s_sharedCullingOptions = CullingOptions.None;
				for (int i = 0; i < PugLight.instances.Count; i++)
				{
					PugLight pugLight = PugLight.instances[i];
					if (pugLight.light != null && !pugLight.light.Equals(null) && pugLight.light.type == LightType.Directional)
					{
						s_sharedCullingMask |= pugLight.light.cullingMask;
					}
				}
			}
			for (int j = 0; j < cameras.Count; j++)
			{
				Camera camera = cameras[j];
				Camera.onPreCull?.Invoke(camera);
				m_cameraRenderer.SetupAndCull(context, camera);
			}
			if (useSharedCullPass)
			{
				PerformSharedCull(context);
			}
		}

		private void PerformSharedCull(ScriptableRenderContext context)
		{
			if (s_sharedCullingCamera == null)
			{
				s_sharedCullingCamera = PugRPUtils.GetUtilityCamera("PUGRP_SHARED_CULL_CAMERA");
			}
			if (sharedCullBounds.Count < 1)
			{
				UnityEngine.Debug.LogError("No cull bounds reported, cannot perform shared cull!");
				return;
			}
			Bounds bounds = sharedCullBounds[0];
			Vector3 vector = bounds.min;
			Vector3 vector2 = bounds.max;
			for (int i = 1; i < sharedCullBounds.Count; i++)
			{
				Bounds bounds2 = sharedCullBounds[i];
				vector = Vector3.Min(vector, bounds2.min);
				vector2 = Vector3.Max(vector2, bounds2.max);
			}
			s_sharedCullBounds = new Bounds((vector2 + vector) / 2f, vector2 - vector);
			Vector3 extents = s_sharedCullBounds.extents;
			s_sharedCullingCamera.transform.position = s_sharedCullBounds.center - Vector3.forward * s_sharedCullBounds.extents.z;
			s_sharedCullingCamera.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
			if (asset.alignSharedCullCamera && Camera.main != null)
			{
				Camera main = Camera.main;
				Vector3 min = s_sharedCullBounds.min;
				Vector3 max = s_sharedCullBounds.max;
				Vector3 point = new Vector3(min.x, min.y, min.z);
				Vector3 point2 = new Vector3(max.x, min.y, min.z);
				Vector3 point3 = new Vector3(min.x, max.y, min.z);
				Vector3 point4 = new Vector3(max.x, max.y, min.z);
				Vector3 point5 = new Vector3(min.x, min.y, max.z);
				Vector3 point6 = new Vector3(max.x, min.y, max.z);
				Vector3 point7 = new Vector3(min.x, max.y, max.z);
				Vector3 point8 = new Vector3(max.x, max.y, max.z);
				Matrix4x4 inverse = Matrix4x4.TRS(s_sharedCullBounds.center, main.transform.rotation, Vector3.one).inverse;
				point = inverse.MultiplyPoint3x4(point);
				point2 = inverse.MultiplyPoint3x4(point2);
				point3 = inverse.MultiplyPoint3x4(point3);
				point4 = inverse.MultiplyPoint3x4(point4);
				point5 = inverse.MultiplyPoint3x4(point5);
				point6 = inverse.MultiplyPoint3x4(point6);
				point7 = inverse.MultiplyPoint3x4(point7);
				point8 = inverse.MultiplyPoint3x4(point8);
				min = point;
				min = Vector3.Min(min, point2);
				min = Vector3.Min(min, point3);
				min = Vector3.Min(min, point4);
				min = Vector3.Min(min, point5);
				min = Vector3.Min(min, point6);
				min = Vector3.Min(min, point7);
				min = Vector3.Min(min, point8);
				max = point;
				max = Vector3.Max(max, point2);
				max = Vector3.Max(max, point3);
				max = Vector3.Max(max, point4);
				max = Vector3.Max(max, point5);
				max = Vector3.Max(max, point6);
				max = Vector3.Max(max, point7);
				max = Vector3.Max(max, point8);
				Bounds bounds3 = new Bounds((min + max) / 2f, max - min);
				Matrix4x4 inverse2 = inverse.inverse;
				extents = bounds3.extents;
				s_sharedCullingCamera.transform.position = inverse2.MultiplyPoint3x4(new Vector3(0f, 0f, bounds3.min.z));
				s_sharedCullingCamera.transform.rotation = main.transform.rotation;
			}
			s_sharedCullingCamera.orthographic = true;
			s_sharedCullingCamera.orthographicSize = extents.y;
			s_sharedCullingCamera.aspect = extents.x / extents.y;
			s_sharedCullingCamera.nearClipPlane = 0.01f;
			s_sharedCullingCamera.farClipPlane = extents.z * 2f;
			Matrix4x4 inverse3 = Matrix4x4.TRS(s_sharedCullingCamera.transform.position, s_sharedCullingCamera.transform.rotation, new Vector3(1f, 1f, -1f)).inverse;
			Matrix4x4 projectionMatrix = Matrix4x4.Ortho(0f - extents.x, extents.x, 0f - extents.y, extents.y, s_sharedCullingCamera.nearClipPlane, s_sharedCullingCamera.farClipPlane);
			s_sharedCullingCamera.worldToCameraMatrix = inverse3;
			s_sharedCullingCamera.projectionMatrix = projectionMatrix;
			s_sharedCullingCamera.cullingMask = s_sharedCullingMask;
			if (s_sharedCullingCamera.TryGetCullingParameters(out var cullingParameters))
			{
				cullingParameters.cullingOptions = s_sharedCullingOptions;
				cullingParameters.cullingMask = (uint)s_sharedCullingMask;
				sharedCullingResults = context.Cull(ref cullingParameters);
				cullOps++;
			}
		}

		private void UpdateLights(ScriptableRenderContext context, List<Camera> cameras)
		{
			ProcessVisibleLights(cameras);
			bool flag = false;
			if (asset.usesCachedPunctualShadows)
			{
				flag = true;
				if (asset.punctualShadowsType == ShadowsType.Raymap)
				{
					Transform transform = null;
					foreach (Camera camera in cameras)
					{
						PugCamera pugCamera = camera.GetPugCamera();
						if (!(pugCamera == null) && pugCamera.indirectLight == IndirectLightingType._2DBuffer)
						{
							transform = pugCamera.indirectLightAnchor;
						}
					}
					if (transform != null)
					{
						Shadows.raymapOrientation = transform.rotation;
					}
					else
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				Shadows.Update(context);
			}
			else
			{
				Shadows.Release();
			}
			s_pointLightData.Populate(visibleLights, LightType.Point);
			s_spotlightData.Populate(visibleLights, LightType.Spot);
			CommandBuffer commandBuffer = CommandBufferPool.Get(s_directionalLightsSampleName);
			commandBuffer.BeginSample(s_directionalLightsSampleName);
			foreach (Light visibleLight in visibleLights)
			{
				if (visibleLight.type == LightType.Directional)
				{
					visibleLight.GetPugLight().UpdateDirectional(context, commandBuffer);
				}
			}
			commandBuffer.EndSample(s_directionalLightsSampleName);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		private void ProcessVisibleLights(List<Camera> cameras)
		{
			visibleLights.Clear();
			if (useSharedCullPass)
			{
				foreach (VisibleLight visibleLight in sharedCullingResults.visibleLights)
				{
					visibleLights.Add(visibleLight.light);
				}
			}
			else
			{
				foreach (Camera camera in cameras)
				{
					GetOrCreateCameraData(camera).AddVisibleLights(visibleLights);
				}
			}
			Shadows.ConsumeDirtyAreas(visibleLights);
			if (visibleLights.Count > 0)
			{
				s_forcedLightUpdateIndex %= visibleLights.Count;
			}
			int num = 0;
			foreach (Light visibleLight2 in visibleLights)
			{
				PugLight pugLight = visibleLight2.GetPugLight();
				if (visibleLight2.shadows == LightShadows.None || asset.punctualShadowsType == ShadowsType.Raymarching)
				{
					pugLight.UpdatePositionalData();
					if (num == s_forcedLightUpdateIndex)
					{
						s_forcedLightUpdateIndex++;
					}
					num++;
				}
				else
				{
					if (pugLight.shadowUpdateMode == ShadowUpdateMode.Always || (pugLight.shadowUpdateMode == ShadowUpdateMode.OnChange && pugLight.CheckShadowDirty()) || num == s_forcedLightUpdateIndex)
					{
						pugLight.light.SetShadowDirty();
					}
					num++;
				}
			}
			s_forcedLightUpdateIndex++;
		}

		private void SetGlobalShaderParameters(CommandBuffer cmd)
		{
			asset.SetGlobalShaderParameters(cmd);
			cmd.SetKeyword(in s_shadowFilterQualityLowKeyword, asset.shadowFilterQuality == ShadowFilterQuality.Low);
			cmd.SetKeyword(in s_shadowFilterQualityMediumKeyword, asset.shadowFilterQuality == ShadowFilterQuality.Medium);
			cmd.SetKeyword(in s_shadowFilterQualityHighKeyword, asset.shadowFilterQuality == ShadowFilterQuality.High);
			cmd.SetGlobalFloat(ShaderIDs.RaymarchDither, asset.raymarchedShadowDither);
			cmd.SetGlobalVector(ShaderIDs.RenderOrigin, origin);
			cmd.SetGlobalFloat(ShaderIDs.PixelsPerMeter, asset.pixelsPerMeter);
			cmd.SetGlobalFloat(ShaderIDs.ApplicationIsPlaying, Application.isPlaying ? 1 : 0);
			PugRPUtils.EnsureLoadedResource(ref m_bluenoise64, "Textures/Bluenoise64");
			cmd.SetGlobalTexture(ShaderIDs.Bluenoise64, m_bluenoise64);
			cmd.SetGlobalTexture(ShaderIDs.GlobalCurveTexture, asset.curveTexture);
			cmd.SetGlobalFloat(ShaderIDs.LightFalloffDither, asset.lightFalloffDither);
			cmd.SetGlobalVector(ShaderIDs.LightPenetrationParams, new Vector4(asset.lightPixelPenetration / asset.pixelsPerMeter, asset.lightOffsetDepth, asset.lightOffsetPenetration, 0f));
			cmd.SetKeyword(in s_enableSpriteLightRimKeyword, asset.enableSpriteLightRims);
			if (asset.ditherTexture != null)
			{
				cmd.SetGlobalTexture(ShaderIDs.DitherTexture, asset.ditherTexture);
			}
			if (asset.noiseTextures != null && asset.noiseTextures.Length != 0)
			{
				cmd.SetGlobalTexture(ShaderIDs.Bluenoise128, asset.noiseTextures[s_frameIndex % asset.noiseTextures.Length]);
			}
			cmd.SetGlobalFloat(ShaderIDs.FrameIndex, s_frameIndex++);
			cmd.SetGlobalFloat(ShaderIDs.FrameIndex128, s_frameIndex128++);
			if (s_frameIndex128 >= 128)
			{
				s_frameIndex128 = 0;
			}
			float time = Time.time;
			float deltaTime = Time.deltaTime;
			float smoothDeltaTime = Time.smoothDeltaTime;
			float f = time / 8f;
			float f2 = time / 4f;
			float f3 = time / 2f;
			Vector4 value = time * new Vector4(0.05f, 1f, 2f, 3f);
			Vector4 value2 = new Vector4(Mathf.Sin(f), Mathf.Sin(f2), Mathf.Sin(f3), Mathf.Sin(time));
			Vector4 value3 = new Vector4(Mathf.Cos(f), Mathf.Cos(f2), Mathf.Cos(f3), Mathf.Cos(time));
			Vector4 value4 = new Vector4(deltaTime, 1f / deltaTime, smoothDeltaTime, 1f / smoothDeltaTime);
			Vector4 value5 = new Vector4(time, Mathf.Sin(time), Mathf.Cos(time), 0f);
			cmd.SetGlobalVector(ShaderIDs.Time, value);
			cmd.SetGlobalVector(ShaderIDs.SinTime, value2);
			cmd.SetGlobalVector(ShaderIDs.CosTime, value3);
			cmd.SetGlobalVector(ShaderIDs.DeltaTime, value4);
			cmd.SetGlobalVector(ShaderIDs.TimeParameters, value5);
		}

		public static void SetupCameraProperties(PugRPContext context, CommandBuffer cmd, Camera camera, bool forceSkew = false)
		{
			currentCameraPropertiesSource = camera;
			Vector3 position = camera.transform.position;
			context.srp.SetupCameraProperties(camera);
			cmd.SetGlobalVector(ShaderIDs.CameraPosition, position);
			cmd.SetGlobalVector(ShaderIDs.CameraRight, camera.transform.right);
			cmd.SetGlobalVector(ShaderIDs.CameraUp, camera.transform.up);
			cmd.SetGlobalVector(ShaderIDs.CameraForward, camera.transform.forward);
			PugRPUtils.GetCameraCorners(camera, s_cameraCorners);
			PugRPUtils.GetCameraRays(camera, s_cameraRays);
			cmd.SetGlobalVectorArray(ShaderIDs.CameraCorners, s_cameraCorners);
			cmd.SetGlobalVectorArray(ShaderIDs.CameraRays, s_cameraRays);
			if (camera.orthographic)
			{
				cmd.SetGlobalVector(ShaderIDs.CameraViewSize, new Vector2(camera.orthographicSize * camera.aspect * 2f, camera.orthographicSize * 2f));
			}
			else
			{
				cmd.SetGlobalVector(ShaderIDs.CameraViewSize, new Vector2(0f, 0f));
			}
			float num = 1f;
			Rect pixelRect = camera.pixelRect;
			float num2 = ((camera.cameraType == CameraType.SceneView) ? 1f : num);
			float num3 = pixelRect.width * num2;
			float num4 = pixelRect.height * num2;
			float num5 = pixelRect.width;
			float num6 = pixelRect.height;
			if (camera.allowDynamicResolution)
			{
				num3 *= ScalableBufferManager.widthScaleFactor;
				num4 *= ScalableBufferManager.heightScaleFactor;
			}
			float nearClipPlane = camera.nearClipPlane;
			float farClipPlane = camera.farClipPlane;
			float num7 = (Mathf.Approximately(nearClipPlane, 0f) ? 0f : (1f / nearClipPlane));
			float num8 = (Mathf.Approximately(farClipPlane, 0f) ? 0f : (1f / farClipPlane));
			float w = (camera.orthographic ? 1f : 0f);
			float num9 = 1f - farClipPlane * num7;
			float num10 = farClipPlane * num7;
			Vector4 value = new Vector4(num9, num10, num9 * num8, num10 * num8);
			if (SystemInfo.usesReversedZBuffer)
			{
				value.y += value.x;
				value.x = 0f - value.x;
				value.w += value.z;
				value.z = 0f - value.z;
			}
			float x = ((camera.targetTexture != null && SystemInfo.graphicsUVStartsAtTop) ? (-1f) : 1f);
			cmd.SetGlobalVector(value: new Vector4(x, nearClipPlane, farClipPlane, 1f * num8), nameID: ShaderIDs.ProjectionParams);
			Vector4 value2 = new Vector4(camera.orthographicSize * camera.aspect, camera.orthographicSize, 0f, w);
			cmd.SetGlobalVector(ShaderIDs.ScreenParams, new Vector4(num5, num6, 1f + 1f / num5, 1f + 1f / num6));
			cmd.SetGlobalVector(ShaderIDs.ScaledScreenParams, new Vector4(num3, num4, 1f + 1f / num3, 1f + 1f / num4));
			cmd.SetGlobalVector(ShaderIDs.ZBufferParams, value);
			cmd.SetGlobalVector(ShaderIDs.OrthoParams, value2);
			cmd.SetGlobalVector(ShaderIDs.ScreenSize, new Vector4(num5, num6, 1f / num5, 1f / num6));
			cmd.SetGlobalVector(ShaderIDs.TargetSize, new Vector4(context.pixelWidth, context.pixelHeight, 1f / (float)context.pixelWidth, 1f / (float)context.pixelHeight));
			float num11 = Math.Min((float)(0.0 - Math.Log(num5 / num3, 2.0)), 0f);
			cmd.SetGlobalVector(ShaderIDs.GlobalMipBias, new Vector2(num11, Mathf.Pow(2f, num11)));
			SetCameraMatrices(context, cmd, camera, setInverseMatrices: true, forceSkew);
			PugCamera pugCamera = context.pugCamera;
			if (pugCamera != null)
			{
				float shadowBias = PugRPUtils.GetShadowBias(Mathf.Max(pugCamera.indirectLightResolution.x, pugCamera.indirectLightResolution.y), asset.raymarchedShadowBias);
				cmd.SetGlobalVector(ShaderIDs.RaymarchedShadowParams, new Vector4(asset.raymarchedShadowQuality, asset.raymarchedShadowMaxSampleCount, shadowBias, asset.raymarchedShadowSharpness));
			}
		}

		private static void SetCameraMatrices(PugRPContext context, CommandBuffer cmd, Camera camera, bool setInverseMatrices, bool forceCameraEffects = false)
		{
			PugCamera pugCamera = context.pugCamera;
			CameraData cameraData = context.cameraData;
			if (pugCamera != null && pugCamera.camera != camera)
			{
				pugCamera = null;
			}
			if ((bool)pugCamera)
			{
				camera.aspect = (float)pugCamera.GetPixelWidth(camera) / (float)pugCamera.GetPixelHeight(camera);
			}
			Matrix4x4 projectionMatrix = camera.projectionMatrix;
			PugCamera pugCamera2 = (forceCameraEffects ? context.pugCamera : pugCamera);
			if (camera.orthographic && (bool)pugCamera2 && pugCamera2.outputSkew && pugCamera2.outputSkewAngle > 0f)
			{
				projectionMatrix[1, 1] /= Mathf.Cos(pugCamera2.outputSkewAngle * (MathF.PI / 180f));
			}
			Vector3 vector = camera.transform.position;
			Matrix4x4 matrix4x = camera.worldToCameraMatrix;
			bool snappingAccountsForOrigin = asset.snappingAccountsForOrigin;
			if ((bool)pugCamera2 && pugCamera2.GetOutputMode(camera) >= OutputMode.MatchAspect && pugCamera2.preventPixelCrawl && camera.orthographic)
			{
				if (snappingAccountsForOrigin)
				{
					vector += origin;
				}
				Matrix4x4 matrix4x2 = projectionMatrix * Matrix4x4.Rotate(camera.transform.rotation).inverse;
				int pixelWidth = context.pixelWidth;
				int pixelHeight = context.pixelHeight;
				Vector3 vector2 = matrix4x2.MultiplyPoint(vector) / 2f;
				Vector2Int vector2Int = new Vector2Int(Mathf.RoundToInt(vector2.x * (float)pixelWidth), Mathf.RoundToInt(vector2.y * (float)pixelHeight));
				Vector3 vector3 = new Vector3(((float)vector2Int.x + pugCamera2.texelSnapOffset) / (float)pixelWidth, ((float)vector2Int.y + pugCamera2.texelSnapOffset) / (float)pixelHeight, vector2.z);
				Vector2 vector4 = vector2 - vector3;
				vector4.x *= pixelWidth;
				vector4.y *= pixelHeight;
				vector = matrix4x2.inverse.MultiplyPoint(vector3 * 2f);
				if (snappingAccountsForOrigin)
				{
					vector -= origin;
				}
				Matrix4x4 inverse = matrix4x.inverse;
				inverse.m03 = vector.x;
				inverse.m13 = vector.y;
				inverse.m23 = vector.z;
				matrix4x = inverse.inverse;
				if ((bool)pugCamera && !pugCamera.subPixelMovement)
				{
					vector4 = Vector2.zero;
				}
				cmd.SetGlobalVector(ShaderIDs.WorldPixelSnap, (Vector2)vector2Int);
				cmd.SetGlobalVector(ShaderIDs.OutputTexelDelta, vector4);
			}
			else
			{
				cmd.SetGlobalVector(ShaderIDs.WorldPixelSnap, Vector2.zero);
				cmd.SetGlobalVector(ShaderIDs.OutputTexelDelta, Vector2.zero);
			}
			cameraData.adjustedViewMatrix = matrix4x;
			Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(projectionMatrix, renderIntoTexture: false);
			cameraData.viewProjectionMatrix = gPUProjectionMatrix * matrix4x;
			cmd.SetGlobalVector(ShaderIDs.WorldSpaceCameraPos, vector);
			cmd.SetViewProjectionMatrices(matrix4x, projectionMatrix);
			cmd.SetGlobalMatrix(ShaderIDs.MATRIX_VP_PREV, cameraData.GetPrevViewProjectionMatrix());
			if (setInverseMatrices)
			{
				Matrix4x4 matrix4x3 = Matrix4x4.Inverse(matrix4x);
				Matrix4x4 matrix4x4 = Matrix4x4.Inverse(gPUProjectionMatrix);
				Matrix4x4 value = matrix4x3 * matrix4x4;
				Matrix4x4 value2 = Matrix4x4.Scale(new Vector3(1f, 1f, -1f)) * matrix4x;
				Matrix4x4 inverse2 = value2.inverse;
				cmd.SetGlobalMatrix(ShaderIDs.WorldToCameraMatrix, value2);
				cmd.SetGlobalMatrix(ShaderIDs.CameraToWorldMatrix, inverse2);
				cmd.SetGlobalMatrix(ShaderIDs.InverseViewMatrix, matrix4x3);
				cmd.SetGlobalMatrix(ShaderIDs.InverseProjectionMatrix, matrix4x4);
				cmd.SetGlobalMatrix(ShaderIDs.InverseViewAndProjectionMatrix, value);
				cmd.SetGlobalMatrix(ShaderIDs.MATRIX_VP, cameraData.viewProjectionMatrix);
			}
		}

		protected override void Dispose(bool disposing)
		{
			PugRP.onDispose?.Invoke();
			base.Dispose(disposing);
			foreach (CameraData value in s_cameraData.Values)
			{
				value.Dispose();
			}
			Shadows.Release();
		}
	}
}
