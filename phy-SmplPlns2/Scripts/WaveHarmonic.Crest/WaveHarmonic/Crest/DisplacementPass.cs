using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum DisplacementPass
	{
		[Tooltip("Displacement that is dependent on an LOD (eg waves).\n\nUses filtering to determine which LOD to write to.")]
		LodDependent = 0,
		[Tooltip("Renders to all LODs.")]
		LodIndependent = 1,
		[Tooltip("Renders to all LODs, but as a separate pass.\n\nTypically used to render visual displacement which does not affect collisions.")]
		[InspectorName("Lod Independent (Last)")]
		LodIndependentLast = 2
	}
}
