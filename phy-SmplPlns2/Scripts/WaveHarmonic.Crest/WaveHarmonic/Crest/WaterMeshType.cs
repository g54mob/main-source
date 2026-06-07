using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal enum WaterMeshType
	{
		[Tooltip("Chunks implemented as a clip-map.")]
		Chunks = 0,
		[Tooltip("A single quad.\n\nOptimal for demanding platforms like mobile. Displacement will only contribute to normals.")]
		Quad = 1
	}
}
