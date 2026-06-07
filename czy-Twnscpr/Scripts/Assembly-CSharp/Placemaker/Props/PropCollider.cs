using UnityEngine;

namespace Placemaker.Props
{
	public class PropCollider : MonoBehaviour
	{
		public enum Layer : byte
		{
			Object = 0,
			Door = 1,
			Path = 2,
			Anchor = 3,
			InWall = 4,
			Step = 5,
			Unclear6 = 6,
			Self = 7
		}

		public Layer layer;

		public Bounds localBounds;

		public Bounds worldBounds;

		public static bool Collides(Layer layer0, Layer layer1)
		{
			return false;
		}

		public Matrix4x4 GetMatrix()
		{
			return default(Matrix4x4);
		}

		public void CalculateWorldBounds()
		{
		}
	}
}
