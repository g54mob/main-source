using UnityEngine;
using UnityEngine.Rendering;

namespace PI.NGSS
{
	public interface NGSS_IExternalEnvironmentProvider
	{
		void RenderFullscreenEffect(CommandBuffer buffer, Camera camera, Material material, Light light, int shaderPass);

		bool IsVREnabled();
	}
}
