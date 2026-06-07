using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum WatertightHullMode
	{
		[Tooltip("Use displacement to remove water.\n\nUsing displacement will also affect the underwater and can nest bouyant objects. Requires the displacement layer to be enabled.")]
		Displacement = 0,
		[Tooltip("Clips the surface to remove water.\n\nThis option is more precise and can be submerged.")]
		Clip = 1
	}
}
