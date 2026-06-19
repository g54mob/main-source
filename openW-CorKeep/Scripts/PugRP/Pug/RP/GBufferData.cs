using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;

namespace Pug.RP
{
	public class GBufferData
	{
		public enum DrawType
		{
			Camera = 0,
			Reflection = 1,
			Indirect = 2
		}

		private static ShaderTagId s_gbufferShaderTagID = new ShaderTagId("UniversalGBuffer");

		private static GlobalKeyword s_enableOutlinesKeyword = GlobalKeyword.Create("ENABLE_DEFERRED_OUTLINES");

		private static GlobalKeyword s_isPostProcessingKeyword = GlobalKeyword.Create("IS_POST_PROCESSING");

		private RenderTexture m_albedo;

		private RenderTexture m_normals;

		private RenderTexture m_emission;

		private RenderTexture m_outlines;

		private RenderTexture m_depth;

		private Material m_analyticNormalsMaterial;

		private Material m_outlinesMaterial;

		private readonly RenderTargetIdentifier[] m_mrt2 = new RenderTargetIdentifier[2];

		private readonly RenderTargetIdentifier[] m_mrt3 = new RenderTargetIdentifier[3];

		private readonly RenderTargetIdentifier[] m_mrt4 = new RenderTargetIdentifier[4];

		private bool m_depthIsShadowmap;

		private static int s_albedoTmp = Shader.PropertyToID("_AlbedoTmp");

		private static int s_normalsTmp = Shader.PropertyToID("_NormalsTmp");

		private static int s_depthTmp = Shader.PropertyToID("_DepthTmp");

		private static int s_emissionTmp = Shader.PropertyToID("_EmissionTmp");

		private OutlineSettings m_outlineSettings;

		private bool m_enableDeferredOutlines;

		private bool m_enablePostProcessingOutlines;

		public RenderTexture albedo => m_albedo;

		public RenderTexture normals => m_normals;

		public RenderTexture emission => m_emission;

		public RenderTexture outlines => m_outlines;

		public RenderTexture depth => m_depth;

		public static event Action<ScriptableRenderContext, CommandBuffer, Camera, DrawType> onDraw;

		public void Setup(int width, int height, bool depthIsShadowmap = false, OutlineSettings? outlineSettings = null)
		{
			m_depthIsShadowmap = depthIsShadowmap;
			m_outlineSettings = (outlineSettings.HasValue ? outlineSettings.Value : OutlineSettings.baseSettings);
			m_enableDeferredOutlines = outlineSettings.HasValue && m_outlineSettings.type == OutlineSettings.Type.Deferred;
			m_enablePostProcessingOutlines = outlineSettings.HasValue && m_outlineSettings.type == OutlineSettings.Type.PostProcessing;
			PugRPUtils.Setup(ref m_albedo, "Albedo", width, height, 0, RenderTextureFormat.ARGB32);
			PugRPUtils.Setup(ref m_normals, "World Normals", width, height, 0, PugRPUtils.packedNormalFormat);
			PugRPUtils.Setup(ref m_emission, "Emission", width, height, 0, RenderTextureFormat.ARGBHalf);
			if (m_enableDeferredOutlines || m_enablePostProcessingOutlines)
			{
				PugRPUtils.Setup(ref m_outlines, "Outlines", width, height, 0, RenderTextureFormat.ARGB32);
			}
			else
			{
				PugRPUtils.Release(ref m_outlines);
			}
			PugRPUtils.Setup(ref m_depth, "Depth", width, height, PugRPUtils.depthBits, (!m_depthIsShadowmap) ? RenderTextureFormat.Depth : RenderTextureFormat.Shadowmap);
			if (m_analyticNormalsMaterial == null)
			{
				m_analyticNormalsMaterial = CoreUtils.CreateEngineMaterial("Hidden/PugRP/AnalyticNormals");
			}
			if (m_outlinesMaterial == null)
			{
				m_outlinesMaterial = CoreUtils.CreateEngineMaterial("Hidden/PugRP/DeferredOutlines");
			}
		}

