using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CustomRenderPass : ScriptableRenderPass
{
	private RTHandle source;

	private RTHandle destination;

	private CustomRenderPassFeature.CustomRenderPassSettings settings;

	public CustomRenderPass(CustomRenderPassFeature.CustomRenderPassSettings settings)
	{
		this.settings = settings;
		base.renderPassEvent = settings.renderPassEvent;
	}

	public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
	{
		source = renderingData.cameraData.renderer.cameraColorTargetHandle;
		RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
		RenderingUtils.ReAllocateIfNeeded(ref destination, in descriptor, FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, "_CustomRenderPassTemp");
		ConfigureTarget(destination);
	}

	public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
	{
		CommandBuffer commandBuffer = CommandBufferPool.Get("CustomRenderPass");
		Blit(commandBuffer, source, destination, settings.material);
		Blit(commandBuffer, destination, source);
		context.ExecuteCommandBuffer(commandBuffer);
		CommandBufferPool.Release(commandBuffer);
	}

	public override void OnCameraCleanup(CommandBuffer cmd)
	{
		destination?.Release();
	}
}
