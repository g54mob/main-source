using UnityEngine;

namespace Shapes
{
	internal struct ShapeDrawState
	{
		public Mesh mesh;

		public Material mat;

		public int submesh;

		internal bool CompatibleWith(ShapeDrawState other)
		{
			if (mesh == other.mesh && submesh == other.submesh)
			{
				return mat == other.mat;
			}
			return false;
		}
	}
}