		public void Draw(ScriptableRenderContext context, CommandBuffer cmd, Camera camera, CullingResults cullingResults, DrawType drawType, bool enableAnalyticNormalEdges = false)
		{
			cmd.BeginSample("GBuffer");
			RenderTargetIdentifier renderTargetIdentifier = m_albedo.colorBuffer;
			RenderTargetIdentifier renderTargetIdentifier2 = m_normals.colorBuffer;
			RenderTargetIdentifier renderTargetIdentifier3 = m_emission.colorBuffer;
			RenderTargetIdentifier renderTargetIdentifier4 = m_depth;
			if (enableAnalyticNormalEdges || m_enableDeferredOutlines)
			{
				cmd.GetTemporaryRT(s_normalsTmp, m_normals.descriptor);
				renderTargetIdentifier2 = s_normalsTmp;
			}
			if (m_enableDeferredOutlines)
			{
				cmd.GetTemporaryRT(s_albedoTmp, m_albedo.descriptor);
				cmd.GetTemporaryRT(s_depthTmp, m_depth.descriptor);
				cmd.GetTemporaryRT(s_emissionTmp, m_emission.descriptor);
				renderTargetIdentifier = s_albedoTmp;
				renderTargetIdentifier4 = s_depthTmp;
				renderTargetIdentifier3 = s_emissionTmp;
			}
			if (enableAnalyticNormalEdges && m_enableDeferredOutlines)
			{
				renderTargetIdentifier2 = m_normals;
			}
			cmd.SetRenderTarget(renderTargetIdentifier);
			cmd.ClearRenderTarget(clearDepth: false, clearColor: true, Color.clear);
			cmd.SetRenderTarget(renderTargetIdentifier4);
			cmd.ClearRenderTarget(clearDepth: true, clearColor: false, Color.clear);
			cmd.SetRenderTarget(m_emission);
			cmd.ClearRenderTarget(clearDepth: false, clearColor: true, Color.clear);
			if (m_enableDeferredOutlines || m_enablePostProcessingOutlines)
			{
				cmd.SetRenderTarget(m_outlines);
				cmd.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
				m_mrt4[0] = renderTargetIdentifier;
				m_mrt4[1] = renderTargetIdentifier2;
				m_mrt4[2] = renderTargetIdentifier3;
				m_mrt4[3] = m_outlines.colorBuffer;
				cmd.SetRenderTarget(m_mrt4, renderTargetIdentifier4);
			}
			else
			{
				m_mrt3[0] = renderTargetIdentifier;
				m_mrt3[1] = renderTargetIdentifier2;
				m_mrt3[2] = renderTargetIdentifier3;
				cmd.SetRenderTarget(m_mrt3, renderTargetIdentifier4);
			}
			RendererListDesc rendererListDesc = new RendererListDesc(s_gbufferShaderTagID, cullingResults, camera);
			rendererListDesc.renderQueueRange = RenderQueueRange.opaque;
			rendererListDesc.sortingCriteria = SortingCriteria.RenderQueue | SortingCriteria.OptimizeStateChanges;
			rendererListDesc.layerMask = camera.cullingMask;
			RendererListDesc desc = rendererListDesc;
			RendererList rendererList = context.CreateRendererList(desc);
			cmd.SetKeyword(in s_enableOutlinesKeyword, m_enableDeferredOutlines);
			cmd.DrawRendererList(rendererList);
			GBufferData.onDraw?.Invoke(context, cmd, camera, drawType);
			if (enableAnalyticNormalEdges)
			{
				cmd.SetGlobalTexture(ShaderIDs.GBuffer1, renderTargetIdentifier2);
				cmd.SetGlobalTexture(ShaderIDs.DepthTexture, renderTargetIdentifier4);
				cmd.BeginSample("Analytic Normal Edges");
				renderTargetIdentifier2 = (m_enableDeferredOutlines ? ((RenderTargetIdentifier)s_normalsTmp) : ((RenderTargetIdentifier)m_normals));
				cmd.SetRenderTarget(renderTargetIdentifier2);
				cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, m_analyticNormalsMaterial, 0, 0);
				cmd.EndSample("Analytic Normal Edges");
			}
			if (m_enableDeferredOutlines)
			{
				cmd.SetGlobalTexture(ShaderIDs.GBuffer0, renderTargetIdentifier);
				cmd.SetGlobalTexture(ShaderIDs.GBuffer1, renderTargetIdentifier2);
				cmd.SetGlobalTexture(ShaderIDs.GBuffer2, renderTargetIdentifier3);
				cmd.SetGlobalTexture(ShaderIDs.DepthTexture, renderTargetIdentifier4);
				cmd.SetGlobalTexture(ShaderIDs.Outlines, m_outlines);
				cmd.SetGlobalVector(ShaderIDs.OutlineParams, m_outlineSettings.GetShaderParams());
				cmd.BeginSample("Deferred Outlines");
				m_mrt3[0] = m_albedo;
				m_mrt3[1] = m_normals;
				m_mrt3[2] = m_emission;
				cmd.SetRenderTarget(m_mrt3, m_depth);
				cmd.SetKeyword(in s_isPostProcessingKeyword, value: false);
				cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, m_outlinesMaterial, 0, 0);
				cmd.EndSample("Deferred Outlines");
				cmd.ReleaseTemporaryRT(s_albedoTmp);
				cmd.ReleaseTemporaryRT(s_depthTmp);
				cmd.ReleaseTemporaryRT(s_emissionTmp);
			}
			if (enableAnalyticNormalEdges || m_enableDeferredOutlines)
			{
				cmd.ReleaseTemporaryRT(s_normalsTmp);
			}
			cmd.SetGlobalTexture(ShaderIDs.GBuffer0, m_albedo);
			cmd.SetGlobalTexture(ShaderIDs.GBuffer1, m_normals);
			cmd.SetGlobalTexture(ShaderIDs.GBuffer2, m_emission);
			cmd.SetGlobalTexture(ShaderIDs.DepthTexture, m_depth);
			cmd.EndSample("GBuffer");
		}

		public void PostProcessOutlines(CommandBuffer cmd, RenderTargetIdentifier color, RenderTargetIdentifier depth, RenderTextureDescriptor colorDescriptor)
		{
			cmd.GetTemporaryRT(s_albedoTmp, colorDescriptor);
			cmd.GetTemporaryRT(s_normalsTmp, m_normals.descriptor);
			cmd.GetTemporaryRT(s_emissionTmp, m_emission.descriptor);
			cmd.GetTemporaryRT(s_depthTmp, m_depth.descriptor);
			cmd.SetGlobalTexture(ShaderIDs.GBuffer0, color);
			cmd.SetGlobalTexture(ShaderIDs.GBuffer1, m_normals);
			cmd.SetGlobalTexture(ShaderIDs.GBuffer1, m_emission);
			cmd.SetGlobalTexture(ShaderIDs.DepthTexture, depth);
			cmd.SetGlobalTexture(ShaderIDs.Outlines, m_outlines);
			m_mrt3[0] = s_albedoTmp;
			m_mrt3[1] = s_normalsTmp;
			m_mrt3[2] = s_emissionTmp;
			cmd.SetRenderTarget(m_mrt3, m_depth);
			cmd.SetKeyword(in s_isPostProcessingKeyword, value: true);
			cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, m_outlinesMaterial, 0, 0);
			cmd.CopyTexture(s_albedoTmp, color);
			cmd.CopyTexture(s_normalsTmp, m_normals);
			cmd.CopyTexture(s_emissionTmp, m_emission);
			cmd.CopyTexture(m_depth, depth);
			cmd.ReleaseTemporaryRT(s_albedoTmp);
			cmd.ReleaseTemporaryRT(s_normalsTmp);
			cmd.ReleaseTemporaryRT(s_emissionTmp);
			cmd.ReleaseTemporaryRT(s_depthTmp);
		}

		public void Dispose()
		{
			PugRPUtils.Release(ref m_albedo);
			PugRPUtils.Release(ref m_normals);
			PugRPUtils.Release(ref m_emission);
			PugRPUtils.Release(ref m_outlines);
			PugRPUtils.Release(ref m_depth);
		}
	}
}
