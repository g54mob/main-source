using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public class SphereColliderComponent3D : ColliderComponent3D
	{
		private SphereCollider sphereCollider;

		public override Vector3 Size
		{
			get
			{
				return Vector3.one * 2f * sphereCollider.radius;
			}
			set
			{
				sphereCollider.radius = value.x / 2f;
			}
		}

		public override Vector3 BoundsSize => sphereCollider.bounds.size;

		public override Vector3 Offset
		{
			get
			{
				return sphereCollider.center;
			}
			set
			{
				sphereCollider.center = value;
			}
		}

		protected override int InternalOverlapBody(Vector3 position, Quaternion rotation, Collider[] unfilteredResults, List<Collider> filteredResults, OverlapFilterDelegate3D filter)
		{
			Vector3 position2 = position + rotation * sphereCollider.center;
			_ = rotation * Vector3.up;
			int hits = Physics.OverlapSphereNonAlloc(position2, sphereCollider.radius, unfilteredResults, -5, QueryTriggerInteraction.Ignore);
			return FilterValidOverlaps(hits, unfilteredResults, filteredResults, filter);
		}

		protected override void Awake()
		{
			sphereCollider = base.gameObject.GetOrAddComponent<SphereCollider>(includeChildren: true);
			collider = sphereCollider;
			base.Awake();
		}
	}
}
