using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum LodQuerySource
	{
		[Tooltip("No query source.")]
		None = 0,
		[Tooltip("Uses AsyncGPUReadback to retrieve data from GPU to CPU.\n\nThis is the most optimal approach.")]
		GPU = 1,
		[Tooltip("Computes data entirely on the CPU.")]
		CPU = 2
	}
}
