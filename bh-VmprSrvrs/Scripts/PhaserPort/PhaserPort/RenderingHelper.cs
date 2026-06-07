using Unity.Mathematics;

namespace PhaserPort
{
	public static class RenderingHelper
	{
		private const float TargetRatio = 1.6f;

		public static float ScreenWidth => 0f;

		public static float ScreenHeight => 0f;

		public static float2 GetRendererSize()
		{
			return default(float2);
		}

		public static float2 GetRendererSizeIgnoringBorders()
		{
			return default(float2);
		}

		public static float2 GetCameraCenter()
		{
			return default(float2);
		}

		public static bool IsTablet()
		{
			return false;
		}

		public static bool TryApplySavedOrientation()
		{
			return false;
		}

		private static float2 UpdateRendererForPortrait()
		{
			return default(float2);
		}

		private static float2 UpdateRendererForLandscape()
		{
			return default(float2);
		}
	}
}
