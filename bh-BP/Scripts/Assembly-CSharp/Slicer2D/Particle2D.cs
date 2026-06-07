using UnityEngine;

namespace Slicer2D
{
	public class Particle2D
	{
		private float speed;

		private float rotation;

		public VirtualTransform transform;

		private static Material material;

		private static Mesh mesh;

		private static Vector2D vec2D;

		public void Draw()
		{
		}

		public bool Update()
		{
			return false;
		}

		public static Particle2D Create(float rotation, Vector3 position)
		{
			return null;
		}

		public static Material GetMaterial()
		{
			return null;
		}

		public static Mesh GetMesh()
		{
			return null;
		}
	}
}
