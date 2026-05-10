using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CTS
{
	public class CopyActiveTargetPass : ScriptableRenderPass
	{
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBufferPool.Get("CopyAlpha").GetTemporaryRT(KuwaharaTransparencyFixer.AlphaCopy, renderingData.cameraData.cameraTargetDescriptor);
		}
	}
}
