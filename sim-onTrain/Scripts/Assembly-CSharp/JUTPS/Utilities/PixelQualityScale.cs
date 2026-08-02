using UnityEngine;

namespace JUTPS.Utilities
{
	[AddComponentMenu("JU TPS/Mobile/Optimization/Pixel Quality Scale")]
	public class PixelQualityScale : MonoBehaviour
	{
		private Resolution start_current_resolution;

		[Space]
		[Header("Is useful for increasing mobile performance")]
		[Header("This will reduce the resolution up to 2 times")]
		[Range(3f, 1f)]
		public float ResolutionQuality;

		private void Start()
		{
			SetRenderResolutionQuality(Display.main.systemWidth, Display.main.systemHeight, ResolutionQuality);
		}

		private void SetRenderResolutionQuality(int width, int height, float downScale)
		{
			start_current_resolution.width = width;
			start_current_resolution.height = height;
			int width2 = (int)((float)start_current_resolution.width / downScale);
			int height2 = (int)((float)start_current_resolution.height / downScale);
			Screen.SetResolution(width2, height2, fullscreen: true);
			MonoBehaviour.print("Resolution: Width: " + width2 + "Height: " + height2);
		}
	}
}
