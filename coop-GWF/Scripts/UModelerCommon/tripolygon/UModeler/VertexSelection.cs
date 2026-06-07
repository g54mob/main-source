using UnityEngine;

namespace tripolygon.UModeler
{
	public class VertexSelection
	{
		public Mesh vertexSelectionMesh;

		public Material vertexSelectionMaterial;

		public VertexSelection()
		{
			vertexSelectionMesh = new Mesh();
			vertexSelectionMaterial = null;
		}
	}
}
