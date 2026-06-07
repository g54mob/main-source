using System;
using System.Collections.Generic;
using Factory;
using Motorways;
using Motorways.Themes;
using Popups;
using UnityEngine;
using UnityEngine.UI;

public class ColorblindCustomisationPanel : MonoBehaviour
{
	[SerializeField]
	private List<Image> ColorDisplays = new List<Image>();

	[Dependency]
	private IScope _appScope;

	[Dependency]
	private PopupStack _popupStack;

	public event Action onUpdated;

	public void Initialise(IScope scope, PopupStack popupStack)
	{
		_appScope = scope;
		_popupStack = popupStack;
		BuildVisualPanel();
	}

	public void BuildVisualPanel()
	{
		Theme activeColorblindTheme = _appScope.Get<MotorwaysThemeDatabase>().ActiveColorblindTheme;
		for (int i = 0; i < MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS; i++)
		{
			ColorDisplays[i].color = activeColorblindTheme.buildingColorGroups[i].GetColor(ThemeComponentGroupTarget.BuildingBase);
		}
	}

	public void OnPopupHidden()
	{
		BuildVisualPanel();
		this.onUpdated?.Invoke();
	}

	public void OnCustomisePressed()
	{
		_popupStack.PushPopup<ColorblindCustomisePopup>().Initialise(_appScope, StringId.Colorblind_Popup_Description, OnPopupHidden);
	}
}
