using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum DepthProbeRefreshMode
	{
		[Tooltip("Populates the DepthProbe in Start.")]
		OnStart = 0,
		[Tooltip("Populates the DepthProbe every frame.")]
		EveryFrame = 1,
		[Tooltip("Requires manual updating via DepthProbe.Populate.")]
		ViaScripting = 2
	}
}
