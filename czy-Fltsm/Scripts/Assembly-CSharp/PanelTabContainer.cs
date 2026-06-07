using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PajamaLlama;

public class PanelTabContainer : MonoBehaviour
{
	[Serializable]
	private struct TabPage
	{
		public AnimatedToggle Tab;

		public Transform Page;
	}

	[SerializeField]
	[NamedArrayElement(new string[] { "Tab" })]
	private TabPage[] _tabs;

	[SerializeField]
	private SelectableGroup _selectableGroup;

	private List<TabPage> _activeTabs = new List<TabPage>();

	private List<TabPage> _inactiveTabs = new List<TabPage>();

	public void Initialize()
	{
		bool flag = false;
		_activeTabs.Clear();
		_inactiveTabs.Clear();
		TabPage[] tabs = _tabs;
		for (int i = 0; i < tabs.Length; i++)
		{
			TabPage item = tabs[i];
			if (HasActiveChild(item.Page))
			{
				_activeTabs.Add(item);
				item.Tab.gameObject.SetActive(value: true);
				if (item.Tab.isOn)
				{
					if (flag)
					{
						item.Tab.SetIsOnWithoutNotify(value: false);
						item.Page.gameObject.SetActive(value: false);
					}
					else
					{
						flag = true;
						item.Page.gameObject.SetActive(value: true);
					}
				}
			}
			else
			{
				item.Tab.gameObject.SetActive(value: false);
				item.Tab.isOn = false;
				item.Page.gameObject.SetActive(value: false);
				_inactiveTabs.Add(item);
			}
		}
		if (_activeTabs.Count <= 1)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		base.gameObject.SetActive(value: true);
		_selectableGroup.Initialize();
		if (!flag)
		{
			_activeTabs[0].Tab.isOn = true;
			_activeTabs[0].Page.gameObject.SetActive(value: true);
		}
	}

	public void ToggleFirstTab()
	{
		if (_activeTabs.Count > 1)
		{
			_activeTabs[0].Tab.isOn = true;
		}
	}

	private bool HasActiveChild(Transform transform)
	{
		int childCount = transform.childCount;
		while (0 < childCount--)
		{
			if (transform.GetChild(childCount).gameObject.activeSelf)
			{
				return true;
			}
		}
		return false;
	}
}
