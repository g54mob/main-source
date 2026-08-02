using UnityEngine;

namespace GRP
{
	public class BraceLine : MonoBehaviour
	{
		public Mesh lineMesh;

		public MeshFilter lineMeshFilter;

		public MeshCollider lineMeshCollider;

		private float customRatio;

		private Mesh customMesh;

		public void Setup(BracePart part, BracePart other)
		{
		}
	}
}
