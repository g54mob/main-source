using System;
using DV.Utils;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	public abstract class MountHoleInteractor : GadgetInteractor
	{
		[SerializeField]
		private Transform holeInteractionTransform;

		private MountPoint mountPoint;

		protected override Predicate<RaycastHitDV> QueryPredicate => (RaycastHitDV hit) => !VRManager.IsVREnabled() || (bool)hit.collider.GetComponentInParent<Drillable>();

		protected override HighlightMode OnUpdate(GadgetBase target, bool use)
		{
			int num = -1;
			Drillable component = target.GetComponent<Drillable>();
			if (component != null)
			{
				if (VRManager.IsVREnabled())
				{
					Vector3 worldPoint = ((holeInteractionTransform != null) ? holeInteractionTransform.position : base.RaycastHit.point);
					num = component.GetMountPointAtWorldPoint(worldPoint);
				}
				else
				{
					num = component.GetMountPointUsingWorldRay(base.Ray.origin, base.Ray.direction);
				}
			}
			SetHighlightPoint((num >= 0 && OnUpdateHoles(component, num, use)) ? component.GetMountPoint(num) : null);
			return HighlightMode.None;
		}

		protected override void OnUpdateNull(bool use)
		{
			SetHighlightPoint(null);
		}

		protected abstract bool OnUpdateHoles(Drillable drillable, int holeIndex, bool use);

		private void SetHighlightPoint(MountPoint point)
		{
			if (!(mountPoint == point))
			{
				if (mountPoint != null)
				{
					mountPoint.IsHighlighted = false;
				}
				mountPoint = point;
				if (mountPoint != null)
				{
					mountPoint.IsHighlighted = true;
				}
			}
		}
	}
}
