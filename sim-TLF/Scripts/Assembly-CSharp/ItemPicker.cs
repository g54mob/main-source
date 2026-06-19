using System;
using System.Collections.Generic;
using System.Linq;
using AssembleSystem;
using MyBox;
using Services.Missions;
using UI.Craft;
using UI.Inventory;
using UnityEngine;
using Zenject;

[Obsolete("Use PlayerItemPciker Instead")]
public class ItemPicker : MonoBehaviour
{
	[SerializeField]
	private Transform _UIparent;

	[SerializeField]
	private GameObject[] _partToPick;

	[SerializeField]
	private List<MonoBehaviour> _inventoryItems;

	[Inject]
	private IInventoryService _inventoryService;

	[Inject]
	private IAssembleSystemService _assembleSystemService;

	[Inject]
	private ICraftUIService _craftUIService;

	[Inject]
	private IInventoryUIService _inventoryUIService;

	[Inject]
	private MissionEventBus _missionEventBus;

	private void Awake()
	{
		IAssembleSystemService assembleSystemService = _assembleSystemService;
		assembleSystemService.CheckBasePartsInInventory = (Action<AssembleObjectParent, bool, int>)Delegate.Combine(assembleSystemService.CheckBasePartsInInventory, new Action<AssembleObjectParent, bool, int>(CheckBaseParts));
	}

	private void OnEnable()
	{
		IInventoryService inventoryService = _inventoryService;
		inventoryService.OnItemPicked = (Action<IInventoryManagable>)Delegate.Combine(inventoryService.OnItemPicked, new Action<IInventoryManagable>(CheckIfCanBuild));
		IInventoryService inventoryService2 = _inventoryService;
		inventoryService2.OnItemDropped = (Action<IInventoryManagable>)Delegate.Combine(inventoryService2.OnItemDropped, new Action<IInventoryManagable>(CheckIfCanBuild));
	}

	private void CheckIfCanBuild(IInventoryManagable managable)
	{
		Debug.Log("Checking if can furhter build");
		if (!(managable is PartObject partObject))
		{
			return;
		}
		AssembleObjectParent parent = partObject.AssembleParent.GetComponent<AssembleObjectParent>();
		if (parent == null || !parent.StateMachine.Placed)
		{
			return;
		}
		Debug.Log("Parent Placed");
		foreach (PartObject item in _inventoryService.Items.Where((IInventoryManagable part) => part is PartObject partObject3 && partObject3.AssembleParent == parent.gameObject).ToList())
		{
			if (item.AllNecessaryPartsTightened() || item.IsBase)
			{
				item.StateMachine.AllNecessaryPartsTightened = true;
			}
			else
			{
				item.StateMachine.AllNecessaryPartsTightened = false;
			}
		}
	}

	private void UpdateInventoryList()
	{
		_inventoryItems.Clear();
		foreach (IInventoryManagable item in _inventoryService.Items)
		{
			_inventoryItems.Add(item as MonoBehaviour);
		}
	}

	private void CheckBaseParts(AssembleObjectParent view, bool allIn, int amount)
	{
		if (allIn)
		{
			Debug.Log(_craftUIService.CraftItems.Count);
			Debug.Log(_craftUIService.CraftItems.Where((CraftItemViewModel x) => x.Parent == view).Count());
			Debug.Log("All base items in inventory for " + view.ItemConfig.name);
			_craftUIService.CraftItems.Where((CraftItemViewModel x) => x.Parent == view).ForEach(delegate(CraftItemViewModel x)
			{
				x.CanCraft.Value = true;
			});
			if (view.ItemConfig.name == "Table_config")
			{
				_missionEventBus.Emit("interact", "pickBaseParts");
			}
		}
		else
		{
			Debug.Log("Not all base parts in inventory");
			view.StateMachine.ReadyToBuild = false;
			_craftUIService.CraftItems.Where((CraftItemViewModel x) => x.Parent == view).ForEach(delegate(CraftItemViewModel x)
			{
				x.CanCraft.Value = false;
			});
		}
		Debug.Log("Amount " + amount);
		_craftUIService.CraftItems.Where((CraftItemViewModel x) => x.Parent == view).ForEach(delegate(CraftItemViewModel x)
		{
			x.CurrentPartsAmount.Value = amount;
		});
	}
}
