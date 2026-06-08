using UnityEngine;

namespace GRP
{
	public class BoxPiece : MonoBehaviour
	{
		public BoxVisual visual;

		public Rigidbody rb;

		public Collider col;

		public MaterialRowConfig material;

		public Color color;

		public Vector3 size;

		private void Awake()
		{
		}

		public void Build()
		{
		}

		private void OnValidate()
		{
		}

		private void OnDidApplyAnimationProperties()
		{
		}
	}
}
