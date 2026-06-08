using UnityEngine;

namespace GRP
{
	public class SizedFace : MonoBehaviour
	{
		public SizedFacePlane plane;

		public bool roundX;

		public bool roundY;

		public bool roundZ;

		public Vector3 tiling;

		public Renderer[] renderers;

		private float gX(float v)
		{
			return 0f;
		}

		private float gY(float v)
		{
			return 0f;
		}

		private float gZ(float v)
		{
			return 0f;
		}

		public void SetSize(Vector3 f)
		{
		}

		public void SetColor(Color color)
		{
		}

		public void SetMaterial(Material mat)
		{
		}
	}
}
