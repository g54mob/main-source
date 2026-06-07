using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum LodInputBlend
	{
		[Tooltip("No blending. Overwrites.")]
		Off = 0,
		[Tooltip("Additive blending.")]
		Additive = 1,
		[Tooltip("Takes the minimum value.")]
		Minimum = 2,
		[Tooltip("Takes the maximum value.")]
		Maximum = 3,
		[Tooltip("Applies the inverse weight to the target.\n\nBasically overwrites what is already in the simulation.")]
		Alpha = 4,
		[Tooltip("Same as alpha except anything above zero will overwrite rather than blend.")]
		AlphaClip = 5
	}
}
