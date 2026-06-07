using Coherence.Common;
using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Query
{
	public struct PositionQuery : IFilter
	{
		private Vector3d center;

		private float radius;

		private BoundingRect rect;

		public bool IsInfinite => false;

		public Vector3d Center => default(Vector3d);

		public float Radius => 0f;

		public BoundingRect Rect => default(BoundingRect);

		public PositionQuery(Vector3d center, float radius)
		{
			this.center = default(Vector3d);
			this.radius = 0f;
			rect = default(BoundingRect);
		}

		public bool Contains(Entity _, EntityMeta meta)
		{
			return false;
		}

		public void Update(ICoherenceComponentData comp, IExtendedDefinition root)
		{
		}
	}
}
