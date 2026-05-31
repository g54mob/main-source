using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KuwaharaFilter
{
	[RequireComponent(typeof(Camera))]
	[ExecuteInEditMode]
	[ImageEffectAllowedInSceneView]
	public class AnisotropicKuwaharaEffect : MonoBehaviour
	{
		[Range(0f, 10f)]
		[Tooltip("Warning: A value has aт impact on performance")]
		public int GaussRadius = 5;

		[Range(0.1f, 10f)]
		public float GaussSigma = 8f;

		[Range(0f, 10f)]
		public float KuwaharaAlpha = 1f;

		[Range(0f, 5f)]
		[Tooltip("Warning: A value has aт impact on performance")]
		public int KuwaharaRadius = 2;

		[Range(1f, 20f)]
		public int KuwaharaQ = 8;

		[Range(0.1f, 1f)]
		[Tooltip("Warning: A value has aт impact on performance")]
		public float ResolutionScale = 1f;

		private ComputeShader m_GaussComputer;

		private ComputeShader m_SSTComputer;

		private ComputeShader m_TFMComputer;

		private ComputeShader m_LICComputer;

		private ComputeShader m_KuwaharaComputer;

		private RenderTexture m_TextureColor;

		private RenderTexture m_TextureSST;

		private RenderTexture m_TextureGaussHS;

		private RenderTexture m_TextureGaussVS;

		private RenderTexture m_TextureTFM;

		private RenderTexture m_TextureLIC;

		private RenderTexture m_TextureKuwahara;

		private Camera m_Camera;

		private ComputeBuffer m_KernelGaussFilter;

		private ConstantBufferVariable m_ConstantBuffer = new ConstantBufferVariable();

		private void Start()
		{
			m_Camera = GetComponent<Camera>();
			m_GaussComputer = Resources.Load<ComputeShader>("Shaders/ComputerGauss");
			m_SSTComputer = Resources.Load<ComputeShader>("Shaders/ComputerStructureTensor");
			m_TFMComputer = Resources.Load<ComputeShader>("Shaders/ComputerVectorField");
			m_LICComputer = Resources.Load<ComputeShader>("Shaders/ComputerLineIntegralConvolution");
			m_KuwaharaComputer = Resources.Load<ComputeShader>("Shaders/ComputerAnisotropicKuwahara");
		}

		private List<float> GenerateGaussKernel(int radius, float sigma)
		{
			List<float> source = (from x in Enumerable.Range(0, 2 * radius + 1)
				select Mathf.Exp((0f - Mathf.Pow(x - radius, 2f)) / (2f * sigma * sigma))).ToList();
			float sum = source.Sum();
			return source.Select((float x) => x / sum).ToList();
		}

		private void InitializeRenderTexture(int width, int height)
		{
			if (m_TextureColor == null || m_TextureColor.width != width || m_TextureColor.height != height)
			{
				m_TextureColor?.Release();
				m_TextureSST?.Release();
				m_TextureGaussHS?.Release();
				m_TextureGaussVS?.Release();
				m_TextureTFM?.Release();
				m_TextureLIC?.Release();
				m_TextureKuwahara?.Release();
				m_TextureColor = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				m_TextureColor.Create();
				m_TextureSST = new RenderTexture(width, height, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
				m_TextureSST.enableRandomWrite = true;
				m_TextureSST.Create();
				m_TextureGaussHS = new RenderTexture(width, height, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
				m_TextureGaussHS.enableRandomWrite = true;
				m_TextureGaussHS.Create();
				m_TextureGaussVS = new RenderTexture(width, height, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
				m_TextureGaussVS.enableRandomWrite = true;
				m_TextureGaussVS.Create();
				m_TextureTFM = new RenderTexture(width, height, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
				m_TextureTFM.enableRandomWrite = true;
				m_TextureTFM.Create();
				m_TextureLIC = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				m_TextureLIC.enableRandomWrite = true;
				m_TextureLIC.Create();
				m_TextureKuwahara = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				m_TextureKuwahara.enableRandomWrite = true;
				m_TextureKuwahara.Create();
			}
		}

		private void InitializeComputeBuffer()
		{
			List<float> data = GenerateGaussKernel(GaussRadius, GaussSigma);
			m_KernelGaussFilter.SetData(data);
		}

		private void Update()
		{
			m_ConstantBuffer.GaussRadius = GaussRadius;
			m_ConstantBuffer.KuwaharaRadius = KuwaharaRadius;
			m_ConstantBuffer.KuwaharaAlpha = KuwaharaAlpha;
			m_ConstantBuffer.KuwaharaQ = KuwaharaQ;
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dst)
		{
			int num = Mathf.CeilToInt(ResolutionScale * (float)m_Camera.pixelWidth);
			int num2 = Mathf.CeilToInt(ResolutionScale * (float)m_Camera.pixelHeight);
			InitializeRenderTexture(num, num2);
			InitializeComputeBuffer();
			Graphics.Blit(src, m_TextureColor);
			ConstantBufferVariable.Apply(m_SSTComputer, m_ConstantBuffer);
			ConstantBufferVariable.Apply(m_GaussComputer, m_ConstantBuffer);
			ConstantBufferVariable.Apply(m_TFMComputer, m_ConstantBuffer);
			ConstantBufferVariable.Apply(m_LICComputer, m_ConstantBuffer);
			ConstantBufferVariable.Apply(m_KuwaharaComputer, m_ConstantBuffer);
			int kernelIndex = m_SSTComputer.FindKernel("StructureTensor");
			m_SSTComputer.SetTexture(kernelIndex, "TextureColorSRV", m_TextureColor);
			m_SSTComputer.SetTexture(kernelIndex, "TextureColorUAV", m_TextureSST);
			m_SSTComputer.Dispatch(kernelIndex, Mathf.CeilToInt((float)num / 8f), Mathf.CeilToInt((float)num2 / 8f), 1);
			int kernelIndex2 = m_GaussComputer.FindKernel("GaussHS");
			m_GaussComputer.SetTexture(kernelIndex2, "TextureColorSRV", m_TextureSST);
			m_GaussComputer.SetTexture(kernelIndex2, "TextureColorUAV", m_TextureGaussHS);
			m_GaussComputer.SetBuffer(kernelIndex2, "BufferGaussKernel", m_KernelGaussFilter);
			m_GaussComputer.Dispatch(kernelIndex2, Mathf.CeilToInt((float)num / 8f), Mathf.CeilToInt((float)num2 / 8f), 1);
			int kernelIndex3 = m_GaussComputer.FindKernel("GaussVS");
			m_GaussComputer.SetTexture(kernelIndex3, "TextureColorSRV", m_TextureGaussHS);
			m_GaussComputer.SetTexture(kernelIndex3, "TextureColorUAV", m_TextureGaussVS);
			m_GaussComputer.SetBuffer(kernelIndex3, "BufferGaussKernel", m_KernelGaussFilter);
			m_GaussComputer.Dispatch(kernelIndex3, Mathf.CeilToInt((float)num / 8f), Mathf.CeilToInt((float)num2 / 8f), 1);
			int kernelIndex4 = m_TFMComputer.FindKernel("VectorField");
			m_TFMComputer.SetTexture(kernelIndex4, "TextureColorSRV", m_TextureGaussVS);
			m_TFMComputer.SetTexture(kernelIndex4, "TextureColorUAV", m_TextureTFM);
			m_TFMComputer.Dispatch(kernelIndex4, Mathf.CeilToInt((float)num / 8f), Mathf.CeilToInt((float)num2 / 8f), 1);
			int kernelIndex5 = m_LICComputer.FindKernel("LineIntegralConvolution");
			m_LICComputer.SetTexture(kernelIndex5, "TextureTFMSRV", m_TextureTFM);
			m_LICComputer.SetTexture(kernelIndex5, "TextureColorSRV", src);
			m_LICComputer.SetTexture(kernelIndex5, "TextureColorUAV", m_TextureLIC);
			m_LICComputer.SetBuffer(kernelIndex5, "BufferGaussKernel", m_KernelGaussFilter);
			m_LICComputer.Dispatch(kernelIndex5, Mathf.CeilToInt((float)num / 8f), Mathf.CeilToInt((float)num2 / 8f), 1);
			int kernelIndex6 = m_KuwaharaComputer.FindKernel("AnisotropicKuwahara");
			m_KuwaharaComputer.SetTexture(kernelIndex6, "TextureTFMSRV", m_TextureTFM);
			m_KuwaharaComputer.SetTexture(kernelIndex6, "TextureColorSRV", m_TextureLIC);
			m_KuwaharaComputer.SetTexture(kernelIndex6, "TextureColorUAV", m_TextureKuwahara);
			m_KuwaharaComputer.Dispatch(kernelIndex6, Mathf.CeilToInt((float)num / 8f), Mathf.CeilToInt((float)num2 / 8f), 1);
			Graphics.Blit(m_TextureKuwahara, dst);
		}

		public void OnEnable()
		{
			m_KernelGaussFilter = new ComputeBuffer(64, 4, ComputeBufferType.Default);
		}

		public void OnDisable()
		{
			if (m_KernelGaussFilter != null)
			{
				m_KernelGaussFilter.Dispose();
				m_KernelGaussFilter = null;
			}
		}
	}
}
