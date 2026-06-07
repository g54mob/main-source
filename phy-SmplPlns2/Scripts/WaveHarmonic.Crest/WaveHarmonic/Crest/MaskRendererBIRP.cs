using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	internal sealed class MaskRendererBIRP : MaskRenderer
	{
		private CommandBuffer _Commands;

		public MaskRendererBIRP(WaterRenderer water)
			: base(water)
		{
		}

		public override void Enable()
		{
			base.Enable();
			Allocate();
		}

		public override void OnBeginCameraRendering(Camera camera)
		{
			if (ShouldExecute(camera))
			{
				if (_Commands == null)
				{
					_Commands = new CommandBuffer
					{
						name = "Crest.DrawMask"
					};
				}
				_Water.UpdateMatrices(camera);
				RenderTextureDescriptor cameraTargetDescriptor = Rendering.BIRP.GetCameraTargetDescriptor(camera);
				cameraTargetDescriptor.useDynamicScale = camera.allowDynamicResolution;
				Allocate();
				ReAllocate(cameraTargetDescriptor);
				Execute(camera, _Commands);
				camera.AddCommandBuffer(CameraEvent.BeforeGBuffer, _Commands);
				camera.AddCommandBuffer(CameraEvent.BeforeDepthTexture, _Commands);
			}
		}

		public override void OnEndCameraRendering(Camera camera)
		{
			if (_Commands != null)
			{
				camera.RemoveCommandBuffer(CameraEvent.BeforeGBuffer, _Commands);
				camera.RemoveCommandBuffer(CameraEvent.BeforeDepthTexture, _Commands);
				_Commands.Clear();
			}
		}
	}
}
