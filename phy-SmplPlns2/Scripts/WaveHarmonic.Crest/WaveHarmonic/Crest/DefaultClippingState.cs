using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum DefaultClippingState
	{
		[Tooltip("By default, nothing is clipped. Use clip inputs to remove water.")]
		NothingClipped = 0,
		[Tooltip("By default, everything is clipped. Use clip inputs to add water.")]
		EverythingClipped = 1
	}
}
