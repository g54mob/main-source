using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public static class MB_TextureCombinerSRPCustom_Standard
	{
		private static bool _IsCreatingAtlasForProperty(MB3_TextureCombinerPipeline.TexturePipelineData data, string property)
		{
			return false;
		}

		internal static void ConfigureMaterialKeywords(MB3_TextureCombinerPipeline.TexturePipelineData data, Material resultMat)
		{
		}
	}
}
