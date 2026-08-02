using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManagerUI : UIPanelBase
{
	[HideInInspector]
	public UnityEvent OnInventoryPanelOpened = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnInventoryPanelClosed = new UnityEvent();

	[SerializeField]
	private InventoryController inventoryController;

	private List<InventorySlot> inventorySlots = new List<InventorySlot>();

	public bool isActive;

	public bool isOpenedExternal;

	private StoryBoardPanel boardPanel;

	private readonly List<UIPanelBase> registeredPanels = new List<UIPanelBase>();

	private void RegisterToPanel(UIPanelBase panel)
	{
		if (!(panel == null))
		{
			panel.connectedPanels.Add(this);
			registeredPanels.Add(panel);
		}
	}

	private void Start()
	{
		inventorySlots = GetComponentsInChildren<InventorySlot>().ToList();
		RegisterToPanel(Object.FindObjectOfType<CraftPanelUIManager>(includeInactive: true));
		RegisterToPanel(Object.FindObjectOfType<ObjectBuilderUIManager>(includeInactive: true));
		RegisterToPanel(Object.FindObjectOfType<ResearchUIManager>(includeInactive: true));
		RegisterToPanel(Object.FindObjectOfType<GunPanelUIManager>(includeInactive: true));
		RegisterToPanel(Object.FindObjectOfType<ChestUIManager>(includeInactive: true));
		RegisterToPanel(Object.FindObjectOfType<ChemistryTableUIManager>(includeInactive: true));
		boardPanel = Object.FindObjectOfType<StoryBoardPanel>(includeInactive: true);
		RegisterToPanel(boardPanel);
	}

	private void OnDestroy()
	{
		foreach (UIPanelBase registeredPanel in registeredPanels)
		{
			if (registeredPanel != null)
			{
				registeredPanel.connectedPanels.Remove(this);
			}
		}
	}

	private void Update()
	{
	}

	public new void ShowPanel()
	{
		base.ShowPanel();
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.isShowing = true;
		}
		isActive = true;
		if (boardPanel != null)
		{
			boardPanel.HidePanel();
		}
		MainUIManager.isInventoryActive = isActive;
	}

	public new void HidePanel()
	{
		base.HidePanel();
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.isShowing = false;
		}
		isActive = false;
		MainUIManager.isInventoryActive = isActive;
	}
}
