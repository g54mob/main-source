using System.Collections.Generic;
using UnityEngine;

public class UIMenuLocatorWidgetContainer : MonoBehaviour
{
	[SerializeField]
	private List<UIMenuLocatorWidgetData> _widgets = new List<UIMenuLocatorWidgetData>();

	private void Awake()
	{
		RegisterAllWidgets();
	}

	public void RegisterAllWidgets()
	{
		foreach (UIMenuLocatorWidgetData widget in _widgets)
		{
			if (widget.UIMenu != null)
			{
				widget.UIMenuLocator.SetUIMenu(widget.UIMenu);
			}
		}
	}
}
