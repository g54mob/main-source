using UnityEngine;

namespace GRP
{
	public class CylinderPiece : MonoBehaviour
	{
		public CylinderVisual visual;

		public Rigidbody rb;

		public Collider col;

		public MaterialRowConfig material;

		public Color color;

		public float height;

		public float radius;

		public Vector3 size => default(Vector3);

		private void Awake()
		{
		}

		public void Build()
		{
		}

		private void OnValidate()
		{
		}
	}
}
