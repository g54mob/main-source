using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIModItem : MonoBehaviour, IUIItem, IUIModItem
{
	private int _useCount;

	public Text qtyLabel;

	public Text descriptionLabel;

	public Text costLabel;

	public Image iconImage;

	private Image backgroundImage;

	private int qtyMax;

	private bool showQtyAsStock;

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

	public IUIItem OriginalUIItem { get; set; }

	public bool IsHighlighted { get; private set; }

	public bool IsSelected { get; private set; }

	public bool IsActive { get; private set; }

	public IUIItem AffectedItem { get; set; }

	public int Cost { get; private set; }

	public Color overrideActiveColor { get; set; }

	public int UseCount
	{
		get
		{
			return _useCount;
		}
		set
		{
			_useCount = value;
			RefreshQty();
		}
	}

	public int Tag { get; set; }

	private void Awake()
	{
	}

	public void Init()
	{
		backgroundImage = base.gameObject.GetComponent<Image>();
		qtyLabel.gameObject.SetActive(false);
		if (ModificationList != null)
		{
			ModificationList.Clear();
		}
	}

	protected virtual void OnDestroy()
	{
		qtyLabel = null;
		descriptionLabel = null;
		costLabel = null;
		iconImage = null;
		backgroundImage = null;
	}

	public void HasIcon(bool show)
	{
		iconImage.enabled = show;
	}

	public void SetCost(int cost)
	{
		Cost = cost;
		costLabel.text = cost.ToString();
	}

	public void AddCost(int cost)
	{
		Cost += cost;
		costLabel.text = Cost.ToString();
	}

	public void SetQtyMax(int qty)
	{
		qtyMax = qty;
		if (qty > 1)
		{
			qtyLabel.gameObject.SetActive(true);
		}
		else
		{
			qtyLabel.gameObject.SetActive(false);
		}
		RefreshQty();
	}

	public void SetQtyOfStock(int qty)
	{
		qtyMax = qty;
		showQtyAsStock = true;
		qtyLabel.gameObject.SetActive(true);
		RefreshQty();
	}

	public void SubtractCost(int cost)
	{
		Cost -= cost;
		costLabel.text = Cost.ToString();
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
			backgroundImage.color = ModificationUI.Instance.highlightedItemColor;
			ModificationUI.Instance.commandHints.SetEnterActive();
		}
		else
		{
			backgroundImage.color = ModificationUI.Instance.highlightedDisabledItemColor;
			ModificationUI.Instance.commandHints.SetEnterInactive();
		}
		if (ModificationList != null && ModificationList.Count > 0)
		{
			UITooltips.CurrentTooltip.label.text = ModificationList[0].Description;
			UITooltips.CurrentTooltip.enabled = true;
			return;
		}
		string empty = string.Empty;
		if (base.name == "PropulsionFuel")
		{
			empty = "trade propulsion fuel for scrap";
		}
		else if (base.name == "JumpFuel")
		{
			empty = "trade jump fuel for scrap";
		}
		else if (base.name == "CraftFuel")
		{
			empty = "create jump fuel";
		}
		else if (InventoryItem != null)
		{
			if (InventoryItem is BaseDroneUpgrade)
			{
				empty = BoardingConfigUi.Instance.helper.FindHelpText(((BaseDroneUpgrade)InventoryItem).CommandValue);
			}
			else
			{
				empty = BoardingConfigUi.Instance.helper.FindHelpText(((BaseShipUpgrade)InventoryItem).CommandValue);
				if (empty == string.Empty)
				{
					empty = InventoryItem.Description;
				}
			}
		}
		else
		{
			empty = "trade for scrap";
		}
		UITooltips.CurrentTooltip.label.text = empty;
	}

	public virtual void Dim()
	{
		Dim(false);
	}

	public virtual void Dim(bool includeExtraFields)
	{
		Color white = Color.white;
		white = ((!IsActive) ? ModificationUI.Instance.disabeledItemTextColor : ((overrideActiveColor.a != 0f) ? overrideActiveColor : ModificationUI.Instance.enabledItemTextColor));
		white.a = 0.5f;
		descriptionLabel.color = white;
		if (includeExtraFields)
		{
			qtyLabel.color = white;
			costLabel.color = white;
			iconImage.color = white;
		}
	}

	public virtual void UnDim()
	{
		UnDim(false);
	}

	public virtual void UnDim(bool includeExtraFields)
	{
		Color white = Color.white;
		white = ((!IsActive) ? ModificationUI.Instance.disabeledItemTextColor : ((overrideActiveColor.a != 0f) ? overrideActiveColor : ModificationUI.Instance.enabledItemTextColor));
		descriptionLabel.color = white;
		if (includeExtraFields)
		{
			qtyLabel.color = white;
			costLabel.color = white;
			iconImage.color = white;
		}
	}

	public void SetInactive()
	{
		IsActive = false;
		descriptionLabel.color = ModificationUI.Instance.disabeledItemTextColor;
		costLabel.color = ModificationUI.Instance.disabeledItemTextColor;
		iconImage.color = ModificationUI.Instance.disabeledItemTextColor;
		if (IsHighlighted)
		{
			backgroundImage.color = ModificationUI.Instance.highlightedDisabledItemColor;
		}
	}

	public void SetActive()
	{
		IsActive = true;
		if (overrideActiveColor.a == 0f)
		{
			descriptionLabel.color = ModificationUI.Instance.enabledItemTextColor;
			costLabel.color = ModificationUI.Instance.enabledItemTextColor;
			iconImage.color = ModificationUI.Instance.enabledItemTextColor;
		}
		else
		{
			descriptionLabel.color = overrideActiveColor;
			costLabel.color = overrideActiveColor;
			iconImage.color = overrideActiveColor;
		}
		if (IsHighlighted)
		{
			backgroundImage.color = ModificationUI.Instance.highlightedItemColor;
		}
	}

	private void RefreshQty()
	{
		if (!showQtyAsStock)
		{
			qtyLabel.text = UseCount + "\\" + qtyMax;
		}
		else
		{
			qtyLabel.text = "(" + qtyMax + ")";
		}
	}
}
