using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace KuwaharaFilterURP
{
	public class AnisotropicKuwaharaEffectURP : ScriptableRendererFeature
	{
		private KuwaharaFilterRenderPass m_KuwaharaFilterRenderPass;

		public KuwaharaFilterSettings Settings = new KuwaharaFilterSettings();

		private ComputeBuffer m_KernelGaussFilter;

		public override void Create()
		{
			m_KuwaharaFilterRenderPass = new KuwaharaFilterRenderPass(Settings, m_KernelGaussFilter);
			base.name = "AnisotropicKuwaharaFilter";
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			m_KuwaharaFilterRenderPass.Setup(renderer.cameraColorTarget, renderer.cameraColorTarget);
			renderer.EnqueuePass(m_KuwaharaFilterRenderPass);
		}

		public void OnEnable()
		{
			m_KernelGaussFilter = new ComputeBuffer(64, 4, ComputeBufferType.Default);
		}

		public void OnDisable()
		{
			m_KernelGaussFilter.Release();
		}
	}
}
