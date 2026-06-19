using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropdownUIElement : UIelement, IScrollable
{
	public UIScrollWindow scrollWindow;

	public GameObject container;

	public GameObject scrollArea;

	public DropdownEntry entryPrefab;

	public List<UIelement> entries;

	private List<DropdownEntryData> entryDatas;

	public float additionalSpaceBetweenEntries;

	public BoxCollider boxCollider;

	public DropdownEntry activeEntry;

	public bool localizeEntries;

	public bool localizeSubText;

	public int activeId;

	public UnityEvent OnActiveEntryChanged;

	public ButtonUIElement button;

	[SerializeField]
	private GameObject _masks;

	public bool isOpen => container.activeSelf;

	public void HideDropdownList(bool selectButton)
	{
		container.SetActive(value: false);
		_masks.SetActive(value: false);
		boxCollider.enabled = false;
		if (selectButton)
		{
			button.Select();
		}
	}

	public void ToggleDropdownList()
	{
		bool flag = !container.activeSelf;
		container.SetActive(flag);
		boxCollider.enabled = flag;
		_masks.SetActive(flag);
		if (flag)
		{
			InitList();
			if (entries.Count > 0)
			{
				entries[0].Select();
			}
			Manager.input.SetActiveDropdown(this);
		}
	}

	public void SetEntryDatas(List<DropdownEntryData> entryDatas)
	{
		this.entryDatas = entryDatas;
	}

	public void OnEntryClicked(DropdownEntry entry)
	{
		activeEntry = entry;
		activeId = entry.entryData.id;
		HideDropdownList(selectButton: true);
		OnActiveEntryChanged?.Invoke();
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		base.OnLeftClicked(mod1, mod2);
		HideDropdownList(selectButton: false);
	}

	public void InitList()
	{
		foreach (UIelement entry in entries)
		{
			entry.gameObject.SetActive(value: false);
		}
		for (int i = entries.Count; i < entryDatas.Count; i++)
		{
			DropdownEntry dropdownEntry = Object.Instantiate(entryPrefab, scrollArea.transform);
			dropdownEntry.gameObject.SetActive(value: false);
			dropdownEntry.text.localize = localizeEntries;
			dropdownEntry.subText.localize = localizeSubText;
			entries.Add(dropdownEntry);
		}
		float previousBottom = 0f;
		for (int j = 0; j < entryDatas.Count; j++)
		{
			DropdownEntry dropdownEntry2 = entries[j] as DropdownEntry;
			dropdownEntry2.Init(this, entryDatas[j], activeEntry != null && activeEntry.entryData.id == dropdownEntry2.entryData.id);
			if (j > 0)
			{
				entries[j - 1].bottomUIElements.Add(dropdownEntry2);
				dropdownEntry2.topUIElements.Add(entries[j - 1]);
			}
			previousBottom = UIManager.PositionElementBeneath(dropdownEntry2.transform, previousBottom, dropdownEntry2.background.size.y, additionalSpaceBetweenEntries);
			dropdownEntry2.gameObject.SetActive(value: true);
		}
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public IEnumerable<UIelement> GetChildElements()
	{
		return entries;
	}

	public void SelectFirstEntry()
	{
		OnEntryClicked(entries[0] as DropdownEntry);
	}

	private DropdownEntry GetBottomEntry()
	{
		for (int num = entries.Count - 1; num >= 0; num--)
		{
			if (entries[num].gameObject.activeSelf)
			{
				return entries[num] as DropdownEntry;
			}
		}
		return null;
	}

	private DropdownEntry GetTopEntry()
	{
		for (int i = 0; i < entries.Count; i++)
		{
			if (entries[i].gameObject.activeSelf)
			{
				return entries[i] as DropdownEntry;
			}
		}
		return null;
	}

	public bool IsBottomElementSelected()
	{
		DropdownEntry bottomEntry = GetBottomEntry();
		if (bottomEntry != null)
		{
			return Manager.ui.currentSelectedUIElement == bottomEntry;
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		DropdownEntry topEntry = GetTopEntry();
		if (topEntry != null)
		{
			return Manager.ui.currentSelectedUIElement == topEntry;
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		DropdownEntry bottomEntry = GetBottomEntry();
		DropdownEntry topEntry = GetTopEntry();
		if (topEntry != null && bottomEntry != null)
		{
			return topEntry.GetTopPos() - bottomEntry.GetBottomPos();
		}
		return 0f;
	}

	public UIScrollWindow GetScrollWindow()
	{
		return scrollWindow;
	}
}
