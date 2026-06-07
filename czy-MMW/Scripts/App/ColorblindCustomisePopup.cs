using System;
using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using Motorways;
using Motorways.Themes;
using Popups;
using UnityEngine;
using UnityEngine.Serialization;

public class ColorblindCustomisePopup : BasePopup
{
	[Dependency]
	private PopupStack _popupStack;

	[SerializeField]
	private LocalizedTextUI _headerText;

	private Action _onConfirmed;

	[Dependency]
	private IScope _appScope;

	[FormerlySerializedAs("CurrentSelectedColors")]
	[SerializeField]
	private List<ChosenColorButton> ChosenColors = new List<ChosenColorButton>();

	private const int DefaultSelectedChosenColorIndex = 0;

	private int _selectedChosenColor;

	[FormerlySerializedAs("SelectableColors")]
	[SerializeField]
	private List<AvailableColorButton> AvailableColors = new List<AvailableColorButton>();

	private AvailableColorButton _previouslySelectedAvailableColor;

	private List<int> _newChosenIndexes = new List<int>();

	public void Initialise(IScope scope, StringId headerStringId, Action onConfirmed = null)
	{
		_headerText.SetStringId(scope, headerStringId);
		_onConfirmed = onConfirmed;
		MotorwaysThemeDatabase motorwaysThemeDatabase = _appScope.Get<MotorwaysThemeDatabase>();
		Theme activeColorblindTheme = motorwaysThemeDatabase.ActiveColorblindTheme;
		List<int> playerColorblindPaletteIndexes = _appScope.Get<ActivePlayer>().MotorwaysExtendedUserProfile.PlayerColorblindPaletteIndexes;
		_newChosenIndexes = new List<int>(playerColorblindPaletteIndexes);
		for (int i = 0; i < activeColorblindTheme.buildingColorGroups.Count; i++)
		{
			ChosenColors[i].Initialise(activeColorblindTheme.buildingColorGroups[i]);
		}
		ChosenColors[_selectedChosenColor].IsSelected = true;
		ColorGroup[] activeColorblindColorGroups = motorwaysThemeDatabase.ActiveColorblindColorGroups;
		for (int j = 0; j < activeColorblindColorGroups.Length; j++)
		{
			AvailableColors[j].Initialise(activeColorblindColorGroups[j]);
		}
		foreach (int item in playerColorblindPaletteIndexes)
		{
			AvailableColors[item].IsChosen = true;
		}
	}

	public override void OnPopupClosed()
	{
		base.OnPopupClosed();
		_onConfirmed?.Invoke();
	}

	public void ClosePressed()
	{
		_popupStack.PopPopup();
	}

	public override void Reset()
	{
		base.Reset();
		if (_selectedChosenColor >= 0)
		{
			ChosenColors[_selectedChosenColor].IsSelected = false;
		}
		foreach (AvailableColorButton availableColor in AvailableColors)
		{
			availableColor.IsSelected = false;
			availableColor.IsChosen = false;
		}
		_selectedChosenColor = 0;
		_previouslySelectedAvailableColor = null;
	}

	[UsedImplicitly]
	public void OnSavePressed()
	{
		MotorwaysThemeDatabase motorwaysThemeDatabase = _appScope.Get<MotorwaysThemeDatabase>();
		_appScope.Get<ActivePlayer>().MotorwaysExtendedUserProfile.PlayerColorblindPaletteIndexes = _newChosenIndexes;
		motorwaysThemeDatabase.UpdateColorblindThemesFromActiveUserProfile();
		_popupStack.PopPopup();
	}

	[UsedImplicitly]
	public void OnColorButtonSelected(int index)
	{
		if (_selectedChosenColor >= 0)
		{
			ChosenColors[_selectedChosenColor].IsSelected = false;
		}
		_selectedChosenColor = index;
		if (index >= 0)
		{
			ChosenColors[_selectedChosenColor].IsSelected = true;
		}
	}

	[UsedImplicitly]
	public void OnTopColorButtonConfirmed()
	{
		if (_newChosenIndexes.Count > 0)
		{
			navigation.SetNewFocus(AvailableColors[_newChosenIndexes[_selectedChosenColor]].TouchToggle);
		}
	}

	[UsedImplicitly]
	public void OnAvailableColorSelected(AvailableColorButton selectedColorButton)
	{
		if (_previouslySelectedAvailableColor != null)
		{
			_previouslySelectedAvailableColor.IsSelected = false;
		}
		_previouslySelectedAvailableColor = selectedColorButton;
		_previouslySelectedAvailableColor.IsSelected = true;
	}

	public void OnAvailableColorButtonConfirmed(AvailableColorButton confirmedColorButton)
	{
		if (!confirmedColorButton.TouchToggle.IsOn || _selectedChosenColor < 0 || _selectedChosenColor >= ChosenColors.Count)
		{
			return;
		}
		ChosenColorButton chosenColorButton = ChosenColors[_selectedChosenColor];
		AvailableColorButton availableColorButton = AvailableColors[_newChosenIndexes[_selectedChosenColor]];
		if (confirmedColorButton == availableColorButton)
		{
			navigation.SetNewFocus(chosenColorButton.FocusPoint);
		}
		else if (confirmedColorButton.IsChosen)
		{
			int chosenColorIndexFor = GetChosenColorIndexFor(confirmedColorButton);
			if (chosenColorIndexFor != -1)
			{
				ChosenColors[chosenColorIndexFor].SwapColorGroupWith(chosenColorButton);
				int value = _newChosenIndexes[chosenColorIndexFor];
				_newChosenIndexes[chosenColorIndexFor] = _newChosenIndexes[_selectedChosenColor];
				_newChosenIndexes[_selectedChosenColor] = value;
			}
			navigation.SetNewFocus(chosenColorButton.FocusPoint);
		}
		else
		{
			availableColorButton.IsChosen = false;
			confirmedColorButton.IsChosen = true;
			chosenColorButton.SetColorGroup(confirmedColorButton.ColorGroup);
			_newChosenIndexes[_selectedChosenColor] = confirmedColorButton.Index;
			navigation.SetNewFocus(chosenColorButton.FocusPoint);
		}
		confirmedColorButton.IsSelected = false;
		_previouslySelectedAvailableColor = null;
	}

	private int GetChosenColorIndexFor(AvailableColorButton availableColorButton)
	{
		int result = -1;
		for (int i = 0; i < _newChosenIndexes.Count; i++)
		{
			if (_newChosenIndexes[i] == availableColorButton.Index)
			{
				result = i;
				break;
			}
		}
		return result;
	}
}
