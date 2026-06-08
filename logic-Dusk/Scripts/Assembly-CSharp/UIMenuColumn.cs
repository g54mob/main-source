using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuColumn : MonoBehaviour
{
	public bool IsValueColumn;

	public GameObject itemPrefab;

	public GameObject spacerPrefab;

	public Text commentsLabel;

	public Color HighlightedTextColor = Color.black;

	public Color UnhighlightedTextColor = Color.green;

	public Color SpecialUnhighlightedTextColor = Color.yellow;

	public Color DisabledColor = Color.gray;

	public Color SelectionBarColor = Color.green;

	private List<UIMenuItem> menuItemList;

	public int HighlightedIndex { get; private set; }

	public void Awake()
	{
		if (commentsLabel != null)
		{
			commentsLabel.text = string.Empty;
		}
	}

	private void OnDestroy()
	{
		itemPrefab = null;
		spacerPrefab = null;
		commentsLabel = null;
	}

	public void AddMenuItem(DuskersMenuItem menuItem)
	{
		UIMenuItem uIMenuItem = AddEmptyItem();
		uIMenuItem.IsEmpty = false;
		uIMenuItem.underlyingMenuItem = menuItem;
		if (!IsValueColumn || menuItem.MenuType != DuskersMenuItem.MenuTypeEnum.Slider)
		{
			RefreshItemText(uIMenuItem);
			if (!menuItem.Disabled)
			{
				if (menuItem.SpecialHighlight)
				{
					uIMenuItem.label.color = SpecialUnhighlightedTextColor;
				}
				else
				{
					uIMenuItem.label.color = UnhighlightedTextColor;
				}
			}
			else
			{
				uIMenuItem.label.color = DisabledColor;
			}
		}
		else
		{
			((UIMenuValueItem)uIMenuItem).SetIsSlider();
			uIMenuItem.SetValue(menuItem.SliderValue * menuItem.SliderValueFactor);
			uIMenuItem.LoseFocus();
			if (!menuItem.Disabled)
			{
				if (menuItem.SpecialHighlight)
				{
					uIMenuItem.label.color = SpecialUnhighlightedTextColor;
				}
				else
				{
					uIMenuItem.label.color = UnhighlightedTextColor;
				}
			}
			else
			{
				uIMenuItem.label.color = DisabledColor;
			}
		}
		uIMenuItem.ShowValue();
	}

	public UIMenuItem AddEmptyItem()
	{
		return AddEmptyItem(false);
	}

	public UIMenuItem AddEmptyItem(bool ignoreFocus)
	{
		if (menuItemList == null)
		{
			menuItemList = new List<UIMenuItem>();
		}
		GameObject gameObject = Object.Instantiate(itemPrefab);
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localScale = Vector3.one;
		UIMenuItem component = gameObject.GetComponent<UIMenuItem>();
		menuItemList.Add(component);
		component.HideBar();
		component.HideValue();
		component.IgnoreFocus = ignoreFocus;
		component.gameObject.SetActive(false);
		component.IsEmpty = true;
		return component;
	}

	public void ShowItem(int index)
	{
		if (index < menuItemList.Count)
		{
			menuItemList[index].gameObject.SetActive(true);
		}
	}

	public void MoveToTop()
	{
		HighlightBar(0, -1);
	}

	public void MoveToBottom()
	{
		HighlightBar(menuItemList.Count - 1, -1);
	}

	public void MoveUp()
	{
		HighlightBar(HighlightedIndex - 1, 2);
	}

	public void MoveDown()
	{
		HighlightBar(HighlightedIndex + 1, 1);
	}

	public void HighlightBar(int newIndex)
	{
		HighlightBar(newIndex, -1);
	}

	public void HighlightBar(int newIndex, int direction)
	{
		menuItemList[HighlightedIndex].HideBar();
		menuItemList[HighlightedIndex].LoseFocus();
		if (menuItemList[HighlightedIndex].underlyingMenuItem == null || !menuItemList[HighlightedIndex].underlyingMenuItem.Disabled)
		{
			if (menuItemList[HighlightedIndex].underlyingMenuItem != null && menuItemList[HighlightedIndex].underlyingMenuItem.SpecialHighlight)
			{
				menuItemList[HighlightedIndex].label.color = SpecialUnhighlightedTextColor;
			}
			else
			{
				menuItemList[HighlightedIndex].label.color = UnhighlightedTextColor;
			}
		}
		else
		{
			menuItemList[HighlightedIndex].label.color = DisabledColor;
		}
		bool flag = false;
		if (direction > -1)
		{
			do
			{
				flag = false;
				if (newIndex < 0)
				{
					newIndex = menuItemList.Count - 1;
				}
				else if (newIndex >= menuItemList.Count)
				{
					newIndex = 0;
				}
				if (menuItemList[newIndex].IgnoreFocus)
				{
					switch (direction)
					{
					case 1:
						newIndex++;
						break;
					case 2:
						newIndex--;
						break;
					}
					flag = true;
				}
			}
			while (flag);
		}
		HighlightedIndex = newIndex;
		if (!menuItemList[HighlightedIndex].IsEmpty)
		{
			menuItemList[HighlightedIndex].ShowBar();
			menuItemList[HighlightedIndex].label.color = HighlightedTextColor;
			menuItemList[HighlightedIndex].SetFocus();
			if (commentsLabel != null)
			{
				commentsLabel.text = menuItemList[HighlightedIndex].underlyingMenuItem.Description;
			}
		}
		else if (commentsLabel != null)
		{
			commentsLabel.text = string.Empty;
		}
	}

	public UIMenuItem GetHighlightedItem()
	{
		if (HighlightedIndex < 0 || HighlightedIndex >= menuItemList.Count)
		{
			return null;
		}
		return menuItemList[HighlightedIndex];
	}

	public void ClearItems()
	{
		if (menuItemList != null)
		{
			int count = menuItemList.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				Object.Destroy(menuItemList[num].gameObject);
			}
			menuItemList.Clear();
			HighlightedIndex = 0;
		}
	}

	public void RemoveItem(DuskersMenuItem menuItem)
	{
		int count = menuItemList.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (menuItemList[num].underlyingMenuItem == menuItem)
			{
				Object.Destroy(menuItemList[num].gameObject);
				menuItemList.RemoveAt(num);
			}
		}
	}

	public void RefreshItem(int index)
	{
		if (index >= 0 && index < menuItemList.Count)
		{
			RefreshItemText(menuItemList[index]);
		}
	}

	public void RefreshItem<T>(int index, T value)
	{
		if (index >= 0 && index < menuItemList.Count)
		{
			menuItemList[index].SetValue(value);
		}
	}

	private void RefreshItemText(UIMenuItem item)
	{
		if (item.underlyingMenuItem != null)
		{
			if (!IsValueColumn)
			{
				item.SetValue(item.underlyingMenuItem.Label);
			}
			else
			{
				item.SetValue(item.underlyingMenuItem.TextValue);
			}
		}
	}

	public void RefreshItemColor(int index)
	{
		if (index < 0 || index >= menuItemList.Count)
		{
			return;
		}
		UIMenuItem uIMenuItem = menuItemList[index];
		if (!uIMenuItem.IsHighlighted && uIMenuItem.IsActive)
		{
			if (uIMenuItem.underlyingMenuItem != null && uIMenuItem.underlyingMenuItem.SpecialHighlight)
			{
				uIMenuItem.label.color = SpecialUnhighlightedTextColor;
			}
			else
			{
				uIMenuItem.label.color = UnhighlightedTextColor;
			}
		}
	}
}
