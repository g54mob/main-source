using System;
using UnityEngine;

public class UICategoryList : MonoBehaviour, IUIList
{
	public bool DisableCategoryDisable;

	public UICategoryItem[] listItems;

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
			if (listItems != null)
			{
				return listItems.Length;
			}
			return 0;
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

	public void Refresh()
	{
		CurrentHighlightedIndex = -1;
		if (!DisableCategoryDisable && listItems != null)
		{
			if (ModificationUI.Instance.DroneList.ItemCount == 0)
			{
				listItems[0].SetInactive();
			}
			else
			{
				listItems[0].SetActive();
			}
			if (ModificationUI.Instance.DroneUpgradeList.ItemCount == 0)
			{
				listItems[1].SetInactive();
			}
			else
			{
				listItems[1].SetActive();
			}
			if (ModificationUI.Instance.ShipList.ItemCount == 0)
			{
				listItems[2].SetInactive();
			}
			else
			{
				listItems[2].SetActive();
			}
			if (ModificationUI.Instance.ShipUpgradeList.ItemCount == 0)
			{
				listItems[3].SetInactive();
			}
			else
			{
				listItems[3].SetActive();
			}
			if (listItems.Length > 4)
			{
				listItems[4].SetActive();
			}
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
		if (CurrentHighlightedIndex == -1 && listItems.Length > 0)
		{
			CurrentHighlightedIndex = 0;
		}
		if (CurrentHighlightedIndex != -1)
		{
			listItems[CurrentHighlightedIndex].Highlight();
		}
	}

	public void LoseFocus()
	{
		if (CurrentHighlightedIndex != -1)
		{
			listItems[CurrentHighlightedIndex].ClearHighlight();
		}
	}

	public bool MoveDown()
	{
		listItems[CurrentHighlightedIndex].ClearHighlight();
		CurrentHighlightedIndex += 1;
		if (CurrentHighlightedIndex >= listItems.Length)
		{
			return true;
		}
		listItems[CurrentHighlightedIndex].Highlight();
		return false;
	}

	public bool MoveUp()
	{
		listItems[CurrentHighlightedIndex].ClearHighlight();
		CurrentHighlightedIndex -= 1;
		if (CurrentHighlightedIndex < 0)
		{
			return true;
		}
		listItems[CurrentHighlightedIndex].Highlight();
		return false;
	}

	public bool MoveToBottom()
	{
		CurrentHighlightedIndex = listItems.Length - 1;
		listItems[CurrentHighlightedIndex].Highlight();
		return false;
	}

	public bool MoveToTop()
	{
		CurrentHighlightedIndex = 0;
		listItems[CurrentHighlightedIndex].Highlight();
		return false;
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
		UICategoryItem[] array = listItems;
		foreach (IUIItem iUIItem in array)
		{
			if (iUIItem.IsSelected)
			{
				break;
			}
			CurrentHighlightedIndex += 1;
		}
		selectedItem.Highlight();
	}

	public bool DeleteHighlightedItem()
	{
		throw new NotImplementedException();
	}

	public void DeleteAllItems()
	{
		if (listItems != null)
		{
			int num = listItems.Length;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				UnityEngine.Object.Destroy(listItems[num2].UnderlyingGameObject);
			}
			listItems = null;
		}
	}

	public bool RemoveBackendSelectedItem()
	{
		return false;
	}

	public void AddBackendItem(IUIItem item)
	{
	}

	public IUIItem SelectHighlightedItem()
	{
		if (CurrentHighlightedIndex >= 0)
		{
			listItems[CurrentHighlightedIndex].Select();
			return listItems[CurrentHighlightedIndex];
		}
		return null;
	}

	public IUIItem GetHighlightedItem()
	{
		UICategoryItem[] array = listItems;
		foreach (IUIItem iUIItem in array)
		{
			if (iUIItem.IsHighlighted)
			{
				return iUIItem;
			}
		}
		return null;
	}

	public IUIItem GetSelectedItem()
	{
		UICategoryItem[] array = listItems;
		foreach (IUIItem iUIItem in array)
		{
			if (iUIItem.IsSelected)
			{
				return iUIItem;
			}
		}
		return null;
	}
}
