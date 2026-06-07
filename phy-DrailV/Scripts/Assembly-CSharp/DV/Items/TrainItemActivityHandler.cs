using System;
using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.InventorySystem;
using DV.Items.Snapping;
using DV.Utils;
using UnityEngine;

namespace DV.Items
{
	public class TrainItemActivityHandler
	{
		private const int MAXIMUM_REGISTER_LOD_FOR_NON_KINEMATIC_STATE = 0;

		private const int MAXIMUM_STANDARD_LOD_FOR_NON_KINEMATIC_STATE = -1;

		private const int MAXIMUM_LOD_FOR_ACTIVE_STATE = 0;

		private HashSet<ItemBase> registeredItems;

		private bool itemsActivated;

		private bool itemsKinematic;

		private TrainPhysicsLod trainPhysicsLod;

		private bool itemRegistryChanged;

		private bool isVR;

		private TrainCar car;

		private TrainItemBoundingBox itemBoundingBox;

		private Collider[] overlapCache = new Collider[32];

		private HashSet<ItemBase> itemsWithinCarBoundingBox = new HashSet<ItemBase>();

		private Dictionary<ItemBase, TrainItemActivityHandlerOverride> activityOverrides = new Dictionary<ItemBase, TrainItemActivityHandlerOverride>();

		private List<ItemSnapPointCoupler> couplerSnapPoints = new List<ItemSnapPointCoupler>();

		private LayerMask itemMask;

		private Coroutine toggleCoro;

		public bool HasRegisteredItems
		{
			get
			{
				if (registeredItems != null)
				{
					return registeredItems.Count > 0;
				}
				return false;
			}
		}

		public TrainItemActivityHandler(TrainPhysicsLod trainPhysicsLod, TrainCar car, TrainCarColliders colliders)
		{
			this.trainPhysicsLod = trainPhysicsLod;
			if (trainPhysicsLod == null)
			{
				throw new ArgumentException("TrainItemActivityHandler requires a valid TrainPhysicsLod reference");
			}
			this.car = car;
			Coupler[] couplers = car.couplers;
			foreach (Coupler coupler in couplers)
			{
				ItemSnapPointCoupler itemSnapPointCoupler = ((coupler.visualCoupler != null) ? coupler.visualCoupler.couplerSnapPoint : null);
				if (!(itemSnapPointCoupler == null))
				{
					couplerSnapPoints.Add(itemSnapPointCoupler);
					itemSnapPointCoupler.ItemSnappedChanged += OnItemSnappedChanged;
				}
			}
			itemBoundingBox = car.gameObject.AddComponent<TrainItemBoundingBox>();
			itemBoundingBox.OnCreated(car, colliders);
			registeredItems = new HashSet<ItemBase>();
			itemRegistryChanged = false;
			isVR = VRManager.IsVREnabled();
			itemMask = LayerMask.GetMask("World_Item");
			trainPhysicsLod.TrainPhysicsLodChanged += OnTrainPhysicsLodChanged;
			car.OnDerailed += OnCarDerailed;
		}

		private void OnCarDerailed(TrainCar _)
		{
			foreach (ItemBase registeredItem in registeredItems)
			{
				if (!(registeredItem == null) && !registeredItem.IsSnapped)
				{
					RespawnOnDrop component = registeredItem.GetComponent<RespawnOnDrop>();
					if (!(component == null))
					{
						component.ResetToOriginalSpawnVariables();
					}
				}
			}
		}

		private void OnItemSnappedChanged(ItemSnapPointBase snapPoint, ItemBase item, bool snapped, bool forced)
		{
			if (!snapped)
			{
				Unregister(item);
			}
		}

