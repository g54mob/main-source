using System.Collections.Generic;
using UnityEngine;

public class MinigameSelectionPanel : MenuListPanel
{
	private readonly Dictionary<MenuPanelType, MinigameListItem> listItems = new Dictionary<MenuPanelType, MinigameListItem>(new MenuPanelEqualityComparer());

	public GameObject minigameListItemPrefab;

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		foreach (KeyValuePair<MenuPanelType, MinigameListItem> listItem in listItems)
		{
			listItem.Value.UpdateDynamicDisplay();
		}
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		foreach (KeyValuePair<MenuPanelType, MinigameListItem> listItem in listItems)
		{
			if (MenuManager.Instance.menuPanels.TryGetValue(listItem.Key, out var _))
			{
				MinigameListItem value2 = listItem.Value;
				bool activeInHierarchy = value2.gameObject.activeInHierarchy;
				bool flag = !value2.linkedPanel.isLocked;
				if (!activeInHierarchy && flag)
				{
					value2.gameObject.SetActive(value: true);
				}
				else if (!flag)
				{
					value2.gameObject.SetActive(value: false);
				}
				value2.UpdateItemAvailability();
			}
		}
	}

	public void OnChildPanelBecameAvailbleDuringGame(MenuPanel p)
	{
		if (listItems.TryGetValue(p.panelType, out var value))
		{
			value.SetAlert(state: true);
			AddAlertState();
		}
	}

	public new void CreateItems()
	{
		AddItem(MenuPanelType.MinigameFarming, MenuPanel.gm.energyFarming);
		AddItem(MenuPanelType.MinigameMining, MenuPanel.gm.energyMining);
		AddItem(MenuPanelType.MinigameResearch, MenuPanel.gm.energyResearch);
		AddItem(MenuPanelType.MinigameWater, MenuPanel.gm.energyWater);
		AddItem(MenuPanelType.MinigameDice, MenuPanel.gm.energyDice);
		AddItem(MenuPanelType.MinigameWood, MenuPanel.gm.energyWood);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		foreach (KeyValuePair<MenuPanelType, MinigameListItem> listItem in listItems)
		{
			listItem.Value.ReloadLabels();
		}
	}

	private void AddItem(MenuPanelType panelType, EnergyTracker energyTracker)
	{
		MinigameListItem component = MenuManager.GetMenuObject(minigameListItemPrefab, layoutGroup.transform).GetComponent<MinigameListItem>();
		component.LoadPanel(panelType, energyTracker);
		component.playDelegate = OnPlayPressed;
		listItems[panelType] = component;
	}

	private void OnPlayPressed(MinigameListItem t)
	{
		t.SetAlert(state: false);
		if (MenuManager.Instance.menuPanels.TryGetValue(t.panelType, out var value))
		{
			value.ManuallyOpen();
		}
	}

	public override bool ShouldBeInAlertState()
	{
		foreach (KeyValuePair<MenuPanelType, MinigameListItem> listItem in listItems)
		{
			if (listItem.Value.linkedPanel.alertStateSelf)
			{
				return true;
			}
		}
		return false;
	}

	public override bool ShouldBeAvailable()
	{
		return false;
	}
}
