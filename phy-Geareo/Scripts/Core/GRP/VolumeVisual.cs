using UnityEngine;

namespace GRP
{
	public class VolumeVisual : MonoBehaviour
	{
		public Transform shapeTransform;

		public MeshFilter shapeMeshFilter;

		public MeshRenderer shapeMeshRenderer;

		public MeshCollider shapeMeshCollider;

		public Mesh meshBox;

		public Mesh meshSphere;

		public Mesh meshCylinder;

		private MaterialPropertyBlock materialBlock;

		public void Setup(VolumePart part)
		{
		}
	}
}
