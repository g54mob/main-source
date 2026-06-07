using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIVisibilityBuffer : GPUIDataBuffer<GPUIVisibilityData>
	{
		public GPUICameraData cameraData;

		public GPUIVisibilityBuffer(GPUICameraData cameraData, string name, GraphicsBuffer.Target target = GraphicsBuffer.Target.Structured)
			: base(name, 0, target)
		{
			this.cameraData = cameraData;
		}
	}
}