		public void Register(ItemBase item)
		{
			if (item == null)
			{
				Debug.LogError("Trying to register a null item to TrainItemActivityHandler. Aborting.");
			}
			else if (registeredItems.Add(item))
			{
				int currentLod = trainPhysicsLod.CurrentLod;
				bool flag = currentLod <= 0;
				TrainItemActivityHandlerOverride component = item.GetComponent<TrainItemActivityHandlerOverride>();
				if (component != null)
				{
					activityOverrides.Add(item, component);
					flag = currentLod <= component.ActivityThreshold;
					component.Fire_AboutToChangeActiveStatus(flag);
				}
				if (currentLod > 0 && !item.IsSnapped)
				{
					item.ItemRigidbody.isKinematic = true;
				}
				GameObject gameObject = item.gameObject;
				if (gameObject.activeSelf != flag)
				{
					gameObject.SetActive(flag);
				}
				item.AboutToBeDestroyed += OnItemAboutToBeDestroyed;
				item.ItemInventoryStateChanged += OnItemInventoryStateChanged;
				item.ForceRemovedFromActivityHandler += Unregister;
				item.ItemInContainerStateChanged += OnItemInContainerStateChanged;
				itemRegistryChanged = true;
			}
		}

		private void OnItemInContainerStateChanged(ItemBase item, AItemContainer _, AItemContainer __, bool added)
		{
			if (added)
			{
				Unregister(item);
			}
		}

		public void Unregister(ItemBase item)
		{
			if (item == null)
			{
				Debug.LogError("Trying to unregister a null item from TrainItemActivityHandler. Aborting.");
			}
			else if (registeredItems.Remove(item))
			{
				if (!item.IsBoundToPlayer() && !item.IsSnapped)
				{
					item.ItemRigidbody.isKinematic = false;
				}
				TrainItemActivityHandlerOverride component = item.GetComponent<TrainItemActivityHandlerOverride>();
				if (component != null)
				{
					activityOverrides.Remove(item);
					component.Fire_AboutToChangeActiveStatus(active: true);
				}
				item.AboutToBeDestroyed -= OnItemAboutToBeDestroyed;
				item.ItemInventoryStateChanged -= OnItemInventoryStateChanged;
				item.ForceRemovedFromActivityHandler -= Unregister;
				item.ItemInContainerStateChanged -= OnItemInContainerStateChanged;
				itemRegistryChanged = true;
			}
		}

		private void OnItemInventoryStateChanged(ItemBase item, InventoryActionType _, InventoryItemState itemState)
		{
			if (itemState.IsInInventory())
			{
				Unregister(item);
			}
		}

		private void OnItemAboutToBeDestroyed(ItemBase item)
		{
			Unregister(item);
		}

		private IEnumerator ToggleItemsDelayed(int currentLod)
		{
			bool activate = currentLod <= 0;
			bool kinematic = currentLod > -1;
			if (registeredItems.Count <= 0)
			{
				itemsActivated = activate;
				itemsKinematic = kinematic;
				itemRegistryChanged = false;
				toggleCoro = null;
				yield break;
			}
			bool kinematicChanged = kinematic != itemsKinematic || itemRegistryChanged;
			bool activeChanged = activate != itemsActivated || itemRegistryChanged;
			if (activeChanged || kinematicChanged)
			{
				if (activate && !kinematic)
				{
					yield return null;
					yield return null;
				}
				if (kinematicChanged && itemsActivated)
				{
					ToggleKinematic(kinematic);
				}
				if (activeChanged)
				{
					foreach (ItemBase registeredItem in registeredItems)
					{
						if (registeredItem.gameObject.activeSelf != activate && !activityOverrides.ContainsKey(registeredItem))
						{
							registeredItem.gameObject.SetActive(activate);
						}
					}
					if (kinematicChanged && activate)
					{
						ToggleKinematic(kinematic);
					}
				}
			}
			foreach (KeyValuePair<ItemBase, TrainItemActivityHandlerOverride> activityOverride in activityOverrides)
			{
				bool flag = currentLod <= activityOverride.Value.ActivityThreshold;
				GameObject gameObject = activityOverride.Key.gameObject;
				if (gameObject.activeSelf != flag)
				{
					activityOverride.Value.Fire_AboutToChangeActiveStatus(flag);
					gameObject.SetActive(flag);
				}
			}
			itemsActivated = activate;
			itemsKinematic = kinematic;
			itemRegistryChanged = false;
			toggleCoro = null;
		}

