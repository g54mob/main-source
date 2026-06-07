using UnityEngine;

namespace Deform
{
	[ExecuteAlways]
	public class VertexCache : ScriptableObject
	{
		[SerializeField]
		[HideInInspector]
		public ManagedMeshData Data = new ManagedMeshData();

		public void Initialize(Mesh mesh)
		{
			Data = new ManagedMeshData(mesh);
		}
	}
}
