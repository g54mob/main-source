using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public class CameraRender
	{
		private const string SampleName = "Render Camera";

		private static string s_deferredSampleName = "Deferred";

		private static string s_errorSampleName = "Unsupported Shaders";

		private static GlobalKeyword s_fullbrightKeyword = GlobalKeyword.Create("FULLBRIGHT");

		private static GlobalKeyword s_preventPixelCrawlKeyword = GlobalKeyword.Create("PREVENT_PIXEL_CRAWL");

		private static GlobalKeyword s_skipPixelFilterKeyword = GlobalKeyword.Create("SKIP_PIXEL_FILTER");

		private static GlobalKeyword s_ssaoKeyword = GlobalKeyword.Create("SSAO_ENABLED");

		private static GlobalKeyword s_limitColorBitDepthKeyword = GlobalKeyword.Create("LIMIT_COLOR_BIT_DEPTH");

		private static GlobalKeyword s_colorLookupKeyword = GlobalKeyword.Create("COLOR_LUT_ENABLED");

		private static GlobalKeyword s_colorLookupX2Keyword = GlobalKeyword.Create("COLOR_LUT_X2_ENABLED");

		private static GlobalKeyword s_tonemappingKeyword = GlobalKeyword.Create("TONEMAPPING_ENABLED");

		private static GlobalKeyword s_filmicTonemappingKeyword = GlobalKeyword.Create("FILMIC_TONEMAPPING_ENABLED");

		private static GlobalKeyword s_depthWriteKeyword = GlobalKeyword.Create("WRITE_DEPTH");

		private static GlobalKeyword s_enableCRTSimulationKeyword = GlobalKeyword.Create("ENABLE_CRT_SIMULATION");

		private static GlobalKeyword s_enableCRTEmulationKeyword = GlobalKeyword.Create("ENABLE_CRT_EMULATION");

		private static GlobalKeyword s_useOutlineColorLookup = GlobalKeyword.Create("USE_OUTLINE_COLOR_LOOKUP");

		private static GlobalKeyword s_useOutlineColorLookupX2 = GlobalKeyword.Create("USE_OUTLINE_COLOR_LOOKUP_X2");

		public readonly PugRPContext context = new PugRPContext();

		public CommandBuffer cmd;

		private bool m_isUnlit;

		private bool m_isUnlitEditor;

		private static int s_internalTargetTmp = Shader.PropertyToID("_InternalTargetTmp");

		public void SetupAndCull(ScriptableRenderContext srpContext, Camera camera)
		{
			context.Setup(srpContext, camera);
			Setup();
			Cull();
		}

		private void Setup()
		{
			if (context.shouldRenderDeferredPass)
			{
				if (context.pugCamera != null)
				{
					PugCamera pugCamera = context.pugCamera;
					context.cameraData.gbuffer.Setup(context.pixelWidth, context.pixelHeight, depthIsShadowmap: false, pugCamera.enableOutlines ? new OutlineSettings?(pugCamera.outlineSettings) : ((OutlineSettings?)null));
				}
				else
				{
					context.cameraData.gbuffer.Setup(context.pixelWidth, context.pixelHeight);
				}
			}
			context.SetupRenderFeatures();
		}

		private bool Cull()
		{
			bool result = false;
			ScriptableCullingParameters cullingParameters;
			if (PugRP.useSharedCullPass)
			{
				PugRP.AppendSharedCullData(PugRPUtils.GetCameraFrustumBounds(context.camera), context.camera.cullingMask, CullingOptions.NeedsLighting | CullingOptions.DisablePerObjectCulling);
				result = true;
			}
			else if (context.camera.TryGetCullingParameters(out cullingParameters))
			{
				cullingParameters.cullingOptions = CullingOptions.NeedsLighting | CullingOptions.DisablePerObjectCulling;
				context.cameraData.Cull(context.srp, ref cullingParameters);
				PugRP.cullOps++;
				result = true;
			}
			context.CullRenderFeatures();
			return result;
		}

		public void RenderBeforeLightUpdate(ScriptableRenderContext srpContext, CommandBuffer cmd, Camera camera)
		{
			context.Setup(srpContext, camera);
			this.cmd = cmd;
			ExecutePipelineStage(RenderPipelineStage.BeforeLightUpdate);
		}

		public void Render(ScriptableRenderContext srpContext, CommandBuffer cmd, Camera camera)
		{
			Camera.onPreRender?.Invoke(camera);
			context.Setup(srpContext, camera);
			this.cmd = cmd;
			Color cameraClearColor = PugRP.GetCameraClearColor(camera);
			if (HDROutputSettings.main.available && context.pugCamera != null)
			{
				bool flag = (bool)context.pugCamera && context.pugCamera.crtFilterSettings.mode != CRTFilterMode.Off;
				HDROutputSettings.main.automaticHDRTonemapping = false;
				if (HDROutputSettings.main.HDRModeChangeRequested != flag)
				{
					Debug.Log($"Requesting HDR mode change: {flag}");
					HDROutputSettings.main.RequestHDRModeChange(flag);
				}
			}
			PugRP.asset.SetCameraShaderParameters(cmd, context.pugCamera);
			m_isUnlit = context.pugCamera != null && context.pugCamera.unlitDeferredPass;
			m_isUnlitEditor = false;
			if (m_isUnlit)
			{
				cmd.SetKeyword(in s_fullbrightKeyword, value: true);
				cmd.SetGlobalFloat(ShaderIDs.FullbrightOn, 1f);
			}
			else
			{
				cmd.SetKeyword(in s_fullbrightKeyword, value: false);
				cmd.SetGlobalFloat(ShaderIDs.FullbrightOn, 0f);
			}
			cmd.BeginSample("Render Camera");
			context.GetTemporaryTextures(cmd);
			context.SetInternalRenderTarget(cmd);
			cmd.ClearRenderTarget(clearDepth: true, clearColor: true, cameraClearColor);
			ExecutePipelineStage(RenderPipelineStage.BeforeEverything);
			ExecutePipelineStage(RenderPipelineStage.BeforeGeometry);
			if (context.shouldRenderDeferredPass)
			{
				DrawDeferredGeometry(context.pugCamera != null && context.pugCamera.enableAnalyticNormalEdges);
			}
			DrawForwardOpaque();
			if ((bool)context.pugCamera && context.pugCamera.enableOutlines && context.pugCamera.outlineSettings.type == OutlineSettings.Type.PostProcessing)
			{
				DrawPostProcessingOutlines();
			}
			PugRP.PostProcessOpaque(context, cmd, context.internalTarget, context.internalTargetDepth, context.internalTargetDescriptor);
			context.UpdateOpaqueTexture(cmd);
			DrawForwardTransparent();
			ExecutePipelineStage(RenderPipelineStage.AfterGeometry);
			DrawToTarget();
			ExecutePipelineStage(RenderPipelineStage.AfterEverything);
			context.ReleaseTemporaryTextures(cmd);
			cmd.EndSample("Render Camera");
			Camera.onPostRender?.Invoke(camera);
			context.cameraData.UpdateHistory();
		}

		private void DrawDeferredGeometry(bool enableAnalyticNormalEdges)
		{
			cmd.BeginSample(s_deferredSampleName);
			ExecutePipelineStage(RenderPipelineStage.BeforeGBuffer);
			DrawGBuffer(enableAnalyticNormalEdges);
			ExecutePipelineStage(RenderPipelineStage.AfterGBuffer);
			ExecutePipelineStage(RenderPipelineStage.BeforeDeferredLighting);
			DrawDeferredLightingPass();
			ExecutePipelineStage(RenderPipelineStage.AfterDeferredLighting);
			cmd.EndSample(s_deferredSampleName);
		}

		private void DrawGBuffer(bool enableAnalyticNormalEdges)
		{
			context.cameraData.gbuffer.Draw(context.srp, cmd, context.camera, context.cameraData.GetCullingResults(), GBufferData.DrawType.Camera, enableAnalyticNormalEdges);
		}

		private void DrawDeferredLightingPass()
		{
			cmd.SetKeyword(in s_ssaoKeyword, context.pugCamera != null && context.pugCamera.enableSSAO);
			context.SetInternalRenderTarget(cmd);
			bool flag = m_isUnlit || PugRP.asset.highPerformanceLightMode;
			PugRP.DrawDeferredLight(cmd, flag ? DeferredLightPass.IndirectOnly : DeferredLightPass.DirectAndIndirect);
			cmd.SetKeyword(in s_ssaoKeyword, value: false);
		}

		private void DrawForwardOpaque()
		{
			context.SetInternalRenderTarget(cmd);
			ExecutePipelineStage(RenderPipelineStage.BeforeForwardOpaque);
			context.SetInternalRenderTarget(cmd);
			PugRP.DrawForwardOpaque(context, cmd);
			ExecutePipelineStage(RenderPipelineStage.AfterForwardOpaque);
		}

		private void DrawPostProcessingOutlines()
		{
			OutlineSettings outlineSettings = context.pugCamera.outlineSettings;
			cmd.SetGlobalVector(ShaderIDs.OutlineParams, outlineSettings.GetShaderParams());
			if (outlineSettings.colorLookup != null)
			{
				cmd.SetGlobalFloat(ShaderIDs.DebugOutlineColorLookup, outlineSettings.debugColorLookup ? 1 : 0);
				cmd.SetGlobalTexture(ShaderIDs.OutlineColorLookup, outlineSettings.colorLookup);
				if (outlineSettings.colorLookup2 != null)
				{
					cmd.SetKeyword(in s_useOutlineColorLookup, value: false);
					cmd.SetKeyword(in s_useOutlineColorLookupX2, value: true);
					cmd.SetGlobalTexture(ShaderIDs.OutlineColorLookup2, outlineSettings.colorLookup2);
				}
				else
				{
					cmd.SetKeyword(in s_useOutlineColorLookup, value: true);
					cmd.SetKeyword(in s_useOutlineColorLookupX2, value: false);
				}
			}
			else
			{
				cmd.SetKeyword(in s_useOutlineColorLookup, value: false);
				cmd.SetKeyword(in s_useOutlineColorLookupX2, value: false);
			}
			context.cameraData.gbuffer.PostProcessOutlines(cmd, context.internalTarget, context.internalTargetDepth, context.internalTargetDescriptor);
		}

		private void DrawForwardTransparent()
		{
			context.SetInternalRenderTarget(cmd);
			ExecutePipelineStage(RenderPipelineStage.BeforeForwardTransparent);
			context.SetInternalRenderTarget(cmd);
			PugRP.DrawForwardTransparent(context, cmd);
			ExecutePipelineStage(RenderPipelineStage.AfterForwardTransparent);
		}

		private void DrawToTarget()
		{
			ExecutePipelineStage(RenderPipelineStage.BeforePostProcessing);
			cmd.BeginSample("Post Processing");
			Rect pixelRect = context.camera.pixelRect;
			int num = 0;
			PugCamera pugCamera = context.pugCamera;
			if (pugCamera != null && !m_isUnlitEditor)
			{
				cmd.SetKeyword(in s_preventPixelCrawlKeyword, pugCamera.GetOutputMode(context.camera) > OutputMode.Native && context.pugCamera.preventPixelCrawl);
				if (context.camera.cameraType == CameraType.Game && pugCamera.TryGetIntegerWidthAndHeight(out var integerWidth, out var integerHeight))
				{
					pixelRect.x += (pixelRect.width - (float)integerWidth) / 2f;
					pixelRect.y += (pixelRect.height - (float)integerHeight) / 2f;
					pixelRect.width = integerWidth;
					pixelRect.height = integerHeight;
					num = pugCamera.GetIntegerScale();
				}
				if (PugRP.skipPixelFilter || context.camera.pixelRect.width < (float)context.pixelWidth * 1.05f || context.camera.pixelRect.height < (float)context.pixelHeight * 1.05f || num > 0)
				{
					cmd.SetKeyword(in s_skipPixelFilterKeyword, value: true);
				}
				else
				{
					cmd.SetKeyword(in s_skipPixelFilterKeyword, value: false);
				}
				float w = 1f / Mathf.Max(Mathf.Epsilon, 1f - pugCamera.tonemapWeight) - 1f;
				cmd.SetKeyword(in s_limitColorBitDepthKeyword, pugCamera.outputLimitColorBitDepth);
				cmd.SetGlobalVector(ShaderIDs.TonemapParams, new Vector4(Mathf.Min(pugCamera.tonemapThreshold, 0.999f), pugCamera.tonemapWhiteout, pugCamera.tonemapWhiteoutThreshold, w));
				cmd.SetGlobalVector(ShaderIDs.TonemapParams2, new Vector4(pugCamera.tonemapGamma, pugCamera.tonemapBrightness, 0f, 0f));
				cmd.SetGlobalFloat(ShaderIDs.DitherOutput, pugCamera.ditherOutput);
				cmd.SetGlobalColor(ShaderIDs.FadeColor, pugCamera.fadeColor);
				cmd.SetGlobalFloat(ShaderIDs.OutputExposure, pugCamera.outputExposure);
				cmd.SetGlobalFloat(ShaderIDs.OutputGamma, pugCamera.outputGamma);
				cmd.SetGlobalFloat(ShaderIDs.OutputColorDepth, Mathf.Pow(2f, pugCamera.outputColorBitDepth) - 1f);
				Texture texture = ((pugCamera.outputColorLookup != null) ? pugCamera.outputColorLookup : pugCamera.outputColorLookup2);
				Texture texture2 = ((pugCamera.outputColorLookup != null) ? pugCamera.outputColorLookup2 : null);
				if (texture != null && texture2 != null)
				{
					cmd.SetGlobalTexture(ShaderIDs.ColorLUT, texture);
					cmd.SetGlobalTexture(ShaderIDs.ColorLUT2, texture2);
					cmd.SetKeyword(in s_colorLookupKeyword, value: false);
					cmd.SetKeyword(in s_colorLookupX2Keyword, value: true);
				}
				else if ((bool)texture)
				{
					cmd.SetGlobalTexture(ShaderIDs.ColorLUT, texture);
					cmd.SetKeyword(in s_colorLookupKeyword, value: true);
					cmd.SetKeyword(in s_colorLookupX2Keyword, value: false);
				}
				else
				{
					cmd.SetKeyword(in s_colorLookupKeyword, value: false);
					cmd.SetKeyword(in s_colorLookupX2Keyword, value: false);
				}
				cmd.SetKeyword(in s_tonemappingKeyword, pugCamera.tonemap && pugCamera.tonemapMode == TonemapMode.MGSV);
				cmd.SetKeyword(in s_filmicTonemappingKeyword, pugCamera.tonemap && pugCamera.tonemapMode == TonemapMode.Filmic);
				cmd.SetKeyword(in s_depthWriteKeyword, pugCamera.enableDeferredPass);
			}
			else
			{
				cmd.SetKeyword(in s_preventPixelCrawlKeyword, value: false);
				cmd.SetKeyword(in s_skipPixelFilterKeyword, value: false);
				cmd.SetKeyword(in s_limitColorBitDepthKeyword, value: false);
				cmd.SetKeyword(in s_colorLookupKeyword, value: false);
				cmd.SetKeyword(in s_tonemappingKeyword, value: false);
				cmd.SetKeyword(in s_filmicTonemappingKeyword, value: false);
				cmd.SetGlobalVector(ShaderIDs.TonemapParams, Vector4.zero);
				cmd.SetGlobalFloat(ShaderIDs.DitherOutput, 0f);
				cmd.SetGlobalColor(ShaderIDs.FadeColor, Color.clear);
				cmd.SetGlobalFloat(ShaderIDs.OutputExposure, 1f);
				cmd.SetGlobalFloat(ShaderIDs.OutputGamma, 1f);
				cmd.SetGlobalFloat(ShaderIDs.OutputColorDepth, 255f);
				cmd.SetKeyword(in s_depthWriteKeyword, value: false);
			}
			if (pugCamera != null)
			{
				CRTFilterSettings crtFilterSettings = pugCamera.crtFilterSettings;
				cmd.SetKeyword(in s_enableCRTSimulationKeyword, crtFilterSettings.mode == CRTFilterMode.Simulated);
				cmd.SetKeyword(in s_enableCRTEmulationKeyword, crtFilterSettings.mode == CRTFilterMode.Emulated);
				cmd.SetGlobalVector(ShaderIDs.CRTEmulationParams, new Vector4(crtFilterSettings.HDRExposure, (float)crtFilterSettings.shadowDirection, (float)crtFilterSettings.maskAlignment, (float)crtFilterSettings.shadowStyle));
				cmd.SetGlobalVector(ShaderIDs.CRTEmulationParams2, new Vector4(crtFilterSettings.shadowGradients ? 1 : 0, (float)crtFilterSettings.simulationStyle, 0f, crtFilterSettings.stablePixels ? 1 : 0));
			}
			else
			{
				cmd.SetKeyword(in s_enableCRTSimulationKeyword, value: false);
				cmd.SetKeyword(in s_enableCRTEmulationKeyword, value: false);
			}
			if (pixelRect.width % 2f != 0f)
			{
				pixelRect.width++;
			}
			if (pixelRect.height % 2f != 0f)
			{
				pixelRect.height++;
			}
			cmd.SetGlobalTexture(ShaderIDs.BlitInput, context.internalTarget);
			cmd.SetGlobalVector(ShaderIDs.TargetSize, new Vector4(pixelRect.width, pixelRect.height, 1f / pixelRect.width, 1f / pixelRect.height));
			cmd.SetGlobalFloat("_IntegerScale", num);
			RenderTextureDescriptor internalTargetDescriptor = context.internalTargetDescriptor;
			internalTargetDescriptor.colorFormat = RenderTextureFormat.Default;
			internalTargetDescriptor.depthBufferBits = 0;
			internalTargetDescriptor.sRGB = true;
			cmd.GetTemporaryRT(s_internalTargetTmp, internalTargetDescriptor, FilterMode.Bilinear);
			cmd.SetRenderTarget(s_internalTargetTmp);
			cmd.SetGlobalTexture(ShaderIDs.BlitInput, context.internalTarget);
			cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, PugRP.colorResolveMaterial, 0, 0);
			if (context.camera.targetTexture != null)
			{
				cmd.SetRenderTarget(context.camera.targetTexture);
			}
			else
			{
				cmd.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);
			}
			cmd.SetViewport(pixelRect);
			cmd.SetGlobalTexture(ShaderIDs.BlitInput, s_internalTargetTmp);
			cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, PugRP.finalBlitMaterial, 0, 0);
			cmd.ReleaseTemporaryRT(s_internalTargetTmp);
			cmd.EndSample("Post Processing");
			ExecutePipelineStage(RenderPipelineStage.AfterPostProcessing);
		}

		private void ExecutePipelineStage(RenderPipelineStage pipelineStagee)
		{
			context.ExecutePipelineStage(cmd, pipelineStagee);
			SetCameraPropertiesIfNecessary();
		}

		private void SetCameraPropertiesIfNecessary()
		{
			if (PugRP.currentCameraPropertiesSource != context.camera)
			{
				PugRP.SetupCameraProperties(context, cmd, context.camera);
			}
		}
	}
}
