using UnityEngine.Rendering;

namespace LeTai.Asset.TranslucentImage
{
	public static class BlurExecutor
	{
		public readonly struct BlurExecutionData
		{
			public readonly RenderTargetIdentifier sourceTex;

			public readonly TranslucentImageSource blurSource;

			public readonly IBlurAlgorithm blurAlgorithm;

			public BlurExecutionData(RenderTargetIdentifier sourceTex, TranslucentImageSource blurSource, IBlurAlgorithm blurAlgorithm)
			{
				this.sourceTex = default(RenderTargetIdentifier);
				this.blurSource = null;
				this.blurAlgorithm = null;
			}
		}

		private static readonly int[] TEMP_RT;

		static BlurExecutor()
		{
		}

		public static void ExecuteBlurWithTempTextures(CommandBuffer cmd, ref BlurExecutionData data)
		{
		}

		public static void ExecuteBlur(CommandBuffer cmd, ref BlurExecutionData data)
		{
		}
	}
}
