using UnityEngine;

namespace GRP
{
	public class ExhibitLoader : MonoBehaviour
	{
		public MeshFilter meshFilter;

		public MeshRenderer meshRenderer;

		private Exhibit exhibit;

		private MaterialPropertyBlock[] materialBlocks;

		private Color[] colors;

		public void Setup(Exhibit exhibit)
		{
		}

		public void SetAlphaMultiplier(float multiplier)
		{
		}
	}
}
