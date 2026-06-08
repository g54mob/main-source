using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VertexColourFeature : ScriptableRendererFeature
{
	private class VertexColourPass : ScriptableRenderPass
	{
		private int kDepthBufferBits = 32;

		private Material depthNormalsMaterial;

		private string m_ProfilerTag = "Vertex Colour Texture Prepass";

		private ShaderTagId m_ShaderTagId = new ShaderTagId("DepthOnly");

		private LayerMask Ghosts;

		private LayerMask Statics;

		private LayerMask Food;

		private RenderTargetHandle colourAttachmentHandle { get; set; }

		internal RenderTextureDescriptor descriptor { get; private set; }

		public VertexColourPass(Material material, LayerMask ghosts, LayerMask statics, LayerMask food)
		{
			depthNormalsMaterial = material;
			Ghosts = ghosts;
			Statics = statics;
			Food = food;
		}

		public void Setup(RenderTextureDescriptor baseDescriptor, RenderTargetHandle colourAttachmentHandle)
		{
			this.colourAttachmentHandle = colourAttachmentHandle;
			baseDescriptor.colorFormat = RenderTextureFormat.ARGB32;
			baseDescriptor.depthBufferBits = kDepthBufferBits;
			descriptor = baseDescriptor;
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			cmd.GetTemporaryRT(colourAttachmentHandle.id, descriptor, FilterMode.Trilinear);
			ConfigureTarget(colourAttachmentHandle.Identifier());
			ConfigureClear(ClearFlag.All, Color.black);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get(m_ProfilerTag);
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			SortingCriteria defaultOpaqueSortFlags = renderingData.cameraData.defaultOpaqueSortFlags;
			FilteringSettings filteringSettings = new FilteringSettings(RenderQueueRange.opaque, Statics);
			FilteringSettings filteringSettings2 = new FilteringSettings(RenderQueueRange.opaque, ~(int)Statics & ~(int)Ghosts & ~(int)Food);
			FilteringSettings filteringSettings3 = new FilteringSettings(RenderQueueRange.all, Ghosts);
			new FilteringSettings(RenderQueueRange.all, Food);
			DrawingSettings drawingSettings = CreateDrawingSettings(m_ShaderTagId, ref renderingData, defaultOpaqueSortFlags);
			drawingSettings.perObjectData = PerObjectData.None;
			drawingSettings.enableDynamicBatching = true;
			drawingSettings.overrideMaterial = depthNormalsMaterial;
			drawingSettings.overrideMaterialPassIndex = 1;
			DrawingSettings drawingSettings2 = CreateDrawingSettings(m_ShaderTagId, ref renderingData, defaultOpaqueSortFlags);
			drawingSettings2.perObjectData = PerObjectData.None;
			drawingSettings2.enableDynamicBatching = true;
			drawingSettings2.overrideMaterial = depthNormalsMaterial;
			drawingSettings2.overrideMaterialPassIndex = 0;
			DrawingSettings drawingSettings3 = CreateDrawingSettings(m_ShaderTagId, ref renderingData, defaultOpaqueSortFlags);
			drawingSettings3.perObjectData = PerObjectData.None;
			drawingSettings3.enableDynamicBatching = true;
			drawingSettings3.overrideMaterial = depthNormalsMaterial;
			drawingSettings3.overrideMaterialPassIndex = 2;
			context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings);
			context.DrawRenderers(renderingData.cullResults, ref drawingSettings2, ref filteringSettings2);
			context.DrawRenderers(renderingData.cullResults, ref drawingSettings3, ref filteringSettings3);
			commandBuffer.SetGlobalTexture("_CameraVertexColourTexture", colourAttachmentHandle.id);
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			if (colourAttachmentHandle != RenderTargetHandle.CameraTarget)
			{
				cmd.ReleaseTemporaryRT(colourAttachmentHandle.id);
				colourAttachmentHandle = RenderTargetHandle.CameraTarget;
			}
		}
	}

	private VertexColourPass depthNormalsPass;

	private RenderTargetHandle depthNormalsTexture;

	public Material depthNormalsMaterial;

	public LayerMask Ghosts;

	public LayerMask Statics;

	public LayerMask Food;

	public override void Create()
	{
		depthNormalsPass = new VertexColourPass(depthNormalsMaterial, Ghosts, Statics, Food);
		depthNormalsPass.renderPassEvent = RenderPassEvent.AfterRenderingPrePasses;
		depthNormalsTexture.Init("_CameraVertexColourTexture");
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
		cameraTargetDescriptor.useMipMap = true;
		depthNormalsPass.Setup(cameraTargetDescriptor, depthNormalsTexture);
		renderer.EnqueuePass(depthNormalsPass);
	}
}
