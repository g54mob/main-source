using UnityEngine;

namespace GRP
{
	public class LinearGearPiece : MonoBehaviour
	{
		public LinearGearVisual visual;

		public Rigidbody rb;

		public MaterialRowConfig material;

		public Color color;

		public LinearGearVisualOptions options;

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
