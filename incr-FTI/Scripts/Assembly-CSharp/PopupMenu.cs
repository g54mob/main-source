using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopupMenu : MenuListPanel
{
	public GameObject popupItemPrefab;

	public GameObject popupNavItemPrefab;

	private int rowCount;

	public RectTransform viewTransform;

	private List<PopupMenuItem> menuItems = new List<PopupMenuItem>(5);

	public bool HasRows()
	{
		return rowCount > 0;
	}

	private PopupMenuItem AddLabelButton(string text)
	{
		PopupMenuItem component = MenuManager.GetMenuObject(popupItemPrefab, layoutGroup.transform).GetComponent<PopupMenuItem>();
		component.label.text = text;
		rowCount++;
		menuItems.Add(component);
		return component;
	}

	public PopupMenuItem AddLabelButton(string text, object loadedObject, UnityAction<PopupMenuItem> del)
	{
		PopupMenuItem popupMenuItem = AddLabelButton(text);
		popupMenuItem.loadedObject = loadedObject;
		popupMenuItem.onClickedDelegate = del;
		popupMenuItem.buttonState = CustomButtonState.Default;
		return popupMenuItem;
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		foreach (PopupMenuItem menuItem in menuItems)
		{
			if (menuItem is PopupNavigationButton popupNavigationButton)
			{
				popupNavigationButton.costGrid.UpdateDynamicAffordability();
			}
		}
	}

	public PopupNavigationButton AddNavigationButton(string text, object loadedObject, UnityAction<PopupMenuItem> del)
	{
		PopupNavigationButton component = MenuManager.GetMenuObject(popupNavItemPrefab, layoutGroup.transform).GetComponent<PopupNavigationButton>();
		component.highlightMargin = 1f;
		component.label.text = text;
		rowCount++;
		menuItems.Add(component);
		component.loadedObject = loadedObject;
		component.onClickedDelegate = del;
		component.buttonState = CustomButtonState.Background;
		CostGrid costGrid = component.costGrid;
		if (loadedObject is MenuPanelType t)
		{
			component.iconImage.sprite = IconManager.SpriteForMenuPanel(t);
			costGrid.gameObject.SetActive(value: false);
		}
		else if (loadedObject is TradeMode tradeMode)
		{
			component.iconImage.sprite = IconManager.SpriteForTradeMode(tradeMode);
			component.iconImage.enabled = tradeMode != TradeMode.None;
			costGrid.gameObject.SetActive(value: false);
		}
		else if (loadedObject is StateManager stateManager)
		{
			component.label.text = string.Empty;
			if (stateManager.producingBuilding != null)
			{
				component.iconImage.sprite = IconManager.SpriteForBuilding(stateManager.producingBuilding.type);
			}
			else
			{
				MenuPanel menuPanel = MenuManager.Instance.MenuPanelForState(stateManager);
				if (null != menuPanel)
				{
					component.iconImage.sprite = IconManager.SpriteForMenuPanel(menuPanel.panelType);
				}
				else
				{
					component.iconImage.sprite = IconManager.SpriteForEntity(stateManager.AsEntity());
				}
			}
			foreach (ItemRateData item in stateManager.input)
			{
				costGrid.AddInput(item);
			}
			costGrid.AddSpacerArrow();
			foreach (ItemRateData item2 in stateManager.output)
			{
				if (!(item2.state is ItemState { type: ItemType.TownExperiencePoint }))
				{
					costGrid.AddOutput(item2);
				}
			}
		}
		else if (loadedObject is ConsumableState)
		{
			component.iconImage.sprite = IconManager.Instance.infoButton;
		}
		return component;
	}

	public void ClearPopup()
	{
		foreach (Transform item in layoutGroup.transform)
		{
			Object.Destroy(item.gameObject);
		}
		rowCount = 0;
		menuItems.Clear();
	}

	public override bool IsFixedPosition()
	{
		return true;
	}

	public void Center()
	{
	}

	public void ResizeHeight(int maxRows = 10)
	{
		int num = Mathf.Clamp(rowCount, 0, maxRows);
		int num2 = 10;
		int num3 = 46;
		int num4 = 10;
		viewTransform.SetHeight(num2 + num4 + num * num3);
	}
}
