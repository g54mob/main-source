using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public class ScreenSpaceAmbientOcclusionRenderFeature : RenderFeature
	{
		private const int CS_KERNEL_DEINTERLEAVE = 0;

		private const int CS_KERNEL_MAIN = 1;

		private const int CS_KERNEL_INTERLEAVE = 2;

		private const int CS_KERNEL_FILTER = 3;

		private const int CS_KERNEL_TEMPORAL_FILTER = 4;

		private SSAOSettings m_settings;

		private ComputeShader m_compute;

		private LocalKeyword m_deinterleavedKwd;

		private LocalKeyword m_enableDirectionalityKwd;

		private RenderTexture m_target;

		private int m_tmp = Shader.PropertyToID("_SSAOTextureTmp");

		private int m_history = Shader.PropertyToID("_SSAOTextureHistory");

		private Vector4[] m_bases;

		private Vector4[] m_kernel;

		private int m_initializedDistributions = -1;

		private float m_initializedBias = -1f;

		private RenderTextureDescriptor m_desc;

		private RenderTextureDescriptor m_intermediateDesc;

		private bool m_hasHistory;

		private int m_intermediate = Shader.PropertyToID("_SSAOIntermediate");

		private int m_depth = Shader.PropertyToID("_SSAODepth");

		private static int[] s_bayer = new int[16]
		{
			0, 8, 2, 10, 12, 4, 14, 6, 3, 11,
			1, 9, 15, 7, 13, 5
		};

		public override bool usesCulling => false;

		public override string sampleName => "SSAO";

		public override RenderPipelineStage executionStage => RenderPipelineStage.AfterGBuffer;

		public override void ValidateFrame(PugRPContext context)
		{
			base.isValid = (bool)context.camera && (bool)context.pugCamera && context.pugCamera.enableSSAO;
		}

		public override void OnBeginValidFrame(PugRPContext context)
		{
			m_settings = context.pugCamera.ssaoSettings;
			if (PugRPUtils.EnsureLoadedResource(ref m_compute, "Shaders/SSAO"))
			{
				m_deinterleavedKwd = new LocalKeyword(m_compute, "DEINTERLEAVED_OUTPUT");
				m_enableDirectionalityKwd = new LocalKeyword(m_compute, "ENABLE_DIRECTIONALITY");
			}
			if (m_initializedDistributions != m_settings.sampleCount || m_initializedBias != m_settings.bias)
			{
				InitializeDistributions(m_settings.sampleCount);
			}
			RenderTextureFormat renderTextureFormat = (context.pugCamera.ssaoSettings.temporalFilter ? RenderTextureFormat.RHalf : RenderTextureFormat.R8);
			if (!PugRPUtils.CheckRenderTextureSupport(renderTextureFormat, checkLinearSampling: true, checkRandomWrite: true))
			{
				renderTextureFormat = (PugRPUtils.CheckRenderTextureSupport(RenderTextureFormat.RHalf, checkLinearSampling: true, checkRandomWrite: true) ? RenderTextureFormat.RHalf : RenderTextureFormat.RFloat);
			}
			m_desc = new RenderTextureDescriptor(context.pixelWidth, context.pixelHeight, renderTextureFormat)
			{
				enableRandomWrite = true
			};
			PugRPUtils.Setup(ref m_target, "SSAOTexture", m_desc);
			if (m_settings.cacheOptimized)
			{
				m_intermediateDesc = m_desc;
				m_intermediateDesc.width = Mathf.CeilToInt((float)m_desc.width / 4f);
				m_intermediateDesc.height = Mathf.CeilToInt((float)m_desc.height / 4f);
				m_intermediateDesc.dimension = TextureDimension.Tex2DArray;
				m_intermediateDesc.volumeDepth = 16;
				m_intermediateDesc.colorFormat = RenderTextureFormat.RHalf;
			}
		}

		public override void Execute(PugRPContext context, CommandBuffer cmd)
		{
			if (!base.isValid)
			{
				return;
			}
			float num = m_settings.radius;
			if (m_settings.screenSpaceRadius)
			{
				num /= 4f;
			}
			if (m_settings.blurFilter || m_settings.temporalFilter)
			{
				cmd.GetTemporaryRT(m_tmp, m_desc);
			}
			if (m_settings.cacheOptimized)
			{
				cmd.GetTemporaryRT(m_intermediate, m_intermediateDesc);
				m_intermediateDesc.colorFormat = RenderTextureFormat.RHalf;
				cmd.GetTemporaryRT(m_depth, m_intermediateDesc, FilterMode.Point);
			}
			if (m_settings.temporalFilter)
			{
				cmd.GetTemporaryRT(m_history, m_desc);
				cmd.CopyTexture(m_target, m_history);
			}
			cmd.SetComputeFloatParam(m_compute, ShaderIDs.Radius, num);
			cmd.SetComputeFloatParam(m_compute, ShaderIDs.ScreenSpaceRadius, m_settings.screenSpaceRadius ? 1f : 0f);
			cmd.SetComputeFloatParam(m_compute, ShaderIDs.Bias, m_settings.bias);
			cmd.SetComputeFloatParam(m_compute, ShaderIDs.ScreenBias, m_settings.screenBias);
			cmd.SetComputeFloatParam(m_compute, ShaderIDs.Exponent, m_settings.strength);
			cmd.SetComputeFloatParam(m_compute, ShaderIDs.NormalizedEdges, m_settings.normalizeEdges ? 1 : 0);
			cmd.SetComputeFloatParam(m_compute, ShaderIDs.Animated, m_settings.temporalFilter ? 1 : 0);
			cmd.SetComputeFloatParam(m_compute, ShaderIDs.Directionality, m_settings.directionality);
			cmd.SetComputeFloatParam(m_compute, ShaderIDs.Noise, m_settings.noise ? 1 : 0);
			cmd.SetComputeIntParam(m_compute, ShaderIDs.SampleCount, m_settings.sampleCount);
			cmd.SetComputeVectorParam(m_compute, ShaderIDs.Size, new Vector2(m_desc.width, m_desc.height));
			cmd.SetComputeVectorArrayParam(m_compute, ShaderIDs.Kernel, m_kernel);
			cmd.SetKeyword(m_compute, in m_enableDirectionalityKwd, m_settings.directionality > Mathf.Epsilon);
			int threadGroupCount = PugRPUtils.GetThreadGroupCount(8, m_intermediateDesc.width);
			int threadGroupCount2 = PugRPUtils.GetThreadGroupCount(8, m_intermediateDesc.height);
			if (m_settings.cacheOptimized)
			{
				cmd.EnableKeyword(m_compute, in m_deinterleavedKwd);
				cmd.SetComputeFloatParam(m_compute, ShaderIDs.Spacing, 4f);
				cmd.SetComputeTextureParam(m_compute, 0, ShaderIDs.Output2, m_depth);
				cmd.DispatchCompute(m_compute, 0, threadGroupCount, threadGroupCount2, 1);
				cmd.SetComputeTextureParam(m_compute, 1, ShaderIDs.Depth, m_depth);
				for (int i = 0; i < 16; i++)
				{
					int num2 = (m_settings.temporalFilter ? s_bayer[(i + PugRP.frameIndex) % 16] : i);
					cmd.SetComputeVectorParam(m_compute, ShaderIDs.Basis, m_bases[num2]);
					cmd.SetComputeVectorParam(m_compute, ShaderIDs.Offset, new Vector2(i % 4, i / 4));
					cmd.SetComputeIntParam(m_compute, ShaderIDs.Slice, i);
					cmd.SetComputeTextureParam(m_compute, 1, ShaderIDs.Output2, m_intermediate);
					cmd.DispatchCompute(m_compute, 1, threadGroupCount, threadGroupCount2, 1);
				}
				cmd.SetComputeTextureParam(m_compute, 2, ShaderIDs.Output, m_target);
				cmd.SetComputeTextureParam(m_compute, 2, ShaderIDs.Output2, m_intermediate);
				threadGroupCount = PugRPUtils.GetThreadGroupCount(8, m_desc.width);
				threadGroupCount2 = PugRPUtils.GetThreadGroupCount(8, m_desc.height);
				cmd.DispatchCompute(m_compute, 2, threadGroupCount, threadGroupCount2, 1);
			}
			else
			{
				cmd.DisableKeyword(m_compute, in m_deinterleavedKwd);
				cmd.SetComputeFloatParam(m_compute, ShaderIDs.Spacing, 1f);
				cmd.SetComputeVectorParam(m_compute, ShaderIDs.Offset, new Vector2(0f, 0f));
				cmd.SetComputeTextureParam(m_compute, 1, ShaderIDs.Output, m_target);
				threadGroupCount = PugRPUtils.GetThreadGroupCount(8, m_desc.width);
				threadGroupCount2 = PugRPUtils.GetThreadGroupCount(8, m_desc.height);
				cmd.DispatchCompute(m_compute, 1, threadGroupCount, threadGroupCount2, 1);
			}
			if (m_settings.blurFilter)
			{
				float num3 = Mathf.Pow(m_settings.blurSharpness, 0.1f);
				cmd.SetComputeIntParam(m_compute, ShaderIDs.BlurWidth, m_settings.blurWidth);
				cmd.SetComputeFloatParam(m_compute, ShaderIDs.BlurDepthWeight, 1f / (1f - num3));
				cmd.SetComputeFloatParam(m_compute, ShaderIDs.BlurNormalWeight, num3);
				threadGroupCount = PugRPUtils.GetThreadGroupCount(8, m_desc.width);
				threadGroupCount2 = PugRPUtils.GetThreadGroupCount(8, m_desc.height);
				for (int j = 0; j < m_settings.blurPasses; j++)
				{
					cmd.SetComputeVectorParam(m_compute, ShaderIDs.Axis, new Vector2(1f, 0f));
					cmd.SetComputeTextureParam(m_compute, 3, ShaderIDs.Input, m_target);
					cmd.SetComputeTextureParam(m_compute, 3, ShaderIDs.Output, m_tmp);
					cmd.DispatchCompute(m_compute, 3, threadGroupCount, threadGroupCount2, 1);
					cmd.SetComputeVectorParam(m_compute, ShaderIDs.Axis, new Vector2(0f, 1f));
					cmd.SetComputeTextureParam(m_compute, 3, ShaderIDs.Input, m_tmp);
					cmd.SetComputeTextureParam(m_compute, 3, ShaderIDs.Output, m_target);
					cmd.DispatchCompute(m_compute, 3, threadGroupCount, threadGroupCount2, 1);
				}
			}
			if (m_settings.temporalFilter)
			{
				cmd.CopyTexture(m_target, m_tmp);
				cmd.SetComputeFloatParam(m_compute, ShaderIDs.TemporalWeight, m_settings.temporalWeight);
				cmd.SetComputeVectorParam(m_compute, ShaderIDs.Axis, new Vector2(0f, 1f));
				cmd.SetComputeTextureParam(m_compute, 4, ShaderIDs.Input, m_tmp);
				cmd.SetComputeTextureParam(m_compute, 4, ShaderIDs.Input2, m_history);
				cmd.SetComputeTextureParam(m_compute, 4, ShaderIDs.Output, m_target);
				cmd.DispatchCompute(m_compute, 4, threadGroupCount, threadGroupCount2, 1);
			}
			if (m_settings.blurFilter || m_settings.temporalFilter)
			{
				cmd.ReleaseTemporaryRT(m_tmp);
			}
			if (m_settings.cacheOptimized)
			{
				cmd.ReleaseTemporaryRT(m_intermediate);
				cmd.ReleaseTemporaryRT(m_depth);
			}
			if (m_settings.temporalFilter)
			{
				cmd.ReleaseTemporaryRT(m_history);
			}
			cmd.SetGlobalTexture(ShaderIDs.SSAOTexture, m_target);
			cmd.SetGlobalFloat(ShaderIDs.SSAOColorize, m_settings.colorize);
			m_hasHistory = m_settings.temporalFilter;
		}

		public override void ExecuteDisabled(PugRPContext context, CommandBuffer cmd)
		{
			cmd.SetGlobalTexture(ShaderIDs.SSAOTexture, Texture2D.whiteTexture);
			m_hasHistory = false;
		}

		protected override void DisposeInternal()
		{
			PugRPUtils.Release(ref m_target);
		}

		private void InitializeDistributions(int n)
		{
			Random.State state = Random.state;
			Random.InitState(0);
			m_bases = PugRPUtils.SunflowerKernel(16, hemisphere: false);
			m_kernel = new Vector4[64];
			for (int i = 0; i < n; i++)
			{
				m_kernel[i] = new Vector3(Random.value * 2f - 1f, Random.value * 2f - 1f, Random.value).normalized;
				m_kernel[i] = Vector3.Slerp(m_kernel[i], Vector3.forward, m_settings.bias);
				float num = ((float)i + 0.5f) / (float)n;
				m_kernel[i] *= Mathf.Lerp(0.1f, 1f, num * num);
			}
			Random.state = state;
			m_initializedDistributions = n;
			m_initializedBias = m_settings.bias;
		}
	}
}
