using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public abstract class ColliderComponent3D : ColliderComponent
	{
		protected Collider collider;

		public RaycastHit[] UnfilteredHits { get; protected set; } = new RaycastHit[20];

		public List<RaycastHit> FilteredHits { get; protected set; } = new List<RaycastHit>(10);

		public Collider[] UnfilteredOverlaps { get; protected set; } = new Collider[20];

		public List<Collider> FilteredOverlaps { get; protected set; } = new List<Collider>(10);

		public PhysicsMaterial Material
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

		protected abstract int InternalOverlapBody(Vector3 position, Quaternion rotation, Collider[] unfilteredResults, List<Collider> filteredResults, OverlapFilterDelegate3D filter);

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
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < num; i++)
			{
				Collider collider = FilteredOverlaps[i];
				if (!collider.transform.IsChildOf(this.collider.transform) && !collider.isTrigger && Physics.ComputePenetration(this.collider, position, rotation, collider, collider.transform.position, collider.transform.rotation, out var direction, out var distance))
				{
					zero += direction * distance;
					Action?.Invoke(ref position, ref rotation, collider.transform, direction, distance);
				}
			}
			return zero;
		}

		protected bool InternalHitFilter(RaycastHit raycastHit)
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

		protected bool InternalOverlapFilter(Collider collider)
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

		protected int FilterValidOverlaps(int hits, Collider[] unfilteredOverlaps, List<Collider> filteredOverlaps, OverlapFilterDelegate3D Filter)
		{
			filteredOverlaps.Clear();
			for (int i = 0; i < hits; i++)
			{
				Collider item = unfilteredOverlaps[i];
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
			PhysicsMaterial physicsMaterial = new PhysicsMaterial("Frictionless 3D");
			physicsMaterial.dynamicFriction = 0f;
			physicsMaterial.staticFriction = 0f;
			physicsMaterial.frictionCombine = PhysicsMaterialCombine.Minimum;
			physicsMaterial.bounceCombine = PhysicsMaterialCombine.Minimum;
			physicsMaterial.bounciness = 0f;
			collider.sharedMaterial = physicsMaterial;
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
