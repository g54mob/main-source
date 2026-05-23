using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CustomPostProcess : ScriptableRendererFeature
{
	private class CustomRenderPass : ScriptableRenderPass
	{
		public RenderTargetIdentifier source;

		private Material mat;

		private RenderTargetHandle tempRenderTargetHandle;

		public CustomRenderPass(Material _mat)
		{
			mat = _mat;
			tempRenderTargetHandle.Init("_TemporaryColorTexture");
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			commandBuffer.GetTemporaryRT(tempRenderTargetHandle.id, renderingData.cameraData.cameraTargetDescriptor);
			Blit(commandBuffer, source, tempRenderTargetHandle.Identifier(), mat);
			Blit(commandBuffer, tempRenderTargetHandle.Identifier(), source);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void OnCameraCleanup(CommandBuffer cmd)
		{
		}
	}

	[Serializable]
	public class Settings
	{
		public Material material;
	}

	private CustomRenderPass m_ScriptablePass;

	public Settings settings;

	public override void Create()
	{
		m_ScriptablePass = new CustomRenderPass(settings.material);
		m_ScriptablePass.renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		m_ScriptablePass.source = renderer.cameraColorTarget;
		renderer.EnqueuePass(m_ScriptablePass);
	}
}
