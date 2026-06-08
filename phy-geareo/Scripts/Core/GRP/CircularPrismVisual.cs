using UnityEngine;

namespace GRP
{
	public class CircularPrismVisual : MonoBehaviour
	{
		public MeshFilter meshFilter;

		public MeshRenderer meshRenderer;

		public MeshCollider meshCollider;

		private CircularPrismVisualOptions options;

		public MaterialBlockContainer materialBlock;

		public void Setup()
		{
		}

		public static Mesh BuildMesh(CircularPrismVisualOptions options)
		{
			return null;
		}

		public void Build(CircularPrismVisualOptions options)
		{
		}

		public void SetMaterial(MaterialRowConfig material, Color color)
		{
		}

		public void SetTiling()
		{
		}

		public void SetOffset(Id id)
		{
		}
	}
}
