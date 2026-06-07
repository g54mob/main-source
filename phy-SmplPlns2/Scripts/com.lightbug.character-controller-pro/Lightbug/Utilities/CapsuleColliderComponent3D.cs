using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public class CapsuleColliderComponent3D : ColliderComponent3D
	{
		private CapsuleCollider capsuleCollider;

		public override Vector3 Size
		{
			get
			{
				return new Vector2(2f * capsuleCollider.radius, capsuleCollider.height);
			}
			set
			{
				capsuleCollider.radius = value.x / 2f;
				capsuleCollider.height = value.y;
			}
		}

		public override Vector3 BoundsSize => capsuleCollider.bounds.size;

		public override Vector3 Offset
		{
			get
			{
				return capsuleCollider.center;
			}
			set
			{
				capsuleCollider.center = value;
			}
		}

		protected override int InternalOverlapBody(Vector3 position, Quaternion rotation, Collider[] unfilteredResults, List<Collider> filteredResults, OverlapFilterDelegate3D filter)
		{
			Vector3 vector = rotation * Vector3.up;
			Vector3 vector2 = (0.5f * capsuleCollider.height - capsuleCollider.radius) * vector;
			Vector3 vector3 = position + rotation * capsuleCollider.center;
			Vector3 point = vector3 + vector2;
			Vector3 point2 = vector3 - vector2;
			int hits = Physics.OverlapCapsuleNonAlloc(point, point2, capsuleCollider.radius, unfilteredResults, -5, QueryTriggerInteraction.Ignore);
			return FilterValidOverlaps(hits, unfilteredResults, filteredResults, filter);
		}

		protected override void Awake()
		{
			capsuleCollider = base.gameObject.GetOrAddComponent<CapsuleCollider>();
			collider = capsuleCollider;
			base.Awake();
		}
	}
}
