using System;
using UnityEngine;

public class UIFuelList : MonoBehaviour, IUIList, IUISellableList
{
	public GameObject itemPrefab;

	public UIModItemConfigurable[] fuelItems;

	protected IInventory sourceInventory;

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
			return 2;
		}
	}

	public int CurrentPageIndex
	{
		get
		{
			return 0;
		}
	}

	public int CurrentHighlightedIndex { get; private set; }

	private void OnDestroy()
	{
		itemPrefab = null;
	}

	public virtual void Refresh()
	{
		if (sourceInventory == null)
		{
			sourceInventory = GlobalSettings.GameState.ThePlayer.Inventory;
		}
		UIModItemConfigurable[] array = fuelItems;
		foreach (UIModItemConfigurable uIModItemConfigurable in array)
		{
			uIModItemConfigurable.Init();
			uIModItemConfigurable.Refresh(sourceInventory);
		}
	}

	public bool PageForward()
	{
		return true;
	}

	public bool PageBack()
	{
		return true;
	}

	public void Show(int pageIdx)
	{
	}

	public void GotFocus()
	{
		if (ItemCount > 0)
		{
			CurrentHighlightedIndex = 0;
			fuelItems[CurrentHighlightedIndex].Highlight();
		}
	}

	public void LoseFocus()
	{
		UIModItemConfigurable[] array = fuelItems;
		foreach (UIModItemConfigurable uIModItemConfigurable in array)
		{
			uIModItemConfigurable.ClearHighlight();
		}
	}

	public bool MoveDown()
	{
		if (ItemCount > 0)
		{
			fuelItems[CurrentHighlightedIndex].ClearHighlight();
			CurrentHighlightedIndex += 1;
			if (CurrentHighlightedIndex >= fuelItems.Length)
			{
				return true;
			}
			fuelItems[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveUp()
	{
		if (ItemCount > 0)
		{
			fuelItems[CurrentHighlightedIndex].ClearHighlight();
			CurrentHighlightedIndex -= 1;
			if (CurrentHighlightedIndex < 0)
			{
				return true;
			}
			fuelItems[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveToBottom()
	{
		if (ItemCount > 0)
		{
			CurrentHighlightedIndex = fuelItems.Length - 1;
			fuelItems[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveToTop()
	{
		if (ItemCount > 0)
		{
			CurrentHighlightedIndex = 0;
			UIModItemConfigurable[] array = fuelItems;
			foreach (UIModItemConfigurable uIModItemConfigurable in array)
			{
				uIModItemConfigurable.ClearHighlight();
			}
			fuelItems[CurrentHighlightedIndex].Highlight();
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
		UIModItemConfigurable[] array = fuelItems;
		foreach (UIModItemConfigurable uIModItemConfigurable in array)
		{
			if (uIModItemConfigurable.IsSelected)
			{
				uIModItemConfigurable.Highlight();
			}
		}
	}

	public bool DeleteHighlightedItem()
	{
		throw new NotImplementedException();
	}

	public void DeleteAllItems()
	{
		throw new NotImplementedException();
	}

	public bool CanBuy(int tag)
	{
		switch (tag)
		{
		case 0:
			if (sourceInventory.Scrap >= 5)
			{
				return true;
			}
			break;
		case 1:
			if (sourceInventory.Scrap >= 15)
			{
				return true;
			}
			break;
		default:
			if (sourceInventory.Scrap >= 20)
			{
				return true;
			}
			break;
		}
		return false;
	}

	public bool RemoveBackendSelectedItem()
	{
		if (fuelItems[CurrentHighlightedIndex].IsActive)
		{
			fuelItems[CurrentHighlightedIndex].Remove();
		}
		Refresh();
		return true;
	}

	public void AddBackendItem(IUIItem item)
	{
		switch (((UIModItem)item).Tag)
		{
		case 0:
			sourceInventory.PropulsionFuelReserve++;
			sourceInventory.Scrap -= 5;
			break;
		case 1:
			sourceInventory.JumpFuel++;
			sourceInventory.Scrap -= 15;
			break;
		case 2:
			sourceInventory.JumpFuel++;
			sourceInventory.Scrap -= 20;
			break;
		}
	}

	public IUIItem SelectHighlightedItem()
	{
		if (CurrentHighlightedIndex >= 0)
		{
			fuelItems[CurrentHighlightedIndex].Select();
			return fuelItems[CurrentHighlightedIndex];
		}
		return null;
	}

	public IUIItem GetHighlightedItem()
	{
		UIModItemConfigurable[] array = fuelItems;
		foreach (UIModItemConfigurable uIModItemConfigurable in array)
		{
			if (uIModItemConfigurable.IsHighlighted)
			{
				return uIModItemConfigurable;
			}
		}
		return null;
	}

	public IUIItem GetSelectedItem()
	{
		UIModItemConfigurable[] array = fuelItems;
		foreach (UIModItemConfigurable uIModItemConfigurable in array)
		{
			if (uIModItemConfigurable.IsSelected)
			{
				return uIModItemConfigurable;
			}
		}
		return null;
	}
}
