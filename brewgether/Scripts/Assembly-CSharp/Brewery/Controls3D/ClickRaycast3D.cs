using UnityEngine;

namespace Brewery.Controls3D
{
	public static class ClickRaycast3D
	{
		private const float MaxDistance = 100f;

		private static readonly int LayerMaskUI3D;

		private static int cachedFrame;

		private static bool wasPressed;

		private static bool wasReleased;

		private static bool didHit;

		private static RaycastHit cachedHit;

		public static Collider HoveredCollider => null;

		public static bool WasPressed => false;

		public static bool WasReleased => false;

		public static bool TryGetHitCollider(out Collider hitCollider)
		{
			hitCollider = null;
			return false;
		}

		private static void EnsureCached()
		{
		}
	}
}