		private void ToggleKinematic(bool kinematic)
		{
			if (kinematic)
			{
				itemsWithinCarBoundingBox.Clear();
				Bounds boundingBox = itemBoundingBox.BoundingBox;
				Transform interior = car.interior;
				int num = Physics.OverlapBoxNonAlloc(interior.TransformPoint(boundingBox.center), boundingBox.extents, overlapCache, interior.rotation, itemMask, QueryTriggerInteraction.Ignore);
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						ItemBase componentInParent = overlapCache[i].GetComponentInParent<ItemBase>();
						if (!(componentInParent == null))
						{
							if (!componentInParent.IsBoundToPlayer())
							{
								itemsWithinCarBoundingBox.Add(componentInParent);
							}
							else if (!componentInParent.IsSnapped)
							{
								Unregister(componentInParent);
							}
						}
					}
				}
				{
					foreach (ItemBase registeredItem in registeredItems)
					{
						if (registeredItem.gameObject.activeInHierarchy && !registeredItem.IsSnapped)
						{
							registeredItem.ItemRigidbody.isKinematic = itemsWithinCarBoundingBox.Contains(registeredItem);
						}
					}
					return;
				}
			}
			foreach (ItemBase registeredItem2 in registeredItems)
			{
				if (!registeredItem2.IsSnapped)
				{
					registeredItem2.ItemRigidbody.isKinematic = false;
				}
			}
		}

		public void UnregisterAndActivateItems()
		{
			if (registeredItems.Count <= 0)
			{
				return;
			}
			if (toggleCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.StopCoroutine(toggleCoro);
				toggleCoro = null;
			}
			Transform originShiftParent = WorldMover.OriginShiftParent;
			foreach (ItemBase item in new HashSet<ItemBase>(registeredItems))
			{
				if (item == null)
				{
					continue;
				}
				ItemReparentingBase component = item.GetComponent<ItemReparentingBase>();
				if (component != null)
				{
					component.ParentItemExternal(originShiftParent, null);
				}
				else
				{
					Debug.LogError("TrainItemActivityHandler could not properly reparent " + item.name + ". ItemReparentingBase is missing.");
					item.transform.SetParent(originShiftParent);
				}
				CabItemRigidbody component2 = item.GetComponent<CabItemRigidbody>();
				if ((bool)component2)
				{
					Rigidbody rigidbody = component2.GetRigidbody();
					if (rigidbody != null && !item.IsSnapped)
					{
						rigidbody.isKinematic = false;
					}
					component2.SetupTrainReceivingForces(null);
				}
				RespawnOnDrop component3 = component2.GetComponent<RespawnOnDrop>();
				if ((bool)component3)
				{
					component3.ResetToOriginalSpawnVariables();
				}
				component2.gameObject.SetActive(value: true);
			}
			foreach (ItemSnapPointCoupler couplerSnapPoint in couplerSnapPoints)
			{
				if (!(couplerSnapPoint.SnappedItem == null))
				{
					couplerSnapPoint.UnsnapItem();
				}
			}
			foreach (TrainItemActivityHandlerOverride value in activityOverrides.Values)
			{
				value.Fire_AboutToChangeActiveStatus(active: true);
			}
			itemRegistryChanged = false;
			itemsActivated = true;
			itemsKinematic = false;
			registeredItems.Clear();
			activityOverrides.Clear();
		}

		private void OnTrainPhysicsLodChanged(int currentLod)
		{
			if (toggleCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(toggleCoro);
			}
			toggleCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(ToggleItemsDelayed(currentLod));
		}

		public List<ItemSnapPointCoupler> GetCouplerSnapPoints()
		{
			return couplerSnapPoints;
		}

		public void ResetToInitialState()
		{
			itemBoundingBox.ResetToInitialState();
		}
	}
}
