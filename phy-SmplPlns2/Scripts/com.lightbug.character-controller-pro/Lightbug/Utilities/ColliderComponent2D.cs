using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public abstract class ColliderComponent2D : ColliderComponent
	{
		protected Collider2D collider;

		protected ContactFilter2D ContactFilter;

		public RaycastHit2D[] UnfilteredHits { get; protected set; } = new RaycastHit2D[20];

		public List<RaycastHit2D> FilteredHits { get; protected set; } = new List<RaycastHit2D>(10);

		public Collider2D[] UnfilteredOverlaps { get; protected set; } = new Collider2D[20];

		public List<Collider2D> FilteredOverlaps { get; protected set; } = new List<Collider2D>(10);

		public PhysicsMaterial2D Material
		{
			get
			{
				return collider.sharedMaterial;
			}
			set
			{
				collider.sharedMaterial = value;
			}
		}

		protected abstract int InternalOverlapBody(Vector3 position, Quaternion rotation, Collider2D[] unfilteredResults, List<Collider2D> filteredResults, OverlapFilterDelegate2D filter);

		public sealed override int OverlapBody(Vector3 position, Quaternion rotation)
		{
			return InternalOverlapBody(position, rotation, UnfilteredOverlaps, FilteredOverlaps, null);
		}

		public override bool ComputePenetration(ref Vector3 position, ref Quaternion rotation, PenetrationDelegate Action)
		{
			return ComputePenetrationVector(ref position, ref rotation, Action) != Vector3.zero;
		}

		public override Vector3 ComputePenetrationVector(ref Vector3 position, ref Quaternion rotation, PenetrationDelegate Action)
		{
			int num = OverlapBody(position, rotation);
			if (num == 0)
			{
				return Vector3.zero;
			}
			Vector2 zero = Vector2.zero;
			for (int i = 0; i < num; i++)
			{
				Collider2D collider2D = FilteredOverlaps[i];
				if (!collider2D.transform.IsChildOf(collider.transform) && !collider2D.isTrigger)
				{
					ColliderDistance2D colliderDistance2D = Physics2D.Distance(collider, collider2D);
					if (colliderDistance2D.isOverlapped)
					{
						zero += -colliderDistance2D.normal * colliderDistance2D.distance;
						Action?.Invoke(ref position, ref rotation, collider2D.transform, -colliderDistance2D.normal, colliderDistance2D.distance);
					}
				}
			}
			return zero;
		}

		protected bool InternalHitFilter(RaycastHit2D raycastHit)
		{
			if (raycastHit.collider == collider)
			{
				return false;
			}
			if (raycastHit.collider.isTrigger)
			{
				return false;
			}
			return true;
		}

		protected bool InternalOverlapFilter(Collider2D collider)
		{
			if (collider == this.collider)
			{
				return false;
			}
			if (collider.isTrigger)
			{
				return false;
			}
			return true;
		}

		protected int FilterValidOverlaps(int hits, Collider2D[] overlapsBuffer, List<Collider2D> filteredOverlaps, OverlapFilterDelegate2D Filter)
		{
			filteredOverlaps.Clear();
			for (int i = 0; i < hits; i++)
			{
				Collider2D item = overlapsBuffer[i];
				if (Filter == null || Filter(item))
				{
					filteredOverlaps.Add(item);
				}
			}
			return filteredOverlaps.Count;
		}

		protected override void Awake()
		{
			base.Awake();
			ContactFilter = default(ContactFilter2D).NoFilter();
			ContactFilter.useLayerMask = true;
			PhysicsMaterial2D physicsMaterial2D = new PhysicsMaterial2D("Frictionless 2D");
			physicsMaterial2D.friction = 0f;
			physicsMaterial2D.bounciness = 0f;
			collider.sharedMaterial = physicsMaterial2D;
			collider.hideFlags = HideFlags.NotEditable;
		}

		protected override void OnEnable()
		{
			collider.enabled = true;
		}

		protected override void OnDisable()
		{
			collider.enabled = false;
		}
	}
}
