using UnityEngine;

public class UICraftingList : MonoBehaviour, IUIList
{
	public RectTransform ScrollRectTransform;

	public UIUpgradeItem[] craftingItems;

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
			if (craftingItems != null)
			{
				return craftingItems.Length;
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

	public int CurrentHighlightedIndex { get; protected set; }

	public virtual void Refresh()
	{
		CurrentHighlightedIndex = -1;
		if (craftingItems != null && craftingItems.Length > 0)
		{
			craftingItems[0].Init();
			craftingItems[1].Init();
			craftingItems[2].Init();
			if (craftingItems[0].ModificationList == null || craftingItems[0].ModificationList.Count == 0)
			{
				craftingItems[0].AddModification(new CraftGathererMod());
			}
			if (craftingItems[1].ModificationList == null || craftingItems[1].ModificationList.Count == 0)
			{
				craftingItems[1].AddModification(new CraftGeneratorMod());
			}
			if (craftingItems[2].ModificationList == null || craftingItems[2].ModificationList.Count == 0)
			{
				craftingItems[2].AddModification(new CraftTowMod());
			}
			CurrentHighlightedIndex = 0;
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
		if (CurrentHighlightedIndex == -1 && craftingItems.Length > 0)
		{
			CurrentHighlightedIndex = 0;
		}
		if (CurrentHighlightedIndex != -1)
		{
			craftingItems[CurrentHighlightedIndex].Highlight();
		}
	}

	public void LoseFocus()
	{
		if (CurrentHighlightedIndex != -1)
		{
			craftingItems[CurrentHighlightedIndex].ClearHighlight();
		}
	}

	public bool MoveDown()
	{
		craftingItems[CurrentHighlightedIndex].ClearHighlight();
		CurrentHighlightedIndex += 1;
		if (CurrentHighlightedIndex >= craftingItems.Length)
		{
			return true;
		}
		craftingItems[CurrentHighlightedIndex].Highlight();
		return false;
	}

	public bool MoveUp()
	{
		craftingItems[CurrentHighlightedIndex].ClearHighlight();
		CurrentHighlightedIndex -= 1;
		if (CurrentHighlightedIndex < 0)
		{
			return true;
		}
		craftingItems[CurrentHighlightedIndex].Highlight();
		return false;
	}

	public bool MoveToBottom()
	{
		CurrentHighlightedIndex = craftingItems.Length - 1;
		craftingItems[CurrentHighlightedIndex].Highlight();
		return false;
	}

	public bool MoveToTop()
	{
		CurrentHighlightedIndex = 0;
		craftingItems[CurrentHighlightedIndex].Highlight();
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
		UIUpgradeItem[] array = craftingItems;
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
		IUIItem selectedItem = GetSelectedItem();
		if (selectedItem != null)
		{
			Object.Destroy(selectedItem.UnderlyingGameObject);
		}
		return true;
	}

	public void DeleteAllItems()
	{
		if (craftingItems != null)
		{
			int num = craftingItems.Length;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				Object.Destroy(craftingItems[num2].UnderlyingGameObject);
			}
			craftingItems = null;
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
			craftingItems[CurrentHighlightedIndex].Select();
			return craftingItems[CurrentHighlightedIndex];
		}
		return null;
	}

	public IUIItem GetHighlightedItem()
	{
		UIUpgradeItem[] array = craftingItems;
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
		UIUpgradeItem[] array = craftingItems;
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
