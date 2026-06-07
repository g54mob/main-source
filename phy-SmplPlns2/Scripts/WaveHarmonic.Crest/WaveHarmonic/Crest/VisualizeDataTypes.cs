using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	[InspectorOrder(InspectorSort.ByName, InspectorSortDirection.Ascending)]
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Packages\\com.waveharmonic.crest\\Runtime\\Scripts\\WaterRenderer.SerializedFields.cs", sourcePath = "Packages/com.waveharmonic.crest/Runtime/Shaders/Library/Settings/Visualize.Crest")]
	internal enum VisualizeDataTypes
	{
		Albedo = 0,
		Displacement = 1,
		DynamicWaves = 2,
		Level = 3,
		Flow = 4,
		Foam = 5,
		Shadow = 6,
		Depth = 7,
		Clip = 8,
		ShorelineDistance = 9,
		Absorption = 10,
		Scattering = 11,
		Cascades = 12
	}
}
