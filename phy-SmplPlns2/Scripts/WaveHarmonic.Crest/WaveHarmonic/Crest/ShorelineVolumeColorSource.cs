using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum ShorelineVolumeColorSource
	{
		[Tooltip("No depth color.")]
		None = 0,
		[Tooltip("Depth color based on water depth.")]
		Depth = 1,
		[Tooltip("Depth color based on shoreline distance.")]
		Distance = 2
	}
}
