using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Tools
{
	public static class CameraExtensions
	{
		private static Bounds _cachedCamBounds;

		public static Bounds OrthographicBounds(this Camera camera)
		{
			return default(Bounds);
		}

		public static Bounds OrthographicBoundsIgnoringBorders(this Camera camera)
		{
			return default(Bounds);
		}

		public static bool IsObjectVisible(this Camera camera, Renderer renderer)
		{
			return false;
		}

		public static Vector2 GetScreenBounds(this Camera camera, bool usePixels = false)
		{
			return default(Vector2);
		}

		public static float GetRtZoomScaling(this Camera camera)
		{
			return 0f;
		}

		public static int2 GetRenderTextureSize(this Camera camera)
		{
			return default(int2);
		}

		public static void ResetOrthographicSize(this Camera camera)
		{
		}

		public static void ResetOrthographicAndRenderTextureSize(this Camera camera)
		{
		}
	}
}
