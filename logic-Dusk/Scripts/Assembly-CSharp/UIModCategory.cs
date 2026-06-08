using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIModCategory : MonoBehaviour, IUIList
{
	public GameObject itemPrefab;

	public Text descriptionLabel;

	private List<UIModItem> itemList;

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public int ItemCount
	{
		get
		{
			if (itemList != null)
			{
				return itemList.Count;
			}
			return 0;
		}
	}

	public UIModListSimple ParentList { get; set; }

	public int CurrentHighlightedIndex { get; private set; }

	public bool EnableQtyDisplay { get; set; }

	public int CurrentPageIndex
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public void Clear()
	{
		if (itemList == null)
		{
			return;
		}
		foreach (UIModItem item in itemList)
		{
			if (item != null)
			{
				GameObjectPool.Instance.PushObject(item.gameObject);
			}
		}
		itemList.Clear();
	}

	public bool AddBackendItem(GameObject parent, IModification mod, bool isExclusiveItem, IUIItem originalItem)
	{
		IUIItem iUIItem = null;
		IUIModItem iUIModItem = (IUIModItem)originalItem;
		if (itemList == null)
		{
			itemList = new List<UIModItem>();
		}
		if (isExclusiveItem)
		{
			DeleteAllItems();
		}
		else
		{
			DeleteSpecificModTypes(typeof(ScrapMod));
			if (ParentList.IsQueueList)
			{
				if (mod.GetType() == typeof(RepairHpMod))
				{
					DeleteSpecificModTypes(typeof(RepairFullHpMod));
				}
				if (mod.GetType() == typeof(RepairFullHpMod))
				{
					DeleteSpecificModTypes(typeof(RepairHpMod));
				}
			}
		}
		foreach (UIModItem item in itemList)
		{
			if (iUIModItem.ModificationList.Count != 1)
			{
				continue;
			}
			IModification modification = ((IUIModItem)item).ModificationList[0];
			IModification modification2 = iUIModItem.ModificationList[0];
			if (((IUIItem)item).InventoryItem == null && originalItem.InventoryItem == null)
			{
				if (modification.GetType() == modification2.GetType())
				{
					if (modification.MaxAllowed == 1 || item.UseCount >= modification.MaxAllowed)
					{
						return false;
					}
					iUIItem = item;
				}
			}
			else if (((IUIItem)item).InventoryItem != null && originalItem.InventoryItem != null && ((IUIItem)item).InventoryItem.GroupKey == originalItem.InventoryItem.GroupKey && modification.GetType() == modification2.GetType())
			{
				if (modification.MaxAllowed == 1 || item.UseCount >= modification.MaxAllowed)
				{
					return false;
				}
				iUIItem = item;
			}
		}
		if (iUIItem == null)
		{
			GameObject gameObject = GameObjectPool.Instance.PopObject("ModItem");
			UIModItem component = gameObject.GetComponent<UIModItem>();
			component.Init();
			component.ClearHighlight();
			gameObject.transform.SetParent(parent.transform);
			gameObject.transform.localScale = Vector3.one;
			component.OriginalUIItem = originalItem;
			component.descriptionLabel.text = mod.DisplayName;
			component.AddModification(mod);
			component.SetCost(mod.ScrapCost);
			if (EnableQtyDisplay)
			{
				component.SetQtyMax(mod.MaxAllowed);
			}
			else
			{
				component.SetQtyMax(0);
			}
			component.ParentItem = originalItem.ParentItem;
			component.InventoryItem = originalItem.InventoryItem;
			if (mod is ScrapMod && originalItem is UIDroneItem)
			{
				component.InventoryItem = (IInventoryItem)((UIDroneItem)originalItem).Drone;
			}
			component.SetActive();
			component.UseCount = 1;
			itemList.Add(component);
		}
		else
		{
			UIModItem uIModItem = (UIModItem)iUIItem;
			uIModItem.AddCost(mod.ScrapCost);
			uIModItem.UseCount++;
		}
		return true;
	}

	public void Refresh()
	{
		CurrentHighlightedIndex = -1;
		if (itemList != null && itemList.Count > 0)
		{
			CurrentHighlightedIndex = 0;
		}
	}

	public void GotFocus()
	{
		throw new NotImplementedException();
	}

	public void LoseFocus()
	{
		if (CurrentHighlightedIndex > -1 && itemList.Count > CurrentHighlightedIndex)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
			itemList[CurrentHighlightedIndex].ClearSelection();
		}
	}

	public bool MoveDown()
	{
		if (CurrentHighlightedIndex > -1 && itemList.Count > CurrentHighlightedIndex)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
			itemList[CurrentHighlightedIndex].ClearSelection();
		}
		CurrentHighlightedIndex += 1;
		if (CurrentHighlightedIndex >= itemList.Count)
		{
			return true;
		}
		itemList[CurrentHighlightedIndex].Highlight();
		return false;
	}

	public bool MoveUp()
	{
		if (CurrentHighlightedIndex > -1 && itemList.Count > CurrentHighlightedIndex)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
			itemList[CurrentHighlightedIndex].ClearSelection();
		}
		CurrentHighlightedIndex -= 1;
		if (CurrentHighlightedIndex < 0)
		{
			return true;
		}
		itemList[CurrentHighlightedIndex].Highlight();
		return false;
	}

	public bool MoveToBottom()
	{
		if (itemList.Count > 0)
		{
			CurrentHighlightedIndex = itemList.Count - 1;
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveToTop()
	{
		if (itemList.Count > 0)
		{
			CurrentHighlightedIndex = 0;
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public void MoveToTopOrSelected()
	{
		IUIItem selectedItem = GetSelectedItem();
		if (selectedItem == null)
		{
			MoveToTop();
			return;
		}
		CurrentHighlightedIndex = 0;
		foreach (UIModItem item in itemList)
		{
			if (((IUIItem)item).IsSelected)
			{
				break;
			}
			CurrentHighlightedIndex += 1;
		}
		selectedItem.Highlight();
	}

	public bool DeleteHighlightedItem()
	{
		IUIItem highlightedItem = GetHighlightedItem();
		if (highlightedItem != null)
		{
			return RemoveBackendSelectedItem(highlightedItem, false);
		}
		return true;
	}

	public void DeleteAllItems()
	{
		if (itemList != null)
		{
			int count = itemList.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				RemoveBackendSelectedItem(itemList[num], false);
			}
		}
	}

	public void DeleteSpecificModTypes(Type t)
	{
		if (itemList == null)
		{
			return;
		}
		int count = itemList.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (itemList[num].ModificationList != null)
			{
				foreach (IModification modification in itemList[num].ModificationList)
				{
					if (modification.GetType().Equals(t))
					{
						RemoveBackendSelectedItem(itemList[num], true);
						if (t == typeof(ScrapMod))
						{
							((ScrapMod)modification).AffectedItem.UnDim();
						}
						break;
					}
				}
			}
		}
	}

	public bool RemoveBackendSelectedItem()
	{
		return false;
	}

	public void AddBackendItem(IUIItem item)
	{
	}

	private bool RemoveBackendSelectedItem(IUIItem item, bool allQty)
	{
		bool flag = false;
		if (item is UIModItem && !allQty)
		{
			UIModItem uIModItem = (UIModItem)item;
			if (uIModItem.ModificationList.Count > 0 && uIModItem.ModificationList[0].GetType() == typeof(ScrapMod) && ((ScrapMod)uIModItem.ModificationList[0]).AffectedItem != null)
			{
				((ScrapMod)uIModItem.ModificationList[0]).AffectedItem.UnDim();
			}
			uIModItem.UseCount--;
			if (uIModItem.UseCount >= 1)
			{
				uIModItem.SubtractCost(uIModItem.ModificationList[0].ScrapCost);
				flag = true;
			}
		}
		if (!flag)
		{
			GameObjectPool.Instance.PushObject(item.UnderlyingGameObject);
			itemList.Remove((UIModItem)item);
			return true;
		}
		return false;
	}

	public IUIItem SelectHighlightedItem()
	{
		return null;
	}

	public IUIItem GetHighlightedItem()
	{
		foreach (UIModItem item in itemList)
		{
			if (((IUIItem)item).IsHighlighted)
			{
				return item;
			}
		}
		return null;
	}

	public IUIItem GetSelectedItem()
	{
		foreach (UIModItem item in itemList)
		{
			if (((IUIItem)item).IsSelected)
			{
				return item;
			}
		}
		return null;
	}

	public void Select()
	{
		if (CurrentHighlightedIndex > -1)
		{
			itemList[CurrentHighlightedIndex].Select();
		}
	}

	public void RefreshListOnScrap(int totalCost)
	{
		if (itemList == null || itemList.Count <= 0)
		{
			return;
		}
		foreach (UIModItem item in itemList)
		{
			item.SetActive();
			if (item.ModificationList[0].ScrapCost < 0)
			{
				if (Mathf.Abs(item.ModificationList[0].ScrapCost) > GlobalSettings.GameState.ThePlayer.Inventory.Scrap + totalCost)
				{
					item.SetInactive();
				}
			}
			else if (item.ModificationList[0].GetType() != typeof(ScrapMod) && GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax - GlobalSettings.GameState.ThePlayer.Inventory.Scrap - totalCost < Mathf.Abs(item.ModificationList[0].ScrapCost))
			{
				item.SetInactive();
			}
			if (!item.ModificationList[0].CanApplyModToTarget())
			{
				item.SetInactive();
			}
		}
	}

	public int GetCost()
	{
		int num = 0;
		if (itemList != null && itemList.Count > 0)
		{
			foreach (UIModItem item in itemList)
			{
				num += item.Cost;
			}
		}
		return num;
	}

	public bool Execute()
	{
		if (itemList != null && itemList.Count > 0)
		{
			foreach (UIModItem item in itemList)
			{
				for (int i = 0; i < item.UseCount; i++)
				{
					IModification modification = item.ModificationList[0];
					if (!modification.CanApplyModToTarget())
					{
						continue;
					}
					int scrapCost = modification.ScrapCost;
					if (modification is ScrapMod)
					{
						if (item.InventoryItem is IDrone)
						{
							IDrone drone = (IDrone)item.InventoryItem;
							GlobalSettings.GameState.ThePlayer.Drones.Remove(drone);
							foreach (BaseDroneUpgrade upgrade2 in drone.Upgrades)
							{
								if (upgrade2 != null)
								{
									GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(upgrade2);
								}
							}
							drone.RemoveAllUpgrades();
							UniverseSaveFile.ClearGroup(((NonVisualDrone)drone).GroupKey);
						}
						else if (item.InventoryItem is BaseDroneUpgrade)
						{
							if (item.ParentItem is IDrone)
							{
								BaseDroneUpgrade upgrade = (BaseDroneUpgrade)item.InventoryItem;
								IDrone drone2 = GlobalSettings.GameState.ThePlayer.Drones.FirstOrDefault((IDrone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u == upgrade));
								if (drone2 != null)
								{
									drone2.RemoveDroneUpgrade(upgrade);
								}
								else
								{
									GlobalSettings.GameState.ThePlayer.Inventory.RemoveInventoryItem(item.InventoryItem);
								}
							}
							else
							{
								GlobalSettings.GameState.ThePlayer.Inventory.RemoveInventoryItem(item.InventoryItem);
							}
						}
						else
						{
							bool flag = false;
							foreach (IInventoryItem item2 in GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy)
							{
								if (item2 == item.InventoryItem)
								{
									GlobalSettings.GameState.ThePlayer.Inventory.RemoveInventoryItem(item.InventoryItem);
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								foreach (IInventoryItem item3 in GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy)
								{
									if (item3 == item.InventoryItem)
									{
										SlotInfo slotByUpgrade = GlobalSettings.GameState.ThePlayer.MyShip.GetSlotByUpgrade((BaseShipUpgrade)item3);
										if (slotByUpgrade != null)
										{
											slotByUpgrade.UnInstallUpgrade();
											UniverseSaveFile.ClearGroup(item3.GroupKey);
										}
										else
										{
											GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.RemoveInventoryItem(item.InventoryItem);
										}
										flag = true;
										break;
									}
								}
							}
							if (!flag)
							{
								int num = 0;
								num++;
							}
						}
					}
					else if (modification is CraftGathererMod)
					{
						GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(CraftingHelper.CraftItem(new CraftableDroneUpgrade(DroneUpgradeFactory.UpgradeDefinitions.First((DroneUpgradeDefinition x) => x.Type == DroneUpgradeType.Gatherer).Name, 8, DroneUpgradeType.Gatherer)));
					}
					else if (modification is CraftGeneratorMod)
					{
						GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(CraftingHelper.CraftItem(new CraftableDroneUpgrade(DroneUpgradeFactory.UpgradeDefinitions.First((DroneUpgradeDefinition x) => x.Type == DroneUpgradeType.Generator).Name, 8, DroneUpgradeType.Generator)));
					}
					else if (modification is CraftTowMod)
					{
						GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(CraftingHelper.CraftItem(new CraftableDroneUpgrade(DroneUpgradeFactory.UpgradeDefinitions.First((DroneUpgradeDefinition x) => x.Type == DroneUpgradeType.Tow).Name, 10, DroneUpgradeType.Tow)));
					}
					else
					{
						modification.ApplyModToTarget();
					}
					if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap + scrapCost <= GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax)
					{
						GlobalSettings.GameState.ThePlayer.Inventory.Scrap += scrapCost;
					}
					else
					{
						GlobalSettings.GameState.ThePlayer.Inventory.Scrap = GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax;
					}
				}
			}
		}
		return false;
	}
}
