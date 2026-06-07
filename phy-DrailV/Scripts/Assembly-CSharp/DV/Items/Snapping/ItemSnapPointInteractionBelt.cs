using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.CabControls.VRTK;
using DV.InventorySystem;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.Items.Snapping
{
	public class ItemSnapPointInteractionBelt : MonoBehaviour
	{
		private ControllerPointerDetectorBelt controllerPointerDetector;

		private VRTK_InteractGrab_DV grabRight;

		private VRTK_InteractGrab_DV grabLeft;

		private ItemSnapPointBelt snapPoint;

		private ItemBeltVR itemBeltVR;

		private SphereCollider proximityCheckSphere;

		private HashSet<Transform> nearbyFreePipas = new HashSet<Transform>();

		private bool snappableGrabbedRight;

		private bool snappableGrabbedLeft;

		private bool snappableGrabbedRightNearby;

		private bool snappableGrabbedLeftNearby;

		private bool adjusterGrabbedRight;

		private bool adjusterGrabbedLeft;

		private bool adjusterGrabbedRightNearby;

		private bool adjusterGrabbedLeftNearby;

		private GameObject grabbedRight;

		private GameObject grabbedLeft;

		private ItemBase itemsToForceSnap;

		private bool initialized;

		private Coroutine ungrabSafetyCoroutine;

		public bool NearbyFreePipa => nearbyFreePipas.Count > 0;

		public bool NearbySnappable
		{
			get
			{
				if (!snappableGrabbedRightNearby)
				{
					return snappableGrabbedLeftNearby;
				}
				return true;
			}
		}

		public bool NearbyGrabbedAdjuster
		{
			get
			{
				if (!adjusterGrabbedRightNearby)
				{
					return adjusterGrabbedLeftNearby;
				}
				return true;
			}
		}

		private void OnEnable()
		{
			if (initialized)
			{
				nearbyFreePipas.Clear();
				if (grabRight != null)
				{
					GameObject grabbedObject = grabRight.GetGrabbedObject();
					bool grabbed = grabbedObject != null;
					UpdateGrabDependentStates(SDK_BaseController.ControllerHand.Right, grabbedObject, grabbed);
				}
				if (grabLeft != null)
				{
					GameObject grabbedObject2 = grabLeft.GetGrabbedObject();
					bool grabbed2 = grabbedObject2 != null;
					UpdateGrabDependentStates(SDK_BaseController.ControllerHand.Left, grabbedObject2, grabbed2);
				}
			}
		}

		public void Initialize(ItemBeltVR itemBeltVR)
		{
			if (!initialized)
			{
				if (!itemBeltVR)
				{
					Debug.LogError("itemBeltVR not found! It is necessary for ItemSnapPointInteractionBelt to function!", base.gameObject);
				}
				proximityCheckSphere = GetComponent<SphereCollider>();
				snapPoint = GetComponent<ItemSnapPointBelt>();
				controllerPointerDetector = GetComponentInChildren<ControllerPointerDetectorBelt>();
				if (SetupDeviceSpecificControls.AreControlsSetRight)
				{
					grabRight = VRTK_DeviceFinder.GetControllerRightHand().GetComponent<VRTK_InteractGrab_DV>();
				}
				if (SetupDeviceSpecificControls.AreControlsSetLeft)
				{
					grabLeft = VRTK_DeviceFinder.GetControllerLeftHand().GetComponent<VRTK_InteractGrab_DV>();
				}
				if (!SetupDeviceSpecificControls.AreControlsSetLeft || !SetupDeviceSpecificControls.AreControlsSetRight)
				{
					SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
				}
				this.itemBeltVR = itemBeltVR;
				SetupListeners(on: true);
				initialized = true;
			}
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand hand)
		{
			if (hand == SDK_BaseController.ControllerHand.Right)
			{
				if (grabRight != null)
				{
					return;
				}
				grabRight = VRTK_DeviceFinder.GetControllerRightHand().GetComponent<VRTK_InteractGrab_DV>();
				SetupListeners(on: true);
			}
			else
			{
				if (grabLeft != null)
				{
					return;
				}
				grabLeft = VRTK_DeviceFinder.GetControllerLeftHand().GetComponent<VRTK_InteractGrab_DV>();
				SetupListeners(on: true);
			}
			if (SetupDeviceSpecificControls.AreControlsSetLeft && SetupDeviceSpecificControls.AreControlsSetRight)
			{
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			}
		}

		private void OnDestroy()
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
				if (ungrabSafetyCoroutine != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(ungrabSafetyCoroutine);
				}
			}
		}

		private void SetupListeners(bool on)
		{
			if (grabRight != null)
			{
				grabRight.GrabButtonPressed -= OnGrabPressed;
				grabRight.ControllerUngrabInteractableObject -= OnUngrabbed;
				grabRight.ControllerGrabInteractableObject -= OnGrabbed;
			}
			if (grabLeft != null)
			{
				grabLeft.GrabButtonPressed -= OnGrabPressed;
				grabLeft.ControllerUngrabInteractableObject -= OnUngrabbed;
				grabLeft.ControllerGrabInteractableObject -= OnGrabbed;
			}
			if (snapPoint != null)
			{
				snapPoint.ItemSnappedChanged -= OnItemSnappedChanged;
			}
			if ((bool)itemBeltVR)
			{
				itemBeltVR.ForceSnapOnUngrabRequested -= OnForceSnapOnUngrabRequested;
				itemBeltVR.ForceSnapOnUngrabRequestCanceled -= OnForceSnapOnUngrabRequestCanceled;
			}
			if (on)
			{
				if (grabRight != null)
				{
					grabRight.GrabButtonPressed += OnGrabPressed;
					grabRight.ControllerUngrabInteractableObject += OnUngrabbed;
					grabRight.ControllerGrabInteractableObject += OnGrabbed;
				}
				if (grabLeft != null)
				{
					grabLeft.GrabButtonPressed += OnGrabPressed;
					grabLeft.ControllerUngrabInteractableObject += OnUngrabbed;
					grabLeft.ControllerGrabInteractableObject += OnGrabbed;
				}
				if (snapPoint != null)
				{
					snapPoint.ItemSnappedChanged += OnItemSnappedChanged;
				}
				if ((bool)itemBeltVR)
				{
					itemBeltVR.ForceSnapOnUngrabRequested += OnForceSnapOnUngrabRequested;
					itemBeltVR.ForceSnapOnUngrabRequestCanceled += OnForceSnapOnUngrabRequestCanceled;
				}
			}
		}

		private void OnForceSnapOnUngrabRequestCanceled(ItemSnapPointBase snapPoint)
		{
			if (!(this.snapPoint != snapPoint))
			{
				itemsToForceSnap = null;
			}
		}

		private void OnForceSnapOnUngrabRequested(ItemSnapPointBase snapPoint, ItemBase item)
		{
			if (!(this.snapPoint != snapPoint))
			{
				itemsToForceSnap = item;
			}
		}

		private void OnGrabbed(object sender, ObjectInteractEventArgs e)
		{
			if (base.enabled)
			{
				UpdateGrabDependentStates(e.controllerReference.hand, e.target, grabbed: true);
			}
		}

		private void UpdateGrabDependentStates(SDK_BaseController.ControllerHand hand, GameObject obj, bool grabbed)
		{
			bool flag = hand == SDK_BaseController.ControllerHand.Right;
			Transform transform = PipaUtils.PipaTransform(hand);
			if (grabbed)
			{
				ItemBase itemBase = ((obj != null) ? obj.GetComponent<ItemBase>() : null);
				bool flag2 = itemBase != null && itemBase.IsBeltSnappable;
				bool flag3 = !flag2 && obj.GetComponent<BeltSnapPointAdjuster>() != null;
				bool flag4 = UpdatePipaCollection(transform, add: false);
				if (flag)
				{
					grabbedRight = obj;
					snappableGrabbedRight = flag2;
					snappableGrabbedRightNearby = flag2 && flag4;
					adjusterGrabbedRight = flag3;
					adjusterGrabbedRightNearby = flag3 && flag4;
				}
				else
				{
					grabbedLeft = obj;
					snappableGrabbedLeft = flag2;
					snappableGrabbedLeftNearby = flag2 && flag4;
					adjusterGrabbedLeft = flag3;
					adjusterGrabbedLeftNearby = flag3 && flag4;
				}
			}
			else
			{
				if (flag)
				{
					grabbedRight = null;
					snappableGrabbedRight = (snappableGrabbedRightNearby = false);
					adjusterGrabbedRight = (adjusterGrabbedRightNearby = false);
				}
				else
				{
					grabbedLeft = null;
					snappableGrabbedLeft = (snappableGrabbedLeftNearby = false);
					adjusterGrabbedLeft = (adjusterGrabbedLeftNearby = false);
				}
				float radius = proximityCheckSphere.radius;
				if ((transform.position - snapPoint.transform.position).sqrMagnitude <= radius * radius)
				{
					UpdatePipaCollection(transform, add: true);
				}
			}
		}

		public bool ValidSnapObjectHover()
		{
			if (!snapPoint.snapAllowed || !(snapPoint.SnappedItem == null))
			{
				return false;
			}
			if (snappableGrabbedRightNearby && controllerPointerDetector.IsProperlyTouched(isRight: true))
			{
				return true;
			}
			if (snappableGrabbedLeftNearby)
			{
				return controllerPointerDetector.IsProperlyTouched(isRight: false);
			}
			return false;
		}

		public bool ValidPipaHover()
		{
			if (snapPoint.SnappedItem == null)
			{
				return false;
			}
			if (!controllerPointerDetector.IsProperlyTouched(isRight: true))
			{
				return controllerPointerDetector.IsProperlyTouched(isRight: false);
			}
			return true;
		}

		private void OnItemSnappedChanged(ItemSnapPointBase _, ItemBase __, bool snapped, bool ___)
		{
			if (!(controllerPointerDetector == null))
			{
				controllerPointerDetector.occupied = snapped;
			}
		}

		private void OnUngrabbed(object _, ObjectInteractEventArgs e)
		{
			if (!base.enabled && itemsToForceSnap == null)
			{
				return;
			}
			ItemBase itemBase = ((e.target != null) ? e.target.GetComponent<ItemBase>() : null);
			if (itemBase == null)
			{
				UpdateGrabDependentStates(e.controllerReference.hand, e.target, grabbed: false);
			}
			else if (itemsToForceSnap != null)
			{
				if (itemsToForceSnap != itemBase)
				{
					Debug.LogError("Item to force snap is not the same as the grabbed item. " + itemsToForceSnap.name + " != " + itemBase.name);
				}
				ForceSnapRequestUngrabBehavior();
			}
			else
			{
				if (ungrabSafetyCoroutine != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(ungrabSafetyCoroutine);
				}
				ungrabSafetyCoroutine = SingletonBehaviour<CoroutineManager>.Instance.Run(OnUngrabDelayed(e, itemBase));
			}
		}

		private IEnumerator OnUngrabDelayed(ObjectInteractEventArgs ungrabEventArgs, ItemBase item)
		{
			yield return WaitFor.EndOfFrame;
			if (item != null && !item.IsGrabbed())
			{
				RegularUngrabBehavior(ungrabEventArgs, item);
			}
			ungrabSafetyCoroutine = null;
		}

		private void ForceSnapRequestUngrabBehavior()
		{
			snapPoint.SnapItem(itemsToForceSnap, itemsToForceSnap);
			itemsToForceSnap = null;
		}

		private void RegularUngrabBehavior(ObjectInteractEventArgs ungrabEventArgs, ItemBase item)
		{
			SDK_BaseController.ControllerHand hand = ungrabEventArgs.controllerReference.hand;
			bool flag = hand == SDK_BaseController.ControllerHand.Right;
			bool flag2 = (flag ? snappableGrabbedRightNearby : snappableGrabbedLeftNearby);
			UpdateGrabDependentStates(ungrabEventArgs.controllerReference.hand, ungrabEventArgs.target, grabbed: false);
			if (!(snapPoint.SnappedItem != null) && flag2 && controllerPointerDetector.IsProperlyTouched(flag) && !InventoryViewVR.Instance.IsInteracting(hand))
			{
				int num = itemBeltVR.InventoryIndexFromBeltSlot(snapPoint);
				int num2 = SingletonBehaviour<Inventory>.Instance.AddItemToInventory(item.gameObject, num);
				if ((num2 == -1 || !SingletonBehaviour<Inventory>.Instance.GetSlotLockState(num2)) && num != num2)
				{
					SingletonBehaviour<Inventory>.Instance.MoveItemFromTo(num2, num);
				}
			}
		}

		private void OnGrabPressed(object sender, ControllerInteractionEventArgs e)
		{
			if (!base.enabled || snapPoint.SnappedItem == null)
			{
				return;
			}
			bool flag = e.controllerReference.hand == SDK_BaseController.ControllerHand.Right;
			if (controllerPointerDetector.IsProperlyTouched(flag) && !((flag ? grabRight : grabLeft).GetGrabbedObject() != null))
			{
				GameObject item = ((snapPoint.SnappedItem != null) ? snapPoint.SnappedItem.gameObject : null);
				int desiredEquipSlot = (flag ? 1 : 0);
				if (SingletonBehaviour<Inventory>.Instance.EquipItem(item, desiredEquipSlot) >= 0)
				{
					itemBeltVR.FireItemEquippedEvent(flag);
				}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			ReliableOnTriggerExit.NotifyTriggerEnter(other, base.gameObject, OnTriggerExit);
			Transform transform = other.transform;
			if (!PipaUtils.IsPipa(transform))
			{
				return;
			}
			bool num = PipaUtils.GetPipaHand(transform) == PipaUtils.PipaHand.Right;
			bool add = false;
			if (num)
			{
				if (grabbedRight == null)
				{
					add = true;
				}
				else if (snappableGrabbedRight)
				{
					snappableGrabbedRightNearby = true;
				}
				else if (adjusterGrabbedRight)
				{
					adjusterGrabbedRightNearby = true;
				}
			}
			else if (grabbedLeft == null)
			{
				add = true;
			}
			else if (snappableGrabbedLeft)
			{
				snappableGrabbedLeftNearby = true;
			}
			else if (adjusterGrabbedLeft)
			{
				adjusterGrabbedLeftNearby = true;
			}
			UpdatePipaCollection(other.transform, add);
		}

		private void OnTriggerExit(Collider other)
		{
			ReliableOnTriggerExit.NotifyTriggerExit(other, base.gameObject);
			if (PipaUtils.IsPipa(other.transform))
			{
				if (PipaUtils.GetPipaHand(other.transform) == PipaUtils.PipaHand.Right)
				{
					snappableGrabbedRightNearby = false;
					adjusterGrabbedRightNearby = false;
				}
				else
				{
					snappableGrabbedLeftNearby = false;
					adjusterGrabbedLeftNearby = false;
				}
				UpdatePipaCollection(other.transform, add: false);
			}
		}

		private bool UpdatePipaCollection(Transform pipa, bool add)
		{
			if (!add)
			{
				return nearbyFreePipas.Remove(pipa);
			}
			return nearbyFreePipas.Add(pipa);
		}
	}
}
