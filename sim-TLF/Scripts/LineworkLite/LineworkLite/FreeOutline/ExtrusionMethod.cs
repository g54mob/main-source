using UnityEngine;

namespace LineworkLite.FreeOutline
{
	public enum ExtrusionMethod
	{
		[InspectorName("Vertex Position (OS)")]
		ObjectSpaceVertexPosition = 0,
		[InspectorName("Normalized Vertex Position (OS)")]
		ObjectSpaceNormalizedVertexPosition = 1,
		[InspectorName("Normal Vector (OS)")]
		ObjectSpaceNormalVector = 2,
		[InspectorName("Vertex Color (OS)")]
		ObjectSpaceVertexColor = 3,
		[InspectorName("Normal Vector (CS)")]
		ClipSpaceNormalVector = 4,
		[InspectorName("Normal Vector (SS)")]
		ScreenSpaceNormalVector = 5,
		[InspectorName("Normal Vector (WS)")]
		WorldSpaceNormalVector = 6,
		[InspectorName("Smoothed Normals")]
		SmoothedNormals = 7
	}
}
