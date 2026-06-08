using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShipItem : MonoBehaviour, IUIItem, IUIModItem
{
	public Text descriptionLabel;

	public Image border;

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

	private void Awake()
	{
		backgroundImage = base.gameObject.GetComponent<Image>();
	}

	private void Start()
	{
		SetActive();
	}

	public void MarkEmpty(int idx)
	{
		descriptionLabel.text = string.Empty;
		if (ModificationList != null)
		{
			ModificationList.Clear();
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
		UpdateToolTip();
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
		UpdateToolTip();
	}

	public void Dim()
	{
		Color white = Color.white;
		white.a = 0.5f;
		descriptionLabel.color = white;
	}

	public void UnDim()
	{
		Color white = Color.white;
		descriptionLabel.color = white;
	}

	public void SetActive()
	{
		IsActive = true;
		border.color = ModificationUI.Instance.selectedBorderColor;
		if (IsHighlighted)
		{
			backgroundImage.color = ModificationUI.Instance.highlightedItemColor;
		}
	}

	public void SetInactive()
	{
		IsActive = false;
		border.color = ModificationUI.Instance.deSelectedBorderColor;
		if (IsHighlighted)
		{
			backgroundImage.color = ModificationUI.Instance.highlightedDisabledItemColor;
		}
	}

	private void UpdateToolTip()
	{
		UITooltips.CurrentTooltip.label.text = "Modify element of ship";
		UITooltips.CurrentTooltip.enabled = true;
	}
}
