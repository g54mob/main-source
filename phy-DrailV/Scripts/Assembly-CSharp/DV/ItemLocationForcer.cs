using System.Collections;
using DV.CabControls;
using DV.InventorySystem;
using DV.Items;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class ItemLocationForcer : MonoBehaviour
	{
		public float allowedSqrDistance = 36f;

		public Transform forcedLocation;

		public GameObject itemGO;

		private ItemBase item;

		private ItemPositionHandler itemPositionHandler;

		private void Awake()
		{
			if (itemGO == null)
			{
				Debug.LogError("itemGO not set! Destroying self!");
				Object.Destroy(this);
			}
		}

		private void Start()
		{
			item = itemGO.GetComponent<ItemBase>();
			if (item == null)
			{
				Debug.LogError("itemGO doesn't have ItemBase script! Destroying self!");
				Object.Destroy(this);
			}
			else
			{
				itemPositionHandler = base.gameObject.AddComponent<ItemPositionHandler>();
				itemPositionHandler.Initialize(item);
				StartCoroutine(ForceItemStartLocation());
			}
		}

		private void OnEnable()
		{
			if (item != null)
			{
				StartCoroutine(ForceItemStartLocation());
			}
			StartCoroutine(CheckDistanceLocationCoro());
			SingletonBehaviour<FastTravelController>.Instance.AboutToFastTravel += OnAboutToFastTravel;
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				StopAllCoroutines();
				SingletonBehaviour<FastTravelController>.Instance.AboutToFastTravel -= OnAboutToFastTravel;
			}
		}

		private void OnAboutToFastTravel()
		{
			if ((bool)itemGO)
			{
				SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(itemGO);
				SingletonBehaviour<Inventory>.Instance.PurgeFromInventory(itemGO);
			}
			if ((bool)item)
			{
				item.transform.position = forcedLocation.position;
				item.transform.rotation = forcedLocation.rotation;
			}
		}

		private IEnumerator CheckDistanceLocationCoro()
		{
			while (true)
			{
				yield return WaitFor.Seconds(1f);
				if (!(item == null) && itemPositionHandler.Initialized && (itemPositionHandler.ItemPosition - forcedLocation.position).sqrMagnitude > allowedSqrDistance)
				{
					yield return StartCoroutine(ForceItemStartLocation());
				}
			}
		}

		private IEnumerator ForceItemStartLocation()
		{
			SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(itemGO);
			SingletonBehaviour<Inventory>.Instance.PurgeFromInventory(itemGO);
			SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.PurgeItemFromContainer(itemGO);
			while (!SingletonBehaviour<WorldStreamingInit>.Instance.IsSceneAndTerrainRegionLoaded(forcedLocation.position))
			{
				yield return WaitFor.Seconds(0.2f);
			}
			item.transform.position = forcedLocation.position;
			item.transform.rotation = forcedLocation.rotation;
		}
	}
}
