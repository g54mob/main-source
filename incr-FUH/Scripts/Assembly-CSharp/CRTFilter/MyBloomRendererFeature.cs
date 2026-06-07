using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CRTFilter
{
	public class MyBloomRendererFeature : ScriptableRendererFeature
	{
		[Serializable]
		public class BloomSettings
		{
			public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;

			public Material bloomMaterial;

			public int blurPasses = 2;
		}

		private class BloomRenderPass : ScriptableRenderPass
		{
			private BloomSettings settings;

			private RTHandle cameraColorTarget;

			private RTHandle tempRT1;

			private RTHandle tempRT2;

			public BloomRenderPass(BloomSettings settings)
			{
				this.settings = settings;
				tempRT1 = RTHandles.Alloc(Vector2.one, TextureXR.slices, DepthBits.None, GraphicsFormat.R8G8B8A8_UNorm, FilterMode.Point, TextureWrapMode.Repeat, TextureXR.dimension, enableRandomWrite: false, useMipMap: false, autoGenerateMips: true, isShadowMap: false, 1, 0f, MSAASamples.None, bindTextureMS: false, useDynamicScale: true, useDynamicScaleExplicit: false, RenderTextureMemoryless.None, VRTextureUsage.None, "_TempRT1");
				tempRT2 = RTHandles.Alloc(Vector2.one, TextureXR.slices, DepthBits.None, GraphicsFormat.R8G8B8A8_UNorm, FilterMode.Point, TextureWrapMode.Repeat, TextureXR.dimension, enableRandomWrite: false, useMipMap: false, autoGenerateMips: true, isShadowMap: false, 1, 0f, MSAASamples.None, bindTextureMS: false, useDynamicScale: true, useDynamicScaleExplicit: false, RenderTextureMemoryless.None, VRTextureUsage.None, "_TempRT2");
				base.renderPassEvent = settings.renderPassEvent;
			}

			public void Setup(RTHandle cameraColorTarget)
			{
				this.cameraColorTarget = cameraColorTarget;
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
				if (!(settings.bloomMaterial == null))
				{
					CommandBuffer commandBuffer = CommandBufferPool.Get("Bloom Effect");
					Blit(commandBuffer, cameraColorTarget, tempRT1, settings.bloomMaterial);
					for (int i = 0; i < settings.blurPasses; i++)
					{
						Blit(commandBuffer, tempRT1, tempRT2, settings.bloomMaterial, 1);
						Blit(commandBuffer, tempRT2, tempRT1, settings.bloomMaterial, 2);
					}
					Blit(commandBuffer, tempRT1, cameraColorTarget, settings.bloomMaterial, 3);
					context.ExecuteCommandBuffer(commandBuffer);
					CommandBufferPool.Release(commandBuffer);
				}
			}

			public override void OnCameraCleanup(CommandBuffer cmd)
			{
				tempRT1.Release();
				tempRT2.Release();
			}
		}

		public BloomSettings settings = new BloomSettings();

		private BloomRenderPass bloomRenderPass;

		public override void Create()
		{
			bloomRenderPass = new BloomRenderPass(settings);
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (settings.bloomMaterial == null)
			{
				Debug.LogWarning("Bloom material is not assigned.");
				return;
			}
			bloomRenderPass.Setup(renderer.cameraColorTargetHandle);
			renderer.EnqueuePass(bloomRenderPass);
		}
	}
}
