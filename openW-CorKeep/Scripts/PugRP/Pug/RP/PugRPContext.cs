using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public class PugRPContext
	{
		public ScriptableRenderContext srp;

		private static Dictionary<RenderFeature, GlobalKeyword> s_keywordLookup = new Dictionary<RenderFeature, GlobalKeyword>();

		private static Dictionary<RenderFeature, GlobalKeyword> s_passKeywordLookup = new Dictionary<RenderFeature, GlobalKeyword>();

		private static string s_opaqueTextureSampleName = "Update Opaque Texture";

		private Camera m_camera;

		private PugCamera m_pugCamera;

		private CameraData m_cameraData;

		private int m_internalTarget = Shader.PropertyToID("_InternalTarget");

		private int m_internalTargetDepth = Shader.PropertyToID("_InternalTargetDepth");

		private int m_opaqueTexture = Shader.PropertyToID("_OpaqueTexture");

		private RenderTargetIdentifier m_internalTargetIdentifier;

		private RenderTargetIdentifier m_internalTargetDepthIdentifier;

		private RenderTargetIdentifier m_opaqueTextureIdentifier;

		private static Dictionary<RenderPipelineStage, string> s_pipelineStageNames = new Dictionary<RenderPipelineStage, string>();

		public Camera camera => m_camera;

		public PugCamera pugCamera => m_pugCamera;

		public CameraData cameraData => m_cameraData;

		public RenderTargetIdentifier internalTarget => m_internalTargetIdentifier;

		public RenderTargetIdentifier internalTargetDepth => m_internalTargetDepthIdentifier;

		public RenderTargetIdentifier opaqueTexture => m_opaqueTextureIdentifier;

		public int pixelWidth
		{
			get
			{
				if (m_pugCamera != null)
				{
					return m_pugCamera.GetPixelWidth(camera);
				}
				return camera.pixelWidth;
			}
		}

		public int pixelHeight
		{
			get
			{
				if (m_pugCamera != null)
				{
					return m_pugCamera.GetPixelHeight(camera);
				}
				return camera.pixelHeight;
			}
		}

		public bool shouldRenderDeferredPass
		{
			get
			{
				if (pugCamera != null)
				{
					return pugCamera.enableDeferredPass;
				}
				return false;
			}
		}

		public bool shouldCreateOpaqueTexture
		{
			get
			{
				bool result = pugCamera != null && pugCamera.enableOpaqueTexture;
				if (camera.cameraType == CameraType.SceneView || camera.cameraType == CameraType.Preview)
				{
					result = true;
				}
				return result;
			}
		}

		public RenderTextureDescriptor internalTargetDescriptor => new RenderTextureDescriptor(pixelWidth, pixelHeight, PugRPUtils.hdrAlphaFormat, 0);

		public RenderTextureDescriptor internalTargetDepthDescriptor => new RenderTextureDescriptor(pixelWidth, pixelHeight, RenderTextureFormat.Depth, PugRPUtils.depthBits);

		public static event Action<PugRPContext, CommandBuffer, RenderPipelineStage> onBeforePipelineStage;

		public static event Action<PugRPContext, CommandBuffer, RenderPipelineStage> onAfterPipelineStage;

		public static event Action<PugRPContext, CommandBuffer, Type, RenderPipelineStage, RenderPipelineStagePass> onBeforeExecuteRenderFeaturePass;

		public static event Action<PugRPContext, CommandBuffer, Type, RenderPipelineStage, RenderPipelineStagePass> onAfterExecuteRenderFeaturePass;

		public PugRPContext()
		{
			m_internalTargetIdentifier = new RenderTargetIdentifier(m_internalTarget);
			m_internalTargetDepthIdentifier = new RenderTargetIdentifier(m_internalTargetDepth);
			m_opaqueTextureIdentifier = new RenderTargetIdentifier(m_opaqueTexture);
		}

		public void Setup(ScriptableRenderContext srp, Camera camera)
		{
			this.srp = srp;
			m_camera = camera;
			m_pugCamera = camera.GetPugCamera();
			if (m_pugCamera != null && m_camera.cameraType == CameraType.Game)
			{
				m_pugCamera.SetCamera(m_camera);
			}
			m_cameraData = PugRP.GetOrCreateCameraData(camera);
		}

		public void GetTemporaryTextures(CommandBuffer cmd)
		{
			cmd.GetTemporaryRT(m_internalTarget, internalTargetDescriptor, FilterMode.Bilinear);
			cmd.GetTemporaryRT(m_internalTargetDepth, internalTargetDepthDescriptor, FilterMode.Point);
			SetInternalRenderTarget(cmd);
			if (shouldCreateOpaqueTexture)
			{
				cmd.GetTemporaryRT(m_opaqueTexture, pixelWidth, pixelHeight, 0, FilterMode.Point, PugRPUtils.hdrAlphaFormat);
			}
		}

		public void SetInternalRenderTarget(CommandBuffer cmd)
		{
			cmd.SetRenderTarget(m_internalTargetIdentifier, m_internalTargetDepthIdentifier);
		}

		public void SetCameraMatrices(CommandBuffer cmd)
		{
			cmd.SetViewProjectionMatrices(camera.worldToCameraMatrix, camera.projectionMatrix);
		}

		public void UpdateOpaqueTexture(CommandBuffer cmd)
		{
			if (shouldCreateOpaqueTexture)
			{
				cmd.BeginSample(s_opaqueTextureSampleName);
				cmd.CopyTexture(m_internalTarget, m_opaqueTexture);
				cmd.SetGlobalTexture(ShaderIDs.OpaqueTexture, m_opaqueTexture);
				cmd.EndSample(s_opaqueTextureSampleName);
			}
		}

		public void ReleaseTemporaryTextures(CommandBuffer cmd)
		{
			cmd.ReleaseTemporaryRT(m_internalTarget);
			cmd.ReleaseTemporaryRT(m_internalTargetDepth);
			if (shouldCreateOpaqueTexture)
			{
				cmd.ReleaseTemporaryRT(m_opaqueTexture);
			}
		}

		public void SetupRenderFeatures()
		{
			RenderFeature[] renderFeatures = cameraData.renderFeatures;
			foreach (RenderFeature renderFeature in renderFeatures)
			{
				if (!s_keywordLookup.ContainsKey(renderFeature))
				{
					s_keywordLookup.Add(renderFeature, GlobalKeyword.Create(renderFeature.featureKeyword));
					s_passKeywordLookup.Add(renderFeature, GlobalKeyword.Create(renderFeature.featurePassKeyword));
				}
				renderFeature.ValidateFrame(this);
				if (renderFeature.isValid)
				{
					renderFeature.OnBeginValidFrame(this);
				}
				else
				{
					renderFeature.Dispose();
				}
			}
		}

		public void AppendSharedCullData(ref Bounds bounds, ref int cullingMask, ref CullingOptions cullingOptions)
		{
			RenderFeature[] renderFeatures = cameraData.renderFeatures;
			for (int i = 0; i < renderFeatures.Length; i++)
			{
				renderFeatures[i].AppendSharedCullData(ref bounds, ref cullingMask, ref cullingOptions);
			}
		}

		public void CullRenderFeatures()
		{
			RenderFeature[] renderFeatures = cameraData.renderFeatures;
			foreach (RenderFeature renderFeature in renderFeatures)
			{
				if (renderFeature.isValid)
				{
					renderFeature.Cull(this);
				}
			}
		}

		public void ExecutePipelineStage(CommandBuffer cmd, RenderPipelineStage stage)
		{
			if (!s_pipelineStageNames.TryGetValue(stage, out var value))
			{
				value = Regex.Replace(stage.ToString(), "([A-Z])", " $1", RegexOptions.Compiled).Trim();
				s_pipelineStageNames[stage] = value;
			}
			cmd.BeginSample(value);
			PugRPContext.onBeforePipelineStage?.Invoke(this, cmd, stage);
			ExecuteRenderFeatures(cmd, stage);
			PugRPContext.onAfterPipelineStage?.Invoke(this, cmd, stage);
			cmd.EndSample(value);
		}

		private void ExecuteRenderFeatures(CommandBuffer cmd, RenderPipelineStage stage)
		{
			for (int i = 0; i < cameraData.renderFeatures.Length; i++)
			{
				RenderFeature renderFeature = cameraData.renderFeatures[i];
				cmd.SetKeyword(s_keywordLookup[renderFeature], renderFeature.isValid);
				if (!renderFeature.isValid)
				{
					renderFeature.ExecuteDisabled(this, cmd);
				}
			}
			for (int j = 0; j < cameraData.renderFeatures.Length; j++)
			{
				ExecuteRenderFeaturePass(cmd, stage, cameraData.renderFeatures[j], RenderPipelineStagePass.Early);
			}
			for (int k = 0; k < cameraData.renderFeatures.Length; k++)
			{
				ExecuteRenderFeaturePass(cmd, stage, cameraData.renderFeatures[k], RenderPipelineStagePass.Normal);
			}
			for (int l = 0; l < cameraData.renderFeatures.Length; l++)
			{
				ExecuteRenderFeaturePass(cmd, stage, cameraData.renderFeatures[l], RenderPipelineStagePass.Late);
			}
		}

		private void ExecuteRenderFeaturePass(CommandBuffer cmd, RenderPipelineStage stage, RenderFeature renderFeature, RenderPipelineStagePass pass)
		{
			if (renderFeature.isValid && renderFeature.GetExecutionStageForPass(pass) == stage)
			{
				Type type = renderFeature.GetType();
				GlobalKeyword keyword = s_passKeywordLookup[renderFeature];
				cmd.SetKeyword(in keyword, value: true);
				PugRPContext.onBeforeExecuteRenderFeaturePass?.Invoke(this, cmd, type, stage, pass);
				switch (pass)
				{
				case RenderPipelineStagePass.Early:
					cmd.BeginSample(renderFeature.sampleNameEarly);
					renderFeature.ExecuteEarly(this, cmd);
					cmd.EndSample(renderFeature.sampleNameEarly);
					break;
				case RenderPipelineStagePass.Normal:
					cmd.BeginSample(renderFeature.sampleName);
					renderFeature.Execute(this, cmd);
					cmd.EndSample(renderFeature.sampleName);
					break;
				case RenderPipelineStagePass.Late:
					cmd.BeginSample(renderFeature.sampleNameLate);
					renderFeature.ExecuteLate(this, cmd);
					cmd.EndSample(renderFeature.sampleNameLate);
					break;
				}
				PugRPContext.onAfterExecuteRenderFeaturePass?.Invoke(this, cmd, type, stage, pass);
				cmd.SetKeyword(in keyword, value: false);
			}
		}

		public bool Cull(Camera camera, ref CullingResults cullingResults, CullingOptions cullingOptions = CullingOptions.ForceEvenIfCameraIsNotActive | CullingOptions.NeedsLighting | CullingOptions.DisablePerObjectCulling)
		{
			if (camera.TryGetCullingParameters(out var cullingParameters))
			{
				cullingParameters.cullingOptions = cullingOptions;
				cullingResults = srp.Cull(ref cullingParameters);
				PugRP.cullOps++;
				return true;
			}
			return false;
		}
	}
}
