using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum CollisionLayer
	{
		[Tooltip("Include all displacement.")]
		Everything = 0,
		[Tooltip("Only include Animated Waves.")]
		AfterAnimatedWaves = 1,
		[Tooltip("Include Animated Waves and Dynamic Waves.")]
		AfterDynamicWaves = 2
	}
}
