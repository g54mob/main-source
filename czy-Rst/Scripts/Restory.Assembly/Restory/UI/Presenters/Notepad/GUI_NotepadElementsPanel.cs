using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Quests;
using Restory.Gameplay.Workplace;
using Restory.Infrastructure.ProjectServices;
using Restory.ObjectPools;
using Restory.StorageSystem;
using Restory.StorageSystem.StorageElements;
using Restory.UI.Views.Notepad;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.UI.Presenters.Notepad
{
	public sealed class GUI_NotepadElementsPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_NotepadElementsPanelView view;

		private readonly List<ElementBase> cachedPlacedElements = new List<ElementBase>();

		private readonly List<ElementBase> highlightedElements = new List<ElementBase>();

		private readonly List<GUI_NotepadElementItem> items = new List<GUI_NotepadElementItem>();

		private WorkSurface workSurface;

		private IInventory inventory;

		private ICoroutineRunner coroutineRunner;

		private NotepadElementItemPool notepadElementItemPool;

		private bool isSubscribed;

		private DeviceContainer deviceContainer;

		private Coroutine updateElementsViewsAndPresentersAfterEndOfFrameCoroutine;

		public bool IsSubscribed => isSubscribed;

		public event Action<GUI_NotepadElementItem> OnElementSelected;

		[Inject]
		private void Construct(WorkSurface workSurface, IInventory inventory, ICoroutineRunner coroutineRunner, NotepadElementItemPool notepadElementItemPool)
		{
			this.workSurface = workSurface;
			this.inventory = inventory;
			this.coroutineRunner = coroutineRunner;
			this.notepadElementItemPool = notepadElementItemPool;
		}

		public void Init(DeviceContainer deviceContainer)
		{
			this.deviceContainer = deviceContainer;
			cachedPlacedElements.Clear();
		}

		public void SetVisibility(bool shouldBeVisible)
		{
			view.SetVisibility(shouldBeVisible);
		}

		public void Subscribe()
		{
			if (!isSubscribed)
			{
				isSubscribed = true;
				inventory.StorageElements.StorageChanged += ResolveInventoryContentsChanged;
				workSurface.OnPlacedElementsChanged += ResolvePlacedElementsChanged;
			}
		}

		public void Unsubscribe()
		{
			if (isSubscribed)
			{
				isSubscribed = false;
				inventory.StorageElements.StorageChanged -= ResolveInventoryContentsChanged;
				workSurface.OnPlacedElementsChanged -= ResolvePlacedElementsChanged;
			}
		}

		public void RequestUpdateElementsViewsAndPresenters()
		{
			if (updateElementsViewsAndPresentersAfterEndOfFrameCoroutine == null)
			{
				updateElementsViewsAndPresentersAfterEndOfFrameCoroutine = coroutineRunner.Run(DoCallbackAfterEndOfFrameCoroutine(UpdateElementsViewsAndPresenters));
			}
		}

		public void Clear()
		{
			if (updateElementsViewsAndPresentersAfterEndOfFrameCoroutine != null)
			{
				coroutineRunner.Stop(updateElementsViewsAndPresentersAfterEndOfFrameCoroutine);
				updateElementsViewsAndPresentersAfterEndOfFrameCoroutine = null;
			}
			Unsubscribe();
			ClearElementViewsAndPresenters();
			ClearHighlightedElements();
			view.Clear();
		}

		private void UpdateElementsViewsAndPresenters()
		{
			ClearElementViewsAndPresenters();
			if (!deviceContainer)
			{
				return;
			}
			List<ElementItemAndPosition> value;
			using (CollectionPool<List<ElementItemAndPosition>, ElementItemAndPosition>.Get(out value))
			{
				CreateElementsFromDevice(value);
				CreateElementsOnSurface(value);
				view.SetElements(value);
			}
		}

		private void CreateElementsFromDevice(List<ElementItemAndPosition> elementViewsAndPositions)
		{
			foreach (ElementSocket sortedSocket in deviceContainer.Device.SortedSockets)
			{
				ElementData elementData = null;
				ElementItemStatus elementItemStatus = ElementItemStatus.EmptySocket;
				if ((bool)sortedSocket.NestedElement)
				{
					elementData = sortedSocket.NestedElement.ConditionHandler.ElementData;
					elementItemStatus = ElementItemStatus.InstalledElement;
				}
				GUI_NotepadElementItem item = CreateElementItem(sortedSocket.CompatibleElementInfo, elementData, elementItemStatus);
				elementViewsAndPositions.Add(new ElementItemAndPosition
				{
					Item = item,
					Status = elementItemStatus
				});
			}
		}

		private void CreateElementsOnSurface(List<ElementItemAndPosition> elementViewsAndPositions)
		{
			if (deviceContainer.transform.parent.TryGetComponent<DismantledDevicePack>(out var component))
			{
				UpdateElements(component.PlacedElements.ElementsOnSurface.Select((ElementTransformRecord placedElement) => placedElement.Element));
			}
			else
			{
				UpdateElements(workSurface.PlacedElements);
			}
			foreach (ElementBase cachedPlacedElement in cachedPlacedElements)
			{
				ElementItemStatus elementItemStatus = ElementItemStatus.ElementOnSurface;
				GUI_NotepadElementItem item = CreateElementItem(cachedPlacedElement.Info, cachedPlacedElement.ConditionHandler.ElementData, elementItemStatus);
				elementViewsAndPositions.Add(new ElementItemAndPosition
				{
					Item = item,
					Status = elementItemStatus
				});
			}
		}

		private void UpdateElements(IEnumerable<ElementBase> placedElements)
		{
			cachedPlacedElements.Clear();
			foreach (ElementBase placedElement in placedElements)
			{
				if ((bool)placedElement && placedElement.TryGetComponent<ElementBase>(out var component) && component.Info.Category != ElementCategory.Small && !(component is QuestItem))
				{
					cachedPlacedElements.Add(component);
				}
			}
			cachedPlacedElements.Sort(delegate(ElementBase a, ElementBase b)
			{
				int valueOrDefault = deviceContainer.Device.ElementsOrderMap.GetValueOrDefault(a.Info, int.MinValue);
				return deviceContainer.Device.ElementsOrderMap.GetValueOrDefault(b.Info, int.MinValue).CompareTo(valueOrDefault);
			});
		}

		private GUI_NotepadElementItem CreateElementItem(ElementInfo elementInfo, ElementData elementData, ElementItemStatus elementItemStatus)
		{
			GUI_NotepadElementItem gUI_NotepadElementItem = notepadElementItemPool.Get<GUI_NotepadElementItem>();
			gUI_NotepadElementItem.Init(elementInfo, elementData, elementItemStatus);
			gUI_NotepadElementItem.OnSelected += ResolveItemSelected;
			gUI_NotepadElementItem.OnDeselected += ResolveItemDeselected;
			items.Add(gUI_NotepadElementItem);
			return gUI_NotepadElementItem;
		}

		private void ClearElementViewsAndPresenters()
		{
			view.ClearElements();
			foreach (GUI_NotepadElementItem item in items)
			{
				if ((bool)item)
				{
					item.OnSelected -= ResolveItemSelected;
					item.OnDeselected -= ResolveItemDeselected;
					notepadElementItemPool.Release(item);
				}
			}
			items.Clear();
		}

		private void UpdateElementsPresentersInventoryInfo(IStorage inventoryStorage)
		{
			foreach (GUI_NotepadElementItem item in items)
			{
				if (!item.Info)
				{
					Debug.LogError("Element info was lost");
					continue;
				}
				Dictionary<ElementConditionBase, int> value;
				using (CollectionPool<Dictionary<ElementConditionBase, int>, KeyValuePair<ElementConditionBase, int>>.Get(out value))
				{
					for (int i = 0; i < inventoryStorage.Size; i++)
					{
						if (inventoryStorage[i] != null && inventoryStorage[i].Item is StorageItemElement storageItemElement && storageItemElement.ElementData.Info == item.Info)
						{
							if (value.ContainsKey(storageItemElement.ElementData.Condition))
							{
								value[storageItemElement.ElementData.Condition] += inventoryStorage[i].Count;
							}
							else
							{
								value.Add(storageItemElement.ElementData.Condition, inventoryStorage[i].Count);
							}
						}
					}
					item.UpdateElementsInInventoryInfo(value);
				}
			}
		}

		private void ResolveInventoryContentsChanged(IStorage inventoryStorage)
		{
			RequestUpdateElementsViewsAndPresenters();
		}

		private void ResolvePlacedElementsChanged()
		{
			RequestUpdateElementsViewsAndPresenters();
		}

		private void ResolveItemSelected(GUI_NotepadElementItem item)
		{
			this.OnElementSelected?.Invoke(item);
			if (item.ElementData != null)
			{
				HighlightConcreteElement(item.ElementData);
			}
			else
			{
				HighlightCompatibleElements(item.Info);
			}
		}

		private void ResolveItemDeselected(GUI_NotepadElementItem item)
		{
			ClearHighlightedElements();
		}

		private void HighlightConcreteElement(ElementData elementData)
		{
			foreach (ElementBase cachedPlacedElement in cachedPlacedElements)
			{
				if (cachedPlacedElement.ConditionHandler.ElementData == elementData)
				{
					cachedPlacedElement.IsHighlighted = true;
					highlightedElements.Add(cachedPlacedElement);
					break;
				}
			}
		}

		private void HighlightCompatibleElements(ElementInfo elementInfo)
		{
			foreach (ElementBase cachedPlacedElement in cachedPlacedElements)
			{
				if (!(cachedPlacedElement.Info != elementInfo))
				{
					cachedPlacedElement.IsHighlighted = true;
					highlightedElements.Add(cachedPlacedElement);
				}
			}
		}

		private void ClearHighlightedElements()
		{
			foreach (ElementBase highlightedElement in highlightedElements)
			{
				if ((bool)highlightedElement)
				{
					highlightedElement.IsHighlighted = false;
				}
			}
			highlightedElements.Clear();
		}

		private IEnumerator DoCallbackAfterEndOfFrameCoroutine(Action callback)
		{
			yield return new WaitForEndOfFrame();
			callback?.Invoke();
			updateElementsViewsAndPresentersAfterEndOfFrameCoroutine = null;
		}
	}
}
