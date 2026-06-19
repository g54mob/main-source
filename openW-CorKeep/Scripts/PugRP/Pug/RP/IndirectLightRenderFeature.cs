using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;

namespace Pug.RP
{
	public class IndirectLightRenderFeature : RenderFeature
	{
		private const int CS_KERNEL_GATHER_PATH_TRACING = 0;

		private const int CS_KERNEL_GATHER_MULTIRES = 1;

		private const int CS_KERNEL_DOWNSAMPLE = 2;

		private const int CS_KERNEL_RADIANCE_CASCADE = 3;

		private const int CS_KERNEL_RADIANCE_CASCADE_MERGE = 4;

		private const int CS_KERNEL_RADIANCE_CASCADE_FINAL = 5;

		private const int M_PASS_UPSCALE = 0;

		private const int M_PASS_UPSCALECOMBINE = 1;

		private const int M_PASS_NEXTBOUNCEINPUT = 2;

		private const int M_PASS_ADD = 3;

		private const int M_PASS_EDGERADIANCE = 4;

		private static GlobalKeyword s_indirectInputKeyword = GlobalKeyword.Create("INDIRECT_INPUT");

		private static GlobalKeyword s_highQualityUpsamplingKeyword = GlobalKeyword.Create("HIGH_QUALITY_INDIRECT_UPSAMPLING");

		private static GlobalKeyword s_gatherModeMaxKeyword = GlobalKeyword.Create("GATHER_MODE_MAX");

		private static GlobalKeyword s_disableOutput2Keyword = GlobalKeyword.Create("DISABLE_OUTPUT_2");

		private static GlobalKeyword s_radianceCascadesEnabledKeyword = GlobalKeyword.Create("RADIANCE_CASCADES_ENABLED");

		private static GlobalKeyword s_edgeRadianceEnabledKeyword = GlobalKeyword.Create("EDGE_RADIANCE_ENABLED");

		private static int s_indirectInput = Shader.PropertyToID("_IndirectInput");

		private static int m_gatherTmp = Shader.PropertyToID("_GatherTmp");

		private static int m_irradiancePrev = Shader.PropertyToID("Irradiance (Previous)");

		private static int m_radianceCascadeTmp = Shader.PropertyToID("Radiance Cascade (Tmp)");

		private ComputeShader m_computeShader;

		private Material m_material;

		private RenderTexture m_radiance;

		private RenderTexture m_irradiance;

		private RenderTextureDescriptor m_radianceDesc;

		private RenderTextureDescriptor m_irradianceDesc;

		private List<RenderTexture> m_gatherPasses = new List<RenderTexture>();

		private List<RenderTexture> m_inputPasses = new List<RenderTexture>();

		private List<RenderTexture> m_bentNormalPasses = new List<RenderTexture>();

		private List<string> m_gatherPassNames = new List<string>();

		private List<string> m_inputPassNames = new List<string>();

		private List<string> m_bentNormalPassNames = new List<string>();

		private List<string> m_bounceSampleNames = new List<string>();

		private GBufferData m_gbuffer;

		private Camera m_internalCamera;

		private Matrix4x4 m_worldToIndirect;

		private Matrix4x4 m_prevWorldToIndirect;

		private Vector3 m_prevCameraPosition;

		private Matrix4x4 m_projection;

		private Matrix4x4 m_view;

		private bool m_enableBentNormal;

		private LocalKeyword m_kwdGatherBentNormal;

		private bool m_hasHistory;

		private RenderTexture m_separateBlockerDepth;

		private float m_texelSize;

		private int m_multiResSamplesPerPass;

		private RenderTextureFormat m_radianceFormat;

		private int m_radianceCascadeCount;

		private static ShaderTagId s_depthOnlyShaderTagID = new ShaderTagId("DepthOnly");

		private static int[] s_radianceCascades = new int[8]
		{
			Shader.PropertyToID("_RadianceCascade0"),
			Shader.PropertyToID("_RadianceCascade1"),
			Shader.PropertyToID("_RadianceCascade2"),
			Shader.PropertyToID("_RadianceCascade3"),
			Shader.PropertyToID("_RadianceCascade4"),
			Shader.PropertyToID("_RadianceCascade5"),
			Shader.PropertyToID("_RadianceCascade6"),
			Shader.PropertyToID("_RadianceCascade7")
		};

		private static RenderTextureDescriptor[] s_radianceCascadeDescs = new RenderTextureDescriptor[8];

		private RenderTexture m_topRadianceCascade;

		private static int s_edgeRadiance = Shader.PropertyToID("_EdgeRadiance");

		public override bool usesCulling => true;

		public override string sampleName => "Indirect Light";

		public override string sampleNameEarly => "Indirect Light (Early)";

		public override string sampleNameLate => "Indirect Light (Late)";

		public override RenderPipelineStage executionStageEarly => RenderPipelineStage.BeforeLightUpdate;

		public override RenderPipelineStage executionStage => RenderPipelineStage.BeforeEverything;

		public RenderTexture irradiance => m_irradiance;

		public RenderTexture radiance => m_radiance;

		public GBufferData gbuffer => m_gbuffer;

		public Matrix4x4 view => m_view;

		public Matrix4x4 projection => m_projection;

