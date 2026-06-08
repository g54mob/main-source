using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlitRenderTargetFeature : ScriptableRendererFeature
{
	private class BlitRenderTargetPass : ScriptableRenderPass
	{
		public RenderTexture Texture;

		private RenderTargetHandle pingTexture;

		private RenderTargetHandle pongTexture;

		private RenderTargetIdentifier source { get; set; }

		private RenderTargetHandle destination { get; set; }

		private RenderTextureDescriptor descriptor { get; set; }

		public void Setup(RenderTargetIdentifier source, RenderTargetHandle destination)
		{
			this.source = source;
			this.destination = destination;
		}

		public BlitRenderTargetPass(RenderTexture texture)
		{
			Texture = texture;
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("_BlitRenderTarget");
			RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
			cameraTargetDescriptor.depthBufferBits = 0;
			Blit(commandBuffer, Texture, source);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			if (destination == RenderTargetHandle.CameraTarget)
			{
				cmd.ReleaseTemporaryRT(pingTexture.id);
			}
		}
	}

	[Serializable]
	public class OutlineSettings
	{
		public RenderTexture Texture;
	}

	public OutlineSettings settings = new OutlineSettings();

	private BlitRenderTargetPass outlinePass;

	private RenderTargetHandle targetTexture;

	public override void Create()
	{
		outlinePass = new BlitRenderTargetPass(settings.Texture);
		outlinePass.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
		targetTexture.Init("_OutlineTexture");
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if ((renderingData.cameraData.cameraType & CameraType.Preview) == 0)
		{
			outlinePass.Setup(renderer.cameraColorTarget, RenderTargetHandle.CameraTarget);
			renderer.EnqueuePass(outlinePass);
		}
	}
}
