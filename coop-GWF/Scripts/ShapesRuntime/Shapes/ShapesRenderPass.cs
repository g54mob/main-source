using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Shapes
{
	internal class ShapesRenderPass : ScriptableRenderPass
	{
		private class PassData
		{
			public DrawCommand drawCommand;
		}

		private DrawCommand drawCommand;

		private readonly CommandBuffer cmdBuf = new CommandBuffer();

		public ShapesRenderPass Init(DrawCommand drawCommand)
		{
			this.drawCommand = drawCommand;
			base.renderPassEvent = drawCommand.camEvt;
			return this;
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			PassData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Render Shapes", out passData, "/github/workspace/Assets/ThirdParty/Shapes/Scripts/Runtime/Immediate Mode/ShapesRenderPass.cs", 40);
			passData.drawCommand = drawCommand;
			rasterRenderGraphBuilder.AllowPassCulling(value: false);
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.cameraColor, 0);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData dataParam, RasterGraphContext context)
			{
				dataParam.drawCommand.AppendToBuffer(context.cmd);
			});
		}

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled)", false)]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			drawCommand.AppendToBuffer(cmdBuf);
			context.ExecuteCommandBuffer(cmdBuf);
			cmdBuf.Clear();
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			DrawCommand.OnCommandRendered(drawCommand);
			drawCommand = null;
			ObjectPool<ShapesRenderPass>.Free(this);
		}
	}
}
