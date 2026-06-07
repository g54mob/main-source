using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	[Obsolete("Please use QuerySource and LodQuerySource.")]
	public enum CollisionSource
	{
		[Tooltip("No collision source. Flat water.")]
		None = 0,
		[Tooltip("Uses AsyncGPUReadback to retrieve data from GPU to CPU.\n\nThis is the most optimal approach.")]
		GPU = 2,
		[Tooltip("Computes data entirely on the CPU.")]
		CPU = 3
	}
}
