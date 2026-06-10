using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.State;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.Construction
{
	[DisallowMultipleComponent]
	public class FurnitureEventStorageView : MonoBehaviour
	{
		private readonly Dictionary<string, Transform> slotByResourceId = new Dictionary<string, Transform>();

		private readonly List<Transform> slots = new List<Transform>();

		[NonSerialized]
		private BaseBuildingInstance baseBuildingInstance;

		[NonSerialized]
		private BaseBuildingViewComponent baseBuildingViewComponent;

		private void OnEnable()
		{
			if (baseBuildingViewComponent == null)
			{
				baseBuildingViewComponent = GetComponentInParent<BaseBuildingViewComponent>();
			}
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent += SubscribeToEvent;
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent -= SubscribeToEvent;
			}
			baseBuildingInstance = null;
		}

		private void Start()
		{
			Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				if (!(transform == base.transform))
				{
					slots.Add(transform);
				}
			}
		}

		private void OnDestroy()
		{
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent -= SubscribeToEvent;
			}
		}

		private void ClearSlots()
		{
			slotByResourceId.Clear();
			foreach (Transform slot in slots)
			{
				ClearSlot(slot);
			}
		}

		private static void ClearSlot(Transform slot)
		{
			for (int num = slot.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(slot.GetChild(num).gameObject);
			}
		}

		private void ShowEventItems()
		{
			ClearSlots();
			if (slots.Count != 0)
			{
				RefreshItemsToDisplay();
			}
		}

		private ResourcePileView GenerateResourceView(ResourceInstance resourceInstance)
		{
			ResourcePileView resourcePileView = ResourcePileFactory.ProduceView(resourceInstance);
			if (resourcePileView == null)
			{
				return null;
			}
			ShelfFillView.RemoveExcessComponents(resourcePileView.gameObject, resetEulerAngles: false);
			resourcePileView.transform.localPosition = Vector3.zero;
			HideResource hideResource = resourcePileView.GetComponent<HideResource>();
			if (hideResource != null)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					if (!(hideResource == null))
					{
						hideResource.SetElevationOnShelf(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent.HostBuilding.GridDataPosition.y);
						hideResource.TryForceHide(MonoSingleton<World>.Instance.LayerLevel);
					}
				});
			}
			return resourcePileView;
		}

		private void RefreshItemsToDisplay()
		{
			if (slotByResourceId == null || MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent.GetDisplayEventResources() == null)
			{
				return;
			}
			foreach (ResourceInstance item in from res in MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent.GetDisplayEventResources()
				where res != null && res.Amount <= 0
				select res)
			{
				if (slotByResourceId.TryGetValue(item.BlueprintId, out var value) && !(value == null))
				{
					slotByResourceId.Remove(item.BlueprintId);
					ClearSlot(value);
				}
			}
			foreach (Transform slot in slots)
			{
				if (!slotByResourceId.ContainsValue(slot))
				{
					ResourceInstance firstFreeResource = GetFirstFreeResource();
					if (firstFreeResource == null)
					{
						break;
					}
					ResourcePileView resourcePileView = GenerateResourceView(firstFreeResource);
					if (resourcePileView == null)
					{
						Debug.Log("FurnitureEventStorageView: cannot create view for resource " + firstFreeResource.BlueprintId);
						break;
					}
					resourcePileView.transform.SetParent(slot, worldPositionStays: false);
					if (slotByResourceId.ContainsKey(firstFreeResource.BlueprintId))
					{
						slotByResourceId[firstFreeResource.BlueprintId] = slot;
					}
					else
					{
						slotByResourceId.Add(firstFreeResource.BlueprintId, slot);
					}
				}
			}
		}

		private ResourceInstance GetFirstFreeResource()
		{
			foreach (ResourceInstance displayEventResource in MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent.GetDisplayEventResources())
			{
				if (displayEventResource != null && displayEventResource.Amount != 0 && !slotByResourceId.ContainsKey(displayEventResource.BlueprintId))
				{
					return displayEventResource;
				}
			}
			return MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent.GetRandomDisplayEventResources();
		}

		private void SubscribeToEvent(PlayerTriggeredEventInstance eventInstance)
		{
			eventInstance.StateChangedEvent += OnEventStateChanged;
		}

		private void OnEventEnded()
		{
			MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent.StateChangedEvent -= OnEventStateChanged;
			ClearSlots();
		}

		private void OnEventStateChanged(EventState state)
		{
			if (baseBuildingInstance == null)
			{
				baseBuildingInstance = baseBuildingViewComponent.BaseBuildingInstance;
			}
			if (baseBuildingInstance != null && baseBuildingInstance.EligibleForEvent() && MonoSingleton<PlayerTriggeredEventManager>.Instance.IsInEventRoom(baseBuildingInstance))
			{
				switch (state)
				{
				case EventState.Started:
					ShowEventItems();
					break;
				case EventState.Ended:
					OnEventEnded();
					break;
				}
			}
		}
	}
}
