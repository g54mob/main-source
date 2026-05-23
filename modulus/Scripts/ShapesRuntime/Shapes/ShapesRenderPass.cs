using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Shapes
{
	internal class ShapesRenderPass : ScriptableRenderPass
	{
		private DrawCommand drawCommand;

		private readonly CommandBuffer cmdBuf = new CommandBuffer();

		public ShapesRenderPass Init(DrawCommand drawCommand)
		{
			this.drawCommand = drawCommand;
			base.renderPassEvent = drawCommand.camEvt;
			return this;
		}

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
