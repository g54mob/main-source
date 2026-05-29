using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

namespace CTS
{
	public class KuwaharaTransparencyFixer : ScriptableRendererFeature
	{
		public class PersistentData
		{
		}

		private CopyActiveTargetPass _copyPass;

		private CopyColorPass _copyColorPass;

		public static readonly int AlphaCopy;

		public override void Create()
		{
			_copyPass = new CopyActiveTargetPass
			{
				renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing
			};
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			renderer.EnqueuePass(_copyPass);
		}
	}
}
