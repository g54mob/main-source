using UnityEngine;

namespace GRP
{
	public class SizedVisual : MonoBehaviour
	{
		public Transform body;

		public SizedFace[] faces;

		private Color currentColor;

		private Vector3 currentSize;

		public Vector3 size => default(Vector3);

		public void SetSize(Vector3 size)
		{
		}

		public void SetColor(Color color)
		{
		}

		public void SetMaterial(Material material)
		{
		}
	}
}
