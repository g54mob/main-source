using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public class BoxColliderComponent3D : ColliderComponent3D
	{
		private BoxCollider boxCollider;

		public override Vector3 Size
		{
			get
			{
				return boxCollider.size;
			}
			set
			{
				boxCollider.size = value;
			}
		}

		public override Vector3 BoundsSize => boxCollider.bounds.size;

		public override Vector3 Offset
		{
			get
			{
				return boxCollider.center;
			}
			set
			{
				boxCollider.center = value;
			}
		}

		protected override int InternalOverlapBody(Vector3 position, Quaternion rotation, Collider[] unfilteredResults, List<Collider> filteredResults, OverlapFilterDelegate3D filter)
		{
			Vector3 center = position + rotation * boxCollider.center;
			Vector3 halfExtents = boxCollider.size * 0.5f;
			int hits = Physics.OverlapBoxNonAlloc(center, halfExtents, unfilteredResults, rotation, -5, QueryTriggerInteraction.Ignore);
			return FilterValidOverlaps(hits, unfilteredResults, filteredResults, filter);
		}

		protected override void Awake()
		{
			boxCollider = base.gameObject.GetOrAddComponent<BoxCollider>(includeChildren: true);
			collider = boxCollider;
			base.Awake();
		}
	}
}
