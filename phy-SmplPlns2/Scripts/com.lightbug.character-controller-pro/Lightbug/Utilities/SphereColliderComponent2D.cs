using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public class SphereColliderComponent2D : ColliderComponent2D
	{
		private CircleCollider2D circleCollider;

		public override Vector3 Size
		{
			get
			{
				return Vector2.one * 2f * circleCollider.radius;
			}
			set
			{
				circleCollider.radius = value.x / 2f;
			}
		}

		public override Vector3 BoundsSize => circleCollider.bounds.size;

		public override Vector3 Offset
		{
			get
			{
				return circleCollider.offset;
			}
			set
			{
				circleCollider.offset = value;
			}
		}

		protected override int InternalOverlapBody(Vector3 position, Quaternion rotation, Collider2D[] unfilteredResults, List<Collider2D> filteredResults, OverlapFilterDelegate2D filter)
		{
			Vector3 vector = position + rotation * circleCollider.offset;
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			Physics2D.queriesHitTriggers = false;
			ContactFilter.layerMask = -5;
			int hits = Physics2D.OverlapCircle(vector, circleCollider.radius, ContactFilter, unfilteredResults);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			return FilterValidOverlaps(hits, unfilteredResults, filteredResults, filter);
		}

		protected override void Awake()
		{
			circleCollider = base.gameObject.GetOrAddComponent<CircleCollider2D>(includeChildren: true);
			collider = circleCollider;
			base.Awake();
		}
	}
}
