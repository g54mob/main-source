using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace KuwaharaFilterURP
{
	public class KuwaharaFilterRenderPass : ScriptableRenderPass
	{
		private ComputeShader m_GaussComputer;

		private ComputeShader m_SSTComputer;

		private ComputeShader m_TFMComputer;

		private ComputeShader m_LICComputer;

		private ComputeShader m_KuwaharaComputer;

		private ComputeBuffer m_KernelGaussFilter;

		private KuwaharaFilterSettings m_Settings;

		private RenderTargetHandle m_TextureColor;

		private RenderTargetHandle m_TextureSST;

		private RenderTargetHandle m_TextureGaussVS;

		private RenderTargetHandle m_TextureGaussHS;

		private RenderTargetHandle m_TextureTFM;

		private RenderTargetHandle m_TextureLIC;

		private RenderTargetHandle m_TextureKuwahara;

		private RenderTargetIdentifier m_TextureSrc;

		private RenderTargetIdentifier m_TextureDst;

		public KuwaharaFilterRenderPass(KuwaharaFilterSettings variables, ComputeBuffer computeBuffer)
		{
			m_SSTComputer = Resources.Load<ComputeShader>("Shaders/ComputerStructureTensor");
			m_GaussComputer = Resources.Load<ComputeShader>("Shaders/ComputerGauss");
			m_TFMComputer = Resources.Load<ComputeShader>("Shaders/ComputerVectorField");
			m_LICComputer = Resources.Load<ComputeShader>("Shaders/ComputerLineIntegralConvolution");
			m_KuwaharaComputer = Resources.Load<ComputeShader>("Shaders/ComputerAnisotropicKuwahara");
			m_TextureColor.Init("CLR");
			m_TextureSST.Init("SST");
			m_TextureGaussVS.Init("GVS");
			m_TextureGaussHS.Init("GHS");
			m_TextureTFM.Init("TFM");
			m_TextureLIC.Init("LIC");
			m_TextureKuwahara.Init("KWH");
			m_Settings = variables;
			base.renderPassEvent = m_Settings.RenderPassEvent;
			m_KernelGaussFilter = computeBuffer;
		}

		private List<float> GenerateGaussKernel(int radius, float sigma)
		{
			List<float> source = (from x in Enumerable.Range(0, 2 * radius + 1)
				select Mathf.Exp((0f - Mathf.Pow(x - radius, 2f)) / (2f * sigma * sigma))).ToList();
			float sum = source.Sum();
			return source.Select((float x) => x / sum).ToList();
		}

		private void InitializeComputeBuffer(int radius, float sigma)
		{
			List<float> data = GenerateGaussKernel(radius, sigma);
			m_KernelGaussFilter.SetData(data);
		}

		public void Setup(RenderTargetIdentifier textureSrc, RenderTargetIdentifier textureDst)
		{
			m_TextureSrc = textureSrc;
			m_TextureDst = textureDst;
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor desc)
		{
			InitializeComputeBuffer(m_Settings.GaussRadius, m_Settings.GaussSigma);
			int width = Mathf.CeilToInt(m_Settings.ResolutionScale * (float)desc.width);
			int height = Mathf.CeilToInt(m_Settings.ResolutionScale * (float)desc.height);
			cmd.GetTemporaryRT(m_TextureColor.id, width, height, 0, FilterMode.Point, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear, 1, enableRandomWrite: true);
			cmd.GetTemporaryRT(m_TextureSST.id, width, height, 0, FilterMode.Point, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear, 1, enableRandomWrite: true);
			cmd.GetTemporaryRT(m_TextureGaussHS.id, width, height, 0, FilterMode.Point, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear, 1, enableRandomWrite: true);
			cmd.GetTemporaryRT(m_TextureGaussVS.id, width, height, 0, FilterMode.Point, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear, 1, enableRandomWrite: true);
			cmd.GetTemporaryRT(m_TextureTFM.id, width, height, 0, FilterMode.Point, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear, 1, enableRandomWrite: true);
			cmd.GetTemporaryRT(m_TextureLIC.id, width, height, 0, FilterMode.Point, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear, 1, enableRandomWrite: true);
			cmd.GetTemporaryRT(m_TextureKuwahara.id, width, height, 0, FilterMode.Point, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear, 1, enableRandomWrite: true);
			ConfigureTarget(m_TextureColor.id);
			ConfigureTarget(m_TextureSST.id);
			ConfigureTarget(m_TextureGaussHS.id);
			ConfigureTarget(m_TextureGaussVS.id);
			ConfigureTarget(m_TextureTFM.id);
			ConfigureTarget(m_TextureLIC.id);
			ConfigureTarget(m_TextureKuwahara.id);
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			cmd.ReleaseTemporaryRT(m_TextureColor.id);
			cmd.ReleaseTemporaryRT(m_TextureSST.id);
			cmd.ReleaseTemporaryRT(m_TextureGaussHS.id);
			cmd.ReleaseTemporaryRT(m_TextureGaussVS.id);
			cmd.ReleaseTemporaryRT(m_TextureTFM.id);
			cmd.ReleaseTemporaryRT(m_TextureLIC.id);
			cmd.ReleaseTemporaryRT(m_TextureKuwahara.id);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			int num = Mathf.CeilToInt(m_Settings.ResolutionScale * (float)renderingData.cameraData.cameraTargetDescriptor.width);
			int num2 = Mathf.CeilToInt(m_Settings.ResolutionScale * (float)renderingData.cameraData.cameraTargetDescriptor.height);
			InitializeComputeBuffer(m_Settings.GaussRadius, m_Settings.GaussSigma);
			CommandBuffer commandBuffer = CommandBufferPool.Get("Kuwahara Filter");
			Blit(commandBuffer, m_TextureSrc, m_TextureColor.id);
			int kernelIndex = m_SSTComputer.FindKernel("StructureTensor");
			m_SSTComputer.GetKernelThreadGroupSizes(kernelIndex, out var x, out var y, out var _);
			commandBuffer.SetComputeTextureParam(m_SSTComputer, kernelIndex, "TextureColorSRV", m_TextureColor.id);
			commandBuffer.SetComputeTextureParam(m_SSTComputer, kernelIndex, "TextureColorUAV", m_TextureSST.id);
			commandBuffer.DispatchCompute(m_SSTComputer, kernelIndex, Mathf.CeilToInt((float)num / (float)x), Mathf.CeilToInt((float)num2 / (float)y), 1);
			int kernelIndex2 = m_GaussComputer.FindKernel("GaussHS");
			m_GaussComputer.GetKernelThreadGroupSizes(kernelIndex2, out var x2, out var y2, out var _);
			commandBuffer.SetComputeIntParam(m_GaussComputer, "GaussRadius", m_Settings.GaussRadius);
			commandBuffer.SetComputeTextureParam(m_GaussComputer, kernelIndex2, "TextureColorSRV", m_TextureSST.id);
			commandBuffer.SetComputeTextureParam(m_GaussComputer, kernelIndex2, "TextureColorUAV", m_TextureGaussHS.id);
			commandBuffer.SetComputeBufferParam(m_GaussComputer, kernelIndex2, "BufferGaussKernel", m_KernelGaussFilter);
			commandBuffer.DispatchCompute(m_GaussComputer, kernelIndex2, Mathf.CeilToInt((float)num / (float)x2), Mathf.CeilToInt((float)num2 / (float)y2), 1);
			int kernelIndex3 = m_GaussComputer.FindKernel("GaussVS");
			m_GaussComputer.GetKernelThreadGroupSizes(kernelIndex3, out var x3, out var y3, out var _);
			commandBuffer.SetComputeIntParam(m_GaussComputer, "GaussRadius", m_Settings.GaussRadius);
			commandBuffer.SetComputeTextureParam(m_GaussComputer, kernelIndex3, "TextureColorSRV", m_TextureGaussHS.id);
			commandBuffer.SetComputeTextureParam(m_GaussComputer, kernelIndex3, "TextureColorUAV", m_TextureGaussVS.id);
			commandBuffer.SetComputeBufferParam(m_GaussComputer, kernelIndex3, "BufferGaussKernel", m_KernelGaussFilter);
			commandBuffer.DispatchCompute(m_GaussComputer, kernelIndex3, Mathf.CeilToInt((float)num / (float)x3), Mathf.CeilToInt((float)num2 / (float)y3), 1);
			int kernelIndex4 = m_TFMComputer.FindKernel("VectorField");
			m_TFMComputer.GetKernelThreadGroupSizes(kernelIndex4, out var x4, out var y4, out var _);
			commandBuffer.SetComputeTextureParam(m_TFMComputer, kernelIndex4, "TextureColorSRV", m_TextureGaussVS.id);
			commandBuffer.SetComputeTextureParam(m_TFMComputer, kernelIndex4, "TextureColorUAV", m_TextureTFM.id);
			commandBuffer.DispatchCompute(m_TFMComputer, kernelIndex4, Mathf.CeilToInt((float)num / (float)x4), Mathf.CeilToInt((float)num2 / (float)y4), 1);
			int kernelIndex5 = m_LICComputer.FindKernel("LineIntegralConvolution");
			m_LICComputer.GetKernelThreadGroupSizes(kernelIndex5, out var x5, out var y5, out var _);
			commandBuffer.SetComputeIntParam(m_LICComputer, "GaussRadius", m_Settings.GaussRadius);
			commandBuffer.SetComputeTextureParam(m_LICComputer, kernelIndex5, "TextureTFMSRV", m_TextureTFM.id);
			commandBuffer.SetComputeTextureParam(m_LICComputer, kernelIndex5, "TextureColorSRV", m_TextureSrc);
			commandBuffer.SetComputeTextureParam(m_LICComputer, kernelIndex5, "TextureColorUAV", m_TextureLIC.id);
			commandBuffer.SetComputeBufferParam(m_LICComputer, kernelIndex5, "BufferGaussKernel", m_KernelGaussFilter);
			commandBuffer.DispatchCompute(m_LICComputer, kernelIndex5, Mathf.CeilToInt((float)num / (float)x5), Mathf.CeilToInt((float)num2 / (float)y5), 1);
			int kernelIndex6 = m_KuwaharaComputer.FindKernel("AnisotropicKuwahara");
			m_KuwaharaComputer.GetKernelThreadGroupSizes(kernelIndex6, out var x6, out var y6, out var _);
			commandBuffer.SetComputeIntParam(m_KuwaharaComputer, "KuwaharaRadius", m_Settings.KuwaharaRadius);
			commandBuffer.SetComputeIntParam(m_KuwaharaComputer, "KuwaharaQ", m_Settings.KuwaharaQ);
			commandBuffer.SetComputeFloatParam(m_KuwaharaComputer, "KuwaharaAlpha", m_Settings.KuwaharaAlpha);
			commandBuffer.SetComputeTextureParam(m_KuwaharaComputer, kernelIndex6, "TextureTFMSRV", m_TextureTFM.id);
			commandBuffer.SetComputeTextureParam(m_KuwaharaComputer, kernelIndex6, "TextureColorSRV", m_TextureLIC.id);
			commandBuffer.SetComputeTextureParam(m_KuwaharaComputer, kernelIndex6, "TextureColorUAV", m_TextureKuwahara.id);
			commandBuffer.DispatchCompute(m_KuwaharaComputer, kernelIndex6, Mathf.CeilToInt((float)num / (float)x6), Mathf.CeilToInt((float)num2 / (float)y6), 1);
			Blit(commandBuffer, m_TextureKuwahara.id, m_TextureDst);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}
	}
}
