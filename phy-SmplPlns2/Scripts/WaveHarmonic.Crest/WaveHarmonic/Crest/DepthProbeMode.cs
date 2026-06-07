using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum DepthProbeMode
	{
		[Tooltip("Update in real-time in accordance to refresh mode.")]
		RealTime = 0,
		[Tooltip("Baked in the editor.")]
		Baked = 1
	}
}
