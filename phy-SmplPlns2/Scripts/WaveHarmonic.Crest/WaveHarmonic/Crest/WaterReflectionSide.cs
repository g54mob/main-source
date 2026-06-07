using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum WaterReflectionSide
	{
		[Tooltip("Both sides. Most expensive.")]
		Both = 0,
		[Tooltip("Above only. Typical for planar reflections.")]
		Above = 1,
		[Tooltip("Below only. For total internal reflections.")]
		Below = 2
	}
}
