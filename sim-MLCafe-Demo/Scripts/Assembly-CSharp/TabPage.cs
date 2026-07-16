using System;
using UnityEngine;

[Serializable]
public class TabPage
{
	public TabButton tabButton;

	public GameObject tabBody;

	public int tabIndex;

	private TabSwitcher tabSwitcher;

	public void InitTabPage(TabSwitcher tabSwitcher, int index)
	{
		this.tabSwitcher = tabSwitcher;
		tabIndex = index;
		tabButton.buttonField.SubscribeToOnClick(delegate
		{
			tabSwitcher.UpdatePageVisibility(tabIndex);
		});
	}

	public void ShowPage()
	{
		tabBody.SetActive(value: true);
		tabButton.Select();
	}

	public void HidePage()
	{
		tabBody.SetActive(value: false);
		tabButton.Deselect();
	}
}
