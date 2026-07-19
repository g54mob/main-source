using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tabs : MonoBehaviour
{
	[Header("Tab")]
	public int tab;

	[Header("Sprites")]
	public Sprite buttonDefault;

	public Sprite buttonSelected;

	[Header("Tab colors")]
	public Color tabColorDefault;

	public Color tabColorSelected;

	[Header("Icon colors")]
	public Color iconColorDefault;

	public Color iconColorSelected;

	[Header("Groups")]
	public List<TabGroup> tabGroups = new List<TabGroup>();

	private void Start()
	{
		if (tabGroups.Count > 0)
		{
			TabSet(0);
		}
	}

	public void TabSet(int t)
	{
		foreach (TabGroup tabGroup in tabGroups)
		{
			if (tabGroup.tabPanel != null)
			{
				tabGroup.tabPanel.gameObject.SetActive(value: false);
			}
		}
		RawImage[] componentsInChildren;
		Text[] componentsInChildren2;
		foreach (TabGroup tabGroup2 in tabGroups)
		{
			tabGroup2.tabButton.GetComponent<Image>().sprite = buttonDefault;
			tabGroup2.tabButton.GetComponent<Image>().color = tabColorDefault;
			componentsInChildren = tabGroup2.tabButton.GetComponentsInChildren<RawImage>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].color = iconColorDefault;
			}
			componentsInChildren2 = tabGroup2.tabButton.GetComponentsInChildren<Text>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].color = iconColorDefault;
			}
		}
		tab = t;
		if (tabGroups[tab].tabPanel != null)
		{
			tabGroups[tab].tabPanel.gameObject.SetActive(value: true);
			tabGroups[tab].tabPanel.gameObject.SendMessage("SelectedTab", tabGroups[tab].tabButton, SendMessageOptions.DontRequireReceiver);
		}
		tabGroups[tab].tabButton.GetComponent<Image>().sprite = buttonSelected;
		tabGroups[tab].tabButton.GetComponent<Image>().color = tabColorSelected;
		componentsInChildren = tabGroups[tab].tabButton.GetComponentsInChildren<RawImage>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].color = iconColorSelected;
		}
		componentsInChildren2 = tabGroups[tab].tabButton.GetComponentsInChildren<Text>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			componentsInChildren2[i].color = iconColorSelected;
		}
	}

	public void TabClick(Transform t)
	{
		for (int i = 0; i < tabGroups.Count; i++)
		{
			if (t == tabGroups[i].tabButton)
			{
				TabSet(i);
				break;
			}
		}
	}
}