		public Matrix4x4 worldToIndirect => m_worldToIndirect;

		public Camera internalCamera => m_internalCamera;

		public event Action<IndirectLightRenderFeature, PugRPContext, CommandBuffer> onDrawInput;

		public IndirectLightRenderFeature()
		{
			m_gbuffer = new GBufferData();
		}

		public override void ValidateFrame(PugRPContext context)
		{
			base.isValid = context.camera != null && context.pugCamera != null && context.pugCamera.indirectLight == IndirectLightingType._2DBuffer && context.pugCamera.indirectLightAnchor != null && context.shouldRenderDeferredPass;
		}

		public override void OnBeginValidFrame(PugRPContext context)
		{
			if (m_internalCamera == null)
			{
				m_internalCamera = PugRPUtils.GetUtilityCamera("_INDIRECT_LIGHT_CAMERA");
			}
			m_enableBentNormal = context.pugCamera.indirectLighting2DGatherMethod == IndirectLighting2DGatherMethod.MultiResolution && context.pugCamera.enableSSAO && context.pugCamera.ssaoSettings.directionality > Mathf.Epsilon;
			int x = context.pugCamera.indirectLightResolution.x;
			int y = context.pugCamera.indirectLightResolution.y;
			m_radianceFormat = (context.pugCamera.indirectLightHighPrecision ? RenderTextureFormat.ARGBFloat : RenderTextureFormat.ARGBHalf);
			m_gbuffer.Setup(x, y, depthIsShadowmap: true);
			if (context.pugCamera.indirectLightSeparateBlockerPass)
			{
				PugRPUtils.Setup(ref m_separateBlockerDepth, "Separate Blocker Dpeth", m_gbuffer.depth.descriptor);
			}
			else
			{
				PugRPUtils.Release(ref m_separateBlockerDepth);
			}
			m_radianceDesc = new RenderTextureDescriptor(x, y, m_radianceFormat)
			{
				enableRandomWrite = true
			};
			PugRPUtils.Setup(ref m_radiance, "Radiance", m_radianceDesc);
			m_irradianceDesc = new RenderTextureDescriptor(x, y, m_radianceFormat)
			{
				enableRandomWrite = true
			};
			if (PugRPUtils.Setup(ref m_irradiance, "Indirect Irradiance", m_irradianceDesc))
			{
				m_hasHistory = false;
			}
			if (PugRPUtils.EnsureLoadedResource(ref m_computeShader, "Shaders/IndirectLight"))
			{
				m_kwdGatherBentNormal = new LocalKeyword(m_computeShader, "GATHER_BENT_NORMAL");
			}
			PugRPUtils.EnsureLoadedMaterial(ref m_material, "Hidden/PugRP/IndirectLight");
			m_texelSize = context.pugCamera.GetIndirectLightTexelSize();
			m_multiResSamplesPerPass = context.pugCamera.indirectLightSamplesPerPass;
			int num = 0;
			int inputPassCount = 0;
			switch (context.pugCamera.indirectLighting2DGatherMethod)
			{
			case IndirectLighting2DGatherMethod.MultiResolution:
				num = (inputPassCount = context.pugCamera.indirectLightPassCount);
				break;
			case IndirectLighting2DGatherMethod.RadianceCascades:
			{
				int num2 = x;
				int num3 = y;
				m_radianceCascadeCount = 0;
				for (int i = 0; i < context.pugCamera.indirectLightRadianceCascadeCount; i++)
				{
					m_radianceCascadeCount++;
					num2 /= 2;
					num3 /= 2;
					if (Mathf.Min(num2, num3) < 2)
					{
						break;
					}
				}
				inputPassCount = m_radianceCascadeCount;
				break;
			}
			}
			ConfigureGatherPasses(num);
			ConfigureInputPasses(inputPassCount);
			int bentNormalPassCount = (m_enableBentNormal ? num : 0);
			ConfigureBentNormalPasses(bentNormalPassCount);
			while (m_bounceSampleNames.Count < context.pugCamera.indirectLightBounceCount)
			{
				m_bounceSampleNames.Add("Bounce " + (m_bounceSampleNames.Count + 1));
			}
		}

		private void ConfigureGatherPasses(int gatherPassCount)
		{
			RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(m_radianceDesc.width, m_radianceDesc.height, m_radianceFormat);
			renderTextureDescriptor.enableRandomWrite = true;
			RenderTextureDescriptor desc = renderTextureDescriptor;
			while (m_gatherPasses.Count < gatherPassCount)
			{
				m_gatherPasses.Add(null);
			}
			while (m_gatherPasses.Count > gatherPassCount)
			{
				int index = m_gatherPasses.Count - 1;
				RenderTexture rt = m_gatherPasses[index];
				PugRPUtils.Release(ref rt);
				m_gatherPasses.RemoveAt(index);
			}
			for (int i = 0; i < m_gatherPasses.Count; i++)
			{
				if (m_gatherPassNames.Count < i + 1)
				{
					m_gatherPassNames.Add("GatherPass_" + i);
					m_inputPassNames.Add("InputPass_" + i);
				}
				RenderTexture rt2 = m_gatherPasses[i];
				if (PugRPUtils.Setup(ref rt2, m_gatherPassNames[i], desc))
				{
					m_gatherPasses[i] = rt2;
				}
				desc.width /= 2;
				desc.height /= 2;
			}
		}

