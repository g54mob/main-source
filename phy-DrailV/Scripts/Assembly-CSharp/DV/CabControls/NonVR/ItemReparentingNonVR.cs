using System.Collections;
using UnityEngine;

namespace DV.CabControls.NonVR
{
	public class ItemReparentingNonVR : ItemReparentingBase
	{
		protected override void OverrideState(Transform newParent)
		{
		}

		protected override void SetupListeners(bool on)
		{
			if (on)
			{
				item.Grabbed += base.OnGrab;
				item.Ungrabbed += base.OnUngrab;
			}
			else
			{
				item.Grabbed -= base.OnGrab;
				item.Ungrabbed -= base.OnUngrab;
			}
		}

		protected override bool ShouldUseDelayed()
		{
			return true;
		}

		protected override IEnumerator HeldItemDynamicReparentingCoro()
		{
			while (true)
			{
				TrainCar car = PlayerManager.Car;
				Transform transform;
				Rigidbody newReceiveForcesFrom;
				if (car != null)
				{
					transform = car.interior;
					newReceiveForcesFrom = car.rb;
				}
				else
				{
					transform = WorldMover.OriginShiftParent;
					newReceiveForcesFrom = null;
				}
				if (base.transform.parent != transform)
				{
					TryToReparentGrabbedItem(transform, newReceiveForcesFrom);
				}
				yield return null;
			}
		}
	}
}
