using UnityEngine;
using UnityEngine.Rendering;

namespace CRTFilter
{
	[VolumeComponentMenu("CRTFilter")]
	public class CRTVolumeComponent : VolumeComponent
	{
		public ClampedFloatParameter screenBend = new ClampedFloatParameter(0f, 0f, 11f);

		public ClampedFloatParameter screenOverscan = new ClampedFloatParameter(0f, 0f, 30f);

		public ClampedFloatParameter vignetteSize = new ClampedFloatParameter(0f, 0f, 20f);

		public ClampedFloatParameter vignetteSmooth = new ClampedFloatParameter(2f, 0f, 10f);

		public ClampedFloatParameter vignetteRound = new ClampedFloatParameter(25f, 0f, 100f);

		public ClampedFloatParameter blur = new ClampedFloatParameter(0f, 0f, 10f);

		public ClampedFloatParameter bleed = new ClampedFloatParameter(0f, 0f, 25f);

		public ClampedFloatParameter smidge = new ClampedFloatParameter(0f, 0f, 25f);

		public ClampedFloatParameter scanlinesStrength = new ClampedFloatParameter(0f, 0f, 25f);

		public ClampedFloatParameter apertureStrength = new ClampedFloatParameter(0f, 0f, 10f);

		public ClampedFloatParameter shadowlines = new ClampedFloatParameter(6f, -50f, 50f);

		public ClampedFloatParameter shadowlinesSpeed = new ClampedFloatParameter(2f, -50f, 50f);

		public ClampedFloatParameter shadowlinesAlpha = new ClampedFloatParameter(0f, 0f, 1f);

		public ClampedFloatParameter noiseSize = new ClampedFloatParameter(50f, 0f, 50f);

		public ClampedFloatParameter noiseSpeed = new ClampedFloatParameter(2f, 0f, 10f);

		public ClampedFloatParameter noiseAlpha = new ClampedFloatParameter(0f, 0f, 1f);

		public ClampedFloatParameter brightness = new ClampedFloatParameter(1f, 0f, 2f);

		public ClampedFloatParameter contrast = new ClampedFloatParameter(1f, -1f, 3f);

		public ClampedFloatParameter gamma = new ClampedFloatParameter(1f, 0f, 2f);

		public ClampedFloatParameter red = new ClampedFloatParameter(1f, 0f, 2f);

		public ClampedFloatParameter green = new ClampedFloatParameter(1f, 0f, 2f);

		public ClampedFloatParameter blue = new ClampedFloatParameter(1f, 0f, 2f);

		public ClampedFloatParameter chromaticAberration = new ClampedFloatParameter(1f, -10f, 10f);

		public Vector2Parameter redOffset = new Vector2Parameter(Vector2.zero);

		public Vector2Parameter blueOffset = new Vector2Parameter(Vector2.zero);

		public Vector2Parameter greenOffset = new Vector2Parameter(Vector2.zero);
	}
}
