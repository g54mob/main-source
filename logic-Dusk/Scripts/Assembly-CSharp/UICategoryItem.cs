using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICategoryItem : MonoBehaviour, IUIItem
{
	public Image borderImage;

	public Image iconImage;

	public Text label;

	private Image backgroundImage;

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public IInventoryItem ParentItem { get; set; }

	public IInventoryItem InventoryItem { get; set; }

	public List<IModification> ModificationList { get; private set; }

	public bool IsHighlighted { get; private set; }

	public bool IsSelected { get; private set; }

	public bool IsActive { get; private set; }

	public IUIItem AffectedItem { get; set; }

	public Color overrideActiveColor { get; set; }

	private void Awake()
	{
		backgroundImage = base.gameObject.GetComponent<Image>();
	}

	private void Start()
	{
		SetActive();
	}

	private void OnDestroy()
	{
		borderImage = null;
		iconImage = null;
		label = null;
		backgroundImage = null;
	}

	public void HasIcon(bool show)
	{
		if (iconImage != null)
		{
			iconImage.enabled = show;
		}
	}

	public void AddModification(IModification mod)
	{
		if (ModificationList == null)
		{
			ModificationList = new List<IModification>();
		}
		ModificationList.Add(mod);
	}

	public void ClearSelection()
	{
		IsSelected = false;
		ClearHighlight();
	}

	public void ClearHighlight()
	{
		IsHighlighted = false;
		if (!(backgroundImage == null))
		{
			if (!IsSelected)
			{
				Color black = Color.black;
				black.a = 0f;
				backgroundImage.color = black;
			}
			else
			{
				backgroundImage.color = ModificationUI.Instance.selectedItemColor;
			}
		}
	}

	public void Select()
	{
		IsSelected = true;
		backgroundImage.color = ModificationUI.Instance.selectedItemColor;
	}

	public void Highlight()
	{
		IsHighlighted = true;
		if (IsActive)
		{
			if (backgroundImage != null)
			{
				backgroundImage.color = ModificationUI.Instance.highlightedItemColor;
			}
			ModificationUI.Instance.commandHints.SetEnterActive("[ENTER] = Select Category");
		}
		else
		{
			if (backgroundImage != null)
			{
				backgroundImage.color = ModificationUI.Instance.highlightedDisabledItemColor;
			}
			ModificationUI.Instance.commandHints.SetEnterInactive();
		}
		UITooltips.CurrentTooltip.enabled = false;
		UITooltips.CurrentTooltip.label.text = string.Empty;
		if (InventoryItem != null)
		{
			if (InventoryItem is BaseDroneUpgrade)
			{
				UITooltips.CurrentTooltip.label.text = BoardingConfigUi.Instance.helper.FindHelpText(((BaseDroneUpgrade)InventoryItem).CommandValue);
				UITooltips.CurrentTooltip.enabled = true;
			}
			else if (InventoryItem is BaseShipUpgrade)
			{
				string text = BoardingConfigUi.Instance.helper.FindHelpText(((BaseShipUpgrade)InventoryItem).CommandValue);
				if (text == string.Empty)
				{
					text = InventoryItem.Description;
				}
				UITooltips.CurrentTooltip.label.text = text;
				UITooltips.CurrentTooltip.enabled = true;
			}
		}
		else if (ModificationList != null && ModificationList.Count > 0)
		{
			UITooltips.CurrentTooltip.label.text = ModificationList[0].Description;
			UITooltips.CurrentTooltip.enabled = true;
		}
		else
		{
			string text2 = string.Empty;
			if (base.name == "DroneUpgradeCat")
			{
				text2 = "trade drone upgrades";
			}
			else if (base.name == "ShipUpgradeItem")
			{
				text2 = "trade ship upgrades";
			}
			else if (base.name == "FuelItem")
			{
				text2 = "trade fuel";
			}
			UITooltips.CurrentTooltip.label.text = text2;
			UITooltips.CurrentTooltip.enabled = true;
		}
	}

	public void SetInactive()
	{
		IsActive = false;
		label.color = ModificationUI.Instance.disabeledItemTextColor;
		if (iconImage != null)
		{
			iconImage.color = ModificationUI.Instance.disabeledItemTextColor;
		}
		if (IsHighlighted)
		{
			backgroundImage.color = ModificationUI.Instance.highlightedDisabledItemColor;
		}
	}

	public void Dim()
	{
		Color white = Color.white;
		white = ((!IsActive) ? ModificationUI.Instance.disabeledItemTextColor : ((overrideActiveColor.a != 0f) ? overrideActiveColor : ModificationUI.Instance.enabledItemTextColor));
		white.a = 0.5f;
		label.color = white;
	}

	public void UnDim()
	{
		Color white = Color.white;
		white = ((!IsActive) ? ModificationUI.Instance.disabeledItemTextColor : ((overrideActiveColor.a != 0f) ? overrideActiveColor : ModificationUI.Instance.enabledItemTextColor));
		label.color = white;
	}

	public void SetActive()
	{
		IsActive = true;
		if (overrideActiveColor.a == 0f)
		{
			label.color = ModificationUI.Instance.enabledItemTextColor;
		}
		else
		{
			label.color = overrideActiveColor;
		}
		if (iconImage != null)
		{
			iconImage.color = ModificationUI.Instance.enabledItemIconColor;
		}
		if (IsHighlighted)
		{
			backgroundImage.color = ModificationUI.Instance.highlightedItemColor;
		}
	}
}
