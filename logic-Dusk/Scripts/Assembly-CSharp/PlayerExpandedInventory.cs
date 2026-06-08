using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpandedInventory : IInventory
{
	private LocalPlayer _player;

	private int guiInventoryCount;

	private int guiMaxInventorySpace;

	private int guiRationValue = -1;

	private int guiScrapValue = -1;

	private string _guiStatus = string.Empty;

	private string _guiRations = string.Empty;

	private string _guiScrap = string.Empty;

	private int _expandedInventoryCount;

	private List<IInventoryItem> _items;

	public int Scrap
	{
		get
		{
			return _player.Inventory.Scrap;
		}
		set
		{
			_player.Inventory.Scrap = value;
		}
	}

	public int TotalPropulsionFuel
	{
		get
		{
			return _player.Inventory.TotalPropulsionFuel;
		}
	}

	public int PropulsionFuelCharge
	{
		get
		{
			return _player.Inventory.PropulsionFuelCharge;
		}
	}

	public int PropulsionFuelReserve
	{
		get
		{
			return _player.Inventory.PropulsionFuelReserve;
		}
		set
		{
			_player.Inventory.PropulsionFuelReserve = value;
		}
	}

	public int JumpFuel
	{
		get
		{
			return _player.Inventory.JumpFuel;
		}
		set
		{
			_player.Inventory.JumpFuel = value;
		}
	}

	public bool CanHaveScrap
	{
		get
		{
			return _player.Inventory.CanHaveScrap;
		}
	}

	public string guiStatus
	{
		get
		{
			if (guiInventoryCount != InventoryCount || guiMaxInventorySpace != MaxInventorySpace)
			{
				_guiStatus = string.Format("{0} / {1}", InventoryCount, MaxInventorySpace);
				guiInventoryCount = InventoryCount;
				guiMaxInventorySpace = MaxInventorySpace;
			}
			return _guiStatus;
		}
	}

	public string guiScrap
	{
		get
		{
			if (guiScrapValue != Scrap)
			{
				_guiScrap = "Scrap: " + Scrap;
				guiScrapValue = Scrap;
			}
			return _guiScrap;
		}
	}

	public int InventoryCount
	{
		get
		{
			return _expandedInventoryCount;
		}
	}

	public int MaxInventorySpace
	{
		get
		{
			return _player.Inventory.MaxInventorySpace;
		}
	}

	public List<IInventoryItem> ItemsCopy
	{
		get
		{
			if (_items == null)
			{
				RefreshItems();
			}
			return _items;
		}
	}

	public PlayerExpandedInventory(LocalPlayer player)
	{
		_player = player;
		EventManager.Instance.SubscribeDeferred(GeneralEventType.InventoryChange, HandlePlayerInventoryChange);
	}

	public void RefreshItems()
	{
		if (_items == null)
		{
			_items = new List<IInventoryItem>();
		}
		else
		{
			_items.Clear();
		}
		if (_player.Inventory.ItemsCopy != null)
		{
			_items.AddRange(_player.Inventory.ItemsCopy);
		}
		_expandedInventoryCount = _player.Inventory.InventoryCount;
		foreach (IDrone drone in _player.Drones)
		{
			foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
			{
				if (upgrade != null)
				{
					_items.Add(new ExpandedInventoryItem(upgrade, string.Format(" (Drone {0}: {1})", drone.DroneNumber, drone.DroneName)));
					_expandedInventoryCount++;
				}
			}
		}
		foreach (IInventoryItem item in _player.MyShip.InstalledInventory.ItemsCopy)
		{
			if (item != null)
			{
				_items.Add(new ExpandedInventoryItem(item, " (installed)"));
				_expandedInventoryCount++;
			}
		}
	}

	public void RemoveInventoryItem(IInventoryItem item)
	{
		if (_player.Inventory.ItemsCopy.Contains(item))
		{
			_player.Inventory.RemoveInventoryItem(item);
		}
		else if (item is ExpandedInventoryItem)
		{
			Debug.LogWarning("Not currently supporting removing 'expanded' items via PlayerExpandedInventory");
		}
	}

	private void HandlePlayerInventoryChange(object sender, EventArgs args)
	{
		RefreshItems();
	}
}
