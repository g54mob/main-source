using UnityEngine;

namespace Linework.EdgeDetection
{
	public enum SectionMapInput
	{
		[InspectorName("Solid Color")]
		None = 0,
		[InspectorName("Vertex Color")]
		VertexColors = 1,
		[InspectorName("Section Texture")]
		SectionTexture = 2,
		[InspectorName("Custom")]
		Custom = 3
	}
}
