using UnityEngine;

namespace Linework.EdgeDetection
{
	public enum DebugView
	{
		None = 0,
		[InspectorName("Depth")]
		Depth = 1,
		[InspectorName("Normals")]
		Normals = 2,
		[InspectorName("Luminance")]
		Luminance = 3,
		[InspectorName("Sections")]
		Sections = 4
	}
}
