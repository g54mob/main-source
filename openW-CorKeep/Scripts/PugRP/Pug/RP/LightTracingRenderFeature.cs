using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public class LightTracingRenderFeature : RenderFeature
	{
		private static GlobalKeyword s_featureKeyword = GlobalKeyword.Create("ENABLE_LIGHT_TRACING");

		private static GlobalKeyword s_passKeyword = GlobalKeyword.Create("LIGHT_TRACE_INPUT_RENDER");

		private static GlobalKeyword s_shadowKeyword = GlobalKeyword.Create("ENABLE_LT_SHADOWS");

		private static GlobalKeyword s_occlusionKeyword = GlobalKeyword.Create("ENABLE_LT_OCCLUSION");

		private static GlobalKeyword s_transmittanceKeyword = GlobalKeyword.Create("ENABLE_LT_TRANSMITTANCE");

		private static string m_shadowsName = "LightTracing (Shadows)";

		private static string m_shadowsBlurredName = "LightTracing (Shadows, Blurred)";

		private static string m_transmittanceName = "LightTracing (Transmittance)";

		private RenderTexture m_shadows;

		private RenderTexture m_occlusion;

		private RenderTexture m_transmittance;

		private RenderTextureDescriptor m_desc;

		private int m_tmp = Shader.PropertyToID("_LT_Tmp");

		private Camera m_internalCamera;

		public override bool usesCulling => true;

		public override string sampleName => "Light Trace Input";

		public override RenderPipelineStage executionStage => RenderPipelineStage.BeforeEverything;

		public override void ValidateFrame(PugRPContext context)
		{
			base.isValid = context.camera != null && context.camera.cameraType == CameraType.Game && context.pugCamera != null && context.pugCamera.indirectLight == IndirectLightingType._2DBuffer && context.pugCamera.indirectLightAnchor != null && context.shouldRenderDeferredPass && context.pugCamera.lightTracing && (context.pugCamera.lightTracingShadows || context.pugCamera.lightTracingOcclusion || context.pugCamera.lightTracingTransmittance);
		}

		public override void OnBeginValidFrame(PugRPContext context)
		{
			if (m_internalCamera == null)
			{
				m_internalCamera = PugRPUtils.GetUtilityCamera("_LIGHT_TRACE_INPUT_CAMERA");
			}
			m_desc = new RenderTextureDescriptor(context.pugCamera.indirectLightResolution.x, context.pugCamera.indirectLightResolution.y, RenderTextureFormat.ARGB32)
			{
				enableRandomWrite = true
			};
			if (context.pugCamera != null && (context.pugCamera.lightTracingShadows || context.pugCamera.lightTracingOcclusion))
			{
				PugRPUtils.Setup(ref m_shadows, m_shadowsName, m_desc);
			}
			else
			{
				PugRPUtils.Release(ref m_shadows);
			}
			if (context.pugCamera != null && context.pugCamera.lightTracingOcclusion)
			{
				PugRPUtils.Setup(ref m_occlusion, m_shadowsBlurredName, m_desc);
			}
			else
			{
				PugRPUtils.Release(ref m_occlusion);
			}
			if (context.pugCamera != null && context.pugCamera.lightTracingTransmittance)
			{
				PugRPUtils.Setup(ref m_transmittance, m_transmittanceName, m_desc);
			}
			else
			{
				PugRPUtils.Release(ref m_transmittance);
			}
		}

		public override void Cull(PugRPContext context)
		{
			Transform indirectLightAnchor = context.pugCamera.indirectLightAnchor;
			Vector3 vector = PugRPUtils.SnapBufferPosition(indirectLightAnchor.position, indirectLightAnchor.rotation, context.pugCamera.indirectLightSize, context.pugCamera.GetIndirectLightSnapResolution());
			Vector2 vector2 = context.pugCamera.indirectLightSize / 2f;
			m_internalCamera.transform.position = vector - indirectLightAnchor.forward * context.pugCamera.indirectLightDepth / 2f;
			m_internalCamera.transform.rotation = indirectLightAnchor.rotation;
			m_internalCamera.orthographic = true;
			m_internalCamera.orthographicSize = vector2.y;
			m_internalCamera.aspect = vector2.x / vector2.y;
			m_internalCamera.nearClipPlane = 0.01f;
			m_internalCamera.farClipPlane = context.pugCamera.indirectLightDepth;
			Matrix4x4 inverse = Matrix4x4.TRS(m_internalCamera.transform.position, m_internalCamera.transform.rotation, new Vector3(1f, 1f, -1f)).inverse;
			Matrix4x4 projectionMatrix = Matrix4x4.Ortho(0f - vector2.x, vector2.x, 0f - vector2.y, vector2.y, m_internalCamera.nearClipPlane, m_internalCamera.farClipPlane);
			m_internalCamera.worldToCameraMatrix = inverse;
			m_internalCamera.projectionMatrix = projectionMatrix;
			m_internalCamera.cullingMask = 0;
			if (context.pugCamera.lightTracingShadows || context.pugCamera.lightTracingOcclusion)
			{
				m_internalCamera.cullingMask |= context.pugCamera.lightTracingShadowLayers;
			}
			if (context.pugCamera.lightTracingTransmittance)
			{
				m_internalCamera.cullingMask |= context.pugCamera.lightTracingTransmittanceLayers;
			}
			Cull(context, m_internalCamera, CullingOptions.ForceEvenIfCameraIsNotActive | CullingOptions.DisablePerObjectCulling);
		}

		public override void Execute(PugRPContext context, CommandBuffer cmd)
		{
			if (!GetCullingResults(out var cullingResults))
			{
				return;
			}
			PugRP.SetupCameraProperties(context, cmd, m_internalCamera);
			cmd.SetKeyword(in s_passKeyword, value: true);
			if (context.pugCamera.lightTracingShadows || context.pugCamera.lightTracingOcclusion)
			{
				cmd.SetRenderTarget(m_shadows);
				cmd.ClearRenderTarget(clearDepth: false, clearColor: true, Color.white);
				m_internalCamera.cullingMask = context.pugCamera.lightTracingShadowLayers;
				PugRP.DrawForwardTransparent(context, cmd, m_internalCamera, cullingResults);
			}
			if (context.pugCamera.lightTracingTransmittance)
			{
				cmd.SetRenderTarget(m_transmittance);
				cmd.ClearRenderTarget(clearDepth: false, clearColor: true, Color.white);
				m_internalCamera.cullingMask = context.pugCamera.lightTracingTransmittanceLayers;
				PugRP.DrawForwardTransparent(context, cmd, m_internalCamera, cullingResults);
				cmd.SetGlobalTexture(ShaderIDs.LTTransmittance, m_transmittance);
				cmd.SetKeyword(in s_transmittanceKeyword, value: true);
			}
			else
			{
				cmd.SetKeyword(in s_transmittanceKeyword, value: false);
			}
			cmd.SetKeyword(in s_passKeyword, value: false);
			if (context.pugCamera.lightTracingOcclusion)
			{
				if (context.pugCamera.lightTracingOcclusionBlur > 0)
				{
					cmd.GetTemporaryRT(m_tmp, m_desc);
					PugRPUtils.BlurTexture(cmd, m_shadows, m_tmp, m_occlusion, m_desc.width, m_desc.height, useUnorm: true, context.pugCamera.lightTracingOcclusionBlur);
					cmd.ReleaseTemporaryRT(m_tmp);
				}
				cmd.SetGlobalTexture(ShaderIDs.LTOcclusion, m_occlusion);
				cmd.SetGlobalFloat(ShaderIDs.LTOcclusionStrength, context.pugCamera.lightTracingOcclusionStrength);
				cmd.SetKeyword(in s_occlusionKeyword, value: true);
			}
			else
			{
				cmd.SetKeyword(in s_occlusionKeyword, value: false);
			}
			if (context.pugCamera.lightTracingShadows)
			{
				if (context.pugCamera.lightTracingShadowBlur > 0)
				{
					cmd.GetTemporaryRT(m_tmp, m_desc);
					PugRPUtils.BlurTexture(cmd, m_shadows, m_tmp, m_desc.width, m_desc.height, useUnorm: true, context.pugCamera.lightTracingShadowBlur);
					cmd.ReleaseTemporaryRT(m_tmp);
				}
				cmd.SetGlobalTexture(ShaderIDs.LTShadows, m_shadows);
				cmd.SetGlobalFloat(ShaderIDs.LTShadowSharpen, context.pugCamera.lightTracingShadowSharpen);
				cmd.SetKeyword(in s_shadowKeyword, value: true);
			}
			else
			{
				cmd.SetKeyword(in s_shadowKeyword, value: false);
			}
			cmd.SetGlobalFloat(ShaderIDs.LTMaxSampleCount, context.pugCamera.lightTracingMaxSampleCount);
			cmd.SetKeyword(in s_featureKeyword, value: true);
		}

		public override void ExecuteDisabled(PugRPContext context, CommandBuffer cmd)
		{
			cmd.SetGlobalTexture(ShaderIDs.LTShadows, Texture2D.whiteTexture);
			cmd.SetGlobalTexture(ShaderIDs.LTOcclusion, Texture2D.whiteTexture);
			cmd.SetGlobalTexture(ShaderIDs.LTTransmittance, Texture2D.whiteTexture);
			cmd.SetKeyword(in s_featureKeyword, value: false);
			cmd.SetKeyword(in s_occlusionKeyword, value: false);
			cmd.SetKeyword(in s_transmittanceKeyword, value: false);
		}

		protected override void DisposeInternal()
		{
			PugRPUtils.Release(ref m_shadows);
			PugRPUtils.Release(ref m_occlusion);
			PugRPUtils.Release(ref m_transmittance);
		}
	}
}
