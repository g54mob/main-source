using Coherence.Common;

namespace Coherence.RSL.EntityManager.Query
{
	public struct BoundingRect
	{
		public Vector3d BottomLeft;

		public Vector3d TopRight;

		public bool IsInfinite;

		public BoundingRect(Vector3d center, float radius)
		{
			BottomLeft = default(Vector3d);
			TopRight = default(Vector3d);
			IsInfinite = false;
		}

		public bool Contains(Vector3d point)
		{
			return false;
		}
	}
}
