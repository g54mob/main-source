using System;
using System.Collections.Generic;
using System.Linq;
using AssembleSystem.Utils;
using UnityEngine;

namespace AssembleSystem
{
	public class AssembleSystemService : IAssembleSystemService
	{
		private Dictionary<AssembleObjectParent, List<PartConfig>> _itemsToBasePartsDictionary = new Dictionary<AssembleObjectParent, List<PartConfig>>();

		private readonly IInventoryService _inventoryService;

		Dictionary<AssembleObjectParent, List<PartConfig>> IAssembleSystemService.ItemsToBasePartsDictionary => _itemsToBasePartsDictionary;

		Action<AssembleObjectParent, bool, int> IAssembleSystemService.CheckBasePartsInInventory { get; set; }

		public AssembleSystemService(IInventoryService inventoryService)
		{
			_itemsToBasePartsDictionary = new Dictionary<AssembleObjectParent, List<PartConfig>>();
			_inventoryService = inventoryService;
			IInventoryService inventoryService2 = _inventoryService;
			inventoryService2.OnItemPicked = (Action<IInventoryManagable>)Delegate.Combine(inventoryService2.OnItemPicked, new Action<IInventoryManagable>(CheckOnInventoryItemAdded));
			IInventoryService inventoryService3 = _inventoryService;
			inventoryService3.OnItemDropped = (Action<IInventoryManagable>)Delegate.Combine(inventoryService3.OnItemDropped, new Action<IInventoryManagable>(CheckOnInventoryItemRemoved));
		}

		private void CheckOnInventoryItemAdded(IInventoryManagable pickable)
		{
			if (!(pickable is PartObject partObject) || partObject.AssembleParent == null)
			{
				return;
			}
			AssembleObjectParent component = partObject.AssembleParent.GetComponent<AssembleObjectParent>();
			if (!(component == null))
			{
				AddPart(component, partObject.Config);
				if (!_itemsToBasePartsDictionary.TryGetValue(component, out var value))
				{
					value = new List<PartConfig>();
				}
				int currentAmount;
				bool arg = AreAllBasePartsIncluded(value, component.ItemConfig, out currentAmount);
				((IAssembleSystemService)this).CheckBasePartsInInventory?.Invoke(component, arg, currentAmount);
			}
		}

		private void CheckOnInventoryItemRemoved(IInventoryManagable pickable)
		{
			if (!(pickable is PartObject partObject) || partObject.AssembleParent == null)
			{
				return;
			}
			AssembleObjectParent component = partObject.AssembleParent.GetComponent<AssembleObjectParent>();
			if (!(component == null))
			{
				RemovePart(component, partObject.Config);
				if (!_itemsToBasePartsDictionary.TryGetValue(component, out var value))
				{
					value = new List<PartConfig>();
				}
				int currentAmount;
				bool arg = AreAllBasePartsIncluded(value, component.ItemConfig, out currentAmount);
				((IAssembleSystemService)this).CheckBasePartsInInventory?.Invoke(component, arg, currentAmount);
			}
		}

		private void AddPart(AssembleObjectParent parentItem, PartConfig config)
		{
			if (!_itemsToBasePartsDictionary.ContainsKey(parentItem))
			{
				_itemsToBasePartsDictionary.Add(parentItem, new List<PartConfig>());
			}
			_itemsToBasePartsDictionary[parentItem].Add(config);
		}

		private void RemovePart(AssembleObjectParent parentItem, PartConfig config)
		{
			if (_itemsToBasePartsDictionary.ContainsKey(parentItem))
			{
				if (_itemsToBasePartsDictionary[parentItem].Count > 0)
				{
					_itemsToBasePartsDictionary[parentItem].Remove(config);
				}
				else
				{
					_itemsToBasePartsDictionary.Remove(parentItem);
				}
			}
		}

		private bool AreAllBasePartsIncluded(List<PartConfig> firstList, AssembleItemConfig assembleConfig, out int currentAmount)
		{
			bool result = assembleConfig.PartsConfig.Where((PartConfig item) => item.NecessaryAssembleParts.Count == 0).All(firstList.Contains);
			currentAmount = firstList.Count((PartConfig config) => config.NecessaryAssembleParts.Count == 0);
			return result;
		}

		bool IAssembleSystemService.AnyPartsInInventoryOf(AssembleObjectParent parent)
		{
			if (parent == null)
			{
				return false;
			}
			GameObject gameObject = parent.gameObject;
			foreach (IInventoryManagable item in _inventoryService.Items)
			{
				if (item is PartObject partObject && partObject.AssembleParent == gameObject)
				{
					return true;
				}
			}
			return false;
		}
	}
}