		private void ConfigureInputPasses(int inputPassCount)
		{
			RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(m_radianceDesc.width, m_radianceDesc.height, m_radianceFormat);
			renderTextureDescriptor.enableRandomWrite = true;
			RenderTextureDescriptor desc = renderTextureDescriptor;
			while (m_inputPasses.Count < inputPassCount)
			{
				m_inputPasses.Add(null);
			}
			while (m_inputPasses.Count > inputPassCount)
			{
				int index = m_inputPasses.Count - 1;
				RenderTexture rt = m_inputPasses[index];
				PugRPUtils.Release(ref rt);
				m_inputPasses.RemoveAt(index);
			}
			for (int i = 0; i < m_inputPasses.Count; i++)
			{
				if (m_inputPassNames.Count < i + 1)
				{
					m_inputPassNames.Add("InputPass_" + i);
				}
				RenderTexture rt2 = m_inputPasses[i];
				if (PugRPUtils.Setup(ref rt2, m_inputPassNames[i], desc))
				{
					m_inputPasses[i] = rt2;
				}
				desc.width /= 2;
				desc.height /= 2;
			}
		}

		private void ConfigureBentNormalPasses(int bentNormalPassCount)
		{
			RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(m_radianceDesc.width, m_radianceDesc.height, RenderTextureFormat.RGHalf);
			renderTextureDescriptor.enableRandomWrite = true;
			RenderTextureDescriptor desc = renderTextureDescriptor;
			while (m_bentNormalPasses.Count < bentNormalPassCount)
			{
				m_bentNormalPasses.Add(null);
			}
			while (m_bentNormalPasses.Count > bentNormalPassCount)
			{
				RenderTexture rt = m_bentNormalPasses[m_bentNormalPasses.Count - 1];
				PugRPUtils.Release(ref rt);
				m_bentNormalPasses.RemoveAt(m_bentNormalPasses.Count - 1);
			}
			for (int i = 0; i < m_bentNormalPasses.Count; i++)
			{
				desc.width /= 2;
				desc.height /= 2;
				RenderTexture rt2 = m_bentNormalPasses[i];
				if (m_bentNormalPassNames.Count < i + 1)
				{
					m_bentNormalPassNames.Add("BentNormalPass_" + i);
				}
				if (PugRPUtils.Setup(ref rt2, m_bentNormalPassNames[i], desc))
				{
					m_bentNormalPasses[i] = rt2;
				}
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
			m_view = Matrix4x4.TRS(m_internalCamera.transform.position, m_internalCamera.transform.rotation, new Vector3(1f, 1f, -1f)).inverse;
			m_projection = Matrix4x4.Ortho(0f - vector2.x, vector2.x, 0f - vector2.y, vector2.y, m_internalCamera.nearClipPlane, m_internalCamera.farClipPlane);
			m_internalCamera.worldToCameraMatrix = m_view;
			m_internalCamera.projectionMatrix = m_projection;
			m_internalCamera.cullingMask = context.pugCamera.indirectLightLayers;
			Matrix4x4 inverse = Matrix4x4.TRS(m_prevCameraPosition - PugRP.origin, m_internalCamera.transform.rotation, new Vector3(1f, 1f, -1f)).inverse;
			Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(m_projection, renderIntoTexture: false);
			m_prevWorldToIndirect = PugRPUtils.AdjustBufferMatrix(gPUProjectionMatrix * inverse);
			m_worldToIndirect = PugRPUtils.AdjustBufferMatrix(gPUProjectionMatrix * m_view);
			Cull(context, m_internalCamera);
			m_prevCameraPosition = m_internalCamera.transform.position + PugRP.origin;
		}

		public override void ExecuteEarly(PugRPContext context, CommandBuffer cmd)
		{
			if (GetCullingResults(out var cullingResults))
			{
				PugRP.SetupCameraProperties(context, cmd, m_internalCamera);
				SetCommon(context, cmd);
				cmd.SetKeyword(in s_indirectInputKeyword, value: true);
				cmd.SetGlobalFloat(s_indirectInput, 1f);
				m_gbuffer.Draw(context.srp, cmd, m_internalCamera, cullingResults, GBufferData.DrawType.Indirect);
				if (context.pugCamera.indirectLightSeparateBlockerPass)
				{
					RendererListDesc rendererListDesc = new RendererListDesc(s_depthOnlyShaderTagID, cullingResults, m_internalCamera);
					rendererListDesc.renderQueueRange = RenderQueueRange.opaque;
					rendererListDesc.sortingCriteria = SortingCriteria.RenderQueue | SortingCriteria.OptimizeStateChanges;
					rendererListDesc.layerMask = context.pugCamera.indirectLightSeparateBlockerPassLayers;
					RendererListDesc desc = rendererListDesc;
					RendererList rendererList = context.srp.CreateRendererList(desc);
					cmd.BeginSample("DepthOnly");
					cmd.SetRenderTarget(m_separateBlockerDepth);
					cmd.ClearRenderTarget(clearDepth: true, clearColor: false, Color.clear);
					cmd.DrawRendererList(rendererList);
					cmd.EndSample("DepthOnly");
					cmd.SetGlobalTexture(ShaderIDs.IndirectBlockerDepthTexture, m_separateBlockerDepth);
				}
				else
				{
					cmd.SetGlobalTexture(ShaderIDs.IndirectBlockerDepthTexture, m_gbuffer.depth);
				}
				cmd.SetKeyword(in s_indirectInputKeyword, value: false);
				cmd.SetGlobalFloat(s_indirectInput, 0f);
			}
		}

		public override void Execute(PugRPContext context, CommandBuffer cmd)
		{
			if (!GetCullingResults(out var cullingResults))
			{
				return;
			}
			SetCommon(context, cmd);
			PugRP.SetupCameraProperties(context, cmd, m_internalCamera);
			bool flag = context.pugCamera.indirectLightFeedback > Mathf.Epsilon && m_hasHistory;
			float num = context.pugCamera.indirectLightFeedback / Mathf.Pow(2f, (float)context.pugCamera.indirectLightBounceCount - 0.5f);
			cmd.BeginSample("Radiance");
			cmd.SetKeyword(in s_indirectInputKeyword, value: true);
			cmd.SetGlobalFloat(s_indirectInput, 1f);
			if (flag)
			{
				cmd.GetTemporaryRT(m_irradiancePrev, m_irradiance.descriptor);
				cmd.CopyTexture(m_irradiance, m_irradiancePrev);
				cmd.SetGlobalTexture(ShaderIDs.IndirectIrradiance, m_irradiancePrev);
				cmd.SetGlobalMatrix(ShaderIDs.PrevWorldToIndirect, m_prevWorldToIndirect);
			}
			else
			{
				cmd.SetGlobalTexture(ShaderIDs.IndirectIrradiance, Texture2D.blackTexture);
			}
			bool flag2 = context.pugCamera.indirectLightEdgeRadiance > Mathf.Epsilon;
			cmd.SetKeyword(in s_edgeRadianceEnabledKeyword, flag2);
			if (flag2)
			{
				cmd.GetTemporaryRT(s_edgeRadiance, m_radiance.descriptor);
				cmd.SetRenderTarget(s_edgeRadiance);
				cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, m_material, 0, 4);
				cmd.SetGlobalTexture(ShaderIDs.IndirectEdgeRadiance, s_edgeRadiance);
				cmd.SetGlobalFloat(ShaderIDs.IndirectEdgeRadianceAmount, context.pugCamera.indirectLightEdgeRadiance);
			}
			cmd.SetRenderTarget(m_radiance);
			cmd.ClearRenderTarget(clearDepth: true, clearColor: true, new Color(0f, 0f, 0f, 1f));
			cmd.SetGlobalFloat(ShaderIDs.IndirectLightFeedback, flag ? num : 0f);
			PugRP.DrawDeferredLight(cmd);
			cmd.SetGlobalMatrix(ShaderIDs.WorldToIndirect, m_worldToIndirect);
			cmd.SetGlobalMatrix(ShaderIDs.IndirectToWorld, m_worldToIndirect.inverse);
			cmd.SetGlobalTexture(ShaderIDs.OpaqueTexture, Texture2D.blackTexture);
			cmd.SetRenderTarget(m_radiance, m_gbuffer.depth);
			PugRP.DrawForwardOpaque(context, cmd, m_internalCamera, cullingResults);
			PugRP.PostProcessOpaque(context, cmd, radiance, m_gbuffer.depth, m_radianceDesc);
			cmd.SetRenderTarget(m_radiance, m_gbuffer.depth);
			PugRP.DrawForwardTransparent(context, cmd, m_internalCamera, cullingResults);
			if (flag2)
			{
				cmd.ReleaseTemporaryRT(s_edgeRadiance);
			}
			if (this.onDrawInput != null)
			{
				cmd.SetRenderTarget(m_radiance);
				this.onDrawInput(this, context, cmd);
			}
			cmd.SetKeyword(in s_indirectInputKeyword, value: false);
			cmd.SetGlobalFloat(s_indirectInput, 0f);
			cmd.EndSample("Radiance");
			PugCamera pugCamera = context.pugCamera;
			cmd.SetKeyword(in s_highQualityUpsamplingKeyword, pugCamera.indirectLightHighQualityUpsampling);
			cmd.SetKeyword(in s_gatherModeMaxKeyword, pugCamera.indirectLighting2DGatherMethod == IndirectLighting2DGatherMethod.MultiResolution && pugCamera.indirectLightingGatherMode == IndirectLightingGatherMode.Max);
			cmd.SetKeyword(in s_radianceCascadesEnabledKeyword, pugCamera.indirectLighting2DGatherMethod == IndirectLighting2DGatherMethod.RadianceCascades);
			cmd.BeginSample("Irradiance");
			int indirectLightBounceCount = pugCamera.indirectLightBounceCount;
			cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.RayCount, pugCamera.indirectLightRayCount);
			for (int i = 0; i < indirectLightBounceCount; i++)
			{
				cmd.BeginSample(m_bounceSampleNames[i]);
				switch (pugCamera.indirectLighting2DGatherMethod)
				{
				case IndirectLighting2DGatherMethod.PathTracing:
					GatherPathTracing(cmd, pugCamera, i, indirectLightBounceCount);
					break;
				case IndirectLighting2DGatherMethod.MultiResolution:
					GatherMultiResolution(cmd, pugCamera, i, indirectLightBounceCount);
					break;
				case IndirectLighting2DGatherMethod.RadianceCascades:
					GatherRadianceCascades(cmd, pugCamera, i, indirectLightBounceCount);
					break;
				}
				cmd.EndSample(m_bounceSampleNames[i]);
			}
			cmd.EndSample("Irradiance");
			cmd.BeginSample("Post-process");
			if (pugCamera.indirectLightBilateralBlur > 0)
			{
				cmd.GetTemporaryRT(m_gatherTmp, m_irradiance.descriptor);
				PugRPUtils.BlurTexture(cmd, m_irradiance, m_gatherTmp, m_irradiance.width, m_irradiance.height, useUnorm: false, pugCamera.indirectLightBilateralBlur, bilateralAlpha: true);
				cmd.ReleaseTemporaryRT(m_gatherTmp);
			}
			if (pugCamera.indirectLightBlur > 0f)
			{
				PugRPUtils.WideBlur(cmd, m_irradiance, m_irradiance.descriptor, pugCamera.indirectLightBlur);
			}
			if (m_enableBentNormal)
			{
				cmd.SetGlobalTexture(ShaderIDs.IndirectBentNormal, m_bentNormalPasses[0]);
			}
			else
			{
				cmd.SetGlobalTexture(ShaderIDs.IndirectBentNormal, Texture2D.blackTexture);
			}
			cmd.SetGlobalTexture(ShaderIDs.IndirectIrradiance, m_irradiance);
			cmd.SetGlobalVector(ShaderIDs.IndirectBoostParams, new Vector4(Mathf.Max(0.001f, 1f - pugCamera.indirectLightBoost), pugCamera.indirectLightBoostLimit, 0f, 0f));
			cmd.SetGlobalFloat(ShaderIDs.IndirectNormalBias, pugCamera.indirectLightNormalBias);
			cmd.SetGlobalVector(ShaderIDs.IndirectSize, new Vector4(m_irradiance.width, m_irradiance.height, 1f / (float)m_irradiance.width, 1f / (float)m_irradiance.height));
			if (flag)
			{
				cmd.ReleaseTemporaryRT(m_irradiancePrev);
			}
			cmd.EndSample("Post-process");
			m_hasHistory = true;
		}

