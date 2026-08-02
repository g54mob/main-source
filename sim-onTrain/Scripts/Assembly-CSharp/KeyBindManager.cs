using System.Collections.Generic;
using UnityEngine;

public class KeyBindManager : MonoBehaviour
{
	private List<SettingsKeyBindItem> keyBindItems = new List<SettingsKeyBindItem>();

	private void Start()
	{
		GetComponentsInChildren(includeInactive: true, keyBindItems);
	}

	public void OnKeyAssigned(SettingsKeyBindItem changedItem, KeyCode newKey)
	{
		foreach (SettingsKeyBindItem keyBindItem in keyBindItems)
		{
			if (!(keyBindItem == changedItem) && keyBindItem.GetCurrentKey() == newKey)
			{
				keyBindItem.ClearKey();
			}
		}
	}
}
