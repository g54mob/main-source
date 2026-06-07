using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace WaveHarmonic.Crest
{
	internal sealed class RenderPipelineHelper
	{
		public static RenderPipeline RenderPipeline
		{
			get
			{
				if (GraphicsSettings.currentRenderPipeline is UniversalRenderPipelineAsset)
				{
					return RenderPipeline.Universal;
				}
				return RenderPipeline.Legacy;
			}
		}

		public static bool IsLegacy => GraphicsSettings.currentRenderPipeline == null;

		public static bool IsUniversal => GraphicsSettings.currentRenderPipeline is UniversalRenderPipelineAsset;

		public static bool IsHighDefinition => false;
	}
}
