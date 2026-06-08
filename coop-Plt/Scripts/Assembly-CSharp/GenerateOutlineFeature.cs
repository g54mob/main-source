using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GenerateOutlineFeature : ScriptableRendererFeature
{
	private class GenerateOutlinePass : ScriptableRenderPass
	{
		public Material outlineMaterial;

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

		public GenerateOutlinePass(Material outlineMaterial)
		{
			this.outlineMaterial = outlineMaterial;
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("_GenerateOutlinePass");
			RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
			cameraTargetDescriptor.depthBufferBits = 0;
			if (destination == RenderTargetHandle.CameraTarget)
			{
				commandBuffer.GetTemporaryRT(pingTexture.id, cameraTargetDescriptor, FilterMode.Bilinear);
				Blit(commandBuffer, source, pingTexture.Identifier(), outlineMaterial);
				Blit(commandBuffer, pingTexture.Identifier(), source);
			}
			else
			{
				Blit(commandBuffer, source, destination.Identifier(), outlineMaterial);
			}
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
		public Material outlineMaterial;
	}

	public OutlineSettings settings = new OutlineSettings();

	private GenerateOutlinePass outlinePass;

	private RenderTargetHandle targetTexture;

	public override void Create()
	{
		outlinePass = new GenerateOutlinePass(settings.outlineMaterial);
		outlinePass.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
		targetTexture.Init("_OutlineTexture");
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (settings.outlineMaterial == null)
		{
			Debug.LogWarningFormat("Missing Outline Material");
		}
		else if ((renderingData.cameraData.cameraType & CameraType.Preview) == 0)
		{
			outlinePass.Setup(renderer.cameraColorTarget, RenderTargetHandle.CameraTarget);
			renderer.EnqueuePass(outlinePass);
		}
	}
}
