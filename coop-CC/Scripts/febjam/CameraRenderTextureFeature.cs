using System;
using Aggro.Core;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraRenderTextureFeature : ScriptableRendererFeature
{
	private class CameraRenderTextureRenderPass : ScriptableRenderPass, IDisposable
	{
		private ProfilingSampler _profilingSampler;

		public CameraRenderTextureRenderPass()
		{
			base.renderPassEvent = RenderPassEvent.BeforeRenderingOpaques;
			_profilingSampler = new ProfilingSampler("Camera Render Texture Pass");
		}

		public void Dispose()
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if (AggroManagerBase<CameraRenderTexture>.ManagerExists())
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				using (new ProfilingScope(commandBuffer, _profilingSampler))
				{
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
					Blitter.BlitCameraTexture(commandBuffer, AggroManagerBase<CameraRenderTexture>.instance.rtHandle, cameraColorTargetHandle, 0f, bilinear: true);
				}
				context.ExecuteCommandBuffer(commandBuffer);
				commandBuffer.Clear();
				CommandBufferPool.Release(commandBuffer);
			}
		}
	}

	private CameraRenderTextureRenderPass _pass;

	public override void Create()
	{
		_pass = new CameraRenderTextureRenderPass();
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (renderingData.cameraData.cameraType == CameraType.Game)
		{
			renderer.EnqueuePass(_pass);
		}
	}

	protected override void Dispose(bool disposing)
	{
		_pass.Dispose();
	}
}
