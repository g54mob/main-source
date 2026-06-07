using System;
using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.CabControls.Spec;
using DV.Customization;
using DV.Items;
using DV.Items.Snapping;
using DV.Utils;
using UnityEngine;

public class StorageItemTransformController
{
	private class StorageItemTransformData
	{
		public ItemBase item;

		public ItemReparentingBase reparenting;

		public RespawnOnDrop respawner;

		public Vector3 LocalPosition { get; private set; }

		public Quaternion LocalRotation { get; private set; }

		public bool ValidTransformData { get; private set; }

		public StorageItemTransformData(ItemBase item, ItemStaticParent staticParent)
		{
			if (item == null)
			{
				throw new ArgumentNullException("StorageItemTransformData requires a non-null ItemBase reference.");
			}
			this.item = item;
			reparenting = item.GetComponent<ItemReparentingBase>();
			if (reparenting == null)
			{
				throw new ArgumentException("StorageItemTransformData requires an item with a valid ItemReparentingBase component.");
			}
			respawner = item.GetComponent<RespawnOnDrop>();
			UpdateTransformData(staticParent);
		}

		public StorageItemTransformData(ItemBase item, Vector3 localPosition, Quaternion localRotation)
		{
			if (item == null)
			{
				throw new ArgumentNullException("StorageItemTransformData requires a non-null ItemBase reference.");
			}
			this.item = item;
			reparenting = item.GetComponent<ItemReparentingBase>();
			if (reparenting == null)
			{
				throw new ArgumentException("StorageItemTransformData requires an item with a valid ItemReparentingBase component.");
			}
			respawner = item.GetComponent<RespawnOnDrop>();
			LocalPosition = localPosition;
			LocalRotation = localRotation;
			ValidTransformData = true;
		}

		public void UpdateTransformData(ItemStaticParent staticParent)
		{
			if (!(staticParent == null))
			{
				LocalPosition = staticParent.transform.InverseTransformPoint(item.transform.position);
				LocalRotation = Quaternion.Inverse(staticParent.transform.rotation) * item.transform.rotation;
				ValidTransformData = true;
			}
		}

		public void UpdateTransformData(Vector3 localPosition, Quaternion localRotation)
		{
			LocalPosition = localPosition;
			LocalRotation = localRotation;
			ValidTransformData = true;
		}

		public void ResetTransformData()
		{
			LocalPosition = IGNORE_POSITION_VALUE;
			LocalRotation = Quaternion.identity;
			ValidTransformData = false;
		}
	}

	public static readonly Vector3 IGNORE_POSITION_VALUE = Vector3.zero;

	private Dictionary<ItemBase, StorageItemTransformData> itemTransformDataCollection = new Dictionary<ItemBase, StorageItemTransformData>();

	private Coroutine itemActivationCoro;

