using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum LodTextureFormatMode
	{
		[Tooltip("Uses the Texture Format property.")]
		Manual = 0,
		[Tooltip("Chooses a texture format for performance.")]
		Performance = 100,
		[Tooltip("Chooses a texture format for precision.\n\nThis format can reduce artifacts.")]
		Precision = 200,
		[Tooltip("Chooses a texture format based on another.\n\nFor example, Dynamic Waves will match precision of Animated Waves.")]
		Automatic = 300
	}
}
