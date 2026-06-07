using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public class CapsuleColliderComponent2D : ColliderComponent2D
	{
		private CapsuleCollider2D capsuleCollider;

		public override Vector3 Size
		{
			get
			{
				return capsuleCollider.size;
			}
			set
			{
				capsuleCollider.size = value;
			}
		}

		public override Vector3 BoundsSize => capsuleCollider.bounds.size;

		public override Vector3 Offset
		{
			get
			{
				return capsuleCollider.offset;
			}
			set
			{
				capsuleCollider.offset = value;
			}
		}

		protected override int InternalOverlapBody(Vector3 position, Quaternion rotation, Collider2D[] unfilteredResults, List<Collider2D> filteredResults, OverlapFilterDelegate2D filter)
		{
			_ = rotation * Vector3.up;
			Vector3 vector = position + rotation * capsuleCollider.offset;
			float z = rotation.eulerAngles.z;
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			Physics2D.queriesHitTriggers = false;
			ContactFilter.layerMask = -5;
			int hits = Physics2D.OverlapCapsule(vector, capsuleCollider.size, CapsuleDirection2D.Vertical, z, ContactFilter, unfilteredResults);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			return FilterValidOverlaps(hits, unfilteredResults, filteredResults, filter);
		}

		protected override void Awake()
		{
			capsuleCollider = base.gameObject.GetOrAddComponent<CapsuleCollider2D>();
			collider = capsuleCollider;
			base.Awake();
		}
	}
}
