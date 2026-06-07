using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum WaterDataBackgroundMode
	{
		[Tooltip("Always progress simulations in the background when camera does not render.")]
		Always = 0,
		[Tooltip("Progress simulations in the background when camera is inactive (ie !isActiveAndEnabled).")]
		Inactive = 1,
		[Tooltip("Progress simulations in the background when camera is disabled (ie !enabled).")]
		Disabled = 2,
		[Tooltip("Never progress simulations in the background.")]
		Never = 3
	}
}
