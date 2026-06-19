using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine.Events;

public class RadicalJoinGameMenu_JoinMethodDropdown : RadicalMenuOption
{
	[Serializable]
	private struct JoinMethodEntries
	{
		public string name;

		public RadicalJoinGameMenu.JoinMethod joinMethod;

		public JoinMethodEntries(string name, RadicalJoinGameMenu.JoinMethod joinMethod)
		{
			this.name = name;
			this.joinMethod = joinMethod;
		}
	}

	public DropdownUIElement dropdown;

	public PugText textResult;

	public UnityEvent<RadicalJoinGameMenu.JoinMethod> onEntryChanged;

	private JoinMethodEntries[] _options = new JoinMethodEntries[2]
	{
		new JoinMethodEntries("Menu/JoinWithGameID", RadicalJoinGameMenu.JoinMethod.ID),
		new JoinMethodEntries("Menu/JoinWithIP", RadicalJoinGameMenu.JoinMethod.IP)
	};

	protected override void Awake()
	{
		base.Awake();
		List<DropdownEntryData> entryDatas = GetEntryDatas();
		if (entryDatas.Count <= 1)
		{
			dropdown.button.gameObject.SetActive(value: false);
		}
		dropdown.SetEntryDatas(entryDatas);
		dropdown.InitList();
		dropdown.SelectFirstEntry();
	}

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		dropdown.HideDropdownList(selectButton: false);
	}

	public void OnActiveEntryChanged()
	{
		if (dropdown.activeEntry != null)
		{
			textResult.Render(dropdown.activeEntry.entryData.textStringToShow);
			onEntryChanged?.Invoke(_options[dropdown.activeEntry.entryData.id].joinMethod);
		}
	}

	public override void OnSelected()
	{
		base.OnSelected();
		dropdown.button.Select();
	}

	public override bool NavigateInternally(Direction.Id id)
	{
		UIelement uIelement = null;
		if (!dropdown.isOpen)
		{
			uIelement = GetAdjacentUIElement(id, dropdown.button.transform.position);
		}
		else if (Manager.ui.currentSelectedUIElement != null)
		{
			uIelement = Manager.ui.currentSelectedUIElement.GetAdjacentUIElement(id, Manager.ui.currentSelectedUIElement.transform.position);
		}
		if (uIelement != null)
		{
			uIelement.Select();
			return true;
		}
		return false;
	}

	public override void OnActivated()
	{
		base.OnActivated();
		UIelement currentSelectedUIElement = Manager.ui.currentSelectedUIElement;
		if (currentSelectedUIElement != null)
		{
			currentSelectedUIElement.LeftClick();
		}
	}

	public List<DropdownEntryData> GetEntryDatas()
	{
		List<DropdownEntryData> list = new List<DropdownEntryData>();
		for (int i = 0; i < _options.Length; i++)
		{
			if (Manager.platform.IsLoggedOn || (!Manager.platform.IsLoggedOn && _options[i].joinMethod == RadicalJoinGameMenu.JoinMethod.IP))
			{
				list.Add(new DropdownEntryData(i, _options[i].name, null, null, null));
			}
		}
		return list;
	}
}
