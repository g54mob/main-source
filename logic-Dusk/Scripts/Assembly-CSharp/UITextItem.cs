using UnityEngine;
using UnityEngine.UI;

public class UITextItem : MonoBehaviour, IUIItem
{
	public Text label;

	public Image border;

	public Color selectedTextDimColor = Color.gray;

	public Color unselectedTextDimColor = Color.gray;

	public Color selectedItemColor = Color.blue;

	public Color clearItemColor = Color.black;

	public Color selectedBorderColor = Color.blue;

	public Color clearBorderColor = Color.blue;

	public Color highlightedItemColor = Color.yellow;

	public Color highlightedDisabledItemColor = Color.white;

	public Color clearBackgroundColor = Color.black;

	private Image backgroundImage;

	private string baseText = string.Empty;

	private string modifierIndicatorText = string.Empty;

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public IInventoryItem ParentItem { get; set; }

	public IInventoryItem InventoryItem { get; set; }

	public IUIItem AffectedItem { get; set; }

	public bool IsHighlighted { get; private set; }

	public bool IsSelected { get; private set; }

	public bool IsActive { get; private set; }

	public bool IsDimmed { get; private set; }

	public bool IsChanged { get; private set; }

	public bool HasChangeBeenSeen { get; private set; }

	public bool CanBeShown { get; set; }

	public string EntryKey { get; set; }

	public EntryTypeEnum EntryType { get; set; }

	private void Awake()
	{
		backgroundImage = base.gameObject.GetComponent<Image>();
		backgroundImage.color = clearBackgroundColor;
	}

	public void SetText(string text, string modifierText)
	{
		baseText = text;
		modifierIndicatorText = "<color=#FFF000>" + modifierText + "</color>";
		if (label != null)
		{
			label.text = baseText;
		}
	}

	public void ClearSelection()
	{
		IsSelected = false;
		ClearHighlight();
		if (label != null && IsDimmed)
		{
			label.color = unselectedTextDimColor;
		}
	}

	public void ClearHighlight()
	{
		IsHighlighted = false;
		if (!IsSelected)
		{
			Color color = clearBackgroundColor;
			backgroundImage.color = color;
		}
		else
		{
			backgroundImage.color = selectedItemColor;
		}
		if (label != null && IsDimmed)
		{
			label.color = unselectedTextDimColor;
		}
	}

	public void Select()
	{
		IsSelected = true;
		backgroundImage.color = selectedItemColor;
		if (label != null && IsDimmed)
		{
			label.color = selectedTextDimColor;
		}
		if (IsChanged)
		{
			HasChangeBeenSeen = true;
		}
	}

	public void Highlight()
	{
		IsHighlighted = true;
		if (IsActive)
		{
			backgroundImage.color = highlightedItemColor;
			ModificationUI.Instance.commandHints.SetEnterActive();
		}
		else
		{
			backgroundImage.color = highlightedDisabledItemColor;
			ModificationUI.Instance.commandHints.SetEnterInactive();
		}
		if (label != null && IsDimmed)
		{
			label.color = selectedTextDimColor;
		}
		if (IsChanged)
		{
			HasChangeBeenSeen = true;
		}
	}

	public void SetActive()
	{
		IsActive = true;
		if (border != null)
		{
			border.color = selectedBorderColor;
		}
		if (label != null)
		{
			if (IsHighlighted)
			{
				backgroundImage.color = highlightedItemColor;
			}
			if (IsDimmed)
			{
				label.color = selectedTextDimColor;
			}
		}
		if (IsChanged)
		{
			HasChangeBeenSeen = true;
		}
	}

	public void SetInactive()
	{
		IsActive = false;
		if (border != null)
		{
			border.color = clearBorderColor;
		}
		if (IsHighlighted)
		{
			backgroundImage.color = highlightedDisabledItemColor;
		}
		if (IsDimmed)
		{
			label.color = unselectedTextDimColor;
		}
	}

	public void Dim()
	{
		IsDimmed = true;
		if (label != null)
		{
			if (IsHighlighted || IsSelected || IsActive)
			{
				label.color = selectedTextDimColor;
			}
			else
			{
				label.color = unselectedTextDimColor;
			}
		}
	}

	public void UnDim()
	{
		IsDimmed = false;
		if (label != null)
		{
			label.color = Color.white;
		}
	}

	public void SetIsChanged()
	{
		IsChanged = true;
		if (label != null)
		{
			label.text = baseText + " " + modifierIndicatorText;
		}
	}

	public void ClearIsChanged()
	{
		IsChanged = false;
		if (label != null)
		{
			label.text = baseText;
		}
	}

	public void Show()
	{
		UnderlyingGameObject.SetActive(true);
	}

	public void Hide()
	{
		UnderlyingGameObject.SetActive(false);
	}
}
