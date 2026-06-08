using UnityEngine;

namespace GRP
{
	public class SpherePiece : MonoBehaviour
	{
		public SphereVisual visual;

		public Rigidbody rb;

		public Collider col;

		public MaterialRowConfig material;

		public Color color;

		public float radius;

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
