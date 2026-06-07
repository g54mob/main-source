using System.Collections;
using DV.CabControls.Spec;
using UnityEngine;
using VRTK;

namespace DV.CabControls.VRTK
{
	public class ItemReparentingVRTK : ItemReparentingBase
	{
		private VRTK_InteractableObject interactable;

		private Item spec;

		protected override void Awake()
		{
			interactable = base.gameObject.GetComponent<VRTK_InteractableObject>();
			spec = GetComponent<Item>();
			base.Awake();
		}

		protected override void SetupListeners(bool set)
		{
			if (set)
			{
				interactable.InteractableObjectGrabbed += OnGrab;
				interactable.InteractableObjectUngrabbed += OnUngrab;
			}
			else
			{
				interactable.InteractableObjectGrabbed -= OnGrab;
				interactable.InteractableObjectUngrabbed -= OnUngrab;
			}
		}

		private void OnGrab(object _, InteractableObjectEventArgs __)
		{
			OnGrab(null);
		}

		private void OnUngrab(object _, InteractableObjectEventArgs __)
		{
			if (!ShouldUseDelayed())
			{
				TrainCar car = PlayerManager.Car;
				if (car != null)
				{
					ParentItem(car.interior, car.rb);
				}
				else
				{
					ParentItem(WorldMover.OriginShiftParent);
				}
			}
			OnUngrab(null);
		}

		protected override void OverrideState(Transform newParent)
		{
			interactable.GetPreviousState(out var _, out var previousKinematic, out var previousGrabbable);
			interactable.OverridePreviousState(newParent, previousKinematic, previousGrabbable);
		}

		protected override bool ShouldUseDelayed()
		{
			return spec.controllerAttachMethod == ItemControllerAttachMethod.ReparentToController;
		}

		protected override IEnumerator HeldItemDynamicReparentingCoro()
		{
			bool earlyExit = false;
			while (true)
			{
				Transform transform;
				Rigidbody newReceiveForcesFrom;
				if (ShouldUseDelayed())
				{
					TrainCar car = PlayerManager.Car;
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
				}
				else
				{
					transform = VRTK_DeviceFinder.PlayAreaTransform();
					newReceiveForcesFrom = null;
					earlyExit = true;
				}
				if (base.transform.parent != transform)
				{
					TryToReparentGrabbedItem(transform, newReceiveForcesFrom);
				}
				if (earlyExit)
				{
					break;
				}
				yield return null;
			}
			reparentingCoroutine = null;
		}
	}
}
