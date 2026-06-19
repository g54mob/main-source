using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	public class CameraWidthLimiter : MonoBehaviour
	{
		private CommandBuffer _commandBuffer;

		protected void OnEnable()
		{
			_commandBuffer = new CommandBuffer();
			_commandBuffer.name = "Camera Width Limiter";
			_commandBuffer.DisableScissorRect();
			_commandBuffer.ClearRenderTarget(clearDepth: false, clearColor: true, Color.black, 0f);
		}

		public void OnPreRender()
		{
			float maxVisibleAspectRatio = 3.6666667f;
			if (CameraUtils.GetLimitVisibleAspectRatioRect(Screen.width, Screen.height, maxVisibleAspectRatio, out var rect))
			{
				Graphics.ExecuteCommandBuffer(_commandBuffer);
			}
			Camera.current.rect = rect;
		}

		protected void OnDestory()
		{
			_commandBuffer.Dispose();
		}
	}
}
