using UnityEngine.Rendering;

namespace Shapes
{
	public static class UnityInfo
	{
		public const int INSTANCES_MAX = 1023;

		public static bool UsingSRP => GraphicsSettings.renderPipelineAsset != null;
	}
}
