using UnityEngine;
using UnityEngine.UI;

public class HelpMenuEntrySlot : MonoBehaviour
{
	public Image selectedBorder;

	public Image cursorBorder;

	private Text _addressLabel;

	private Text _description;

	private string _myAddressText;

	private bool _initialized;

	public bool IsSelected
	{
		get
		{
			return selectedBorder.gameObject.activeInHierarchy;
		}
	}

	public bool IsCursorHere
	{
		get
		{
			return cursorBorder.gameObject.activeInHierarchy;
		}
	}

	public bool IsVisible
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
		set
		{
			base.gameObject.SetActive(value);
		}
	}

	public HelpManualMenuItem MenuItem { get; private set; }

	private void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		Transform transform = base.transform.FindChild("AddressLabel");
		if (transform != null)
		{
			_addressLabel = transform.gameObject.GetComponent<Text>();
		}
		transform = base.transform.FindChild("Description");
		if (transform != null)
		{
			_description = transform.gameObject.GetComponent<Text>();
		}
		if (_description == null || selectedBorder == null || cursorBorder == null || _addressLabel == null)
		{
			Debug.LogError("HelpMenuEntrySlot did not resolve all fields properly");
		}
		else
		{
			_description.text = string.Empty;
			_myAddressText = _addressLabel.text;
			_addressLabel.text = string.Empty;
		}
		_initialized = true;
	}

	public void SetMenuItem(HelpManualMenuItem menuItem)
	{
		if (menuItem == null)
		{
			MenuItem = null;
			_description.text = string.Empty;
			IsVisible = false;
		}
		else
		{
			MenuItem = menuItem;
			Color32 color = HelpManualScript.Instance.MenuItemColor;
			if (menuItem.IsDimmed)
			{
				color = Color.gray;
			}
			string text = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
			string text2 = string.Empty;
			if (menuItem.ChangedSinceLastView)
			{
				text2 = "*";
			}
			_description.text = "<color=#" + text + ">" + menuItem.DisplayText + " " + text2 + "</color>";
			IsVisible = true;
			_addressLabel.text = _myAddressText;
		}
		SetIsSelected(false);
		SetCursorHere(false);
	}

	public void SetIsSelected(bool isSelected)
	{
		if (!_initialized)
		{
			Initialize();
		}
		selectedBorder.gameObject.SetActive(isSelected);
	}

	public void SetCursorHere(bool cursorIsHere)
	{
		if (!_initialized)
		{
			Initialize();
		}
		if (IsVisible)
		{
			cursorBorder.gameObject.SetActive(cursorIsHere);
		}
	}
}
