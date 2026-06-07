using System.Collections.Generic;
using DV.CabControls;
using DV.InventorySystem;
using DV.Items;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public abstract class ItemMagazineTriggerReloadVolume<T> : MonoBehaviour where T : MagazineAmmo
	{
		protected ItemBase magazineItem;

		protected Dictionary<T, HashSet<Collider>> enteredColliders = new Dictionary<T, HashSet<Collider>>();

		protected bool initialized;

		private HashSet<int> validLayers = new HashSet<int>();

		public ItemMagazine Magazine { get; private set; }

		protected abstract bool Initialize();

		public abstract bool ValidReload(T ammo);

		private void Start()
		{
			Magazine = GetComponentInParent<ItemMagazine>();
			if (Magazine == null)
			{
				Debug.LogError("ItemMagazineTriggerReloadVolume: Missing ItemMagazine. Destroying self.", this);
				Object.Destroy(this);
				return;
			}
			magazineItem = GetComponentInParent<ItemBase>();
			if (magazineItem == null)
			{
				Debug.LogError("ItemMagazineTriggerReloadVolume: Missing ItemBase. Destroying self.", this);
				Object.Destroy(this);
				return;
			}
			int item = LayerMask.NameToLayer("World_Item");
			int item2 = LayerMask.NameToLayer("Grabbed_Item");
			validLayers.Add(item);
			validLayers.Add(item2);
			initialized = Initialize();
		}

		public void Reload(GameObject ammo)
		{
			Magazine.AddItem(ammo, 0);
		}

		private void OnTriggerEnter(Collider other)
		{
			ReliableOnTriggerExit.NotifyTriggerEnter(other, base.gameObject, OnTriggerExit);
			if (!initialized || other == null || other.isTrigger || !ValidLayer(other.gameObject.layer))
			{
				return;
			}
			T componentInParent = other.GetComponentInParent<T>();
			if (componentInParent == null)
			{
				return;
			}
			if (enteredColliders.TryGetValue(componentInParent, out var value))
			{
				value.Add(other);
				return;
			}
			enteredColliders.Add(componentInParent, new HashSet<Collider> { other });
			if (ValidReload(componentInParent))
			{
				ItemBase item = componentInParent.Item;
				if (item.IsGrabbed())
				{
					SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(item.gameObject);
				}
				Reload(item.gameObject);
				enteredColliders.Remove(componentInParent);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			ReliableOnTriggerExit.NotifyTriggerExit(other, base.gameObject);
			if (!initialized)
			{
				return;
			}
			T componentInParent = other.GetComponentInParent<T>();
			if (!(componentInParent == null) && enteredColliders.TryGetValue(componentInParent, out var value))
			{
				value.Remove(other);
				if (value.Count == 0)
				{
					enteredColliders.Remove(componentInParent);
				}
			}
		}

		private bool ValidLayer(int layer)
		{
			return validLayers.Contains(layer);
		}
	}
}