		private void GatherPathTracing(CommandBuffer cmd, PugCamera pugCamera, int bounceIndex, int bounceCount)
		{
			int width = m_irradiance.width;
			int height = m_irradiance.height;
			cmd.GetTemporaryRT(m_gatherTmp, m_irradiance.descriptor);
			Vector2Int threadGroupCount = PugRPUtils.GetThreadGroupCount(8, width, height);
			cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.SampleCount, Mathf.CeilToInt(pugCamera.indirectLightSpread / m_texelSize));
			cmd.BeginSample("Gather (Path tracing)");
			cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.InputSize, new Vector2(m_radiance.width, m_radiance.height));
			cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.OutputSize, new Vector2(width, height));
			cmd.SetComputeTextureParam(m_computeShader, 0, ShaderIDs.Input, m_radiance);
			cmd.SetComputeTextureParam(m_computeShader, 0, ShaderIDs.Output, m_gatherTmp);
			cmd.DispatchCompute(m_computeShader, 0, threadGroupCount.x, threadGroupCount.y, 1);
			if (bounceIndex == 0)
			{
				cmd.CopyTexture(m_gatherTmp, m_irradiance);
			}
			else
			{
				cmd.Blit(m_gatherTmp, m_irradiance, m_material, 3);
			}
			cmd.Blit(m_gatherTmp, m_radiance, m_material, 2);
			cmd.ReleaseTemporaryRT(m_gatherTmp);
			cmd.EndSample("Gather (Path tracing)");
		}

		private void GatherMultiResolution(CommandBuffer cmd, PugCamera pugCamera, int bounceIndex, int bounceCount)
		{
			int maxIndirectLightSkipPasses = pugCamera.GetMaxIndirectLightSkipPasses();
			float num = pugCamera.indirectLightRayCount;
			cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.SampleCount, pugCamera.indirectLightSamplesPerPass);
			cmd.BeginSample("Gather (Multi-resolution)");
			int num2 = m_gatherPasses[0].width;
			int num3 = m_gatherPasses[0].height;
			for (int i = 0; i < m_gatherPasses.Count; i++)
			{
				Vector2Int threadGroupCount = PugRPUtils.GetThreadGroupCount(8, num2, num3);
				cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.Offset, (i > 0) ? (pugCamera.indirectLightSamplesPerPass / 2) : 0);
				cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.RayCount, Mathf.CeilToInt(num));
				num *= pugCamera.indirectLightRayCountExponent;
				cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.InputSize, new Vector2(num2, num3));
				cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.OutputSize, new Vector2(num2, num3) / 2f);
				_ = 1f / Mathf.Pow(2f, m_gatherPasses.Count - 1 - i);
				cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.Weight, (float)i / (float)m_gatherPasses.Count);
				bool flag = i == m_gatherPasses.Count - 1;
				cmd.SetKeyword(in s_disableOutput2Keyword, flag);
				RenderTargetIdentifier rt = ((i == 0) ? m_radiance : m_inputPasses[i]);
				cmd.SetGlobalFloat(ShaderIDs.IndirectLeakPrevention, pugCamera.indirectLightLeakPrevention);
				cmd.SetGlobalFloat(ShaderIDs.IndirectUpscaling, pugCamera.indirectLightUpscaling);
				if (i < maxIndirectLightSkipPasses && i < m_gatherPasses.Count - 1)
				{
					if (bounceIndex == 0 && m_enableBentNormal)
					{
						cmd.SetRenderTarget(m_bentNormalPasses[i]);
						cmd.ClearRenderTarget(clearDepth: false, clearColor: true, Color.clear);
					}
					cmd.SetComputeTextureParam(m_computeShader, 2, ShaderIDs.Input, rt);
					cmd.SetComputeTextureParam(m_computeShader, 2, ShaderIDs.Output, m_inputPasses[i + 1]);
					if (!flag)
					{
						cmd.SetComputeTextureParam(m_computeShader, 2, ShaderIDs.Output2, m_gatherPasses[i + 1]);
					}
					cmd.DispatchCompute(m_computeShader, 2, threadGroupCount.x, threadGroupCount.y, 1);
				}
				else
				{
					cmd.SetComputeTextureParam(m_computeShader, 1, ShaderIDs.Input, rt);
					cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.Pass, i);
					cmd.SetComputeTextureParam(m_computeShader, 1, ShaderIDs.Output, m_gatherPasses[i]);
					if (!flag)
					{
						cmd.SetComputeTextureParam(m_computeShader, 1, ShaderIDs.Output2, m_inputPasses[i + 1]);
					}
					if (bounceIndex == 0 && m_enableBentNormal)
					{
						cmd.SetComputeTextureParam(m_computeShader, 1, ShaderIDs.BentNormal, m_bentNormalPasses[i]);
						cmd.SetKeyword(m_computeShader, in m_kwdGatherBentNormal, value: true);
					}
					else
					{
						cmd.SetKeyword(m_computeShader, in m_kwdGatherBentNormal, value: false);
					}
					cmd.DispatchCompute(m_computeShader, 1, threadGroupCount.x, threadGroupCount.y, 1);
				}
				num2 /= 2;
				num3 /= 2;
			}
			cmd.EndSample("Gather (Multi-resolution)");
			cmd.BeginSample("Upsample (Multi-resolution)");
			for (int num4 = m_gatherPasses.Count - 1; num4 > 0; num4--)
			{
				float num5 = Mathf.Pow(2f, num4);
				float value = 1f - 1f / Mathf.Pow(2f, num5 * pugCamera.indirectLightLeakPrevention);
				if (num4 > maxIndirectLightSkipPasses)
				{
					cmd.SetGlobalFloat(ShaderIDs.IndirectLeakPrevention, value);
					cmd.Blit(m_gatherPasses[num4], m_gatherPasses[num4 - 1], m_material, 1);
					if (bounceIndex == 0 && m_enableBentNormal)
					{
						cmd.SetGlobalFloat(ShaderIDs.IndirectLeakPrevention, -1f);
						cmd.Blit(m_bentNormalPasses[num4], m_bentNormalPasses[num4 - 1], m_material, 1);
					}
				}
				else
				{
					cmd.SetGlobalFloat(ShaderIDs.IndirectLeakPrevention, value);
					cmd.Blit(m_gatherPasses[num4], m_gatherPasses[num4 - 1], m_material, 0);
					if (bounceIndex == 0 && m_enableBentNormal)
					{
						cmd.SetGlobalFloat(ShaderIDs.IndirectLeakPrevention, -1f);
						cmd.Blit(m_bentNormalPasses[num4], m_bentNormalPasses[num4 - 1], m_material, 0);
					}
				}
			}
			cmd.EndSample("Upsample (Multi-resolution)");
			if (bounceIndex == 0)
			{
				cmd.CopyTexture(m_gatherPasses[0], m_irradiance);
			}
			else
			{
				cmd.Blit(m_gatherPasses[0], m_irradiance, m_material, 3);
			}
			if (bounceIndex < bounceCount - 1)
			{
				cmd.Blit(m_irradiance, m_radiance, m_material, 2);
			}
		}

		private void GatherRadianceCascades(CommandBuffer cmd, PugCamera pugCamera, int bounceIndex, int bounceCount)
		{
			int num = (pugCamera.indirectLightRayCount = 4);
			cmd.SetKeyword(in s_disableOutput2Keyword, value: true);
			RenderTextureDescriptor descriptor = radiance.descriptor;
			int num2 = Mathf.Min(pugCamera.indirectLightSkipPasses, m_radianceCascadeCount - 1);
			Vector2Int threadGroupCount;
			for (int i = 0; i < num2; i++)
			{
				RenderTexture renderTexture = ((i == 0) ? m_radiance : m_inputPasses[i]);
				threadGroupCount = PugRPUtils.GetThreadGroupCount(8, descriptor.width / 2, descriptor.height / 2);
				cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.InputSize, new Vector2(renderTexture.width, renderTexture.height));
				cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.OutputSize, new Vector2(renderTexture.width, renderTexture.height) / 2f);
				cmd.SetComputeTextureParam(m_computeShader, 2, ShaderIDs.Input, renderTexture);
				cmd.SetComputeTextureParam(m_computeShader, 2, ShaderIDs.Output, m_inputPasses[i + 1]);
				cmd.DispatchCompute(m_computeShader, 2, threadGroupCount.x, threadGroupCount.y, 1);
				descriptor.width /= 2;
				descriptor.height /= 2;
			}
			RenderTexture renderTexture2 = ((num2 > 0) ? m_inputPasses[num2 - 1] : m_radiance);
			descriptor.dimension = TextureDimension.Tex3D;
			descriptor.volumeDepth = num;
			float num3 = 0f;
			int indirectLightSamplesPerPass = pugCamera.indirectLightSamplesPerPass;
			int num4 = 0;
			for (int j = 0; j < m_radianceCascadeCount; j++)
			{
				num4 += indirectLightSamplesPerPass * Mathf.RoundToInt(Mathf.Pow(2f, j));
			}
			cmd.SetGlobalFloat(ShaderIDs.IndirectLightDirectionality, pugCamera.indirectLightDirectionality);
			bool flag = bounceIndex == 0;
			cmd.BeginSample("Sample");
			for (int k = num2; k < m_radianceCascadeCount; k++)
			{
				bool flag2 = k == num2;
				if (flag2 && flag)
				{
					PugRPUtils.Setup(ref m_topRadianceCascade, "Radiance Cascade 0", descriptor);
				}
				else
				{
					s_radianceCascadeDescs[k] = descriptor;
					cmd.GetTemporaryRT(s_radianceCascades[k], descriptor, FilterMode.Bilinear);
				}
				RenderTexture renderTexture3 = ((k == 0) ? renderTexture2 : m_inputPasses[k]);
				if (k >= num2)
				{
					threadGroupCount = PugRPUtils.GetThreadGroupCount(8, descriptor.width, descriptor.height);
					cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.SampleCount, indirectLightSamplesPerPass);
					cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.RayCount, descriptor.volumeDepth);
					cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.Offset, num3);
					cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.BlockerWeight, Mathf.Pow(Mathf.Pow(2f, k), k));
					cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.InputSize, new Vector2(renderTexture3.width, renderTexture3.height));
					cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.OutputSize, new Vector2(descriptor.width, descriptor.height));
					cmd.SetComputeTextureParam(m_computeShader, 3, ShaderIDs.Input, renderTexture3);
					if (flag2 && flag)
					{
						cmd.SetComputeTextureParam(m_computeShader, 3, ShaderIDs.RadianceCascade, m_topRadianceCascade);
					}
					else
					{
						cmd.SetComputeTextureParam(m_computeShader, 3, ShaderIDs.RadianceCascade, s_radianceCascades[k]);
					}
					cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.RadianceCascadeIndex, k);
					cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.SampleWeight, Mathf.Pow(2f, k) / (float)num4);
					cmd.DispatchCompute(m_computeShader, 3, threadGroupCount.x, threadGroupCount.y, descriptor.volumeDepth);
					num3 = (num3 + (float)indirectLightSamplesPerPass) / 2f;
				}
				if (k < m_radianceCascadeCount - 1)
				{
					threadGroupCount = PugRPUtils.GetThreadGroupCount(8, descriptor.width / 2, descriptor.height / 2);
					cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.InputSize, new Vector2(renderTexture3.width, renderTexture3.height));
					cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.OutputSize, new Vector2(renderTexture3.width, renderTexture3.height) / 2f);
					cmd.SetComputeTextureParam(m_computeShader, 2, ShaderIDs.Input, renderTexture3);
					cmd.SetComputeTextureParam(m_computeShader, 2, ShaderIDs.Output, m_inputPasses[k + 1]);
					cmd.DispatchCompute(m_computeShader, 2, threadGroupCount.x, threadGroupCount.y, 1);
					if (pugCamera.indirectLightInputBlur > 0)
					{
						RenderTextureDescriptor desc = descriptor;
						desc.dimension = TextureDimension.Tex2D;
						desc.volumeDepth = 1;
						cmd.GetTemporaryRT(m_gatherTmp, desc);
						PugRPUtils.BlurTexture(cmd, m_inputPasses[k + 1], m_gatherTmp, m_radiance.width, m_radiance.height, useUnorm: false, pugCamera.indirectLightInputBlur, bilateralAlpha: true);
						cmd.ReleaseTemporaryRT(m_gatherTmp);
					}
					descriptor.width /= 2;
					descriptor.height /= 2;
					descriptor.volumeDepth *= 2;
				}
			}
			cmd.EndSample("Sample");
			cmd.BeginSample("Merge");
			for (int num5 = m_radianceCascadeCount - 2; num5 >= num2; num5--)
			{
				bool num6 = num5 == num2;
				descriptor.width *= 2;
				descriptor.height *= 2;
				descriptor.volumeDepth /= 2;
				threadGroupCount = PugRPUtils.GetThreadGroupCount(8, descriptor.width, descriptor.height);
				cmd.SetComputeTextureParam(m_computeShader, 4, ShaderIDs.RadianceCascadeIn, s_radianceCascades[num5 + 1]);
				RenderTargetIdentifier renderTargetIdentifier;
				RenderTextureDescriptor desc2;
				if (num6 && flag)
				{
					renderTargetIdentifier = m_topRadianceCascade;
					desc2 = m_topRadianceCascade.descriptor;
				}
				else
				{
					renderTargetIdentifier = s_radianceCascades[num5];
					desc2 = s_radianceCascadeDescs[num5];
				}
				cmd.SetComputeTextureParam(m_computeShader, 4, ShaderIDs.RadianceCascade, renderTargetIdentifier);
				cmd.GetTemporaryRT(m_radianceCascadeTmp, desc2);
				cmd.CopyTexture(renderTargetIdentifier, m_radianceCascadeTmp);
				cmd.SetComputeTextureParam(m_computeShader, 4, ShaderIDs.RadianceCascadeTmp, m_radianceCascadeTmp);
				cmd.SetComputeVectorParam(m_computeShader, ShaderIDs.OutputSize, new Vector2(descriptor.width, descriptor.height));
				cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.RayCount, descriptor.volumeDepth);
				cmd.DispatchCompute(m_computeShader, 4, threadGroupCount.x, threadGroupCount.y, descriptor.volumeDepth);
				cmd.ReleaseTemporaryRT(m_radianceCascadeTmp);
			}
			threadGroupCount = PugRPUtils.GetThreadGroupCount(8, descriptor.width, descriptor.height);
			cmd.SetComputeTextureParam(m_computeShader, 5, ShaderIDs.RadianceCascadeIn, flag ? ((RenderTargetIdentifier)m_topRadianceCascade) : ((RenderTargetIdentifier)s_radianceCascades[num2]));
			if (!flag)
			{
				cmd.SetComputeTextureParam(m_computeShader, 5, ShaderIDs.RadianceCascade, m_topRadianceCascade);
				cmd.SetKeyword(in s_disableOutput2Keyword, value: false);
			}
			else
			{
				cmd.SetKeyword(in s_disableOutput2Keyword, value: true);
			}
			cmd.SetComputeTextureParam(m_computeShader, 5, ShaderIDs.Output, m_inputPasses[num2]);
			cmd.SetComputeFloatParam(m_computeShader, ShaderIDs.RayCount, num);
			cmd.DispatchCompute(m_computeShader, 5, threadGroupCount.x, threadGroupCount.y, 1);
			cmd.SetKeyword(in s_disableOutput2Keyword, value: true);
			cmd.EndSample("Merge");
			cmd.BeginSample("Upsample");
			for (int num7 = num2; num7 > 0; num7--)
			{
				cmd.SetGlobalFloat(ShaderIDs.IndirectLeakPrevention, 0f);
				cmd.Blit(m_inputPasses[num7], m_inputPasses[num7 - 1], m_material, 0);
			}
			cmd.EndSample("Upsample");
			for (int l = num2; l < m_radianceCascadeCount; l++)
			{
				cmd.ReleaseTemporaryRT(s_radianceCascades[l]);
			}
			if (bounceIndex == 0)
			{
				cmd.CopyTexture(m_inputPasses[0], m_irradiance);
			}
			else
			{
				cmd.Blit(m_inputPasses[0], m_irradiance, m_material, 3);
			}
			if (bounceIndex < bounceCount - 1)
			{
				cmd.Blit(m_irradiance, m_radiance, m_material, 2);
			}
			cmd.SetGlobalTexture(ShaderIDs.TopRadianceCascade, m_topRadianceCascade);
		}

		private void SetCommon(PugRPContext context, CommandBuffer cmd)
		{
			cmd.SetGlobalFloat(ShaderIDs.IndirectLightDepth, context.pugCamera.indirectLightDepth);
			cmd.SetGlobalMatrix(ShaderIDs.WorldToIndirect, m_worldToIndirect);
			cmd.SetGlobalMatrix(ShaderIDs.IndirectToWorld, m_worldToIndirect.inverse);
			float num = context.pugCamera.indirectLightDepth / 2f - context.pugCamera.indirectLightThreshold;
			cmd.SetGlobalFloat(ShaderIDs.IndirectDepthThreshold, num);
			cmd.SetGlobalFloat(ShaderIDs.IndirectBlockerThreshold, Mathf.Min(context.pugCamera.indirectLightBlockerThreshold, 0.999f));
			float num2 = num / context.pugCamera.indirectLightDepth;
			cmd.SetGlobalFloat(ShaderIDs.IndirectBlockerMinZ, 1f - num2);
		}

		public override void ExecuteDisabled(PugRPContext context, CommandBuffer cmd)
		{
			cmd.SetGlobalTexture(ShaderIDs.IndirectIrradiance, Texture2D.blackTexture);
		}

		protected override void DisposeInternal()
		{
			m_gbuffer.Dispose();
			PugRPUtils.Release(ref m_separateBlockerDepth);
			PugRPUtils.Release(ref m_radiance);
			PugRPUtils.Release(ref m_irradiance);
			PugRPUtils.Release(m_gatherPasses);
			PugRPUtils.Release(m_inputPasses);
			PugRPUtils.Release(m_bentNormalPasses);
			PugRPUtils.Release(ref m_topRadianceCascade);
		}
	}
}
