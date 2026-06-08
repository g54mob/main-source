using UnityEngine;

namespace Kitchen
{
	[RequireComponent(typeof(MeshFilter))]
	public class VertexColour : MonoBehaviour
	{
		public Color32 Color;

		private void Start()
		{
			MeshFilter component = GetComponent<MeshFilter>();
			int vertexCount = component.mesh.vertexCount;
			Color32[] array = new Color32[vertexCount];
			for (int i = 0; i < vertexCount; i++)
			{
				array[i] = Color;
			}
			component.mesh.colors32 = array;
		}
	}
}
