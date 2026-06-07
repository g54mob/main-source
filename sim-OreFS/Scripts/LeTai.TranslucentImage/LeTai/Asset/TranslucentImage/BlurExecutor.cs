using UnityEngine;
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
				this.sourceTex = sourceTex;
				this.blurSource = blurSource;
				this.blurAlgorithm = blurAlgorithm;
			}
		}

		private static readonly int[] TEMP_RT;

		static BlurExecutor()
		{
			TEMP_RT = new int[14];
			for (int i = 0; i < TEMP_RT.Length; i++)
			{
				TEMP_RT[i] = Shader.PropertyToID($"TI_intermediate_rt_{i}");
			}
		}

		public static void ExecuteBlurWithTempTextures(CommandBuffer cmd, ref BlurExecutionData data)
		{
			int scratchesCount = data.blurAlgorithm.GetScratchesCount();
			RenderTextureDescriptor descriptor = data.blurSource.BlurredScreen.descriptor;
			descriptor.msaaSamples = 1;
			descriptor.useMipMap = false;
			descriptor.depthBufferBits = 0;
			for (int i = 0; i < scratchesCount; i++)
			{
				data.blurAlgorithm.GetScratchDescriptor(i, ref descriptor);
				cmd.GetTemporaryRT(TEMP_RT[i], descriptor, FilterMode.Bilinear);
				data.blurAlgorithm.SetScratch(i, TEMP_RT[i]);
			}
			ExecuteBlur(cmd, ref data);
			for (int j = 0; j < scratchesCount; j++)
			{
				cmd.ReleaseTemporaryRT(TEMP_RT[j]);
			}
		}

		public static void ExecuteBlur(CommandBuffer cmd, ref BlurExecutionData data)
		{
			TranslucentImageSource blurSource = data.blurSource;
			data.blurAlgorithm.Blur(cmd, data.sourceTex, blurSource.BlurRegion, blurSource.ActiveRegion, blurSource.BackgroundFill, blurSource.BlurredScreen);
		}
	}
}
