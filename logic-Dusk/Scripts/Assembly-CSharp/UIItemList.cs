using System;
using UnityEngine;

public abstract class UIItemList : MonoBehaviour, IUIList
{
	public GameObject itemPrefab;

	protected IUIItem[] itemList;

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
				return itemList.Length;
			}
			return 0;
		}
	}

	public int CurrentPageIndex { get; protected set; }

	public int CurrentHighlightedIndex { get; protected set; }

	protected virtual void Awake()
	{
	}

	public abstract void Refresh();

	public void GotFocus()
	{
		if (CurrentHighlightedIndex == -1 && itemList.Length > 0)
		{
			CurrentHighlightedIndex = 0;
		}
		if (CurrentHighlightedIndex != -1)
		{
			itemList[CurrentHighlightedIndex].Highlight();
		}
	}

	public void LoseFocus()
	{
		if (itemList != null && itemList.Length > 0 && CurrentHighlightedIndex != -1)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
		}
	}

	public bool MoveDown()
	{
		if (itemList != null && itemList.Length > 0)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
			CurrentHighlightedIndex += 1;
			if (CurrentHighlightedIndex >= itemList.Length)
			{
				return true;
			}
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveUp()
	{
		if (itemList != null && itemList.Length > 0)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
			CurrentHighlightedIndex -= 1;
			if (CurrentHighlightedIndex < 0)
			{
				return true;
			}
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveToBottom()
	{
		if (itemList != null && itemList.Length > 0)
		{
			CurrentHighlightedIndex = itemList.Length - 1;
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveToTop()
	{
		if (itemList != null && itemList.Length > 0)
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
		IUIItem[] array = itemList;
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
		if (itemList == null)
		{
			return;
		}
		int num = itemList.Length;
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			if (itemList[num2] != null)
			{
				UnityEngine.Object.Destroy(itemList[num2].UnderlyingGameObject);
			}
		}
		itemList = null;
	}

	public bool RemoveBackendSelectedItem()
	{
		throw new NotImplementedException();
	}

	public void AddBackendItem(IUIItem item)
	{
		throw new NotImplementedException();
	}

	public IUIItem SelectHighlightedItem()
	{
		if (itemList != null && itemList.Length > 0 && CurrentHighlightedIndex >= 0 && CurrentHighlightedIndex <= itemList.Length)
		{
			itemList[CurrentHighlightedIndex].Select();
			return itemList[CurrentHighlightedIndex];
		}
		return null;
	}

	public IUIItem GetHighlightedItem()
	{
		IUIItem[] array = itemList;
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
		IUIItem[] array = itemList;
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
