using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	[Flags]
	public enum CollisionLayers
	{
		[Tooltip("No extra layers (ie single layer).")]
		Nothing = 0,
		[Tooltip("Separate layer for dynamic waves.\n\nDynamic waves are normally combined together for efficiency. By enabling this layer, dynamic waves are combined and added in a separate pass.")]
		DynamicWaves = 2,
		[Tooltip("Extra displacement layer for visual displacement.")]
		Displacement = 4,
		[Tooltip("All layers.")]
		Everything = -1
	}
}
