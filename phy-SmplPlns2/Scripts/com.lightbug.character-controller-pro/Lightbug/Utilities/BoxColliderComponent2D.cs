using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public class BoxColliderComponent2D : ColliderComponent2D
	{
		private BoxCollider2D boxCollider;

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
				return boxCollider.offset;
			}
			set
			{
				boxCollider.offset = value;
			}
		}

		protected override int InternalOverlapBody(Vector3 position, Quaternion rotation, Collider2D[] unfilteredResults, List<Collider2D> filteredResults, OverlapFilterDelegate2D filter)
		{
			_ = rotation * Vector3.up;
			Vector3 vector = position + rotation * boxCollider.offset;
			float z = rotation.eulerAngles.z;
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			Physics2D.queriesHitTriggers = false;
			ContactFilter.layerMask = -5;
			int hits = Physics2D.OverlapBox(vector, boxCollider.size, z, ContactFilter, unfilteredResults);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			return FilterValidOverlaps(hits, unfilteredResults, filteredResults, filter);
		}

		protected override void Awake()
		{
			boxCollider = base.gameObject.GetOrAddComponent<BoxCollider2D>(includeChildren: true);
			collider = boxCollider;
			base.Awake();
		}
	}
}
