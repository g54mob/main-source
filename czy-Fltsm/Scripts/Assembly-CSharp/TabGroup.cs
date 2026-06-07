using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
	private List<TabGroupButton> _tabButtons;

	public void Subscribe(TabGroupButton button)
	{
		if (_tabButtons == null)
		{
			_tabButtons = new List<TabGroupButton>();
		}
		if (button.IsSelected)
		{
			button.Activate();
		}
		else
		{
			button.Deactivate();
		}
		_tabButtons.Add(button);
	}

	public void Select(TabGroupButton button)
	{
		foreach (TabGroupButton tabButton in _tabButtons)
		{
			if (tabButton == button)
			{
				tabButton.Activate();
			}
			else
			{
				tabButton.Deactivate();
			}
		}
	}
}
