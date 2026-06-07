using UnityEngine.Rendering;

namespace Kamgam.SettingsGenerator
{
	public static class RenderPipelineDetector
	{
		public enum RenderPiplelineType
		{
			URP = 0,
			HDRP = 1,
			BuiltIn = 2
		}

		public static RenderPiplelineType GetCurrentRenderPiplelineType()
		{
			RenderPipelineAsset currentRenderPipeline = GraphicsSettings.currentRenderPipeline;
			if (currentRenderPipeline != null)
			{
				if (currentRenderPipeline.GetType().Name.Contains("Universal"))
				{
					return RenderPiplelineType.URP;
				}
				return RenderPiplelineType.HDRP;
			}
			return RenderPiplelineType.BuiltIn;
		}

		public static bool IsURP()
		{
			return GetCurrentRenderPiplelineType() == RenderPiplelineType.URP;
		}

		public static bool IsHDRP()
		{
			return GetCurrentRenderPiplelineType() == RenderPiplelineType.HDRP;
		}

		public static bool IsBuiltIn()
		{
			return GetCurrentRenderPiplelineType() == RenderPiplelineType.BuiltIn;
		}
	}
}
