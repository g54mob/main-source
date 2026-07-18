using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ProPixelizer
{
	public abstract class ProPixelizerPass : ScriptableRenderPass
	{
		public void Prepare(CommandBuffer buffer, ref RenderingData renderingData)
		{
			buffer.SetGlobalVector("_ProPixelizer_RenderTargetInfo", new Vector4(renderingData.cameraData.cameraTargetDescriptor.width, renderingData.cameraData.cameraTargetDescriptor.height, 1f, 1f));
		}
	}
}
