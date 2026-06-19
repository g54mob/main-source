using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public class VolumetricLightRenderFeature : RenderFeature
	{
		private RenderTexture m_volumetricLight;

		private RenderTexture m_volumetricLightDirect;

		private RenderTextureDescriptor m_volumetricLightDesc;

		private int m_sliceTarget = Shader.PropertyToID("Volumetric Light Slice Target");

		private Camera m_internalCamera;

		private Matrix4x4 m_worldToVolumetric;

		private List<string> m_sliceNames = new List<string>();

		private Vector3Int m_resolution;

		private Vector3 m_size;

		public override bool usesCulling => false;

		public override string sampleName => "Volumetric Light";

		public override string sampleNameEarly => "Volumetric Light (Early)";

		public override string sampleNameLate => "Volumetric Light (Late)";

		public override string featurePassKeyword => "VOLUMETRIC_INPUT";

		public override RenderPipelineStage executionStageEarly => RenderPipelineStage.BeforeEverything;

		public override RenderPipelineStage executionStageLate => RenderPipelineStage.BeforeEverything;

		public RenderTexture irradiance => m_volumetricLight;

		public RenderTexture irradianceDirect => m_volumetricLightDirect;

		public Matrix4x4 worldToVolumetric => m_worldToVolumetric;

		public Vector3Int resolution => m_resolution;

		public Vector3 size => m_size;

		public override void ValidateFrame(PugRPContext context)
		{
			base.isValid = context.camera != null && context.pugCamera != null && context.pugCamera.volumetricLight == VolumetricLightingType._3DBuffer && context.pugCamera.volumetricLightAnchor != null;
		}

		public override void OnBeginValidFrame(PugRPContext context)
		{
			if (m_internalCamera == null)
			{
				m_internalCamera = PugRPUtils.GetUtilityCamera("_VOLUMETRIC_LIGHT_CAMERA");
			}
			Vector3 volumetricLightSize = context.pugCamera.volumetricLightSize;
			float volumetricLightPPU = context.pugCamera.volumetricLightPPU;
			int num = Mathf.CeilToInt(volumetricLightSize.x * volumetricLightPPU);
			int num2 = Mathf.CeilToInt(volumetricLightSize.y * volumetricLightPPU);
			if (Mathf.Max(num, num2) > 1024)
			{
				Debug.LogError("Excessive volumetric light buffer resolution! Reduce the size or lower PPU");
				num = Mathf.Min(num, 1024);
				num2 = Mathf.Min(num2, 1024);
			}
			m_resolution = new Vector3Int(num, num2, context.pugCamera.volumetricLightDepthSlices);
			m_size = new Vector3((float)m_resolution.x / volumetricLightPPU, (float)m_resolution.y / volumetricLightPPU, volumetricLightSize.z);
			m_volumetricLightDesc = new RenderTextureDescriptor(m_resolution.x, m_resolution.y, PugRPUtils.floatNoAlphaFormat)
			{
				dimension = TextureDimension.Tex3D,
				volumeDepth = m_resolution.z,
				enableRandomWrite = true
			};
			PugRPUtils.Setup(ref m_volumetricLight, "Volumetric Light", m_volumetricLightDesc);
			PugRPUtils.Setup(ref m_volumetricLightDirect, "Volumetric Light (Direct Only)", m_volumetricLightDesc);
		}

		public override void Cull(PugRPContext context)
		{
			Transform volumetricLightAnchor = context.pugCamera.volumetricLightAnchor;
			Vector3 vector = PugRPUtils.SnapBufferPosition(volumetricLightAnchor.position, volumetricLightAnchor.rotation, m_size, m_resolution);
			Vector3 vector2 = m_size / 2f;
			m_internalCamera.transform.position = vector - volumetricLightAnchor.forward * vector2.z;
			m_internalCamera.transform.rotation = volumetricLightAnchor.rotation;
			m_internalCamera.orthographic = true;
			m_internalCamera.orthographicSize = vector2.y;
			m_internalCamera.aspect = vector2.x / vector2.y;
			m_internalCamera.nearClipPlane = 0.01f;
			m_internalCamera.farClipPlane = vector2.z * 2f;
			Matrix4x4 inverse = Matrix4x4.TRS(m_internalCamera.transform.position, m_internalCamera.transform.rotation, new Vector3(1f, 1f, -1f)).inverse;
			Matrix4x4 matrix4x = Matrix4x4.Ortho(0f - vector2.x, vector2.x, 0f - vector2.y, vector2.y, m_internalCamera.nearClipPlane, m_internalCamera.farClipPlane);
			m_worldToVolumetric = matrix4x * inverse;
			m_internalCamera.worldToCameraMatrix = inverse;
			m_internalCamera.projectionMatrix = matrix4x;
			m_internalCamera.cullingMask = 0;
		}

		public override void ExecuteEarly(PugRPContext context, CommandBuffer cmd)
		{
			PugRP.SetupCameraProperties(context, cmd, m_internalCamera);
			RenderTextureDescriptor volumetricLightDesc = m_volumetricLightDesc;
			volumetricLightDesc.dimension = TextureDimension.Tex2D;
			volumetricLightDesc.enableRandomWrite = true;
			for (int i = 0; i < m_resolution.z; i++)
			{
				if (i >= m_sliceNames.Count)
				{
					m_sliceNames.Add("Slice " + i);
				}
				cmd.BeginSample(m_sliceNames[i]);
				cmd.SetGlobalFloat(ShaderIDs.FixedDepth, ((float)i + 0.5f) / (float)m_resolution.z);
				cmd.SetRenderTarget(m_volumetricLight, 0, CubemapFace.Unknown, i);
				cmd.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
				PugRP.DrawDeferredLight(cmd, DeferredLightPass.DirectOnly, isVolumetricInput: true);
				cmd.EndSample(m_sliceNames[i]);
			}
			cmd.CopyTexture(m_volumetricLight, m_volumetricLightDirect);
			cmd.SetGlobalTexture(ShaderIDs.VolumetricLight, m_volumetricLight);
			cmd.SetGlobalTexture(ShaderIDs.VolumetricLightDirect, m_volumetricLightDirect);
			cmd.SetGlobalMatrix(ShaderIDs.WorldToVolumetric, PugRPUtils.AdjustBufferMatrix(m_worldToVolumetric, applyToZ: true));
		}

		public override void ExecuteLate(PugRPContext context, CommandBuffer cmd)
		{
			PugRP.SetupCameraProperties(context, cmd, m_internalCamera);
			RenderTextureDescriptor volumetricLightDesc = m_volumetricLightDesc;
			volumetricLightDesc.dimension = TextureDimension.Tex2D;
			volumetricLightDesc.enableRandomWrite = true;
			bool flag = context.pugCamera.volumetricLightBlur > Mathf.Epsilon;
			if (flag)
			{
				cmd.GetTemporaryRT(m_sliceTarget, volumetricLightDesc);
			}
			for (int i = 0; i < m_resolution.z; i++)
			{
				cmd.BeginSample(m_sliceNames[i]);
				cmd.SetGlobalFloat(ShaderIDs.FixedDepth, ((float)i + 0.5f) / (float)m_resolution.z);
				if (flag)
				{
					cmd.CopyTexture(m_volumetricLight, i, m_sliceTarget, 0);
					cmd.SetRenderTarget(m_sliceTarget);
				}
				else
				{
					cmd.SetRenderTarget(m_volumetricLight, 0, CubemapFace.Unknown, i);
				}
				PugRP.DrawDeferredLight(cmd, DeferredLightPass.IndirectOnly, isVolumetricInput: true);
				if (flag)
				{
					PugRPUtils.WideBlur(cmd, m_sliceTarget, volumetricLightDesc, context.pugCamera.volumetricLightBlur, 1f - context.pugCamera.volumetricLightBlurBlend);
					cmd.CopyTexture(m_sliceTarget, 0, m_volumetricLight, i);
				}
				cmd.EndSample(m_sliceNames[i]);
			}
			if (flag)
			{
				cmd.ReleaseTemporaryRT(m_sliceTarget);
			}
			cmd.SetGlobalTexture(ShaderIDs.VolumetricLight, m_volumetricLight);
			cmd.SetGlobalTexture(ShaderIDs.VolumetricLightDirect, m_volumetricLightDirect);
			cmd.SetGlobalMatrix(ShaderIDs.WorldToVolumetric, PugRPUtils.AdjustBufferMatrix(m_worldToVolumetric, applyToZ: true));
			cmd.SetGlobalFloat(ShaderIDs.VolumetricLightDepthBias, (0f - context.pugCamera.volumetricLightDepthBias) / (float)context.pugCamera.volumetricLightDepthSlices);
		}

		public override void ExecuteDisabled(PugRPContext context, CommandBuffer cmd)
		{
		}

		protected override void DisposeInternal()
		{
			PugRPUtils.Release(ref m_volumetricLight);
			PugRPUtils.Release(ref m_volumetricLightDirect);
		}
	}
}
