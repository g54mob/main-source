using System.Collections;
using DV.InventorySystem;
using UnityEngine;

namespace DV.CabControls
{
	[DisallowMultipleComponent]
	public abstract class ItemReparentingBase : MonoBehaviour
	{
		public delegate void ItemParentedDelegate(Transform parentedTo);

		protected ItemBase item;

		protected Coroutine reparentingCoroutine;

		private bool delayedParentCached;

		private Transform cachedDelayedParent;

		private Rigidbody cachedDelayedReceiveForcesFrom;

		private TrainPhysicsLod currentCarPhysicsLod;

		private bool justUngrabbed;

		public Transform CurrentParent { get; private set; }

		public event ItemParentedDelegate ItemParented;

		protected virtual void Awake()
		{
			item = GetComponent<ItemBase>();
			if (item == null)
			{
				Debug.LogError("ItemReparentingBase couldn't find item", base.gameObject);
			}
			if (item != null)
			{
				item.ItemInventoryStateChanged += OnItemInventoryStateChanged;
			}
		}

		protected abstract void SetupListeners(bool on);

		protected abstract void OverrideState(Transform newParent);

		protected abstract bool ShouldUseDelayed();

		protected abstract IEnumerator HeldItemDynamicReparentingCoro();

		private void OnEnable()
		{
			SetupListeners(on: true);
			StartReparentingGrabbedItemToPlayersParentCoroutine();
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && !(currentCarPhysicsLod == null))
			{
				item.ItemInventoryStateChanged -= OnItemInventoryStateChanged;
				currentCarPhysicsLod.RemoveItem(item);
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (item.IsGrabbed() || item.IsInBelt())
			{
				return;
			}
			TrainCar trainCar = TrainCar.Resolve(collision.transform);
			if (trainCar != null)
			{
				Transform interior = trainCar.interior;
				if (base.transform.parent != interior || justUngrabbed)
				{
					ParentItem(interior.transform, trainCar.rb);
					justUngrabbed = false;
				}
				return;
			}
			ItemStaticParent componentInParent = collision.transform.GetComponentInParent<ItemStaticParent>();
			Transform transform = ((!(componentInParent != null) || !componentInParent.ValidParentFor(item)) ? WorldMover.OriginShiftParent : componentInParent.transform);
			if (base.transform.parent != transform || justUngrabbed)
			{
				ParentItem(transform, null, componentInParent);
				justUngrabbed = false;
			}
		}

		protected void OnGrab(ControlImplBase _)
		{
			justUngrabbed = false;
			RemoveFromTrainPhysicsLod();
			delayedParentCached = false;
			ParentItem(CurrentParent, item.CabItem.ReceiveForcesFrom);
			StartReparentingGrabbedItemToPlayersParentCoroutine();
		}

		private void StartReparentingGrabbedItemToPlayersParentCoroutine()
		{
			if (reparentingCoroutine != null)
			{
				StopCoroutine(reparentingCoroutine);
				reparentingCoroutine = null;
			}
			if (item.IsGrabbed())
			{
				reparentingCoroutine = StartCoroutine(HeldItemDynamicReparentingCoro());
			}
		}

		protected void OnUngrab(ControlImplBase _)
		{
			justUngrabbed = true;
			if (reparentingCoroutine != null)
			{
				StopCoroutine(reparentingCoroutine);
				reparentingCoroutine = null;
			}
			if (delayedParentCached)
			{
				delayedParentCached = false;
				ParentItem(cachedDelayedParent, cachedDelayedReceiveForcesFrom);
			}
		}

		protected void ParentItem(Transform newParent, Rigidbody receiveForcesFrom = null, ItemStaticParent itemStaticParent = null)
		{
			RemoveFromTrainPhysicsLod();
			if (item.IsGrabbed())
			{
				OverrideState(newParent);
			}
			base.transform.SetParent(newParent);
			base.transform.SetSiblingIndex(999);
			CurrentParent = newParent;
			CabItemRigidbody component = GetComponent<CabItemRigidbody>();
			if ((bool)component)
			{
				component.SetupTrainReceivingForces(receiveForcesFrom);
			}
			AddToTrainPhysicsLod();
			if (itemStaticParent != null)
			{
				itemStaticParent.ItemParented(item, this);
			}
			this.ItemParented?.Invoke(newParent);
		}

		private void RemoveFromTrainPhysicsLod()
		{
			if (currentCarPhysicsLod != null)
			{
				currentCarPhysicsLod.RemoveItem(item);
			}
		}

		private void AddToTrainPhysicsLod()
		{
			if (!item.IsBoundToPlayer() && !(item.InContainer != null))
			{
				currentCarPhysicsLod = TrainCar.Resolve(CurrentParent)?.GetComponent<TrainPhysicsLod>();
				if (currentCarPhysicsLod != null)
				{
					currentCarPhysicsLod.AddItem(item);
				}
			}
		}

		protected void TryToReparentGrabbedItem(Transform newParent, Rigidbody newReceiveForcesFrom)
		{
			if (ShouldUseDelayed())
			{
				CacheParentForDelayedReparent(newParent, newReceiveForcesFrom);
			}
			else
			{
				ParentItem(newParent, newReceiveForcesFrom);
			}
		}

		protected void CacheParentForDelayedReparent(Transform newParentToCache, Rigidbody receiveForcesFrom)
		{
			delayedParentCached = true;
			OverrideState(newParentToCache);
			cachedDelayedParent = newParentToCache;
			cachedDelayedReceiveForcesFrom = receiveForcesFrom;
		}

		public void ParentItemExternal(Transform desiredParent, Rigidbody receiveForcesFrom, ItemStaticParent itemStaticParent = null)
		{
			ParentItem(desiredParent, receiveForcesFrom, itemStaticParent);
		}

		protected void OnItemInventoryStateChanged(ItemBase itemBase, InventoryActionType actionType, InventoryItemState itemState)
		{
			if (actionType.HasAnyFlag(InventoryActionType.Drop) && !actionType.HasAnyFlag(InventoryActionType.Unequip))
			{
				TrainCar car = PlayerManager.Car;
				Transform newParent = ((car != null) ? car.interior : WorldMover.OriginShiftParent);
				Rigidbody receiveForcesFrom = ((car != null) ? car.rb : null);
				ParentItem(newParent, receiveForcesFrom);
			}
		}
	}
}
