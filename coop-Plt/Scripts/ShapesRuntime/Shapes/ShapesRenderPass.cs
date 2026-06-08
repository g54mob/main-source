using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Shapes
{
	internal class ShapesRenderPass : ScriptableRenderPass
	{
		private DrawCommand drawCommand;

		public ShapesRenderPass(DrawCommand drawCommand)
		{
			this.drawCommand = drawCommand;
			base.renderPassEvent = drawCommand.camEvt;
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = new CommandBuffer
			{
				name = drawCommand.name
			};
			drawCommand.AppendToBuffer(commandBuffer);
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Release();
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			DrawCommand.OnCommandRendered(drawCommand);
		}
	}
}
