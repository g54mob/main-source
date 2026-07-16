using System;
using UnityEngine;

namespace Game.Graphics
{
	[Serializable]
	public class GraphicsContainer
	{
		[Header("Video")]
		public int resolutionX;

		public int resolutionY;

		public int resolutionIndex;

		public double refreshRate;

		public int monitor;

		public int fullscreenMode;

		public int vSync;

		public float renderScale;

		public float brightness;

		[Header("Graphics")]
		public int quality;

		public int shadowQuality;

		public static GraphicsContainer DefaultSettings()
		{
			return new GraphicsContainer(1920, 1080, 0, Screen.currentResolution.refreshRateRatio.value, DisplayUtility.GetMainDisplay(), 1, 1, 1f, 1f, 0, 0);
		}

		public GraphicsContainer(int resolutionX, int resolutionY, int resolutionIndex, double refreshRate, int monitor, int fullscreenMode, int vSync, float renderScale, float brightness, int quality, int shadowQuality)
		{
			this.resolutionX = resolutionX;
			this.resolutionY = resolutionY;
			this.resolutionIndex = resolutionIndex;
			this.refreshRate = refreshRate;
			this.monitor = monitor;
			this.fullscreenMode = fullscreenMode;
			this.vSync = vSync;
			this.renderScale = renderScale;
			this.brightness = brightness;
			this.quality = quality;
			this.shadowQuality = shadowQuality;
		}
	}
}
