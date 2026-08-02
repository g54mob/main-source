using UnityEngine;

namespace GRP
{
	public class SlopeVisual : MonoBehaviour
	{
		public struct Quad
		{
			public int i1;

			public int i2;

			public int i3;

			public int i4;

			public Quad(int i1, int i2, int i3, int i4)
			{
				this.i1 = 0;
				this.i2 = 0;
				this.i3 = 0;
				this.i4 = 0;
			}
		}

		public MeshFilter meshFilter;

		public MeshCollider meshCollider;

		public MeshRenderer meshRenderer;

		public SlopeVisualOptions options;

		public MaterialBlockContainer materialBlock;

		public void Setup()
		{
		}

		public static Mesh BuildMesh(SlopeVisualOptions options)
		{
			return null;
		}

		public void Build(SlopeVisualOptions options)
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