	public void ActivateItems(StorageStaticParent staticParent)
	{
		if (staticParent == null)
		{
			Debug.LogError("StorageItemTransformController: Trying to move items to a null StorageStaticParent. Aborting...");
			return;
		}
		if (itemActivationCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(itemActivationCoro);
			itemActivationCoro = null;
		}
		StorageBase storageLostAndFound = SingletonBehaviour<StorageController>.Instance.StorageLostAndFound;
		storageLostAndFound.RemovePotentialNulls();
		storageLostAndFound.itemsActiveOrActivating = true;
		HashSet<ItemBase> hashSet = new HashSet<ItemBase>(SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.GetStorageItemList());
		foreach (KeyValuePair<ItemBase, StorageItemTransformData> item in itemTransformDataCollection)
		{
			ItemBase key = item.Key;
			if (!hashSet.Contains(key))
			{
				continue;
			}
			if (key.IsSnapped)
			{
				hashSet.Remove(key);
				continue;
			}
			StorageItemTransformData value = item.Value;
			if (!value.ValidTransformData)
			{
				continue;
			}
			Vector3 vector = staticParent.transform.TransformPoint(value.LocalPosition);
			if (!staticParent.IsInVolume(vector))
			{
				Debug.LogWarning("Resetting transform data for item " + key.name + " since it is outside of the static parent volume.", key);
				value.ResetTransformData();
				continue;
			}
			Transform transform = staticParent.transform;
			key.transform.position = vector;
			key.transform.rotation = transform.rotation * value.LocalRotation;
			key.ItemRigidbody.velocity = Vector3.zero;
			key.ItemRigidbody.angularVelocity = Vector3.zero;
			if (key.transform.parent != transform)
			{
				value.reparenting.ParentItemExternal(transform, null, staticParent);
			}
			UpdateRespawnParams(key, value.respawner, transform);
			hashSet.Remove(key);
			key.gameObject.SetActive(value: true);
		}
		if (hashSet.Count > 0)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Run(SequentialItemActivation(staticParent, storageLostAndFound, hashSet));
		}
	}

	public void DeactivateItems()
	{
		if (itemActivationCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(itemActivationCoro);
			itemActivationCoro = null;
		}
		StorageBase storageLostAndFound = SingletonBehaviour<StorageController>.Instance.StorageLostAndFound;
		foreach (ItemBase storageItem in storageLostAndFound.GetStorageItemList())
		{
			if (!ItemSnappedToLostAndFound(storageItem.SnappableItem))
			{
				storageItem.gameObject.SetActive(value: false);
			}
		}
		storageLostAndFound.itemsActiveOrActivating = false;
	}

	private IEnumerator SequentialItemActivation(StorageStaticParent staticParent, StorageBase storage, HashSet<ItemBase> itemsToActivate)
	{
		foreach (ItemBase item in itemsToActivate)
		{
			if (item == null)
			{
				Debug.LogWarning("Item was destroyed during activation process in storage " + storage.name + ". Skipping...", storage);
			}
			else if (!item.IsSnapped)
			{
				Transform transform = item.transform;
				Transform transform2 = item.transform;
				(Vector3, Quaternion) randomTransformValues = staticParent.GetRandomTransformValues();
				transform.position = randomTransformValues.Item1;
				transform2.rotation = randomTransformValues.Item2;
				RespawnOnDrop component = item.GetComponent<RespawnOnDrop>();
				UpdateRespawnParams(item, component, staticParent.transform);
				item.gameObject.SetActive(value: true);
				yield return null;
			}
		}
		itemActivationCoro = null;
	}

	private void UpdateRespawnParams(ItemBase item, RespawnOnDrop respawner, Transform staticParentTransform)
	{
		if (respawner != null)
		{
			respawner.TryChangeRespawnParent(staticParentTransform);
		}
		else
		{
			Debug.LogError("Activating item " + item.transform.name + " which has no RespawnOnDrop. Is this intended?");
		}
	}

	public void UpdateItemTransformData(ItemBase item)
	{
		if (item == null)
		{
			Debug.LogError("StorageItemTransformController: Trying to update transform data for a null ItemBase. Aborting...");
		}
		else
		{
			if (!item.BelongsToPlayer())
			{
				return;
			}
			StorageController instance = SingletonBehaviour<StorageController>.Instance;
			SnappableItem snappableItem = item.SnappableItem;
			bool num = ItemSnappedToLostAndFound(snappableItem);
			if (!instance.StorageLostAndFound.ContainsItem(item))
			{
				instance.AddItemToLostAndFound(item, updateTransformData: false);
			}
			if (num)
			{
				RemoveItem(item);
				return;
			}
			if (itemTransformDataCollection.TryGetValue(item, out var value))
			{
				if (value == null)
				{
					Debug.LogError("StorageItemTransformController: StorageItemTransformData is null. Aborting transform data update. This should not happen.");
				}
				else
				{
					value.UpdateTransformData(item.GetComponentInParent<ItemStaticParent>());
				}
				return;
			}
			itemTransformDataCollection.Add(item, new StorageItemTransformData(item, item.GetComponentInParent<ItemStaticParent>()));
			item.AboutToBeDestroyed += RemoveItem;
			if ((bool)snappableItem)
			{
				snappableItem.ItemSnappingChanged += OnItemSnappingChanged;
			}
		}
	}

	private void OnItemSnappingChanged(SnappableItem snappableItem, bool snapped, SnapPointTypes _)
	{
		if (ItemSnappedToLostAndFound(snappableItem))
		{
			RemoveItem(snappableItem.Item);
		}
	}

	private bool ItemSnappedToLostAndFound(SnappableItem snappable)
	{
		ItemSnapPointBase itemSnapPointBase = ((snappable != null) ? snappable.SnappedTo : null);
		if (itemSnapPointBase != null)
		{
			return itemSnapPointBase.gameObject.GetComponentInParentIncludingInactive<StorageShedCustomization>() != null;
		}
		return false;
	}

	private void RemoveItem(ItemBase item)
	{
		if (item == null)
		{
			Debug.LogError("StorageItemTransformController received null item. Aborting item unregistration...");
		}
		else if (itemTransformDataCollection.ContainsKey(item))
		{
			itemTransformDataCollection.Remove(item);
			item.AboutToBeDestroyed -= RemoveItem;
			if (item.SnappableItem != null)
			{
				item.SnappableItem.ItemSnappingChanged -= OnItemSnappingChanged;
			}
		}
	}

	public (Vector3 localPosition, Quaternion localRotation, bool hasValidPositionAndRotation) GetItemTransformValues(ItemBase item)
	{
		if (!itemTransformDataCollection.TryGetValue(item, out var value) || !value.ValidTransformData)
		{
			return default((Vector3, Quaternion, bool));
		}
		return (localPosition: value.LocalPosition, localRotation: value.LocalRotation, hasValidPositionAndRotation: true);
	}

	public void ForceSetItemTransformValues(ItemBase item, Vector3 localPosition, Quaternion localRotation)
	{
		StorageItemTransformData value;
		if (item == null)
		{
			Debug.LogError("StorageItemTransformController: Trying to force set transform values for a null ItemBase. Aborting...");
		}
		else if (!itemTransformDataCollection.TryGetValue(item, out value))
		{
			itemTransformDataCollection.Add(item, new StorageItemTransformData(item, localPosition, localRotation));
			item.AboutToBeDestroyed += RemoveItem;
			if (item.SnappableItem != null)
			{
				item.SnappableItem.ItemSnappingChanged += OnItemSnappingChanged;
			}
		}
		else
		{
			value.UpdateTransformData(localPosition, localRotation);
		}
	}
}
