using UnityEngine;

namespace GRP
{
	public class GearPiece : MonoBehaviour
	{
		public GearVisual visual;

		public Rigidbody rb;

		public MaterialRowConfig material;

		public Color color;

		public GearVisualOptions options;

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
