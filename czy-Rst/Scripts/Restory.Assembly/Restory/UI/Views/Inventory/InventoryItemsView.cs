using System.Collections.Generic;
using Restory.ObjectPools;
using Restory.UI.Views.StorageSlotElements;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views.Inventory
{
	public sealed class InventoryItemsView : UIBehaviour, ICleanableComponent
	{
		[SerializeField]
		private RectTransform container;

		[SerializeField]
		private RectTransform emptyInfo;

		private readonly List<StorageSlotElementView> items = new List<StorageSlotElementView>();

		public IReadOnlyList<StorageSlotElementView> Items => items;

		public void AddItems(IEnumerable<StorageSlotElementView> items)
		{
			foreach (StorageSlotElementView item in items)
			{
				this.items.Add(item);
				item.transform.SetParent(container, worldPositionStays: false);
			}
		}

		public void SetItems(IEnumerable<StorageSlotElementView> items)
		{
			ClearItems();
			AddItems(items);
		}

		public void ClearItems()
		{
			items.Clear();
			container.DetachChildren();
		}

		public void SetEmptyInfoVisibility(bool isVisible)
		{
			emptyInfo.gameObject.SetActive(isVisible);
		}

		void ICleanableComponent.Clean()
		{
			ClearItems();
			SetEmptyInfoVisibility(isVisible: true);
		}
	}
}
