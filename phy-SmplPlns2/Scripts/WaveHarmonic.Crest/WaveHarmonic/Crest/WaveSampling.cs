using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum WaveSampling
	{
		[Tooltip("Automatically chooses the other options as needed (512+ resolution needs precision).")]
		Automatic = 0,
		[Tooltip("Reduces samples by copying waves from higher LODs to lower LODs.\n\nBest for resolutions lower than 512.")]
		Performance = 1,
		[Tooltip("Samples directly from the wave buffers to preserve wave quality.\n\nNeeded for higher resolutions (512+). Higher LOD counts can also benefit with this enabled.")]
		Precision = 2
	}
}
