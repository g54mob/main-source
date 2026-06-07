using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum WaterInjectionPoint
	{
		[Tooltip("Renders in the default pass.\n\nFor the water surface, this will be determined by the material (opaque or transparent). This pass is controlled by Unity, and is not compatible with certain features like soft particles.\n\nFor the water volume, this will be after transparency.")]
		Default = 0,
		[Tooltip("Renders before the transparent pass.\n\nThis has advantages like being compatible with soft particles, refractive shaders, and possibly third-party fog.")]
		BeforeTransparent = 1
	}
}
