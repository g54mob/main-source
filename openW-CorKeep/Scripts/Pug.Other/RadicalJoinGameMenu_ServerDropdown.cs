using System;
using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using UnityEngine;
using UnityEngine.Events;

public class RadicalJoinGameMenu_ServerDropdown : RadicalMenuOption
{
	public DropdownUIElement dropdown;

	public RadicalMenuOptionTextInput textInput;

	public bool listIPConnections;

	public UnityEvent<string> onActiveEntryChanged;

	private const string dateFormat = "dateFormat";

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		dropdown.SetEntryDatas(GetEntryDatas());
		dropdown.HideDropdownList(selectButton: false);
	}

	public void OnActiveEntryChanged()
	{
		if (dropdown.activeEntry != null)
		{
			onActiveEntryChanged?.Invoke(dropdown.activeEntry.entryData.string0);
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
		List<SavedServer> previousServers = Manager.prefs.GetPreviousServers(listIPConnections);
		List<DropdownEntryData> list = new List<DropdownEntryData>();
		string[] array = LocalizationManager.GetTranslation("months").Split(' ');
		for (int i = 0; i < previousServers.Count; i++)
		{
			SavedServer savedServer = previousServers[i];
			DateTime lastJoin = savedServer.lastJoin;
			string text = array[Mathf.Clamp(lastJoin.Month - 1, 0, 11)];
			string[] subStringFormatFields = new string[3]
			{
				lastJoin.Year.ToString(),
				lastJoin.Day.ToString(),
				text.ToString()
			};
			list.Add(new DropdownEntryData(i, savedServer.name, "dateFormat", subStringFormatFields, savedServer.gameId));
		}
		return list;
	}
}
