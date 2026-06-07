using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CRTFilter
{
	public class ChangeColorFeature : ScriptableRendererFeature
	{
		private class CRTRenderPass : ScriptableRenderPass
		{
			private const string PROFTAG = "ChangeColor";

			private Material shaderMaterial;

			private RTHandle crtTexture;

			public CRTRenderPass(Material material)
			{
				shaderMaterial = material;
			}

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
				RenderTextureDescriptor descriptor = cameraTextureDescriptor;
				descriptor.depthBufferBits = 0;
				RenderingUtils.ReAllocateIfNeeded(ref crtTexture, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, "_ChangeColorTexture");
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				if (!(shaderMaterial == null) && crtTexture != null)
				{
					CommandBuffer commandBuffer = CommandBufferPool.Get("ChangeColor");
					commandBuffer.Blit(renderingData.cameraData.renderer.cameraColorTargetHandle, crtTexture, shaderMaterial, 0);
					commandBuffer.Blit(crtTexture, renderingData.cameraData.renderer.cameraColorTargetHandle);
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					CommandBufferPool.Release(commandBuffer);
				}
			}

			public void Dispose()
			{
				RTHandles.Release(crtTexture);
				crtTexture = null;
			}
		}

		public Shader shader;

		public RenderPassEvent injectionPoint = RenderPassEvent.BeforeRenderingPostProcessing;

		private CRTRenderPass crtRenderPass;

		private Material shaderMaterial;

		public Vector4 newBlack = new Vector4(0f, 0f, 0f, 1f);

		public Vector4 newWhite = new Vector4(1f, 1f, 1f, 1f);

		public void OnValidate()
		{
		}

		public override void Create()
		{
			if (shaderMaterial == null)
			{
				shaderMaterial = CoreUtils.CreateEngineMaterial(shader);
			}
			if (crtRenderPass == null)
			{
				crtRenderPass = new CRTRenderPass(shaderMaterial);
				crtRenderPass.renderPassEvent = injectionPoint;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (shaderMaterial != null)
			{
				CoreUtils.Destroy(shaderMaterial);
				shaderMaterial = null;
			}
			if (crtRenderPass != null)
			{
				crtRenderPass.Dispose();
				crtRenderPass = null;
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (!(shaderMaterial == null) && crtRenderPass != null)
			{
				shaderMaterial.SetVector("m_newBlack", newBlack);
				shaderMaterial.SetVector("m_newWhite", newWhite);
				crtRenderPass.ConfigureInput(ScriptableRenderPassInput.Color);
				renderer.EnqueuePass(crtRenderPass);
			}
		}
	}
}
