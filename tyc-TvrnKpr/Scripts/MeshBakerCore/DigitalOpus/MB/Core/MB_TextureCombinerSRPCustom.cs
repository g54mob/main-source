using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public static class MB_TextureCombinerSRPCustom
	{
		private static bool IsURPMaterial(Material m)
		{
			return false;
		}

		internal static void ConfigureMaterialKeywordsIfNecessary(MB3_TextureCombinerPipeline.TexturePipelineData data)
		{
		}
	}
}
